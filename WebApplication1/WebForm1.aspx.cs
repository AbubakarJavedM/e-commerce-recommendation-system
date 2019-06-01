using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btny_ServerClick(object sender, EventArgs e)
        {
            //the user provides his/her login to login to the system
            string s = new DAO().login(login__username.Value.ToString(), login__password.Value.ToString());
            if (s.Length>0)
            {
                Session["user"] = s;
                Response.Redirect("WebForm2.aspx");
            }
            else
            {
                Response.Write("Invalid UserName or Password");
            }
        }

        protected void Submit2_ServerClick()
        {
            //string name = Text1.Value.ToString();
            //string pass = Password1.Value.ToString();
            //bool result = new DAO().addUser(name, pass);
            //if (result == false) { Response.Write("Username already exists"); }
            //else { Response.Write("User successfully registered"); }
        }
  

        protected void Unnamed_ServerClick1(object sender, EventArgs e)
        {
            Response.Redirect("WebForm3.aspx");
        }
    }
}