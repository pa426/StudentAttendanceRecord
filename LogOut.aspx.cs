using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentAttendanceRecord
{
    public partial class LogOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["UsernameLogin"] = null;
            Session["UserType"] = null;
            Session["UserID"] = null;
            Response.Redirect("Default.aspx");
        }
    }
}