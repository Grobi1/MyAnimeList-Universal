using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MyAnimeList.Models
{
    [KnownType(typeof(Anime))]
    [DataContract]
    class Anime : ModelBase
    {
        int _id;
        string _name;
        int _episodes;
        int _watchedEpisodes;
        int _status;
        int _type;
        string _image;
        string _imageUrl;
        bool _hasImage;
        int _score;
        int _timesRewatched;
        int _rewatchValue;
        ulong _version;
        DateTime _dateStart;
        DateTime _dateFinish;

        #region Properties

        [DataMember]
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }
        [DataMember]
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        [DataMember]
        public int Episodes
        {
            get { return _episodes; }
            set
            {
                _episodes = value;
                OnPropertyChanged();
            }
        }
        [DataMember]
        public int Status
        {
            get { return _status; }
            set
            {
                _status = value;
                OnPropertyChanged();
            }
        }

        [DataMember]
        public int Type
        {
            get { return _type; }
            set
            {
                _type = value;
                OnPropertyChanged();
            }
        }

        [DataMember]
        public string ImagePath
        {
            get { return _image; }
            set
            {
                _image = value;
                OnPropertyChanged();
            }
        }
        [DataMember]
        public string ImageUrl
        {
            get { return _imageUrl; }
            set
            {
                _imageUrl = value;
                OnPropertyChanged();
            }
        }

        [DataMember]
        public bool HasImage
        {
            get { return _hasImage; }
            set
            {
                _hasImage = value;
                OnPropertyChanged("ImagePath");
                OnPropertyChanged("ImageUrl");
            }
        }

        [DataMember]
        public int Score
        {
            get { return _score; }
            set
            {
                _score = value;
                OnPropertyChanged();
            }
        }
        [DataMember]
        public int WatchedEpisodes
        {
            get { return _watchedEpisodes; }
            set
            {
                _watchedEpisodes = value;
                OnPropertyChanged();
            }
        }
        [DataMember]
        public int TimesRewatched
        {
            get { return _timesRewatched; }
            set
            {
                _timesRewatched = value;
                OnPropertyChanged();
            }
        }
        [DataMember]
        public int RewatchValue
        {
            get { return _rewatchValue; }
            set
            {
                _rewatchValue = value;
                OnPropertyChanged();
            }
        }

        [DataMember]
        public ulong Version
        {
            get { return _version; }
            set
            {
                _version = value;
                OnPropertyChanged();
            }
        }

        [DataMember]
        public DateTime DateStart
        {
            get { return _dateStart; }
            set
            {
                _dateStart = value;
                OnPropertyChanged();
            }
        }

        [DataMember]
        public DateTime DateFinish
        {
            get { return _dateFinish; }
            set
            {
                _dateFinish = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}
