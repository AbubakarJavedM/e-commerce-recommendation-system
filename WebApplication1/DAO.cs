using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class DAO
    {
        public string connection;
        // this particular class i.e. DAO (database administrator object)
        //is responsible for all the interaction we need with the database

        public void insertData(product_info p)
        {
            //this method inserts data of a product in to the database
            this.connection = "datasource=localhost;username=root;password=;database=mobiles_data";
            MySqlConnection con = new MySqlConnection(this.connection);
            con.Open();
            string query = "insert into data(Name,Price,Rating,Site,URL) values(" + "'" + p.name + "','" + p.price + "','" + p.rating + "','" + p.site +"','"+p.imgurl+"') ";
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader rd = cmd.ExecuteReader();


        }
        public string login(string name, string pass)
        {
            // this method checks wethere the credentials provided by a user to login are correct or not
            this.connection = "datasource=localhost;username=root;password=;database=mobiles_data";
            MySqlConnection con = new MySqlConnection(connection);
            con.Open();
            string query = "SELECT * from user WHERE UserName='" + name + "' AND Password='" + pass + "'";
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader rd = cmd.ExecuteReader();

            if (rd.HasRows == true)
            {
                while (rd.Read())
                {
                     rd["UserName"].ToString();
                }
                return rd["UserName"].ToString();
            }


            else { return ""; }



        }

        public List<product_info> getAllProduct(string name)
        {
            //this method returns all the products whose name contains the word the user 
            List<product_info> P = new List<product_info>();
            this.connection = "datasource=localhost;username=root;password=;database=mobiles_data";
            MySqlConnection con = new MySqlConnection(connection);
            con.Open();
            string query = "SELECT * FROM data WHERE Name LIKE '%" + name + "%' ORDER BY Rating DESC;";
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                if (rd.HasRows)
                {
                    product_info p = new product_info();
                    p.ID = rd["ID"].ToString();
                    p.name = rd["Name"].ToString();
                    p.price = rd["Price"].ToString();
                    p.site = rd["Site"].ToString();
                    p.rating = double.Parse(rd["Rating"].ToString());
                    p.imgurl = rd["URL"].ToString();
                    P.Add(p);
                }
            }
            return P;
            //string connection = "datasource=localhost;username=root;password=;database=mobiles_data";
            //MySqlConnection con = new MySqlConnection(connection);
            //con.Open();
            //string query = "SELECT * FROM data WHERE Name LIKE '%" + name + "%'";
            //MySqlCommand cmd = con.CreateCommand();
            //cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "SELECT * FROM data WHERE Name LIKE '%" + name + "%'";
            //cmd.ExecuteNonQuery();

            //MySqlDataAdapter rd = new MySqlDataAdapter(cmd);
            //return rd;
        }
        public void updateRating(string id, string name, string rating)
        {
            try
            {
                double rate = int.Parse(rating);
                string r = null;
                this.connection = "datasource=localhost;username=root;password=;database=mobiles_data";
                MySqlConnection con = new MySqlConnection(this.connection);
                con.Open();


                string query = "insert into raterecord(ID,UserName,Rating) values(" + "'" + id + "','" + name + "','" + rating + "') ";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader rd = cmd.ExecuteReader();
                rd.Close();


                query = "SELECT Rating FROM data WHERE ID='" + id + "'";
                MySqlCommand cmd1 = new MySqlCommand(query, con);
                MySqlDataReader rd1 = cmd1.ExecuteReader();
                while (rd1.Read())
                {
                    r = rd1["Rating"].ToString();

                }
                rd1.Close();
                double newrate = double.Parse(r);
                rd1.Close();
                query = "SELECT AVG(Rating) as Rating from raterecord where ID='"+id+"'";
                MySqlCommand cmd2 = new MySqlCommand(query, con);
                MySqlDataReader rd2 = cmd2.ExecuteReader();
                while (rd2.Read())
                {
                    double d = double.Parse(rd2["Rating"].ToString());
                    d = d;
                    newrate =newrate+d;
                    newrate=newrate/2;
                    if (newrate > 5)
                    {
                        newrate = 5;
                    }
                    break;
                }

                rd2.Close();
                con.Close();
                this.connection = "datasource=localhost;username=root;password=;database=mobiles_data";
                MySqlConnection con1 = new MySqlConnection(connection);
                con1.Open();

                query = "Update data SET Rating='" + newrate + "' WHERE ID='" + id + "'";
                ///cmd3 = new MySqlCommand(query, con);

                MySqlCommand cmd3 = new MySqlCommand(query, con1);
                MySqlDataReader rd3 = cmd3.ExecuteReader();
                con1.Close();
                /// return "You successfully rated this product";
            }catch (Exception) { }
        }

  public bool addUser(string fname, string lname ,string uname,string pass)
        {
            this.connection = "datasource=localhost;username=root;password=;database=mobiles_data";
            MySqlConnection con = new MySqlConnection(this.connection);
            con.Open();


            string query = "insert into user(UserName,Password,FName,LName) values(" + "'" + uname + "','"  + pass + "','"+fname+"','"+lname+"') ";
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader rd = cmd.ExecuteReader();
                return true;
            }
            catch { return false; }
      
        }
      

        }

    }
