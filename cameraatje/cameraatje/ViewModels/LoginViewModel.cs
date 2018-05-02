using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Firebase.Auth;
using System.Windows.Input;

namespace cameraatje.ViewModels
{
    public class LoginViewModel : BindableBase
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
        public LoginViewModel()
        {
            loginCommand = new DelegateCommand(login);
        }
        public async void login()
        {
            //Firebase
            try
            {
                string ApiKey = "YOUR_API_KEY";
                string Bucket = "your-bucket.appspot.com";
                
                // of course you can login using other method, not just email+password
                var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
                var a = await auth.SignInWithEmailAndPasswordAsync(email, password);

            }
            catch (Exception e)
            { }
        }
    }
}
