using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAllPaths
{
    public class Algoritms
    {
        public class Range
        {
            public int Port { get; set; }
            public double MinVal { get; set; }
            public double MaxVal { get; set; }
        }
        public int recursiveCount = 0;
        public static List<List<ProcessStep>> nodeRouteList = new List<List<ProcessStep>>();
        public List<ProcessStep> GetStartNode()
        {
            var nodeInstance = new Node();
            var nodeList = nodeInstance.CreateNodes();
            var connectionList = nodeInstance.CreateConnections();
            var returnlist = new List<ProcessStep>();
            foreach (var node in nodeList)
            {
                if (!connectionList.Any(x => x.EndNode == node.Id))
                {
                    returnlist.Add(node);
                }
            }
            return returnlist;
        }
        public List<List<ProcessStep>> GetAllRoutes()
        {
            var startNodeList = GetStartNode();
            var tNodeList = new List<ProcessStep>();
            foreach (var child in startNodeList)
            {
                ComputePaths(child, tNodeList);
            }
            return nodeRouteList;
        }

        public void ComputePaths(ProcessStep root, List<ProcessStep> nodeList)
        {
            var tNodeList = new List<ProcessStep>();
            tNodeList.AddRange(nodeList);
            tNodeList.Add(root);
            if (root.Children != null && root.Children.Any() && recursiveCount <= 100)
            {
                recursiveCount++;
                foreach (var child in root.Children)
                {
                    if (tNodeList.Where(x => x.Id == child.Id).Count() > 1)
                    {
                        continue;
                    }
                    ComputePaths(child, tNodeList);
                }
            }
            else
            {
                nodeRouteList.Add(tNodeList);
            }
        }
        public void ComputeSimulationPaths(ProcessStep root, List<ProcessStep> nodeList)
        {
            
                var nextPort = MakeDecision(root);
                var nextNode = new Node().CreateConnections().FirstOrDefault(x=>x.StartNode==root.Id && x.FromPort==nextPort);
                Console.WriteLine(root.Id);
                if(root.Children.Count()>0) 
                { 
                    ComputeSimulationPaths(nodeList.FirstOrDefault(x=>x.Id==nextNode.EndNode), nodeList); 
                }
        }
        public int MakeDecision(ProcessStep step)
        {

            List<Range> rangeList = new List<Range>();

            step.Ports = step.Ports.OrderBy(x => x.Probability).ToList();
            double minVal=0;
            foreach (var item in step.Ports)
            {
                rangeList.Add(new Range{Port=item.Id,MinVal=minVal,MaxVal= minVal+ item.Probability });
                minVal +=item.Probability;
            }

            var minProbability = step.Ports.OrderBy(x=>x.Probability).Select(x=>x.Probability).ToList()[0];
            Random rand = new Random();
            int mincoumt = 0;
            const int iterations = 1000000;
            for (int i = 0; i < iterations; i++)
            {
                var tRandomValue = rand.Next(1, 101);
                mincoumt+= tRandomValue;
            }
            var value = ((float)mincoumt / iterations);
            var sss = (Convert.ToDouble(String.Format("{0:0.00}", value)) - (int) value)*100;
            var trange = Convert.ToInt16(value.ToString().Substring(value.ToString().Length - 2));
            var range = rangeList.FirstOrDefault(x => trange > x.MinVal * 100 && trange <= x.MaxVal * 100);
            
            return range.Port;
        }

        public void Simulate()
        {
            double totalCost = 0;
            double totalTime = 0;
            var startNodeList = GetStartNode()[0];
            totalCost += startNodeList.Cost;
            totalTime += startNodeList.Time;
            foreach (var node in startNodeList.Children)
            {
                if (node.Ports.Count == 1)
                {
                    totalCost += node.Cost;
                    totalTime += node.Time;
                }
            }
            var nodeInstance = new Node();
            var nodeList = nodeInstance.CreateNodes();
            ComputeSimulationPaths(startNodeList, nodeList);
        }
    }
}
