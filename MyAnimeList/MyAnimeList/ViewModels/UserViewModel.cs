using MyAnimeList.Models;
using MyAnimeList.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace MyAnimeList.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
        User _serviceUser;

        RelayCommand _logInCommand;
        RelayCommand _logOutCommand;

        string _logInName = "";
        string _logInPassword = "";
        string _logInStatusMessage = "";
        ApiList _animeListApis;
        ApiServices _selectedApi;

        bool _isLoggedIn;
        bool _isBusy = false;

        public User ServiceUser
        {
            get
            {
                return UserManager.ServiceUser;
            }
        }

        public RelayCommand LogInCommand
        {
            get
            {
                return _logInCommand;
            }

            set
            {
                _logInCommand = value;
            }
        }

        public string LogInName
        {
            get
            {
                return _logInName;
            }

            set
            {
                _logInName = value;
                OnPropertyChanged();
                OnPropertyChanged("CanLogIn");
            }
        }

        public string LogInPassword
        {
            get
            {
                return _logInPassword;
            }

            set
            {
                _logInPassword = value;
                OnPropertyChanged();
                OnPropertyChanged("CanLogIn");
            }
        }

        public bool CanLogIn
        {
            get
            {
                //if (!LogInName.Equals("") && !LogInPassword.Equals("") && !_isBusy)
                    return true;
                return false;
            }
        }

        public ApiList AnimeListApis
        {
            get
            {
                return _animeListApis;
            }

            set
            {
                _animeListApis = value;
            }
        }

        public ApiServices SelectedApi
        {
            get
            {
                return _selectedApi;
            }

            set
            {
                _selectedApi = value;
            }
        }

        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }

            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        public bool IsLoggedIn
        {
            get
            {
                return _isLoggedIn;
            }

            set
            {
                _isLoggedIn = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand LogOutCommand
        {
            get
            {
                return _logOutCommand;
            }

            set
            {
                _logOutCommand = value;
            }
        }

        public string LogInStatusMessage
        {
            get
            {
                return _logInStatusMessage;
            }

            set
            {
                _logInStatusMessage = value;
                OnPropertyChanged();
            }
        }

        public UserViewModel()
        {
            LogInCommand = new RelayCommand(param => LogIn(), param => CanLogIn);
            LogOutCommand = new RelayCommand(param => LogOut(), param => true);
            AnimeListApis = new ApiList();
            SelectedApi = AnimeListApis.First();
        }

        public async Task LogIn()
        {
            IsBusy = true;

            if(await SelectedApi.Api.VerifyCredentialsAsync(LogInName, LogInPassword))
            {
                UserManager.ServiceUser.SelectedApi = SelectedApi;
                UserManager.SaveCredentials(LogInName, LogInPassword);
                IsLoggedIn = true;
            }
            else
            {
                IsLoggedIn = false;
                LogInStatusMessage = "Login failed!";
            }

            IsBusy = false;
        }

        public async Task LogOut()
        {
            var dialog = new MessageDialog("Do you really want to LogOut?");
            dialog.Commands.Add(new UICommand { Label = "Ok", Id = 0 });
            dialog.Commands.Add(new UICommand { Label = "Cancel", Id = 1 });
            var result = await dialog.ShowAsync();

            if ((int)result.Id == 0)
            {
                UserManager.RemoveCredentials();
                IsLoggedIn = false;
            }
        }


    }
}
