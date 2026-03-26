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
                isNewInput = false;

            txtExpression.Text += digit;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            firstNumber = int.Parse(txtExpression.Text.Trim());
            txtExpression.Text += " + ";
            isNewInput = true;
        }

        private void BtnEqual_Click(object sender, EventArgs e)
        {
            string[] parts = txtExpression.Text.Split('+');
            int secondNumber = int.Parse(parts[1].Trim());
            int result = firstNumber + secondNumber;

            txtExpression.Text += " = " + result.ToString();
            txtResult.Text = result.ToString();
            isNewInput = true;
        }
    }
}
