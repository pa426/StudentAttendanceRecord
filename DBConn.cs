using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Odbc;

namespace StudentAttendanceRecord
{
    public class DBConn
    {

        private static OdbcConnection GetConnection()
        {
            string connString;
            //  change to your connection string in the following line
            connString = @"Driver={MySQL ODBC 5.3 ANSI Driver};server=mysql.cms.gre.ac.uk;user=pa426;password=159753.;database=mdb_pa426;option=3";
            return new OdbcConnection(connString);
        }

        public static string[] CheckStaff(string un)
        {//method used to chek a users detail

            OdbcConnection myConnection = GetConnection();
            string myQuery = " SELECT * FROM Staff where StaffUsername='" + un + "'";
            OdbcCommand myCommand = new OdbcCommand(myQuery, myConnection);

            string[] userDetails = new string[3];

            try
            {
                myConnection.Open();
                OdbcDataReader myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {

                    userDetails[0] = myReader["StaffPassword"].ToString();
                    userDetails[1] = myReader["StaffType"].ToString();
                    userDetails[2] = myReader["StaffID"].ToString();

                }
                return userDetails;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in DBHandler", ex);
                return null;
            }
            finally
            {
                myConnection.Close();
            }
        }

        public static string[] CheckStudent(string un)
        {//method used to chek a users detail

            OdbcConnection myConnection = GetConnection();
            string myQuery = " SELECT * FROM Student where StudentUsername='" + un + "'";
            OdbcCommand myCommand = new OdbcCommand(myQuery, myConnection);

            string[] userDetails = new string[3];

            try
            {
                myConnection.Open();
                OdbcDataReader myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {

                    userDetails[0] = myReader["StudentPassword"].ToString();
                    userDetails[1] = myReader["StudentID"].ToString();

                }
                return userDetails;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in DBHandler", ex);
                return null;
            }
            finally
            {
                myConnection.Close();
            }
        }


        public static List<Staff> GetStaffList()
        {
            List<Staff> attRecList = new List<Staff>();

            OdbcConnection myConnection = GetConnection();
            string myQuery = "SELECT * FROM Staff";
            OdbcCommand myCommand = new OdbcCommand(myQuery, myConnection);

            try
            {
                myConnection.Open();
                OdbcDataReader myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {

                    Staff a = new Staff( (int.Parse(myReader["StaffID"].ToString())), myReader["StaffName"].ToString(), myReader["StaffSurname"].ToString(), myReader["StaffPassword"].ToString(), (int.Parse(myReader["StaffType"].ToString())));
                    attRecList.Add(a);

                }
                return attRecList;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in DBHandler", ex);
                return null;
            }
            finally
            {
                myConnection.Close();
            }

        }

        public static List<Course> GetCourse(int sid)
        {
            List<Course> attRecList = new List<Course>();

            OdbcConnection myConnection = GetConnection();
            string myQuery = "SELECT * FROM Course where StaffID='" + sid + "'";
            OdbcCommand myCommand = new OdbcCommand(myQuery, myConnection);

            try
            {
                myConnection.Open();
                OdbcDataReader myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {

                    Course a = new Course((int.Parse(myReader["CourseID"].ToString())), myReader["CourseName"].ToString(), (int.Parse(myReader["StaffID"].ToString())), (int.Parse(myReader["CourseDuration"].ToString())));
                    attRecList.Add(a);

                }
                return attRecList;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in DBHandler", ex);
                return null;
            }
            finally
            {
                myConnection.Close();
            }

        }


        public static List<Session> GetStaffSession(int sId)
        {
            List<Session> attRecList = new List<Session>();

            OdbcConnection myConnection = GetConnection();
            string myQuery = "SELECT * FROM Session where StaffID='" + sId + "'";
            OdbcCommand myCommand = new OdbcCommand(myQuery, myConnection);

            try
            {
                myConnection.Open();
                OdbcDataReader myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {

                    Session a = new Session((int.Parse(myReader["SessionID"].ToString())), myReader["Name"].ToString(), (int.Parse(myReader["StudentID"].ToString())), (int.Parse(myReader["CourseID"].ToString())), (int.Parse(myReader["StaffID"].ToString())), (int.Parse(myReader["RoomID"].ToString())), myReader["Day"].ToString(), myReader["TimeSlot"].ToString());
                    attRecList.Add(a);

                }
                return attRecList;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in DBHandler", ex);
                return null;
            }
            finally
            {
                myConnection.Close();
            }

        }

