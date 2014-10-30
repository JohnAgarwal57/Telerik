namespace EscapingHtml
{
    using System;

    public partial class EscapingHtml : System.Web.UI.Page
    {
        protected void ButtonUnsafeSubmit_Click(object sender, EventArgs e)
        {
            string enteredText = this.TextFieldInput.Text;
            this.TextFieldResult.Text = enteredText;
            this.LabelResult.Text = enteredText;
        }

        protected void ButtonSafeSubmit_Click(object sender, EventArgs e)
        {
            string enteredText = this.TextFieldInput.Text;

            this.TextFieldResult.Text = this.Server.HtmlEncode(enteredText);
            this.LabelResult.Text = this.Server.HtmlEncode(enteredText);
        }
    }
}