using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laba2
{
    public class Function
    {
        public static string[] FuncTable = new string[]
        {   
            "+","-","*","/","^","exp","sin","arcsin","cos","arccos",
            "tg","ctg","arctg","arcctg","log","sh","arsh","ch","arch","abs","pow",
            "sqrt","th","cth","arth","arcth"
        };     
        #region Fields
        List<ElementaryFuncElement> _funcBody;
        List<ElementaryFuncElement> _reverseNotation;
        Dictionary<double, double> _values;
        char _varName;
        bool _paramsInitFlag;
        #endregion
        #region Props
        public char Var
        {
            get { return _varName; }
            set
            {
                if (Var == Convert.ToChar(0))
                {
                     if (value != 'e')
                     {
                         var Vars=from V in _reverseNotation where (V.Type == Types.Param &&V.Name==value.ToString()) select V;
                         foreach (var V in Vars)
                         {
                                 V.Type = Types.Var;
                         }
                         _varName = value;
                     }

                }
                else
                if (_reverseNotation != null)
                {
                    if (value != 'e')
                    {
                        if (value != Var)
                        {
                            var Params = from V in _reverseNotation where V.Name == value.ToString() select V;
                            var Variables = from V in _reverseNotation where V.Name == Var.ToString() select V;
                            foreach (var Param in Params)
                            {
                                Param.Type = Types.Var;
                            }
                            foreach (var Variable in Variables)
                            {
                                Variable.Type = Types.Param;
                            }
                            _varName = value;
                        }
                    }
                    else
                        throw new ArgumentException();
                }
                else
                    throw new NullReferenceException();
                _values.Clear();
            }
        }
        public int ParamsCount
        {
            get { return (from Item in _reverseNotation where (Item.Type == Types.Param) select Item.Name).Distinct<string>().Count<string>(); }
        }
        #endregion
        #region Ctors
        public Function(string Function,char VarName)
        {
            _funcBody = ConvertExpression("[]" + Function.ToLower().Replace("[", "(").Replace("]", ")").Replace("{", "(").Replace("}", ")"));
            _reverseNotation = GetReverseNotation(_funcBody);
            _values = new Dictionary<double, double>();
            Var = VarName;
            if (ParamsCount == 0)
                _paramsInitFlag = true;
        }
        #endregion
        #region Methods
        string FindDigits(string s)
        {
            StringBuilder strb = new StringBuilder();
            bool NumFind = false;
            for (int i = 0; i < s.Length; i++)
            {
                if (!NumFind && char.IsDigit(s[i]))
                {
                    strb.Append("[");
                    NumFind = true;
                }
                if (NumFind && !char.IsDigit(s[i]) && s[i] != '.')
                {
                    strb.Append("]");
                    NumFind = false;
                }
                strb.Append(s[i]);
                if (NumFind && i == s.Length - 1)
                    strb.Append("]");
            }
            return strb.ToString();
        }
        string FindConst(string s)
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
        string FindVar(string s)
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
        string FindAbs(string s)
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
        string FindFunc(string s)
        {
            foreach (var Func in FuncTable)
            {
                s = s.Replace(Func, "[" + Func + "]");
            }
            s = s.Replace("arc[sin]", "[arcsin]");
            s = s.Replace("arc[cos]", "[arccos]");
            s = s.Replace("c[tg]", "[ctg]");
            s = s.Replace("ar[ctg]", "[arctg]");
            s = s.Replace("arc[ctg]", "[arcctg]");
            s = s.Replace("arc[sin]", "[arcsin]");
            s = s.Replace("ar[sh]", "[arsh]");
            s = s.Replace("ar[ch]", "[arch]");
            s = s.Replace("c[th]", "[cth]");
            s = s.Replace("ar[th]", "[arth]");
            s = s.Replace("ar[cth]", "[arcth]");
            return s;
        }
        string FindParenthesis(string s)
        {
            s = s.Replace("(", "[(]");
            s = s.Replace(")", "[)]");
            return s;
        }
        List<ElementaryFuncElement> ConvertExpression(string s)
        {
            var ArrayEx = FindParenthesis(FindVar(FindFunc(FindAbs(FindConst(FindDigits(s)))))).Split(new char[] { ']', '[', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            List<ElementaryFuncElement> ListEx = new List<ElementaryFuncElement>();
            List<ElementaryFuncElement> Temp = new List<ElementaryFuncElement>();
            foreach (var Ex in ArrayEx)
            {
                if (Ex == "e")
                {
                    ListEx.Add(new ElementaryFuncElement(Math.E.ToString().Replace(',', '.')) {Name="e" });
                    continue;
                }
                else if (Ex == "pi")
                {
                    ListEx.Add(new ElementaryFuncElement(Math.PI.ToString().Replace(',', '.')) { Name = "pi" });
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
                    if (i == 0)
                    {
                        if (ListEx[i].Name == "-")
                        {
                            Temp.Add(new ElementaryFuncElement("0"));
                        }
                        else
                            if (ListEx[i].Type == Types.CloseParenthesis || ListEx[i].Type == Types.Operation || ListEx[i].Type == Types.Separator||(ListEx[i].Type==Types.OpParenthesis&&ListEx[i+1].Type==Types.CloseParenthesis))
                            {
                                throw new FormatException();
                            }
                    }
                    if ((ListEx[i].Type == Types.OpParenthesis || ListEx[i].Type == Types.Separator) && ListEx[i + 1].Name == "-")
                    {
                        Temp.Add(ListEx[i]);
                        Temp.Add(new ElementaryFuncElement("0"));
                    }
                    else
                    if (
                        ((ListEx[i].Type == Types.Digit || ListEx[i].Type == Types.Param) && (ListEx[i + 1].Type == Types.Digit || ListEx[i + 1].Type == Types.Param || ListEx[i + 1].Type == Types.OpParenthesis || ListEx[i + 1].Type == Types.Func))
                        || (ListEx[i].Type == Types.CloseParenthesis && ((ListEx[i + 1].Type == Types.Digit) || ListEx[i + 1].Type == Types.Param || ListEx[i + 1].Type == Types.Func || ListEx[i + 1].Type == Types.OpParenthesis))
                        )
                    {
                        Temp.Add(ListEx[i]);
                        Temp.Add(new ElementaryFuncElement("*"));
                    }
                    else
                    if (ListEx[i].Type == Types.Operation && ListEx[i + 1].Type == Types.Operation)
                    {
                        throw new FormatException();
                    }
                    else
                    if (ListEx[i].Type == Types.OpParenthesis && ListEx[i + 1].Type == Types.CloseParenthesis)
                    {
                        throw new FormatException();
                    }    
                    else
                    {
                        Temp.Add(ListEx[i]);
                    }
                    if (i == ListEx.Count - 2)
                        Temp.Add(ListEx[i + 1]);
                }
            }
            return Temp;
        }
        List<ElementaryFuncElement> GetReverseNotation(List<ElementaryFuncElement> Func)
        {
            var DecSeparatorFormat = new System.Globalization.NumberFormatInfo();
            DecSeparatorFormat.CurrencyDecimalSeparator = ".";
            List<ElementaryFuncElement> Notation = new List<ElementaryFuncElement>();
            Stack<ElementaryFuncElement> Stack = new Stack<ElementaryFuncElement>();
            ElementaryFuncElement LastFunc = null;
            foreach (var Expression in Func)
            {
                switch (Expression.Type)
                {
                    case Types.Digit:
                    case Types.Param:
                        Notation.Add(Expression);
                        break;
                    case Types.Func:
                        Stack.Push(Expression);
                        LastFunc = Expression;
                        break;
                    case Types.Separator:
                        LastFunc.OperandCount++;
                        while (Stack.Peek().Type != Types.OpParenthesis)
                        {
                            Notation.Add(Stack.Pop());
                            if (Stack.Count == 0)
                                break;
                        }
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
                                    throw new FormatException();
                            }
                            Stack.Pop();
                            if (Stack.Count != 0 && Stack.Peek().Type == Types.Func)
                            {
                                Notation.Add(Stack.Pop());
                            }
                        }
                        break;
                }

            }
            while (Stack.Count != 0)
            {
                var StackItem = Stack.Pop();
                if (StackItem.Type == Types.Operation || StackItem.Type == Types.Func)
                    Notation.Add(StackItem);
                else
                    throw new FormatException();
            }
            return Notation;
        }
        double CalcFuncValue(double Var)
        {
            if (_paramsInitFlag)
            {
                Stack<double> Stack = new Stack<double>();
                foreach (var Ex in _reverseNotation)
                {
                    switch (Ex.Type)
                    {
                        case Types.Digit:
                        case Types.Param:
                            Stack.Push(Ex.Value);
                            break;
                        case Types.Var:
                            Ex.Value = Var;
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
            }
            throw new NullReferenceException();
        }
        public double Call(double Value)
        {
            if (_values.ContainsKey(Value))
            {
                return _values[Value];
            }
            else
            {
                var y=CalcFuncValue(Value);
                _values.Add(Value, y);
                return y;
            }
        }
        public void ParamsInit(IEnumerable<Parameter> Parameters)
        {
            foreach (var ParamValue in Parameters)
            {
                var Params = from Element in _reverseNotation where (Element.Type == Types.Var||Element.Type == Types.Param) && Element.Name != Var.ToString() && Element.Name == ParamValue.Name select Element;
                foreach (var p in Params)
                {
                        p.Type = Types.Param;
                        p.Value = ParamValue.Value;
                }
            }
            var NonInitParamsCount = (from Element in _reverseNotation where Element.Type == Types.Var && Element.Name != Var.ToString() select Element).Count<ElementaryFuncElement>();
            if (NonInitParamsCount != 0)
                throw new ArgumentException();
            _values.Clear();
            _paramsInitFlag = true;
        }
        public override string ToString()
        {
            StringBuilder strb = new StringBuilder();
            foreach (var s in _funcBody)
            {
                strb.Append(s.Name);
            }
            return strb.ToString();
        }
        public string GetReverseNotation()
        {
            StringBuilder strb = new StringBuilder();
            foreach (var s in _reverseNotation)
            {
                strb.Append(s.Name);
            }
            return strb.ToString();
        }
        public string GetParams()
        {
            StringBuilder strb = new StringBuilder();
            var Params = (from Item in _reverseNotation where (Item.Type == Types.Param) select Item.Name).Distinct<string>();
            foreach (var s in Params)
            {
                strb.Append(","+s);
            }
            if(strb.Length!=0)
            return strb.ToString().Remove(0,1);
            return "-";
        }
        public IEnumerable<string> GetParamsCollection()
        {
            return (from Item in _reverseNotation where (Item.Type == Types.Param) select Item.Name).Distinct<string>();
        }
        public IEnumerable<IEnumerable<DoublePoint>> GetPointsForGraph(double LeftEndPoint, double RightEndPoint,double Epsilon,double dVariable)
        {
            if (_paramsInitFlag)
            {
                List<List<DoublePoint>> Res = new List<List<DoublePoint>>();
                List<DoublePoint> ValuesInContinuousPart = new List<DoublePoint>();
                double LastValue = CalcFuncValue(LeftEndPoint);
                for (double i = LeftEndPoint; i <= RightEndPoint; i += dVariable)
                {
                    double Value = CalcFuncValue(i);
                    if (Math.Abs(LastValue - Value) > Epsilon)
                    {
                        Res.Add(ValuesInContinuousPart);
                        ValuesInContinuousPart=new List<DoublePoint>();
                    }
                    ValuesInContinuousPart.Add(new DoublePoint(){X=i,Y=Value});
                    LastValue = Value;
                }
                Res.Add(ValuesInContinuousPart);
                return Res;
            }
            else 
                throw new NullReferenceException();
            
        
        }
        public static string GetFunctionList()
        {
            StringBuilder strb = new StringBuilder();
            strb.AppendLine("Available operations:");
            int LineBuildHelper = 1;
            foreach (var Operation in FuncTable)
            {
                if (LineBuildHelper % 5 != 0)
                {
                    if (Operation.Length == 1)
                    {
                        strb.Append("a" + Operation + "b; ");
                    }
                    else
                        if (Operation == "pow")
                        {
                            strb.Append(Operation + "(x,power); ");
                        }
                        else
                            if (Operation == "log")
                            {
                                strb.Append(Operation + "(x); ");
                                strb.Append(Operation + "(x,base); ");
                            }
                            else
                                strb.Append(Operation + "(x); ");
                }
                else
                {
                    if (Operation.Length == 1)
                    {
                        strb.AppendLine("a" + Operation + "b; ");
                    }
                    else
                        if (Operation == "pow")
                        {
                            strb.AppendLine(Operation + "(x,power); ");
                        }
                        else
                            if (Operation == "log")
                            {
                                strb.AppendLine(Operation + "(x); ");
                                strb.Append(Operation + "(x,base); ");
                            }
                            else
                                strb.AppendLine(Operation + "(x); ");
                }
                LineBuildHelper++;
            }
            strb.AppendLine("|a|");
            return strb.ToString();
        }
        #endregion

    }
}
