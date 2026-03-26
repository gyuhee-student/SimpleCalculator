namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        private List<string> tokens = new List<string>();
        private string currentInput = "";
        private bool isResult = false;
        private int parenDepth = 0;

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
            else if (e.KeyChar == '(') btnOpenParen.PerformClick();
            else if (e.KeyChar == ')') btnCloseParen.PerformClick();
            else if (e.KeyChar == '=') btnEqual.PerformClick();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnEqual.PerformClick();
            else if (e.KeyCode == Keys.Delete) btnC.PerformClick();
            else if (e.KeyCode == Keys.Back) btnDel.PerformClick();
        }

        private bool IsOperator(string tok) =>
            tok == "+" || tok == "-" || tok == "x" || tok == "÷";

        private string LastToken() =>
            tokens.Count > 0 ? tokens[tokens.Count - 1] : "";

        private void SimulateNumberClick(string digit)
        {
            if (isResult)
            {
                tokens.Clear();
                currentInput = "";
                isResult = false;
                parenDepth = 0;
            }
            // 닫는 괄호 바로 뒤 숫자 → 암묵적 곱하기 삽입
            if (LastToken() == ")")
                tokens.Add("x");
            if (currentInput == "0") return; // 선행 0 방지
            currentInput += digit;
            UpdateDisplay();
        }

        private void BtnNumber_Click(object sender, EventArgs e)
        {
            SimulateNumberClick(((Button)sender).Text);
        }

        private void BtnOpenParen_Click(object sender, EventArgs e)
        {
            if (isResult)
            {
                tokens.Clear();
                currentInput = "";
                isResult = false;
                parenDepth = 0;
            }
            // 숫자 입력 중이면 → 암묵적 곱하기 삽입 후 (
            if (currentInput != "")
            {
                tokens.Add(currentInput);
                currentInput = "";
                tokens.Add("x");
            }
            else
            {
                string last = LastToken();
                // 닫는 괄호나 숫자 토큰 뒤에도 암묵적 곱하기
                if (last == ")" || int.TryParse(last, out _))
                    tokens.Add("x");
                else if (last != "" && last != "(" && !IsOperator(last))
                    return;
            }

            tokens.Add("(");
            parenDepth++;
            UpdateDisplay();
        }

        private void BtnCloseParen_Click(object sender, EventArgs e)
        {
            if (parenDepth == 0) return;
            // 괄호 안에 아무것도 없거나 연산자로 끝난 상태면 무시
            if (currentInput == "" && (LastToken() == "(" || IsOperator(LastToken()))) return;

            if (currentInput != "")
            {
                tokens.Add(currentInput);
                currentInput = "";
            }
            tokens.Add(")");
            parenDepth--;
            UpdateDisplay();
        }

        private void BtnOperator_Click(object sender, EventArgs e)
        {
            string newOp = ((Button)sender).Text;

            if (isResult)
            {
                // 결과 상태에서 연산자 누름 → 결과를 첫 번째 토큰으로 이어서 계산
                tokens.Clear();
                tokens.Add(txtResult.Text);
                currentInput = "";
                isResult = false;
                parenDepth = 0;
                tokens.Add(newOp);
                UpdateDisplay();
                return;
            }

            if (currentInput == "" && tokens.Count == 0) return;

            string last = LastToken();

            if (currentInput != "")
            {
                tokens.Add(currentInput);
                currentInput = "";
                tokens.Add(newOp);
            }
            else if (last == ")")
            {
                // 닫는 괄호 뒤 연산자
                tokens.Add(newOp);
            }
            else if (IsOperator(last))
            {
                // 연산자 연속 입력 → 마지막 연산자 교체
                tokens[tokens.Count - 1] = newOp;
            }
            // 여는 괄호 바로 뒤 연산자는 무시

            UpdateDisplay();
        }

        private void BtnEqual_Click(object sender, EventArgs e)
        {
            if (isResult) return;

            var evalTokens = new List<string>(tokens);
            if (currentInput != "")
                evalTokens.Add(currentInput);

            if (evalTokens.Count == 0) return;
            // 연산자 없이 숫자만 있으면 무시
            bool hasOperator = evalTokens.Exists(t => IsOperator(t));
            if (!hasOperator) return;

            // 열린 괄호 자동으로 닫기
            for (int i = 0; i < parenDepth; i++)
                evalTokens.Add(")");

            string expr = BuildExpression(evalTokens, "");

            try
            {
                int result = EvaluateTokens(evalTokens);
                txtExpression.Text = expr + " = " + result;
                txtResult.Text = result.ToString();
                tokens.Clear();
                currentInput = "";
                parenDepth = 0;
                isResult = true;
            }
            catch (DivideByZeroException)
            {
                txtExpression.Text = "0으로 나눌 수 없습니다";
                txtResult.Text = "";
                tokens.Clear();
                currentInput = "";
                parenDepth = 0;
                isResult = false;
            }
            ScrollToEnd();
        }

        private int EvaluateTokens(List<string> toks)
        {
            // Shunting-yard 알고리즘으로 중위 표기를 후위 표기로 변환 후 계산
            var output = new Queue<string>();
            var opStack = new Stack<string>();

            int Precedence(string op)
            {
                if (op == "+" || op == "-") return 1;
                if (op == "x" || op == "÷") return 2;
                return 0;
            }

            foreach (var tok in toks)
            {
                if (int.TryParse(tok, out _))
                {
                    output.Enqueue(tok);
                }
                else if (tok == "(")
                {
                    opStack.Push(tok);
                }
                else if (tok == ")")
                {
                    while (opStack.Count > 0 && opStack.Peek() != "(")
                        output.Enqueue(opStack.Pop());
                    if (opStack.Count > 0) opStack.Pop(); // ( 제거
                }
                else // 연산자
                {
                    while (opStack.Count > 0 && opStack.Peek() != "(" &&
                           Precedence(opStack.Peek()) >= Precedence(tok))
                        output.Enqueue(opStack.Pop());
                    opStack.Push(tok);
                }
            }
            while (opStack.Count > 0)
                output.Enqueue(opStack.Pop());

            // 후위 표기 계산
            var evalStack = new Stack<int>();
            while (output.Count > 0)
            {
                string tok = output.Dequeue();
                if (int.TryParse(tok, out int num))
                {
                    evalStack.Push(num);
                }
                else
                {
                    int b = evalStack.Pop(), a = evalStack.Pop();
                    switch (tok)
                    {
                        case "+": evalStack.Push(a + b); break;
                        case "-": evalStack.Push(a - b); break;
                        case "x": evalStack.Push(a * b); break;
                        case "÷":
                            if (b == 0) throw new DivideByZeroException();
                            evalStack.Push(a / b);
                            break;
                    }
                }
            }
            return evalStack.Pop();
        }

        private string BuildExpression(List<string> toks, string curIn)
        {
            string result = "";
            foreach (var tok in toks)
            {
                if (tok == "(") result += "(";
                else if (tok == ")") result += ")";
                else if (IsOperator(tok)) result += " " + tok + " ";
                else result += tok;
            }
            result += curIn;
            return result;
        }

        private void UpdateDisplay()
        {
            txtExpression.Text = BuildExpression(tokens, currentInput);
            if (currentInput != "")
                txtResult.Text = currentInput;
            else
            {
                string last = LastToken();
                txtResult.Text = int.TryParse(last, out _) ? last : "";
            }
            ScrollToEnd();
        }

        private void ScrollToEnd()
        {
            txtExpression.SelectionStart = txtExpression.Text.Length;
            txtExpression.ScrollToCaret();
        }

        private void BtnC_Click(object sender, EventArgs e)
        {
            tokens.Clear();
            currentInput = "";
            isResult = false;
            parenDepth = 0;
            txtExpression.Text = "";
            txtResult.Text = "";
        }

        private void BtnCE_Click(object sender, EventArgs e)
        {
            isResult = false;
            if (currentInput != "")
            {
                currentInput = "";
            }
            else if (tokens.Count > 0)
            {
                string last = LastToken();
                tokens.RemoveAt(tokens.Count - 1);
                if (last == ")") parenDepth++;
                else if (last == "(") parenDepth--;
            }
            UpdateDisplay();
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            if (isResult) return;
            if (currentInput.Length > 0)
            {
                currentInput = currentInput.Substring(0, currentInput.Length - 1);
            }
            else if (tokens.Count > 0)
            {
                string last = LastToken();
                tokens.RemoveAt(tokens.Count - 1);
                if (last == ")") parenDepth++;
                else if (last == "(") parenDepth--;
                else if (int.TryParse(last, out _)) currentInput = last; // 숫자 토큰은 currentInput으로 복원
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
