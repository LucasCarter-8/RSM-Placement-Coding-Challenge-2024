﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionServiceManagementSystem
{
    class Film : IComparable<Film>
    {
        private string showName;
        private int yearOfRelease;
        private string genre;
        private int rating;
        private float runtime;
        public Film(string showName, int year, string genre, float runtime) 
        {
            this.showName = showName;
            this.yearOfRelease = year;             
            this.genre = genre;
            this.runtime = runtime;

            //default set rating
            this.rating = 0;
        }

        public void SetRating(int rating)
        {
            if(rating < 0 || rating > 5)
            {
                Console.WriteLine("Invalid rating");
            }
            else
            {
                this.rating = rating;
            }
        
        }

        public int CompareTo(Film other)
        {
            if (this.showName == other.showName && this.yearOfRelease == other.yearOfRelease)
            {
                return 0;
            }
            else
            {
                return -1;
            }

        }

        public override string ToString()
        {
            return $"Name: {this.showName}, Year: {this.yearOfRelease}, Genre: {this.genre}, Rating: {this.rating}, Runtime: {this.runtime}";
        }
    }
}
