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
            btn4 = new Button();
            btn5 = new Button();
            btn6 = new Button();
            btn1 = new Button();
            btn2 = new Button();
            btn3 = new Button();
            btnAdd = new Button();
            btn0 = new Button();
            btnEqual = new Button();
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
            txtExpression.Font = new Font("Segoe UI", 12F);
            txtExpression.Location = new Point(20, 65);
            txtExpression.Size = new Size(360, 30);
            txtExpression.ReadOnly = true;
            txtExpression.TabStop = false;

            // txtResult
            txtResult.Font = new Font("Segoe UI", 12F);
            txtResult.Location = new Point(20, 100);
            txtResult.Size = new Size(360, 30);
            txtResult.ReadOnly = true;
            txtResult.TabStop = false;

            int bw = 80, bh = 45, gap = 10;
            int startX = 20, startY = 145;

            // Row 1: 7, 8, 9, +
            SetBtn(btn7,   "7", Color.WhiteSmoke, Color.RoyalBlue, startX,            startY, bw, bh);
            SetBtn(btn8,   "8", Color.WhiteSmoke, Color.RoyalBlue, startX+bw+gap,     startY, bw, bh);
            SetBtn(btn9,   "9", Color.WhiteSmoke, Color.RoyalBlue, startX+(bw+gap)*2, startY, bw, bh);
            SetBtn(btnAdd, "+", Color.WhiteSmoke, Color.OrangeRed, startX+(bw+gap)*3, startY, bw, bh);

            // Row 2: 4, 5, 6
            SetBtn(btn4, "4", Color.WhiteSmoke, Color.RoyalBlue, startX,            startY+(bh+gap),   bw, bh);
            SetBtn(btn5, "5", Color.WhiteSmoke, Color.RoyalBlue, startX+bw+gap,     startY+(bh+gap),   bw, bh);
            SetBtn(btn6, "6", Color.WhiteSmoke, Color.RoyalBlue, startX+(bw+gap)*2, startY+(bh+gap),   bw, bh);

            // Row 3: 1, 2, 3
            SetBtn(btn1, "1", Color.WhiteSmoke, Color.RoyalBlue, startX,            startY+(bh+gap)*2, bw, bh);
            SetBtn(btn2, "2", Color.WhiteSmoke, Color.RoyalBlue, startX+bw+gap,     startY+(bh+gap)*2, bw, bh);
            SetBtn(btn3, "3", Color.WhiteSmoke, Color.RoyalBlue, startX+(bw+gap)*2, startY+(bh+gap)*2, bw, bh);

            // Row 4: 0, =
            SetBtn(btn0,     "0", Color.WhiteSmoke, Color.RoyalBlue, startX,            startY+(bh+gap)*3, bw, bh);
            SetBtn(btnEqual, "=", Color.WhiteSmoke, Color.Black,     startX+(bw+gap)*3, startY+(bh+gap)*3, bw, bh);

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
            btnAdd.Click += BtnAdd_Click;
            btnEqual.Click += BtnEqual_Click;

            // Form
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 360);
            Text = "Calculator v1.0";
            BackColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            Controls.Add(lblTitle);
            Controls.Add(txtExpression);
            Controls.Add(txtResult);
            Controls.Add(btn7); Controls.Add(btn8); Controls.Add(btn9); Controls.Add(btnAdd);
            Controls.Add(btn4); Controls.Add(btn5); Controls.Add(btn6);
            Controls.Add(btn1); Controls.Add(btn2); Controls.Add(btn3);
            Controls.Add(btn0); Controls.Add(btnEqual);

            ResumeLayout(false);
        }

        private void SetBtn(Button btn, string text, Color back, Color fore, int x, int y, int w, int h)
        {
            btn.Text = text;
            btn.BackColor = back;
            btn.ForeColor = fore;
            btn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
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
        private Button btn7, btn8, btn9, btnAdd;
        private Button btn4, btn5, btn6;
        private Button btn1, btn2, btn3;
        private Button btn0, btnEqual;
    }
}
