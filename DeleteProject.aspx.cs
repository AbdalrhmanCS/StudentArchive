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
    public partial class DeleteProject : System.Web.UI.Page
    {
        string scon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            loadgrid();
            if (!IsPostBack)
            {
               
                lang();
                lang2();
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
                hdel.InnerText = "حذف المشروع";
                hptaple.InnerText = "جدول المشاريع";
                lblpid.InnerText = "رقم المشروع";
                lbltit.InnerText = "عنوان المشروع";
                Button1.Text = "بحث";
                Button2.Text = "حذف";
            }
        }





        private void lang2()
        {
            if (GridView1.HeaderRow == null) return;
            
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
        protected void GridView1_Load(object sender, EventArgs e)
        {
            loadgrid();
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
                string query = "select ProjectTitle from Projects where ID=@ID;";
                SqlCommand cmd = new SqlCommand(query, con1);
                cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtpid.Text.Trim()));
                //  object result = cmd.ExecuteScalar();
                // txttype.Text = result.ToString();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txttitle.Text = dr["ProjectTitle"].ToString();       // show Title
                   
                }
                dr.Close();
                con1.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
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
                string query = @"select ProjectTitle, SupervisorName, GraduationYear, ProjectDescription from Projects where ID=@id;";
                SqlCommand cmd = new SqlCommand(query, con1);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtpid.Text.Trim()));
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    string title = dr["ProjectTitle"].ToString();
                    string supervisor = dr["SupervisorName"].ToString();
                    string year = dr["GraduationYear"].ToString();
                    string description = dr["ProjectDescription"].ToString();



                    dr.Close(); // close reader before inserting

                    // 2) Insert into Requests table
                    string insertQuery = @"
                    INSERT INTO Requests (ProjectTitle, SupervisorName, GraduationYear, ProjectDescription, Type,ProjectID)
                    VALUES (@title, @supervisor, @year, @description, @Type,@ID);";

                    SqlCommand insertCmd = new SqlCommand(insertQuery, con1);
                    insertCmd.Parameters.AddWithValue("@title", title);
                    insertCmd.Parameters.AddWithValue("@supervisor", supervisor);
                    insertCmd.Parameters.AddWithValue("@year", year);
                    insertCmd.Parameters.AddWithValue("@description", description);
                    insertCmd.Parameters.AddWithValue("@Type", "Delete");
                    insertCmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtpid.Text.Trim()));
                    insertCmd.ExecuteNonQuery();
                    con1.Close();
                    Response.Write("<script>alert('Your Request Has Been Recorded');</script>");
                }
            }catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
            }
    }
}