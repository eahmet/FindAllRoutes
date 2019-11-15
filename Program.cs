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
            Console.WriteLine("Which method you want to execute? (S: Simulate,R: Route)");
            var choice =Console.ReadLine();
            if (choice.ToLower() == "r") { 
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
            else if(choice.ToLower()=="s")
            {
                var dicisionList= new List<string>();
                var algoritmInstance = new Algoritms();
                for (int i = 0; i < 100; i++)
                {
                    algoritmInstance.Simulate();
                    Console.WriteLine("----------");
                    //dicisionList.Add(algoritmInstance.MakeDicision());
                }

                Console.WriteLine("Hayır:" + dicisionList.Count(x=>x.Equals("Hayır")));
                Console.WriteLine("Evet:" + dicisionList.Count(x => x.Equals("Evet")));
                Console.ReadLine();
            }
        }
    }
}
