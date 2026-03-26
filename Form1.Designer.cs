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
            btnCE = new Button();
            btnC = new Button();
            btnDel = new Button();
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
            SuspendLayout();

            // lblTitle
            lblTitle.AutoSize = false;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.DarkOrange;
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

            // btnCE
            btnCE.BackColor = Color.WhiteSmoke;
            btnCE.Cursor = Cursors.Hand;
            btnCE.FlatStyle = FlatStyle.Flat;
            btnCE.FlatAppearance.BorderColor = Color.LightGray;
            btnCE.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btnCE.ForeColor = Color.Black;
            btnCE.Location = new Point(20, 145);
            btnCE.Size = new Size(80, 45);
            btnCE.Text = "CE";
            btnCE.Click += BtnCE_Click;

            // btnC
            btnC.BackColor = Color.WhiteSmoke;
            btnC.Cursor = Cursors.Hand;
            btnC.FlatStyle = FlatStyle.Flat;
            btnC.FlatAppearance.BorderColor = Color.LightGray;
            btnC.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btnC.ForeColor = Color.Black;
            btnC.Location = new Point(110, 145);
            btnC.Size = new Size(80, 45);
            btnC.Text = "C";
            btnC.Click += BtnC_Click;

            // btnDel
            btnDel.BackColor = Color.WhiteSmoke;
            btnDel.Cursor = Cursors.Hand;
            btnDel.FlatStyle = FlatStyle.Flat;
            btnDel.FlatAppearance.BorderColor = Color.LightGray;
            btnDel.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btnDel.ForeColor = Color.Black;
            btnDel.Location = new Point(200, 145);
            btnDel.Size = new Size(80, 45);
            btnDel.Text = "del";
            btnDel.Click += BtnDel_Click;

            // btn7
            btn7.BackColor = Color.WhiteSmoke;
            btn7.Cursor = Cursors.Hand;
            btn7.FlatStyle = FlatStyle.Flat;
            btn7.FlatAppearance.BorderColor = Color.LightGray;
            btn7.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btn7.ForeColor = Color.RoyalBlue;
            btn7.Location = new Point(20, 200);
            btn7.Size = new Size(80, 45);
            btn7.Text = "7";
            btn7.Click += BtnNumber_Click;

            // btn8
            btn8.BackColor = Color.WhiteSmoke;
            btn8.Cursor = Cursors.Hand;
            btn8.FlatStyle = FlatStyle.Flat;
            btn8.FlatAppearance.BorderColor = Color.LightGray;
            btn8.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btn8.ForeColor = Color.RoyalBlue;
            btn8.Location = new Point(110, 200);
            btn8.Size = new Size(80, 45);
            btn8.Text = "8";
            btn8.Click += BtnNumber_Click;

            // btn9
            btn9.BackColor = Color.WhiteSmoke;
            btn9.Cursor = Cursors.Hand;
            btn9.FlatStyle = FlatStyle.Flat;
            btn9.FlatAppearance.BorderColor = Color.LightGray;
            btn9.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btn9.ForeColor = Color.RoyalBlue;
            btn9.Location = new Point(200, 200);
            btn9.Size = new Size(80, 45);
            btn9.Text = "9";
            btn9.Click += BtnNumber_Click;

            // btnDiv
            btnDiv.BackColor = Color.WhiteSmoke;
            btnDiv.Cursor = Cursors.Hand;
            btnDiv.FlatStyle = FlatStyle.Flat;
            btnDiv.FlatAppearance.BorderColor = Color.LightGray;
            btnDiv.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btnDiv.ForeColor = Color.OrangeRed;
            btnDiv.Location = new Point(290, 200);
            btnDiv.Size = new Size(80, 45);
            btnDiv.Text = "÷";
            btnDiv.Click += BtnOperator_Click;

            // btn4
            btn4.BackColor = Color.WhiteSmoke;
            btn4.Cursor = Cursors.Hand;
            btn4.FlatStyle = FlatStyle.Flat;
            btn4.FlatAppearance.BorderColor = Color.LightGray;
            btn4.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btn4.ForeColor = Color.RoyalBlue;
            btn4.Location = new Point(20, 255);
            btn4.Size = new Size(80, 45);
            btn4.Text = "4";
            btn4.Click += BtnNumber_Click;

            // btn5
            btn5.BackColor = Color.WhiteSmoke;
            btn5.Cursor = Cursors.Hand;
            btn5.FlatStyle = FlatStyle.Flat;
            btn5.FlatAppearance.BorderColor = Color.LightGray;
            btn5.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btn5.ForeColor = Color.RoyalBlue;
            btn5.Location = new Point(110, 255);
            btn5.Size = new Size(80, 45);
            btn5.Text = "5";
            btn5.Click += BtnNumber_Click;

            // btn6
            btn6.BackColor = Color.WhiteSmoke;
            btn6.Cursor = Cursors.Hand;
            btn6.FlatStyle = FlatStyle.Flat;
            btn6.FlatAppearance.BorderColor = Color.LightGray;
            btn6.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btn6.ForeColor = Color.RoyalBlue;
            btn6.Location = new Point(200, 255);
            btn6.Size = new Size(80, 45);
            btn6.Text = "6";
            btn6.Click += BtnNumber_Click;

            // btnMul
            btnMul.BackColor = Color.WhiteSmoke;
            btnMul.Cursor = Cursors.Hand;
            btnMul.FlatStyle = FlatStyle.Flat;
            btnMul.FlatAppearance.BorderColor = Color.LightGray;
            btnMul.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btnMul.ForeColor = Color.OrangeRed;
            btnMul.Location = new Point(290, 255);
            btnMul.Size = new Size(80, 45);
            btnMul.Text = "x";
            btnMul.Click += BtnOperator_Click;

            // btn1
            btn1.BackColor = Color.WhiteSmoke;
            btn1.Cursor = Cursors.Hand;
            btn1.FlatStyle = FlatStyle.Flat;
            btn1.FlatAppearance.BorderColor = Color.LightGray;
            btn1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btn1.ForeColor = Color.RoyalBlue;
            btn1.Location = new Point(20, 310);
            btn1.Size = new Size(80, 45);
            btn1.Text = "1";
            btn1.Click += BtnNumber_Click;

            // btn2
            btn2.BackColor = Color.WhiteSmoke;
            btn2.Cursor = Cursors.Hand;
            btn2.FlatStyle = FlatStyle.Flat;
            btn2.FlatAppearance.BorderColor = Color.LightGray;
            btn2.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btn2.ForeColor = Color.RoyalBlue;
            btn2.Location = new Point(110, 310);
            btn2.Size = new Size(80, 45);
            btn2.Text = "2";
            btn2.Click += BtnNumber_Click;

            // btn3
            btn3.BackColor = Color.WhiteSmoke;
            btn3.Cursor = Cursors.Hand;
            btn3.FlatStyle = FlatStyle.Flat;
            btn3.FlatAppearance.BorderColor = Color.LightGray;
            btn3.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btn3.ForeColor = Color.RoyalBlue;
            btn3.Location = new Point(200, 310);
            btn3.Size = new Size(80, 45);
            btn3.Text = "3";
            btn3.Click += BtnNumber_Click;

            // btnSub
            btnSub.BackColor = Color.WhiteSmoke;
            btnSub.Cursor = Cursors.Hand;
            btnSub.FlatStyle = FlatStyle.Flat;
            btnSub.FlatAppearance.BorderColor = Color.LightGray;
            btnSub.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btnSub.ForeColor = Color.OrangeRed;
            btnSub.Location = new Point(290, 310);
            btnSub.Size = new Size(80, 45);
            btnSub.Text = "-";
            btnSub.Click += BtnOperator_Click;

            // btn0
            btn0.BackColor = Color.WhiteSmoke;
            btn0.Cursor = Cursors.Hand;
            btn0.FlatStyle = FlatStyle.Flat;
            btn0.FlatAppearance.BorderColor = Color.LightGray;
            btn0.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btn0.ForeColor = Color.RoyalBlue;
            btn0.Location = new Point(20, 365);
            btn0.Size = new Size(80, 45);
            btn0.Text = "0";
            btn0.Click += BtnNumber_Click;

            // btnAdd
            btnAdd.BackColor = Color.WhiteSmoke;
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.FlatAppearance.BorderColor = Color.LightGray;
            btnAdd.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btnAdd.ForeColor = Color.OrangeRed;
            btnAdd.Location = new Point(290, 145);
            btnAdd.Size = new Size(80, 45);
            btnAdd.Text = "+";
            btnAdd.Click += BtnOperator_Click;

            // btnEqual
            btnEqual.BackColor = Color.WhiteSmoke;
            btnEqual.Cursor = Cursors.Hand;
            btnEqual.FlatStyle = FlatStyle.Flat;
            btnEqual.FlatAppearance.BorderColor = Color.LightGray;
            btnEqual.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btnEqual.ForeColor = Color.Black;
            btnEqual.Location = new Point(290, 365);
            btnEqual.Size = new Size(80, 45);
            btnEqual.Text = "=";
            btnEqual.Click += BtnEqual_Click;

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
            Controls.Add(btnCE); Controls.Add(btnC); Controls.Add(btnDel);
            Controls.Add(btn7); Controls.Add(btn8); Controls.Add(btn9); Controls.Add(btnDiv);
            Controls.Add(btn4); Controls.Add(btn5); Controls.Add(btn6); Controls.Add(btnMul);
            Controls.Add(btn1); Controls.Add(btn2); Controls.Add(btn3); Controls.Add(btnSub);
            Controls.Add(btn0); Controls.Add(btnAdd); Controls.Add(btnEqual);

            ResumeLayout(false);
        }

        #endregion

        private Label lblTitle;
        private TextBox txtExpression;
        private TextBox txtResult;
        private Button btnCE, btnC, btnDel;
        private Button btn7, btn8, btn9, btnDiv;
        private Button btn4, btn5, btn6, btnMul;
        private Button btn1, btn2, btn3, btnSub;
        private Button btn0, btnAdd, btnEqual;
    }
}