        public static Session GetStudentSession(int sId, string name)
        {
            Session a = null;
            OdbcConnection myConnection = GetConnection();
            string myQuery = "SELECT * FROM Session where StudentID='" + sId + "' AND Name= '" + name + "'";
            OdbcCommand myCommand = new OdbcCommand(myQuery, myConnection);

            try
            {
                myConnection.Open();
                OdbcDataReader myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    a  = new Session((int.Parse(myReader["SessionID"].ToString())), myReader["Name"].ToString(), (int.Parse(myReader["StudentID"].ToString())), (int.Parse(myReader["CourseID"].ToString())), (int.Parse(myReader["StaffID"].ToString())), (int.Parse(myReader["RoomID"].ToString())), myReader["Day"].ToString(), myReader["TimeSlot"].ToString());
                }
                return a;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in DBHandler", ex);
                return null;
            }
            finally
            {
                myConnection.Close();
            }

        }


        public static List<Student> GetAllStudentsBySession(string name, int sid)
        {
            List<Student> allStudents = GetStudentsList();
            List<Student>  sl = new List<Student>();

            OdbcConnection myConnection = GetConnection();
            string myQuery = "SELECT * FROM Session where Name= '" + name + "' AND StaffID= '" + sid + "'";
            OdbcCommand myCommand = new OdbcCommand(myQuery, myConnection);

            try
            {
                myConnection.Open();
                OdbcDataReader myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    Student a = FindStudent(allStudents, (int.Parse(myReader["StudentID"].ToString()))); 
                    sl.Add(a);
                }
                return sl;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in DBHandler", ex);
                return null;
            }
            finally
            {
                myConnection.Close();
            }

        }

        public static List<Session> GetAllStudentSession( int sid)
        {
            List<Session> s = new List<Session>();
            OdbcConnection myConnection = GetConnection();
            string myQuery = "SELECT * FROM Session where StudentID='" + sid + "'";
            OdbcCommand myCommand = new OdbcCommand(myQuery, myConnection);

            try
            {
                myConnection.Open();
                OdbcDataReader myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    Session a = new Session((int.Parse(myReader["SessionID"].ToString())), myReader["Name"].ToString(), (int.Parse(myReader["StudentID"].ToString())), (int.Parse(myReader["CourseID"].ToString())), (int.Parse(myReader["StaffID"].ToString())), (int.Parse(myReader["RoomID"].ToString())), myReader["Day"].ToString(), myReader["TimeSlot"].ToString());
                    s.Add(a);
                }
                return s;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in DBHandler", ex);
                return null;
            }
            finally
            {
                myConnection.Close();
            }

        }


        public static List<Record> GetEventList(int sesid)
        {
            List<Record> attRecList = new List<Record>();
            OdbcConnection myConnection = GetConnection();
            string myQuery = "SELECT * FROM AttendanceRecord where SessionID='" + sesid + "'";
            OdbcCommand myCommand = new OdbcCommand(myQuery, myConnection);

            try
            {
                myConnection.Open();
                OdbcDataReader myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {

                    Record a = new Record(int.Parse(myReader["AttRecID"].ToString()), int.Parse(myReader["SessionID"].ToString()), int.Parse(myReader["WeekID"].ToString()), DateTime.Parse(myReader["EventDate"].ToString()));
                    attRecList.Add(a);

                }
                return attRecList;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in DBHandler", ex);
                return null;
            }
            finally
            {
                myConnection.Close();
            }

        }

        public static List<Student> GetStudentsList()
        {
            List<Student> attRecList = new List<Student>();

            OdbcConnection myConnection = GetConnection();
            string myQuery = "SELECT * FROM Student";
            OdbcCommand myCommand = new OdbcCommand(myQuery, myConnection);

            try
            {
                myConnection.Open();
                OdbcDataReader myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {

                    Student a = new Student((int.Parse(myReader["StudentID"].ToString())), myReader["StudentName"].ToString(), myReader["StudentSurname"].ToString(), myReader["StudentPassword"].ToString());
                    attRecList.Add(a);

                }
                return attRecList;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in DBHandler", ex);
                return null;
            }
            finally
            {
                myConnection.Close();
            }

        }


       

        private static Student FindStudent(List<Student> st, int id)
        {//Method used to find teachers name
            foreach (var s in st)
            {
                if (s.StudentId == id)
                {
                    return s;
                }
            }
            return null;
        }

         public static List<Student> GetCourseStudentsList(int cid, int ctype)
        {
            List<Student> allStudents = GetStudentsList();
            List<Student> attRecList = new List<Student>();

            OdbcConnection myConnection = GetConnection();
            string myQuery = "";

            if (ctype == 0)
            {  
                myQuery = "SELECT * FROM CourseStudentList where CourseID='" + cid + "' AND LectureAssignmentStatus='" + 0 + "'";
            }
            else if (ctype == 1)
            {
                myQuery = "SELECT * FROM CourseStudentList where CourseID='" + cid + "' AND LaboratoryAssignmentStatus='" + 0 + "'";
            }
            else if (ctype == 2)
            {
                myQuery =  "SELECT * FROM CourseStudentList where CourseID='" + cid + "' AND TutorialAssignmentStatus='" + 0 + "'"; 
            }
            OdbcCommand myCommand = new OdbcCommand(myQuery, myConnection);

            try
            {
                myConnection.Open();
                OdbcDataReader myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {

                    Student a = FindStudent(allStudents, (int.Parse(myReader["StudentID"].ToString())));
                    attRecList.Add(a);

                }
                return attRecList;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in DBHandler", ex);
                return null;
            }
            finally
            {
                myConnection.Close();
            }

        }

         public static List<Student> GetTemporaryStudentsList(int cid)
         {
             List<Student> allStudents = GetStudentsList();
             List<Student> attRecList = new List<Student>();

             OdbcConnection myConnection = GetConnection();
             string myQuery = "";


             myQuery = "SELECT * FROM CourseStudentList where RegStatus='" + "Temporary" + "' AND CourseID='"+ cid +"'";
            
             OdbcCommand myCommand = new OdbcCommand(myQuery, myConnection);

             try
             {
                 myConnection.Open();
                 OdbcDataReader myReader = myCommand.ExecuteReader();

                 while (myReader.Read())
                 {

                     Student a = FindStudent(allStudents, (int.Parse(myReader["StudentID"].ToString())));
                     attRecList.Add(a);

                 }
                 return attRecList;
             }
             catch (Exception ex)
             {
                 Console.WriteLine("Exception in DBHandler", ex);
                 return null;
             }
             finally
             {
                 myConnection.Close();
             }

         }

         public static List<Room> GetLectureRooms()
         {

             List<Room> attRecList = new List<Room>();

             OdbcConnection myConnection = GetConnection();
             string myQuery = "SELECT * FROM Room where RoomCapacity >= '30'";
             OdbcCommand myCommand = new OdbcCommand(myQuery, myConnection);

             try
             {
                 myConnection.Open();
                 OdbcDataReader myReader = myCommand.ExecuteReader();

                 while (myReader.Read())
                 {

                     Room a = new Room((int.Parse(myReader["RoomID"].ToString())), myReader["RoomName"].ToString(), (int.Parse(myReader["RoomCapacity"].ToString())));
                     attRecList.Add(a);

                 }
                 return attRecList;
             }
             catch (Exception ex)
             {
                 Console.WriteLine("Exception in DBHandler", ex);
                 return null;
             }
             finally
             {
                 myConnection.Close();
             }

         }

            

         public static List<Room> GetLabRooms()
         {

             List<Room> attRecList = new List<Room>();

             OdbcConnection myConnection = GetConnection();
             string myQuery = "SELECT * FROM Room where RoomCapacity <= '30'";
             OdbcCommand myCommand = new OdbcCommand(myQuery, myConnection);

             try
             {
                 myConnection.Open();
                 OdbcDataReader myReader = myCommand.ExecuteReader();

                 while (myReader.Read())
                 {

                     Room a = new Room((int.Parse(myReader["RoomID"].ToString())), myReader["RoomName"].ToString(), (int.Parse(myReader["RoomCapacity"].ToString())));
                     attRecList.Add(a);

                 }
                 return attRecList;
             }
             catch (Exception ex)
             {
                 Console.WriteLine("Exception in DBHandler", ex);
                 return null;
             }
             finally
             {
                 myConnection.Close();
             }

         }

         public static Course GetCourseByName(string cname)
         {

             Course cyz = null;

             OdbcConnection myConnection = GetConnection();
             string myQuery = "SELECT * FROM Course WHERE CourseName ='" + cname + "'";
             OdbcCommand myCommand = new OdbcCommand(myQuery, myConnection);

             try
             {
                 myConnection.Open();
                 OdbcDataReader myReader = myCommand.ExecuteReader();

                 while (myReader.Read())
                 {

                     cyz = new Course(int.Parse(myReader["CourseID"].ToString()), myReader["CourseName"].ToString(), int.Parse(myReader["StaffID"].ToString()), int.Parse(myReader["CourseDuration"].ToString()));

                 }
                 return cyz;
             }
             catch (Exception ex)
             {
                 Console.WriteLine("Exception in DBHandler", ex);
                 return null;
             }
             finally
             {
                 myConnection.Close();
             }

         }

         public static List<Week> GetWeeks()
         {

             List<Week> attRecList = new List<Week>();

             OdbcConnection myConnection = GetConnection();
             string myQuery = "SELECT * FROM Week ORDER BY WeekStarting ASC";
             OdbcCommand myCommand = new OdbcCommand(myQuery, myConnection);

             try
             {
                 myConnection.Open();
                 OdbcDataReader myReader = myCommand.ExecuteReader();

                 while (myReader.Read())
                 {

                     Week a = new Week((int.Parse(myReader["WeekID"].ToString())), myReader["WeekName"].ToString(), Convert.ToDateTime(myReader["WeekStarting"].ToString()), Convert.ToDateTime(myReader["WeekEnding"].ToString()));
                     attRecList.Add(a);

                 }
                 return attRecList;
             }
             catch (Exception ex)
             {
                 Console.WriteLine("Exception in DBHandler", ex);
                 return null;
             }
             finally
             {
                 myConnection.Close();
             }

         }

         public static void UpdateCourseStudentList(int cId , int sId, int cType)
         {

             OdbcConnection myConnection = GetConnection();
             string myQuery="";

             if (cType == 0)
             {
                 myQuery = "UPDATE  CourseStudentList SET LectureAssignmentStatus=1 WHERE CourseID = " + cId + " AND StudentID = " + sId + " ;";
             }
             else if (cType == 1)
             {
                 myQuery = "UPDATE  CourseStudentList SET 	LaboratoryAssignmentStatus=1 WHERE CourseID = " + cId + " AND StudentID = " + sId +" ;";
             }
             else if (cType == 2)
             {
                 myQuery = "UPDATE  CourseStudentList SET TutorialAssignmentStatus=1 WHERE CourseID = " + cId + " AND StudentID = " + sId + " ;";
             }
            
             OdbcCommand myCommand = new OdbcCommand(myQuery, myConnection);

             try
             {
                 myConnection.Open();
                 myCommand.ExecuteNonQuery();
             }
             catch (Exception ex)
             {
                 Console.WriteLine("Exception in DBHandler", ex);
             }
             finally
             {
                 myConnection.Close();
             }

         }

        public static void InsertSession(Session s)
        {

            OdbcConnection myConnection = GetConnection();
            string myQuery = " INSERT INTO Session (Name, StudentID, CourseID, StaffID, RoomID, Day, TimeSlot) VALUES ( '" + s.SessionName + "' ,  " + s.StudentId + ",  " + s.CourseId + ",  " + s.StaffId + ", " + s.RoomId + ", '" + s.Day + "', '" + s.TimeSlot + "');";
            OdbcCommand myCommand = new OdbcCommand(myQuery, myConnection);

            try
            {
                myConnection.Open();
                myCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in DBHandler", ex);
            }
            finally
            {
                myConnection.Close();
            }
        
        }

        public static void InsertWeek(Week w)
        {

            OdbcConnection myConnection = GetConnection();
            string format = "yyyy-MM-dd HH:MM:ss";
            string myQuery = " INSERT INTO Week (WeekName, WeekStarting, WeekEnding) VALUES ( '" + w.WeekName + "', '" + w.Start.ToString(format) + "', '" + w.End.ToString(format) + "');";
            OdbcCommand myCommand = new OdbcCommand(myQuery, myConnection);

            try
            {
                myConnection.Open();
                myCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in DBHandler", ex);
            }
            finally
            {
                myConnection.Close();
            }

        }

            public static void InsertRecord(Record r)
        {

            OdbcConnection myConnection = GetConnection();
            string myQuery = " INSERT INTO AttendanceRecord (SessionID, WeekID) VALUES ( " + r.SessionId + ", '" + r.WeekId + "');";
            OdbcCommand myCommand = new OdbcCommand(myQuery, myConnection);

            try
            {
                myConnection.Open();
                myCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in DBHandler", ex);
            }
            finally
            {
                myConnection.Close();
            }
        
        }


            public static void InsertCourseStudentList(int cid, int sid)
            {

                OdbcConnection myConnection = GetConnection();
                string myQuery = " INSERT INTO CourseStudentList (CourseID, StudentID, LectureAssignmentStatus, LaboratoryAssignmentStatus, TutorialAssignmentStatus, RegStatus) VALUES ( " + cid + " ,  " + sid + ",  " + 0 + ",  " + 0 + ", " + 0 + ", '" + "Temporary" +"');";
                OdbcCommand myCommand = new OdbcCommand(myQuery, myConnection);

                try
                {
                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception in DBHandler", ex);
                }
                finally
                {
                    myConnection.Close();
                }

            }

            public static void InsertStudentList(int cid, int sid)
            {

                OdbcConnection myConnection = GetConnection();
                string myQuery = " INSERT INTO CourseStudentList (CourseID, StudentID, LectureAssignmentStatus, LaboratoryAssignmentStatus, TutorialAssignmentStatus, RegStatus) VALUES ( " + cid + " ,  " + sid + ",  " + 0 + ",  " + 0 + ", " + 0 + ", '" + "Permanent" + "');";
                OdbcCommand myCommand = new OdbcCommand(myQuery, myConnection);

                try
                {
                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception in DBHandler", ex);
                }
                finally
                {
                    myConnection.Close();
                }

            }


            public static void InsertCourse(Course c)
            {

                OdbcConnection myConnection = GetConnection();
                string myQuery = " INSERT INTO Course (CourseName, StaffID, CourseDuration) VALUES ( '" + c.CourseName + "' ,  " + c.StaffId + ",  " + c.CourseDuration + ");";
                OdbcCommand myCommand = new OdbcCommand(myQuery, myConnection);

                try
                {
                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception in DBHandler", ex);
                }
                finally
                {
                    myConnection.Close();
                }

            }


            public static void UpdateCourseStudentList(int cId, int sId)
            {

                OdbcConnection myConnection = GetConnection();
                string myQuery = "";


                    myQuery = "UPDATE  CourseStudentList SET RegStatus='Registered' WHERE CourseID = " + cId + " AND StudentID = " + sId + " ;";
             

                OdbcCommand myCommand = new OdbcCommand(myQuery, myConnection);

                try
                {
                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception in DBHandler", ex);
                }
                finally
                {
                    myConnection.Close();
                }

            }

        }

    
}