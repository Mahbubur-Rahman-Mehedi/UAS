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
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null) //not logged in
            {
                Response.Redirect("loginStudent.aspx");
            }
            else
            {
                if (!IsPostBack)
                {

                    fillTheEvents();
                }
            }
        }
        void fillTheEvents()
        {

            SqlConnection con = new SqlConnection(CommonClass.strcon);
            try
            {
                if (con.State == ConnectionState.Closed) con.Open();


                // String qur = "select * from jobList 
                String qur = "select c_id,subject,amount,c.t_id as teacherId, t_name from course as c " +
                    "Left join teacher as t on t.t_id = c.t_id";

                SqlDataAdapter sqlData = new SqlDataAdapter(qur, con);
                DataTable tab = new DataTable();
                sqlData.Fill(tab);
                eventGrid.DataSource = tab;
                eventGrid.DataBind();
                con.Close();

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
        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            eventGrid.PageIndex = e.NewPageIndex;
            fillTheEvents();
        }

        protected void btnApply_Click1(object sender, EventArgs e)
        {

            string id = (sender as LinkButton).CommandArgument;

            //Session["cApplyId"] = id;

            //Response.Redirect("");

          
                SqlConnection con = new SqlConnection(CommonClass.strcon);
                try
                {
                   

                        con.Open();

                        String findMatchEmail = "select * from c_assign where" +
                            " c-id='" + name.Text + "'";

                        SqlCommand sqlCommand = new SqlCommand(findMatchEmail, con);

                        SqlDataReader dr = sqlCommand.ExecuteReader();

                        if (dr.Read())
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(),
                                "script", "alert('Course Already Exists');", true);
                            con.Close();

                        }
                        else
                        {
                            sqlCommand.Dispose();
                            dr.Close();
                            con.Close();
                            con.Open();

                            string qur = "insert into course (subject, amount ";

                            if (txtTeacher.Text != null && txtTeacher.Text != "")
                            {
                                qur += ",t_id";
                            }

                            qur += " ) " +
                                "values (";

                            qur += "'" + name.Text + "',";
                            qur += "'" + txtAmount.Text + "'";
                            if (txtTeacher.Text != null && txtTeacher.Text != "")
                            {
                                qur += ",'" + txtTeacher.Text + "'";
                            }


                            qur += ")";
                            System.Diagnostics.Debug.WriteLine(qur);

                            SqlCommand cmd = new SqlCommand(qur, con);


                            cmd.ExecuteNonQuery();

                            fillTheEvents();
                          
                            //  getEventDetailsBox();

                            ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                                "alert('Sucessfully Inserted');", true);

                            // Session["UserEmail"] = EmailAddress.Text;

                        }
                }
                catch (Exception)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                        "alert('COurse Info didn't submitted properly');", true);
                }
                finally
                {
                    con.Close();
                }

               
        }
    }
}