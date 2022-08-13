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
            if (Session["sid"] == null) //not logged in
            {
                Response.Redirect("loginStudent.aspx");
            }
            else
            {
                if (!IsPostBack)
                {

                    fillTheEvents();
                    fillAddmissionDetails();
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

        void fillAddmissionDetails()
        {
            SqlConnection con = new SqlConnection(CommonClass.strcon);
            try
            {
                if (con.State == ConnectionState.Closed) con.Open();

                String qur = "select id,addmisson_season,deadline,exam_date,course,phone,u.u_name " +
                    "from addmisson as a " +
                    "Left join university as u on u.u_id = a.id";

                SqlDataAdapter sqlData = new SqlDataAdapter(qur, con);
                DataTable tab = new DataTable();
                sqlData.Fill(tab);
                GridView1.DataSource = tab;
                GridView1.DataBind();
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

        protected void OnPageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            fillAddmissionDetails();
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
                            " c_id=" + id + " and s_id = " + Session["sid"] ;
                System.Diagnostics.Debug.WriteLine(findMatchEmail);
                        SqlCommand sqlCommand = new SqlCommand(findMatchEmail, con);

                        SqlDataReader dr = sqlCommand.ExecuteReader();

                        if (dr.Read())
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(),
                                "script", "alert('Already Enrolled');", true);
                            con.Close();

                        }
                        else
                        {
                            sqlCommand.Dispose();
                            dr.Close();
                            con.Close();
                            con.Open();

                            string qur = "insert into c_assign (c_id, s_id ";
                            qur += " ) " +
                                "values (";

                            qur += "'" + id + "',";
                            qur += "'" + Session["sid"] + "'";
                           
                            qur += ")";
                            System.Diagnostics.Debug.WriteLine(qur);

                            SqlCommand cmd = new SqlCommand(qur, con);


                            cmd.ExecuteNonQuery();

                            fillTheEvents();
                          
                            //  getEventDetailsBox();

                            ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                                "alert('Sucessfully joined');", true);

                            // Session["UserEmail"] = EmailAddress.Text;

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

        protected void btnApply1_Click(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument;

            //Session["cApplyId"] = id;

            //Response.Redirect("");


            SqlConnection con = new SqlConnection(CommonClass.strcon);
            try
            {
                con.Open();

                String findMatchEmail = "select * from a_assign where" +
                    " a_id=" + id + " and s_id = " + Session["sid"];
                System.Diagnostics.Debug.WriteLine(findMatchEmail);
                SqlCommand sqlCommand = new SqlCommand(findMatchEmail, con);

                SqlDataReader dr = sqlCommand.ExecuteReader();

                if (dr.Read())
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                        "script", "alert('Already Enrolled');", true);
                    con.Close();

                }
                else
                {
                    sqlCommand.Dispose();
                    dr.Close();
                    con.Close();
                    con.Open();

                    string qur = "insert into a_assign (a_id, s_id ";
                    qur += " ) " +
                        "values (";
                    qur += "'" + id + "',";
                    qur += "'" + Session["sid"] + "'";
                    qur += ")";

                    System.Diagnostics.Debug.WriteLine(qur);
                    SqlCommand cmd = new SqlCommand(qur, con);
                    cmd.ExecuteNonQuery();
                    fillTheEvents();

                    //  getEventDetailsBox();

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                        "alert('Sucessfully applied');", true);

                    // Session["UserEmail"] = EmailAddress.Text;

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