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

        private bool HasLeadingZero()
        {
            string text = txtExpression.Text;
            int i = text.Length - 1;
            while (i >= 0 && char.IsDigit(text[i])) i--;
            string currentNum = text.Substring(i + 1);
            return currentNum == "0";
        }

        private void SimulateNumberClick(string digit)
        {
            if (isResult)
            {
                // 결과 후 숫자 누르면 새 계산 시작
                txtExpression.Text = "";
                txtResult.Text = "";
                firstNumber = 0;
                currentOperator = "";
                isResult = false;
            }
            if (isNewInput)
                isNewInput = false;
            if (HasLeadingZero()) return;
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

            if (isResult)
            {
                // 결과 후 숫자 누르면 새 계산 시작
                txtExpression.Text = "";
                txtResult.Text = "";
                firstNumber = 0;
                currentOperator = "";
                isResult = false;
            }
            if (isNewInput)
                isNewInput = false;

            if (HasLeadingZero()) return;
            txtExpression.Text += digit;
            ScrollToEnd();
        }

        private void BtnOperator_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string newOperator = btn.Text;

            if (isResult)
            {
                // 결과 상태에서 연산자 누름 → 결과를 첫 번째 수로 이어서 계산
                if (!int.TryParse(txtResult.Text, out firstNumber)) return;
                txtExpression.Text = txtResult.Text + " " + newOperator + " ";
                txtResult.Text = "";
                isResult = false;
            }
            else if (currentOperator != "" && !isNewInput)
            {
                // 두 번째 숫자까지 입력된 상태 → 중간 계산 후 연속 연산
                BtnEqual_Click(null, EventArgs.Empty);
                if (!int.TryParse(txtResult.Text, out firstNumber)) return;
                txtExpression.Text = txtResult.Text + " " + newOperator + " ";
                txtResult.Text = "";
                isResult = false;
            }
            else if (currentOperator != "" && isNewInput)
            {
                // 숫자 입력 없이 연산자만 다시 누름 → 연산자만 교체
                txtExpression.Text = firstNumber.ToString() + " " + newOperator + " ";
            }
            else
            {
                // 첫 번째 연산자 입력
                string raw = txtExpression.Text.Trim();
                if (raw == "") return;
                if (!int.TryParse(raw, out firstNumber)) return;
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
            isResult = false;
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
            if (isResult) return; // 결과 표시 중엔 Del 무시
            if (txtExpression.Text.Length > 0)
                txtExpression.Text = txtExpression.Text.Substring(0, txtExpression.Text.Length - 1);
            ScrollToEnd();
        }

        private void BtnEqual_Click(object sender, EventArgs e)
        {
            // 연산자 없거나 두 번째 숫자 미입력 상태면 무시
            if (currentOperator == "" || isNewInput || isResult) return;

            string delimiter = " " + currentOperator + " ";
            string[] parts = txtExpression.Text.Split(new string[] { delimiter }, StringSplitOptions.None);
            if (parts.Length < 2) return;
            if (!int.TryParse(parts[1].Trim(), out int secondNumber)) return;

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
                default: return;
            }

            txtExpression.Text += " = " + result.ToString();
            txtResult.Text = result.ToString();
            isNewInput = true;
            isResult = true;
        }
    }
}
