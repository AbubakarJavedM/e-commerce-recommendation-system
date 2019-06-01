using AjaxControlToolkit;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void searchbtn_ServerClick(object sender, EventArgs e)
        {
            Label1.Text = "";
            string text = str.Value;// search.Value;
            DAO dao = new DAO();
            List<product_info> P = new List<product_info>();
            P = dao.getAllProduct(text);
            if (P.Count < 5)
            {
                crawl c = new crawl();
            c.crawl_gsm(text);
       c.crawl_whatmobile(text);
            c.crawl_daraz(text);
                P = dao.getAllProduct(text);
                string str = "font-size:0; white-space:nowrap; display: inline-block; width: 250px; height: 50px; overflow: hidden;position: relative;background: url('data:image/svg+xml;base64,PHN2ZyB2ZXJzaW9uPSIxLjEiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyIgeG1sbnM6eGxpbms9Imh0dHA6Ly93d3cudzMub3JnLzE5OTkveGxpbmsiIHg9IjBweCIgeT0iMHB4IiB3aWR0aD0iMjBweCIgaGVpZ2h0PSIyMHB4IiB2aWV3Qm94PSIwIDAgMjAgMjAiIGVuYWJsZS1iYWNrZ3JvdW5kPSJuZXcgMCAwIDIwIDIwIiB4bWw6c3BhY2U9InByZXNlcnZlIj48cG9seWdvbiBmaWxsPSIjREREREREIiBwb2ludHM9IjEwLDAgMTMuMDksNi41ODMgMjAsNy42MzkgMTUsMTIuNzY0IDE2LjE4LDIwIDEwLDE2LjU4MyAzLjgyLDIwIDUsMTIuNzY0IDAsNy42MzkgNi45MSw2LjU4MyAiLz48L3N2Zz4=');background-size:contain;i{opacity: 0;position: absolute;left: 0;top:0;height: 100 %; width: 20 %;z-index: 1; background:url('data:image/svg+xml;base64,PHN2ZyB2ZXJzaW9uPSIxLjEiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyIgeG1sbnM6eGxpbms9Imh0dHA6Ly93d3cudzMub3JnLzE5OTkveGxpbmsiIHg9IjBweCIgeT0iMHB4IiB3aWR0aD0iMjBweCIgaGVpZ2h0PSIyMHB4IiB2aWV3Qm94PSIwIDAgMjAgMjAiIGVuYWJsZS1iYWNrZ3JvdW5kPSJuZXcgMCAwIDIwIDIwIiB4bWw6c3BhY2U9InByZXNlcnZlIj48cG9seWdvbiBmaWxsPSIjRkZERjg4IiBwb2ludHM9IjEwLDAgMTMuMDksNi41ODMgMjAsNy42MzkgMTUsMTIuNzY0IDE2LjE4LDIwIDEwLDE2LjU4MyAzLjgyLDIwIDUsMTIuNzY0IDAsNy42MzkgNi45MSw2LjU4MyAiLz48L3N2Zz4=');background-size:contain; ";
                string name = Session["user"].ToString();
                for (int i = 0; i < P.Count; i++)
                {
                    //Label1.Text += "<tr class='mtr' style='color:white;'><td  class='col-lg-1'>" + P[i].ID + "</td><td rowspan='3'  class='col-lg-5'>" + P[i].name + "</td>"
                    //         + "<td class='col-lg-2'>" + P[i].price + "</td>"
                    //         +"<td><span class='star-rating' style="+str+">"
                    //         + "<input type = 'radio' name = 'rating' value='1'/>"
                    //         + "<input type = 'radio' name = 'rating' value='2'/>"
                    //         + "<input type = 'radio' name = 'rating' value='3'/>"
                    //         + "<input type = 'radio' name = 'rating' value = '4'/>"
                    //         + "<input type = 'radio' name = 'rating' value='5'/>"
                    //         + "</span ></td></tr>";

                    //Label1.Text += "<tr class='mtr' style='color:white;'><td  class='col-lg-1'>" + P[i].ID + "</td><td rowspan='3'  class='col-lg-5'>" + P[i].name + "</td>"
                    //       + "<td class='col-lg-2'>" + P[i].price + "</td>"
                    //       + "<td>"
                    //       + "<div class='star' style=''>"
                    //       + "<span class='it fa fa-star-o star'></span>"
                    //       + "<span class='it fa fa-star-o star'></span>"
                    //       + "<span class='it fa fa-star-o star'></span>"
                    //       + "<span class='it fa fa-star-o star'></span>"
                    //       + "<span class='it fa fa-star-o star'></span>"
                    //       + "</div ></td></tr>";
                    //Label2.Text="<script type='text/javascript'>myfun(3)</script>";

                    string str2 = "";
                    for (int x = 0; x < Convert.ToInt32(P[i].rating); x++)
                    {
                        str2 += "<span class='it fa fa-star-o star'style='background-color:#2c3338;'></span>";
                    }
                    //<td  class='col-lg-1'>" + P[i].ID + "</td>
                    Label1.Text += "<tr height='180px' class='mtr' style='color:white;'><td class='col-lg-3' style='height:100%;'><img src=" + P[i].imgurl + " style='width:50%;height:100%;'/></td><td  class='col-lg-3'>" + P[i].name + "</td>"
                                                                + "<td class='col-lg-1'>" + P[i].price + "</td>"
                                                                + "<td class= 'col-lg-1' width='130px'>"
                                                                + "<div class='star' style='color:gold;margin-left:25px;'>"
                                                                + str2 + "</div></td>"
                                                                + "<td class='col-lg-2' style='margin-left:10px;'><div><select id='" + P[i].ID + "' onchange='me(" + P[i].ID + ")' class='form-control pyy'>"
                                                                 + "<option value = '0'> Rate </option>"
                                                                + "<option value = '1'> 1 </option>"
                                                                + "<option value = '2'> 2 </option>"
                                                                + "<option value = '3'> 3 </option>"
                                                                + "<option value = '4'> 4 </option>"
                                                                + "<option value = '5'> 5 </option>"
                                                                + "</select></div></td><td class='col-lg-1' style='margin-left: 30px;cursor: pointer;'><a href=" + P[i].site + ">Visit Website</a></td></tr>";

                    ///<span id='count'>0</span>


                }
            }

            else
            {
                string str= "font-size:0; white-space:nowrap; display: inline-block; width: 250px; height: 50px; overflow: hidden;position: relative;background: url('data:image/svg+xml;base64,PHN2ZyB2ZXJzaW9uPSIxLjEiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyIgeG1sbnM6eGxpbms9Imh0dHA6Ly93d3cudzMub3JnLzE5OTkveGxpbmsiIHg9IjBweCIgeT0iMHB4IiB3aWR0aD0iMjBweCIgaGVpZ2h0PSIyMHB4IiB2aWV3Qm94PSIwIDAgMjAgMjAiIGVuYWJsZS1iYWNrZ3JvdW5kPSJuZXcgMCAwIDIwIDIwIiB4bWw6c3BhY2U9InByZXNlcnZlIj48cG9seWdvbiBmaWxsPSIjREREREREIiBwb2ludHM9IjEwLDAgMTMuMDksNi41ODMgMjAsNy42MzkgMTUsMTIuNzY0IDE2LjE4LDIwIDEwLDE2LjU4MyAzLjgyLDIwIDUsMTIuNzY0IDAsNy42MzkgNi45MSw2LjU4MyAiLz48L3N2Zz4=');background-size:contain;i{opacity: 0;position: absolute;left: 0;top:0;height: 100 %; width: 20 %;z-index: 1; background:url('data:image/svg+xml;base64,PHN2ZyB2ZXJzaW9uPSIxLjEiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyIgeG1sbnM6eGxpbms9Imh0dHA6Ly93d3cudzMub3JnLzE5OTkveGxpbmsiIHg9IjBweCIgeT0iMHB4IiB3aWR0aD0iMjBweCIgaGVpZ2h0PSIyMHB4IiB2aWV3Qm94PSIwIDAgMjAgMjAiIGVuYWJsZS1iYWNrZ3JvdW5kPSJuZXcgMCAwIDIwIDIwIiB4bWw6c3BhY2U9InByZXNlcnZlIj48cG9seWdvbiBmaWxsPSIjRkZERjg4IiBwb2ludHM9IjEwLDAgMTMuMDksNi41ODMgMjAsNy42MzkgMTUsMTIuNzY0IDE2LjE4LDIwIDEwLDE2LjU4MyAzLjgyLDIwIDUsMTIuNzY0IDAsNy42MzkgNi45MSw2LjU4MyAiLz48L3N2Zz4=');background-size:contain; ";
                string name = Session["user"].ToString();
                for (int i = 0; i < P.Count; i++)
                {
                    //Label1.Text += "<tr class='mtr' style='color:white;'><td  class='col-lg-1'>" + P[i].ID + "</td><td rowspan='3'  class='col-lg-5'>" + P[i].name + "</td>"
                    //         + "<td class='col-lg-2'>" + P[i].price + "</td>"
                    //         +"<td><span class='star-rating' style="+str+">"
                    //         + "<input type = 'radio' name = 'rating' value='1'/>"
                    //         + "<input type = 'radio' name = 'rating' value='2'/>"
                    //         + "<input type = 'radio' name = 'rating' value='3'/>"
                    //         + "<input type = 'radio' name = 'rating' value = '4'/>"
                    //         + "<input type = 'radio' name = 'rating' value='5'/>"
                    //         + "</span ></td></tr>";

                    //Label1.Text += "<tr class='mtr' style='color:white;'><td  class='col-lg-1'>" + P[i].ID + "</td><td rowspan='3'  class='col-lg-5'>" + P[i].name + "</td>"
                    //       + "<td class='col-lg-2'>" + P[i].price + "</td>"
                    //       + "<td>"
                    //       + "<div class='star' style=''>"
                    //       + "<span class='it fa fa-star-o star'></span>"
                    //       + "<span class='it fa fa-star-o star'></span>"
                    //       + "<span class='it fa fa-star-o star'></span>"
                    //       + "<span class='it fa fa-star-o star'></span>"
                    //       + "<span class='it fa fa-star-o star'></span>"
                    //       + "</div ></td></tr>";
                    //Label2.Text="<script type='text/javascript'>myfun(3)</script>";

                    string str2 = "";
                    for (int x = 0; x < Convert.ToInt32(P[i].rating); x++)
                    {
                        str2 += "<span class='it fa fa-star-o star'style='background-color:#2c3338;'></span>";
                    }
                    Label1.Text += "<tr height='180px' class='mtr' style='color:white;'><td class='col-lg-3' style='height:100%;'><img src=" + P[i].imgurl + " style='width:50%;height:100%;'/></td><td  class='col-lg-3'>" + P[i].name + "</td>"
                                             + "<td class='col-lg-1'>" + P[i].price + "</td>"
                                             + "<td class= 'col-lg-1' width='130px'>"
                                             + "<div class='star' style='color:gold;margin-left:25px;'>"
                                             + str2 + "</div></td>"
                                             + "<td class='col-lg-2' style='margin-left:10px;'><div><select id='" + P[i].ID + "' onchange='me(" + P[i].ID + ")' class='form-control pyy'>"
                                              + "<option value = '0'> Rate </option>"
                                             + "<option value = '1'> 1 </option>"
                                             + "<option value = '2'> 2 </option>"
                                             + "<option value = '3'> 3 </option>"
                                             + "<option value = '4'> 4 </option>"
                                             + "<option value = '5'> 5 </option>"
                                             + "</select></div></td><td class='col-lg-1' style='margin-left: 30px;cursor: pointer;'><a href="+P[i].site+">Visit Website</a></td></tr>";

                    ///<span id='count'>0</span>


                }
                //new DAO().updateRating("194","admin","5");

            }
        }
        /// List<product_info> P = new List<product_info>();
        //  DataTable dt = new DataTable();

        //    MySqlDataAdapter rd = dao.getAllProduct(text);
        //    rd.Fill(dt);
        //GridView1.DataSource = dt;
        //GridView1.DataBind();
        //con.Close();


    
    [System.Web.Services.WebMethod]
    public static void addRate(string id, string rating, string name)
    {

          
            new DAO().updateRating(id,name,rating);
    }



    protected void Unnamed_ServerClick()
        {

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
    }
}

