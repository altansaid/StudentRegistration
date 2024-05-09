using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab8.Models
{
    public class FulltimeStudent : Student
    {
        public static int MaxWeeklyHours { get; set; }

        public FulltimeStudent(string name) : base(name)
        {
        }

        public override void RegisterCourses(List<Course> selectedCourses)
        {
            int totalHours = selectedCourses.Sum(course => course.WeeklyHours);
            if (totalHours > MaxWeeklyHours)
            {
                throw new Exception("Total weekly hours exceeds the maximum allowed for FulltimeStudent.");
            }

            base.RegisterCourses(selectedCourses);
        }
        public override string ToString()
        {
            return $"{Id} - {Name} (Full time)";
        }
    }
}