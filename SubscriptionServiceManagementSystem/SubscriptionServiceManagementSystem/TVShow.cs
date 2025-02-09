using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionServiceManagementSystem
{
    class TVShow
    {
        private string showName;
        private string genre;
        private int rating;
        private List<Season> seasons = new List<Season>();
    
        public TVShow(string showName, string genre, float runtime)
        {
            this.showName = showName;
            this.genre = genre;

            //default set rating
            this.rating = 0;
        }

        public void SetRating(int rating)
        {
            if (rating < 0 || rating > 5)
            {
                Console.WriteLine("Invalid rating");
            }
            else
            {
                this.rating = rating;
            }

        }

        public int CompareTo(TVShow other)
        {
            return this.showName.CompareTo(other.showName);
        }

        public override string ToString()
        {
            return $"Name: {this.showName}, Genre: {this.genre}, Rating: {this.rating}, Number of seasons available: {this.seasons.Count}";
        }
    }
}
