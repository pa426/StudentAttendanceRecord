using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentAttendanceRecord
{
    public class Week
    {
        private int weekId;

        public int WeekId
        {
            get { return weekId; }
            set { weekId = value; }
        }
        private DateTime start;

        public DateTime Start
        {
            get { return start; }
            set { start = value; }
        }
        private DateTime end;

        public DateTime End
        {
            get { return end; }
            set { end = value; }
        }

        private string weekName;

        public string WeekName
        {
            get { return weekName; }
            set { weekName = value; }
        }

        private string weekNameDate;

        public string WeekNameDate
        {
            get { return weekNameDate; }
            set { weekNameDate = value; }
        }

        public Week(int wid, string wn, DateTime s, DateTime e)
        {
            this.weekId = wid;
            this.weekName = wn;
            this.start = s;
            this.end = e;
            this.weekNameDate = wn + " " + s.ToString("dd/mm") + " to " + e.ToString("dd/mm");
            
        }

    }
}