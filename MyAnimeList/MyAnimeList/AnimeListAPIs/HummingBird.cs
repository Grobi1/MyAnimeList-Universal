using MyAnimeList.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyAnimeList.Models;
using System.Collections.ObjectModel;

namespace MyAnimeList.AnimeListAPIs
{
    class HummingBird : IAnimeApi
    {
        public Task<int> AddAnimeAsync(Anime anime)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAnimeAsync(Anime anime)
        {
            throw new NotImplementedException();
        }

        public Task<ObservableCollection<Anime>> GetAnimeListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Anime>> SearchAnimeAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAnimeAsync(Anime anime)
        {
            throw new NotImplementedException();
        }

        public Task<bool> VerifyCredentialsAsync(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
