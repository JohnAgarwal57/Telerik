namespace Mobile
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using Mobile.Models;
    using System.Text;


    public partial class Home : System.Web.UI.Page
    {
        private Producer[] cars = new Producer[]
        {
            new Producer 
            {
                Name = "Mercedes",
                Models = new Model[]
                {
                    new Model { Name = "CLS" },
                    new Model { Name = "SLS" },
                    new Model { Name = "A class" },
                    new Model { Name = "B class" },
                    new Model { Name = "C class" },
                }
            },
            new Producer 
            {
                Name = "BMW",
                Models = new Model[]
                {
                    new Model { Name = "320i" },
                    new Model { Name = "330i" },
                    new Model { Name = "530i" },
                    new Model { Name = "550" },
                    new Model { Name = "728i" },
                }
            },
            new Producer 
            {
                Name = "Audi",
                Models = new Model[]
                {
                    new Model { Name = "A2" },
                    new Model { Name = "A3" },
                    new Model { Name = "A4" },
                    new Model { Name = "S4" },
                    new Model { Name = "S5" },
                }
            },
            new Producer 
            {
                Name = "Lada",
                Models = new Model[]
                {
                    new Model { Name = "1500" },
                    new Model { Name = "1700" },
                    new Model { Name = "2103" },
                    new Model { Name = "2105" },
                    new Model { Name = "2107" },
                }
            }
        };

        private Extra[] extras = new Extra[] 
        {
            new Extra { Name = "Climatronic"},
            new Extra { Name = "Parktronic"},
            new Extra { Name = "Stereo"},
            new Extra { Name = "Alarm"},
            new Extra { Name = "DVD/TV"},
            new Extra { Name = "Electronic mirros"},
            new Extra { Name = "Electronic windows"},
            new Extra { Name = "Navigation"}
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack)
            {
                return;
            }

            this.DropDownListProducer.DataSource = this.cars;
            this.DropDownListProducer.DataBind();

            this.CheckBoxListExtras.DataSource = this.extras;
            this.CheckBoxListExtras.DataBind();

            var engines = new[]
            {
                "diesel",
                "petrol",
                "gas",
                "electric"
            };

            this.RadioButtonListEngine.DataSource = engines;
            this.RadioButtonListEngine.DataBind();
        }

        protected void DropDownListCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList listView = sender as DropDownList;
            if (listView == null)
            {
                return;
            }

            var models = this.GetModelsByProducer(listView.SelectedValue).ToArray();

            this.DropDownListModel.DataSource = models;
            this.DropDownListModel.DataBind();
        }

        private IEnumerable<string> GetModelsByProducer(string selectedProducer)
        {
            return this.cars.FirstOrDefault(p => p.Name == selectedProducer)
                .Models.Select(m => m.Name);
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            StringBuilder summary = new StringBuilder();

            summary.AppendLine("<b>Producer</b>: " + this.DropDownListProducer.SelectedValue);
            summary.AppendLine("<b>Model</b>: " + this.DropDownListModel.SelectedValue);
            summary.AppendLine("<b>Engine</b>: " + this.RadioButtonListEngine.SelectedValue);

            var extras = string.Empty;

            foreach (ListItem item in this.CheckBoxListExtras.Items)
            {
                if (item.Selected)
                {
                    extras += item.Text + ", ";
                }
            }

            summary.AppendLine("<b>Extras</b>: " + extras.TrimEnd(' ').TrimEnd(','));

            this.Summary.Text = summary.ToString();
        }
    }
}