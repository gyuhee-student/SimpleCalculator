namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        private List<int> numbers = new List<int>();
        private List<string> operators = new List<string>();
        private string currentInput = "";
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
                SimulateNumberClick(e.KeyChar.ToString());
            else if (e.KeyChar == '+') btnAdd.PerformClick();
            else if (e.KeyChar == '-') btnSub.PerformClick();
            else if (e.KeyChar == '*') btnMul.PerformClick();
            else if (e.KeyChar == '/') btnDiv.PerformClick();
            else if (e.KeyChar == '=') btnEqual.PerformClick();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnEqual.PerformClick();
            else if (e.KeyCode == Keys.Delete) btnC.PerformClick();
            else if (e.KeyCode == Keys.Back) btnDel.PerformClick();
        }

        private void SimulateNumberClick(string digit)
        {
            if (isResult)
            {
                numbers.Clear();
                operators.Clear();
                currentInput = "";
                isResult = false;
            }
            if (currentInput == "0") return; // 선행 0 방지
            currentInput += digit;
            UpdateDisplay();
        }

        private void BtnNumber_Click(object sender, EventArgs e)
        {
            SimulateNumberClick(((Button)sender).Text);
        }

        private void BtnOperator_Click(object sender, EventArgs e)
        {
            string newOp = ((Button)sender).Text;

            if (isResult)
            {
                // 결과 상태에서 연산자 누름 → 결과를 첫 번째 수로 이어서 계산
                if (!int.TryParse(txtResult.Text, out int val)) return;
                numbers.Clear();
                operators.Clear();
                numbers.Add(val);
                currentInput = "";
                isResult = false;
                operators.Add(newOp);
                UpdateDisplay();
                return;
            }

            if (currentInput == "" && numbers.Count == 0) return;

            if (currentInput != "")
            {
                if (!int.TryParse(currentInput, out int num)) return;
                numbers.Add(num);
                currentInput = "";
                operators.Add(newOp);
            }
            else
            {
                // 숫자 입력 없이 연산자만 다시 누름 → 마지막 연산자 교체
                if (operators.Count > 0)
                    operators[operators.Count - 1] = newOp;
            }

            UpdateDisplay();
        }

        private void BtnEqual_Click(object sender, EventArgs e)
        {
            if (isResult) return;
            if (currentInput == "" || operators.Count == 0) return;
            if (!int.TryParse(currentInput, out int lastNum)) return;

            var allNums = new List<int>(numbers) { lastNum };
            string expr = BuildExpression(allNums, operators, "");

            try
            {
                int result = Evaluate(new List<int>(allNums), new List<string>(operators));
                txtExpression.Text = expr + " = " + result;
                txtResult.Text = result.ToString();
                numbers.Clear();
                operators.Clear();
                currentInput = "";
                isResult = true;
            }
            catch (DivideByZeroException)
            {
                txtExpression.Text = "0으로 나눌 수 없습니다";
                txtResult.Text = "";
                numbers.Clear();
                operators.Clear();
                currentInput = "";
                isResult = false;
            }
            ScrollToEnd();
        }

        private int Evaluate(List<int> nums, List<string> ops)
        {
            // 1단계: 곱하기·나누기 먼저 처리
            int i = 0;
            while (i < ops.Count)
            {
                if (ops[i] == "x" || ops[i] == "÷")
                {
                    if (ops[i] == "÷" && nums[i + 1] == 0)
                        throw new DivideByZeroException();
                    int res = ops[i] == "x" ? nums[i] * nums[i + 1] : nums[i] / nums[i + 1];
                    nums[i] = res;
                    nums.RemoveAt(i + 1);
                    ops.RemoveAt(i);
                }
                else i++;
            }

            // 2단계: 더하기·빼기 처리
            int total = nums[0];
            for (int j = 0; j < ops.Count; j++)
                total = ops[j] == "+" ? total + nums[j + 1] : total - nums[j + 1];
            return total;
        }

        private string BuildExpression(List<int> nums, List<string> ops, string curIn)
        {
            string result = "";
            for (int i = 0; i < nums.Count; i++)
            {
                result += nums[i].ToString();
                if (i < ops.Count)
                    result += " " + ops[i] + " ";
            }
            result += curIn;
            return result;
        }

        private void UpdateDisplay()
        {
            txtExpression.Text = BuildExpression(numbers, operators, currentInput);
            txtResult.Text = currentInput != "" ? currentInput :
                             (numbers.Count > 0 ? numbers[numbers.Count - 1].ToString() : "");
            ScrollToEnd();
        }

        private void ScrollToEnd()
        {
            txtExpression.SelectionStart = txtExpression.Text.Length;
            txtExpression.ScrollToCaret();
        }

        private void BtnC_Click(object sender, EventArgs e)
        {
            numbers.Clear();
            operators.Clear();
            currentInput = "";
            isResult = false;
            txtExpression.Text = "";
            txtResult.Text = "";
        }

        private void BtnCE_Click(object sender, EventArgs e)
        {
            isResult = false;
            if (operators.Count == 0)
            {
                numbers.Clear();
                currentInput = "";
                txtExpression.Text = "";
                txtResult.Text = "";
            }
            else
            {
                // 현재 입력 중인 피연산자만 삭제
                currentInput = "";
                UpdateDisplay();
            }
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            if (isResult) return;
            if (currentInput.Length > 0)
            {
                currentInput = currentInput.Substring(0, currentInput.Length - 1);
            }
            else if (operators.Count > 0)
            {
                // 연산자 삭제 → 이전 숫자를 currentInput으로 복원
                operators.RemoveAt(operators.Count - 1);
                if (numbers.Count > 0)
                {
                    currentInput = numbers[numbers.Count - 1].ToString();
                    numbers.RemoveAt(numbers.Count - 1);
                }
            }
            UpdateDisplay();
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
    }
}
