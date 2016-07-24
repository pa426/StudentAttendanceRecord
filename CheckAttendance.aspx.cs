using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace StudentAttendanceRecord
{
    public partial class CheckAttendance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                if (Session["UserID"] != null)
                {
                DropDownList1.DataSource = DBConn.GetAllStudentSession(int.Parse(Session["UserID"].ToString())); 
                DropDownList1.DataTextField = "SessionName";
                DropDownList1.DataValueField = "SessionId";
                DropDownList1.DataBind();

                }
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            List<Week> weeks = DBConn.GetWeeks();

            if (weeks != null)
            {

                DataTable dt = new DataTable();


                foreach (Week w in weeks)
                {
                    dt.Columns.Add(w.WeekName, typeof(string));
                }


                DataRow row1 = dt.NewRow();
                List<Record> records = DBConn.GetEventList(int.Parse(DropDownList1.SelectedValue));

                foreach (Week w in weeks)
                {

                    bool test = false;

                    if (records != null)
                    {
                        foreach (Record r in records)
                        {
                            if (r.WeekId == w.WeekId)
                            {
                                test = true;
                            }
                        }

                        if (test == true)
                        {
                            row1[w.WeekName] = "✓";
                        }
                        else
                        {
                            row1[w.WeekName] = "x";
                        }
                    }

                }

                dt.Rows.Add(row1);
                GridView1.DataSource = dt;
                GridView1.DataBind();

            }
           
        }




    }
}