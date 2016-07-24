using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentAttendanceRecord
{
    public partial class _Default : Page
    {

        private string password;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            password = TextBox2.Text;
            string[] userDetails;
            

            if (CheckBoxList1.SelectedValue == "0")
            {
                 userDetails = DBConn.CheckStaff(TextBox1.Text);
                 Singleton single = Singleton.Instance;
                 if (single.CheckPassword(password,userDetails[0]))
                 {
                     Session["UsernameLogin"] = TextBox1.Text;
                     Session["UserType"] = userDetails[1];
                     Session["UserID"] = userDetails[2];
                     ScriptManager.RegisterStartupScript(this, GetType(), "Welcome", "confirm('Welcome back  " + TextBox1.Text + " !');", true);
                    
                 }
                 else
                 {
                     ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Please insert a valid username or password!');", true);
                 }

            }
            else if (CheckBoxList1.SelectedValue == "1")
            {
                 userDetails = DBConn.CheckStudent(TextBox1.Text);
                 Singleton single = Singleton.Instance;
                 if (single.CheckPassword(password, userDetails[0]))
                 {
                     Session["UsernameLogin"] = TextBox1.Text;
                     Session["UserType"] = 2;
                     Session["UserID"] = userDetails[1];
                     ScriptManager.RegisterStartupScript(this, GetType(), "Welcome", "confirm('Welcome back  " + TextBox1.Text + " !');", true);
                 }
                 else
                 {
                     ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Please insert a valid username or password!');", true);
                 }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Please select a user type!');", true);
            }

            if (Session["UsernameLogin"] != null && Session["UserType"] != null)
            {
                if (Session["UserType"].ToString() == "0")
                {
                    Response.Redirect("ManageLists.aspx");
                }
                else if (Session["UserType"].ToString() == "1")
                {
                    Response.Redirect("PrintList.aspx");
                }
                else if (Session["UserType"].ToString() == "2")
                {
                    Response.Redirect("CheckAttendance.aspx");
                }
                else if (Session["UserType"].ToString() == "3")
                {
                    Response.Redirect("Admin.aspx");
                }
            }
           
        }
    }
}