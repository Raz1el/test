#region ...
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Laba2
{
    public class FunctionOld
    {
        public static string[] FuncTable = new string[]
        {   
            "+","-","*","/","^","exp","arcsin","sin","arccos","cos",
            "arctg","arcctg","ctg","tg","log","sh","ch","abs","pow",
            "sqrt","th","cth","arsh","arch","arth","arcth"
        };
        public delegate double Func(double Var,IEnumerable<Parameter> Params,string VarName);
        public Func _body;
        List<Parameter> _params;
        List<ElementaryFuncElement> _textBody;
        public List<ElementaryFuncElement> _reverseNotation;
        public double Invoke(double Var,IEnumerable<Parameter> Params,string VarName)
        {
            return _body(Var, Params, VarName);
        }
        public static FunctionOld GetFunc(string Func)
        {
            var Function = new FunctionOld();
            Function._textBody = ConvertExpression("[]" + Func.ToLower());
            Function._reverseNotation = GetReverseNotation(Function._textBody);
            Function._body = BuildFunc(Function._reverseNotation);
            return Function;

        }
        static Func BuildFunc(List<ElementaryFuncElement> ReversNotation)
        {
            return (Var,Params,VarName) =>
            {
                Stack<double> Stack = new Stack<double>();
                foreach(var Ex in ReversNotation)
                {
                    switch (Ex.Type)
                    {
                        case Types.Digit:
                            Stack.Push(Ex.Value);
                            break;
                        case Types.Var:
                            if (Ex.Name == VarName)
                            {
                                Ex.Value = Var;
                            }
                            else
                            Ex.Value = (from Param in Params where Param.Name == Ex.Name select Param.Value).First<double>();
                            Stack.Push(Ex.Value);
                            break;
                        case Types.Operation:
                        case Types.Func:
                            List<double> Temp = new List<double>();
                            for (int i = 0; i < Ex.OperandCount; i++)
                            {
                                Temp.Add(Stack.Pop());
                            }
                            Stack.Push(ElementaryMathFunc.Call(Ex.Name, Temp));
                            break;
                            
                    }
                }
                return Stack.Pop();
                
            };
        }
        static List<ElementaryFuncElement> GetReverseNotation(List<ElementaryFuncElement> Func)
        {
            var DecSeparatorFormat = new System.Globalization.NumberFormatInfo();
            DecSeparatorFormat.CurrencyDecimalSeparator = ".";
            List<ElementaryFuncElement> Notation = new List<ElementaryFuncElement>();
            Stack<ElementaryFuncElement> Stack = new Stack<ElementaryFuncElement>();
            ElementaryFuncElement LastFunc=null;
            foreach (var Expression in Func)
            {

                switch (Expression.Type)
                {
                    case Types.Digit:
                    case Types.Var:
                        Notation.Add(Expression);
                        break;
                    case Types.Func:
                        Stack.Push(Expression);
                        LastFunc = Expression;
                        break;
                    case Types.Separator:
                        LastFunc.OperandCount++;
                        break;
                    case Types.Operation:
                        if (Stack.Count == 0)
                        {
                            Stack.Push(Expression);
                        }
                        else if (Expression.Priority > Stack.Peek().Priority)
                        {
                            Stack.Push(Expression);
                        }
                        else
                        {
                            while (Stack.Peek().Priority >= Expression.Priority)
                            {
                                Notation.Add(Stack.Pop());
                                if (Stack.Count == 0)
                                    break;
                            }
                            Stack.Push(Expression);
                        }
                        break;
                    case Types.OpParenthesis:
                        Stack.Push(Expression);
                        break;
                    case Types.CloseParenthesis:
                        if (Stack.Count != 0)
                        {
                            while (Stack.Peek().Type != Types.OpParenthesis)
                            {
                                Notation.Add(Stack.Pop());
                                if (Stack.Count == 0)
                                    break;
                            }
                            Stack.Pop();
                            if (Stack.Count!=0&&Stack.Peek().Type == Types.Func)
                            {
                                Notation.Add(Stack.Pop());
                            }
                        }
                        break;
                }
                
            }
            while (Stack.Count != 0)
            {
                Notation.Add(Stack.Pop());
            }
            return Notation;
            
        }
        static string FindDigits(string s)
        {
            StringBuilder strb = new StringBuilder();
            bool flag = false;
            for (int i = 0; i < s.Length; i++)
            {
                if (!flag && char.IsDigit(s[i]))
                {
                    strb.Append("[");
                    flag = true;
                }
                if (flag && !char.IsDigit(s[i]) && s[i] != '.')
                {
                    strb.Append("]");
                    flag = false;
                }
                strb.Append(s[i]);
                if (flag && i == s.Length - 1)
                    strb.Append("]");
            }
            return strb.ToString();

        }
        static string FindConst(string s)
        {
            StringBuilder strb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                switch (s[i])
                {
                    case 'p':
                        if (i != s.Length - 1)
                            if (s[i + 1] == 'i')
                                strb.Append("[");
                        break;
                    case 'i':
                        if (i != 0)
                        {
                            if (s[i - 1] == 'p')
                                strb.Append("i]");
                            else
                                strb.Append(s[i]);
                        }
                        continue;

                    case 'e':
                        if (i < s.Length - 2)
                        {
                            if (s[i + 1] == 'x' && s[i + 2] == 'p' && s[i + 3] == '(')
                            {
                                strb.Append(s[i]);
                                continue;
                            }
                        }
                        strb.Append("[e]");
                        continue;
                }
                strb.Append(s[i]);
            }

            return strb.ToString();
        }
        static string FindVar(string s)
        {
            StringBuilder strb = new StringBuilder();
            bool flag = false;
            for (int i = 0; i < s.Length; i++)
            {

                if (s[i] == ']')
                {
                    flag = true;
                    
                }
                else
                if (flag && char.IsLetter(s[i]))
                {
                    strb.Append("[" + s[i] + "]");
                    continue;
                }
                else
                if (s[i] == '[')
                {
                    flag = false;
                }
                strb.Append(s[i]);

            }
            return strb.ToString();
        }
        static string FindAbs(string s)
        {
            StringBuilder strb = new StringBuilder();
            bool flag = false;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '|')
                {
                    if (flag)
                    {
                        flag = false;
                        strb.Append(")");
                    }
                    else
                    {
                        strb.Append("abs(");
                        flag = true;
                    }

                }
                else
                {

                    strb.Append(s[i]);
                }

            }
            if (flag)
                throw new FormatException();
            return strb.ToString();
        }
        static string FindFunc(string s)
        {
            foreach (var Func in FuncTable)
            {
                s = s.Replace(Func, "[" + Func + "]");
            }
            return s;
        }
        static string FindParenthesis(string s)
        {

            s = s.Replace("(", "[(]");
            s = s.Replace(")", "[)]");
            return s;

        }
        static List<ElementaryFuncElement> ConvertExpression(string s)
        {
            var ArrayEx = FindParenthesis(FindVar(FindFunc(FindAbs(FindConst(FindDigits(s)))))).Split(new char[] { ']', '[',' ' }, StringSplitOptions.RemoveEmptyEntries);
            List<ElementaryFuncElement> ListEx = new List<ElementaryFuncElement>();
            List<ElementaryFuncElement> Temp = new List<ElementaryFuncElement>();
            foreach (var Ex in ArrayEx)
            {
                if (Ex == "e")
                {
                    ListEx.Add(new ElementaryFuncElement(Math.E.ToString().Replace(',', '.')));
                    continue;
                }
                else if (Ex == "pi")
                {
                    ListEx.Add(new ElementaryFuncElement(Math.PI.ToString().Replace(',', '.')));
                    continue;
                }
                ListEx.Add(new ElementaryFuncElement(Ex));
            }
            if (ListEx.Count == 1)
            {
                return ListEx;
            }
            else
            {
                for (int i = 0; i < ListEx.Count - 1; i++)
                {
                    if (i == 0 && ListEx[i].Name == "-")
                    {
                        Temp.Add(new ElementaryFuncElement("0"));
                    }
                    if (ListEx[i].Type == Types.OpParenthesis && ListEx[i + 1].Name == "-")
                    {
                        Temp.Add(ListEx[i]);
                        Temp.Add(new ElementaryFuncElement("0"));
                    }
                    else
                    {
                        Temp.Add(ListEx[i]);
                    }
                    if (
                        ((ListEx[i].Type == Types.Digit || ListEx[i].Type == Types.Var) && (ListEx[i + 1].Type == Types.Digit || ListEx[i + 1].Type == Types.Var))
                        || (ListEx[i].Type == Types.CloseParenthesis && ((ListEx[i + 1].Type == Types.Digit) || ListEx[i + 1].Type == Types.Var || ListEx[i + 1].Type == Types.Func || ListEx[i + 1].Type == Types.OpParenthesis))
                        || ((ListEx[i].Type == Types.Digit || ListEx[i].Type == Types.Var) && ((ListEx[i + 1].Type == Types.OpParenthesis || ListEx[i].Type == Types.Func)))
                        )
                    {
                        Temp.Add(new ElementaryFuncElement("*"));
                    }
                    if (ListEx[i].Type == Types.Operation && ListEx[i + 1].Type == Types.Operation)
                    {
                        throw new FormatException();
                    }

                    if (i == ListEx.Count - 2)
                        Temp.Add(ListEx[i + 1]);
                }
            }
            return Temp;
        }
        public override string ToString()
        {
            StringBuilder strb = new StringBuilder();
            foreach (var s in _textBody)
            {
                strb.Append(s);
            }
            return strb.ToString();
        }
    }
}
#endregion
