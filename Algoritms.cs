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
        public IEnumerable<IEnumerable<Node>> paths;

        public static List<List<Node>> nodeRouteList = new List<List<Node>>();
        public Node GetStartNode(List<Node> nodeList)
        {
            return nodeList.FirstOrDefault(x => x.Id == 1);
            /*Node startNode = null;
            foreach (var node in nodeList)
            {
                startNode= startNode ?? node;
                if(nodeList.Any(x=>x.Id == startNode.StartNode))
                {
                    startNode = node;
                }
            }
            return startNode;*/
        }
        public Node GetEndNode(List<Node> nodeList)
        {

            Node endNode = null;
            /*foreach (var node in nodeList)
            {
                endNode = endNode ?? node;
                if (nodeList.Any(x => x.StartNode == endNode.EndNode))
                {
                    endNode = node;
                }
            }*/
            return endNode;
        }
        public LinkedList<Node> CreateLinkedList(List<Node> nodeList, Node startNode)
        {
            int startNodeId = 0;
            LinkedList<Node> my_list = new LinkedList<Node>();
            /* my_list.AddFirst(startNode);
             foreach (var node in nodeList)
             {
                 if(startNodeId == 0)
                     startNodeId = node.StartNode;
                 my_list.AddLast(node);

             }
             */
            return my_list;
        }

       public List<List<Node>> GetAllRoutes(List<Node> nodeList, Node startNode)
        {
            var tNodeList = new List<Node>();
            //tNodeList.Add(startNode);
            foreach (var child in startNode.Children)
            {
                ComputePaths(startNode, tNodeList);
            }
            return nodeRouteList;
        }

        public void ComputePaths(Node root,List<Node> nodeList)
        {
            var tNodeList = new List<Node>();
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
        public IEnumerable<IEnumerable<Node>> Test(List<Node> nodeList, Node startNode)
        {

            List<Node> listOfNodes = nodeList;

            Node rootNode = startNode;

            paths = ComputePaths(rootNode, n => n.Children);
            return paths;
        }
        public IEnumerable<IEnumerable<T>> ComputePaths<T>(T Root, Func<T, IEnumerable<T>> Children)
        {
            
            var children = Children(Root);
            if ((children != null && children.Any()) && recursiveCount <= 100)
            {
                recursiveCount++;
                foreach (var Child in children)
                {
                    foreach (var ChildPath in ComputePaths(Child, Children))
                    {
                        foreach (var item in ChildPath)
                        {
                            var a = item.ToString();
                        }
                        yield return new[] { Root }.Concat(ChildPath);
                    }
                }
            }
            else
            {
                yield return new[] { Root };
            }
        }
    }
}
