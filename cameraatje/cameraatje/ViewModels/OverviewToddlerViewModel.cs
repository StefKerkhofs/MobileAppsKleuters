using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using cameraatje.Models;
using cameraatje.Repositories;
using cameraatje.Contracts;
using Prism.Navigation;
using Prism.Services;
using Firebase.Storage;
using Firebase.Auth;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Windows.Input;

namespace cameraatje.ViewModels
{
	public class OverviewToddlerViewModel : ViewModelBase
	{
        private IRepository repos;
        private IDbContext dbContext;

        private ICommand getPhotoCommand;
        private List<ImageSource> toddlerImages;
        private IList<Toddler> toddlers;
        public IList<Toddler> Toddlers
        {
            set { SetProperty(ref toddlers, value);}
            get { return toddlers; }
        }
        private Toddler selectedToddler;
        public Toddler SelectedToddler
        {
            get { return selectedToddler; }
            set
            {
                if (SetProperty(ref selectedToddler, value) && selectedToddler != null)
                {
                    var p = new NavigationParameters
                    {
                        { "Kid", selectedToddler },
                        { "PictureUrl", pictureUrl }
                    };
                    NavigationService.NavigateAsync("OverviewCornerView", p);
                    selectedToddler = null;
                }
            }
        }

        private string pictureUrl;
        public OverviewToddlerViewModel(INavigationService navigationService, IDbContext dbContext, IRepository repos) : base(navigationService)
        {
            this.dbContext = dbContext;
            this.repos = repos;
           // getPhotoCommand = new DelegateCommand(getPhotos);
        }
      
        public async override void OnNavigatedTo(NavigationParameters parameters)
        {

            if (parameters.ContainsKey("PictureUrl"))
            {
                pictureUrl = (string)parameters["PictureUrl"];
            }

            repos = new CameraatjeRepository(dbContext);
            Toddlers = await repos.GetToddlersAsync();
            getPhotos();
        }
        public async void getPhotos() {
            //Firebase
            try
            {
                string ApiKey = "AIzaSyBsGi32c2dYar02Zok9YHAanQU1J9OyxXA";
                string Bucket = "gs://cameraatje-69273.appspot.com/";
                string AuthEmail = "sashavandevoorde@gmail.com";
                string AuthPassword = "Koekjessaus123";

                // of course you can login using other method, not just email+password
                var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
                var a = await auth.SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword);

                
                //Firebase download
                HttpClient client = await HttpClientFactory.CreateHttpClientAsync(new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                });
                foreach (Toddler t in Toddlers)
                {
                    var stream = await client.GetStreamAsync(t.foto_string);
                    toddlerImages.Add(ImageSource.FromStream(() => stream));
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
