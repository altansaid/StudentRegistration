using Lab8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab8
{
    public partial class RegisterCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Course> availableCourses = Helper.GetAvailableCourses();
                PopulateCoursesCheckBoxList(availableCourses);
                PopulateStudentDropDown();
            }
        }

        private void PopulateStudentDropDown()
        {
            
            List<Student> students = Session["StudentsList"] as List<Student>;

            if (students != null)
            {
                
                var studentDisplayList = students.Select(s => new {
                    DisplayText = $"{s.Id} - {s.Name} ({s.GetType().Name})",
                    Value = s.Id 
                });

                
                studentDropDown.DataSource = studentDisplayList;
                studentDropDown.DataTextField = "DisplayText";
                studentDropDown.DataValueField = "Value";
                studentDropDown.DataBind();
            }
        }

        protected void studentDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            string studentId = studentDropDown.SelectedValue;

     
            Student selectedStudent = GetStudentById(studentId);

            if (selectedStudent != null)
            {
            
                registrationSummaryLabel.Text = GetRegistrationSummary(selectedStudent);

              
                PopulateCoursesCheckBoxList(selectedStudent.RegisteredCourses);
            }
        }

        private Student GetStudentById(string studentId)
        {
            
            List<Student> students = Session["StudentsList"] as List<Student>;

            if (students != null)
            {
               
                int id;
                if (int.TryParse(studentId, out id))
                {
                    return students.FirstOrDefault(s => s.Id == id);
                }
            }

            return null;
        }


        private string GetRegistrationSummary(Student student)
        {
           
            int numberOfCourses = student.RegisteredCourses.Count;

           
            int totalWeeklyHours = student.RegisteredCourses.Sum(c => c.WeeklyHours);

           
            string summary = $"Number of Courses: {numberOfCourses}, Total Weekly Hours: {totalWeeklyHours}";

            return summary;
        }

        private void PopulateCoursesCheckBoxList(List<Course> registeredCourses)
        {
         
            List<Course> availableCourses = Helper.GetAvailableCourses();

           
            coursesCheckBoxList.DataSource = availableCourses;
            coursesCheckBoxList.DataTextField = "FormattedName";
            coursesCheckBoxList.DataValueField = "Code";
            coursesCheckBoxList.DataBind();


            if (string.IsNullOrEmpty(studentDropDown.SelectedValue))
            {
                foreach (ListItem item in coursesCheckBoxList.Items)
                {
                    item.Selected = false;
                }
            }
            else
            {
        
                foreach (ListItem item in coursesCheckBoxList.Items)
                {
                    if (registeredCourses.Any(c => c.Code == item.Value))
                    {
                        item.Selected = true;
                    }
                }
            }
        }


        protected void submitButton_Click(object sender, EventArgs e)
        {
            errorLabel.Visible = false;
            

            if (string.IsNullOrEmpty(studentDropDown.SelectedValue))
            {
                errorLabel.Text = "Please select a student.";
                errorLabel.Visible = true;
                return;
            }
            if (GetSelectedCourses().Count == 0)
            {
                errorLabel.Text = "Please select at least one course.";
                errorLabel.Visible = true;
                return;
            }

       
            string studentId = studentDropDown.SelectedValue;
            Student selectedStudent = GetStudentById(studentId);

            if (selectedStudent != null)
            {
                try
                {
        
                    List<Course> selectedCourses = GetSelectedCourses();

                
                    selectedStudent.RegisterCourses(selectedCourses);

                  
                    registrationSummaryLabel.Text = GetRegistrationSummary(selectedStudent);
                }
                catch (Exception ex)
                {
                    
                    errorLabel.Text = ex.Message;
                    errorLabel.Visible = true;
                }
            }
        }

        private List<Course> GetSelectedCourses()
        {
            List<Course> selectedCourses = new List<Course>();

           
            foreach (ListItem item in coursesCheckBoxList.Items)
            {
                if (item.Selected)
                {
                    
                    Course course = Helper.GetCourseByCode(item.Value);
                    if (course != null)
                    {
                        selectedCourses.Add(course);
                    }
                }
            }

            return selectedCourses;
        }
    }
}
