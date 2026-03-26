namespace SimpleCalculator
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTitle = new Label();
            txtExpression = new TextBox();
            txtResult = new TextBox();
            btn7 = new Button();
            btn8 = new Button();
            btn9 = new Button();
            btnDiv = new Button();
            btn4 = new Button();
            btn5 = new Button();
            btn6 = new Button();
            btnMul = new Button();
            btn1 = new Button();
            btn2 = new Button();
            btn3 = new Button();
            btnSub = new Button();
            btn0 = new Button();
            btnAdd = new Button();
            btnEqual = new Button();
            btnC = new Button();
            btnCE = new Button();
            SuspendLayout();

            // lblTitle
            lblTitle.AutoSize = false;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.RoyalBlue;
            lblTitle.Location = new Point(20, 10);
            lblTitle.Size = new Size(360, 50);
            lblTitle.Text = "Simple Calculator";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // txtExpression
            txtExpression.Font = new Font("Segoe UI", 16F);
            txtExpression.Location = new Point(20, 65);
            txtExpression.Size = new Size(360, 30);
            txtExpression.ReadOnly = true;
            txtExpression.TabStop = false;

            // txtResult
            txtResult.Font = new Font("Segoe UI", 16F);
            txtResult.Location = new Point(20, 100);
            txtResult.Size = new Size(360, 30);
            txtResult.ReadOnly = true;
            txtResult.TabStop = false;

            // Row 0: CE, C  (y=145)
            SetBtn(btnCE, "CE", Color.WhiteSmoke, Color.Black,     20,  145, 80, 45);
            SetBtn(btnC,  "C",  Color.WhiteSmoke, Color.Black,     110, 145, 80, 45);

            // Row 1: 7, 8, 9, ÷  (y=200)
            SetBtn(btn7,   "7", Color.WhiteSmoke, Color.RoyalBlue, 20,  200, 80, 45);
            SetBtn(btn8,   "8", Color.WhiteSmoke, Color.RoyalBlue, 110, 200, 80, 45);
            SetBtn(btn9,   "9", Color.WhiteSmoke, Color.RoyalBlue, 200, 200, 80, 45);
            SetBtn(btnDiv, "÷", Color.WhiteSmoke, Color.OrangeRed, 290, 200, 80, 45);

            // Row 2: 4, 5, 6, x  (y=255)
            SetBtn(btn4,   "4", Color.WhiteSmoke, Color.RoyalBlue, 20,  255, 80, 45);
            SetBtn(btn5,   "5", Color.WhiteSmoke, Color.RoyalBlue, 110, 255, 80, 45);
            SetBtn(btn6,   "6", Color.WhiteSmoke, Color.RoyalBlue, 200, 255, 80, 45);
            SetBtn(btnMul, "x", Color.WhiteSmoke, Color.OrangeRed, 290, 255, 80, 45);

            // Row 3: 1, 2, 3, -  (y=310)
            SetBtn(btn1,   "1", Color.WhiteSmoke, Color.RoyalBlue, 20,  310, 80, 45);
            SetBtn(btn2,   "2", Color.WhiteSmoke, Color.RoyalBlue, 110, 310, 80, 45);
            SetBtn(btn3,   "3", Color.WhiteSmoke, Color.RoyalBlue, 200, 310, 80, 45);
            SetBtn(btnSub, "-", Color.WhiteSmoke, Color.OrangeRed, 290, 310, 80, 45);

            // Row 4: 0, +, =  (y=365)
            SetBtn(btn0,     "0", Color.WhiteSmoke, Color.RoyalBlue, 20,  365, 80, 45);
            SetBtn(btnAdd,   "+", Color.WhiteSmoke, Color.OrangeRed, 200, 365, 80, 45);
            SetBtn(btnEqual, "=", Color.WhiteSmoke, Color.Black,     290, 365, 80, 45);

            // 이벤트 연결
            btn0.Click += BtnNumber_Click;
            btn1.Click += BtnNumber_Click;
            btn2.Click += BtnNumber_Click;
            btn3.Click += BtnNumber_Click;
            btn4.Click += BtnNumber_Click;
            btn5.Click += BtnNumber_Click;
            btn6.Click += BtnNumber_Click;
            btn7.Click += BtnNumber_Click;
            btn8.Click += BtnNumber_Click;
            btn9.Click += BtnNumber_Click;
            btnAdd.Click += BtnOperator_Click;
            btnSub.Click += BtnOperator_Click;
            btnMul.Click += BtnOperator_Click;
            btnDiv.Click += BtnOperator_Click;
            btnEqual.Click += BtnEqual_Click;
            btnC.Click += BtnC_Click;
            btnCE.Click += BtnCE_Click;

            // Form
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 425);
            Text = "Calculator v1.0";
            BackColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            Controls.Add(lblTitle);
            Controls.Add(txtExpression);
            Controls.Add(txtResult);
            Controls.Add(btn7); Controls.Add(btn8); Controls.Add(btn9); Controls.Add(btnDiv);
            Controls.Add(btn4); Controls.Add(btn5); Controls.Add(btn6); Controls.Add(btnMul);
            Controls.Add(btn1); Controls.Add(btn2); Controls.Add(btn3); Controls.Add(btnSub);
            Controls.Add(btn0); Controls.Add(btnAdd); Controls.Add(btnEqual);
            Controls.Add(btnCE); Controls.Add(btnC);

            ResumeLayout(false);
        }

        private void SetBtn(Button btn, string text, Color back, Color fore, int x, int y, int w, int h)
        {
            btn.Text = text;
            btn.BackColor = back;
            btn.ForeColor = fore;
            btn.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btn.Location = new Point(x, y);
            btn.Size = new Size(w, h);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = Color.LightGray;
            btn.Cursor = Cursors.Hand;
        }

        #endregion

        private Label lblTitle;
        private TextBox txtExpression;
        private TextBox txtResult;
        private Button btn7, btn8, btn9, btnDiv;
        private Button btn4, btn5, btn6, btnMul;
        private Button btn1, btn2, btn3, btnSub;
        private Button btn0, btnAdd, btnEqual;
        private Button btnC, btnCE;
    }
}
