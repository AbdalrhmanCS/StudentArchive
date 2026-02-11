using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace StudentArchive1
{
    public partial class AdminApprove : System.Web.UI.Page
    {
        string scon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            loadgrid();
            if (!IsPostBack)
            {
                lang();
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
                haa.InnerText = "الموافقة على الطلب";
                lblapt.InnerText = "نوع الطلب";
                lblpro.InnerText = "رقم المشروع";
                lblre.InnerText = "رقم الطلب";
                lblreqtable.InnerText = "جدول الطلبات";
                Button1.Text = "حذف من جدول الطلبات";
                Button2.Text = "اضافة";
                Button3.Text = "تحديث";
                Button4.Text = "حذف";
                Button5.Text = "تنزيل من جدول الطلبات";
                GridView1.HeaderRow.Cells[0].Text = "رقم الطلب";
                GridView1.HeaderRow.Cells[1].Text = "عنوان المشروع";
                GridView1.HeaderRow.Cells[2].Text = "اسم المشرف";
                GridView1.HeaderRow.Cells[3].Text = "سنة التخرج";
                GridView1.HeaderRow.Cells[4].Text = "نبذة عن المشروع";
                GridView1.HeaderRow.Cells[5].Text = "تاريخ الطلب";
                GridView1.HeaderRow.Cells[6].Text = "نوع الطلب";
                GridView1.HeaderRow.Cells[7].Text = "رقم المشروع";


            }
            else if ((Session["lang"].ToString() == "en-US"))
            {
                GridView1.HeaderRow.Cells[0].Text = "Request ID";
                GridView1.HeaderRow.Cells[1].Text = "Project Title";
                GridView1.HeaderRow.Cells[2].Text = "Supervisor Name";
                GridView1.HeaderRow.Cells[3].Text = "Graduation Year";
                GridView1.HeaderRow.Cells[4].Text = "Project Description";
                GridView1.HeaderRow.Cells[5].Text = "Request Date";
                GridView1.HeaderRow.Cells[6].Text = "Request Type";
                GridView1.HeaderRow.Cells[7].Text = "Project ID";

            }

        }

        protected void btngo_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con1 = new SqlConnection(scon);
                if (con1.State == ConnectionState.Closed)
                {
                    con1.Open();
                }
                string query = "select Type,ProjectID from Requests where RequestID=@ID;";
                SqlCommand cmd = new SqlCommand(query, con1);
                cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtreq.Text.Trim()));
                //  object result = cmd.ExecuteScalar();
                // txttype.Text = result.ToString();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txttype.Text = dr["Type"].ToString();       // show Type
                    txtpid.Text = dr["projectID"].ToString();  // show ProjectID
                }
                dr.Close();
                con1.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        protected void GridView1_Load(object sender, EventArgs e)
        {
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
                string query = @"select ProjectTitle, SupervisorName, GraduationYear, ProjectDescription, fileData from Requests where RequestID=@id;";
                SqlCommand cmd = new SqlCommand(query, con1);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtreq.Text.Trim()));
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    string title = dr["ProjectTitle"].ToString();
                    string supervisor = dr["SupervisorName"].ToString();
                    string year = dr["GraduationYear"].ToString();
                    string description = dr["ProjectDescription"].ToString();
                    byte[] fileData = dr["fileData"] as byte[];


                    dr.Close(); // close reader before inserting

                    // 2) Insert into Projects table
                    string insertQuery = @"
                    INSERT INTO Projects (ProjectTitle, SupervisorName, GraduationYear, ProjectDescription, fileData) OUTPUT INSERTED.ID
                    VALUES (@title, @supervisor, @year, @description, @fileData);";

                    SqlCommand insertCmd = new SqlCommand(insertQuery, con1);
                    insertCmd.Parameters.AddWithValue("@title", title);
                    insertCmd.Parameters.AddWithValue("@supervisor", supervisor);
                    insertCmd.Parameters.AddWithValue("@year", year);
                    insertCmd.Parameters.AddWithValue("@description", description);
                    insertCmd.Parameters.AddWithValue("@fileData", (object)fileData ?? DBNull.Value);


                    int proid = (int)insertCmd.ExecuteScalar();


                    string selectStudents = "SELECT StudentName FROM RequestStudents WHERE RequestID = @rid";
                    SqlCommand cmdStudents = new SqlCommand(selectStudents, con1);
                    cmdStudents.Parameters.AddWithValue("@rid", Convert.ToInt32(txtreq.Text.Trim()));

                    SqlDataReader dr2 = cmdStudents.ExecuteReader();

                    List<string> names = new List<string>();

                    while (dr2.Read())
                        names.Add(dr2["StudentName"].ToString());

                    dr2.Close();

                    // Insert each student into Students table
                    string insertStudent = "INSERT INTO Students (ID, StudentName) VALUES (@pid, @name)";

                    foreach (string name in names)
                    {
                        SqlCommand cmdInsertStudent = new SqlCommand(insertStudent, con1);
                        cmdInsertStudent.Parameters.AddWithValue("@pid", proid);
                        cmdInsertStudent.Parameters.AddWithValue("@name", name);
                        cmdInsertStudent.ExecuteNonQuery();
                    }
                    con1.Close();

                    Response.Write("<script>alert('Project and students added successfully!');</script>");
                }

            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
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
                string query = @"delete from Projects where ID=@id;";
                SqlCommand cmd = new SqlCommand(query, con1);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtpid.Text.Trim()));
                cmd.ExecuteNonQuery();
                string query1 = @"delete from Students where ID=@id;";
                SqlCommand cmd1 = new SqlCommand(query1, con1);
                cmd1.Parameters.AddWithValue("@id", Convert.ToInt32(txtpid.Text.Trim()));
                cmd1.ExecuteNonQuery();
                Response.Write("<script>alert('Project and students Deleted successfully!');</script>");
                con1.Close();


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void btnDFR_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con1 = new SqlConnection(scon);
                if (con1.State == ConnectionState.Closed)
                {
                    con1.Open();
                }
                string query = @"delete from Requests where RequestID=@id;";
                SqlCommand cmd = new SqlCommand(query, con1);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtreq.Text.Trim()));
                cmd.ExecuteNonQuery();
                string query1 = @"delete from RequestStudents where RequestID=@id;";
                SqlCommand cmd1 = new SqlCommand(query1, con1);
                cmd1.Parameters.AddWithValue("@id", Convert.ToInt32(txtreq.Text.Trim()));

                cmd1.ExecuteNonQuery();
                Response.Write("<script>alert('Request and request Students Deleted successfully!');</script>");
                con1.Close();
                loadgrid();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
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
                string query = "select * from Requests;";
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

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con1 = new SqlConnection(scon);
                if (con1.State == ConnectionState.Closed)
                {
                    con1.Open();
                }
                
                string query = @"select ProjectTitle, SupervisorName, GraduationYear, ProjectDescription, fileData from Requests where RequestID=@id;";
                SqlCommand cmd = new SqlCommand(query, con1);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtreq.Text.Trim()));
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    string title = dr["ProjectTitle"].ToString();
                    string supervisor = dr["SupervisorName"].ToString();
                    string year = dr["GraduationYear"].ToString();
                    string description = dr["ProjectDescription"].ToString();
                    byte[] fileData = dr["fileData"] as byte[];


                    dr.Close(); // close reader before inserting
                    string updateProj;
                    if (fileData!=null) {
                         updateProj = @"UPDATE Projects SET
                          ProjectTitle = @title,
                          SupervisorName = @sname,
                          GraduationYear = @gy,
                          ProjectDescription = @desc,
                          fileData = @fd
                          WHERE ID = @pid";
                    }
                    else
                    {
                        updateProj = @"UPDATE Projects SET
                          ProjectTitle = @title,
                          SupervisorName = @sname,
                          GraduationYear = @gy,
                          ProjectDescription = @desc
                          
                          WHERE ID = @pid";
                    }

                    SqlCommand cmdProj = new SqlCommand(updateProj, con1);
                    cmdProj.Parameters.AddWithValue("@pid", Convert.ToInt32(txtpid.Text.Trim()));
                    cmdProj.Parameters.AddWithValue("@title", title);
                    cmdProj.Parameters.AddWithValue("@sname", supervisor);
                    cmdProj.Parameters.AddWithValue("@gy", year);
                    cmdProj.Parameters.AddWithValue("@desc", description);
                    if (fileData != null)
                    {
                        cmdProj.Parameters.AddWithValue("@fd", fileData);

                    }
                    cmdProj.ExecuteNonQuery();

                    string getStuds = "SELECT StudentName FROM RequestStudents WHERE RequestID=@reqid";

                    SqlCommand cmdStuds = new SqlCommand(getStuds, con1);
                    cmdStuds.Parameters.AddWithValue("@reqid", Convert.ToInt32(txtreq.Text.Trim()));

                    SqlDataReader dr2 = cmdStuds.ExecuteReader();

                    List<string> students = new List<string>();

                    while (dr2.Read())
                    {
                        students.Add(dr2["StudentName"].ToString());
                    }
                    dr2.Close();

                    // 4. DELETE OLD STUDENTS FOR THIS PROJECT
                    SqlCommand cmdDel = new SqlCommand(
                        "DELETE FROM Students WHERE ID=@pid", con1);
                    cmdDel.Parameters.AddWithValue("@pid", Convert.ToInt32(txtpid.Text.Trim()));
                    cmdDel.ExecuteNonQuery();

                    // 5. INSERT NEW STUDENTS
                    string insertStud = @"INSERT INTO Students (ID, StudentName)
                              VALUES (@pid, @name)";

                    foreach (string name in students)
                    {
                        SqlCommand cmdIns = new SqlCommand(insertStud, con1);
                        cmdIns.Parameters.AddWithValue("@pid", Convert.ToInt32(txtpid.Text.Trim()));
                        cmdIns.Parameters.AddWithValue("@name", name);
                        cmdIns.ExecuteNonQuery();
                    }

                    con1.Close();

                    Response.Write("<script>alert('Project Updated Successfully');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

        }

        protected void btndoan_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con1 = new SqlConnection(scon);
                if (con1.State == ConnectionState.Closed)
                {
                    con1.Open();
                }

                string query = "SELECT fileData, ProjectTitle FROM Requests WHERE RequestID=@id;";
                SqlCommand cmd = new SqlCommand(query, con1);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtreq.Text.Trim()));

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    byte[] fileBytes = dr["fileData"] as byte[];
                    //  string title = dr["ProjectTitle"].ToString();
                    string title = dr["ProjectTitle"].ToString();
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

    

