using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UAS
{
    public partial class adminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void AdminLogin(object sender, EventArgs e)
        {
            try
            {
                if (UserName.Text == "Admin" && Password.Text == "Admin")
                {
                    Session["admin"] = "1234";
                    Response.Redirect("adminIndex.aspx");
                }

                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Wrong Email or Password');", true);
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Something Went Wrong With Admin Login');", true);

            }
        }
    }
}