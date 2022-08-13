using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UAS
{
    public partial class contactUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Thread mailThread = StartTheThread(txtEmail.Text, "", txtComment.Text);
            Response.Write("<script>alert('Message Sent!');</script>");
            txtEmail.Text = "";
            txtComment.Text = "";
            txtName.Text = "";
        }
        public Thread StartTheThread(string to, string sbjct, string msg)
        {
            var t = new Thread(() => CommonClass.sendTheMsgForOTP(msg, sbjct, to));
            t.Start();
            return t;
        }
    }
}