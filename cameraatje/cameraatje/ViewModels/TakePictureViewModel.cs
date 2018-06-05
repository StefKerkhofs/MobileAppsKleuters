using cameraatje.Contracts;
using cameraatje.Models;
using Firebase.Auth;
using Firebase.Storage;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace cameraatje.ViewModels
{
	public class TakePictureViewModel : ViewModelBase
	{
        private IRepository repos;
        private IDbContext dbContext;
        IPageDialogService dialogService;


        public TakePictureViewModel(INavigationService navigationService, IDbContext dbContext, IRepository repos, IPageDialogService dialogService) : base(navigationService)
        {
            Title = "Take Picture";
            this.dbContext = dbContext;
            this.repos = repos;
            this.dialogService = dialogService;

            TakePictureCommand = new DelegateCommand(ExecuteTakePictureCommand);
        }


        private ImageSource source;
        public ImageSource Source
        {
            get { return source; }
            set { SetProperty(ref source, value); }
        }

        public ICommand TakePictureCommand { get; private set; }

        private async void ExecuteTakePictureCommand()
        {
            await CrossMedia.Current.Initialize();

            if(!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await dialogService.DisplayAlertAsync("No Camera", ":( No camera available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = "test.jpg",
                PhotoSize = PhotoSize.Small
            });

            if (file == null)
                return;

            await dialogService.DisplayAlertAsync("File Location", file.Path, "OK");



            try
            {
                string ApiKey = "AIzaSyBsGi32c2dYar02Zok9YHAanQU1J9OyxXA";
                string Bucket = "cameraatje-69273.appspot.com";
                string AuthEmail = "sasha@test.com";
                string AuthPassword = "testtest";

                // of course you can login using other method, not just email+password

               

                var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
                var a = await auth.SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword);

                //Firebase Upload
                // Constructr FirebaseStorage, path to where you want to upload the file and Put it there
                var task = new FirebaseStorage(
                    Bucket,
                    new FirebaseStorageOptions
                    {
                        AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                    })
                    .Child("data")
                    .Child("foto's")
                    .Child(Convert.ToString(DateTime.Now) + "file.png".Replace("/", ""))
                    .PutAsync(file.GetStream());

                 //Track progress of the upload
                task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

                // await the task to wait until upload completes and get the download url
                var downloadUrl = await task;
                await dialogService.DisplayAlertAsync("Download Url", downloadUrl, "OK");

                //Firebase download
                Source = downloadUrl;

            }
            catch (Exception ex)
            {
                await dialogService.DisplayAlertAsync("Exception was thrown", ex.Message, "OK");
            }
        }

    }
	
}
