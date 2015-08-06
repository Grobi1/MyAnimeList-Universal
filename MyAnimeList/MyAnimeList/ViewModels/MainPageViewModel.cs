using MyAnimeList.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAnimeList.ViewModels
{
    class MainPageViewModel
    {
        ObservableCollection<Anime> _watchedAnime;

        public ObservableCollection<Anime> WatchedAnime
        {
            get
            {
                return _watchedAnime;
            }

            set
            {
                _watchedAnime = value;
            }
        }
    }
}
