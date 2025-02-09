using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionServiceManagementSystem
{
    class StreamingService :IComparable<StreamingService>
    {
        private string serviceName;
        private float servicePrice;
        private List<Film> availableFilms= new List<Film>();
        private List<TVShow> availableShows = new List<TVShow>();
        public StreamingService(string name, float price) 
        {
            this.serviceName = name;
            this.servicePrice = price;
        }

        public void AddFilm(Film addedFilm)
        {
            if(!this.ContainsFilm(addedFilm))
            {
                Console.WriteLine("Film Added");
                availableFilms.Add(addedFilm);
            }
            else
            {
                Console.WriteLine("Film is already on this streaming service");
            }
        }
        public void RemoveFilm(Film removeFilm)
        {
            foreach (Film film in availableFilms)
            {
                if (film.CompareTo(removeFilm) == 0)
                {
                    Console.WriteLine("Film Removed");
                    availableFilms.Remove(film);
                }
            }
        }

        public void PrintAvailableFilms()
        {
            foreach(Film film in availableFilms)
            {
                Console.WriteLine(film.ToString());
            }
        }

        public void AddShow(TVShow addedShow)
        {
            if (!this.ContainsShow(addedShow))
            {
                Console.WriteLine("Show Added");
                availableShows.Add(addedShow);
            }
            else
            {
                Console.WriteLine("Show is already on this streaming service");
            }
        }
        public void RemoveShow(TVShow removeShow)
        {
            foreach (TVShow show in availableShows)
            {
                if (removeShow.CompareTo(show) == 0)
                {
                    availableShows.Remove(show);
                }
            }
        }

        public void PrintAvailableShows()
        {
            foreach (TVShow show in availableShows)
            {
                Console.WriteLine(show.ToString());
            }
        }

        public int CompareTo(StreamingService other)
        {
            return this.serviceName.CompareTo(other.serviceName);
        }

        public bool ContainsFilm(Film checkFilm)
        {
            foreach(Film film in availableFilms)
            {
                if(checkFilm.CompareTo(film)==0)
                {
                    return true;
                }
            }

            return false;
        }

        public bool ContainsShow(TVShow checkShow)
        {
            foreach (TVShow show in availableShows)
            {
                if (checkShow.CompareTo(show) == 0)
                {
                    return true;
                }
            }

            return false;
        }


        public void SetFilmRating(Film filmToRate, int rating)
        {
            foreach (Film film in availableFilms)
            {
                if (filmToRate.CompareTo(film) == 0)
                {
                    film.SetRating(rating);
                }
            }
        }

        public void SetShowRating(TVShow showToRate, int rating)
        {
            foreach (TVShow show in availableShows)
            {
                if (showToRate.CompareTo(show) == 0)
                {
                    show.SetRating(rating);
                }
            }
        }
    }
}
