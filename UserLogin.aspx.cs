using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentArchive1
{
    public partial class UserLogin : System.Web.UI.Page
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
                hlogin.InnerText = "تسجيل الدخول";
                lblem.InnerText = "البريد الالكتروني";
                lblpass.InnerText = "الرمز السري";
                Button3.Text = "انشاء حساب";
                Button4.Text = "تسجيل الدخول";

            }
            else if ((Session["lang"].ToString() == "en-US"))
            {


            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignUp.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con1 = new SqlConnection(scon);
                if (con1.State == ConnectionState.Closed)
                {
                    con1.Open();
                }
                string query = "select * from Users where Email='" + txtemail.Text.Trim() + "'AND Password='" + txtpass.Text + "' ";
                SqlCommand cmd = new SqlCommand(query, con1);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Session["FullName"] = dr.GetValue(1).ToString();
                        Session["Role"] = dr.GetValue(5).ToString();
                        Session["Email"] = dr.GetValue(3).ToString();
                       

                    }
                    Response.Redirect("HomePage.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Email or Password is wrong');</script>");
                }
            }
               
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
            }
    }
}