using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentArchive1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Session["lang"] = "en-US";
            Response.Redirect("UserLogin.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["lang"] = "ar-IQ";
            Response.Redirect("UserLogin.aspx");
        }
    }
}