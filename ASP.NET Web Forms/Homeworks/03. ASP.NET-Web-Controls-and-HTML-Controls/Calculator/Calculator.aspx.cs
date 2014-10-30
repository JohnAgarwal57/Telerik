namespace Calculator
{
    using System;
    using System.Linq;
    using System.Web.UI.WebControls;

    public partial class Calculator : System.Web.UI.Page
    {
        protected void OnCommand(object sender, CommandEventArgs e)
        {
            if (this.LabelNewNumber.Text == "false")
            {
                this.CalcArea.Text += e.CommandName;
            }
            else
            {
                if (this.LabelOperation.Text == "")
                {
                    this.LabelCurrentNumber.Text = "0";
                }
                else
                {
                    this.LabelCurrentNumber.Text = this.Server.HtmlEncode(this.CalcArea.Text);
                }

                this.CalcArea.Text = e.CommandName;
                this.LabelNewNumber.Text = "false";
            }
        }

        protected void ButtonPlus_Click(object sender, EventArgs e)
        {
            decimal currentNumber;
            var isDecimal = decimal.TryParse(this.CalcArea.Text, out currentNumber);

            if (isDecimal)
            {
                if (this.LabelCalculate.Text == "true")
                {
                    this.CalculateResultNumber();
                }

                this.LabelOperation.Text = "+";
                this.LabelNewNumber.Text = "true";
                this.LabelCalculate.Text = "true";
            }
        }

        protected void ButtonMultiply_Click(object sender, EventArgs e)
        {
            decimal currentNumber;
            var isDecimal = decimal.TryParse(this.CalcArea.Text, out currentNumber);

            if (isDecimal)
            {
                if (this.LabelCalculate.Text == "true")
                {
                    this.CalculateResultNumber();
                }

                this.LabelOperation.Text = "*";
                this.LabelNewNumber.Text = "true";
                this.LabelCalculate.Text = "true";
            }
        }

        protected void ButtonDevide_Click(object sender, EventArgs e)
        {
            decimal currentNumber;
            var isDecimal = decimal.TryParse(this.CalcArea.Text, out currentNumber);

            if (isDecimal)
            {
                if (this.LabelCalculate.Text == "true")
                {
                    this.CalculateResultNumber();
                }

                this.LabelOperation.Text = "/";
                this.LabelNewNumber.Text = "true";
                this.LabelCalculate.Text = "true";
            }
        }

        protected void ButtonSqr_Click(object sender, EventArgs e)
        {
            decimal currentNumber;
            var isDecimal = decimal.TryParse(this.CalcArea.Text, out currentNumber);

            if (isDecimal)
            {
                this.LabelOperation.Text = "sqrt";
                this.CalculateResultNumber();
                this.LabelOperation.Text = "";
            }
        }

        protected void ButtonMinus_Click(object sender, EventArgs e)
        {
            decimal currentNumber;
            var isDecimal = decimal.TryParse(this.CalcArea.Text, out currentNumber);

            if (isDecimal)
            {
                if (this.LabelCalculate.Text == "true")
                {
                    this.CalculateResultNumber();
                }

                this.LabelOperation.Text = "-";
                this.LabelNewNumber.Text = "true";
                this.LabelCalculate.Text = "true";
            }
        }

        protected void ButtonEqual_Click(object sender, EventArgs e)
        {
            this.CalculateResultNumber();
            this.LabelOperation.Text = "";
            this.LabelNewNumber.Text = "true";
            this.LabelCalculate.Text = "false";
        }

        private void CalculateResultNumber()
        {
            this.LabelCalculate.Text = "false";
            double result;
            double storageResult;
            bool isstorageResult = double.TryParse(this.LabelCurrentNumber.Text, out storageResult);
            bool isResult = double.TryParse(this.CalcArea.Text, out result);
            if (isstorageResult && isResult)
            {
                switch (this.LabelOperation.Text)
                {
                    case "+":
                        this.CalcArea.Text = (storageResult + result).ToString();
                        break;
                    case "-":
                        this.CalcArea.Text = (storageResult - result).ToString();
                        break;
                    case "*":
                        this.CalcArea.Text = (storageResult * result).ToString();
                        break;
                    case "/":
                        this.CalcArea.Text = (storageResult / result).ToString();
                        break;
                    case "sqrt":
                        this.CalcArea.Text = (Math.Round(Math.Sqrt(result), 2)).ToString();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}