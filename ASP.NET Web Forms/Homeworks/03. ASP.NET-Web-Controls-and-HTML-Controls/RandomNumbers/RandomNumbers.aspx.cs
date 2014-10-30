using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RandomNumbers
{
    public partial class RandomNumbers : System.Web.UI.Page
    {
        private Random rand = new Random();

        protected void ButtonSubmit_ServerClick(object sender, EventArgs e)
        {
            int minValue = 0;
            int maxValue = 0;

            if (this.TextFieldMinNumber.Value != string.Empty)
            {
                int.TryParse(this.TextFieldMinNumber.Value, out minValue);
            }

            if (this.TextFieldMaxNumber.Value != string.Empty)
            {
                int.TryParse(this.TextFieldMaxNumber.Value, out maxValue);
            }

            this.LabelResult.InnerText = this.rand.Next(minValue, maxValue + 1).ToString();
        }
    }
}