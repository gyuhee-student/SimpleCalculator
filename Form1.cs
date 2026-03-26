namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        private int firstNumber = 0;
        private string currentOperator = "";
        private bool isNewInput = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void BtnNumber_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string digit = btn.Text;

            if (isNewInput)
                isNewInput = false;

            txtExpression.Text += digit;
        }

        private void BtnOperator_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            currentOperator = btn.Text;
            firstNumber = int.Parse(txtExpression.Text.Trim());
            txtExpression.Text += " " + currentOperator + " ";
            isNewInput = true;
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
                case "÷": result = firstNumber / secondNumber; break;
            }

            txtExpression.Text += " = " + result.ToString();
            txtResult.Text = result.ToString();
            isNewInput = true;
        }
    }
}
