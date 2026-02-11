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
    public partial class ViewPr : System.Web.UI.Page
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
                hviewp.InnerText = "عرض المشروع";
                lbln.Text = "الاسم";
                lbln2.Text = "الاسم";
                lbln3.Text = "الاسم";
                lbln4.Text = "الاسم";
                lblsu.Text = "اسم المشرف";
                lblg.Text = "تاريخ التخرج";
                lblpid.InnerText = "رقم المشروع";
                Button1.Text = "تحميل المشروع";
                Button2.Text = "عرض";
                
            }
            else if ((Session["lang"].ToString() == "en-US"))
            {


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
                string query = @"select ProjectTitle, SupervisorName, GraduationYear from Projects where ID=@id;";
                SqlCommand cmd = new SqlCommand(query, con1);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtid.Text.Trim()));
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    string title = dr["ProjectTitle"].ToString();
                    string supervisor = dr["SupervisorName"].ToString();
                    string year = dr["GraduationYear"].ToString();
                    



                    dr.Close();
                    lbltitle.Text = title;
                    lblsupn.Text = supervisor;
                    lblGY.Text = year;

                    string selectStudents = "SELECT StudentName FROM Students WHERE ID = @id";
                    SqlCommand cmdStudents = new SqlCommand(selectStudents, con1);
                    cmdStudents.Parameters.AddWithValue("@id", Convert.ToInt32(txtid.Text.Trim()));

                    SqlDataReader dr2 = cmdStudents.ExecuteReader();

                    List<string> names = new List<string>();

                    while (dr2.Read())
                        names.Add(dr2["StudentName"].ToString());

                    dr2.Close();
                    if (names.Count > 0) lblnm1.Text = names[0];
                    if (names.Count > 1) lblnm2.Text = names[1];
                    if (names.Count > 2) lblnm3.Text = names[2];
                    if (names.Count > 3) lblnm4.Text = names[3];


                    con1.Close();
                    
                }
            }
            catch(Exception ex)
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

                string query = "SELECT fileData, ProjectTitle FROM Projects WHERE ID=@id;";
                SqlCommand cmd = new SqlCommand(query, con1);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtid.Text.Trim()));

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    byte[] fileBytes = dr["fileData"] as byte[];
                    //  string title = dr["ProjectTitle"].ToString();
                    string title = dr["ProjectTitle"].ToString() ;
                    if (fileBytes != null && fileBytes.Length > 0)
                    {
                        // Detect file type by magic number
                        string extension = ".bin"; // default fallback

                        if (fileBytes.Length >= 4)
                        {
                            // PDF files start with %PDF
                            if (fileBytes[0] == 0x25 && fileBytes[1] == 0x50 && fileBytes[2] == 0x44 && fileBytes[3] == 0x46)
                            {
                                extension = ".pdf";
                            }
                            // DOCX files (Office Open XML) are ZIP files starting with PK
                            else if (fileBytes[0] == 0x50 && fileBytes[1] == 0x4B)
                            {
                                extension = ".docx";
                            }
                        }

                        string fileName = title + extension;

                        if (fileBytes != null)
                        {
                            // Change extension if needed

                            Response.Clear();
                            Response.ContentType = "application/octet-stream";
                            Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
                            Response.BinaryWrite(fileBytes);
                            Response.End();
                        }
                        else
                        {
                            Response.Write("<script>alert('No file found for this project');</script>");
                        }
                    }

                    dr.Close();
                    con1.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
      

    }
}
