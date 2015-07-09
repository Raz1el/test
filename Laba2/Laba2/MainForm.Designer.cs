namespace Laba2
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainGl = new OpenTK.GLControl();
            this.OxPositiveL = new System.Windows.Forms.Label();
            this.OxNegativeL = new System.Windows.Forms.Label();
            this.OyNegativeL = new System.Windows.Forms.Label();
            this.OyPositiveL = new System.Windows.Forms.Label();
            this.FunctionInputTB = new System.Windows.Forms.TextBox();
            this.OkBtn = new System.Windows.Forms.Button();
            this.FuncInLabel = new System.Windows.Forms.Label();
            this.InputL = new System.Windows.Forms.Label();
            this.InputTextL = new System.Windows.Forms.Label();
            this.NotationL = new System.Windows.Forms.Label();
            this.NotationTextL = new System.Windows.Forms.Label();
            this.ParamsL = new System.Windows.Forms.Label();
            this.ParamsListL = new System.Windows.Forms.Label();
            this.VarL = new System.Windows.Forms.Label();
            this.VariableTB = new System.Windows.Forms.TextBox();
            this.FunctionInputBorder = new System.Windows.Forms.Panel();
            this.VariableBorder = new System.Windows.Forms.Panel();
            this.InfoLabelsPanel = new System.Windows.Forms.Panel();
            this.ParamsPanel = new System.Windows.Forms.Panel();
            this.IntegralOptionsPanel = new System.Windows.Forms.Panel();
            this.ResultL = new System.Windows.Forms.Label();
            this.ResultTB = new System.Windows.Forms.TextBox();
            this.CalcBtn = new System.Windows.Forms.Button();
            this.NNumeric = new System.Windows.Forms.NumericUpDown();
            this.IntervalPanel = new System.Windows.Forms.Panel();
            this.aTB = new System.Windows.Forms.TextBox();
            this.bTB = new System.Windows.Forms.TextBox();
            this.NL = new System.Windows.Forms.Label();
            this.IntervalRightL = new System.Windows.Forms.Label();
            this.IntervalLeftL = new System.Windows.Forms.Label();
            this.IntervalL = new System.Windows.Forms.Label();
            this.IntegralParamsL = new System.Windows.Forms.Label();
            this.ParamsOptionsL = new System.Windows.Forms.Label();
            this.SaveParamsBtn = new System.Windows.Forms.Button();
            this.IncorrectInput = new System.Windows.Forms.ErrorProvider(this.components);
            this.FunctionInputBorder.SuspendLayout();
            this.VariableBorder.SuspendLayout();
            this.InfoLabelsPanel.SuspendLayout();
            this.IntegralOptionsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NNumeric)).BeginInit();
            this.IntervalPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IncorrectInput)).BeginInit();
            this.SuspendLayout();
            // 
            // MainGl
            // 
            this.MainGl.BackColor = System.Drawing.Color.Black;
            this.MainGl.Location = new System.Drawing.Point(-2, -1);
            this.MainGl.Name = "MainGl";
            this.MainGl.Size = new System.Drawing.Size(671, 514);
            this.MainGl.TabIndex = 0;
            this.MainGl.VSync = false;
            this.MainGl.Load += new System.EventHandler(this.MainGl_Load);
            this.MainGl.Paint += new System.Windows.Forms.PaintEventHandler(this.MainGl_Paint);
            // 
            // OxPositiveL
            // 
            this.OxPositiveL.AutoSize = true;
            this.OxPositiveL.BackColor = System.Drawing.Color.Black;
            this.OxPositiveL.Location = new System.Drawing.Point(623, 265);
            this.OxPositiveL.Name = "OxPositiveL";
            this.OxPositiveL.Size = new System.Drawing.Size(22, 13);
            this.OxPositiveL.TabIndex = 1;
            this.OxPositiveL.Text = "OX";
            // 
            // OxNegativeL
            // 
            this.OxNegativeL.AutoSize = true;
            this.OxNegativeL.BackColor = System.Drawing.Color.Black;
            this.OxNegativeL.Location = new System.Drawing.Point(23, 265);
            this.OxNegativeL.Name = "OxNegativeL";
            this.OxNegativeL.Size = new System.Drawing.Size(25, 13);
            this.OxNegativeL.TabIndex = 2;
            this.OxNegativeL.Text = "-OX";
            // 
            // OyNegativeL
            // 
            this.OyNegativeL.AutoSize = true;
            this.OyNegativeL.BackColor = System.Drawing.Color.Black;
            this.OyNegativeL.Location = new System.Drawing.Point(346, 490);
            this.OyNegativeL.Name = "OyNegativeL";
            this.OyNegativeL.Size = new System.Drawing.Size(25, 13);
            this.OyNegativeL.TabIndex = 3;
            this.OyNegativeL.Text = "-OY";
            // 
            // OyPositiveL
            // 
            this.OyPositiveL.AutoSize = true;
            this.OyPositiveL.BackColor = System.Drawing.Color.Black;
            this.OyPositiveL.Location = new System.Drawing.Point(346, 9);
            this.OyPositiveL.Name = "OyPositiveL";
            this.OyPositiveL.Size = new System.Drawing.Size(22, 13);
            this.OyPositiveL.TabIndex = 4;
            this.OyPositiveL.Text = "OY";
            // 
            // FunctionInputTB
            // 
            this.FunctionInputTB.BackColor = System.Drawing.SystemColors.MenuText;
            this.FunctionInputTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FunctionInputTB.ForeColor = System.Drawing.Color.Lime;
            this.FunctionInputTB.Location = new System.Drawing.Point(1, 1);
            this.FunctionInputTB.Name = "FunctionInputTB";
            this.FunctionInputTB.Size = new System.Drawing.Size(267, 20);
            this.FunctionInputTB.TabIndex = 5;
            this.FunctionInputTB.TextChanged += new System.EventHandler(this.FunctionInputTB_TextChanged);
            // 
            // OkBtn
            // 
            this.OkBtn.BackColor = System.Drawing.Color.Black;
            this.OkBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OkBtn.Location = new System.Drawing.Point(754, 81);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(169, 23);
            this.OkBtn.TabIndex = 6;
            this.OkBtn.Text = "OK";
            this.OkBtn.UseVisualStyleBackColor = false;
            this.OkBtn.Click += new System.EventHandler(this.FunctionInit);
            // 
            // FuncInLabel
            // 
            this.FuncInLabel.AutoSize = true;
            this.FuncInLabel.Location = new System.Drawing.Point(692, 40);
            this.FuncInLabel.Name = "FuncInLabel";
            this.FuncInLabel.Size = new System.Drawing.Size(51, 13);
            this.FuncInLabel.TabIndex = 7;
            this.FuncInLabel.Text = "Function:";
            // 
            // InputL
            // 
            this.InputL.AutoSize = true;
            this.InputL.Location = new System.Drawing.Point(10, 9);
            this.InputL.Name = "InputL";
            this.InputL.Size = new System.Drawing.Size(34, 13);
            this.InputL.TabIndex = 8;
            this.InputL.Text = "Input:";
            // 
            // InputTextL
            // 
            this.InputTextL.AutoSize = true;
            this.InputTextL.Location = new System.Drawing.Point(50, 9);
            this.InputTextL.Name = "InputTextL";
            this.InputTextL.Size = new System.Drawing.Size(71, 13);
            this.InputTextL.TabIndex = 9;
            this.InputTextL.Text = "FunctionHere";
            // 
            // NotationL
            // 
            this.NotationL.AutoSize = true;
            this.NotationL.Location = new System.Drawing.Point(10, 31);
            this.NotationL.Name = "NotationL";
            this.NotationL.Size = new System.Drawing.Size(91, 13);
            this.NotationL.TabIndex = 10;
            this.NotationL.Text = "Reverse notation:";
            // 
            // NotationTextL
            // 
            this.NotationTextL.AutoSize = true;
            this.NotationTextL.Location = new System.Drawing.Point(107, 31);
            this.NotationTextL.Name = "NotationTextL";
            this.NotationTextL.Size = new System.Drawing.Size(70, 13);
            this.NotationTextL.TabIndex = 11;
            this.NotationTextL.Text = "NotationHere";
            // 
            // ParamsL
            // 
            this.ParamsL.AutoSize = true;
            this.ParamsL.Location = new System.Drawing.Point(10, 53);
            this.ParamsL.Name = "ParamsL";
            this.ParamsL.Size = new System.Drawing.Size(45, 13);
            this.ParamsL.TabIndex = 14;
            this.ParamsL.Text = "Params:";
            // 
            // ParamsListL
            // 
            this.ParamsListL.AutoSize = true;
            this.ParamsListL.Location = new System.Drawing.Point(76, 53);
            this.ParamsListL.Name = "ParamsListL";
            this.ParamsListL.Size = new System.Drawing.Size(65, 13);
            this.ParamsListL.TabIndex = 15;
            this.ParamsListL.Text = "ParamsHere";
            // 
            // VarL
            // 
            this.VarL.AutoSize = true;
            this.VarL.Location = new System.Drawing.Point(692, 18);
            this.VarL.Name = "VarL";
            this.VarL.Size = new System.Drawing.Size(48, 13);
            this.VarL.TabIndex = 16;
            this.VarL.Text = "Variable:";
            // 
            // VariableTB
            // 
            this.VariableTB.BackColor = System.Drawing.SystemColors.MenuText;
            this.VariableTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.VariableTB.ForeColor = System.Drawing.Color.Lime;
            this.VariableTB.Location = new System.Drawing.Point(1, 1);
            this.VariableTB.Name = "VariableTB";
            this.VariableTB.Size = new System.Drawing.Size(19, 20);
            this.VariableTB.TabIndex = 17;
            this.VariableTB.Text = "x";
            this.VariableTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FunctionInputBorder
            // 
            this.FunctionInputBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.FunctionInputBorder.Controls.Add(this.FunctionInputTB);
            this.FunctionInputBorder.Location = new System.Drawing.Point(695, 54);
            this.FunctionInputBorder.Margin = new System.Windows.Forms.Padding(1);
            this.FunctionInputBorder.Name = "FunctionInputBorder";
            this.FunctionInputBorder.Size = new System.Drawing.Size(269, 22);
            this.FunctionInputBorder.TabIndex = 18;
            // 
            // VariableBorder
            // 
            this.VariableBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.VariableBorder.Controls.Add(this.VariableTB);
            this.VariableBorder.Location = new System.Drawing.Point(741, 12);
            this.VariableBorder.Name = "VariableBorder";
            this.VariableBorder.Size = new System.Drawing.Size(21, 22);
            this.VariableBorder.TabIndex = 19;
            // 
            // InfoLabelsPanel
            // 
            this.InfoLabelsPanel.Controls.Add(this.InputL);
            this.InfoLabelsPanel.Controls.Add(this.NotationL);
            this.InfoLabelsPanel.Controls.Add(this.ParamsL);
            this.InfoLabelsPanel.Controls.Add(this.ParamsListL);
            this.InfoLabelsPanel.Controls.Add(this.InputTextL);
            this.InfoLabelsPanel.Controls.Add(this.NotationTextL);
            this.InfoLabelsPanel.Location = new System.Drawing.Point(675, 110);
            this.InfoLabelsPanel.Name = "InfoLabelsPanel";
            this.InfoLabelsPanel.Size = new System.Drawing.Size(305, 73);
            this.InfoLabelsPanel.TabIndex = 20;
            this.InfoLabelsPanel.Visible = false;
            // 
            // ParamsPanel
            // 
            this.ParamsPanel.Location = new System.Drawing.Point(678, 382);
            this.ParamsPanel.Name = "ParamsPanel";
            this.ParamsPanel.Size = new System.Drawing.Size(305, 121);
            this.ParamsPanel.TabIndex = 21;
            // 
            // IntegralOptionsPanel
            // 
            this.IntegralOptionsPanel.Controls.Add(this.ResultL);
            this.IntegralOptionsPanel.Controls.Add(this.ResultTB);
            this.IntegralOptionsPanel.Controls.Add(this.CalcBtn);
            this.IntegralOptionsPanel.Controls.Add(this.NNumeric);
            this.IntegralOptionsPanel.Controls.Add(this.IntervalPanel);
            this.IntegralOptionsPanel.Controls.Add(this.NL);
            this.IntegralOptionsPanel.Controls.Add(this.IntervalRightL);
            this.IntegralOptionsPanel.Controls.Add(this.IntervalLeftL);
            this.IntegralOptionsPanel.Controls.Add(this.IntervalL);
            this.IntegralOptionsPanel.Controls.Add(this.IntegralParamsL);
            this.IntegralOptionsPanel.Location = new System.Drawing.Point(675, 189);
            this.IntegralOptionsPanel.Name = "IntegralOptionsPanel";
            this.IntegralOptionsPanel.Size = new System.Drawing.Size(305, 156);
            this.IntegralOptionsPanel.TabIndex = 22;
            this.IntegralOptionsPanel.Visible = false;
            // 
            // ResultL
            // 
            this.ResultL.AutoSize = true;
            this.ResultL.Location = new System.Drawing.Point(10, 115);
            this.ResultL.Name = "ResultL";
            this.ResultL.Size = new System.Drawing.Size(37, 13);
            this.ResultL.TabIndex = 0;
            this.ResultL.Text = "Result";
            // 
            // ResultTB
            // 
            this.ResultTB.BackColor = System.Drawing.Color.Black;
            this.ResultTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ResultTB.ForeColor = System.Drawing.Color.Lime;
            this.ResultTB.Location = new System.Drawing.Point(52, 113);
            this.ResultTB.Name = "ResultTB";
            this.ResultTB.ReadOnly = true;
            this.ResultTB.Size = new System.Drawing.Size(196, 20);
            this.ResultTB.TabIndex = 1;
            // 
            // CalcBtn
            // 
            this.CalcBtn.BackColor = System.Drawing.Color.Black;
            this.CalcBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CalcBtn.Location = new System.Drawing.Point(198, 27);
            this.CalcBtn.Name = "CalcBtn";
            this.CalcBtn.Size = new System.Drawing.Size(75, 53);
            this.CalcBtn.TabIndex = 9;
            this.CalcBtn.Text = "Calculate";
            this.CalcBtn.UseVisualStyleBackColor = false;
            this.CalcBtn.Click += new System.EventHandler(this.CalcBtn_Click);
            // 
            // NNumeric
            // 
            this.NNumeric.BackColor = System.Drawing.Color.Black;
            this.NNumeric.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NNumeric.ForeColor = System.Drawing.Color.Lime;
            this.NNumeric.Location = new System.Drawing.Point(66, 65);
            this.NNumeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NNumeric.Name = "NNumeric";
            this.NNumeric.Size = new System.Drawing.Size(55, 20);
            this.NNumeric.TabIndex = 8;
            this.NNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NNumeric.ValueChanged += new System.EventHandler(this.NNumeric_ValueChanged);
            // 
            // IntervalPanel
            // 
            this.IntervalPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.IntervalPanel.Controls.Add(this.aTB);
            this.IntervalPanel.Controls.Add(this.bTB);
            this.IntervalPanel.ForeColor = System.Drawing.Color.Black;
            this.IntervalPanel.Location = new System.Drawing.Point(68, 37);
            this.IntervalPanel.Name = "IntervalPanel";
            this.IntervalPanel.Size = new System.Drawing.Size(50, 22);
            this.IntervalPanel.TabIndex = 7;
            // 
            // aTB
            // 
            this.aTB.BackColor = System.Drawing.Color.Black;
            this.aTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.aTB.ForeColor = System.Drawing.Color.Lime;
            this.aTB.Location = new System.Drawing.Point(1, 1);
            this.aTB.Name = "aTB";
            this.aTB.Size = new System.Drawing.Size(23, 20);
            this.aTB.TabIndex = 5;
            this.aTB.TextChanged += new System.EventHandler(this.aTB_TextChanged);
            this.aTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.aTB_KeyPress);
            // 
            // bTB
            // 
            this.bTB.BackColor = System.Drawing.Color.Black;
            this.bTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bTB.ForeColor = System.Drawing.Color.Lime;
            this.bTB.Location = new System.Drawing.Point(25, 1);
            this.bTB.Name = "bTB";
            this.bTB.Size = new System.Drawing.Size(24, 20);
            this.bTB.TabIndex = 4;
            this.bTB.TextChanged += new System.EventHandler(this.bTB_TextChanged);
            this.bTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.bTB_KeyPress);
            // 
            // NL
            // 
            this.NL.AutoSize = true;
            this.NL.Location = new System.Drawing.Point(10, 67);
            this.NL.Name = "NL";
            this.NL.Size = new System.Drawing.Size(15, 13);
            this.NL.TabIndex = 6;
            this.NL.Text = "N";
            // 
            // IntervalRightL
            // 
            this.IntervalRightL.AutoSize = true;
            this.IntervalRightL.Location = new System.Drawing.Point(124, 42);
            this.IntervalRightL.Name = "IntervalRightL";
            this.IntervalRightL.Size = new System.Drawing.Size(10, 13);
            this.IntervalRightL.TabIndex = 3;
            this.IntervalRightL.Text = "]";
            // 
            // IntervalLeftL
            // 
            this.IntervalLeftL.AutoSize = true;
            this.IntervalLeftL.Location = new System.Drawing.Point(55, 42);
            this.IntervalLeftL.Name = "IntervalLeftL";
            this.IntervalLeftL.Size = new System.Drawing.Size(10, 13);
            this.IntervalLeftL.TabIndex = 2;
            this.IntervalLeftL.Text = "[";
            // 
            // IntervalL
            // 
            this.IntervalL.AutoSize = true;
            this.IntervalL.Location = new System.Drawing.Point(10, 42);
            this.IntervalL.Name = "IntervalL";
            this.IntervalL.Size = new System.Drawing.Size(42, 13);
            this.IntervalL.TabIndex = 1;
            this.IntervalL.Text = "Interval";
            // 
            // IntegralParamsL
            // 
            this.IntegralParamsL.AutoSize = true;
            this.IntegralParamsL.Location = new System.Drawing.Point(9, 13);
            this.IntegralParamsL.Name = "IntegralParamsL";
            this.IntegralParamsL.Size = new System.Drawing.Size(79, 13);
            this.IntegralParamsL.TabIndex = 0;
            this.IntegralParamsL.Text = "Integral params";
            // 
            // ParamsOptionsL
            // 
            this.ParamsOptionsL.AutoSize = true;
            this.ParamsOptionsL.Location = new System.Drawing.Point(675, 357);
            this.ParamsOptionsL.Name = "ParamsOptionsL";
            this.ParamsOptionsL.Size = new System.Drawing.Size(79, 13);
            this.ParamsOptionsL.TabIndex = 23;
            this.ParamsOptionsL.Text = "Params options";
            this.ParamsOptionsL.Visible = false;
            // 
            // SaveParamsBtn
            // 
            this.SaveParamsBtn.BackColor = System.Drawing.Color.Black;
            this.SaveParamsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveParamsBtn.Location = new System.Drawing.Point(754, 351);
            this.SaveParamsBtn.Name = "SaveParamsBtn";
            this.SaveParamsBtn.Size = new System.Drawing.Size(80, 25);
            this.SaveParamsBtn.TabIndex = 0;
            this.SaveParamsBtn.Text = "Save params";
            this.SaveParamsBtn.UseVisualStyleBackColor = false;
            this.SaveParamsBtn.Visible = false;
            this.SaveParamsBtn.Click += new System.EventHandler(this.SaveParamsBtn_Click);
            // 
            // IncorrectInput
            // 
            this.IncorrectInput.BlinkRate = 500;
            this.IncorrectInput.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.IncorrectInput.ContainerControl = this;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(992, 509);
            this.Controls.Add(this.SaveParamsBtn);
            this.Controls.Add(this.ParamsOptionsL);
            this.Controls.Add(this.IntegralOptionsPanel);
            this.Controls.Add(this.ParamsPanel);
            this.Controls.Add(this.InfoLabelsPanel);
            this.Controls.Add(this.VariableBorder);
            this.Controls.Add(this.FunctionInputBorder);
            this.Controls.Add(this.VarL);
            this.Controls.Add(this.FuncInLabel);
            this.Controls.Add(this.OkBtn);
            this.Controls.Add(this.OyPositiveL);
            this.Controls.Add(this.OyNegativeL);
            this.Controls.Add(this.OxNegativeL);
            this.Controls.Add(this.OxPositiveL);
            this.Controls.Add(this.MainGl);
            this.ForeColor = System.Drawing.Color.Lime;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Numerical integration";
            this.FunctionInputBorder.ResumeLayout(false);
            this.FunctionInputBorder.PerformLayout();
            this.VariableBorder.ResumeLayout(false);
            this.VariableBorder.PerformLayout();
            this.InfoLabelsPanel.ResumeLayout(false);
            this.InfoLabelsPanel.PerformLayout();
            this.IntegralOptionsPanel.ResumeLayout(false);
            this.IntegralOptionsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NNumeric)).EndInit();
            this.IntervalPanel.ResumeLayout(false);
            this.IntervalPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IncorrectInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenTK.GLControl MainGl;
        private System.Windows.Forms.Label OxPositiveL;
        private System.Windows.Forms.Label OxNegativeL;
        private System.Windows.Forms.Label OyNegativeL;
        private System.Windows.Forms.Label OyPositiveL;
        private System.Windows.Forms.TextBox FunctionInputTB;
        private System.Windows.Forms.Button OkBtn;
        private System.Windows.Forms.Label FuncInLabel;
        private System.Windows.Forms.Label InputL;
        private System.Windows.Forms.Label InputTextL;
        private System.Windows.Forms.Label NotationL;
        private System.Windows.Forms.Label NotationTextL;
        private System.Windows.Forms.Label ParamsL;
        private System.Windows.Forms.Label ParamsListL;
        private System.Windows.Forms.Label VarL;
        private System.Windows.Forms.TextBox VariableTB;
        private System.Windows.Forms.Panel FunctionInputBorder;
        private System.Windows.Forms.Panel VariableBorder;
        private System.Windows.Forms.Panel InfoLabelsPanel;
        private System.Windows.Forms.Panel ParamsPanel;
        private System.Windows.Forms.Panel IntegralOptionsPanel;
        private System.Windows.Forms.Label ParamsOptionsL;
        private System.Windows.Forms.Button SaveParamsBtn;
        private System.Windows.Forms.Panel IntervalPanel;
        private System.Windows.Forms.TextBox aTB;
        private System.Windows.Forms.TextBox bTB;
        private System.Windows.Forms.Label NL;
        private System.Windows.Forms.Label IntervalRightL;
        private System.Windows.Forms.Label IntervalLeftL;
        private System.Windows.Forms.Label IntervalL;
        private System.Windows.Forms.Label IntegralParamsL;
        private System.Windows.Forms.NumericUpDown NNumeric;
        private System.Windows.Forms.TextBox ResultTB;
        private System.Windows.Forms.Label ResultL;
        private System.Windows.Forms.ErrorProvider IncorrectInput;
        private System.Windows.Forms.Button CalcBtn;


    }
}

