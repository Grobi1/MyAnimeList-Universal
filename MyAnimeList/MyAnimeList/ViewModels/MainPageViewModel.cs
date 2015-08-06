using MyAnimeList.Models;
using MyAnimeList.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace MyAnimeList.ViewModels
{
    class MainPageViewModel : ViewModelBase
    {
        RelayCommand _togglePaneCommand;

        string _userName;
        bool _isPaneOpen;

        UserViewModel _userVM;

        public bool IsPaneOpen
        {
            get
            {
                return _isPaneOpen;
            }

            set
            {
                if (!UserManager.HasCredentials())
                {
                    _isPaneOpen = true;
                }
                else
                    _isPaneOpen = value;
                OnPropertyChanged();
            }
        }

        public bool CanTogglePane { get { return true; }  }

        public RelayCommand TogglePaneCommand
        {
            get
            {
                return _togglePaneCommand;
            }

            set
            {
                _togglePaneCommand = value;
            }
        }

        public string UserName
        {
            get
            {
                return _userName;
            }

            set
            {
                _userName = value;
                OnPropertyChanged();
            }
        }

        public UserViewModel UserVM
        {
            get
            {
                return _userVM;
            }

            set
            {
                _userVM = value;
            }
        }

        public MainPageViewModel()
        {
            TogglePaneCommand = new RelayCommand(param => TogglePane() , param => CanTogglePane);
            UserVM = new UserViewModel();
            bool result = UserManager.HasCredentials();
            IsPaneOpen = !result;
            if(result)
            {
                UserManager.GetCredentialFromLocker();
                UserName = UserManager.ServiceUser.Name;
                UserVM.IsLoggedIn = true;
            }
        }

        public void TogglePane()
        {
            IsPaneOpen = !IsPaneOpen;
        }
    }
}
