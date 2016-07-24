using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentAttendanceRecord
{
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var testDiv0 = LoginView1.FindControl("logoutLink");
            var testDiv2 = FindControl("ManageListLink");
            var testDiv3 = FindControl("PrintListLink");
            var testDiv4 = FindControl("CheckAttendanceLink");
            var testDiv5 = FindControl("CheckStudentAttendanceLink");

            testDiv0.Visible = false;
            testDiv2.Visible = false;
            testDiv3.Visible = false;
            testDiv4.Visible = false;
            testDiv5.Visible = false;

            if (Session["UsernameLogin"] != null && Session["UserType"] != null)
            {
                usernameLabel.Text = "Welcome back: " + Session["UsernameLogin"].ToString();
                testDiv0.Visible = true;

                if (Session["UserType"].ToString() == "0")
                {
                    testDiv2.Visible = true;
                    testDiv3.Visible = true;
                    testDiv4.Visible = false;
                    testDiv5.Visible = true;
                }
                else if (Session["UserType"].ToString() == "1")
                {
                    testDiv2.Visible = false;
                    testDiv3.Visible = true;
                    testDiv4.Visible = false;
                    testDiv5.Visible = true;
                }
                else if (Session["UserType"].ToString() == "2")
                {
                    testDiv2.Visible = false;
                    testDiv3.Visible = false;
                    testDiv4.Visible = true;
                    testDiv5.Visible = false;
                }
                else if (Session["UserType"].ToString() == "3")
                {
                    testDiv2.Visible = false;
                    testDiv3.Visible = false;
                    testDiv4.Visible = false;
                    testDiv5.Visible = false;
                }
            }
          
        }
    }
}