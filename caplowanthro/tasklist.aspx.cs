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
    public partial class tasklist : System.Web.UI.Page
    {
        string ConDataBase = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateFormatPageLoad();
                Session["WebForm"] = "taskList";
                ShowData();
                txtDSSID.Focus();
            }
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtCalndrDate.Enabled = !CheckBox1.Checked;
            txtCalndrDate1.Enabled = !CheckBox1.Checked;
        }


        private void DateFormatPageLoad()
        {
            txtCalndrDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            txtCalndrDate1.Text = DateTime.Now.ToString("dd-MM-yyyy");
            txtCalndrDate.Attributes.Add("readonly", "readonly");
            txtCalndrDate1.Attributes.Add("readonly", "readonly");
            txtCalndrDate.Enabled = true;
            txtCalndrDate1.Enabled = true;
            CheckBox1.Checked = false;
        }


        public void showalert(string message)
        {
            string script = @"alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ShowData();
            txtDSSID.Focus();
        }


        private void ShowData()
        {
            MySqlConnection con = new MySqlConnection(ConDataBase);
            try
            {
                if (byEndDate.Checked == false)
                {
                    if (CheckBox1.Checked == true)
                    {
                        con.Open();
                        MySqlCommand cmd;
                        cmd = new MySqlCommand("select followup_id,mother_id,child_id,SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1) as block,concat(SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 1), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 2), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 4), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 5), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 6), ':', -1)) as dssid,followup_no,   pw_name,husband_name,dob,DATEDIFF(str_to_date(start_date, '%d-%m-%Y'), str_to_date(dob, '%d-%m-%Y')) as age, DATE_FORMAT(str_to_date(start_date, '%d-%m-%Y'), '%d-%m-%Y') as start_date ,DATE_FORMAT(DATE_SUB(str_to_date(end_date, '%d-%m-%Y'), interval 1 day), '%d-%m-%Y') as end_date 	from followups where status=3 and str_to_date(start_date, '%d-%m-%Y') <= CURDATE() and concat(SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 1), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 2), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 4), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 5), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 6), ':', -1)) like '%" + txtDSSID.Text + "%'  order by SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1),mother_id,child_id,followup_id;", con);
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
                        con.Open();
                        MySqlCommand cmd;
                        cmd = new MySqlCommand("select followup_id,mother_id,child_id,SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1) as block,concat(SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 1), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 2), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 4), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 5), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 6), ':', -1)) as dssid,followup_no,   pw_name,husband_name,dob,DATEDIFF(str_to_date(start_date, '%d-%m-%Y'), str_to_date(dob, '%d-%m-%Y')) as age, DATE_FORMAT(str_to_date(start_date, '%d-%m-%Y'), '%d-%m-%Y') as start_date ,DATE_FORMAT(DATE_SUB(str_to_date(end_date, '%d-%m-%Y'), interval 1 day), '%d-%m-%Y') as end_date 	from followups where status=3 and str_to_date(start_date, '%d-%m-%Y') <= CURDATE() and concat(SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 1), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 2), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 4), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 5), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 6), ':', -1)) like '%" + txtDSSID.Text + "%' and (str_to_date(start_date, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  order by SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1),mother_id,child_id,followup_id;", con);
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

                else
                {
                    if (CheckBox1.Checked == true)
                    {
                        con.Open();
                        MySqlCommand cmd;
                        cmd = new MySqlCommand("select followup_id,mother_id,child_id,SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1) as block,concat(SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 1), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 2), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 4), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 5), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 6), ':', -1)) as dssid,followup_no,   pw_name,husband_name,dob,DATEDIFF(str_to_date(start_date, '%d-%m-%Y'), str_to_date(dob, '%d-%m-%Y')) as age, DATE_FORMAT(str_to_date(start_date, '%d-%m-%Y'), '%d-%m-%Y') as start_date ,DATE_FORMAT(DATE_SUB(str_to_date(end_date, '%d-%m-%Y'), interval 1 day), '%d-%m-%Y') as end_date 	from followups where status=3 and str_to_date(start_date, '%d-%m-%Y') <= CURDATE() and concat(SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 1), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 2), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 4), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 5), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 6), ':', -1)) like '%" + txtDSSID.Text + "%'  order by SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1),mother_id,child_id,followup_id;", con);
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
                        con.Open();
                        MySqlCommand cmd;
                        cmd = new MySqlCommand("select followup_id,mother_id,child_id,SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1) as block,concat(SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 1), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 2), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 4), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 5), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 6), ':', -1)) as dssid,followup_no,   pw_name,husband_name,dob,DATEDIFF(str_to_date(start_date, '%d-%m-%Y'), str_to_date(dob, '%d-%m-%Y')) as age, DATE_FORMAT(str_to_date(start_date, '%d-%m-%Y'), '%d-%m-%Y') as start_date ,DATE_FORMAT(DATE_SUB(str_to_date(end_date, '%d-%m-%Y'), interval 1 day), '%d-%m-%Y') as end_date 	from followups where status=3 and str_to_date(start_date, '%d-%m-%Y') <= CURDATE() and concat(SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 1), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 2), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 4), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 5), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 6), ':', -1)) like '%" + txtDSSID.Text + "%' and (DATE_SUB(str_to_date(end_date, '%d-%m-%Y'), interval 1 day) between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  order by SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1),mother_id,child_id,followup_id;", con);
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





        protected void btnExport_Click(object sender, EventArgs e)
        {
            ShowData();
            if (GridView1.Rows.Count != 0)
            {
                ExcelExport();
            }
            txtDSSID.Focus();
        }


        public void ExcelExportMessage()
        {
            if (txtDSSID.Text != "")
            {
                GridView2.Caption = "DSSID, Search by: " + txtDSSID.Text;
            }
        }


        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }



        private void Exportdata()
        {
            MySqlConnection con = new MySqlConnection(ConDataBase);
            try
            {
                if (byEndDate.Checked == false)
                {
                    if (CheckBox1.Checked == true)
                    {
                        con.Open();
                        MySqlCommand cmd;
                        cmd = new MySqlCommand("select followup_id,mother_id,child_id,SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1) as block,concat(SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 1), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 2), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 4), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 5), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 6), ':', -1)) as dssid,followup_no,   pw_name,husband_name,dob,DATEDIFF(str_to_date(start_date, '%d-%m-%Y'), str_to_date(dob, '%d-%m-%Y')) as age, DATE_FORMAT(str_to_date(start_date, '%d-%m-%Y'), '%d-%m-%Y') as start_date ,DATE_FORMAT(DATE_SUB(str_to_date(end_date, '%d-%m-%Y'), interval 1 day), '%d-%m-%Y') as end_date 	from followups where status=3 and str_to_date(start_date, '%d-%m-%Y') <= CURDATE() and concat(SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 1), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 2), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 4), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 5), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 6), ':', -1)) like '%" + txtDSSID.Text + "%'  order by SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1),mother_id,child_id,followup_id;", con);
                        MySqlDataAdapter sda = new MySqlDataAdapter();
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            DataTable dt = new DataTable();
                            {
                                sda.Fill(dt);
                                GridView2.DataSource = dt;
                                GridView2.DataBind();
                                con.Close();
                            }
                        }
                    }
                    else
                    {
                        con.Open();
                        MySqlCommand cmd;
                        cmd = new MySqlCommand("select followup_id,mother_id,child_id,SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1) as block,concat(SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 1), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 2), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 4), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 5), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 6), ':', -1)) as dssid,followup_no,   pw_name,husband_name,dob,DATEDIFF(str_to_date(start_date, '%d-%m-%Y'), str_to_date(dob, '%d-%m-%Y')) as age, DATE_FORMAT(str_to_date(start_date, '%d-%m-%Y'), '%d-%m-%Y') as start_date ,DATE_FORMAT(DATE_SUB(str_to_date(end_date, '%d-%m-%Y'), interval 1 day), '%d-%m-%Y') as end_date 	from followups where status=3 and str_to_date(start_date, '%d-%m-%Y') <= CURDATE() and concat(SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 1), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 2), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 4), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 5), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 6), ':', -1)) like '%" + txtDSSID.Text + "%' and (str_to_date(start_date, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  order by SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1),mother_id,child_id,followup_id;", con);
                        MySqlDataAdapter sda = new MySqlDataAdapter();
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            DataTable dt = new DataTable();
                            {
                                sda.Fill(dt);
                                GridView2.DataSource = dt;
                                GridView2.DataBind();
                                con.Close();
                            }
                        }
                    }
                }

                else
                {
                    if (CheckBox1.Checked == true)
                    {
                        con.Open();
                        MySqlCommand cmd;
                        cmd = new MySqlCommand("select followup_id,mother_id,child_id,SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1) as block,concat(SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 1), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 2), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 4), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 5), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 6), ':', -1)) as dssid,followup_no,   pw_name,husband_name,dob,DATEDIFF(str_to_date(start_date, '%d-%m-%Y'), str_to_date(dob, '%d-%m-%Y')) as age, DATE_FORMAT(str_to_date(start_date, '%d-%m-%Y'), '%d-%m-%Y') as start_date ,DATE_FORMAT(DATE_SUB(str_to_date(end_date, '%d-%m-%Y'), interval 1 day), '%d-%m-%Y') as end_date 	from followups where status=3 and str_to_date(start_date, '%d-%m-%Y') <= CURDATE() and concat(SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 1), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 2), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 4), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 5), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 6), ':', -1)) like '%" + txtDSSID.Text + "%'  order by SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1),mother_id,child_id,followup_id;", con);
                        MySqlDataAdapter sda = new MySqlDataAdapter();
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            DataTable dt = new DataTable();
                            {
                                sda.Fill(dt);
                                GridView2.DataSource = dt;
                                GridView2.DataBind();
                                con.Close();
                            }
                        }
                    }
                    else
                    {
                        con.Open();
                        MySqlCommand cmd;
                        cmd = new MySqlCommand("select followup_id,mother_id,child_id,SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1) as block,concat(SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 1), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 2), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 4), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 5), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 6), ':', -1)) as dssid,followup_no,   pw_name,husband_name,dob,DATEDIFF(str_to_date(start_date, '%d-%m-%Y'), str_to_date(dob, '%d-%m-%Y')) as age, DATE_FORMAT(str_to_date(start_date, '%d-%m-%Y'), '%d-%m-%Y') as start_date ,DATE_FORMAT(DATE_SUB(str_to_date(end_date, '%d-%m-%Y'), interval 1 day), '%d-%m-%Y') as end_date 	from followups where status=3 and str_to_date(start_date, '%d-%m-%Y') <= CURDATE() and concat(SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 1), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 2), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 4), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 5), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 6), ':', -1)) like '%" + txtDSSID.Text + "%' and (DATE_SUB(str_to_date(end_date, '%d-%m-%Y'), interval 1 day) between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  order by SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1),mother_id,child_id,followup_id;", con);
                        MySqlDataAdapter sda = new MySqlDataAdapter();
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            DataTable dt = new DataTable();
                            {
                                sda.Fill(dt);
                                GridView2.DataSource = dt;
                                GridView2.DataBind();
                                con.Close();
                            }
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




        public void ExcelExport()
        {
            try
            {
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=Followups Pending (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
                Response.Charset = "";

                Response.ContentType = "application/vnd.xls";
                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite =
                new HtmlTextWriter(stringWrite);
                GridView2.AllowPaging = false;
                ExcelExportMessage();
                GridView2.CaptionAlign = TableCaptionAlign.Top;

                Exportdata();
                for (int i = 0; i < GridView2.HeaderRow.Cells.Count; i++)
                {
                    GridView2.HeaderRow.Cells[i].Style.Add("background-color", "#5D7B9D");
                    GridView2.HeaderRow.Cells[i].Style.Add("Color", "white");
                }
                GridView2.RenderControl(htmlWrite);
                Response.Write(stringWrite.ToString());
                Response.End();

            }
            catch (Exception ex)
            {
                Response.Write("<script type=\"text/javascript\">alert(" + ex.Message + ")</script>");

            }
        }





        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int a = 0;

                a = Convert.ToInt32(e.Row.Cells[8].Text);

                if (a == 27 || a == 59 || a == 89 || a == 179)
                {
                    e.Row.Cells[11].Text = "Yes";
                }
                else
                {
                    e.Row.Cells[11].Text = "No";
                }
            }


        }


    }
}