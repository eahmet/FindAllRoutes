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
            var nodeList = new Node().CreateData();

            //Console.WriteLine(new Algoritms().GetStartNode(nodeList).StartNode.ToString());
            //Console.WriteLine(new Algoritms().GetEndNode(nodeList).StartNode.ToString());

            //Console.WriteLine(new Algoritms().CreateLinkedList(nodeList, new Algoritms().GetStartNode(nodeList)));

            //var sad = new Algoritms().Test(nodeList, new Algoritms().GetStartNode(nodeList)).ToList();
            var sad = new Algoritms().GetAllRoutes(nodeList, new Algoritms().GetStartNode(nodeList));
            
            foreach (var item in sad)
            {
                Console.WriteLine(String.Join(",",item.ToList().Select(x=>x.Id)));
                Console.WriteLine("----------");
            }
            Console.ReadLine();
        }
    }
}
