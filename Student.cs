using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentAttendanceRecord
{
    public class Student
    {

        private int studentId;

        public int StudentId
        {
            get { return studentId; }
            set { studentId = value; }
        }
        private string studentName;

        public string StudentName
        {
            get { return studentName; }
            set { studentName = value; }
        }
        private string studentSurname;

        public string StudentSurname
        {
            get { return studentSurname; }
            set { studentSurname = value; }
        }

        private string holeName;
        
        public string HoleName
        {
            get { return holeName; }
            set { holeName = value; }
        }

        private string studentPassword;

        public string StudentPassword
        {
            get { return studentPassword; }
            set { studentPassword = value; }
        }
        

        public Student(int sid, string n, string s, string p)
        {
            this.studentId = sid;
            this.studentName = n;
            this.studentSurname = s;
            this.holeName = n + " " + s;
            this.studentPassword = p;
           
        }

    }
}