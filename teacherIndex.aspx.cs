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
    public partial class teacherIndex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null) //not logged in
            {
                Response.Redirect("loginTeacher.aspx");
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
                String qur = "select c.c_id,c.subject,c.t_id,c.amount,c.status,COUNT(c.c_id) as total from course as c" +
                    " inner join c_assign as cs on cs.c_id = c.c_id " +
                    "where t_id = " + Session["id"];
                qur += " group by c.c_id,c.subject,c.t_id,c.amount,c.status";

                //string qur = "select * from course where t_id ="+ Session["id"];

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

        protected void btnTotal_Click(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument;
            Session["courseId"] = id;
            Response.Redirect("studentList.aspx");
        }
    }
}