using Lab8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab8
{
    public partial class AddStudent : System.Web.UI.Page
    {
        private List<Student> students;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateStudentsTable();
            }
            students = Session["StudentsList"] as List<Student>;
            if (students == null)
            {
                students = new List<Student>();
                Session["StudentsList"] = students;
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            string studentType = studentTypeDropDown.SelectedValue;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(studentType))
            {

              
                return;
            }

            Student newStudent;
            switch (studentType)
            {
                case "FullTime":
                    newStudent = new FulltimeStudent(name);
                    break;
                case "PartTime":
                    newStudent = new ParttimeStudent(name);
                    break;
                case "Coop":
                    newStudent = new CoopStudent(name);
                    break;
                default:
                    
                    return;
            }

            students.Add(newStudent);

            PopulateStudentsTable();

            nameTextBox.Text = string.Empty;
            studentTypeDropDown.SelectedIndex = 0;
        }

        private void PopulateStudentsTable()
        {
            registeredStudents.DataSource = students;
            registeredStudents.DataBind();
        }
    }
}