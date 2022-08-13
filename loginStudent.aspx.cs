using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UAS
{
    public partial class loginStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            if (CommonClass.checkTheDatabase())
            {
                userLogin();
            }
            else
            {
                messageLable2.ForeColor = System.Drawing.Color.Red;
                if (messageLable2.Visible == true) Response.Redirect("error.aspx");
                else
                    messageLable2.Visible = true;
            }
        }

        void userLogin()
        {
            SqlConnection con = new SqlConnection(CommonClass.strcon);
            try
            {
                // SqlConnection con = new SqlConnection(commonClass.strcon);
                if (con.State == ConnectionState.Closed) con.Open();

                String qur = "select s_id,s_name,s_mail,s_img from student where s_mail='" + loginemail.Text.Trim() + "' and s_password='" + CommonClass.encrypt(loginpassword.Text.Trim()) + "';";
                //String qur = "select id,FName,Email,Status,LoginAttempt from Users_Tab where Email='" + loginemail.Text.Trim() + "' and Password='" + loginpassword.Text.Trim() + "';";
                SqlCommand cmd = new SqlCommand(qur, con);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        Session["username"] = dr.GetValue(1).ToString();

                        Session["sid"] = dr.GetValue(0).ToString();
                        System.Diagnostics.Debug.WriteLine(Session["sid"].ToString());

                        //Set Profile picture 
                        if (dr.GetValue(3) != DBNull.Value)
                        {
                            System.Diagnostics.Debug.WriteLine(dr.GetValue(3).ToString());
                            byte[] bytes = (byte[])dr.GetValue(3);
                            System.Diagnostics.Debug.WriteLine(bytes);
                            string strBase64 = Convert.ToBase64String(bytes);
                            Session["profileImage"] = strBase64;
                        }
                    }
                    Response.Redirect("index.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Invalid user');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
            finally
            {
                con.Close();
            }
        }
    }
}