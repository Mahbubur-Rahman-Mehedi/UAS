using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UAS
{
    public partial class adminStudentControl : System.Web.UI.Page
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

                String qur = "select * from student where s_id='" + empid.Text.Trim() + "'";
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
        protected void btnActive_Click(object sender, EventArgs e)
        {
            if (empid.Text.Trim() != "" && validId())
            {
                message.Text = "";
                if (status.Text == "deactive")
                {
                    updateEventisExpired("active");
                }
                else if (status.Text == "active")
                {
                    updateEventisExpired("deactive");
                }


                getEventDetailsBox();
            }
            else
            {
                message.Text = "invalid id";
                message.ForeColor = System.Drawing.Color.Red;
            }

        }

        //protected void btnPending_Click(object sender, EventArgs e)
        //{
        //    if (empid.Text.Trim() != "" && validId())
        //    {
        //        message.Text = "";
        //        btnPending.Visible = true;
        //        updateEventisExpired("1");
        //        getEventDetailsBox();
        //    }
        //    else
        //    {
        //        message.Text = "invalid id";
        //        message.ForeColor = System.Drawing.Color.Red;
        //    }
        //}

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
                String qur = "select * from student order by s_name asc";

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



        void getEventDetailsBox(string id = "")
        {



            SqlConnection con = new SqlConnection(CommonClass.strcon);
            try
            {
                if (con.State == ConnectionState.Closed) con.Open();

                String qur = "select * from student where s_id='";
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
                System.Diagnostics.Debug.WriteLine(qur);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        name.Text = dr.GetValue(1).ToString();
                        status.Text = dr.GetValue(11).ToString();
                        phone.Text = dr.GetValue(3).ToString();
                        email.Text = dr.GetValue(8).ToString();
                        address.Text = dr.GetValue(6).ToString();
                        txtPaddress.Text = dr.GetValue(7).ToString();
                        txtMother.Text = dr.GetValue(5).ToString();
                        txtFathers.Text = dr.GetValue(4).ToString();
                     
                        if (status.Text == "active")
                        {

                            // iActive.Attributes.Add("class", "far fa-pause-circle");
                            btnActive.Attributes["class"] = "btn btn-warning pr-4 mr-1";
                            btnActive.Attributes["title"] = "deactive";
                            System.Diagnostics.Debug.WriteLine(iActive.Attributes["class"]);
                            iActive.Attributes["class"] = "fas fa-pause-circle";
                        }
                        else if (status.Text == "deactive")
                        {

                            // iActive.Attributes.Add("class", "fas fa-check-circle");
                            btnActive.Attributes["class"] = "btn btn-success pr-4 mr-1";
                            btnActive.Attributes["title"] = "active";
                            System.Diagnostics.Debug.WriteLine(iActive.Attributes["class"]);
                            iActive.Attributes["class"] = "fas fa-check-circle";
                            // iActive.CssClass = "h";
                        }

                        btnEdit.Visible = true;
                     
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


        void updateEventisExpired(String isExpired)
        {

            SqlConnection con = new SqlConnection(CommonClass.strcon);
            try
            {
                if (con.State == ConnectionState.Closed) con.Open();

                String qur = "update student set status = '" + isExpired + "' where s_id='" + empid.Text.Trim() + "'";
                SqlCommand cmd = new SqlCommand(qur, con);

                cmd.ExecuteNonQuery();
                con.Close();
                fillTheEvents();
                if (isExpired == "deactive") Smail();

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
        }

        // if deactivate job this goes o the employer who posted the job
        protected void Smail()
        {
            SqlConnection con = new SqlConnection(CommonClass.strcon);
            try
            {

                if (con.State == ConnectionState.Closed) con.Open();
                string qur = "select s_mail from student where s_id =  " + empid.Text.Trim() + "";
                string to = "";

                SqlCommand cmd = new SqlCommand(qur, con);
                //System.Diagnostics.Debug.WriteLine(qur);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        to = dr["s_mail"].ToString();
                    }

                }
                string sub = "Your status changed!";
                string message = "Hey,<br><br> We have found some problem. So, We have deactivated it. Talk to our admin for solve.";
                message += "<br><br> Thank you,<br>Admin";
                Thread mailThread = StartTheThread(to, sub, message);



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

        public Thread StartTheThread(string to, string sbjct, string msg)
        {
           
            var t = new Thread(() => CommonClass.sendTheMsgForOTP(msg, sbjct, to));
            t.Start();
            return t;
        }

        void deleteEvent()
        {
            SqlConnection con = new SqlConnection(CommonClass.strcon);
            try
            {
                if (con.State == ConnectionState.Closed) con.Open();

                String qur =
                   " delete from results where s_id = '" + empid.Text.Trim() + "' " +
                    " delete from payment where s_id = '" + empid.Text.Trim() + "' " +
                    " delete from education where s_id = '" + empid.Text.Trim() + "' " +
                    " delete from student where s_id='" + empid.Text.Trim() + "'";
                System.Diagnostics.Debug.WriteLine(qur);
                SqlCommand cmd = new SqlCommand(qur, con);

                cmd.ExecuteNonQuery();
                con.Close();
                clearTheForm();
                fillTheEvents();
                Response.Write("<script>alert('Student deleted');</script>");


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
            status.Text = "";
            txtFathers.Text = "";
            txtMother.Text = "";
            phone.Text = "";
            email.Text = "";
            address.Text = "";
            txtPaddress.Text = "";
            btnEdit.Visible = false;
            btnInsert.Visible = true;
            btnCancel.Visible = false;
            btnOk.Visible = false;

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            //edit mode on
            eorI = false;

            empid.ReadOnly = true;
            name.ReadOnly = false;
           
            phone.ReadOnly = false;
            address.ReadOnly = false;
            txtFathers.ReadOnly = false;
            txtMother.ReadOnly = false;
            txtPaddress.ReadOnly = false;
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
            empid.ReadOnly = true;
            name.ReadOnly = false;
            email.ReadOnly = false;
            phone.ReadOnly = false;
            address.ReadOnly = false;
            txtFathers.ReadOnly = false;
            txtMother.ReadOnly = false;
            txtPaddress.ReadOnly = false;
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

                    if (name.Text != null &&
                        address != null && email.Text != null && phone.Text != null &&
                        txtFathers.Text != null && txtMother.Text != null && txtPaddress.Text != null)
                    {
                        String EmailID = email.Text;

                        con.Open();

                        String findMatchEmail = "select * from student where" +
                            " s_mail='" + EmailID + "'";

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


                          
                            String password = "Ab*12345";
                            password = CommonClass.encrypt(password);
                            string qur = "insert into student (s_name, s_password, s_phone, s_mail, s_gender,present_address,permanent_address,father,mother ";
                            byte[] pic = { };
                           
                            qur += " ) " +
                                "values (";
                            //"values ('@name', '@password', @phone, @mail, '@gender', '@sb')";
                            qur += "'" + name.Text + "',";
                            qur += "'" + password + "',";
                            qur += phone.Text + ",";
                            qur += "'" + email.Text + "',";
                            qur += "'nun',";
                            qur += "'" + address.Text + "',";
                            qur += "'" + txtPaddress.Text + "',";
                            qur += "'" + txtFathers.Text + "',";
                            qur += "'" + txtMother.Text + "'";

                         
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
                        "alert('User Info didn't submitted properly');", true);
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
                   

                        String qur = "update student set s_name = '" + name.Text +
                        "' , s_phone =" + phone.Text +
                        " , s_mail = '" + email.Text +
                        "' , father = '" + txtFathers.Text +
                        "' , mother = '" + txtMother.Text +
                        "' , present_address = '" + address.Text +
                        "' , permanent_address = '" + txtPaddress.Text +
                        "' where s_id='" + empid.Text.Trim() + "'";

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
            email.ReadOnly = true;
            phone.ReadOnly = true;
            address.ReadOnly = true;
            txtFathers.ReadOnly = true;
            txtMother.ReadOnly = true;
            txtPaddress.ReadOnly = true;
            btnOk.Visible = false;
            btnCancel.Visible = false;
            empid.ReadOnly = false;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //back to view only
            empid.ReadOnly = false;
            name.ReadOnly = true;
            email.ReadOnly = true;
            phone.ReadOnly = true;
            address.ReadOnly = true;
            txtFathers.ReadOnly = true;
            txtMother.ReadOnly = true;
            txtPaddress.ReadOnly = true;
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
           
        }
    }
}