using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace UAS
{
    public class Validate
    {
        // any kind of validation put here


        // Email exist validation
        public static bool EmailExists(string email)
        {
            SqlConnection con = new SqlConnection(CommonClass.strcon);
            try
            {
                // SqlConnection con = new SqlConnection(commonClass.strcon);
                if (con.State == ConnectionState.Closed) con.Open();

                String qur = "select mail from subscriberTab where mail='" + email + "';";
                SqlCommand cmd = new SqlCommand(qur, con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    con.Close();
                    return true;
                }
                else
                {
                    con.Close();
                    return false;
                }
            }
            catch (Exception)
            {
                //Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
            finally
            {
                con.Close();
            }
            return false;
        }
        // Email exist validation End

        // Email validation

        public static bool ValidEmail(string email)
        {
            if (Regex.IsMatch(email, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
                return true;
            else
            {
                //Response.Write("<script>alert('Invalid email address');</script>");
                return false;
            }

        }
        // Email validation End
    }
}