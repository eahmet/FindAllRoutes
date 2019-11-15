using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAllPaths
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var algoritmInstance = new Algoritms();
            var routerList = algoritmInstance.GetAllRoutes();
            double totalSum = 0;
            double totalCost = 0;

            foreach (var route in routerList)
            {
                Console.WriteLine("Geçilen Adımlar: "+String.Join(",",route.ToList().Select(x=>x.Id)));
                Console.WriteLine("Geçilen Adım Sayısı:" + route.Count.ToString());
                Console.WriteLine("Geçilen Adımların Toplam Süresi:" + route.ToList().Select(x => x.Time).Sum());
                totalSum += route.ToList().Select(x => x.Time).Sum();
                Console.WriteLine("Geçilen Adımların Toplam Maliyeti:" + route.ToList().Select(x => x.Cost).Sum());
                totalCost += route.ToList().Select(x => x.Cost).Sum();
                Console.WriteLine("----------");
            }
            Console.WriteLine("----------");
            Console.WriteLine("Toplam Akış Sayısı:" + routerList.Count());
            Console.WriteLine("Ortalama Süre:" + totalSum / routerList.Count());
            Console.WriteLine("Ortalama Maliyet:" + totalCost / routerList.Count());
            Console.WriteLine("----------");
            Console.ReadLine();
        }
    }
}
