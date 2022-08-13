using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UAS
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // for back button
                if (CommonClass.currentPage != HttpContext.Current.Request.Url.AbsoluteUri)
                {
                    CommonClass.previousPage = CommonClass.currentPage;
                    CommonClass.currentPage = HttpContext.Current.Request.Url.AbsoluteUri;
                }
                back.HRef = CommonClass.previousPage;
                // end back button
                // profileLink.Visible = false;
                if (Session["admin"] != null) //not logged in
                {
                    if (Session["admin"].ToString() == "1234")
                    {
                        logout.Visible = true;
                        signUp.Visible = false;
                        signIn.Visible = false;

                        userName.InnerHtml = "Admin";
                        userName.HRef = "adminCourse.aspx";
                        userName.Visible = true;

                        System.Diagnostics.Debug.WriteLine(CommonClass.currentPage);
                        if (CommonClass.currentPage == "https://localhost:44342/adminQue.aspx")
                        {
                            adminQue.Visible = false;
                        }
                        else
                        {
                            adminQue.Visible = true;
                        }
                        if (CommonClass.currentPage == "https://localhost:44342/adminTeacherControl.aspx")
                        {
                            adminTeacherControl.Visible = false;
                        }
                        else
                        {
                            adminTeacherControl.Visible = true;
                        }
                        if (CommonClass.currentPage == "https://localhost:44342/adminStudentControl.aspx")
                        {
                            adminStudentControl.Visible = false;
                        }
                        else
                        {
                            adminStudentControl.Visible = true;
                        }
                        if (CommonClass.currentPage == "https://localhost:44342/adminTckts.aspx")
                        {


                        }
                        else
                        {

                        }
                    }
                }
                else
                {
                    adminStudentControl.Visible = false;
                    adminTeacherControl.Visible = false;
                    adminQue.Visible = false;
                    adminUni.Visible = false;
                    adminCourse.Visible = false;

                    if (Session["points"] != null) //set username
                    {
                        lblPointsTotal.Text = Session["points"].ToString();
                    }
                    else
                    {
                        lblPointsTotal.Text = "0";
                    }
                    if (Session["id"] == null && Session["sid"] == null) //not logged in
                    {
                        logout.Visible = false;
                        signIn.Visible = true;
                        signUp.Visible = true;
                        // profileLink.Visible = false;

                    }
                    else //logged in
                    {
                        if(Session["id"] != null)
                        {
                            aHome.HRef = "teacherIndex.aspx";
                        }
                        logout.Visible = true;
                        signUp.Visible = false;
                        signIn.Visible = false;
                        // profileLink.Visible = true; 

                        if (Session["username"] != null) //set username
                        {
                            userName.InnerHtml = Session["username"].ToString();
                            userName.Visible = true;
                        }
                        if (Session["profileImage"] != null) //set Profile picture
                        {
                            if (Session["profileImage"].ToString() != "")
                            {
                                System.Diagnostics.Debug.WriteLine("omg:" + Session["profileImage"]);
                                profileImage.ImageUrl = "data:Image/png;base64," + Session["profileImage"];
                                //Eval("picture=" + Session["profileImage"]);
                            }
                            else
                            {
                                profileImage.ImageUrl = "image/noimg.png";
                            }
                            profileImage.Visible = true;
                        }
                    }
                }
            }
        }

        protected void footerEmailBtn_Click(object sender, EventArgs e)
        {
            if (CommonClass.checkTheDatabase())
            {
                try
                {
                    string to = footerEmail.Value.Trim();

                    if (Validate.ValidEmail(to))
                    {
                        if (!Validate.EmailExists(to))
                        {
                            //database

                            SqlConnection con = new SqlConnection(CommonClass.strcon);
                            if (con.State == ConnectionState.Closed) con.Open();

                            String qur = "If Not Exists(select * from subscriberTab where mail=@mail) Begin insert into subscriberTab (mail) values (@mail) End";
                            SqlCommand cmd = new SqlCommand(qur, con);

                            //cmd.Parameters.AddWithValue("@subscriber_id", jobTitle.Text.Trim());

                            cmd.Parameters.AddWithValue("@mail", to);

                            cmd.ExecuteNonQuery();
                            con.Close();

                            string sub = "Subscribe to AB proj";
                            string body = "Thank you for subscribing.<br><br>";
                            Thread mailThread = StartTheThread(body, sub, to);

                            //mail.sendMail(to);


                            footerEmail.Value = string.Empty;
                            Response.Write("<script>alert('Subscription successful!');</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('You are already a subscriber!');</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid email address');</script>");
                    }
                }

                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Redirect("error.aspx");
            }
        }

        public Thread StartTheThread(string body, string sub, string to)
        {
            // var t = new Thread(() => sendMail(to));
            var t = new Thread(() => CommonClass.sendTheMsgForOTP(body, sub, to));
            t.Start();
            return t;
        }

        protected void profileImage_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("UserProfilePage.aspx");
        }

        protected void lnkbtnAdminTcks_Click(object sender, EventArgs e)
        {

        }
    }
}