using MyAnimeList.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAnimeList.Interfaces
{
    public interface IAnimeApi
    {
        Task<bool> VerifyCredentialsAsync(string username, string password);

        Task<ObservableCollection<Anime>> GetAnimeListAsync();

        Task<List<Anime>> SearchAnimeAsync(string name);

        Task<int> AddAnimeAsync(Anime anime);

        Task<int> UpdateAnimeAsync(Anime anime);

        Task<int> DeleteAnimeAsync(Anime anime);
    }
}
