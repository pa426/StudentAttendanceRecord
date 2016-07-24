using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentAttendanceRecord
{
    public class Session
    {

        private int sessionId;

        public int SessionId
        {
            get { return sessionId; }
            set { sessionId = value; }
        }
        private string sessionName;

        public string SessionName
        {
            get { return sessionName; }
            set { sessionName = value; }
        }
        private int studentId;

        public int StudentId
        {
            get { return studentId; }
            set { studentId = value; }
        }
        private int courseId;

        public int CourseId
        {
            get { return courseId; }
            set { courseId = value; }
        }
        private int staffId;

        public int StaffId
        {
            get { return staffId; }
            set { staffId = value; }
        }
        private int roomId;

        public int RoomId
        {
            get { return roomId; }
            set { roomId = value; }
        }
        private string day;

        public string Day
        {
            get { return day; }
            set { day = value; }
        }

        private string timeSlot;

        public string TimeSlot
        {
            get { return timeSlot; }
            set { timeSlot = value; }
        }

        public Session(int seid, string n, int sid,  int cid, int stid, int rid, string d, string sts)
        {
            this.sessionId = seid;
            this.sessionName = n;
            this.studentId = sid;
            this.courseId = cid;
            this.staffId = stid;
            this.roomId = rid;
            this.day = d;
            this.timeSlot = sts;

        }

    }
}