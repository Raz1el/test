using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laba2
{
    public class Area
    {
       public double Value { get; set; }
       public void Add(double X)
       {
           Value += X;
       }
       public void Sub(double X)
       {
           Value -= X;
       }
       public string ToString(string Format)
       {
           return Value.ToString(Format);
       }
    }
}
