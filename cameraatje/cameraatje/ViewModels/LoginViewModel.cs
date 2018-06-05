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
     author: sasha van de voorde
     */
    public class LoginViewModel : ViewModelBase
    {
        
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
        public LoginViewModel( INavigationService navigationService, IPageDialogService dialogService, IDbContext dbContext, IRepository repos) : base(navigationService)
        {
            loginCommand = new DelegateCommand(login);
            this.dialogService = dialogService;
            this.repos = repos;
            this.dbContext = dbContext;
        }
       
        public async void login()
        {
            //Firebase
            try
            {
                string ApiKey = "AIzaSyBsGi32c2dYar02Zok9YHAanQU1J9OyxXA";
                
                // of course you can login using other method, not just email+password
                var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));

                var a = await auth.SignInWithEmailAndPasswordAsync(email, password);
                await dialogService.DisplayAlertAsync("Aanmelden is gelukt","User", "OK");
                var p = new NavigationParameters();
               /* var u = await repos.GetUserAsync(email);
                var t = await repos.GetToddlerAsync(u.kleuter_id);
                p.Add("Toddler", t);*/
                await NavigationService.NavigateAsync("OverViewToddlerView");
              
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                await dialogService.DisplayAlertAsync("test", e.ToString(), "Cancel");
            
            }
        }
   
      
    }
}
