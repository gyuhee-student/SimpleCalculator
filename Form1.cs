namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        private int firstNumber = 0;
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
            {
                txtResult.Text = digit;
                isNewInput = false;
            }
            else
            {
                txtResult.Text += digit;
            }

            txtExpression.Text += digit;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            firstNumber = int.Parse(txtResult.Text);
            txtExpression.Text += " + ";
            isNewInput = true;
        }

        private void BtnEqual_Click(object sender, EventArgs e)
        {
            int secondNumber = int.Parse(txtResult.Text);
            int result = firstNumber + secondNumber;

            txtExpression.Text += " = " + result.ToString();
            txtResult.Text = result.ToString();
            isNewInput = true;
        }
    }
}
