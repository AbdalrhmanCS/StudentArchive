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
    public partial class HomePage : System.Web.UI.Page
    {
        string scon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            loadgrid();
            if (!IsPostBack)
            {
                GridView1.DataBind();
                lang();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadgrid();


           
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
           
                GridView1.HeaderRow.Cells[0].Text = "رقم المشروع";
                GridView1.HeaderRow.Cells[1].Text = "عنوان المشروع";
                GridView1.HeaderRow.Cells[2].Text = "اسم المشرف";
                GridView1.HeaderRow.Cells[3].Text = "سنة التخرج";
                GridView1.HeaderRow.Cells[4].Text = "نبذة عن المشروع";
                GridView1.HeaderRow.Cells[5].Text = "تاريخ الموافقة";
            }
            else if ((Session["lang"].ToString() == "en-US"))
            {

                GridView1.HeaderRow.Cells[0].Text = "Project ID";
                GridView1.HeaderRow.Cells[1].Text = "Project Title";
                GridView1.HeaderRow.Cells[2].Text = "Supervisor Name";
                GridView1.HeaderRow.Cells[3].Text = "Graduation Year";
                GridView1.HeaderRow.Cells[4].Text = "Project Description";
                GridView1.HeaderRow.Cells[5].Text = "Approval Date";
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
                string query = "select * from Projects;";
                SqlDataAdapter da = new SqlDataAdapter(query, con1);
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
    }
}