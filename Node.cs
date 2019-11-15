using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAllPaths
{

    public class Node
    {
        public List<ProcessStep> CreateNodes()
        {
            var connectionList = CreateConnections();
            var nodeList = new List<ProcessStep>
            {
                new ProcessStep(){ Id=1,Time=1.1,Cost=2,Ports=new List<Port>{new Port(){Id=1,Probability= 1 }}},
                new ProcessStep(){ Id=2,Time=1.2,Cost=1,Ports=new List<Port>{new Port(){Id=1,Probability= 0.45 }, new Port(){Id=2,Probability= 0.55 }} },
                new ProcessStep(){ Id=3,Time=1.3,Cost=2,Ports=new List<Port>{new Port(){Id=1,Probability= 1 }}},
                new ProcessStep(){ Id=4,Time=2,Cost=1,Ports=new List<Port>{new Port(){Id=1,Probability= 0.4 }, new Port(){Id=2,Probability= 0.2 }, new Port(){Id=3,Probability= 0.4 }}},
                new ProcessStep(){ Id=5,Time=4,Cost=2,Ports=new List<Port>{new Port(){Id=1,Probability= 1 }}},
                new ProcessStep(){ Id=6,Time=0.5,Cost=1,Ports=new List<Port>{new Port(){Id=1,Probability= 1 }}},
                new ProcessStep(){ Id=7,Time=0.6,Cost=2,Ports=new List<Port>{new Port(){Id=1,Probability= 1 }}},
                new ProcessStep(){ Id=8,Time=2,Cost=1,Ports=new List<Port>{new Port(){Id=1,Probability= 1 }}},
                new ProcessStep(){ Id=9,Time=3,Cost=2,Ports=new List<Port>{new Port(){Id=1,Probability= 1 }}},
                new ProcessStep(){ Id=10,Time=6,Cost=8.6,Ports=new List<Port>{new Port(){Id=1,Probability= 1 }}}
            };
            foreach (var node in nodeList)
            {
                var connections = connectionList.Where(x => x.StartNode == node.Id).Select(k => k.EndNode).ToList();
                node.Children = nodeList.Where(x => connections.Contains(x.Id)).ToList();
            }
            return nodeList;
        }
        public List<Connections> CreateConnections()
        {
            return new List<Connections>
            {
                new Connections() { StartNode = 1, EndNode = 2,FromPort=1},
                new Connections() { StartNode = 2, EndNode = 3,FromPort=1},
                new Connections() { StartNode = 2, EndNode = 4,FromPort=2},
                new Connections() { StartNode = 3, EndNode = 5,FromPort=1},
                new Connections() { StartNode = 5, EndNode = 6,FromPort=1},
                new Connections() { StartNode = 4, EndNode = 7,FromPort=3},
                new Connections() { StartNode = 4, EndNode = 8,FromPort=1},
                new Connections() { StartNode = 4, EndNode = 9,FromPort=2},
                new Connections() { StartNode = 9, EndNode = 2,FromPort=1},
                new Connections() { StartNode = 10, EndNode = 9,FromPort=1}
            };
        }
    }
}
