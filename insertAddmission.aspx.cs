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
    public partial class insertAddmission : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uId"] == null) //not logged in
            {
                Response.Redirect("adminUniList.aspx");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(Session["uId"].ToString());
                Label1.Text = Session["uId"].ToString();
            }

        }

        protected void btnsignup_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(CommonClass.strcon);
            try
            {
             
                //SqlConnection con = new SqlConnection(commonClass.strcon);
                if (con.State == ConnectionState.Closed) con.Open();


                String qur = "insert into addmisson (addmisson_season, deadline, exam_date, course, phone, u_id) values (@addmisson_season, @deadline, @exam_date, @course, @phone, @u_id )";
                qur += "";
                SqlCommand cmd = new SqlCommand(qur, con);
                System.Diagnostics.Debug.WriteLine(qur);
                cmd.Parameters.AddWithValue("@addmisson_season", txtaddss.Text.Trim());
                //    cmd.Parameters.AddWithValue("@status", "pending");
                string[] ar = applicationDeadline.Text.Trim().Split(' ');
                if (ar[0] == String.Empty)
                {
                    //ar[0] = String.Empty;

                    cmd.Parameters.AddWithValue("@deadline", DBNull.Value);

                }
                else
                {
                    int year = Convert.ToInt32(ar[0].Split('-')[0]);
                    int day = Convert.ToInt32(ar[0].Split('-')[2]);
                    int month = Convert.ToInt32(ar[0].Split('-')[1]);
                    DateTime dtOld = new DateTime(year, month, day);
                    string newDate = dtOld.ToString("MM/dd/yyyy hh:mm:ss tt").Replace('-', '/');


                    cmd.Parameters.AddWithValue("@deadline", newDate);
                }
                string[] ar1 = txtExamDate.Text.Trim().Split(' ');
                if (ar1[0] == String.Empty)
                {
                    //ar[0] = String.Empty;

                    cmd.Parameters.AddWithValue("@exam_date", DBNull.Value);

                }
                else
                {
                    int year = Convert.ToInt32(ar1[0].Split('-')[0]);
                    int day = Convert.ToInt32(ar1[0].Split('-')[2]);
                    int month = Convert.ToInt32(ar1[0].Split('-')[1]);
                    DateTime dtOld = new DateTime(year, month, day);
                    string newDate = dtOld.ToString("MM/dd/yyyy hh:mm:ss tt").Replace('-', '/');


                    cmd.Parameters.AddWithValue("@exam_date", newDate);
                }

             
                
                    cmd.Parameters.AddWithValue("@course", departement.SelectedItem.Value);
            

                    cmd.Parameters.AddWithValue("@phone", phone.Text.Trim());
                


                cmd.Parameters.AddWithValue("@u_id", Session["uId"]);
              

               


                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('successful!');</script>");


                // if (flag) loadTheJobTypes();
                // clearTheForm();

                Response.Redirect("uAdmisson.aspx");



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