using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

namespace StudentAttendanceRecord
{
    public partial class About : Page
    {

        private ArrayList xyz = new ArrayList();
        private List<Student> s = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                DropDownList1.DataSource = DBConn.GetCourse(int.Parse(Session["UserID"].ToString()));
                DropDownList1.DataTextField = "CourseName";
                DropDownList1.DataValueField = "CourseId";
                DropDownList1.DataBind();

                DropDownList2.DataSource = DBConn.GetStaffList();
                DropDownList2.DataTextField = "HoleName";
                DropDownList2.DataValueField = "StaffId";
                DropDownList2.DataBind();

                }
            

        }


        protected void Button1_Click(object sender, EventArgs e)
        {

            foreach (GridViewRow r in GridView1.Rows)
            {
         
                CheckBox cb = (CheckBox)r.FindControl("StudentSelector");
                if (cb != null && cb.Checked)
                {
                    int studentID = int.Parse(r.Cells[1].Text);
                    DBConn.UpdateCourseStudentList(int.Parse(DropDownList1.SelectedValue), studentID, int.Parse(RadioButtonList1.SelectedValue));
                    Session s = new Session(0, (DropDownList1.SelectedItem + " " + RadioButtonList1.SelectedItem.Text), studentID, int.Parse(DropDownList1.SelectedValue), int.Parse(DropDownList2.SelectedValue), int.Parse(CheckBoxList2.SelectedValue), DropDownList4.SelectedValue, DropDownList3.SelectedValue);
                    DBConn.InsertSession(s);
                }
            }
            Response.Redirect("ManageLists.aspx");
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedValue == "0")
            {
                CheckBoxList2.DataSource = DBConn.GetLectureRooms();
                CheckBoxList2.DataTextField = "NameAndPlaces";
                CheckBoxList2.DataValueField = "RoomId";
                CheckBoxList2.DataBind();
                s = DBConn.GetCourseStudentsList(int.Parse(DropDownList1.SelectedValue), 0);

            }
            else if (RadioButtonList1.SelectedValue == "1")
            {
                CheckBoxList2.DataSource = DBConn.GetLabRooms();
                CheckBoxList2.DataTextField = "NameAndPlaces";
                CheckBoxList2.DataValueField = "RoomId";
                CheckBoxList2.DataBind();
                s = DBConn.GetCourseStudentsList(int.Parse(DropDownList1.SelectedValue), 1);

            }
            else if (RadioButtonList1.SelectedValue == "2")
            {
                CheckBoxList2.DataSource = DBConn.GetLabRooms();
                CheckBoxList2.DataTextField = "NameAndPlaces";
                CheckBoxList2.DataValueField = "RoomId";
                CheckBoxList2.DataBind();
                s = DBConn.GetCourseStudentsList(int.Parse(DropDownList1.SelectedValue), 2);

            }



            DataTable dt = new DataTable();
            dt.Columns.Add("Student ID", typeof(int));
            dt.Columns.Add("Student Name", typeof(string));
            //BAGA STUDENT STATUS

            if (s != null)
            {
                foreach (var cl in s)
                {

                    DataRow row1 = dt.NewRow();
                    row1["Student ID"] = cl.StudentId;
                    row1["Student Name"] = cl.HoleName;
                    //BAGA STUDENT STATUS
                    dt.Rows.Add(row1);

                }
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();

        }
    }
}