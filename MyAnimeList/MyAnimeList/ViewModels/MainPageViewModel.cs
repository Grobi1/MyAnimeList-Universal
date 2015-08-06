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

        bool _isPaneOpen;

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

        public MainPageViewModel()
        {
            TogglePaneCommand = new RelayCommand(param => TogglePane() , param => CanTogglePane);
            IsPaneOpen = !UserManager.HasCredentials();
        }

        public void TogglePane()
        {
            IsPaneOpen = !IsPaneOpen;
        }
    }
}
