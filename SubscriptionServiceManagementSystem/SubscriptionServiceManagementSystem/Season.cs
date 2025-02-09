using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionServiceManagementSystem
{
    class Season : IComparable<Season>
    {
        private int seasonNum;
        private int yearOfRelease;
        private int numOfEpisodes;
        public Season(int seasons, int year, int episodes) 
        {
            this.seasonNum = seasons;
            this.yearOfRelease = year;
            this.numOfEpisodes = episodes;
        }

        public int CompareTo(Season other)
        {
            return this.seasonNum.CompareTo(other.seasonNum);
        }
    }
}
