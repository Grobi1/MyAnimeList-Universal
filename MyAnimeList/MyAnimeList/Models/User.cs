using MyAnimeList.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAnimeList.Models
{
    public class User : ModelBase
    {
        string _name;
        ApiServices _selectedApi;

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
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
    }
}
