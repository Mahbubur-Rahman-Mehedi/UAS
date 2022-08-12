using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UAS
{
    public partial class adminQuestion : System.Web.UI.Page
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

                String qur = "select * from prev_ques where id='" + empid.Text.Trim() + "'";
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
                // btnPending.Visible = true;
                if (status.Text == "deactivate")
                {
                    updateEventisExpired("activate");
                    // iActive.Attributes.Add("class", "far fa-pause-circle");
                    //btnActive.Attributes["class"] = "btn btn-warning pr-4 mr-1";
                    //System.Diagnostics.Debug.WriteLine(iActive.Attributes["class"]);
                    //iActive.Attributes["class"] = "fas fa-pause-circle";
                }
                else if (status.Text == "activate")
                {
                    updateEventisExpired("deactivate");
                    // iActive.Attributes.Add("class", "fas fa-check-circle");
                    //btnActive.Attributes["class"] = "btn btn-success pr-4 mr-1";
                    //System.Diagnostics.Debug.WriteLine(iActive.Attributes["class"]);
                    //iActive.Attributes["class"] = "fas fa-check-circle";
                    // iActive.CssClass = "h";
                }

                getEventDetailsBox();

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

                String qur = "select * from prev_ques order by university_name desc";

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

                String qur = "select * from prev_ques where id='";
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
                        name.Text = dr.GetValue(2).ToString();

                        status.Text = dr.GetValue(4).ToString();
                        year.Text = dr.GetValue(1).ToString();

                        System.Diagnostics.Debug.WriteLine(dr.GetValue(3).ToString());
                        if (dr.GetValue(5).ToString() != null && dr.GetValue(5).ToString() != "")
                        {
                            txDocument.Text = dr.GetValue(5).ToString();
                        }
                        else
                        {
                            txDocument.Text = "No";
                        }

                        if (status.Text == "activate")
                        {

                            // iActive.Attributes.Add("class", "far fa-pause-circle");
                            btnActive.Attributes["class"] = "btn btn-warning pr-4 mr-1";
                            btnActive.Attributes["title"] = "deactivate";
                            System.Diagnostics.Debug.WriteLine(iActive.Attributes["class"]);
                            iActive.Attributes["class"] = "fas fa-pause-circle";
                        }
                        else if (status.Text == "deactivate")
                        {

                            // iActive.Attributes.Add("class", "fas fa-check-circle");
                            btnActive.Attributes["class"] = "btn btn-success pr-4 mr-1";
                            btnActive.Attributes["title"] = "activate";
                            System.Diagnostics.Debug.WriteLine(iActive.Attributes["class"]);
                            iActive.Attributes["class"] = "fas fa-check-circle";
                            // iActive.CssClass = "h";
                        }
                        LinkDownload.Visible = true;
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

                String qur = "update prev_ques set status = '" + isExpired + "' where id='" + empid.Text.Trim() + "'";
                SqlCommand cmd = new SqlCommand(qur, con);

                cmd.ExecuteNonQuery();
                con.Close();
                fillTheEvents();

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



        void deleteEvent()
        {
            SqlConnection con = new SqlConnection(CommonClass.strcon);
            try
            {
                if (con.State == ConnectionState.Closed) con.Open();

                String qur = " delete from prev_ques where id = '" + empid.Text.Trim() + "' ";
                System.Diagnostics.Debug.WriteLine(qur);
                SqlCommand cmd = new SqlCommand(qur, con);

                cmd.ExecuteNonQuery();
                con.Close();
                clearTheForm();
                fillTheEvents();
                status.Text = "";
                empid.Text = "";
                Response.Write("<script>alert('Question deleted');</script>");


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
            if (lnkbtnInsertA.Text == "back")
            {
                btnInsert.Visible = false;
                empid.Text = "";
                empid.ReadOnly = false;
                status.Text = "";
                clearTheForm();
                name.ReadOnly = true;
                
                btnActive.Visible = true;
                btnDelete.Visible = true;
                lnkbtnInsertA.Text = "Insert";
                btnUpload.Visible = true;
            }
            getEventDetailsBox(id);

        }

        void clearTheForm()
        {
            name.Text = "";
            year.Text = "";
            txDocument.Text = "";

        }

        protected bool fileValidate()
        {

            string fileEx = Path.GetExtension(skillFile.FileName);


            if (fileEx.ToLower() == ".pdf" || fileEx.ToLower() == ".docx" || fileEx.ToLower() == ".doc")
            {
                int filesize = skillFile.PostedFile.ContentLength;
                if (filesize > 5097152)
                {
                    // Response.Write("<script>alert('Maximum file size(2MB) Exceeded');</script> ");
                    lblUploadMessage.Text = "Maximum file size(5MB) Exceeded";
                    return false;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(CommonClass.strcon);
            try
            {
                bool fileFlag = false;
                if (skillFile.HasFile)
                {
                    fileFlag = fileValidate();
                }

                if (con.State == ConnectionState.Closed) con.Open();

                string qur = "IF(Not Exists(select * from prev_ques where year = '" + year.Text.ToString().Trim() + "' and " +
                    " university_name = '"+ name.Text.ToString()+ "'))";
                qur += "insert into  prev_ques(university_name, year";
                if (fileFlag)
                {
                    qur += ",DocName, Document";
                }
                qur += ") values('" + name.Text.ToString().Trim() + "' , '" + year.Text.ToString().Trim() + "'";
                byte[] bytes = { };
                if (fileFlag)
                {
                    string fileName = Path.GetFileName(skillFile.PostedFile.FileName);
                    Stream dr = skillFile.PostedFile.InputStream;
                    BinaryReader br = new BinaryReader(dr);
                    bytes = br.ReadBytes((Int32)dr.Length);

                    qur += ",'" + fileName + "',";
                    qur += "@data";
                }

                qur += ") ";
                System.Diagnostics.Debug.WriteLine(qur);

                SqlCommand cmd = new SqlCommand(qur, con);
                if (fileFlag)
                {
                    cmd.Parameters.AddWithValue("@data", bytes);
                }
                cmd.ExecuteNonQuery();
                con.Close();

                btnInsert.Visible = false;
                empid.Text = "";
                empid.ReadOnly = false;
                clearTheForm();
                name.ReadOnly = true;
                year.ReadOnly = true;

                fillTheEvents();

                lnkbtnInsertA.Text = "Insert";
                btnDelete.Visible = true;
                btnActive.Visible = true;



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

        protected void lnkbtnInsertA_Click(object sender, EventArgs e)
        {
            if (lnkbtnInsertA.Text == "Insert")
            {
                btnInsert.Visible = true;
                empid.Text = "";
                empid.ReadOnly = true;
                status.Text = "";
                clearTheForm();
                name.ReadOnly = false;
                year.ReadOnly = false;
                btnActive.Visible = false;
                btnDelete.Visible = false;
                lnkbtnInsertA.Text = "back";
                btnUpload.Visible = false;
                LinkDownload.Visible = false;
            }
            else
            {
                btnInsert.Visible = false;
                empid.Text = "";
                empid.ReadOnly = false;
                status.Text = "";
                clearTheForm();
                name.ReadOnly = true;
                year.ReadOnly = true;
                btnActive.Visible = true;
                btnDelete.Visible = true;
                lnkbtnInsertA.Text = "Insert";
                btnUpload.Visible = true;
                LinkDownload.Visible = true;
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (skillFile.HasFile)
            {
                upload();
            }

            else
            {
                // Response.Write("<script>alert('Please select a file');</script>");
                lblUploadMessage.Text = "Please select a file.";
            }
        }

        void upload()
        {
            try
            {
                string fileEx = Path.GetExtension(skillFile.FileName);
                //if (fileEx.ToLower() != ".pdf")
                //{
                //    Response.Write("<script>alert('Only file with pdf extention is allowed');</script> ");
                //}
                if (fileEx.ToLower() == ".pdf" || fileEx.ToLower() == ".docx" || fileEx.ToLower() == ".doc")
                {
                    int filesize = skillFile.PostedFile.ContentLength;
                    if (filesize > 5097152)
                    {
                        // Response.Write("<script>alert('Maximum file size(2MB) Exceeded');</script> ");
                        lblUploadMessage.Text = "Maximum file size(5MB) Exceeded";
                    }
                    else
                    {
                        string fileName = Path.GetFileName(skillFile.PostedFile.FileName);
                        Stream dr = skillFile.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(dr);
                        byte[] bytes = br.ReadBytes((Int32)dr.Length);

                        SqlConnection con = new SqlConnection(CommonClass.strcon);
                        if (con.State == ConnectionState.Closed) con.Open();
                        string qur = "IF(Exists(select * from prev_ques where id = '" + empid.Text + "' ))";
                        qur += " update prev_ques set DocName = @file , Document= @data  where id='" + empid.Text + "'";

                        System.Diagnostics.Debug.WriteLine(qur);
                        SqlCommand cmd = new SqlCommand(qur, con);

                        cmd.Parameters.AddWithValue("@file", fileName);
                        cmd.Parameters.AddWithValue("@data", bytes);
                        System.Diagnostics.Debug.WriteLine(qur);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        fillTheEvents();
                        txDocument.Text = fileName;
                    }
                }
                else
                {
                    // Response.Write("<script>alert('Only pdf and doc file  is allowed');</script> ");
                    lblUploadMessage.Text = "Only pdf and doc file  is allowed";
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void LinkDownload_Click(object sender, EventArgs e)
        {
            if (empid.Text != "")
            {
                SqlConnection con = new SqlConnection(CommonClass.strcon);
                try
                {
                    // SqlConnection con = new SqlConnection(commonClass.strcon);
                    if (con.State == ConnectionState.Closed) con.Open();
                    string qur = "Select DocName,Document from prev_ques  where id='" + empid.Text + "'";

                    SqlCommand cmd = new SqlCommand(qur, con);

                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    string filePath = (sender as LinkButton).CommandArgument;
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.ContentType = "application/octet-stream";
                    byte[] bytes = (byte[])reader["Document"];
                    string filename = reader["DocName"].ToString();
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename);
                    Response.BinaryWrite(bytes);

                    con.Close();
                    Response.Flush();
                    Response.End();
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
            else
            {
                lblUploadMessage.Text = "no id selected";
            }
        }
    }
}