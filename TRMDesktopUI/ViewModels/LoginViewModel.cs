using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRMDesktopUI.ViewModels
{
    public class LoginViewModel : Screen
    {
        private string _username;
        private string _password;


        public string Username
        {
            get { return _username; }
            set {
                _username = value;
                NotifyOfPropertyChange(() => Username);
                NotifyOfPropertyChange(() => CanLogIn);
            }
        }

        public string Password
        {
            get { return _password; }
            set {
                _password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanLogIn);
            }
        }

        public bool CanLogIn
        {
            get
            {
                bool output = false;

                if (Username?.Length > 0 && Password?.Length > 0) {
                    output = true;
                }

                return output;
            }
        }

        public void LogIn()
        {
            Console.WriteLine();
        }
    }
}
