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
    public partial class studentList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["courseId"] == null) //not logged in
            {
                Response.Redirect("teacherIndex.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    fillTheEvents();
                }
            }
        }
        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("teacherIndex.aspx");
        }
        void fillTheEvents()
        {

            SqlConnection con = new SqlConnection(CommonClass.strcon);
            try
            {
                if (con.State == ConnectionState.Closed) con.Open();

//                select* from c_assign as cs
//inner join course as c on c.c_id = cs.c_id
//where cs.c_id = 2
//and c.t_id = 6
                // String qur = "select * from jobList 
                String qur = " select* from c_assign as cs " +
                    " inner join course as c on c.c_id = cs.c_id " +
                    " inner join student as s on s.s_id = cs.s_id " +
                    " where cs.c_id = " + Session["courseId"] +
                    " and c.t_id = " + Session["id"];

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
    }
}