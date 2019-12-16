using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;


namespace caplowanthro
{
    public partial class Login : System.Web.UI.Page
    {
        MySqlDataReader dreader;
        string ConDataBase = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["CPusername"] = null;
            Session["team_id"] = null;
            Session["Role"] = null;
            txtUserNme.Focus();
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Loginn();
        }


        private void Loginn()
        {
            if (txtUserNme.Text == "")
            {
                Response.Write("<script type=\"text/javascript\">alert('Please Enter User Name!')</script>");
                txtUserNme.Focus();
            }

            else if (txtPass.Text == "")
            {
                Response.Write("<script type=\"text/javascript\">alert('Please Enter Password!')</script>");
                txtPass.Focus();
            }
            else if (LogSeach() == false)
            {
                Response.Write("<script>alert('Incorrect User Name or Password')</script>");
                txtPass.Text = "";
                txtPass.Focus();
            }
            else if (Security() == false)
            {
                Response.Write("<script>alert('You are doing some irrelevant thing, Complaint registered')</script>");
                txtPass.Text = "";
                txtPass.Focus();
            }
            else
            {
                Session["CPusername"] = txtUserNme.Text.ToUpper();                
                Response.Redirect("dashboard.aspx");

            }
        }


        public void showalert(string message)
        {
            string script = @"alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
        }



        //public bool FindUseRole()
        //{
        //    MySqlConnection con = new MySqlConnection(ConDataBase);
        //    try
        //    {
        //        con.Open();
        //        MySqlCommand cmd = new MySqlCommand("select * from team where username='" + txtUserNme.Text + "' and role='1'", con);
        //        dreader = cmd.ExecuteReader();
        //        if (dreader.Read())
        //        {

        //            return true;
        //        }
        //        con.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        showalert(ex.Message);
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //    return false;
        //}






        public bool Security()
        {
            MySqlConnection con = new MySqlConnection(ConDataBase);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select count(*) as total from team where user_name='" + txtUserNme.Text + "'", con);
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read() && dr["total"].ToString() == "1")
            {
                con.Close();
                return true;
            }
            con.Close();
            return false;
        }


        public bool LogSeach()
        {
            MySqlConnection con = new MySqlConnection(ConDataBase);
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * from team where password='" + txtPass.Text + "' and user_name='" + txtUserNme.Text + "'", con);
                dreader = cmd.ExecuteReader();
                if (dreader.Read())
                {
                    Session["team_id"] = dreader["team_id"].ToString();
                    Session["CP_Login_status"] = dreader["status"].ToString();
                    return true;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script type=\"text/javascript\">alert('" + ex.Message + "')</script>");
                Response.Write("<script>window.location.href='Login.aspx';</script>");
            }
            finally
            {
                con.Close();
            }
            return false;
        }
    }
}