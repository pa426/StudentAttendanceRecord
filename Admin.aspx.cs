using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentAttendanceRecord
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DropDownList1.DataSource = DBConn.GetStaffList();
            DropDownList1.DataTextField = "HoleName";
            DropDownList1.DataValueField = "StaffId";
            DropDownList1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Course c = new Course(0, TextBox1.Text, int.Parse(DropDownList1.SelectedValue), int.Parse(RadioButtonList1.SelectedValue));
            DBConn.InsertCourse(c);
            Course x = DBConn.GetCourseByName(TextBox1.Text);

            FileUpload fu = FileUpload1;
            if (fu.HasFile)
            {
                StreamReader reader = new StreamReader(fu.FileContent);
                do
                {
                        string textLine = reader.ReadLine();
                        string[] words;
                        words = textLine.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries);
                        DBConn.InsertStudentList(x.CourseId, int.Parse(words[2]));

                } while (reader.Peek() != -1);
                reader.Close();
            }


        }


    }
}