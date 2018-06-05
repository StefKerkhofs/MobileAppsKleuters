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
        private IPageDialogService dialogService;
      

        public ICommand TapCommand  { get; private set; }
      
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
                        { "Toddler", selectedToddler },
                        { "PictureUrl", pictureUrl }
                    };
                    NavigationService.NavigateAsync("OverviewCorner", p);
                    selectedToddler = null;
                }
            }
        }

        private string pictureUrl;
        public OverviewToddlerViewModel(INavigationService navigationService, IDbContext dbContext, IRepository repos, IPageDialogService dialogService) : base(navigationService)
        {
            this.dbContext = dbContext;
            this.repos = repos;
            this.dialogService = dialogService; 
          
            TapCommand = new Command(OnTapped);
         
        }
      
        public async override void OnNavigatedTo(NavigationParameters parameters)
        {

            if (parameters.ContainsKey("PictureUrl"))
            {
                pictureUrl = (string)parameters["PictureUrl"];
            }

            repos = new CameraatjeRepository(dbContext);
            Toddlers = await repos.GetToddlersAsync();
        }
        private void OnTapped(object s)
        {
            
                NavigateToTakePicture();
            
        }
        private async void NavigateToTakePicture()
        {

            await NavigationService.NavigateAsync("TakePicture");
        }

    }
}
