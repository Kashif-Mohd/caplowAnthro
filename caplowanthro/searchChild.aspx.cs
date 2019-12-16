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
    public partial class searchChild : System.Web.UI.Page
    {
        MySqlDataReader dreader;
        string ConDataBase = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "searchChild";
                txtdssid.Focus();
            }

        }

        public void showalert(string message)
        {
            string script = @"alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtdssid.Text.Length < 3)
            {
                showalert("Enter minimum 3 character or digit!");
            }
            else
            {
                ShowData();
            }
            txtdssid.Focus();
        }


        private void ShowData()
        {
            MySqlConnection con = new MySqlConnection(ConDataBase);
            try
            {

                con.Open();
                MySqlCommand cmd;
                if (radioChildStatus2.Checked == true)
                {
                    cmd = new MySqlCommand("select followup_id,mother_id,SUBSTRING_INDEX(SUBSTRING_INDEX(mother_id, ':', 2), ':', -1) as pw_id,child_id,concat(SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 1), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 2), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 4), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 5), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 6), ':', -1)) as dssid,followup_no,   pw_name,husband_name,dob,DATEDIFF(str_to_date(start_date, '%d-%m-%Y'), str_to_date(dob, '%d-%m-%Y')) as age,(CASE WHEN status= '1' THEN 'Done' WHEN status= '3' THEN 'Pending' END) as status,  DATE_FORMAT(str_to_date(start_date, '%d-%m-%Y'), '%d-%m-%Y') as start_date  ,DATE_FORMAT(DATE_SUB(str_to_date(end_date, '%d-%m-%Y'), interval 1 day), '%d-%m-%Y') as end_date 		from followups 					where concat(SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 1), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 2), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 4), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 5), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 6), ':', -1))  like '%" + txtdssid.Text + "%' and status!='2' order by followup_id", con);
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        {
                            sda.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                            con.Close();
                        }
                    }
                }
                else
                {
                    cmd = new MySqlCommand("select followup_id,mother_id,SUBSTRING_INDEX(SUBSTRING_INDEX(mother_id, ':', 2), ':', -1) as pw_id,child_id,concat(SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 1), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 2), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 4), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 5), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 6), ':', -1)) as dssid,followup_no,   pw_name,husband_name,dob,DATEDIFF(str_to_date(start_date, '%d-%m-%Y'), str_to_date(dob, '%d-%m-%Y')) as age,(CASE WHEN status= '1' THEN 'Done' WHEN status= '3' THEN 'Pending' END) as status, DATE_FORMAT(str_to_date(start_date, '%d-%m-%Y'), '%d-%m-%Y') as start_date ,DATE_FORMAT(DATE_SUB(str_to_date(end_date, '%d-%m-%Y'), interval 1 day), '%d-%m-%Y') as end_date 		from followups 					where         mother_id   like '%" + txtdssid.Text + "' and status!='2' order by followup_id", con);
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        {
                            sda.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                            con.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script type=\"text/javascript\">alert('" + ex.Message + "')</script>");
            }
            finally
            {
                con.Close();
            }
        }





        private void CheckLastPendingFollowups()
        {
            MySqlConnection con = new MySqlConnection(ConDataBase);
            try
            {
                con.Open();
                MySqlCommand cmd;
                cmd = new MySqlCommand("select min(followup_id) as id,min(cast(followup_no as UNSIGNED)) as followup_no  from followups where mother_id='" + Convert.ToString(Session["CP_mother_id"]) + "' and child_id='" + Convert.ToString(Session["CP_child_id"]) + "' and status=3", con);
                dreader = cmd.ExecuteReader();
                if (dreader.Read())
                {
                    Session["Attempt_followup_no"] = dreader["followup_no"].ToString();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script type=\"text/javascript\">alert('" + ex.Message + "')</script>");
            }
            finally
            {
                con.Close();
            }
        }



        protected void Link_Studyid(object sender, EventArgs e)
        {
            Session["CP_pwid"] = null;
            Session["CP_child_id"] = null;
            Session["CP_age"] = null;
            Session["CP_start_date"] = null;
            Session["CP_end_date"] = null;
            Session["Attempt_followup_no"] = null;
            
            Session["CP_mother_id"] = null;
            Session["CP_followup_no"] = null;



            string[] TextArgs = ((LinkButton)sender).CommandArgument.ToString().Split(new char[] { ',' });


            Session["CP_status"] = TextArgs[0];
            Session["CP_pw_id"] = TextArgs[1];
            Session["CP_child_id"] = TextArgs[2];
            Session["CP_age"] = TextArgs[3];
            Session["CP_start_date"] = TextArgs[4];
            Session["CP_end_date"] = TextArgs[5];

            Session["CP_mother_id"] = TextArgs[6];
            Session["CP_followup_no"] = TextArgs[7];

            //To Check Minimum Pending Followups to be Open            
            CheckLastPendingFollowups();

            if (TextArgs[0] == "Pending" && Convert.ToInt32(Session["Attempt_followup_no"]) == Convert.ToInt32(Session["CP_followup_no"]))
            {
                Response.Redirect("followupsSecA.aspx");
            }
            else if (TextArgs[0] == "Done")
            {
                showalert("Already Done!");
                txtdssid.Focus();
            }
            else
            {
                showalert("Please attempt the Followup no. " + Convert.ToString(Session["Attempt_followup_no"]) );
                txtdssid.Focus();
            }
        }




        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[8].Text == "Done")
                {
                    TableCell cell = e.Row.Cells[8];
                    cell.BackColor = System.Drawing.Color.FromName("#cef5cb");
                }
                if (e.Row.Cells[8].Text == "Pending")
                {
                    TableCell cell = e.Row.Cells[8];
                    cell.BackColor = System.Drawing.Color.FromName("#FFAB91");
                }
            }
        }



    }
}