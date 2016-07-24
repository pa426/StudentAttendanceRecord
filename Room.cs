using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentAttendanceRecord
{
    public class Room
    {

        private int roomId;

        public int RoomId
        {
            get { return roomId; }
            set { roomId = value; }
        }
        private string roomName;

        public string RoomName
        {
            get { return roomName; }
            set { roomName = value; }
        }
        private int roomCapacity;

        public int RoomCapacity
        {
            get { return roomCapacity; }
            set { roomCapacity = value; }
        }

        private string nameAndPlaces;

        public string NameAndPlaces
        {
            get { return nameAndPlaces; }
            set { nameAndPlaces = value; }
        }

        public Room(int rid, string rn, int rcap)
        {

            this.roomId = rid;
            this.roomName = rn;
            this.roomCapacity = rcap;
            this.nameAndPlaces = rn + " (" + rcap + ")";

        }

    }
}