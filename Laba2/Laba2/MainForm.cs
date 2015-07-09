#region Using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL;
using System.Threading.Tasks;
using System.Globalization;
using System.Diagnostics;
using System.Collections.Concurrent;
#endregion
/*
 * 2.	Посчитать интеграл методом прямоугольников (разбить интервал на мелкие отрезки интегрирования и посчитать площадь каждого прямоугольника, 
 *         а затем сложить. Запускать вычисление интеграла на каждом отрезке в отдельном потоке). Вывести результат.
 *         
 *          1)Класса Parallel	
 *          integral (x+1)^(-1/3) from 0 to 1.2 = 1.03731
 * */
namespace Laba2
{
    public partial class MainForm : Form
    {
        IntegrateOptions IntegrateOptions;
        Function Function;
        Area Area;
        bool FuncDrawFlag ;
        double CoordRange;
        double ScrollRate;
        double Epsilon;
        double dVariable;
        bool Loaded;
        #region ...
        public MainForm()
        {
            InitializeComponent();
            VariableTB.TextChanged += new EventHandler(SetVariable);
            MainGl.MouseWheel += new MouseEventHandler(MainGl_MouseWheel);
            Area = new Area();
            CoordRange = 2;
            ScrollRate = 0.1;
            dVariable = 0.01;
            Epsilon = 1;
            FuncDrawFlag = false;
            LabelChange();
            IntegrateOptions = new IntegrateOptions() { LeftValue = 0, RightValue = 1, N = 100 };
            aTB.Text = IntegrateOptions.LeftValue.ToString();
            bTB.Text = IntegrateOptions.RightValue.ToString();
            NNumeric.Value = IntegrateOptions.N;
        }
        void MainGl_Load(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, this.MainGl.Width, this.MainGl.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-CoordRange, CoordRange, -CoordRange, CoordRange, -1, 1);
            GL.ClearColor(Color.Black);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            GL.Disable(EnableCap.DepthTest);
            Loaded = true;
            Draw();
        }
        void MainGl_Paint(object sender, PaintEventArgs e)
        {
            Draw();
            MainGl.SwapBuffers();
        }
        void FunctionInit(object sender, EventArgs e)
        {
            try
            {
                Function = new Function(FunctionInputTB.Text, Convert.ToChar(VariableTB.Text));
                ShowFuncInfoLables();
                FunctionInputBorder.BackColor = Color.LimeGreen;
                if (Function.ParamsCount == 0)
                {
                    FuncDrawFlag = true;
                    Draw();
                    ParamsPanel.Controls.Clear();
                    IntegralOptionsPanel.Visible = true;
                    ParamsOptionsL.Visible = false;
                    SaveParamsBtn.Visible = false;
                    CalcIntegral();
                }
                else
                {
                    CreateParamsPanel();
                    FuncDrawFlag = false;
                    Draw();
                }
                IncorrectInput.SetError(FunctionInputBorder, "");
            }
            catch
            {
                FunctionInputBorder.BackColor = Color.Red;
                IntegralOptionsPanel.Visible = false;
                ParamsOptionsL.Visible = false;
                SaveParamsBtn.Visible = false;
                IncorrectInput.SetError(FunctionInputBorder, Function.GetFunctionList());
                FuncDrawFlag = false;
                Draw();
            }
        }
        void SetVariable(object sender, EventArgs e)
        {
            try
            {
                Function.Var = Convert.ToChar(VariableTB.Text);
                VariableBorder.BackColor = Color.LimeGreen;
                CreateParamsPanel();
                ShowFuncInfoLables();
                IntegralOptionsPanel.Visible = false;

            }
            catch (NullReferenceException)
            {
                VariableBorder.BackColor = Color.LimeGreen;
            }
            catch
            {
                VariableBorder.BackColor = Color.Red;
            }
            finally
            {
                FuncDrawFlag = false;
                Draw();
            }
        }
        void SaveParamsBtn_Click(object sender, EventArgs e)
        {
            try
            {
                List<Parameter> Params = new List<Parameter>();
                foreach (var Control in ParamsPanel.Controls)
                {
                    var ControlTB = Control as TextBox;
                    if (ControlTB != null)
                    {
                        Params.Add(new Parameter() { Name = ControlTB.Name, Value = Convert.ToDouble(ControlTB.Text.Replace('.', ',')) });
                    }
                }
                Function.ParamsInit(Params);
                IntegralOptionsPanel.Visible = true;
                FuncDrawFlag = true;
                Draw();
                IncorrectInput.SetError(SaveParamsBtn, "");
            }
            catch
            {
                IncorrectInput.SetError(SaveParamsBtn, "Incorrect input, try again");
                FuncDrawFlag = false;
                IntegralOptionsPanel.Visible = false;
                Draw();
            }


        }
        void MainGl_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {

                CoordRange += ScrollRate;
                GL.MatrixMode(MatrixMode.Projection);
                GL.LoadIdentity();
                GL.Ortho(-CoordRange, CoordRange, -CoordRange, CoordRange, -1, 1);
                LabelChange();
            }
            else
                if (e.Delta < 0)
                {
                    if (CoordRange > 1)
                    {
                        CoordRange -= ScrollRate;
                    }

                    GL.MatrixMode(MatrixMode.Projection);
                    GL.LoadIdentity();
                    GL.Ortho(-CoordRange, CoordRange, -CoordRange, CoordRange, -1, 1);
                    LabelChange();
                }
            Draw();
        }
        void DrawCoordinateSystem()
        {
            GL.Color3(Color.FromArgb(33, 33, 33, 33));
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex2(CoordRange, 0);
            GL.Vertex2(-CoordRange, 0);
            GL.Vertex2(0, CoordRange);
            GL.Vertex2(0, -CoordRange);
            GL.End();
        }
        void DrawDots()
        {
            GL.Color3(Color.Red);
            GL.Begin(PrimitiveType.Points);
            for (int i = Convert.ToInt32(-CoordRange); i < CoordRange; i++)
            {
                GL.Vertex2(0, i);
                GL.Vertex2(i, 0);

            }
            GL.End();
        }
        void DrawFunc()
        {
            DrawArea();
            GL.Color3(Color.LimeGreen);
            foreach (var Part in Function.GetPointsForGraph(-CoordRange, CoordRange, Epsilon, dVariable))
            {
                GL.Begin(PrimitiveType.LineStrip);
                foreach (var Point in Part)
                {
                    GL.Vertex2(Point.X, Point.Y);
                }
                GL.End();
            }
           

        }
        void DrawArea()
        {
            GL.Color3(Color.Red);
            GL.Begin(PrimitiveType.Quads);
            for (int i = 0; i < IntegrateOptions.N; i++)
            {
                var x = IntegrateOptions.LeftValue + IntegrateOptions.dVariable / 2 + i * IntegrateOptions.dVariable;
                var y = Function.Call(x);
                GL.Vertex2(x-IntegrateOptions.dVariable/2, 0);
                GL.Vertex2(x - IntegrateOptions.dVariable / 2, y);
                GL.Vertex2(x+IntegrateOptions.dVariable/2, y);
                GL.Vertex2(x + IntegrateOptions.dVariable/2, 0);

            }
            GL.End();
        }
        void Draw()
        {
            if (Loaded)
            {
                GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
                DrawCoordinateSystem();
                DrawDots();
                if (FuncDrawFlag)
                {
                    DrawFunc();
                }
                MainGl.SwapBuffers();
            }
        }
        void LabelChange()
        {
            var CoordRangeText = CoordRange.ToString(".#");
            OxPositiveL.Text = CoordRangeText;
            OyPositiveL.Text = CoordRangeText;
            OxNegativeL.Text ="-"+ CoordRangeText;
            OyNegativeL.Text ="-"+ CoordRangeText;
        }
        void ShowFuncInfoLables()
        {
            InputTextL.Text = Function.ToString();
            NotationTextL.Text = Function.GetReverseNotation();
            Function.Var = Convert.ToChar(VariableTB.Text);
            ParamsListL.Text = Function.GetParams();
            InfoLabelsPanel.Visible = true;
        }
        void CreateParamsPanel()
        {
            ParamsPanel.Visible = true;
            ParamsPanel.Controls.Clear();
            ParamsOptionsL.Visible = true;
            SaveParamsBtn.Visible = true;
            int Left = 10;
            int Top = 15;
            int DownSpace = 30;
            int RightSpace = 50;
            int RowCount = 0;
            int LinesCount = 0;
            Label[] Labels = new Label[Function.ParamsCount];
            TextBox[] Tbs = new TextBox[Function.ParamsCount];
            var ParamCollection = Function.GetParamsCollection();
            for (int i = 0; i < Function.ParamsCount; i++)
            {
                Labels[i] = new Label();
                Labels[i].Text = ParamCollection.ElementAt<string>(i) + "=";
                Labels[i].Left = Left + RightSpace * RowCount;
                Labels[i].Top = Top + LinesCount * DownSpace;
                Labels[i].Width = 25;
                Labels[i].Parent = ParamsPanel;
                Tbs[i] = new TextBox();
                Tbs[i].KeyPress += new KeyPressEventHandler((sender, e) => { char c = e.KeyChar; if (!char.IsDigit(c) && c != Convert.ToChar(8) && c != ',' && c != '.' && c != '-') e.Handled = true; });
                Tbs[i].Left = Labels[i].Left + Labels[i].Width;
                Tbs[i].Top = Labels[i].Top;
                Tbs[i].Width = 20;
                Tbs[i].Height = 10;
                Tbs[i].Name = ParamCollection.ElementAt<string>(i);
                Tbs[i].Parent = ParamsPanel;
                Tbs[i].ForeColor = Color.LimeGreen;
                Tbs[i].BackColor = Color.Black;
                if (Tbs[i].Location.X + 40 > ParamsPanel.Width)
                {
                    RowCount = 0;
                    LinesCount++;
                }
                else
                {
                    RowCount++;
                }
            }
        }
        void aTB_TextChanged(object sender, EventArgs e)
        {
            var a = Convert.ToDouble(aTB.Text.Replace('.',','));
            if (a > IntegrateOptions.RightValue)
            {
                IncorrectInput.SetError(IntervalRightL, "Incorrect value!");
                IntervalPanel.BackColor = Color.Red;
            }
            else
            {
                IntervalPanel.BackColor = Color.LimeGreen;
                IncorrectInput.SetError(IntervalRightL, "");
                IntegrateOptions.LeftValue = a;
            }
            Draw();
            CalcIntegral();
        }
        void bTB_TextChanged(object sender, EventArgs e)
        {
            var b = Convert.ToDouble(bTB.Text.Replace('.', ','));
            if (b < IntegrateOptions.LeftValue)
            {
                IncorrectInput.SetError(IntervalRightL, "Incorrect value!");
                IntervalPanel.BackColor = Color.Red;
            }
            else
            {
                IntervalPanel.BackColor = Color.LimeGreen;
                IncorrectInput.SetError(IntervalRightL, "");
                IntegrateOptions.RightValue = b;
            }
            Draw();
            CalcIntegral();
        }
        void aTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '-' && e.KeyChar != '.' && e.KeyChar != ',' && !char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }
        void bTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '-' && e.KeyChar != '.' && e.KeyChar != ',' && !char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }
        void CalcBtn_Click(object sender, EventArgs e)
        {
            CalcIntegral();
        }
        void NNumeric_ValueChanged(object sender, EventArgs e)
        {
            IntegrateOptions.N = Convert.ToInt32(NNumeric.Value);
            Draw();
            CalcIntegral();
        }
        void FunctionInputTB_TextChanged(object sender, EventArgs e)
        {
            IntegralOptionsPanel.Visible = false;
            ParamsPanel.Visible = false;
            ParamsOptionsL.Visible = false;
            SaveParamsBtn.Visible = false;
            FuncDrawFlag = false;
            Draw();
        }
        #endregion
        #region Задание
        void CalcIntegral()
        {
            Area.Value = 0;
            if (Function != null)
            {
                #region...
                //var Parts = Partitioner.Create(0, IntegrateOptions.N);
                //Stopwatch stopWatch = new Stopwatch();
                //stopWatch.Start();
                //Parallel.ForEach(Parts, (Range) =>
                //    {
                //        lock (Area)
                //        {
                //            for (int i = Range.Item1; i < Range.Item2; i++)
                //            {

                //                Area.Add(Function.Call(IntegrateOptions.LeftValue + IntegrateOptions.dVariable / 2 + i * IntegrateOptions.dVariable) * IntegrateOptions.dVariable);

                //            }

                //        }
                //    });
                //stopWatch.Stop();
                //MessageBox.Show(stopWatch.ElapsedMilliseconds.ToString());
                #endregion
                Parallel.For(0, IntegrateOptions.N, (i) =>
                {
                    lock (Area)
                    {
                        Area.Add(Function.Call(IntegrateOptions.LeftValue + IntegrateOptions.dVariable / 2 + i * IntegrateOptions.dVariable) * IntegrateOptions.dVariable);
                    }
                });
                ResultTB.Text = Area.ToString("F6");
            }
        }
        #endregion
    }
}
