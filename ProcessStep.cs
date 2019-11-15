using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAllPaths
{
    public class ProcessStep
    {
        public int Id { get; set; }
        public double Cost { get; set; }
        public double Time { get; set; }
        public List<ProcessStep> Children { get; set; }
    }
}
