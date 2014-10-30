namespace PhotoAlbum
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Web.Script.Services;
    using System.Web.Services;

    public partial class Main : System.Web.UI.Page
    {
        [WebMethodAttribute, ScriptMethodAttribute]
        public static AjaxControlToolkit.Slide[] GetSlides()
        {
            DirectoryInfo imageFolder = new DirectoryInfo(string.Format("{0}img", AppDomain.CurrentDomain.BaseDirectory));

            var files = imageFolder.GetFiles("*.jpg", SearchOption.TopDirectoryOnly)
                                   .Select(file => new AjaxControlToolkit.Slide
                                          {
                                              Name = file.Name,
                                                ImagePath = string.Format("img/{0}", file.Name),
                                                Description = file.Name.TrimEnd(".jpg".ToCharArray())
                                          })
                                   .OrderBy(file => file.Name);

            return files.ToArray();
        }
    }
}