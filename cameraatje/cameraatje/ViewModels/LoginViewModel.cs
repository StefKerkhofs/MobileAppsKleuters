using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Firebase.Auth;
using System.Windows.Input;
using Prism.Services;
using System.Threading.Tasks;
using System.Diagnostics;
using Prism.Navigation;
using cameraatje.Models;
using cameraatje.Repositories;

using System.Linq;
using cameraatje.Contracts;

namespace cameraatje.ViewModels
{
    /*
     author: Sasha van de Voorde
     */
    public class LoginViewModel : ViewModelBase
    {
       private Models.User user;
        private string email;
        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }
        private IRepository repos;
        private IDbContext dbContext;
        public ICommand loginCommand { get; private set; }
        private IPageDialogService dialogService;
        public LoginViewModel( INavigationService navigationService, IDbContext dbContext, IRepository repos, IPageDialogService dialogService ) : base(navigationService)
        {
            this.repos = repos;
            loginCommand = new DelegateCommand(login);
            this.dialogService = dialogService;
        }
       
        public async void login()
        {
            //Firebase
            try
            {
                string ApiKey = "AIzaSyBsGi32c2dYar02Zok9YHAanQU1J9OyxXA";
                
                // of course you can login using other method, not just email+password
                var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
               // user = await repos.GetUserAsync("sasha@test.com");
                var a = await auth.SignInWithEmailAndPasswordAsync(email, password);
                await dialogService.DisplayAlertAsync("Aanmelden is gelukt","Sasha", "OK");
                var p = new NavigationParameters();
                await NavigationService.NavigateAsync("OverviewToddler");
              
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                await dialogService.DisplayAlertAsync("test", e.ToString(), "Cancel");
            
            }
        }
   
      
    }
}



