using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentArchive1
{
    public partial class UpdateProject : System.Web.UI.Page
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
                hupd.InnerText = "تحديث المشروع";
                lblGY.InnerText = "تاريخ التخرج";
                lblpd.InnerText = "(عن ماذا يتكلم المشروع (بشكل مختصر ";
                lblpid.InnerText = "رقم المشروع";
                lblptit.InnerText = "عنوان المشروع";
                lblsn1.InnerText = "اسم الطالب";
                lblsn2.InnerText = "اسم الطالب";
                lblsn3.InnerText = "اسم الطالب";
                lblsn4.InnerText = "(اسم الطالب(ان وجد ";
                btnup.Text = "تحديث";
                Button1.Text = "بحث";
            }
            else if ((Session["lang"].ToString() == "en-US"))
            {


            }

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
          
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
                string query = @"select ProjectTitle, SupervisorName, GraduationYear, ProjectDescription from Projects where ID=@id;";
                SqlCommand cmd = new SqlCommand(query, con1);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtid.Text.Trim()));
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    string title = dr["ProjectTitle"].ToString();
                    string supervisor = dr["SupervisorName"].ToString();
                    string year = dr["GraduationYear"].ToString();
                    string description = dr["ProjectDescription"].ToString();
                   


                    dr.Close();
                    txttitle.Text = title;
                    txtsname.Text = supervisor;
                    txtGY.Text = year;
                    txtpd.Text = description;
                   

                    string selectStudents = "SELECT StudentName FROM Students WHERE ID = @id";
                    SqlCommand cmdStudents = new SqlCommand(selectStudents, con1);
                    cmdStudents.Parameters.AddWithValue("@id", Convert.ToInt32(txtid.Text.Trim()));

                    SqlDataReader dr2 = cmdStudents.ExecuteReader();

                    List<string> names = new List<string>();

                    while (dr2.Read())
                        names.Add(dr2["StudentName"].ToString());

                    dr2.Close();
                    if (names.Count > 0) txtsn1.Text = names[0];
                    if (names.Count > 1) txtsn2.Text = names[1];
                    if (names.Count > 2) txtsn3.Text = names[2];
                    if (names.Count > 3) txtsn4.Text = names[3];


                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void btnup_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con1 = new SqlConnection(scon);
                if (con1.State == ConnectionState.Closed)
                {
                    con1.Open();
                }
                int reqid;
                byte[] filedata = null;
                if (FileUpload1.HasFile)
                {
             

                    using (BinaryReader br = new BinaryReader(FileUpload1.PostedFile.InputStream))
                    {
                        filedata = br.ReadBytes(FileUpload1.PostedFile.ContentLength);
                    }
                    String query = @"insert into Requests(ProjectTitle,SupervisorName,GraduationYear,ProjectDescription,fileData,Type,ProjectID) OUTPUT INSERTED.RequestID  values(@title,@Sname,@GY,@PD,@FD,@Type,@id);";
                    SqlCommand cmd = new SqlCommand(query, con1);
                    cmd.Parameters.AddWithValue("@title", txttitle.Text.Trim());
                    cmd.Parameters.AddWithValue("@Sname", txtsname.Text.Trim());
                    cmd.Parameters.AddWithValue("@GY", txtGY.Text.Trim());
                    cmd.Parameters.AddWithValue("@PD", txtpd.Text.Trim());
                    cmd.Parameters.AddWithValue("@FD", filedata);
                    cmd.Parameters.AddWithValue("@Type", "update");
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtid.Text.Trim()));
                     reqid = (int)cmd.ExecuteScalar();

                }
                else
                {
                    String query = @"insert into Requests(ProjectTitle,SupervisorName,GraduationYear,ProjectDescription,Type,ProjectID) OUTPUT INSERTED.RequestID  values(@title,@Sname,@GY,@PD,@Type,@id);";
                    SqlCommand cmd = new SqlCommand(query, con1);
                    cmd.Parameters.AddWithValue("@title", txttitle.Text.Trim());
                    cmd.Parameters.AddWithValue("@Sname", txtsname.Text.Trim());
                    cmd.Parameters.AddWithValue("@GY", txtGY.Text.Trim());
                    cmd.Parameters.AddWithValue("@PD", txtpd.Text.Trim());
                  
                    cmd.Parameters.AddWithValue("@Type", "update");
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtid.Text.Trim()));
                     reqid = (int)cmd.ExecuteScalar();
                }
                string querys = "insert into RequestStudents (RequestID,StudentName,ProjectID) values(@reqid,@SN,@id);";
                string[] students =
                {
                        txtsn1.Text.Trim(),
                        txtsn2.Text.Trim(),
                        txtsn3.Text.Trim(),
                        txtsn4.Text.Trim(),
                    };
                foreach (string s in students)
                {
                    if (!string.IsNullOrWhiteSpace(s))
                    {
                        SqlCommand cmd1 = new SqlCommand(querys, con1);
                        cmd1.Parameters.AddWithValue("@reqid", reqid);
                        
                        cmd1.Parameters.AddWithValue("@SN", s);
                        cmd1.Parameters.AddWithValue("@id", Convert.ToInt32(txtid.Text.Trim()));
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
