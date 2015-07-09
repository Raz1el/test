using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laba2
{
    public static class ElementaryMathFunc
    {
        public static double Call(string Name,double Value)
        {
            switch (Name)
            {
                case "exp":
                    return Math.Exp(Value);
                case "sin":
                    return Math.Sin(Value);
                case "cos":
                    return Math.Cos(Value);
                case "arccos":
                    return Math.Acos(Value);
                case "arcsin":
                    return Math.Asin(Value);
                case "tg":
                    return Math.Tan(Value);
                case "ctg":
                    return 1/Math.Tan(Value);
                case "arctg":
                    return Math.Atan(Value);
                    
                case "arcctg":
                    return Math.PI/2-Math.Atan( Value);
                   
                case "log":
                    return Math.Log(Value);
                   
                case "sh":
                    return Math.Sinh(Value);
                    
                case "ch":
                    return Math.Cosh(Value);
                    
                case "abs":
                    return Math.Abs(Value);
                   
                case "sqrt":
                    return Math.Sqrt(Value);
                   
                case "th":
                    return Math.Tanh(Value);
                    
                case "cth":
                    return 1 / Math.Tanh(Value);
                    
                case "arsh":
                    return Math.Log(Value+Math.Sqrt(Value*Value+1));
            
                case "arch":
                    return Math.Log(Value + Math.Sqrt(Value * Value - 1));
                   
                case "arth":
                    return Math.Log(Math.Sqrt(1-Value*Value)/(1-Value));
                case "arcth":
                    return  Math.Log(Math.Sqrt(Value*Value-1) / (Value - 1));
            }
            throw new ArgumentException();
        }
        public static double Call(string Name, double Value1,double Value2)
        {
            switch (Name)
            {
                case "+":
                    return Value1 + Value2;
                case "-":
                    return Value1 - Value2;
                case "*":
                    return Value1 * Value2;
                case "/":
                    return Value1 / Value2;
                case "log":
                    return Math.Log(Value1,Value2);
                case "pow":
                case "^":
                    return Math.Pow(Value1,Value2);
            }
            throw new ArgumentException();
        }
        public static double Call(string Name, IEnumerable<double> Values)
        {
            switch (Values.Count<double>())
            {
                case 1:
                    return Call(Name,Values.ElementAt<double>(0));
                case 2:
                    return Call(Name, Values.ElementAt<double>(1), Values.ElementAt<double>(0));
                default:
                    throw new ArgumentException();
            }
        }
    }
}
