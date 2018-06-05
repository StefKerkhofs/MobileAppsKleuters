using cameraatje.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace cameraatje.ViewModels
{
    //Author: Stef Kerkhofs
    public class MainPageViewModel : ViewModelBase
    {
       
        private ImageSource logo;
        public ImageSource Logo
        {
            get { return logo; }
            set { SetProperty(ref logo, value); }
        }

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

        public ICommand TapCommand { get; private set; }
        public ICommand NavigateToLoginCommand { get; private set; }
        public ICommand NavigateToOverviewToddlerCommand { get; private set; }

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Start";
            Logo = ImageSource.FromResource("cameraatje.Images.logo.png");
            School = ImageSource.FromResource("cameraatje.Images.account_kleuter.png");
            Home = ImageSource.FromResource("cameraatje.Images.account_thuis.png");

            NavigateToLoginCommand = new DelegateCommand(NavigateToLogin);
            NavigateToOverviewToddlerCommand = new DelegateCommand(NavigateToOverviewToddler);
            TapCommand = new Command(OnTapped);
        } 

        private async void NavigateToLogin()
        {
            var p = new NavigationParameters();
          
            p.Add("user", new User());
          await  NavigationService.NavigateAsync("Login", p);
        }

        private async void NavigateToOverviewToddler()
        {

            await NavigationService.NavigateAsync("OverviewToddler");
        }

        private void OnTapped(object s)
        {
            if (s.ToString() == "school")
            {
                NavigateToOverviewToddler();
            }
            else if(s.ToString()=="home")
            {
                NavigateToLogin();
            }
        }

    

        
    }
}
