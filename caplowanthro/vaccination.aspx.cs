using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace caplowanthro
{
    public partial class vaccination : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "showvaccination";
                GraphColor();
                ShowGraph();
                //VacciantionColor();
                //ShowDataVacciantion();
            }
        }




        //For Graph Cumulative:

        private static DataTable GetData(string query)
        {
            string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

            MySqlConnection con = new MySqlConnection(constr);
            {
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    DataTable dt = new DataTable();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(query, con))
                    {
                        sda.Fill(dt);
                    }
                    return dt;
                }
            }
        }


        protected void btnGraph_Click(object sender, EventArgs e)
        {
            GraphColor();
            ShowGraph();
        }


        protected void btnVaccination_Click(object sender, EventArgs e)
        {
            VacciantionColor();
            ShowDataVacciantion();
            txtdssidVacciantion.Focus();
        }


        private void VacciantionColor()
        {
            btnVaccination.Style.Add("color", "white");
            btnVaccination.Style.Add("background-color", "#55efc4");

            btnGraph.Style.Add("color", "#adadad");
            btnGraph.Style.Add("background-color", "#e0e0e0");

            divVaccination.Visible = true;
            divGraph.Visible = false;
        }


        private void GraphColor()
        {
            btnGraph.Style.Add("color", "white");
            btnGraph.Style.Add("background-color", "#55efc4");

            btnVaccination.Style.Add("color", "#adadad");
            btnVaccination.Style.Add("background-color", "#e0e0e0");

            divGraph.Visible = true;
            divVaccination.Visible = false;
        }






        private void ShowGraph()
        {
            LoadChartVaccination();

            LoadChartChildDeath();
        }

        private void LoadChartVaccination()
        {
            string query = string.Format("select 'BCG0_Eligible' as vaccine,count(a.motherid_code) as total from form_1 as a left join child_record as c on c.pw_id=a.pw_id where c.form1_q25='1' and  DATEDIFF(CURDATE(),str_to_date(c.form1_q18, '%d-%m-%Y')) >1 union all select 'BCG0_Done' , count(z.dssid) from view_vaccination as z where z.bcg0_date !=''  and z.current_age>1   union all select 'OPV0_Eligible',count(a.motherid_code) from form_1 as a left join child_record as c on c.pw_id=a.pw_id where c.form1_q25='1' and  DATEDIFF(CURDATE(),str_to_date(c.form1_q18, '%d-%m-%Y')) >1 union all select 'OPV0_Done',count(z.dssid) from view_vaccination as z where z.opv0_date !=''  and z.current_age>1 union all select 'OPV1_Eligible',count(a.motherid_code) from form_1 as a left join child_record as c on c.pw_id=a.pw_id where c.form1_q25='1' and  DATEDIFF(CURDATE(),str_to_date(c.form1_q18, '%d-%m-%Y')) >42 union all select 'OPV1_Done',count(z.dssid) from view_vaccination as z where z.opv1_date !=''  and z.current_age>42 union all select 'Penta1_Eligible',count(a.motherid_code) from form_1 as a left join child_record as c on c.pw_id=a.pw_id where c.form1_q25='1' and  DATEDIFF(CURDATE(),str_to_date(c.form1_q18, '%d-%m-%Y')) >42 union all select 'Penta1_Done',count(z.dssid) from view_vaccination as z where z.penta1_date !=''  and z.current_age>42 union all select 'PCV1_Eligible',count(a.motherid_code) from form_1 as a left join child_record as c on c.pw_id=a.pw_id where c.form1_q25='1' and  DATEDIFF(CURDATE(),str_to_date(c.form1_q18, '%d-%m-%Y')) >42  union all select 'PCV1_Done',count(z.dssid) from view_vaccination as z where z.pcv1_date !=''  and z.current_age>42 union all select 'Rota1_Eligible',count(a.motherid_code) from form_1 as a left join child_record as c on c.pw_id=a.pw_id where c.form1_q25='1' and  DATEDIFF(CURDATE(),str_to_date(c.form1_q18, '%d-%m-%Y')) >42 union all select 'Rota1_Done',count(z.dssid) from view_vaccination as z where z.rota1_date  !=''  and z.current_age>42 union all select 'OPV2_Eligible',count(a.motherid_code) from form_1 as a left join child_record as c on c.pw_id=a.pw_id where c.form1_q25='1' and  DATEDIFF(CURDATE(),str_to_date(c.form1_q18, '%d-%m-%Y')) >70 union all select 'OPV2_Done',count(z.dssid) from view_vaccination as z where z.opv2_date !=''  and z.current_age>70 union all select 'Penta2_Eligible',count(a.motherid_code) from form_1 as a left join child_record as c on c.pw_id=a.pw_id where c.form1_q25='1' and  DATEDIFF(CURDATE(),str_to_date(c.form1_q18, '%d-%m-%Y')) >70 union all select 'Penta2_Done',count(z.dssid) from view_vaccination as z where z.penta2_date !=''  and z.current_age>70 union all select 'PCV2_Eligible',count(a.motherid_code) from form_1 as a left join child_record as c on c.pw_id=a.pw_id where c.form1_q25='1' and  DATEDIFF(CURDATE(),str_to_date(c.form1_q18, '%d-%m-%Y')) >70 union all select 'PCV2_Done',count(z.dssid) from view_vaccination as z where z.pcv2_date !=''  and z.current_age>70 union all select 'Rota2_Eligible',count(a.motherid_code) from form_1 as a left join child_record as c on c.pw_id=a.pw_id where c.form1_q25='1' and  DATEDIFF(CURDATE(),str_to_date(c.form1_q18, '%d-%m-%Y')) >70  union all select 'Rota2_Done',count(z.dssid) from view_vaccination as z where z.rota2_date  !=''  and z.current_age>70 union all select 'OPV3_Eligible',count(a.motherid_code) from form_1 as a left join child_record as c on c.pw_id=a.pw_id where c.form1_q25='1' and  DATEDIFF(CURDATE(),str_to_date(c.form1_q18, '%d-%m-%Y')) >98 union all select 'OPV3_Done',count(z.dssid) from view_vaccination as z where z.opv3_date !=''  and z.current_age>98 union all select 'Penta3_Eligible',count(a.motherid_code) from form_1 as a left join child_record as c on c.pw_id=a.pw_id where c.form1_q25='1' and  DATEDIFF(CURDATE(),str_to_date(c.form1_q18, '%d-%m-%Y')) >98 union all select 'Penta3_Done',count(z.dssid) from view_vaccination as z where z.penta3_date !=''  and z.current_age>98 union all select 'PCV3_Eligible',count(a.motherid_code) from form_1 as a left join child_record as c on c.pw_id=a.pw_id where c.form1_q25='1' and  DATEDIFF(CURDATE(),str_to_date(c.form1_q18, '%d-%m-%Y')) >98 union all select 'PCV3_Done',count(z.dssid) from view_vaccination as z where z.pcv3_date !=''  and z.current_age>98 union all select 'IPV_Eligible',count(a.motherid_code) from form_1 as a left join child_record as c on c.pw_id=a.pw_id where c.form1_q25='1' and  DATEDIFF(CURDATE(),str_to_date(c.form1_q18, '%d-%m-%Y')) >98 union all select 'IPV_Done',count(z.dssid) from view_vaccination as z where z.ipv_date !=''  and z.current_age>98");
            DataTable dt = GetData(query);
            Chart3.DataSource = dt;
            Chart3.Series[0].XValueMember = "vaccine";
            Chart3.Series[0].YValueMembers = "total";
            Chart3.Series[0].Label = "#VALY";
            Chart3.ChartAreas["ChartArea3"].AxisX.MajorGrid.Enabled = false;
            Chart3.Series["Series3"].IsValueShownAsLabel = true;
            Chart3.DataBind();
        }

        private void LoadChartChildDeath()
        {
            string query = string.Format("select 'Total Child Death' as death,count(a.motherid_code) as total from form_1 as a left join child_record as c on c.pw_id=a.pw_id where c.form1_q25='1'  	and (select b.q18 from form_2 as b where a.pw_id=b.pw_id and b.q18!='' and c.child_id=b.child_id   group by b.pw_id,b.child_id) !='' union all select 'Child Death Less than 6 Weeks',count(a.motherid_code) from form_1 as a left join child_record as c on c.pw_id=a.pw_id where c.form1_q25='1' and  		DATEDIFF((select str_to_date(b.q18, '%d-%m-%Y') from form_2 as b where a.pw_id=b.pw_id and b.q18!='' and c.child_id=b.child_id   group by b.pw_id,b.child_id),str_to_date(c.form1_q18, '%d-%m-%Y'))  >=1		and	DATEDIFF((select str_to_date(b.q18, '%d-%m-%Y') from form_2 as b where a.pw_id=b.pw_id and b.q18!='' and c.child_id=b.child_id   group by b.pw_id,b.child_id),str_to_date(c.form1_q18, '%d-%m-%Y')) <42		and (select b.q18 from form_2 as b where a.pw_id=b.pw_id and b.q18!='' and c.child_id=b.child_id   group by b.pw_id,b.child_id) !=''  union all select 'Child Death Less than 10 Weeks',count(a.motherid_code) from form_1 as a left join child_record as c on c.pw_id=a.pw_id where c.form1_q25='1' and  		DATEDIFF((select str_to_date(b.q18, '%d-%m-%Y') from form_2 as b where a.pw_id=b.pw_id and b.q18!='' and c.child_id=b.child_id   group by b.pw_id,b.child_id),str_to_date(c.form1_q18, '%d-%m-%Y'))  >=42		and	DATEDIFF((select str_to_date(b.q18, '%d-%m-%Y') from form_2 as b where a.pw_id=b.pw_id and b.q18!='' and c.child_id=b.child_id   group by b.pw_id,b.child_id),str_to_date(c.form1_q18, '%d-%m-%Y')) <70		and (select b.q18 from form_2 as b where a.pw_id=b.pw_id and b.q18!='' and c.child_id=b.child_id   group by b.pw_id,b.child_id) !='' union all select 'Child Death Less than 14 Weeks',count(a.motherid_code) from form_1 as a left join child_record as c on c.pw_id=a.pw_id where c.form1_q25='1' and  		DATEDIFF((select str_to_date(b.q18, '%d-%m-%Y') from form_2 as b where a.pw_id=b.pw_id and b.q18!='' and c.child_id=b.child_id   group by b.pw_id,b.child_id),str_to_date(c.form1_q18, '%d-%m-%Y'))  >=70		and	DATEDIFF((select str_to_date(b.q18, '%d-%m-%Y') from form_2 as b where a.pw_id=b.pw_id and b.q18!='' and c.child_id=b.child_id   group by b.pw_id,b.child_id),str_to_date(c.form1_q18, '%d-%m-%Y')) <90		and (select b.q18 from form_2 as b where a.pw_id=b.pw_id and b.q18!='' and c.child_id=b.child_id   group by b.pw_id,b.child_id) !='' union all select 'Child Death greater or equal than 14 Weeks',count(a.motherid_code) from form_1 as a left join child_record as c on c.pw_id=a.pw_id where c.form1_q25='1' and  		DATEDIFF((select str_to_date(b.q18, '%d-%m-%Y') from form_2 as b where a.pw_id=b.pw_id and b.q18!='' and c.child_id=b.child_id   group by b.pw_id,b.child_id),str_to_date(c.form1_q18, '%d-%m-%Y'))  >=90		and (select b.q18 from form_2 as b where a.pw_id=b.pw_id and b.q18!='' and c.child_id=b.child_id   group by b.pw_id,b.child_id) !=''");
            DataTable dt = GetData(query);
            Chart1.DataSource = dt;
            Chart1.Series[0].XValueMember = "death";
            Chart1.Series[0].YValueMembers = "total";
            Chart1.Series[0].Label = "#VALY";
            Chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            Chart1.Series["Series1"].IsValueShownAsLabel = true;
            Chart1.DataBind();
        }





        public void showalert(string message)
        {
            string script = @"alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ShowDataVacciantion();
            txtdssidVacciantion.Focus();
        }


        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ShowDataVacciantion();
        }


        private void ShowDataVacciantion()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd;
                cmd = new MySqlCommand("select *,(select DATE_FORMAT((STR_TO_DATE(b.q18,'%d-%m-%Y')),'%d-%m-%Y') from form_2 as b where SUBSTRING_INDEX(a.mother_id, ':', -1)=b.pw_id and b.q18!='' and a.child_id=b.child_id   group by b.pw_id,b.child_id) as dod from view_vaccination  as a where a.dssid LIKE '%" + txtdssidVacciantion.Text + "%'order by a.current_age desc", con);
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
            if (GridView1.Rows.Count != 0)
            {
                ExcelExport();
            }
            txtdssidVacciantion.Focus();
        }



        public void ExcelExportMessage()
        {
            if (txtdssidVacciantion.Text != "")
            {
                GridView2.Caption = "DSSID, Search by: " + txtdssidVacciantion.Text;
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }


        private void Exportdata()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd;
                cmd = new MySqlCommand("select *,(select DATE_FORMAT((STR_TO_DATE(b.q18,'%d-%m-%Y')),'%d-%m-%Y')  from form_2 as b where SUBSTRING_INDEX(a.mother_id, ':', -1)=b.pw_id and b.q18!='' and a.child_id=b.child_id      group by b.pw_id,b.child_id) as dod from view_vaccination  as a where a.dssid LIKE '" + txtdssidVacciantion.Text + "%'order by a.current_age desc", con);
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
                Response.AddHeader("content-disposition", "attachment;filename=Vaccination (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
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
                if (e.Row.Cells[9].Text != "&nbsp;")
                {
                    //Null Current Age
                    e.Row.Cells[8].Text = "";


                    // Age of Death 
                    DateTime dob = DateTime.ParseExact(e.Row.Cells[7].Text, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    DateTime dod = DateTime.ParseExact(e.Row.Cells[9].Text, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    TimeSpan diff = dod.Subtract(dob);
                    int age_dod = diff.Days;
                    e.Row.Cells[10].Text = Convert.ToString(age_dod);
                }


                TableCell cell1 = e.Row.Cells[11];
                TableCell cell2 = e.Row.Cells[12];
                TableCell cell3 = e.Row.Cells[13];
                TableCell cell4 = e.Row.Cells[14];
                TableCell cell5 = e.Row.Cells[18];
                TableCell cell6 = e.Row.Cells[19];
                TableCell cell7 = e.Row.Cells[20];
                TableCell cell8 = e.Row.Cells[24];
                TableCell cell9 = e.Row.Cells[25];
                TableCell cell10 = e.Row.Cells[26];
                TableCell cell11 = e.Row.Cells[30];
                TableCell cell12 = e.Row.Cells[31];
                TableCell cell13 = e.Row.Cells[32];
                TableCell cell14 = e.Row.Cells[36];
                TableCell cell15 = e.Row.Cells[37];
                TableCell cell16 = e.Row.Cells[38];
                TableCell cell17 = e.Row.Cells[42];
                TableCell cell18 = e.Row.Cells[43];
                TableCell cell19 = e.Row.Cells[44];
                TableCell cell20 = e.Row.Cells[48];
                TableCell cell21 = e.Row.Cells[49];
                TableCell cell22 = e.Row.Cells[50];
                TableCell cell23 = e.Row.Cells[54];
                TableCell cell24 = e.Row.Cells[55];

                cell1.BackColor = System.Drawing.Color.FromName("#cef5cb");
                cell2.BackColor = System.Drawing.Color.FromName("#dfe6e9");
                cell3.BackColor = System.Drawing.Color.FromName("#dfe6e9");
                cell4.BackColor = System.Drawing.Color.FromName("#dfe6e9");
                cell5.BackColor = System.Drawing.Color.FromName("#dfe6e9");
                cell6.BackColor = System.Drawing.Color.FromName("#dfe6e9");
                cell7.BackColor = System.Drawing.Color.FromName("#dfe6e9");
                cell8.BackColor = System.Drawing.Color.FromName("#dfe6e9");
                cell9.BackColor = System.Drawing.Color.FromName("#dfe6e9");
                cell10.BackColor = System.Drawing.Color.FromName("#dfe6e9");
                cell11.BackColor = System.Drawing.Color.FromName("#dfe6e9");
                cell12.BackColor = System.Drawing.Color.FromName("#dfe6e9");
                cell13.BackColor = System.Drawing.Color.FromName("#dfe6e9");
                cell14.BackColor = System.Drawing.Color.FromName("#dfe6e9");
                cell15.BackColor = System.Drawing.Color.FromName("#dfe6e9");
                cell16.BackColor = System.Drawing.Color.FromName("#dfe6e9");
                cell17.BackColor = System.Drawing.Color.FromName("#dfe6e9");
                cell18.BackColor = System.Drawing.Color.FromName("#dfe6e9");
                cell19.BackColor = System.Drawing.Color.FromName("#dfe6e9");
                cell20.BackColor = System.Drawing.Color.FromName("#dfe6e9");
                cell21.BackColor = System.Drawing.Color.FromName("#dfe6e9");
                cell22.BackColor = System.Drawing.Color.FromName("#dfe6e9");
                cell23.BackColor = System.Drawing.Color.FromName("#ffeaa7");
                cell24.BackColor = System.Drawing.Color.FromName("#ffeaa7");







                //BCG0 Pending   (Pending_After_Birth)
                if (e.Row.Cells[13].Text == "&nbsp;" && e.Row.Cells[8].Text != "" && Convert.ToInt32(e.Row.Cells[8].Text) > 1)
                {
                    e.Row.Cells[56].Text = "BCG0, ";
                    TableCell DSSID = e.Row.Cells[11];
                    DSSID.BackColor = System.Drawing.Color.FromName("#fab1a0");
                }
                //OPV0 Pending   (Pending_After_Birth)
                if (e.Row.Cells[16].Text == "&nbsp;" && e.Row.Cells[8].Text != "" && Convert.ToInt32(e.Row.Cells[8].Text) > 1)
                {
                    e.Row.Cells[56].Text = e.Row.Cells[56].Text + "OPV0, ";
                    TableCell DSSID = e.Row.Cells[11];
                    DSSID.BackColor = System.Drawing.Color.FromName("#fab1a0");
                }





                //OPV1 Pending   (Pending_Greater_6_Weeks)
                if (e.Row.Cells[19].Text == "&nbsp;" && e.Row.Cells[8].Text != "" && Convert.ToInt32(e.Row.Cells[8].Text) > 42)
                {
                    e.Row.Cells[57].Text = "OPV1, ";
                    TableCell DSSID = e.Row.Cells[11];
                    DSSID.BackColor = System.Drawing.Color.FromName("#fab1a0");
                }
                //Penta1 Pending   (Pending_Greater_6_Weeks)
                if (e.Row.Cells[22].Text == "&nbsp;" && e.Row.Cells[8].Text != "" && Convert.ToInt32(e.Row.Cells[8].Text) > 42)
                {
                    e.Row.Cells[57].Text = e.Row.Cells[57].Text + "Penta1, ";
                    TableCell DSSID = e.Row.Cells[11];
                    DSSID.BackColor = System.Drawing.Color.FromName("#fab1a0");
                }
                //PCV1 Pending   (Pending_Greater_6_Weeks)
                if (e.Row.Cells[25].Text == "&nbsp;" && e.Row.Cells[8].Text != "" && Convert.ToInt32(e.Row.Cells[8].Text) > 42)
                {
                    e.Row.Cells[57].Text = e.Row.Cells[57].Text + "PCV1, ";
                    TableCell DSSID = e.Row.Cells[11];
                    DSSID.BackColor = System.Drawing.Color.FromName("#fab1a0");
                }
                //Rota1  Pending   (Pending_Greater_6_Weeks)
                if (e.Row.Cells[28].Text == "&nbsp;" && e.Row.Cells[8].Text != "" && Convert.ToInt32(e.Row.Cells[8].Text) > 42)
                {
                    e.Row.Cells[57].Text = e.Row.Cells[57].Text + "Rota1, ";
                    TableCell DSSID = e.Row.Cells[11];
                    DSSID.BackColor = System.Drawing.Color.FromName("#fab1a0");
                }






                //OPV2  Pending   (Pending_Greater_10_Weeks)
                if (e.Row.Cells[31].Text == "&nbsp;" && e.Row.Cells[8].Text != "" && Convert.ToInt32(e.Row.Cells[8].Text) > 70)
                {
                    e.Row.Cells[58].Text = e.Row.Cells[58].Text + "OPV2, ";
                    TableCell DSSID = e.Row.Cells[11];
                    DSSID.BackColor = System.Drawing.Color.FromName("#fab1a0");
                }
                //Penta2  Pending   (Pending_Greater_10_Weeks)
                if (e.Row.Cells[34].Text == "&nbsp;" && e.Row.Cells[8].Text != "" && Convert.ToInt32(e.Row.Cells[8].Text) > 70)
                {
                    e.Row.Cells[58].Text = e.Row.Cells[58].Text + "Penta2, ";
                    TableCell DSSID = e.Row.Cells[11];
                    DSSID.BackColor = System.Drawing.Color.FromName("#fab1a0");
                }
                //PCV2  Pending   (Pending_Greater_10_Weeks)
                if (e.Row.Cells[37].Text == "&nbsp;" && e.Row.Cells[8].Text != "" && Convert.ToInt32(e.Row.Cells[8].Text) > 70)
                {
                    e.Row.Cells[58].Text = e.Row.Cells[58].Text + "PCV2, ";
                    TableCell DSSID = e.Row.Cells[11];
                    DSSID.BackColor = System.Drawing.Color.FromName("#fab1a0");
                }
                //Rota2  Pending   (Pending_Greater_10_Weeks)
                if (e.Row.Cells[40].Text == "&nbsp;" && e.Row.Cells[8].Text != "" && Convert.ToInt32(e.Row.Cells[8].Text) > 70)
                {
                    e.Row.Cells[58].Text = e.Row.Cells[58].Text + "Rota2, ";
                    TableCell DSSID = e.Row.Cells[11];
                    DSSID.BackColor = System.Drawing.Color.FromName("#fab1a0");
                }






                //OPV3  Pending   (Pending_Greater_14_Weeks)
                if (e.Row.Cells[43].Text == "&nbsp;" && e.Row.Cells[8].Text != "" && Convert.ToInt32(e.Row.Cells[8].Text) > 98)
                {
                    e.Row.Cells[59].Text = e.Row.Cells[59].Text + "OPV3, ";
                    TableCell DSSID = e.Row.Cells[11];
                    DSSID.BackColor = System.Drawing.Color.FromName("#fab1a0");
                }
                //Penta3  Pending   (Pending_Greater_14_Weeks)
                if (e.Row.Cells[46].Text == "&nbsp;" && e.Row.Cells[8].Text != "" && Convert.ToInt32(e.Row.Cells[8].Text) > 98)
                {
                    e.Row.Cells[59].Text = e.Row.Cells[59].Text + "Penta3, ";
                    TableCell DSSID = e.Row.Cells[11];
                    DSSID.BackColor = System.Drawing.Color.FromName("#fab1a0");
                }
                //PCV3  Pending   (Pending_Greater_14_Weeks)
                if (e.Row.Cells[49].Text == "&nbsp;" && e.Row.Cells[8].Text != "" && Convert.ToInt32(e.Row.Cells[8].Text) > 98)
                {
                    e.Row.Cells[59].Text = e.Row.Cells[59].Text + "PCV3, ";
                    TableCell DSSID = e.Row.Cells[11];
                    DSSID.BackColor = System.Drawing.Color.FromName("#fab1a0");
                }
                //IPV  Pending   (Pending_Greater_14_Weeks)
                if (e.Row.Cells[52].Text == "&nbsp;" && e.Row.Cells[8].Text != "" && Convert.ToInt32(e.Row.Cells[8].Text) > 98)
                {
                    e.Row.Cells[59].Text = e.Row.Cells[59].Text + "IPV, ";
                    TableCell DSSID = e.Row.Cells[11];
                    DSSID.BackColor = System.Drawing.Color.FromName("#fab1a0");
                }




            }
        }


    }
}