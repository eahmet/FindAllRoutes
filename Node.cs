using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAllPaths
{
    public class Connections
    {
        public int StartNode { get; set; }
        public int EndNode { get; set; }
        public double Cost { get; set; }
        public double Time { get; set; }
    }
    public class Node
    {
        public int Id { get; set; }
        public double Cost { get; set; }
        public double Time { get; set; }
        public List<Node> Children { get; set; }
        public Node()
        {

        }
        public List<Node> CreateData()
        {
            //var returnList= new List<Node>
            //{
            //    new Node() { StartNode = 43411, EndNode = 43412, Cost = 1, Time = 3 },
            //    new Node() { StartNode = 43412, EndNode = 43414, Cost = 2, Time = 2 },
            //    new Node() { StartNode = 43437, EndNode = 43412, Cost = 1, Time = 1 },
            //    new Node() { StartNode = 43414, EndNode = 43415, Cost = 2, Time = 3 },
            //    new Node() { StartNode = 43415, EndNode = 43416, Cost = 2, Time = 4 },
            //    new Node() { StartNode = 43416, EndNode = 43417, Cost = 2.2, Time = 3.5 },
            //    new Node() { StartNode = 43417, EndNode = 43416, Cost = 2.4, Time = 3.8 },
            //    new Node() { StartNode = 43417, EndNode = 43418, Cost = 2.6, Time = 4.1 },
            //    new Node() { StartNode = 43418, EndNode = 43419, Cost = 2.8, Time = 4.4 },
            //    new Node() { StartNode = 43418, EndNode = 43422, Cost = 3, Time = 4.7 },
            //    new Node() { StartNode = 43418, EndNode = 43421, Cost = 3.2, Time = 5 },
            //    new Node() { StartNode = 43418, EndNode = 43425, Cost = 3.4, Time = 5.3 },
            //    new Node() { StartNode = 43418, EndNode = 43420, Cost = 3.6, Time = 5.6 },
            //    new Node() { StartNode = 43418, EndNode = 43423, Cost = 3.8, Time = 5.9 },
            //    new Node() { StartNode = 43418, EndNode = 43424, Cost = 4, Time = 6.2 },
            //    new Node() { StartNode = 43425, EndNode = 43426, Cost = 4.2, Time = 6.5 },
            //    new Node() { StartNode = 43426, EndNode = 43427, Cost = 4.4, Time = 6.8 },
            //    new Node() { StartNode = 43427, EndNode = 43428, Cost = 4.6, Time = 7.1 },
            //    new Node() { StartNode = 43428, EndNode = 43429, Cost = 4.8, Time = 7.4 },
            //    new Node() { StartNode = 43429, EndNode = 43419, Cost = 5, Time = 7.7 },
            //    new Node() { StartNode = 43429, EndNode = 43430, Cost = 5.2, Time = 8 },
            //    new Node() { StartNode = 43430, EndNode = 43431, Cost = 5.4, Time = 8.3 },
            //    new Node() { StartNode = 43431, EndNode = 43432, Cost = 5.6, Time = 8.6 },
            //    new Node() { StartNode = 43432, EndNode = 43433, Cost = 5.8, Time = 8.9 },
            //    new Node() { StartNode = 43433, EndNode = 43431, Cost = 6, Time = 9.2 },
            //    new Node() { StartNode = 43433, EndNode = 43434, Cost = 6.2, Time = 9.5 },
            //    new Node() { StartNode = 43434, EndNode = 43435, Cost = 6.4, Time = 9.8 },
            //    new Node() { StartNode = 43435, EndNode = 43436, Cost = 6.6, Time = 10.1 },
            //    new Node() { StartNode = 43436, EndNode = 43413, Cost = 6.8, Time = 10.4 },
            //    new Node() { StartNode = 43434, EndNode = 43431, Cost = 7, Time = 10.7 },
            //    new Node() { StartNode = 43470, EndNode = 43471, Cost = 7.2, Time = 11 },
            //    new Node() { StartNode = 43471, EndNode = 43437, Cost = 7.4, Time = 11.3 },
            //    new Node() { StartNode = 43471, EndNode = 43411, Cost = 7.6, Time = 11.6 }
            //};
            var connectionList = new List<Connections>
            {
                new Connections() { StartNode = 1, EndNode = 2, Cost = 1, Time = 3 },
                new Connections() { StartNode = 2, EndNode = 3, Cost = 2, Time = 2 },
                new Connections() { StartNode = 2, EndNode = 4, Cost = 1, Time = 1 },
                new Connections() { StartNode = 3, EndNode = 5, Cost = 2, Time = 3 },
                new Connections() { StartNode = 5, EndNode = 6, Cost = 2, Time = 4 },
                new Connections() { StartNode = 4, EndNode = 7, Cost = 2.2, Time = 3.5 },
                new Connections() { StartNode = 4, EndNode = 8, Cost = 2.4, Time = 3.8 },
                new Connections() { StartNode = 4, EndNode = 9, Cost = 2.4, Time = 3.8 },
                new Connections() { StartNode = 9, EndNode = 2, Cost = 2.4, Time = 3.8 }
            };
            var nodeList = new List<Node>
            {
                new Node(){ Id=1,Time=1,Cost=2},
                new Node(){ Id=2,Time=1,Cost=2},
                new Node(){ Id=3,Time=1,Cost=2},
                new Node(){ Id=4,Time=1,Cost=2},
                new Node(){ Id=5,Time=1,Cost=2},
                new Node(){ Id=6,Time=1,Cost=2},
                new Node(){ Id=7,Time=1,Cost=2},
                new Node(){ Id=8,Time=1,Cost=2},
                new Node(){ Id=9,Time=1,Cost=2}
            };
            foreach (var node in nodeList)
            {
                var connections = connectionList.Where(x => x.StartNode == node.Id).Select(k=>k.EndNode).ToList();
                node.Children = nodeList.Where(x=>connections.Contains(x.Id)).ToList();
            }
            return nodeList;
        }
    }
}
