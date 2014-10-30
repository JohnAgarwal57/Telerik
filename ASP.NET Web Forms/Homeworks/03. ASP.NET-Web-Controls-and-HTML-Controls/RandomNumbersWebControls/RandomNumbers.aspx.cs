using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RandomNumbersWebControls
{
    public partial class RandomNumbers : System.Web.UI.Page
    {
        private Random rand = new Random();

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            int minValue = 0;
            int maxValue = 0;

            if (this.TextFieldMinNumber.Text != string.Empty)
            {
                int.TryParse(this.TextFieldMinNumber.Text, out minValue);
            }

            if (this.TextFieldMaxNumber.Text != string.Empty)
            {
                int.TryParse(this.TextFieldMaxNumber.Text, out maxValue);
            }
            
            this.LabelResult.Text = this.rand.Next(minValue, maxValue + 1).ToString();
        }
    }
}