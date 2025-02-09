using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionServiceManagementSystem
{
    class StreamingService
    {
        private string serviceName;
        private float servicePrice;
        private List<Film> availableFilms= new List<Film>();
        public StreamingService(string name, float price) 
        {
            this.serviceName = name;
            this.servicePrice = price;
        }

        public void AddFilm(Film addedFilm)
        {
            foreach(Film film in  availableFilms) 
            { 
                if(addedFilm.CompareTo(film) == 0)
                {
                    Console.WriteLine("Film is already on this streaming service");
                    return;
                }
            }
            Console.WriteLine("Film Added");
            availableFilms.Add(addedFilm);
      
        }
        public void RemoveFilm(Film removeFilm)
        {
            foreach (Film film in availableFilms)
            {
                if (removeFilm.CompareTo(film) == 0)
                {
                    Console.WriteLine("Film Removed");
                    availableFilms.Remove(removeFilm);
                }
            }
        }
    }
}
