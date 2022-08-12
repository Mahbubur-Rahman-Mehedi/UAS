using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UAS
{
    public partial class teacherRegistration : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(CommonClass.strcon);


        protected void UserInfoSubmit(object sender, EventArgs e)
        {
            try
            {
                //check email pattern regex
                //check  password pattern regex
                //

                if (FirstName.Text != null &&
                    DropDownGender != null && EmailAddress.Text != null && ContactNo.Text != null &&
                    Password.Text != null)
                {
                    String EmailID = EmailAddress.Text;

                    con.Open();

                    String findMatchEmail = "select * from teacher where" +
                        " t_mail='" + EmailID + "'";

                    SqlCommand sqlCommand = new SqlCommand(findMatchEmail, con);

                    SqlDataReader dr = sqlCommand.ExecuteReader();

                    if (dr.Read())
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(),
                            "script", "alert('Email Already Exists');", true);
                        con.Close();

                    }
                    else
                    {
                        sqlCommand.Dispose();
                        dr.Close();
                        con.Close();
                        con.Open();
                        

                        // String filename = FileUpload1.PostedFile.FileName;
                        //String filepath = "App_Data/" + Path.GetFileName(ImageUpload.FileName);
                        //ImageUpload.PostedFile.SaveAs(Server.MapPath("~/App_data/") +
                        //    Path.GetFileName(ImageUpload.FileName));
                        //store the image directly to database

                        //String userInfo = "insert into teacher values('" + FirstName.Text +

                        //    "','" + LastName.Text + "','" + EmailAddress.Text + "','" + ContactNo.Text +

                        //    "','" + Residence.Text + "','" + Password.Text + "','" +

                        //    DropDownGender.SelectedValue + "','" + DOB.Text + "','" +

                        //    Status.Text + "','" + null + "','" + null +

                        //    "','" + filepath + "')";

                        //SqlCommand comm = new SqlCommand(userInfo, con);

                        //comm.ExecuteNonQuery();
                        String password = Password.Text;
                        password = CommonClass.encrypt(password);
                        string qur = "insert into teacher (t_name, t_password, t_phone, t_mail, t_gender, study_background";
                        byte[] pic = { };
                        if (ImageUpload.HasFile)
                        {
                            int length = ImageUpload.PostedFile.ContentLength;
                            pic = new byte[length];
                            ImageUpload.PostedFile.InputStream.Read(pic, 0, length);
                            qur += ",t_img";
                        }
                        qur +=" ) " +
                            "values (";
                            //"values ('@name', '@password', @phone, @mail, '@gender', '@sb')";
                        qur +="'"+FirstName.Text+"',";
                        qur +="'"+ password +"',";
                        qur += ContactNo.Text+",";
                        qur +="'"+ EmailAddress.Text+"',";
                        qur +="'"+ DropDownGender.SelectedValue+"',";
                        qur += "'" + sb.Text+"'";
                        
                        if (ImageUpload.HasFile)
                        {
                            qur+=",'@pic'";
                        }
                        qur += ")";
                        System.Diagnostics.Debug.WriteLine(qur);

                        SqlCommand cmd = new SqlCommand(qur, con);
                        if (ImageUpload.HasFile)
                        {
                            cmd.Parameters.AddWithValue("@img", pic);
                        }
                        
                        //cmd.Parameters.AddWithValue("@name", FirstName.Text);                        
                        //cmd.Parameters.AddWithValue("@mail", EmailAddress.Text);
                        //cmd.Parameters.AddWithValue("@sb", sb.Text);
                        //cmd.Parameters.AddWithValue("@phone", ContactNo.Text);


                        //cmd.Parameters.AddWithValue("@password", password);

                        //cmd.Parameters.AddWithValue("@gender", DropDownGender.SelectedValue);


                        //System.Diagnostics.Debug.WriteLine(DropDownGender.SelectedValue);
                        //System.Diagnostics.Debug.WriteLine(qur);
                        //System.Diagnostics.Debug.WriteLine(ContactNo.Text);

                        cmd.ExecuteNonQuery();



                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                        //    "alert('Sucessfully Inserted');", true);

                       // Session["UserEmail"] = EmailAddress.Text;
                        Response.Redirect("index.aspx");
                    }
                }

                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                        "alert('Please Fill Up The Required Document');", true);
                }

            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                    "alert('User Info didn't submitted properly');", true);
            }
            finally
            {
                con.Close();
            }


        }
    }
}