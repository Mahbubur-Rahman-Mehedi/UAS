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
    public partial class uAdmisson : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null) //not logged in
            {
                Response.Redirect("adminLogin.aspx");
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
                String qur = "select * from addmisson where u_id=" + Session["uId"];
                System.Diagnostics.Debug.WriteLine(qur);
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

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument;
            SqlConnection con = new SqlConnection(CommonClass.strcon);
            try
            {
                if (con.State == ConnectionState.Closed) con.Open();

                String qur =
                    " delete from addmisson where id = '" + id + "' ";
                   
                System.Diagnostics.Debug.WriteLine(qur);
                SqlCommand cmd = new SqlCommand(qur, con);

                cmd.ExecuteNonQuery();
                con.Close();
             
                fillTheEvents();
                Response.Write("<script>alert('deleted');</script>");


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