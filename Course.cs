using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentAttendanceRecord
{
    public class Course
    {
        private int courseId;

        public int CourseId
        {
            get { return courseId; }
            set { courseId = value; }
        }

        private string courseName;

        public string CourseName
        {
            get { return courseName; }
            set { courseName = value; }
        }

        private int staffId;

        public int StaffId
        {
            get { return staffId; }
            set { staffId = value; }
        }

        private int courseDuration;

        public int CourseDuration
        {
            get { return courseDuration; }
            set { courseDuration = value; }
        }

        public Course(int cid, string cn, int sid, int cd )
        {
            this.courseId = cid;
            this.courseName = cn;
            this.staffId = sid;
            this.courseDuration = cd;
           
        }

    }
}