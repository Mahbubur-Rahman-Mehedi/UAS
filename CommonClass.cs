using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Web;

namespace UAS
{
    public class CommonClass
    {
        public static string key = "@124#";   //very important
        public static string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;  //server sql

        public static string adEmail = "", adPas = "";

        public static string errorText = "Cannot access data at this time. Please try later ☹";//   public static string strcon = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\bnxnbd2\\Documents\\GitHub\\pdesiStops\\db\\desistopsdb.mdf;Integrated Security=True";

        public static string previousPage = "index.aspx";
        public static string currentPage = "index.aspx";


        //check DB
        public static bool checkTheDatabase() 
        {

            try
            {
                SqlConnection con = new SqlConnection(CommonClass.strcon);
                con.Open();
                return true;
            }
            catch (SqlException ex)
            {
                HttpContext.Current.Response.Write("<script>alert('" + ex.Message + "');</script>");

                return false;
            }

        }

        public static void deleteORupdateFromDB(string qur)
        {
            SqlConnection con = new SqlConnection(CommonClass.strcon);
            try
            {
                if (con.State == ConnectionState.Closed) con.Open();

                SqlCommand cmd = new SqlCommand(qur, con);
                cmd.ExecuteNonQuery();
            }
            catch
            {
            }
            finally
            {
                con.Close();
            }
        }


        public static bool exists(string qur)
        {
            SqlConnection con = new SqlConnection(CommonClass.strcon);
            try
            {
                if (con.State == ConnectionState.Closed) con.Open();

                //  String qur = "select userID from userTab where email='" + txtEmail.Text.Trim() + "';";
                SqlCommand cmd = new SqlCommand(qur, con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
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
            catch (Exception ex)
            {
            }
            finally
            {
                con.Close();
            }
            return false;
        }




        public static string encrypt(string pass)
        {

            if (string.IsNullOrEmpty(pass)) return "";
            pass += key;
            var passBytes = Encoding.UTF8.GetBytes(pass);
            return Convert.ToBase64String(passBytes);
        }




        public static string decrypt(string passBytes)
        {
            if (string.IsNullOrEmpty(passBytes)) return "";
            var encodedBytes = Convert.FromBase64String(passBytes);
            var result = Encoding.UTF8.GetString(encodedBytes);
            return result.Substring(0, result.Length - key.Length);
        }

        public static void otpSender(OTPgen op, string email)
        {

            Random rand = new Random();
            string randomcode = rand.Next(99999).ToString();
            string[] arr = { randomcode, email };
            op.myOTP = arr[0];
            bool done = true;
            if (done)
            {
                Thread senderThread = new Thread(() => CommonClass.sendTheMsgForOTP(arr[0], "Verification code", arr[1]));
                senderThread.Start();
            }

        }

        public static void sendTheMsgForOTP(string body, string sub="Mail from U.A.S", string to = "zaman.joy@gmail.com")
        {
            try
            {
                string emailBody = body;
                MailMessage passResetMail = new MailMessage(adEmail, to);
                passResetMail.Body = emailBody;
                passResetMail.IsBodyHtml = true;
                passResetMail.Subject = sub;
                passResetMail.Priority = MailPriority.High;
                SmtpClient SMTP = new SmtpClient("smtp.gmail.com", 587);
                SMTP.DeliveryMethod = SmtpDeliveryMethod.Network;
                SMTP.UseDefaultCredentials = false;

                SMTP.Credentials = new NetworkCredential(adEmail, adPas); //password please
                SMTP.EnableSsl = true;
                SMTP.Send(passResetMail);
            }
            catch (Exception e)
            {
                   //HttpContext.Current.Response.Write("<script>alert('" + e.Message + "');</script>");
            }

        }

        public class OTPgen
        {
            public string myOTP { get; set; }

            public OTPgen() { }
        }

      
    }
}