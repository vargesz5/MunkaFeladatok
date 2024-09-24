using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games
{
    internal class PS5Game
    {
        public PS5Game(string title, int publishYear, double price, string developer, string publisher, bool rayTracing, bool pS4Version)
        {
            Title = title;
            PublishYear = publishYear;
            Price = price;
            Developer = developer;
            Publisher = publisher;
            RayTracing = rayTracing;
            PS4Version = pS4Version;
        }

        public string Title { get; set; }
        public int PublishYear { get; set; }
        public double Price { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public bool RayTracing { get; set; }
        public bool PS4Version { get; set; }

        public static double rate = 354.46;

        public double DiscountedPrice(double percent)
        {
            return Price * (100 - percent) / 100.0;
        }
        public double PriceHUF
        {
            get
            {
                return Price * rate;
            }
        }
    }
}

