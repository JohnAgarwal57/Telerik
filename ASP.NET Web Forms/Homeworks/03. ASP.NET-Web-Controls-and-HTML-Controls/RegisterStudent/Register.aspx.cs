using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegisterStudent
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack)
            {
                return;
            }

            var universities = new[]
            {
                "New bulgarian university",
                "Sofia University",
                "Technical University"
            };

            this.DropDownListUniversity.DataSource = universities;
            this.DropDownListUniversity.DataBind();

            var specialies = new[]
            {
                "Informatics",
                "Computer system and technologies",
                "Telecomunications"
            };

            this.DropDownListSpecialty.DataSource = specialies;
            this.DropDownListSpecialty.DataBind();

            var courses = new[]
            {
                new { Id =1, Text = "C#" },
                new { Id =2, Text = "Java script" },
                new { Id =3, Text = "CISCO" }
            };

            this.ListBoxCourses.DataSource = courses;
            this.ListBoxCourses.DataBind();
        }

        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            this.SummaryHeader.InnerText = "Summary";

            var firstName = new Label();
            firstName.Text = "<b>First name: </b>" + this.Server.HtmlEncode(this.TextFieldFirstName.Text);
            this.Summary.Controls.Add(firstName);
            this.Summary.Controls.Add(new LiteralControl("<br />"));

            var lastName = new Label();
            lastName.Text = "<b>Last name: </b>" + this.Server.HtmlEncode(this.TextFieldLastName.Text);
            this.Summary.Controls.Add(lastName);
            this.Summary.Controls.Add(new LiteralControl("<br />"));

            var fNumber = new Label();
            fNumber.Text = "<b>Faculty number: </b>" + this.Server.HtmlEncode(this.TextFieldFNumber.Text);
            this.Summary.Controls.Add(fNumber);
            this.Summary.Controls.Add(new LiteralControl("<br />"));

            var university = new Label();
            university.Text = "<b>University: </b>" + this.Server.HtmlEncode(this.DropDownListUniversity.Text);
            this.Summary.Controls.Add(university);
            this.Summary.Controls.Add(new LiteralControl("<br />"));

            var specialty = new Label();
            specialty.Text = "<b>Specialty: </b>" + this.Server.HtmlEncode(this.DropDownListSpecialty.Text);
            this.Summary.Controls.Add(specialty);
            this.Summary.Controls.Add(new LiteralControl("<br />"));

            var selectedCourses = string.Empty;

            foreach (ListItem item in this.ListBoxCourses.Items)
            {
                if (item.Selected)
                {
                    selectedCourses += item.Text + ", ";
                }
            }

            var courses = new Label();

            courses.Text = "<b>Courses: </b>" + selectedCourses.TrimEnd(' ').TrimEnd(',');
            this.Summary.Controls.Add(courses);
            this.Summary.Controls.Add(new LiteralControl("<br />"));
        }
    }
}