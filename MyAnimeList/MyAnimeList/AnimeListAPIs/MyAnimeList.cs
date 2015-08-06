using MyAnimeList.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyAnimeList.Models;
using System.Collections.ObjectModel;
using MyAnimeList.Utility;
using System.Xml.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MyAnimeList.AnimeListAPIs
{
    class MyAnimeList : IAnimeApi
    {
        static HttpClient _client;
        static bool _hasUserAgent;

        public MyAnimeList()
        {
            _client = new HttpClient();
            _hasUserAgent = _client.DefaultRequestHeaders.UserAgent.TryParseAdd("api-indiv-947E5C715D875A35C09C74BBC413DD94");
        }

        public async Task<int> AddAnimeAsync(Anime anime)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteAnimeAsync(Anime anime)
        {
            throw new NotImplementedException();
        }

        public async Task<ObservableCollection<Anime>> GetAnimeListAsync()
        {
            await Task.Run(async () =>
            {
                try
                {
                    string userName = UserManager.GetCredentialFromLocker().UserName;


                    Task<string> getStringTask = _client.GetStringAsync("http://myanimelist.net/malappinfo.php?status=all&u=" + userName + "&nocache=" + DateTime.UtcNow.ToString("r"));
                    XDocument xDoc = XDocument.Parse(await getStringTask);

                    ObservableCollection<Anime> animeList = new ObservableCollection<Anime>(); ;

                    Anime a;
                    foreach (XElement e in xDoc.Root.Elements("anime"))
                    {
                        a = new Anime();
                        a.Id = Int32.Parse(e.Element("series_animedb_id").Value);
                        a.Name = e.Element("series_title").Value;
                        a.Episodes = Int32.Parse(e.Element("series_episodes").Value);
                        a.Status = Int32.Parse(e.Element("my_status").Value);
                        a.Type = Int32.Parse(e.Element("series_type").Value);
                        //string filename = a.Id + System.Text.RegularExpressions.Regex.Replace(a.Name, @"[^a-z]", String.Empty);
                        //a.Image = ApplicationData.Current.LocalFolder.Path + "\\images\\" + filename + ".jpg";
                        //client.GetStreamAsync(e.Element("series_image").Value);
                        a.WatchedEpisodes = Int32.Parse(e.Element("my_watched_episodes").Value);
                        a.Episodes = Int32.Parse(e.Element("series_episodes").Value);
                        a.Score = Int32.Parse(e.Element("my_score").Value);
                        a.ImageUrl = e.Element("series_image").Value;
                        a.Version = UInt64.Parse(e.Element("my_last_updated").Value);
                        animeList.Add(a);
                    }

                    return animeList;
                }
                catch { return null; }
            }
            );
            return null;
        }

        public async Task<List<Anime>> SearchAnimeAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateAnimeAsync(Anime anime)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> VerifyCredentialsAsync(string username, string password)
        {
            await Task.Run(async () =>
            {
                var encoded = Convert.ToBase64String(Encoding.UTF8.GetBytes(String.Format("{0}:{1}", username, password)));
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", encoded);

                HttpResponseMessage result = await _client.GetAsync("http://myanimelist.net/api/account/verify_credentials.xml");

                if (result.IsSuccessStatusCode)
                    return true;
                return false;
            });
            return false;

        }
    }
}
