using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WebApplication1
{
    public partial class WebForm3 : System.Web.UI.Page
    {
    
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }
        [System.Web.Services.WebMethod]
        public static void addRate(string id, string rating,string name)
        {
         
             /// new DAO().updateRating(id,name,rating);
        }

        protected void done_ServerClick(object sender, EventArgs e)
        {
            string fname = Text4.Value.ToString();
            string lname = Text3.Value.ToString();
            string uname = Text1.Value.ToString();
            string pass = Password1.Value.ToString();

            if (new DAO().addUser(fname, lname, uname, pass))
            {
                Session["user"] = uname.ToString();
                Response.Redirect("WebForm2.aspx");
            }
            else {
                Response.Write("Username already exists");
            }
        }
    }
}