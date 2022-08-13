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
    public partial class sAddmission : System.Web.UI.Page
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
                String qur = "select a.id,a.addmisson_season,a.course,a.deadline,a.exam_date,a.phone,a.cgpa,u.u_name,u.u_details from a_assign as asn " +
                    " Right join addmisson as a on a.id = asn.a_id " +
                    " Left join university as u on u.u_id = a.u_id " +
                    "where asn.s_id = " + Session["sid"];

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
            fillTheEvents();
        }


        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument;
            SqlConnection con = new SqlConnection(CommonClass.strcon);
            try
            {
                if (con.State == ConnectionState.Closed) con.Open();

                String qur =
                    " delete from a_assign where a_id = '" + id + "' " +
                    "and s_id='" + Session["sid"] + "'";
                System.Diagnostics.Debug.WriteLine(qur);
                SqlCommand cmd = new SqlCommand(qur, con);

                cmd.ExecuteNonQuery();
                con.Close();

                fillTheEvents();
                Response.Write("<script>alert('Canceled');</script>");


            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
            finally
            {
                con.Close();
            }
        }
    }
}