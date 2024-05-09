using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab8.Models
{
    public class Course
    {
        public string Code { get; }

        public string Name { get; }

        public int WeeklyHours { get; set; }
        public Course(string code, string title)
        {
            Code = code;
            string Name = title;
            WeeklyHours = 0;
           
        }
        public string FormattedName
        {
            get { return $"{Code} - {Name} - {WeeklyHours} hour(s) per week"; }
        }




    }
}