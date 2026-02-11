using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentArchive1
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lang();
            }
         
                if (Session["Role"] == null)

                {
                    btnhome.Visible = false;
                    btnview.Visible = false;
                    btnadd.Visible = false;
                    btndelete.Visible = false;
                    btnupdate.Visible = false;
                    btnlogin.Visible = true;
                    btnsignup.Visible = true;
                    btnlogout.Visible = false;
                    btnhello.Visible = false;
                    btnAdmin.Visible = false;
                    btnAS.Visible = false;
                    btnUM.Visible = false;

                }
                else if (string.Equals(Session["Role"] as string, "User"))
                {
                    btnhome.Visible = true;
                    btnview.Visible = true;
                    btnadd.Visible = true;
                    btndelete.Visible = true;
                    btnupdate.Visible = true;
                    btnlogin.Visible = false;
                    btnsignup.Visible = false;
                    btnlogout.Visible = true;
                    btnhello.Visible = true;
                    btnAdmin.Visible = false;
                    btnAS.Visible = false;
                    btnUM.Visible = false;
                    btnhello.Text = "Hello " + Session["FullName"].ToString();
                }
                else if (string.Equals(Session["Role"] as string, "Admin"))
                {
                    btnhome.Visible = true;
                    btnview.Visible = true;
                    btnadd.Visible = true;
                    btndelete.Visible = true;
                    btnupdate.Visible = true;
                    btnlogin.Visible = false;
                    btnsignup.Visible = false;
                    btnlogout.Visible = true;
                    btnhello.Visible = true;
                    btnAdmin.Visible = true;
                    btnAS.Visible = true;
                    btnUM.Visible = true;
                    btnhello.Text = "Hello Admin";
                }
            
        }
        private void lang()

        {
            if (Session["lang"] == null)
            {
                if (!Request.Url.AbsolutePath.EndsWith("Language.aspx"))
                {
                    Response.Redirect("Language.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
                return;
            }

            if (Session["lang"].ToString() == "ar-IQ")
            {
                btnhome.Text = "الصفحة الرئيسية";
                btnadd.Text = "اضافة المشاريع";
                btnAdmin.Text = "موافقة المسؤول";
                btnAS.Text = "انشاء حساب بصفة مسؤول";
                btndelete.Text = "حذف المشاريع";
                btnlogin.Text = "تسجيل الدخول";
                btnlogout.Text = "تسجيل الخروج";
                btnsignup.Text = "انشاء حساب";
                btnUM.Text = "حذف المستخدمين";
                btnupdate.Text = "تحديث المشاريع";
                btnview.Text = "عرض المشاريع";
            }
            else if ((Session["lang"].ToString() == "en-US"))
            {


            }

        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminLogin.aspx");
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminApprove.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserLogin.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignUp.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session["FullName"] = "";
            Session["Role"] = null;
            btnview.Visible = false;
            btnadd.Visible = false;
            btndelete.Visible = false;
            btnupdate.Visible = false;
            btnlogin.Visible = true;
            btnsignup.Visible = true;
            btnlogout.Visible = false;
            btnhello.Visible = false;
            btnAdmin.Visible = false;
            btnAS.Visible = false;
            btnUM.Visible = false;
            btnhome.Visible = false;
            Response.Redirect("Language.aspx");

        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProfilePage.aspx");
        }

        protected void btnhome_click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void btnview_click(object sender, EventArgs e)
        {
            Response.Redirect("ViewPr.aspx");
        }

        protected void btnAdd_click(object sender, EventArgs e)
        {
            Response.Redirect("AddProjects.aspx");
        }

        protected void btnUpdate_click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateProject.aspx");
        }

        protected void btndelete_click(object sender, EventArgs e)
        {
            Response.Redirect("DeleteProject.aspx");
        }

        protected void Adminsig_click(object sender, EventArgs e)
        {
            Response.Redirect("AdminSignup.aspx");
        }

        protected void btnUM_click(object sender, EventArgs e)
        {
            Response.Redirect("UsersMangment.aspx");
        }
    }
}