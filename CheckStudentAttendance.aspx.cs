using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace StudentAttendanceRecord
{
    public partial class CheckStudentAttendance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Label2.Visible = true;
            DropDownList1.Visible = true;
            

            if (!Page.IsPostBack)
            {
                Label2.Visible = false;
                DropDownList1.Visible = false;
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


        protected void Button1_Click(object sender, EventArgs e)
        {
            int sid = int.Parse(TextBox1.Text);
            DropDownList1.DataSource = DBConn.GetAllStudentSession(sid);
            DropDownList1.DataTextField = "SessionName";
            DropDownList1.DataValueField = "SessionId";
            DropDownList1.DataBind();

        }

    }

    

}