using Prism.Commands;
using Prism.Mvvm;
using System;
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
using System.Collections.Generic;

namespace cameraatje.ViewModels
{
	public class OverviewCornerViewModel : ViewModelBase
	{
        private IRepository repos;
        private IDbContext dbContext;
        private IPageDialogService dialogService;


        public ICommand TapCommand { get; private set; }
        private Toddler selectedToddler;
        private IList<Corner> corners;
        public IList<Corner> Corners
        {
            set { SetProperty(ref corners, value); }
            get { return corners; }
        }
        private Corner selectedCorner;
        public Corner SelectedCorner
        {
            get { return selectedCorner; }
            set
            {
                if (SetProperty(ref selectedCorner, value) && selectedCorner != null)
                {
                    var p = new NavigationParameters
                    {
                        {"Toddler", selectedToddler },
                        { "Corner", selectedCorner },
                    };
                    NavigationService.NavigateAsync("TakePicture", p);
                    selectedCorner = null;
                }
            }
        }

        public OverviewCornerViewModel(INavigationService navigationService, IDbContext dbContext, IRepository repos, IPageDialogService dialogService) : base(navigationService)
        {
            this.dbContext = dbContext;
            this.repos = repos;
            this.dialogService = dialogService;

            TapCommand = new Command(OnTapped);

        }

        public async override void OnNavigatedTo(NavigationParameters parameters)
        {

            if (parameters.ContainsKey("Toddler"))
            {
                selectedToddler = (Toddler)parameters["Toddler"];
            }

            repos = new CameraatjeRepository(dbContext);
            Corners = await repos.GetCornersAsync();
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
