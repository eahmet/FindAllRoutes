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
                Console.WriteLine("Route: "+String.Join(",",route.ToList().Select(x=>x.Id)));
                Console.WriteLine("Total Count of Hops:" + route.Count.ToString());
                Console.WriteLine("Total Time of Route:" + route.ToList().Select(x => x.Time).Sum());
                totalSum += route.ToList().Select(x => x.Time).Sum();
                Console.WriteLine("Total Cost of Hops:" + route.ToList().Select(x => x.Cost).Sum());
                totalCost += route.ToList().Select(x => x.Cost).Sum();
                Console.WriteLine("----------");
            }
            Console.WriteLine("----------");
            Console.WriteLine("Total Route Count:" + routerList.Count());
            Console.WriteLine("Avarage Sum:" + totalSum / routerList.Count());
            Console.WriteLine("Average Cost:" + totalCost / routerList.Count());
            Console.WriteLine("----------");
            Console.ReadLine();
        }
    }
}
