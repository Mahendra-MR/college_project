using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NcbJobPortal.User
{
    public partial class ResumeBuild : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader sdr;
        string str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        string query;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    showUserInfo();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        private void showUserInfo()
        {
            try
            {
                con = new SqlConnection(str);
                string query = "Select * from[User] where UserId=@UserId";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserId", Request.QueryString["id"]);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    if (sdr.Read())
                    {
                        txtUserName.Text = sdr["Username"].ToString();
                        txtFullName.Text = sdr["Name"].ToString();
                        txtEmail.Text = sdr["Email"].ToString();
                        txtMobile.Text = sdr["Mobile"].ToString();
                        txtTenth.Text = sdr["TenthGrade"].ToString();
                        txtTwelth.Text = sdr["TwelthGrade"].ToString();
                        txtGraducation.Text = sdr["GraduationGrade"].ToString();
                        txtPostGraducation.Text = sdr["PostGraduationGrade"].ToString();
                        txtPhd.Text = sdr["Phd"].ToString();
                        txtWork.Text = sdr["WorksOn"].ToString();
                        txtExperience.Text = sdr["Experience"].ToString();
                        txtAddress.Text = sdr["Address"].ToString();
                        ddlCountry.SelectedValue = sdr["Country"].ToString();


                    }
                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "User not found";
                    lblMsg.CssClass = "alert alert-danger";
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["id"] != null)
                {
                    string concatQuery = string.Empty;
                    string filepath = string.Empty;
                   // bool isValidToExecute = false;
                    bool isValid = false;
                    con = new SqlConnection(str);
                    if (fuResume.HasFile)
                    {
                        if (Utils.IsValidExtensionResume(fuResume.FileName))
                        {
                            concatQuery = "Resume=@Resume,";
                            isValid = true;
                        }
                        else
                        {
                            concatQuery = string.Empty;
                           
                        }
                    }
                    else
                    {
                        concatQuery = string.Empty;
                    }
                    query = @"Update [User] set Username=@Username,Name=@Name,Email=@Email,Mobile=@Mobile,Tenthgrade=@Tenthgrade,
                               TwelthGrade=@TwelthGrade,GraduationGrade=@GraduationGrade,PostGraducationGrade=@PostGraducationGrade,
                                Phd=@Phd,WorksOn=@WorksOn,Experience=@Experience," + concatQuery + " Address=@Address,Country=@Country where UserId=@UserId ";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Username",txtUserName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Name", txtFullName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text.Trim());
                    cmd.Parameters.AddWithValue("@Tenthgrade", txtTenth.Text.Trim());
                    cmd.Parameters.AddWithValue("@TwelthGrade", txtTwelth.Text.Trim());
                    cmd.Parameters.AddWithValue("@GraduationGrade", txtGraducation.Text.Trim());
                    cmd.Parameters.AddWithValue("@PostGraducationGrade", txtPostGraducation.Text.Trim());
                    cmd.Parameters.AddWithValue("@Phd", txtPhd.Text.Trim());
                    cmd.Parameters.AddWithValue("@WorksOn", txtWork.Text.Trim());
                    cmd.Parameters.AddWithValue("@Experience", txtExperience.Text.Trim());
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@Country", ddlCountry.SelectedValue);
                    cmd.Parameters.AddWithValue("@UserId", Request.QueryString["id"]);
                    if (fuResume.HasFile)
                    {
                        if (Utils.IsValidExtensionResume(fuResume.FileName))
                        {
                            Guid obj = Guid.NewGuid();
                            filepath = "Resumes/" + obj.ToString() + fuResume.FileName;
                            fuResume.PostedFile.SaveAs(Server.MapPath("~/Resumes/") + obj.ToString() + fuResume.FileName);

                            cmd.Parameters.AddWithValue("@Resume", filepath);
                            isValid = true; 
                        }
                        else
                        {
                            concatQuery = string.Empty;
                            lblMsg.Visible = true;
                            lblMsg.Text = "Please Select.doc,.docs, .pdf for resume ";
                            lblMsg.CssClass = "alert alert-danger";
                        }

                    }
                    else
                    {
                        isValid = true;
                    }

                    if (isValid)
                    {
                        con.Open();
                        int r = cmd.ExecuteNonQuery();
                        if (r > 0)
                        {
                            lblMsg.Visible = true;
                            lblMsg.Text = "Resume details updated successful...! ";
                            lblMsg.CssClass = "alert alert-success";
                        }
                        else
                        {
                            lblMsg.Visible = true;
                            lblMsg.Text = "Cannot update the records please try after sometimes ";
                            lblMsg.CssClass = "alert alert-danger";
                        }
                    }

                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Cannot update the records please try <b>Relogin again</b> ";
                    lblMsg.CssClass = "alert alert-danger";
                }
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("Violation of UNIQUE KEY constraint"))
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "<b>" + txtUserName.Text.Trim() + "</b> Username already exist, try new one";
                    lblMsg.CssClass = "alert alert-danger";
                }
                else
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }

            }
            catch(Exception ex)
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