using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using cameraatje.Models;
using cameraatje.Repositories;
using cameraatje.Contracts;
using Prism.Services;
using System.Windows.Input;
using Xamarin.Forms;

namespace cameraatje.ViewModels
{
	public class ChoiceViewModel : ViewModelBase
    {
        private IRepository repos;
        private IDbContext dbContext;
        private Toddler selectedToddler;
        IPageDialogService dialogService;
        public ICommand TapCommand { get; private set; }
        private ImageSource home;
        public ImageSource Home
        {
            get { return home; }
            set { SetProperty(ref home, value); }
        }

        private ImageSource school;
        public ImageSource School
        {
            get { return school; }
            set { SetProperty(ref school, value); }
        }
        public ChoiceViewModel(INavigationService navigationService, IDbContext dbContext, IRepository repos, IPageDialogService dialogService) : base(navigationService)
        {
            Title = "Pick the spot!";
            this.dbContext = dbContext;
            this.repos = repos;
            this.dialogService = dialogService;
            TapCommand = new Command(OnTapped);
            Home = ImageSource.FromResource("cameraatje.Images.home.png");
            School = ImageSource.FromResource("cameraatje.Images.class.png");
        }

        public async override void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("Toddler"))
            {
                selectedToddler = (Toddler)parameters["Toddler"];
            }

            repos = new CameraatjeRepository(dbContext);
        }

        private void OnTapped(object s)
        {
            if (s.ToString() == "school")
            {
                NavigateToSchool();
            }
            else if (s.ToString() == "home")
            {
                NavigateToHome();
            }
        }
        private async void NavigateToSchool()
        {
            var p = new NavigationParameters();
            p.Add("Toddler", selectedToddler);
            await NavigationService.NavigateAsync("OverviewPictureView", p);
        }
        private async void NavigateToHome()
        {
            await NavigationService.NavigateAsync("OverviewToddler");
        }
      
    }
}
