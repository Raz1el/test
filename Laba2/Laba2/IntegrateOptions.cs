using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laba2
{
    public class IntegrateOptions
    {
        public int N { get; set; }
        public double LeftValue { get; set; }
        public double RightValue { get; set; }
        public double dVariable { get { return (RightValue-LeftValue) / N; } }
    }
}
