using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentArchive1
{
    public partial class UsersMangment : System.Web.UI.Page
    {
        string scon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadgrid();
                lang();
            }
            else
            {
                loadgrid();
            }

           
        }
        private void lang()

        {
            if (GridView1.HeaderRow == null) return;
            if (Session["lang"] == null)
            {
                Response.Redirect("Language.aspx");
            }

            if (Session["lang"].ToString() == "ar-IQ")
            {

                htit.InnerText = "حذف المستخدمين";
                Button2.Text = "حذف";
                Button1.Text = "بحث";
                lblNa.InnerText = "الاسم";
                lblus.InnerText = "رقم المستخدم";
                hut.InnerText = "جدول المستخدمين";
                GridView1.HeaderRow.Cells[0].Text = "رقم المستخدم";
                GridView1.HeaderRow.Cells[1].Text = "الاسم";
                GridView1.HeaderRow.Cells[2].Text = "تاريخ الميلاد";
                GridView1.HeaderRow.Cells[3].Text = "البريد الالكتروني";
                GridView1.HeaderRow.Cells[4].Text = "رمز المستخدم";
                GridView1.HeaderRow.Cells[5].Text = "نوع المستخدم";


            }
            else if((Session["lang"].ToString() == "en-US")){


            }
            
        }
        

  
        private void loadgrid()
        {
            try
            {
                SqlConnection con1 = new SqlConnection(scon);
                if (con1.State == ConnectionState.Closed)
                {
                    con1.Open();
                }
                string role = "User";
                string query = "select * from Users where Role=@role;";
                SqlCommand cmd = new SqlCommand(query, con1);
                cmd.Parameters.AddWithValue("@role", role);
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();
                con1.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
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
                string query = "select FullName from Users where ID=@ID;";
                SqlCommand cmd = new SqlCommand(query, con1);
                cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtpid.Text.Trim()));
              
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtname.Text = dr["FullName"].ToString();       // show Title

                }
                dr.Close();
                con1.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void GridView1_Load(object sender, EventArgs e)
        {
            loadgrid();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con1 = new SqlConnection(scon);
                if (con1.State == ConnectionState.Closed)
                {
                    con1.Open();
                }
                string query = @"delete from Users where ID=@id;";
                SqlCommand cmd = new SqlCommand(query, con1);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtpid.Text.Trim()));
                cmd.ExecuteNonQuery();
                txtname.Text = "";
                txtpid.Text = "";
                loadgrid();
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}