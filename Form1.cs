namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        private int firstNumber = 0;
        private string currentOperator = "";
        private bool isNewInput = true;
        private bool isResult = false;

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
            this.KeyPress += Form1_KeyPress;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                SimulateNumberClick(e.KeyChar.ToString());
            }
            else if (e.KeyChar == '+') btnAdd.PerformClick();
            else if (e.KeyChar == '-') btnSub.PerformClick();
            else if (e.KeyChar == '*') btnMul.PerformClick();
            else if (e.KeyChar == '/') btnDiv.PerformClick();
            else if (e.KeyChar == '=') btnEqual.PerformClick();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEqual.PerformClick();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                btnC.PerformClick();
            }
            else if (e.KeyCode == Keys.Back)
            {
                btnDel.PerformClick();
            }
        }

        private void SimulateNumberClick(string digit)
        {
            if (isNewInput)
                isNewInput = false;
            txtExpression.Text += digit;
            ScrollToEnd();
        }

        private void ScrollToEnd()
        {
            txtExpression.SelectionStart = txtExpression.Text.Length;
            txtExpression.ScrollToCaret();
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

        private void BtnNumber_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string digit = btn.Text;

            if (isNewInput)
                isNewInput = false;

            txtExpression.Text += digit;
            ScrollToEnd();
        }

        private void BtnOperator_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string newOperator = btn.Text;

            if (isResult)
            {
                firstNumber = int.Parse(txtResult.Text);
                txtExpression.Text = txtResult.Text + " " + newOperator + " ";
                txtResult.Text = "";
                isResult = false;
            }
            else if (currentOperator != "" && !isNewInput)
            {
                BtnEqual_Click(null, EventArgs.Empty);
                firstNumber = int.Parse(txtResult.Text);
                txtExpression.Text = txtResult.Text + " " + newOperator + " ";
                txtResult.Text = "";
                isResult = false;
            }
            else
            {
                firstNumber = int.Parse(txtExpression.Text.Trim());
                txtExpression.Text += " " + newOperator + " ";
            }

            currentOperator = newOperator;
            isNewInput = true;
            ScrollToEnd();
        }

        private void BtnC_Click(object sender, EventArgs e)
        {
            txtExpression.Text = "";
            txtResult.Text = "";
            firstNumber = 0;
            currentOperator = "";
            isNewInput = true;
        }

        private void BtnCE_Click(object sender, EventArgs e)
        {
            if (currentOperator == "")
            {
                txtExpression.Text = "";
            }
            else
            {
                string prefix = firstNumber.ToString() + " " + currentOperator + " ";
                txtExpression.Text = prefix;
            }
            isNewInput = true;
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            if (txtExpression.Text.Length > 0)
                txtExpression.Text = txtExpression.Text.Substring(0, txtExpression.Text.Length - 1);
            ScrollToEnd();
        }

        private void BtnEqual_Click(object sender, EventArgs e)
        {
            string[] parts = txtExpression.Text.Split(currentOperator);
            int secondNumber = int.Parse(parts[1].Trim());
            int result = 0;

            switch (currentOperator)
            {
                case "+": result = firstNumber + secondNumber; break;
                case "-": result = firstNumber - secondNumber; break;
                case "x": result = firstNumber * secondNumber; break;
                case "÷":
                    if (secondNumber == 0)
                    {
                        txtExpression.Text = "0으로 나눌 수 없습니다";
                        txtResult.Text = "";
                        firstNumber = 0;
                        currentOperator = "";
                        isNewInput = true;
                        return;
                    }
                    result = firstNumber / secondNumber;
                    break;
            }

            txtExpression.Text += " = " + result.ToString();
            txtResult.Text = result.ToString();
            isNewInput = true;
            isResult = true;
        }
    }
}
