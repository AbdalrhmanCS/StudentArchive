using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentArchive1
{
    public partial class SignUp : System.Web.UI.Page
    {
        string scon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lang();
            }
        }
        private void lang()

        {
            if (Session["lang"] == null)
            {
                Response.Redirect("Language.aspx");
            }

            if (Session["lang"].ToString() == "ar-IQ")
            {
                hsu.InnerText = "انشاء حساب";
                lbldob.InnerText = "تاريخ الميلاد";
                lblem.InnerText = "البريد الالكتروني";
                lblfn.InnerText = "الاسم الكامل";
                lblpass.InnerText = "الرمز السري";
                btnsig.Text = "تسجيل";
            }
            else if ((Session["lang"].ToString() == "en-US"))
            {


            }

        }

        protected void btnsig_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con1 = new SqlConnection(scon);
                if (con1.State == ConnectionState.Closed)
                {
                    con1.Open();
                }
                string query = "insert into Users(FullName,DateOfBirth,Email,Password,Role) values(@FullName,@DateOfBirth,@Email,@Password,@Role)";
                SqlCommand cmd = new SqlCommand(query, con1);
                cmd.Parameters.AddWithValue("@FullName", txtfulname.Text.Trim());
                cmd.Parameters.AddWithValue("@DateOfBirth", txtDob.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", txtemail.Text.Trim());
                cmd.Parameters.AddWithValue("@Password", txtpass.Text.Trim());
                cmd.Parameters.AddWithValue("@Role","User");
                cmd.ExecuteNonQuery();
                con1.Close();
                Response.Write("<script>alert('Sign Up Successful. Go to User Login');</script>");
            }
            catch(Exception ex)
            {

                Response.Write("<script>alert('"+ex.Message+"');</script>");
            }
        }
    }
}