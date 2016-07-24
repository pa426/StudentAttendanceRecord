using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentAttendanceRecord
{
    public class Record
    {

        private int attRecId;

        public int AttRecId
        {
            get { return attRecId; }
            set { attRecId = value; }
        }
        private int sessionId;

        public int SessionId
        {
            get { return sessionId; }
            set { sessionId = value; }
        }
        private int weekId;

        public int WeekId
        {
            get { return weekId; }
            set { weekId = value; }
        }
       
        private DateTime eventDate;

        public DateTime EventDate
        {
            get { return eventDate; }
            set { eventDate = value; }
        }

        public Record(int arid, int sesid, int wid, DateTime ed)
        {

            this.attRecId = arid;
            this.sessionId = sesid;
            this.weekId = wid;
            this.eventDate = ed;

        }


    }
}