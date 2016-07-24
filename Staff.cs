using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentAttendanceRecord
{
    public class Staff
    {
        private int staffId;

        public int StaffId
        {
            get { return staffId; }
            set { staffId = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string surname;

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        private string holeName;

        public string HoleName
        {
            get { return holeName; }
            set { holeName = value; }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        private int staffType;
        
        public int StaffType
        {
            get { return staffType; }
            set { staffType = value; }
        }

        public Staff(int sid, string n, string s, string p, int st)
        {
            this.staffId = sid;
            this.name = n;
            this.surname = s;
            this.holeName = n + " " + s;
            this.password = p;
            this.staffType = st;
        }


    }
}