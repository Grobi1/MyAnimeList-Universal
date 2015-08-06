using MyAnimeList.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAnimeList.Utility
{
    public class ApiList : List<ApiServices>
    {
        public ApiList()
        {
            Add(new ApiServices("MyAnimeList", new AnimeListAPIs.MyAnimeList()));
            Add(new ApiServices("HummingBird", new AnimeListAPIs.HummingBird()));
        }
    }

    public class ApiServices
    {
        public string Name { get; set; }
        public IAnimeApi Api { get; set; }

        public ApiServices(string name, IAnimeApi api)
        {
            Name = name;
            Api = api;
        }
    }

}
