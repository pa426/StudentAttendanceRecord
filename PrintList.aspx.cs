using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using System.IO;


namespace StudentAttendanceRecord
{
    public partial class PrintList : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Button1.Visible = false;
            Button2.Visible = false;
            FileUpload1.Visible = false;
            Button3.Visible = false;
            DropDownList2.Visible = false;
            Label6.Visible = false;

            if (!Page.IsPostBack)
            {
                List<Session> ses = DBConn.GetStaffSession(int.Parse(Session["UserID"].ToString()));

                var distinctList = ses.GroupBy(i => i.SessionName).Select(g => g.First()).ToList();

                    DropDownList1.DataSource = distinctList;
                    DropDownList1.DataTextField = "SessionName";
                    DropDownList1.DataValueField = "CourseId";
                    DropDownList1.DataBind();
              

                Label5.Text = "Student Attendence Record for " + DropDownList1.SelectedItem.ToString() + " on " + DateTime.Now.ToString("ddd d MMM yyyy",
                      CultureInfo.CreateSpecificCulture("en-US"));

                List<Week> weeks = DBConn.GetWeeks();

                DropDownList2.DataSource = weeks;
                DropDownList2.DataTextField = "WeekNameDate";
                DropDownList2.DataValueField = "WeekId";
                DropDownList2.DataBind();

                string format = "yyyy-MM-dd HH:MM:ss";
                string x = DateTime.Now.ToString(format);
                DateTime now = Convert.ToDateTime(x);
                foreach (Week w in weeks)
                {
                    if (now.Date < w.End.Date && now.Date > w.Start.Date)
                    {
                        DropDownList2.SelectedValue = w.WeekId.ToString();
                    }
                } 
            }

            if (RadioButtonList1.SelectedValue == "0")
            {

                Button1.Visible = true;
                Button2.Visible = false;
                FileUpload1.Visible = true;
                Button3.Visible = true;
                DropDownList2.Visible = true;
                Label6.Visible = true;

            }
            else if (RadioButtonList1.SelectedValue == "1")
            {

                Button1.Visible = false;
                Button2.Visible = true;
                Label5.Visible = true;

            }
          

        }



        protected void Button2_Click(object sender, EventArgs e)
        {
            Button2.Visible = false;
            Session["ctrl"] = pnl1;
            ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('Print.aspx','PrintMe','height=595px,width=842px,scrollbars=1');</script>");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

            FileUpload fu = FileUpload1;
            if (fu.HasFile)
            {
                int i =0;
                StreamReader reader = new StreamReader(fu.FileContent);
                do
                {
                    if (i != 0)
                    {
                        string textLine = reader.ReadLine();
                        string[] words;
                        words = textLine.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries);

                        foreach (GridViewRow r in GridView1.Rows)
                        {
                            if (r.Cells[2].Text == words[0] + " " + words[1] && words[2] == "1")
                            {
                                CheckBox cb = (CheckBox)r.FindControl("StudentSelector");
                                cb.Visible = true;
                                cb.Checked = true;
                                Button1.Visible = true;
                            }
                        }
                    }
                    i++;
                } while (reader.Peek() != -1);
                reader.Close();
            }


        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            List<Student> s = DBConn.GetAllStudentsBySession(DropDownList1.SelectedItem.ToString(), int.Parse(Session["UserID"].ToString()));
            DataTable dt = new DataTable();
            dt.Columns.Add("Student ID", typeof(int));
            dt.Columns.Add("Student Name", typeof(string));

            if (RadioButtonList1.SelectedValue == "0")
            {
                //dt.Columns.Add("Student Status", typeof(string));
            }
            else
            {
                dt.Columns.Add("Student Signature", typeof(string));
            }

            if (s != null)
            {
                foreach (var cl in s)
                {

                    DataRow row1 = dt.NewRow();
                    row1["Student ID"] = cl.StudentId;
                    row1["Student Name"] = cl.HoleName;
                    if (RadioButtonList1.SelectedValue == "0")
                    {
                        //row1["Student Status"] = cl.StudentRegStatus;
                    }

                    dt.Rows.Add(row1);

                }
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
             foreach (GridViewRow r in GridView1.Rows)
            {
                CheckBox cbc = (CheckBox)r.FindControl("StudentSelector");
                if (cbc != null && cbc.Checked)
                {
                    int studentID = int.Parse(r.Cells[1].Text);
                    Session s = DBConn.GetStudentSession(studentID, DropDownList1.SelectedItem.ToString());
                    Record rec = new Record(0, s.SessionId , int.Parse(DropDownList2.SelectedValue.ToString()), DateTime.Now );
                    DBConn.InsertRecord(rec);
  
                }
            } 

        }


        private void PopulateWeek()
        {
            DateTime start = new DateTime(2015, 09, 28, 12, 00, 00);
            DateTime end = new DateTime(2015, 10, 04, 12, 00, 00);

            for (int i = 0; i < 35; i++)
            {
                DateTime addStart = start.AddDays(7 * i);
                DateTime addEnd = end.AddDays(7 * i);
                Week w = new Week(0, ("Week " + (i + 1)), addStart, addEnd);
                DBConn.InsertWeek(w);
            }

        }
    }
}