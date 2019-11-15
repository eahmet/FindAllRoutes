using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAllPaths
{
    public class Algoritms
    {
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
                if(!connectionList.Any(x=>x.EndNode == node.Id))
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

        public void ComputePaths(ProcessStep root,List<ProcessStep> nodeList)
        {
            var tNodeList = new List<ProcessStep>();
            tNodeList.AddRange(nodeList);
            tNodeList.Add(root);
            if (root.Children!=null && root.Children.Any() && recursiveCount <= 100)
            {
                recursiveCount++;
                foreach (var child in root.Children)
                {
                    if(tNodeList.Where(x=>x.Id== child.Id).Count()>1) 
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
    }
}
