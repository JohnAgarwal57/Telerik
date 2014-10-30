namespace GraphicalCounter
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Linq;

    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // To to with DB Simply has to change loading and saving from Application with Linq to some field in some table
            // It's not somthing common with this course, so I'll skip it... :)
            this.Application.Lock();
            if (this.Application["VisitorCount"] == null)
            {
                this.Application["VisitorCount"] = 1;
            }
            else
            {
                this.Application["VisitorCount"] = (int)this.Application["VisitorCount"] + 1;
            }
            this.Application.UnLock();

            Bitmap generatedImage = new Bitmap(200, 200);
            using (generatedImage)
            {
                Graphics gr = Graphics.FromImage(generatedImage);
                using (gr)
                {
                    string num = this.Application["VisitorCount"].ToString();

                    gr.FillRectangle(Brushes.MediumSeaGreen, 0, 0, 200, 200);

                    Font drawFont = new Font("Arial", 24);
                    SolidBrush drawBrush = new SolidBrush(Color.Blue);

                    PointF drawPoint = new PointF(80.0F, 80.0F);

                    gr.DrawString(num, drawFont, drawBrush, drawPoint);

                    this.Response.ContentType = "image/gif";

                    generatedImage.Save(this.Response.OutputStream, ImageFormat.Jpeg);
                }
            }
        }
    }
}