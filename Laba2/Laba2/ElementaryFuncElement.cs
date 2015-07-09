using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laba2
{
    public enum Types { Digit, Func, Operation, OpParenthesis, CloseParenthesis, Var, Separator,Param };
    public class ElementaryFuncElement
    {
        public Types Type { get; set; }
        public int? Priority { get; set; }
        public int? OperandCount { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public ElementaryFuncElement(string Element)
        {
            var DecSeparatorFormat = new System.Globalization.NumberFormatInfo();
            DecSeparatorFormat.CurrencyDecimalSeparator = ".";
            try
            {
                Value = double.Parse(Element, DecSeparatorFormat);
                Type = Types.Digit;
                Name = Element;
            }
            catch
            {
                if (Element.Length != 1 && Function.FuncTable.Contains<string>(Element))
                {

                    Type = Types.Func;
                    Priority = 0;
                    OperandCount = 1;
                    Name = Element;
                }
                else
                {

                    switch (Element)
                    {
                        case ")":
                            Type = Types.CloseParenthesis;
                            Priority = 1;
                            Name = Element;
                            break;
                        case "(":
                            Type = Types.OpParenthesis;
                            Priority = 0;
                            Name = Element;
                            break;
                        case "+":
                            Type = Types.Operation;
                            Priority = 2;
                            OperandCount = 2;
                            Name = Element;
                            break;
                        case "-":
                            Type = Types.Operation;
                            Priority = 2;
                            OperandCount = 2;
                            Name = Element;
                            break;
                        case "*":
                            Type = Types.Operation;
                            Priority = 3;
                            OperandCount = 2;
                            Name = Element;
                            break;
                        case "/":
                            Type = Types.Operation;
                            Priority = 3;
                            OperandCount = 2;
                            Name = Element;
                            break;
                        case "^":
                            Type = Types.Operation;
                            Priority = 4;
                            OperandCount = 2;
                            Name = Element;
                            break;
                        case ",":
                            Type = Types.Separator;
                            Name = ",";
                            break;
                        default:
                            if (char.IsLetter(Element.ToCharArray()[0]))
                            {
                                Type = Types.Param;
                                Name = Element;
                                break;
                            }
                            else
                                throw new FormatException();
                    }
                }
            }
        }
    }
}
