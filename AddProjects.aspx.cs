using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentArchive1
{
    public partial class AddProjects : System.Web.UI.Page
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
                ptit.InnerText = "عنوان المشروع";
                lblGY.InnerText = "سنة التخرج";
                lblpd.InnerText = "(عن ماذا يتكلم المشروع (بشكل مختصر ";
                lblsn1.InnerText = "اسم الطالب ";
                lblsn2.InnerText = "اسم الطالب ";
                lblsn3.InnerText = "اسم الطالب";
                lblsn4.InnerText = "اسم الطالب";
                lblsup.InnerText = "اسم مشرف المشروع";
                hadd.InnerText = "اضافة المشاريع";
                Button2.Text = "اضافة";
                
                
            }
            else if ((Session["lang"].ToString() == "en-US"))
            {


            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    SqlConnection con1 = new SqlConnection(scon);
                    if (con1.State == ConnectionState.Closed)
                    {
                        con1.Open();
                    }
                    String query = @"insert into Requests(ProjectTitle,SupervisorName,GraduationYear,ProjectDescription,fileData,Type) OUTPUT INSERTED.RequestID values(@title,@Sname,@GY,@PD,@FD,@Type);";
                    SqlCommand cmd = new SqlCommand(query, con1);
                    cmd.Parameters.AddWithValue("@title", txttitle.Text.Trim());
                    cmd.Parameters.AddWithValue("@Sname", txtsupname.Text.Trim());
                    cmd.Parameters.AddWithValue("@GY", txtGY.Text.Trim());
                    cmd.Parameters.AddWithValue("@PD", txtpd.Text.Trim());
                    byte[] filedata = null;
                   if(FileUpload1.HasFile)
                   {
                        using(BinaryReader br= new BinaryReader(FileUpload1.PostedFile.InputStream))
                        {
                            filedata = br.ReadBytes(FileUpload1.PostedFile.ContentLength);
                        }
                    }
                    cmd.Parameters.AddWithValue("@FD", (object)filedata ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Type","Add");
                    int reqid = (int)cmd.ExecuteScalar();
                    string querys = "insert into RequestStudents (RequestID,StudentName) values(@reqid,@SN);";
                    string[] students =
                    {
                        txtsn1.Text.Trim(),
                        txtsn2.Text.Trim(),
                        txtsn3.Text.Trim(),
                        txtsn4.Text.Trim(),
                    };
                    foreach(string s in students)
                    {
                        if (!string.IsNullOrWhiteSpace(s))
                        {
                            SqlCommand cmd1 = new SqlCommand(querys, con1);
                            cmd1.Parameters.AddWithValue("@reqid", reqid);
                            cmd1.Parameters.AddWithValue("@SN", s);
                            cmd1.ExecuteNonQuery();
                                }
                    }
                    con1.Close();
                    Response.Write("<script>alert('Your Request Has Been Recorded');</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }

            }
        }
    }
}