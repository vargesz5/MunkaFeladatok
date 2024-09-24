using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games
{
    internal class Tasks
    {
        List<PS5Game> gamesList;

        public Tasks(string filePath)
        {
            gamesList = new List<PS5Game>();

            foreach (var item in File.ReadAllLines(filePath, Encoding.UTF8).Skip(1))
            {
                string[] parts = item.Split(";");
                string title = parts[0];
                int publishYear = Convert.ToInt32(parts[1]);
                double price = Convert.ToDouble(parts[2].Replace('.', ',').Replace("Ingyenes", "0"));
                string developer = parts[3];
                string publisher = parts[4];
                bool rayTracing = (parts[5] == "Igen");
                bool PS4Version = (parts[6] == "Igen");

                PS5Game newGame = new(title, publishYear, price, developer, publisher, rayTracing, PS4Version);
                gamesList.Add(newGame);
            }
        }
        public void Task1()
        {
            double maxPrice;
            Console.Write("Max price: ");
            maxPrice = Convert.ToDouble(Console.ReadLine());
            var newList = gamesList.Where(x => x.Price <= maxPrice).OrderByDescending(x => x.Price).ThenBy(x => x.Title);
            Console.WriteLine($"Game with max: {maxPrice}$ price:");
            foreach (var item in newList)
            {
                string PS4 = (item.PS4Version) ? "PS4 version available" : "PS4 verison not available";
                Console.WriteLine($"{item.Title},{item.Developer},{item.Price}$,{PS4}");
            }
        }
        public void Task2() 
        {
            double avgPrice = gamesList.Where(x => x.PS4Version).Average(x => x.Price);
            Console.WriteLine($"Avarage price of PS5 games with PS4 version: {avgPrice:N2}$");
        }
        public void Task3()
        {
            Console.Write("Adj me 10 és 80 % között egy számot: ");
            double percent = Convert.ToInt32(Console.ReadLine());
            foreach (var item in gamesList)
            {
                Console.WriteLine($"{item.Title}, {item.DiscountedPrice(percent)}");
            }
        }

        public void Task4()
        {
            Console.WriteLine("Developers and the games's Avarage price: ");
            foreach (var item in gamesList.GroupBy(x => x.Publisher))
            {
                Console.WriteLine($"{item.Key},{item.Average(x => x.Price)}");
            }
        }
        public void Task5()
        {
            Console.WriteLine();
            Console.WriteLine($"1$ -> {PS5Game.rate} HUF");
            foreach (var item in gamesList)
            {
                Console.WriteLine($"{item.Title},{item.Developer},{item.PriceHUF:N0} HUF");
            }
        }
        public void Task6()
        {
            double PS4percent = 100.0*gamesList.Count(x=>x.PS4Version)/gamesList.Count();
            double RayTracingPercent = 100.0 * gamesList.Count(x => x.RayTracing) / gamesList.Count();
            Console.WriteLine($"Games with PS4 version: {PS4percent:N1}% Ray Tracing: {RayTracingPercent:N1}%");
        }
        public void Task7()
        {
            var minPrice = gamesList.Where(x=>x.Price!=0).OrderBy(x => x.Price).First();
            Console.WriteLine($"The cheapest game: {minPrice.Title}, {minPrice.Price}");
        }
        public void Task8()
        {
            foreach (var item in gamesList.Where(x=>x.RayTracing).GroupBy(x=>x.PublishYear))
            {
                Console.WriteLine($"{item.Key}, {item.Count()}");
            }
        }
    }
}
