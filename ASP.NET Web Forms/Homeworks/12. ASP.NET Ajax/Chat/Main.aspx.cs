using System;
using System.Collections.Generic;
using System.Linq;

namespace Chat
{
    public partial class Main : System.Web.UI.Page
    {
        private List<Message> messages = new List<Message>();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Application.Lock();
            if (this.Application["Messages"] != null)
            {
                this.messages = (List<Message>)this.Application["Messages"];
            }
            this.Application.UnLock();

            this.ListViewMessages.DataSource = this.messages.Skip(Math.Max(0, this.messages.Count() - 100)).Take(100);
            this.ListViewMessages.DataBind();
        }

        protected void ButtonSend_Click(object sender, EventArgs e)
        {
            var message = new Message
            {
                User = this.TextBoxUserName.Text,
                Text = this.TextBoxMessage.Text
            };

            this.messages.Add(message);

            this.Application.Lock();
            this.Application["Messages"] = this.messages;
            this.Application.UnLock();

            this.ListViewMessages.DataSource = this.messages.Skip(Math.Max(0, this.messages.Count() - 100)).Take(100);
            this.ListViewMessages.DataBind();
        }

        protected void TimerTimeRefresh_Tick(object sender, EventArgs e)
        {
            this.Application.Lock();
            this.Application["Messages"] = this.messages;
            this.Application.UnLock();

            this.ListViewMessages.DataSource = this.messages.Skip(Math.Max(0, this.messages.Count() - 100)).Take(100);
            this.ListViewMessages.DataBind();
        }
    }
}