/*
 <!--  <td runat = "server" id="a1" class="col-lg-1">#</td>
                        <td id = "a2" class="col-lg-5">Test Points</td>
                         <td id = "a3" class="col-lg-2">10</td>
                        
                      <td class="col-lg-2">
                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="star-rating">
                                        <span class="fa fa-star-o" data-rating="1"></span>
                                        <span class="fa fa-star-o" data-rating="2"></span>
                                        <span class="fa fa-star-o" data-rating="3"></span>
                                        <span class="fa fa-star-o" data-rating="4"></span>
                                        <span class="fa fa-star-o" data-rating="5"></span>
                                        <input id = "a4" runat="server" type="hidden" name="whatever1" class="rating-value" value="2.56"/>
                                    </div>
                                </div>
                            </div>

                        </td>
                        <td class="col-lg-2">
                            <div class="row">
                                    <div class="col-lg-12">
                                        <div class="star-rating">
                                  
                                            <span class="fa fa-star-o" data-rating="1"></span>
                                            <span class="fa fa-star-o" data-rating="2"></span>
                                            <span class="fa fa-star-o" data-rating="3"></span>
                                            <span class="fa fa-star-o" data-rating="4"></span>
                                            <span class="fa fa-star-o" data-rating="5"></span>
                                            <input id = "Hidden1" type="hidden" runat="server" name="whatever1" class="rating-value" value="2.56"/>
                                        </div>
                                    </div>
                                </div>
                        </td>-->
                        */
