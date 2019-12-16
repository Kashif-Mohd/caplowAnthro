using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace caplowanthro
{
    public partial class duplicateForm2 : System.Web.UI.Page
    {
        static string Unique_ID;
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["WebForm"] = "duplicateForm2";
            Session["dssid"] = null;
            if (!IsPostBack)
            {
                ShowData();
            }
        }






        private void ShowData()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();

                MySqlCommand cmd = new MySqlCommand("select *,count(concat(unique_mother_id,':',followup_num)) as total, concat(unique_mother_id,':',followup_num) as unique_id_fup from view_form2  group by concat(unique_mother_id,':',followup_num) having count(*)>1", con);

                {
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

        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            if (GridView1.Rows.Count != 0)
            {
                ExcelExport();
            }
        }


        private void Exportdata()
        {
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from view_form2  where concat(unique_mother_id,':',followup_num) in (select concat(unique_mother_id,':',followup_num) from view_form2 group by  concat(unique_mother_id,':',followup_num) having count(*)>1)");
                {
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    {
                        cmd.Connection = con;
                        cmd.CommandTimeout = 999999;
                        cmd.CommandType = CommandType.Text;
                        sda.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        {
                            sda.Fill(dt);
                            GridView2.DataSource = dt;
                            GridView2.DataBind();
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
                Response.AddHeader("content-disposition", "attachment;filename=Duplicate Form-2(" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
                Response.Charset = "";

                Response.ContentType = "application/vnd.xls";
                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite =
                new HtmlTextWriter(stringWrite);
                GridView2.AllowPaging = false;
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










        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("duplicateForm2.aspx");
        }

        protected void Link_unique_mother_id(object sender, EventArgs e)
        {
            Unique_ID = null;
            Unique_ID = ((LinkButton)sender).Text;
            div_Main.Visible = false;
            div_ShowForm.Visible = true;
            ShowFormData();
        }


        private void ShowFormData()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd;
                cmd = new MySqlCommand("select * from view_form2 where concat(unique_mother_id,':',followup_num)='" + Unique_ID + "'", con);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    {
                        sda.Fill(dt);
                        GridView3.DataSource = dt;
                        GridView3.DataBind();
                        con.Close();
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


    }
}