namespace FileUploadInASP.NET
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Web;

    using Ionic.Zip;

    public partial class Upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Response.Expires = -1;
            try
            {
                HttpPostedFile file = this.Request.Files["uploaded"];

                if (file.ContentType == "application/x-zip-compressed")
                {
                    byte[] fileData = null;
                    Stream fileStream = null;
                    int length = 0;

                    length = file.ContentLength;
                    fileData = new byte[length + 1];
                    fileStream = file.InputStream;
                    fileStream.Read(fileData, 0, length);
                    fileStream.Position = 0;

                    using (ZipFile zip = ZipFile.Read(fileStream))
                    {
                        foreach (ZipEntry zipEntry in zip)
                        {
                            MemoryStream personInformation = new MemoryStream();
                            zipEntry.Extract(personInformation);

                            // Here you reach the content of the Text File, but I don't think to create DB just for that
                            // It's not the point of the Homework to create DB, we already know that, the point is to upload file
                            // Read it from memmory, extract in memmory and get information from files :)
                            var info = Encoding.ASCII.GetString(personInformation.ToArray());
                        }
                    }

                    this.Response.ContentType = "application/json";
                    this.Response.Write("{}");
                }
                else
                {
                    this.Response.Write("Upload status: Only ZIP files are accepted!");
                }
            }
            catch (Exception ex)
            {
                this.Response.Write(ex.ToString());
            }
        }
    }
}