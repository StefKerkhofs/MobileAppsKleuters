using cameraatje.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
//Stef
namespace cameraatje.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService) 
            : base (navigationService)
        {
            Title = "Start";
            
            NavigateToLoginCommand = new DelegateCommand(NavigateToLogin);
        }

       
        private void NavigateToLogin()
        {
            var p = new NavigationParameters();
            p.Add("user", new User());
            NavigationService.NavigateAsync("Login", p);
        }
      
        public ICommand NavigateToLoginCommand { get; private set; }
    }
}
