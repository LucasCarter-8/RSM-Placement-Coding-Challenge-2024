using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionServiceManagementSystem
{
    class Film : IComparable<Film>
    {
        private string filmName;
        private int yearOfRelease;
        private string genre;
        private int rating;
        private float runtime;
        public Film(string filmName, int year, string genre, float runtime) 
        {
            this.filmName = filmName;
            this.yearOfRelease = year;             
            this.genre = genre;
            this.runtime = runtime;

            //default set rating
            this.rating = 0;
        }

        public void SetRating(int rating)
        {
            this.rating = rating;
        }

        public int CompareTo(Film other)
        {
            if (this.filmName == other.filmName && this.yearOfRelease == other.yearOfRelease)
            {
                return 0;
            }
            else
            {
                return -1;
            }

        }
    }
}
