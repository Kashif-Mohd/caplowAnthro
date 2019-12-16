using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Web.UI.DataVisualization.Charting;


namespace caplowanthro
{
    public partial class dashboard : System.Web.UI.Page
    {

        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtCalndrDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                txtCalndrDate1.Text = DateTime.Now.ToString("dd-MM-yyyy");
                lbeUname.Text = Convert.ToString(Session["CPusername"]);
                Session["WebForm"] = "Dashboard";
                LoadChartUserWise();
                LoadChartBirthCapturing();
                LoadChartLiveBirth();
                ShowEnrollment();
                ShowFollowups();
                Mortality();
            }
        }




        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadChartUserWise();
            ShowEnrollment();
            ShowFollowups();
            LoadChartBirthCapturing();
            LoadChartLiveBirth();
            Mortality();
        }




        private void LoadChartUserWise()
        {
            Chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            Chart1.DataBindCrossTable(GetDataItem().DefaultView, "sra_name", "Enrollment", "total", "Label=total");
            Chart1.DataBind();
        }





        private DataTable GetDataItem()
        {
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select a.sra_name,'Enrollment', (select count(*) as total from form_1 as b left join team as z on b.team_id=z.team_id where str_to_date(b.form1_q01, '%d-%m-%Y') BETWEEN str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y')  and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y') and a.sra_name=z.sra_name  group by z.sra_name) as total from  team as a where a.status=1 union all select a.sra_name,'Complete', (select count(*) as total from form_1 as b left join team as z on b.team_id=z.team_id where str_to_date(b.form1_q01, '%d-%m-%Y') BETWEEN str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y')  and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y') and a.sra_name=z.sra_name and form1_q15='1'  group by z.sra_name) as total from  team as a where a.status=1 union all select a.sra_name,'Incomplete', (select count(*) as total from form_1 as b left join team as z on b.team_id=z.team_id where str_to_date(b.form1_q01, '%d-%m-%Y') BETWEEN str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y')  and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y') and a.sra_name=z.sra_name and form1_q15!='1'  group by z.sra_name) as total from  team as a where a.status=1 union all select a.sra_name,'Followups', (select count(*) as total from view_form2 as b where str_to_date(b.q01, '%d-%m-%Y') BETWEEN str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y')  and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y') and a.sra_name=b.sra_name  group by b.sra_name) as total from  team as a where a.status=1 union all select a.sra_name,'Complete F/ups', (select count(*) as total from view_form2 as b where str_to_date(b.q01, '%d-%m-%Y') BETWEEN str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y')  and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y') and a.sra_name=b.sra_name and q16='1' group by b.sra_name) as total from  team as a where a.status=1 union all select a.sra_name,'Incomplete F/ups', (select count(*) as total from view_form2 as b where str_to_date(b.q01, '%d-%m-%Y') BETWEEN str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y')  and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y') and a.sra_name=b.sra_name  and q16!='1' group by b.sra_name) as total from  team as a where a.status=1", con);
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                DataTable dtData = new DataTable();
                dtData.Load(reader);
                return dtData;
                con.Close();
            }
            con.Close();
        }






        private void Mortality()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select TableA.*,TableB.year_2019 from mortality as TableA  left join  (select 'Yearly live births' as field, 'high mortality' as cluster_type,count(*) year_2019  from view_form1 where form1_q24='1' and Date_Format(str_to_date(form1_q18, '%d-%m-%Y'),'%Y')='2019' and ((pw_block between '01' and '20') or (pw_block between '35' and '37')) union all select 'Yearly live births' as field, 'low mortality' as cluster_type,count(*) year_2019  from view_form1 where form1_q24='1' and Date_Format(str_to_date(form1_q18, '%d-%m-%Y'),'%Y')='2019' and ((pw_block between '21' and '34') or pw_block >='38') union all select 'Yearly live births' as field, 'cumulative' as cluster_type,count(*) year_2019  from view_form1 where form1_q24='1' and Date_Format(str_to_date(form1_q18, '%d-%m-%Y'),'%Y')='2019' union all select 'Number of under 5 deaths' as field, 'high mortality' as cluster_type,count(*) year_2019  from cod_vasa where Date_Format(str_to_date(va_g1_5, '%d-%m-%Y'),'%Y')='2019' and ((mid(va_g1_1,5,2) between '01' and '20') or (mid(va_g1_1,5,2) between '35' and '37')) and  (to_days(str_to_date(va_g1_5,'%d-%m-%Y')) - to_days(str_to_date(va_g1_4,'%d-%m-%Y'))) <1825 	and (ABS(str_to_date(concat(Date_Format(str_to_date(va_g1_5,'%d-%m-%Y'),'%d-%m-%Y'),' ', STR_TO_DATE(va_g1_5_time,  '%H:%i')),'%d-%m-%Y %H:%i')) - ABS(str_to_date(concat(Date_Format(str_to_date(va_g1_4,'%d-%m-%Y'),'%d-%m-%Y'),' ', STR_TO_DATE(va_g1_4_time,  '%H:%i')),'%d-%m-%Y %H:%i'))) >0 union all select 'Number of under 5 deaths' as field, 'low mortality' as cluster_type,count(*) year_2019  from cod_vasa where Date_Format(str_to_date(va_g1_5, '%d-%m-%Y'),'%Y')='2019' and ((mid(va_g1_1,5,2) between '21' and '34') or mid(va_g1_1,5,2) >='38') and  (to_days(str_to_date(va_g1_5,'%d-%m-%Y')) - to_days(str_to_date(va_g1_4,'%d-%m-%Y'))) <1825		and (ABS(str_to_date(concat(Date_Format(str_to_date(va_g1_5,'%d-%m-%Y'),'%d-%m-%Y'),' ', STR_TO_DATE(va_g1_5_time,  '%H:%i')),'%d-%m-%Y %H:%i')) - ABS(str_to_date(concat(Date_Format(str_to_date(va_g1_4,'%d-%m-%Y'),'%d-%m-%Y'),' ', STR_TO_DATE(va_g1_4_time,  '%H:%i')),'%d-%m-%Y %H:%i'))) >0 union all select 'Number of under 5 deaths' as field, 'cumulative' as cluster_type,count(*) year_2019  from cod_vasa where Date_Format(str_to_date(va_g1_5, '%d-%m-%Y'),'%Y')='2019' and  (to_days(str_to_date(va_g1_5,'%d-%m-%Y')) - to_days(str_to_date(va_g1_4,'%d-%m-%Y'))) <1825		and (ABS(str_to_date(concat(Date_Format(str_to_date(va_g1_5,'%d-%m-%Y'),'%d-%m-%Y'),' ', STR_TO_DATE(va_g1_5_time,  '%H:%i')),'%d-%m-%Y %H:%i')) - ABS(str_to_date(concat(Date_Format(str_to_date(va_g1_4,'%d-%m-%Y'),'%d-%m-%Y'),' ', STR_TO_DATE(va_g1_4_time,  '%H:%i')),'%d-%m-%Y %H:%i'))) >0 union all select 'under 5 mortality rates per 1000 live births' as field, 'high mortality' as cluster_type, round(((select count(*)  from cod_vasa where Date_Format(str_to_date(va_g1_5, '%d-%m-%Y'),'%Y')='2019' and ((mid(va_g1_1,5,2) between '01' and '20') or (mid(va_g1_1,5,2) between '35' and '37')) and  (to_days(str_to_date(va_g1_5,'%d-%m-%Y')) - to_days(str_to_date(va_g1_4,'%d-%m-%Y'))) <1825 	and (ABS(str_to_date(concat(Date_Format(str_to_date(va_g1_5,'%d-%m-%Y'),'%d-%m-%Y'),' ', STR_TO_DATE(va_g1_5_time,  '%H:%i')),'%d-%m-%Y %H:%i')) - ABS(str_to_date(concat(Date_Format(str_to_date(va_g1_4,'%d-%m-%Y'),'%d-%m-%Y'),' ', STR_TO_DATE(va_g1_4_time,  '%H:%i')),'%d-%m-%Y %H:%i'))) >0) 	/  (select count(*)   from view_form1 where form1_q24='1' and Date_Format(str_to_date(form1_q18, '%d-%m-%Y'),'%Y')='2019' and ((pw_block between '01' and '20') or (pw_block between '35' and '37')))   ) * 1000,  0) as year_2019 union all select 'under 5 mortality rates per 1000 live births' as field, 'low mortality' as cluster_type, round(((select count(*)  from cod_vasa where Date_Format(str_to_date(va_g1_5, '%d-%m-%Y'),'%Y')='2019' and ((mid(va_g1_1,5,2) between '21' and '34') or mid(va_g1_1,5,2) >='38')  and  (to_days(str_to_date(va_g1_5,'%d-%m-%Y')) - to_days(str_to_date(va_g1_4,'%d-%m-%Y'))) <1825 	and (ABS(str_to_date(concat(Date_Format(str_to_date(va_g1_5,'%d-%m-%Y'),'%d-%m-%Y'),' ', STR_TO_DATE(va_g1_5_time,  '%H:%i')),'%d-%m-%Y %H:%i')) - ABS(str_to_date(concat(Date_Format(str_to_date(va_g1_4,'%d-%m-%Y'),'%d-%m-%Y'),' ', STR_TO_DATE(va_g1_4_time,  '%H:%i')),'%d-%m-%Y %H:%i'))) >0) 	/  (select count(*)   from view_form1 where form1_q24='1' and Date_Format(str_to_date(form1_q18, '%d-%m-%Y'),'%Y')='2019' and ((pw_block between '21' and '34') or pw_block >='38'))   ) * 1000,  0) as year_2019	 union all select 'under 5 mortality rates per 1000 live births' as field, 'cumulative' as cluster_type, round(((select count(*)  from cod_vasa where Date_Format(str_to_date(va_g1_5, '%d-%m-%Y'),'%Y')='2019' and (to_days(str_to_date(va_g1_5,'%d-%m-%Y')) - to_days(str_to_date(va_g1_4,'%d-%m-%Y'))) <1825	 	and (ABS(str_to_date(concat(Date_Format(str_to_date(va_g1_5,'%d-%m-%Y'),'%d-%m-%Y'),' ', STR_TO_DATE(va_g1_5_time,  '%H:%i')),'%d-%m-%Y %H:%i')) - ABS(str_to_date(concat(Date_Format(str_to_date(va_g1_4,'%d-%m-%Y'),'%d-%m-%Y'),' ', STR_TO_DATE(va_g1_4_time,  '%H:%i')),'%d-%m-%Y %H:%i'))) >0) 	/  (select count(*)   from view_form1 where form1_q24='1' and Date_Format(str_to_date(form1_q18, '%d-%m-%Y'),'%Y')='2019')   ) * 1000,  0) as year_2019	 union all select '(24-59) Month death' as field, 'high mortality' as cluster_type,count(*) year_2019  from cod_vasa where Date_Format(str_to_date(va_g1_5, '%d-%m-%Y'),'%Y')='2019' and ((mid(va_g1_1,5,2) between '01' and '20') or (mid(va_g1_1,5,2) between '35' and '37')) and  ((to_days(str_to_date(va_g1_5,'%d-%m-%Y')) - to_days(str_to_date(va_g1_4,'%d-%m-%Y'))) between '700' and '1794') union all select '(24-59) Month death' as field, 'low mortality' as cluster_type,count(*) year_2019  from cod_vasa where Date_Format(str_to_date(va_g1_5, '%d-%m-%Y'),'%Y')='2019' and ((mid(va_g1_1,5,2) between '21' and '34') or mid(va_g1_1,5,2) >='38') and ((to_days(str_to_date(va_g1_5,'%d-%m-%Y')) - to_days(str_to_date(va_g1_4,'%d-%m-%Y'))) between '700' and '1794') union all select '(24-59) Month death' as field, 'cumulative' as cluster_type,count(*) year_2019  from cod_vasa where Date_Format(str_to_date(va_g1_5, '%d-%m-%Y'),'%Y')='2019' and ((to_days(str_to_date(va_g1_5,'%d-%m-%Y')) - to_days(str_to_date(va_g1_4,'%d-%m-%Y'))) between '700' and '1794')  union all select '(24-59) month mortality Rates' as field, 'high mortality' as cluster_type, round(((select count(*)  from cod_vasa where Date_Format(str_to_date(va_g1_5, '%d-%m-%Y'),'%Y')='2019' and ((mid(va_g1_1,5,2) between '01' and '20') or (mid(va_g1_1,5,2) between '35' and '37')) and  ((to_days(str_to_date(va_g1_5,'%d-%m-%Y')) - to_days(str_to_date(va_g1_4,'%d-%m-%Y'))) between '700' and '1794')) 	/  (select count(*)   from view_form1 where form1_q24='1' and Date_Format(str_to_date(form1_q18, '%d-%m-%Y'),'%Y')='2019' and ((pw_block between '01' and '20') or (pw_block between '35' and '37')))   ) * 1000,  0) as year_2019 union all select '(24-59) month mortality Rates' as field, 'low mortality' as cluster_type, round(((select count(*)  from cod_vasa where Date_Format(str_to_date(va_g1_5, '%d-%m-%Y'),'%Y')='2019' and ((mid(va_g1_1,5,2) between '21' and '34') or mid(va_g1_1,5,2) >='38')  and  ((to_days(str_to_date(va_g1_5,'%d-%m-%Y')) - to_days(str_to_date(va_g1_4,'%d-%m-%Y'))) between '700' and '1794')) 	/  (select count(*)   from view_form1 where form1_q24='1' and Date_Format(str_to_date(form1_q18, '%d-%m-%Y'),'%Y')='2019' and ((pw_block between '21' and '34') or pw_block >='38'))   ) * 1000,  0) as year_2019	 union all select '(24-59) month mortality Rates' as field, 'cumulative' as cluster_type, round(((select count(*)  from cod_vasa where Date_Format(str_to_date(va_g1_5, '%d-%m-%Y'),'%Y')='2019' and ((to_days(str_to_date(va_g1_5,'%d-%m-%Y')) - to_days(str_to_date(va_g1_4,'%d-%m-%Y'))) between '700' and '1794')) 	/  (select count(*)   from view_form1 where form1_q24='1' and Date_Format(str_to_date(form1_q18, '%d-%m-%Y'),'%Y')='2019')   ) * 1000,  0) as year_2019	 union all select '(12-23) month  deaths' as field, 'high mortality' as cluster_type,count(*) year_2019  from cod_vasa where Date_Format(str_to_date(va_g1_5, '%d-%m-%Y'),'%Y')='2019' and ((mid(va_g1_1,5,2) between '01' and '20') or (mid(va_g1_1,5,2) between '35' and '37')) and  ((to_days(str_to_date(va_g1_5,'%d-%m-%Y')) - to_days(str_to_date(va_g1_4,'%d-%m-%Y'))) between '335' and '699') union all select '(12-23) month  deaths' as field, 'low mortality' as cluster_type,count(*) year_2019  from cod_vasa where Date_Format(str_to_date(va_g1_5, '%d-%m-%Y'),'%Y')='2019' and ((mid(va_g1_1,5,2) between '21' and '34') or mid(va_g1_1,5,2) >='38') and ((to_days(str_to_date(va_g1_5,'%d-%m-%Y')) - to_days(str_to_date(va_g1_4,'%d-%m-%Y'))) between '335' and '699') union all select '(12-23) month  deaths' as field, 'cumulative' as cluster_type,count(*) year_2019  from cod_vasa where Date_Format(str_to_date(va_g1_5, '%d-%m-%Y'),'%Y')='2019' and ((to_days(str_to_date(va_g1_5,'%d-%m-%Y')) - to_days(str_to_date(va_g1_4,'%d-%m-%Y'))) between '335' and '699') union all select '(12-23) month  mortality rates' as field, 'high mortality' as cluster_type, round(((select count(*)  from cod_vasa where Date_Format(str_to_date(va_g1_5, '%d-%m-%Y'),'%Y')='2019' and ((mid(va_g1_1,5,2) between '01' and '20') or (mid(va_g1_1,5,2) between '35' and '37')) and  ((to_days(str_to_date(va_g1_5,'%d-%m-%Y')) - to_days(str_to_date(va_g1_4,'%d-%m-%Y'))) between '335' and '699')) 	/  (select count(*)   from view_form1 where form1_q24='1' and Date_Format(str_to_date(form1_q18, '%d-%m-%Y'),'%Y')='2019' and ((pw_block between '01' and '20') or (pw_block between '35' and '37')))   ) * 1000,  0) as year_2019 union all select '(12-23) month  mortality rates' as field, 'low mortality' as cluster_type, round(((select count(*)  from cod_vasa where Date_Format(str_to_date(va_g1_5, '%d-%m-%Y'),'%Y')='2019' and ((mid(va_g1_1,5,2) between '21' and '34') or mid(va_g1_1,5,2) >='38')  and  ((to_days(str_to_date(va_g1_5,'%d-%m-%Y')) - to_days(str_to_date(va_g1_4,'%d-%m-%Y'))) between '335' and '699')) 	/  (select count(*)   from view_form1 where form1_q24='1' and Date_Format(str_to_date(form1_q18, '%d-%m-%Y'),'%Y')='2019' and ((pw_block between '21' and '34') or pw_block >='38'))   ) * 1000,  0) as year_2019 union all select '(12-23) month  mortality rates' as field, 'cumulative' as cluster_type, round(((select count(*)  from cod_vasa where Date_Format(str_to_date(va_g1_5, '%d-%m-%Y'),'%Y')='2019' and ((to_days(str_to_date(va_g1_5,'%d-%m-%Y')) - to_days(str_to_date(va_g1_4,'%d-%m-%Y'))) between '335' and '699')) 	/  (select count(*)   from view_form1 where form1_q24='1' and Date_Format(str_to_date(form1_q18, '%d-%m-%Y'),'%Y')='2019')   ) * 1000,  0) as year_2019	 union all select '(6-11) month death' as field, 'high mortality' as cluster_type,count(*) year_2019  from cod_vasa where Date_Format(str_to_date(va_g1_5, '%d-%m-%Y'),'%Y')='2019' and ((mid(va_g1_1,5,2) between '01' and '20') or (mid(va_g1_1,5,2) between '35' and '37')) and  ((to_days(str_to_date(va_g1_5,'%d-%m-%Y')) - to_days(str_to_date(va_g1_4,'%d-%m-%Y'))) between '153' and '334') union all select '(6-11) month death' as field, 'low mortality' as cluster_type,count(*) year_2019  from cod_vasa where Date_Format(str_to_date(va_g1_5, '%d-%m-%Y'),'%Y')='2019' and ((mid(va_g1_1,5,2) between '21' and '34') or mid(va_g1_1,5,2) >='38') and ((to_days(str_to_date(va_g1_5,'%d-%m-%Y')) - to_days(str_to_date(va_g1_4,'%d-%m-%Y'))) between  '153' and '334') union all select '(6-11) month death' as field, 'cumulative' as cluster_type,count(*) year_2019  from cod_vasa where Date_Format(str_to_date(va_g1_5, '%d-%m-%Y'),'%Y')='2019' and ((to_days(str_to_date(va_g1_5,'%d-%m-%Y')) - to_days(str_to_date(va_g1_4,'%d-%m-%Y'))) between  '153' and '334') union all select '(6-11) month mortality rates' as field, 'high mortality' as cluster_type, round(((select count(*)  from cod_vasa where Date_Format(str_to_date(va_g1_5, '%d-%m-%Y'),'%Y')='2019' and ((mid(va_g1_1,5,2) between '01' and '20') or (mid(va_g1_1,5,2) between '35' and '37')) and  ((to_days(str_to_date(va_g1_5,'%d-%m-%Y')) - to_days(str_to_date(va_g1_4,'%d-%m-%Y'))) between  '153' and '334')) 	/  (select count(*)   from view_form1 where form1_q24='1' and Date_Format(str_to_date(form1_q18, '%d-%m-%Y'),'%Y')='2019' and ((pw_block between '01' and '20') or (pw_block between '35' and '37')))   ) * 1000,  0) as year_2019 union all select '(6-11) month mortality rates' as field, 'low mortality' as cluster_type, round(((select count(*)  from cod_vasa where Date_Format(str_to_date(va_g1_5, '%d-%m-%Y'),'%Y')='2019' and ((mid(va_g1_1,5,2) between '21' and '34') or mid(va_g1_1,5,2) >='38')  and  ((to_days(str_to_date(va_g1_5,'%d-%m-%Y')) - to_days(str_to_date(va_g1_4,'%d-%m-%Y'))) between  '153' and '334')) 	/  (select count(*)   from view_form1 where form1_q24='1' and Date_Format(str_to_date(form1_q18, '%d-%m-%Y'),'%Y')='2019' and ((pw_block between '21' and '34') or pw_block >='38'))   ) * 1000,  0) as year_2019 union all select '(6-11) month mortality rates' as field, 'cumulative' as cluster_type, round(((select count(*)  from cod_vasa where Date_Format(str_to_date(va_g1_5, '%d-%m-%Y'),'%Y')='2019' and ((to_days(str_to_date(va_g1_5,'%d-%m-%Y')) - to_days(str_to_date(va_g1_4,'%d-%m-%Y'))) between  '153' and '334')) 	/  (select count(*)   from view_form1 where form1_q24='1' and Date_Format(str_to_date(form1_q18, '%d-%m-%Y'),'%Y')='2019')   ) * 1000,  0) as year_2019	 union all select '(2-5) month death' as field, 'high mortality' as cluster_type,count(*) year_2019  from cod_vasa where Date_Format(str_to_date(va_g1_5, '%d-%m-%Y'),'%Y')='2019' and ((mid(va_g1_1,5,2) between '01' and '20') or (mid(va_g1_1,5,2) between '35' and '37')) and  ((to_days(str_to_date(va_g1_5,'%d-%m-%Y')) - to_days(str_to_date(va_g1_4,'%d-%m-%Y'))) between '60' and '152') union all select '(2-5) month death' as field, 'low mortality' as cluster_type,count(*) year_2019  from cod_vasa where Date_Format(str_to_date(va_g1_5, '%d-%m-%Y'),'%Y')='2019' and ((mid(va_g1_1,5,2) between '21' and '34') or mid(va_g1_1,5,2) >='38') and ((to_days(str_to_date(va_g1_5,'%d-%m-%Y')) - to_days(str_to_date(va_g1_4,'%d-%m-%Y'))) between   '60' and '152') union all select '(2-5) month death' as field, 'cumulative' as cluster_type,count(*) year_2019  from cod_vasa where Date_Format(str_to_date(va_g1_5, '%d-%m-%Y'),'%Y')='2019' and ((to_days(str_to_date(va_g1_5,'%d-%m-%Y')) - to_days(str_to_date(va_g1_4,'%d-%m-%Y'))) between   '60' and '152') union all select '(2-5) month mortality rate' as field, 'high mortality' as cluster_type, round(((select count(*)  from cod_vasa where Date_Format(str_to_date(va_g1_5, '%d-%m-%Y'),'%Y')='2019' and ((mid(va_g1_1,5,2) between '01' and '20') or (mid(va_g1_1,5,2) between '35' and '37')) and  ((to_days(str_to_date(va_g1_5,'%d-%m-%Y')) - to_days(str_to_date(va_g1_4,'%d-%m-%Y'))) between   '60' and '152')) 	/  (select count(*)   from view_form1 where form1_q24='1' and Date_Format(str_to_date(form1_q18, '%d-%m-%Y'),'%Y')='2019' and ((pw_block between '01' and '20') or (pw_block between '35' and '37')))   ) * 1000,  0) as year_2019 union all select '(2-5) month mortality rate' as field, 'low mortality' as cluster_type, round(((select count(*)  from cod_vasa where Date_Format(str_to_date(va_g1_5, '%d-%m-%Y'),'%Y')='2019' and ((mid(va_g1_1,5,2) between '21' and '34') or mid(va_g1_1,5,2) >='38')  and  ((to_days(str_to_date(va_g1_5,'%d-%m-%Y')) - to_days(str_to_date(va_g1_4,'%d-%m-%Y'))) between   '60' and '152')) 	/  (select count(*)   from view_form1 where form1_q24='1' and Date_Format(str_to_date(form1_q18, '%d-%m-%Y'),'%Y')='2019' and ((pw_block between '21' and '34') or pw_block >='38'))   ) * 1000,  0) as year_2019 union all select '(2-5) month mortality rate' as field, 'cumulative' as cluster_type, round(((select count(*)  from cod_vasa where Date_Format(str_to_date(va_g1_5, '%d-%m-%Y'),'%Y')='2019' and ((to_days(str_to_date(va_g1_5,'%d-%m-%Y')) - to_days(str_to_date(va_g1_4,'%d-%m-%Y'))) between   '60' and '152')) 	/  (select count(*)   from view_form1 where form1_q24='1' and Date_Format(str_to_date(form1_q18, '%d-%m-%Y'),'%Y')='2019')   ) * 1000,  0) as year_2019	 union all select '(28-59) days death' as field, 'high mortality' as cluster_type,count(*) year_2019  from cod_vasa where Date_Format(str_to_date(va_g1_5, '%d-%m-%Y'),'%Y')='2019' and ((mid(va_g1_1,5,2) between '01' and '20') or (mid(va_g1_1,5,2) between '35' and '37')) and  ((to_days(str_to_date(va_g1_5,'%d-%m-%Y')) - to_days(str_to_date(va_g1_4,'%d-%m-%Y'))) between '28' and '59') union all select '(28-59) days death' as field, 'low mortality' as cluster_type,count(*) year_2019  from cod_vasa where Date_Format(str_to_date(va_g1_5, '%d-%m-%Y'),'%Y')='2019' and ((mid(va_g1_1,5,2) between '21' and '34') or mid(va_g1_1,5,2) >='38') and ((to_days(str_to_date(va_g1_5,'%d-%m-%Y')) - to_days(str_to_date(va_g1_4,'%d-%m-%Y'))) between   '28' and '59') union all select '(28-59) days death' as field, 'cumulative' as cluster_type,count(*) year_2019  from cod_vasa where Date_Format(str_to_date(va_g1_5, '%d-%m-%Y'),'%Y')='2019' and ((to_days(str_to_date(va_g1_5,'%d-%m-%Y')) - to_days(str_to_date(va_g1_4,'%d-%m-%Y'))) between   '28' and '59') union all select '(28-59) days mortality rate' as field, 'high mortality' as cluster_type, round(((select count(*)  from cod_vasa where Date_Format(str_to_date(va_g1_5, '%d-%m-%Y'),'%Y')='2019' and ((mid(va_g1_1,5,2) between '01' and '20') or (mid(va_g1_1,5,2) between '35' and '37')) and  ((to_days(str_to_date(va_g1_5,'%d-%m-%Y')) - to_days(str_to_date(va_g1_4,'%d-%m-%Y'))) between   '28' and '59')) 	/  (select count(*)   from view_form1 where form1_q24='1' and Date_Format(str_to_date(form1_q18, '%d-%m-%Y'),'%Y')='2019' and ((pw_block between '01' and '20') or (pw_block between '35' and '37')))   ) * 1000,  0) as year_2019 union all select '(28-59) days mortality rate' as field, 'low mortality' as cluster_type, round(((select count(*)  from cod_vasa where Date_Format(str_to_date(va_g1_5, '%d-%m-%Y'),'%Y')='2019' and ((mid(va_g1_1,5,2) between '21' and '34') or mid(va_g1_1,5,2) >='38')  and  ((to_days(str_to_date(va_g1_5,'%d-%m-%Y')) - to_days(str_to_date(va_g1_4,'%d-%m-%Y'))) between   '28' and '59')) 	/  (select count(*)   from view_form1 where form1_q24='1' and Date_Format(str_to_date(form1_q18, '%d-%m-%Y'),'%Y')='2019' and ((pw_block between '21' and '34') or pw_block >='38'))   ) * 1000,  0) as year_2019 union all select '(28-59) days mortality rate' as field, 'cumulative' as cluster_type, round(((select count(*)  from cod_vasa where Date_Format(str_to_date(va_g1_5, '%d-%m-%Y'),'%Y')='2019' and ((to_days(str_to_date(va_g1_5,'%d-%m-%Y')) - to_days(str_to_date(va_g1_4,'%d-%m-%Y'))) between   '28' and '59')) 	/  (select count(*)   from view_form1 where form1_q24='1' and Date_Format(str_to_date(form1_q18, '%d-%m-%Y'),'%Y')='2019')   ) * 1000,  0) as year_2019	 union all select 'number of neonatal deaths' as field, 'high mortality' as cluster_type,count(*) year_2019  from cod_vasa where Date_Format(str_to_date(va_g1_5, '%d-%m-%Y'),'%Y')='2019' and ((mid(va_g1_1,5,2) between '01' and '20') or (mid(va_g1_1,5,2) between '35' and '37')) and  ((to_days(str_to_date(va_g1_5,'%d-%m-%Y')) - to_days(str_to_date(va_g1_4,'%d-%m-%Y')))   <=27  and (ABS(str_to_date(concat(Date_Format(str_to_date(va_g1_5,'%d-%m-%Y'),'%d-%m-%Y'),' ', STR_TO_DATE(va_g1_5_time,  '%H:%i')),'%d-%m-%Y %H:%i')) - ABS(str_to_date(concat(Date_Format(str_to_date(va_g1_4,'%d-%m-%Y'),'%d-%m-%Y'),' ', STR_TO_DATE(va_g1_4_time,  '%H:%i')),'%d-%m-%Y %H:%i'))) >0 ) union all select 'number of neonatal deaths' as field, 'low mortality' as cluster_type,count(*) year_2019  from cod_vasa where Date_Format(str_to_date(va_g1_5, '%d-%m-%Y'),'%Y')='2019' and ((mid(va_g1_1,5,2) between '21' and '34') or mid(va_g1_1,5,2) >='38') and ((to_days(str_to_date(va_g1_5,'%d-%m-%Y')) - to_days(str_to_date(va_g1_4,'%d-%m-%Y')))    <=27  and (ABS(str_to_date(concat(Date_Format(str_to_date(va_g1_5,'%d-%m-%Y'),'%d-%m-%Y'),' ', STR_TO_DATE(va_g1_5_time,  '%H:%i')),'%d-%m-%Y %H:%i')) - ABS(str_to_date(concat(Date_Format(str_to_date(va_g1_4,'%d-%m-%Y'),'%d-%m-%Y'),' ', STR_TO_DATE(va_g1_4_time,  '%H:%i')),'%d-%m-%Y %H:%i'))) >0 ) union all select 'number of neonatal deaths' as field, 'cumulative' as cluster_type,count(*) year_2019  from cod_vasa where Date_Format(str_to_date(va_g1_5, '%d-%m-%Y'),'%Y')='2019' and ((to_days(str_to_date(va_g1_5,'%d-%m-%Y')) - to_days(str_to_date(va_g1_4,'%d-%m-%Y')))    <=27  and (ABS(str_to_date(concat(Date_Format(str_to_date(va_g1_5,'%d-%m-%Y'),'%d-%m-%Y'),' ', STR_TO_DATE(va_g1_5_time,  '%H:%i')),'%d-%m-%Y %H:%i')) - ABS(str_to_date(concat(Date_Format(str_to_date(va_g1_4,'%d-%m-%Y'),'%d-%m-%Y'),' ', STR_TO_DATE(va_g1_4_time,  '%H:%i')),'%d-%m-%Y %H:%i'))) >0 )  union all select 'Neonatal mortality rate' as field, 'high mortality' as cluster_type, round(((select count(*)  from cod_vasa where Date_Format(str_to_date(va_g1_5, '%d-%m-%Y'),'%Y')='2019' and ((mid(va_g1_1,5,2) between '01' and '20') or (mid(va_g1_1,5,2) between '35' and '37')) and  ((to_days(str_to_date(va_g1_5,'%d-%m-%Y')) - to_days(str_to_date(va_g1_4,'%d-%m-%Y')))    <=27  and (ABS(str_to_date(concat(Date_Format(str_to_date(va_g1_5,'%d-%m-%Y'),'%d-%m-%Y'),' ', STR_TO_DATE(va_g1_5_time,  '%H:%i')),'%d-%m-%Y %H:%i')) - ABS(str_to_date(concat(Date_Format(str_to_date(va_g1_4,'%d-%m-%Y'),'%d-%m-%Y'),' ', STR_TO_DATE(va_g1_4_time,  '%H:%i')),'%d-%m-%Y %H:%i'))) >0 )) 	/  (select count(*)   from view_form1 where form1_q24='1' and Date_Format(str_to_date(form1_q18, '%d-%m-%Y'),'%Y')='2019' and ((pw_block between '01' and '20') or (pw_block between '35' and '37')))   ) * 1000,  0) as year_2019 union all select 'Neonatal mortality rate' as field, 'low mortality' as cluster_type, round(((select count(*)  from cod_vasa where Date_Format(str_to_date(va_g1_5, '%d-%m-%Y'),'%Y')='2019' and ((mid(va_g1_1,5,2) between '21' and '34') or mid(va_g1_1,5,2) >='38')  and  ((to_days(str_to_date(va_g1_5,'%d-%m-%Y')) - to_days(str_to_date(va_g1_4,'%d-%m-%Y')))     <=27  and (ABS(str_to_date(concat(Date_Format(str_to_date(va_g1_5,'%d-%m-%Y'),'%d-%m-%Y'),' ', STR_TO_DATE(va_g1_5_time,  '%H:%i')),'%d-%m-%Y %H:%i')) - ABS(str_to_date(concat(Date_Format(str_to_date(va_g1_4,'%d-%m-%Y'),'%d-%m-%Y'),' ', STR_TO_DATE(va_g1_4_time,  '%H:%i')),'%d-%m-%Y %H:%i'))) >0 )) 	/  (select count(*)   from view_form1 where form1_q24='1' and Date_Format(str_to_date(form1_q18, '%d-%m-%Y'),'%Y')='2019' and ((pw_block between '21' and '34') or pw_block >='38'))   ) * 1000,  0) as year_2019 union all select 'Neonatal mortality rate' as field, 'cumulative' as cluster_type, round(((select count(*)  from cod_vasa where Date_Format(str_to_date(va_g1_5, '%d-%m-%Y'),'%Y')='2019' and ((to_days(str_to_date(va_g1_5,'%d-%m-%Y')) - to_days(str_to_date(va_g1_4,'%d-%m-%Y')))     <=27  and (ABS(str_to_date(concat(Date_Format(str_to_date(va_g1_5,'%d-%m-%Y'),'%d-%m-%Y'),' ', STR_TO_DATE(va_g1_5_time,  '%H:%i')),'%d-%m-%Y %H:%i')) - ABS(str_to_date(concat(Date_Format(str_to_date(va_g1_4,'%d-%m-%Y'),'%d-%m-%Y'),' ', STR_TO_DATE(va_g1_4_time,  '%H:%i')),'%d-%m-%Y %H:%i'))) >0 )) 	/  (select count(*)   from view_form1 where form1_q24='1' and Date_Format(str_to_date(form1_q18, '%d-%m-%Y'),'%Y')='2019')   ) * 1000,  0) as year_2019	 union all select 'number of day zero neonatal deaths' as field, 'high mortality' as cluster_type,count(*) year_2019  from cod_vasa where Date_Format(str_to_date(va_g1_5, '%d-%m-%Y'),'%Y')='2019' and ((mid(va_g1_1,5,2) between '01' and '20') or (mid(va_g1_1,5,2) between '35' and '37')) and  ((to_days(str_to_date(va_g1_5,'%d-%m-%Y')) - to_days(str_to_date(va_g1_4,'%d-%m-%Y'))) =0  and (ABS(str_to_date(concat(Date_Format(str_to_date(va_g1_5,'%d-%m-%Y'),'%d-%m-%Y'),' ', STR_TO_DATE(va_g1_5_time,  '%H:%i')),'%d-%m-%Y %H:%i')) - ABS(str_to_date(concat(Date_Format(str_to_date(va_g1_4,'%d-%m-%Y'),'%d-%m-%Y'),' ', STR_TO_DATE(va_g1_4_time,  '%H:%i')),'%d-%m-%Y %H:%i'))) >0 ) union all select 'number of day zero neonatal deaths' as field, 'low mortality' as cluster_type,count(*) year_2019  from cod_vasa where Date_Format(str_to_date(va_g1_5, '%d-%m-%Y'),'%Y')='2019' and ((mid(va_g1_1,5,2) between '21' and '34') or mid(va_g1_1,5,2) >='38') and ((to_days(str_to_date(va_g1_5,'%d-%m-%Y')) - to_days(str_to_date(va_g1_4,'%d-%m-%Y')))    =0    and (ABS(str_to_date(concat(Date_Format(str_to_date(va_g1_5,'%d-%m-%Y'),'%d-%m-%Y'),' ', STR_TO_DATE(va_g1_5_time,  '%H:%i')),'%d-%m-%Y %H:%i')) - ABS(str_to_date(concat(Date_Format(str_to_date(va_g1_4,'%d-%m-%Y'),'%d-%m-%Y'),' ', STR_TO_DATE(va_g1_4_time,  '%H:%i')),'%d-%m-%Y %H:%i'))) >0 ) union all select 'number of day zero neonatal deaths' as field, 'cumulative' as cluster_type,count(*) year_2019  from cod_vasa where Date_Format(str_to_date(va_g1_5, '%d-%m-%Y'),'%Y')='2019' and ((to_days(str_to_date(va_g1_5,'%d-%m-%Y')) - to_days(str_to_date(va_g1_4,'%d-%m-%Y'))) =0    and (ABS(str_to_date(concat(Date_Format(str_to_date(va_g1_5,'%d-%m-%Y'),'%d-%m-%Y'),' ', STR_TO_DATE(va_g1_5_time,  '%H:%i')),'%d-%m-%Y %H:%i')) - ABS(str_to_date(concat(Date_Format(str_to_date(va_g1_4,'%d-%m-%Y'),'%d-%m-%Y'),' ', STR_TO_DATE(va_g1_4_time,  '%H:%i')),'%d-%m-%Y %H:%i'))) >0 ) union all select 'Day zero Neonatal mortality rate' as field, 'high mortality' as cluster_type, round(((select count(*)  from cod_vasa where Date_Format(str_to_date(va_g1_5, '%d-%m-%Y'),'%Y')='2019' and ((mid(va_g1_1,5,2) between '01' and '20') or (mid(va_g1_1,5,2) between '35' and '37')) and  ((to_days(str_to_date(va_g1_5,'%d-%m-%Y')) - to_days(str_to_date(va_g1_4,'%d-%m-%Y'))) =0    and (ABS(str_to_date(concat(Date_Format(str_to_date(va_g1_5,'%d-%m-%Y'),'%d-%m-%Y'),' ', STR_TO_DATE(va_g1_5_time,  '%H:%i')),'%d-%m-%Y %H:%i')) - ABS(str_to_date(concat(Date_Format(str_to_date(va_g1_4,'%d-%m-%Y'),'%d-%m-%Y'),' ', STR_TO_DATE(va_g1_4_time,  '%H:%i')),'%d-%m-%Y %H:%i'))) >0 )) 	/  (select count(*)   from view_form1 where form1_q24='1' and Date_Format(str_to_date(form1_q18, '%d-%m-%Y'),'%Y')='2019' and ((pw_block between '01' and '20') or (pw_block between '35' and '37')))   ) * 1000,  0) as year_2019 union all select 'Day zero Neonatal mortality rate' as field, 'low mortality' as cluster_type, round(((select count(*)  from cod_vasa where Date_Format(str_to_date(va_g1_5, '%d-%m-%Y'),'%Y')='2019' and ((mid(va_g1_1,5,2) between '21' and '34') or mid(va_g1_1,5,2) >='38')  and  ((to_days(str_to_date(va_g1_5,'%d-%m-%Y')) - to_days(str_to_date(va_g1_4,'%d-%m-%Y'))) =0    and (ABS(str_to_date(concat(Date_Format(str_to_date(va_g1_5,'%d-%m-%Y'),'%d-%m-%Y'),' ', STR_TO_DATE(va_g1_5_time,  '%H:%i')),'%d-%m-%Y %H:%i')) - ABS(str_to_date(concat(Date_Format(str_to_date(va_g1_4,'%d-%m-%Y'),'%d-%m-%Y'),' ', STR_TO_DATE(va_g1_4_time,  '%H:%i')),'%d-%m-%Y %H:%i'))) >0 )) 	/  (select count(*)   from view_form1 where form1_q24='1' and Date_Format(str_to_date(form1_q18, '%d-%m-%Y'),'%Y')='2019' and ((pw_block between '21' and '34') or pw_block >='38'))   ) * 1000,  0) as year_2019 union all select 'Day zero Neonatal mortality rate' as field, 'cumulative' as cluster_type, round(((select count(*)  from cod_vasa where Date_Format(str_to_date(va_g1_5, '%d-%m-%Y'),'%Y')='2019' and ((to_days(str_to_date(va_g1_5,'%d-%m-%Y')) - to_days(str_to_date(va_g1_4,'%d-%m-%Y'))) =0    and (ABS(str_to_date(concat(Date_Format(str_to_date(va_g1_5,'%d-%m-%Y'),'%d-%m-%Y'),' ', STR_TO_DATE(va_g1_5_time,  '%H:%i')),'%d-%m-%Y %H:%i')) - ABS(str_to_date(concat(Date_Format(str_to_date(va_g1_4,'%d-%m-%Y'),'%d-%m-%Y'),' ', STR_TO_DATE(va_g1_4_time,  '%H:%i')),'%d-%m-%Y %H:%i'))) >0 )) 	/  (select count(*)   from view_form1 where form1_q24='1' and Date_Format(str_to_date(form1_q18, '%d-%m-%Y'),'%Y')='2019')   ) * 1000,  0) as year_2019	 ) TableB on TableA.field=TableB.field and TableA.cluster_type=TableB.cluster_type", con);
                {
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











        private void ShowEnrollment()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("(select sra_name as 'User Name',pw_block as Block, count(*) as 'Enrollment Done' from view_form1 where str_to_date(form1_q01, '%d-%m-%Y') BETWEEN str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y')  and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')  group by sra_name,pw_block order by pw_block,sra_name) union all (select 'All User','Cumulative', count(*) as 'Enrollment Done' from view_form1 where str_to_date(form1_q01, '%d-%m-%Y') BETWEEN str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y')  and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y') ) ", con);
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
                            GridView1.Rows[GridView1.Rows.Count - 1].BackColor = System.Drawing.Color.FromName("#ebf598");
                            GridView1.Rows[GridView1.Rows.Count - 1].ForeColor = System.Drawing.Color.FromName("#006e25");
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




        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#fdcb6e'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='White'");

                if (e.Row.Cells[2].Text == "cumulative")
                {
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#ebf598'");
                    e.Row.BackColor = Color.FromName("#ebf598");
                    e.Row.ForeColor = Color.FromName("#006e25");
                }
            }   
        }




        private void ShowFollowups()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("(select sra_name as 'User Name',pw_block as Block, count(*) as 'Followups Done' from view_form2 where str_to_date(q01, '%d-%m-%Y') BETWEEN str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y')  and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')  group by sra_name,pw_block order by pw_block,sra_name) union all (select 'All User','Cumulative', count(*) as 'Followups Done' from view_form2 where str_to_date(q01, '%d-%m-%Y') BETWEEN str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y')  and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))", con);
                {
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
                            GridView2.Rows[GridView2.Rows.Count - 1].BackColor = System.Drawing.Color.FromName("#ebf598");
                            GridView2.Rows[GridView2.Rows.Count - 1].ForeColor = System.Drawing.Color.FromName("#006e25");
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






        private void LoadChartBirthCapturing()
        {
            try
            {
                string query = string.Format("select concat(Date_Format(str_to_date(form1_q01, '%d-%m-%Y'),'%b'),'-',Date_Format(str_to_date(form1_q01, '%d-%m-%Y'),'%y')) as Year, count(*) as birth_capture	   from view_form1  group by Year(str_to_date(form1_q01, '%d-%m-%Y')),Month(str_to_date(form1_q01, '%d-%m-%Y'))");
                DataTable dt = GetData(query);
                Chart2.DataSource = dt;
                Chart2.Series[0].XValueMember = "Year";
                Chart2.Series[0].YValueMembers = "birth_capture";
                Chart2.Series[0].Label = "#VALY";
                Chart2.ChartAreas["ChartArea2"].AxisX.MajorGrid.Enabled = false;
                Chart2.DataBind();


                ////  Target Line:
                //StripLine targetLine = new StripLine();
                //targetLine.StripWidth = 0;
                //targetLine.BorderColor = ColorTranslator.FromHtml("#55efc4");
                //targetLine.BorderWidth = 3;
                //targetLine.BorderDashStyle = ChartDashStyle.Dash;
                //targetLine.IntervalOffset = 120; // In my case I am plotting percentages.
                //targetLine.Text = "Target";
                //targetLine.TextOrientation = TextOrientation.Horizontal;
                //targetLine.ForeColor = targetLine.BorderColor;
                //Chart2.ChartAreas[0].AxisY.StripLines.Add(targetLine);
            }
            catch (Exception ex)
            {
                Response.Write("<script type=\"text/javascript\">alert('" + ex.Message + "')</script>");
            }

        }



        private void LoadChartLiveBirth()
        {
            try
            {
                string query = string.Format("select concat(Date_Format(str_to_date(form1_q18, '%d-%m-%Y'),'%b'),'-',Date_Format(str_to_date(form1_q18, '%d-%m-%Y'),'%y')) as Year, count(*) as birth_capture	   from view_form1  where   form1_q24='1'    group by Year(str_to_date(form1_q18, '%d-%m-%Y')),Month(str_to_date(form1_q18, '%d-%m-%Y'))");
                DataTable dt = GetData(query);
                Chart3.DataSource = dt;
                Chart3.Series[0].XValueMember = "Year";
                Chart3.Series[0].YValueMembers = "birth_capture";
                Chart3.Series[0].Label = "#VALY";
                Chart3.ChartAreas["ChartArea3"].AxisX.MajorGrid.Enabled = false;
                Chart3.DataBind();


                ////   Target Line:
                //StripLine targetLine = new StripLine();
                //targetLine.StripWidth = 0;
                //targetLine.BorderColor = ColorTranslator.FromHtml("#55efc4");
                //targetLine.BorderWidth = 3;
                //targetLine.BorderDashStyle = ChartDashStyle.Dash;
                //targetLine.IntervalOffset = 120; // In my case I am plotting percentages.
                //targetLine.Text = "Target";
                //targetLine.TextOrientation = TextOrientation.Horizontal;
                //targetLine.ForeColor = targetLine.BorderColor;
                //Chart3.ChartAreas[0].AxisY.StripLines.Add(targetLine);
            }
            catch (Exception ex)
            {
                Response.Write("<script type=\"text/javascript\">alert('" + ex.Message + "')</script>");
            }

        }




        //For Cumulative:
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


    }
}