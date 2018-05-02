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

namespace cameraatje.ViewModels
{
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
        public ICommand loginCommand { get; private set; }
        private IPageDialogService dialogService;
        public LoginViewModel( INavigationService navigationService, IPageDialogService dialogService) : base(navigationService)
        {
            dialogService.DisplayAlertAsync("test", "test", "Cancel");
            loginCommand = new DelegateCommand(login);
            this.dialogService = dialogService;
        }
        public async void login()
        {
            //Firebase
            try
            {
                string ApiKey = "AIzaSyBsGi32c2dYar02Zok9YHAanQU1J9OyxXA";
                string Bucket = "your-bucket.appspot.com";
                
                // of course you can login using other method, not just email+password
                var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
                var a = await auth.SignInWithEmailAndPasswordAsync(email, password);
                Debug.WriteLine(email + " " + password );
                await dialogService.DisplayAlertAsync("test", a.ToString(), "Cancel");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                await dialogService.DisplayAlertAsync("test", e.ToString(), "Cancel");
            
            }
        }

      
    }
}
