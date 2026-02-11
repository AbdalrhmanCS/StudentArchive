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
    public partial class ProfilePage : System.Web.UI.Page
    {
        string scon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lang();
            }
            try
            {
                if ( Session["Email"] == null)
                { 
                    Response.Write("<script>alert('Session Expired log in again');</script>");
                    Response.Redirect("UserLogin.aspx");

                }
                else
                {
                    if (!Page.IsPostBack)
                    {
                        getuserdata();
                    }
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
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
                accst.InnerText = "حالة الحساب";
                hyp.InnerText = "حسابك";
                lblact.Text = "مفعل";
                lbldob.InnerText = "تاريخ الميلاد";
                lblem.InnerText = "البريد الالكتروني";
                lblfn.InnerText = "الاسم الكامل";
                lblnewpass.InnerText = "الرمز الجديد";
                lbloldpass.InnerText = "الرمز القديم";
                Button1.Text = "تحديث";
            }
            else if ((Session["lang"].ToString() == "en-US"))
            {


            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con1 = new SqlConnection(scon);
                if (con1.State == ConnectionState.Closed)
                {
                    con1.Open();
                }
                if (txtnew.Text == "" || txtdate.Text == "" || txtemail.Text == "" || txtfull.Text == "")
                {
                    Response.Write("<script>alert('Please dont leave anything Empty');</script>");
                }
                else
                {
                    string query = "update Users set FullName=@fname,DateOfBirth=@DOB , Email=@email,Password=@pass where Email=@oldem ";
                    SqlCommand cmd = new SqlCommand(query, con1);
                    cmd.Parameters.AddWithValue("@fname", txtfull.Text.Trim());
                    cmd.Parameters.AddWithValue("@DOB", txtdate.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", txtemail.Text.Trim());
                    cmd.Parameters.AddWithValue("@pass",txtnew.Text.Trim());
                    cmd.Parameters.AddWithValue("@oldem", Session["Email"].ToString());
                    cmd.ExecuteNonQuery();
                    Session["Email"] = txtemail.Text.Trim();
                    Response.Write("<script>alert('Your Profile is Updated');</script>");
                    getuserdata();
                    txtnew.Text = "";

                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
            }
        void getuserdata()
        {
            try
            {
                SqlConnection con1 = new SqlConnection(scon);
                if (con1.State == ConnectionState.Closed)
                {
                    con1.Open();
                }
                string query = "select * from Users where Email='" + Session["Email"].ToString()+"'";
                SqlCommand cmd = new SqlCommand( query,con1);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtfull.Text = dt.Rows[0]["FullName"].ToString();
                
                txtdate.Text = Convert.ToDateTime(dt.Rows[0]["DateOfBirth"])
                .ToString("yyyy-MM-dd");
                txtemail.Text = dt.Rows[0]["Email"].ToString();
                txtold.Text = dt.Rows[0]["Password"].ToString();
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}