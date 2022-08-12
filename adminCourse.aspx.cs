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
    public partial class adminCourse : System.Web.UI.Page
    {
        static bool eorI = true; // true for insert btn
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

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminIndex.aspx");
        }


        bool validId()
        {

            SqlConnection con = new SqlConnection(CommonClass.strcon);
            try
            {
                if (con.State == ConnectionState.Closed) con.Open();

                String qur = "select * from course where c_id='" + empid.Text.Trim() + "'";
                SqlCommand cmd = new SqlCommand(qur, con);


                SqlDataReader dr = cmd.ExecuteReader();


                if (dr.HasRows)
                {
                    con.Close();
                    return true;
                }
                con.Close();
                return false;


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
            finally
            {
                con.Close();
            }
            return false;
        }

        protected void btnEventDetails_Click(object sender, EventArgs e)
        {
            clearTheForm();
            getEventDetailsBox();
            if (validId())
            {
                message.Text = "";
            }
            else
            {
                message.Text = "invalid id";
                message.ForeColor = System.Drawing.Color.Red;
            }
        }


        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (empid.Text.Trim() != "" && validId())
            {
                message.Text = "";
                deleteEvent();
            }
            else
            {
                message.Text = "invalid id";
                message.ForeColor = System.Drawing.Color.Red;
            }
        }


        void fillTheEvents()
        {

            SqlConnection con = new SqlConnection(CommonClass.strcon);
            try
            {
                if (con.State == ConnectionState.Closed) con.Open();


                // String qur = "select * from jobList 
                String qur = "select * from course order by c_id asc";

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

        void getTeacherName(string id)
        {
            SqlConnection con = new SqlConnection(CommonClass.strcon);
            try
            {
                if (con.State == ConnectionState.Closed) con.Open();

                String qur = "select t_name from teacher where t_id='";
               
                    qur += id + "'";
                  

                SqlCommand cmd = new SqlCommand(qur, con);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        txtTName.Text = dr.GetValue(0).ToString();
                        divTName.Visible = true;
                    }
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


        void getEventDetailsBox(string id = "")
        {



            SqlConnection con = new SqlConnection(CommonClass.strcon);
            try
            {
                if (con.State == ConnectionState.Closed) con.Open();

                String qur = "select * from course where c_id='";
                if (id == "")
                {
                    qur += empid.Text.Trim() + "'";
                }
                else
                {
                    qur += id + "'";
                    empid.Text = id;
                }

                SqlCommand cmd = new SqlCommand(qur, con);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        name.Text = dr.GetValue(1).ToString();
                        txtAmount.Text = dr.GetValue(3).ToString();
                        if (dr.GetValue(2).ToString() != null && dr.GetValue(2).ToString() != "")
                        {
                            txtTeacher.Text = dr.GetValue(2).ToString();
                            
                            getTeacherName(dr.GetValue(2).ToString());
                        }

                        btnEdit.Visible = true;
                        btnInsert.Visible = true;
                        btnOk.Visible = false;
                        btnCancel.Visible = false;
                    }
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

        void deleteEvent()
        {
            SqlConnection con = new SqlConnection(CommonClass.strcon);
            try
            {
                if (con.State == ConnectionState.Closed) con.Open();

                String qur =
                    " delete from c_assign where c_id = '" + empid.Text.Trim() + "' " +
                    " delete from course where c_id='" + empid.Text.Trim() + "'";
                System.Diagnostics.Debug.WriteLine(qur);
                SqlCommand cmd = new SqlCommand(qur, con);

                cmd.ExecuteNonQuery();
                con.Close();
                clearTheForm();
                fillTheEvents();
                Response.Write("<script>alert('university deleted');</script>");


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

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument;
            getEventDetailsBox(id);
        }

        void clearTheForm()
        {
            //clear all field
            name.Text = "";
            txtAmount.Text = "";
            txtTeacher.Text = "";
            txtTName.Text = "";

            btnEdit.Visible = false;
            btnInsert.Visible = true;
            btnCancel.Visible = false;
            btnOk.Visible = false;

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            //edit mode on
            eorI = false;
            txtAmount.ReadOnly = false;
            txtTeacher.ReadOnly = false;
          
            empid.ReadOnly = true;

            btnOk.Visible = true;
            btnCancel.Visible = true;
            btnEdit.Visible = false;

        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            //insert
            eorI = true;
            clearTheForm();
            empid.Text = "";
            name.ReadOnly = false;
            txtAmount.ReadOnly = false;
            txtTeacher.ReadOnly = false;
           
            empid.ReadOnly = true;

            btnOk.Visible = true;
            btnCancel.Visible = true;
            btnInsert.Visible = false;
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            //insert if insert btn visible 
            if (eorI)
            {
                SqlConnection con = new SqlConnection(CommonClass.strcon);
                try
                {
                    //check email pattern regex
                    //check  password pattern regex
                    //

                    if (name.Text != null && txtAmount.Text !=null )
                    {

                        con.Open();

                        String findMatchEmail = "select * from course where" +
                            " subject='" + name.Text + "'";

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

                            if(txtTeacher.Text != null && txtTeacher.Text != "")
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
                            clearTheForm();
                            //  getEventDetailsBox();

                            ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                                "alert('Sucessfully Inserted');", true);

                            // Session["UserEmail"] = EmailAddress.Text;

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
                        "alert('COurse Info didn't submitted properly');", true);
                }
                finally
                {
                    con.Close();
                }

                btnInsert.Visible = true;
                empid.ReadOnly = false;
            }


            //update if edit btn visible
            else
            {


                SqlConnection con = new SqlConnection(CommonClass.strcon);
                try
                {
                    if (con.State == ConnectionState.Closed) con.Open();



                    // string pass = CommonClass.encrypt("Ab*12345");

                    String qur = "update course set subject = '" + name.Text +
                    "' , amount = '" + txtAmount.Text;
                    if(txtTeacher.Text != null && txtTeacher.Text != "")
                    {
                        qur += "' , t_id = '" + txtTeacher.Text;
                    }
                    qur += "' where c_id='" + empid.Text.Trim() + "'";

                    System.Diagnostics.Debug.WriteLine(qur);
                    SqlCommand cmd = new SqlCommand(qur, con);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    fillTheEvents();
                    getEventDetailsBox();

                    // Response.Write("<script>alert('status updated');</script>");



                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");

                }
                finally
                {
                    con.Close();
                }

                btnEdit.Visible = true;
            }

            name.ReadOnly = true;
            txtAmount.ReadOnly = true;
            txtTeacher.ReadOnly = true;
            txtTName.ReadOnly = true;
            empid.ReadOnly = false;
            btnOk.Visible = false;
            btnCancel.Visible = false;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //back to view only
            name.ReadOnly = true;
            txtAmount.ReadOnly = true;
            txtTeacher.ReadOnly = true;
            txtTName.ReadOnly = true;

            btnOk.Visible = false;
            btnCancel.Visible = false;
            if (eorI)
            {
                btnInsert.Visible = true;
            }
            else
            {
                btnEdit.Visible = true;
            }
            empid.ReadOnly = false;
        }
    }
}