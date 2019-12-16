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
    public partial class followupsSecA : System.Web.UI.Page
    {
        MySqlDataReader dreader;
        string ConDataBase = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;





        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["FormStartTime"] = null;
                Session["FormEndTime"] = null;
                Session["DOB"] = null;
                Session["CurrentAge"] = null;
                Session["Last_Length"] = null;
                Session["Last_HeadCircum"] = null;
                Session["Avg_Weight"] = null;
                Session["Avg_Length"] = null;
                Session["Avg_MUAC"] = null;
                Session["Avg_HeadCircum"] = null;
                Session["LastDOV"] = null;

                Session["FormStartTime"] = DateTime.Now.ToShortTimeString();

                SearchInfo();

                if (lbeMotherID.Text == "")
                {
                    Response.Redirect("searchChild.aspx");
                }

                Session["WebForm"] = "searchChild";

                lbeChildID.Text = Convert.ToString(Session["CP_child_id"]);
                lbeFollowupNum.Text = Convert.ToString(Session["CP_followup_no"]);
                lbeAge.Text = Convert.ToString(Session["CP_age"]);
                txtChildName.Focus();
                if (lbeAge.Text != "27" && lbeAge.Text != "59" && lbeAge.Text != "89" && lbeAge.Text != "179")
                {
                    divBabyLength.Style["display"] = "none";
                    divBabyMUAC.Style["display"] = "none";
                    divBabyHeadCircum.Style["display"] = "none";
                }
            }
        }


        public void showalert(string message)
        {
            string script = @"alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
        }





        protected void submit_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbeMotherID.Text == "")
                {
                    Response.Redirect("searchChild.aspx");
                }
                string currentDate = DateTime.Now.ToString("dd-MM-yyyy");
                int diff_Weight = 0;
                float diff_Length = 0;
                float diff_MUAC = 0;
                float diff_HeadCircum = 0;
                LastFollowupDOV();

                if (txtq16.Text == "1" && txtq17.Text == "1")
                {
                    LastFollowupValues();
                    EnrollmentValues();

                    diff_Weight = Convert.ToInt32(txtBabyWeight1.Text) - Convert.ToInt32(txtBabyWeight2.Text);
                    Session["Avg_Weight"] = Convert.ToString((Convert.ToInt32(txtBabyWeight1.Text) + Convert.ToInt32(txtBabyWeight2.Text)) / 2);

                    if (lbeAge.Text == "27" || lbeAge.Text == "59" || lbeAge.Text == "89" || lbeAge.Text == "179")
                    {
                        diff_Length = float.Parse(txtBabyLength1.Text) - float.Parse(txtBabyLength2.Text);
                        diff_MUAC = float.Parse(txtBabyMUAC1.Text) - float.Parse(txtBabyMUAC2.Text);
                        diff_HeadCircum = float.Parse(txtBabyHeadCircum1.Text) - float.Parse(txtBabyHeadCircum2.Text);


                        Session["Avg_Length"] = Convert.ToString((float.Parse(txtBabyLength1.Text) + float.Parse(txtBabyLength2.Text)) / 2);
                        Session["Avg_MUAC"] = Convert.ToString((float.Parse(txtBabyMUAC1.Text) + float.Parse(txtBabyMUAC2.Text)) / 2);
                        Session["Avg_HeadCircum"] = Convert.ToString((float.Parse(txtBabyHeadCircum1.Text) + float.Parse(txtBabyHeadCircum2.Text)) / 2);
                    }
                }


                if (txtq16.Text == "1" && txtq17.Text == "1" && (diff_Weight > 50 || diff_Weight < -50))
                {
                    showalert("Child Weight difference should be Less than 50!");
                    txtBabyWeight1.Focus();
                }
                else if (txtBabyLength1.Text != "" && (diff_Length > 0.5 || diff_Length < -0.5))
                {
                    showalert("Child Length difference should be Less than 0.5!");
                    txtBabyLength1.Focus();
                }
                else if (txtBabyMUAC1.Text != "" && (diff_MUAC > 0.5 || diff_MUAC < -0.5))
                {
                    showalert("Child MUAC difference should be Less than 0.5!");
                    txtBabyMUAC1.Focus();
                }
                else if (txtBabyHeadCircum1.Text != "" && (diff_HeadCircum > 0.5 || diff_HeadCircum < -0.5))
                {
                    showalert("Child Head Circum difference should be Less than 0.5!");
                    txtBabyHeadCircum1.Focus();
                }

                //Check with Previous Values:
                else if (txtBabyLength1.Text != "" && txtBabyLength1.Text != "00.0" && (float.Parse(Convert.ToString(Session["Avg_Length"])) <= float.Parse(Convert.ToString(Session["Last_Length"]))))
                {
                    showalert("Child Length should be greater than Previous Value: " + Convert.ToString(Session["Last_Length"]));
                    txtBabyLength1.Focus();
                }
                else if (txtBabyHeadCircum1.Text != "" && txtBabyHeadCircum1.Text != "00.0" && (float.Parse(Convert.ToString(Session["Avg_HeadCircum"])) <= float.Parse(Convert.ToString(Session["Last_HeadCircum"]))))
                {
                    showalert("Child Head Circumference should be greater than Previous Value: " + Convert.ToString(Session["Last_HeadCircum"]));
                    txtBabyHeadCircum1.Focus();
                }



                // For Date of Visit:
                else if (DateTime.ParseExact(txtDOV.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentDate, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Enter Less than Current Date!");
                    txtDOV.Focus();
                }
                else if (DateTime.ParseExact(txtDOV.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(Convert.ToString(Session["CP_end_date"]), "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Enter Less than End Date: " + Convert.ToString(Session["CP_end_date"]));
                    txtDOV.Focus();
                }
                else if (DateTime.ParseExact(txtDOV.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < (DateTime.ParseExact(Convert.ToString(Session["CP_start_date"]), "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Enter Greater than Start Date: " + Convert.ToString(Session["CP_start_date"]));
                    txtDOV.Focus();
                }
                // For Date of Death:
                else if (txtq18.Text != "" && (DateTime.ParseExact(txtq18.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentDate, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Enter Less than Current Date!");
                    txtq18.Focus();
                }
                else if (txtq18.Text != "" && (DateTime.ParseExact(txtq18.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(Convert.ToString(Session["CP_end_date"]), "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Enter Less than End Date: " + Convert.ToString(Session["CP_end_date"]));
                    txtq18.Focus();
                }
                else if (txtq18.Text != "" &&  Session["LastDOV"] != null && (DateTime.ParseExact(txtq18.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < (DateTime.ParseExact(Convert.ToString(Session["LastDOV"]), "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Enter Greater than Last Date of Visit: " + Convert.ToString(Session["LastDOV"]));
                    txtq18.Focus();
                }
                else
                {
                    if (CompleteForm() == false)
                    {
                        InsertForm2();
                        UpdateChildName();
                        UpdateFollowupStatus();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('Form Saved Successfully');window.location.href='searchChild.aspx';", true);
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script type=\"text/javascript\">alert('" + ex.Message + "')</script>");
            }
        }





        private void SearchInfo()
        {
            MySqlConnection con = new MySqlConnection(ConDataBase);
            try
            {
                con.Open();
                MySqlCommand cmd;
                cmd = new MySqlCommand("select a.form1_id,c.record_id,b.mother_id,c.pw_id, c.child_id,concat(b.pw_site,b.pw_para,b.pw_block,b.pw_structure,b.pw_house_hold,b.pw_woman_number) as dssid,a.form1_q01,a.form1_q02,b.pw_site,b.pw_para,b.pw_block,b.pw_structure,b.pw_house_hold,b.pw_woman_number,c.child_name,b.pw_name,b.pw_husband_name,a.form1_q15,a.refused_reason,a.form1_q16,a.form1_q17,Date_Format(str_to_date(c.form1_q18, '%d-%m-%Y'),'%d-%m-%Y') as form1_q18,c.form1_q19,c.form1_q20,c.form1_q21,c.form1_q22,c.form1_q23,c.form1_q24,c.form1_q25,c.form1_q26,c.form1_q27,c.reader1_code,c.reader2_code,c.form1_q28_r1,c.form1_q28_r2,round((c.form1_q28_r1+c.form1_q28_r2)/2,0) as q29,c.form1_q30_r1,c.form1_q30_r2,round((c.form1_q30_r1+c.form1_q30_r2)/2,1) as q31,c.form1_q32_r1,c.form1_q32_r2,round((c.form1_q32_r1+c.form1_q32_r2)/2,1) as q33,c.form1_q34_r1,c.form1_q34_r2,round((c.form1_q34_r1+c.form1_q34_r2)/2,1) as q35,c.form1_q36,c.form1_q37_days,c.form1_q37_hours,c.form1_q37_minutes,c.form1_q38,c.form1_q39_days,c.form1_q39_hours,c.form1_q39_minutes,c.form1_q40,c.form1_q41,c.form1_q42,c.form1_q43,c.form1_q44,c.form1_q45,c.form1_q46,c.form1_q47,c.form1_q48,c.form1_q49,c.form1_q50,c.form1_q51,c.form1_q52,d.sra_name from form_1 as a left join pregnant_woman as b on a.pw_id=b.pw_id left join child_record as c on c.pw_id=b.pw_id left join team as d on d.team_id=a.team_id where c.pw_id='" + Convert.ToString(Session["CP_pw_id"]) + "' and c.child_id='" + Convert.ToString(Session["CP_child_id"]) + "'", con);
                dreader = cmd.ExecuteReader();
                if (dreader.Read())
                {
                    lbeMotherID.Text = dreader["mother_id"].ToString();
                    lbeMotherNm.Text = dreader["pw_name"].ToString();
                    lbeFatherNm.Text = dreader["pw_husband_name"].ToString();
                    txtChildName.Text = dreader["child_name"].ToString();
                    lbeDSSID.Text = dreader["dssid"].ToString();
                    Session["DOB"] = dreader["form1_q18"].ToString();
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



        private void LastFollowupValues()
        {
            MySqlConnection con = new MySqlConnection(ConDataBase);
            try
            {
                con.Open();
                MySqlCommand cmd;
                cmd = new MySqlCommand("select * from view_form2 where mother_id='" + lbeMotherID.Text + "' and child_id='" + Convert.ToString(Session["CP_child_id"]) + "' and followup_num= (select max(cast(followup_num as UNSIGNED)) as followup_num from view_form2 where mother_id='" + lbeMotherID.Text + "' and child_id='" + Convert.ToString(Session["CP_child_id"]) + "' and q23!='' and q23!='00.0' and q27!='00.0' and cast(followup_num as UNSIGNED)  < '" + lbeFollowupNum.Text + "')", con);
                dreader = cmd.ExecuteReader();
                if (dreader.Read())
                {
                    Session["Last_Length"] = dreader["q23"].ToString();
                    Session["Last_HeadCircum"] = dreader["q27"].ToString();
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



        private void LastFollowupDOV()
        {
            MySqlConnection con = new MySqlConnection(ConDataBase);
            try
            {
                con.Open();
                MySqlCommand cmd;
                cmd = new MySqlCommand("select * from view_form2 where mother_id='" + lbeMotherID.Text + "' and child_id='" + Convert.ToString(Session["CP_child_id"]) + "' and followup_num= (select max(cast(followup_num as UNSIGNED)) as followup_num from view_form2 where mother_id='" + lbeMotherID.Text + "' and child_id='" + Convert.ToString(Session["CP_child_id"]) + "')", con);
                dreader = cmd.ExecuteReader();
                if (dreader.Read())
                {
                    Session["LastDOV"] = dreader["q01"].ToString();
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

        private void EnrollmentValues()
        {
            MySqlConnection con = new MySqlConnection(ConDataBase);
            try
            {
                con.Open();
                MySqlCommand cmd;
                cmd = new MySqlCommand("select * from view_form1 where mother_id='" + lbeMotherID.Text + "' and child_id='" + Convert.ToString(Session["CP_child_id"]) + "'", con);
                dreader = cmd.ExecuteReader();
                if (dreader.Read())
                {
                    if (Session["Last_Length"] == null || (Convert.ToString(Session["Last_Length"])) == "")
                    {
                        Session["Last_Length"] = float.Parse(dreader["q31"].ToString());
                    }
                    if (Session["Last_HeadCircum"] == null || (Convert.ToString(Session["Last_HeadCircum"])) == "")
                    {
                        Session["Last_HeadCircum"] = float.Parse(dreader["q35"].ToString());
                    }
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



        private void UpdateChildName()
        {
            MySqlConnection con = new MySqlConnection(ConDataBase);
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("update child_record set child_name='" + txtChildName.Text.ToUpper() + "'  where  pw_id='" + Convert.ToString(Session["CP_pw_id"]) + "' and child_id='" + Convert.ToString(Session["CP_child_id"]) + "'", con);
                cmd.ExecuteNonQuery();
                if (txtq18.Text != "")
                {
                    UpdateFollowupStatusforDeathChild();
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



        private void UpdateFollowupStatus()
        {
            MySqlConnection con = new MySqlConnection(ConDataBase);
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("update followups set status='1'  where  mother_id='" + lbeMotherID.Text + "' and child_id='" + lbeChildID.Text + "' and followup_no='" + lbeFollowupNum.Text + "'", con);
                cmd.ExecuteNonQuery();
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


        private void UpdateFollowupStatusforDeathChild()
        {
            MySqlConnection con = new MySqlConnection(ConDataBase);
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("update followups set status='9'  where  mother_id='" + lbeMotherID.Text + "' and child_id='" + lbeChildID.Text + "' and status='3'", con);
                cmd.ExecuteNonQuery();
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




        private void InsertForm2()
        {
            MySqlConnection con = new MySqlConnection(ConDataBase);
            try
            {
                if (Session["DOB"] != null && Convert.ToString(Session["DOB"]) != "")
                {
                    System.DateTime startDate = DateTime.ParseExact(Convert.ToString(Session["DOB"]), "dd-MM-yyyy", System.Globalization.CultureInfo.CurrentCulture);
                    System.DateTime endDate = DateTime.ParseExact(txtDOV.Text, "dd-MM-yyyy", System.Globalization.CultureInfo.CurrentCulture);
                    Session["CurrentAge"] = Convert.ToString((endDate - startDate).TotalDays);
                }

                Session["FormEndTime"] = DateTime.Now.ToShortTimeString();
                con.Open();
                MySqlCommand cmd = new MySqlCommand("insert into form_2 (pw_id,	child_id,	followup_num,	team_id,	q01,	q02,	q15,	q16,	refused_reason,	q17,	q18,	q19,	q20_reader1_reading,	q20_reader2_reading,	q21,	q22_reader1_reading,	q22_reader2_reading,q23,q24_reader1_reading,q24_reader2_reading,q25,q26_reader1_reading,q26_reader2_reading,q27,q28,q29,q30,q35,q36,q37,q38,q39,q40,q41,q42,q43,q44,q45,reader1_code,reader2_code) values ('" + Convert.ToString(Session["CP_pw_id"]) + "','" + lbeChildID.Text + "','" + lbeFollowupNum.Text + "','" + Convert.ToString(Session["team_id"]) + "','" + txtDOV.Text + "','" + Convert.ToString(Session["FormStartTime"]) + "','" + Convert.ToString(Session["CurrentAge"]) + "','" + txtq16.Text + "','" + txtq16Reason.Text + "','" + txtq17.Text + "','" + txtq18.Text + "','" + txtq19.Text + "','" + txtBabyWeight1.Text + "','" + txtBabyWeight2.Text + "','" + Convert.ToString(Session["Avg_Weight"]) + "','" + txtBabyLength1.Text + "','" + txtBabyLength2.Text + "','" + Convert.ToString(Session["Avg_Length"]) + "','" + txtBabyMUAC1.Text + "','" + txtBabyMUAC2.Text + "','" + Convert.ToString(Session["Avg_MUAC"]) + "','" + txtBabyHeadCircum1.Text + "','" + txtBabyHeadCircum2.Text + "','" + Convert.ToString(Session["Avg_HeadCircum"]) + "','" + txtq28.Text + "','" + txtq29.Text + "','" + txtq30.Text + "','" + txtq35.Text + "','" + txtq36.Text + "','" + txtq37.Text + "','" + txtq38.Text + "','" + txtq39.Text + "','" + txtq40.Text + "','" + txtq41.Text + "','" + txtq42.Text + "','" + txtq43.Text + "','" + txtq44.Text + "','" + Convert.ToString(Session["FormEndTime"]) + "','" + Convert.ToString(Session["CPusername"]) + "','chw')", con);
                cmd.ExecuteNonQuery();
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



        public bool CompleteForm()
        {
            bool exist = false;
            MySqlConnection con = new MySqlConnection(ConDataBase);
            MySqlCommand cmd = new MySqlCommand("select * from form_2 where pw_id='" + Convert.ToString(Session["CP_pw_id"]) + "' and child_id='" + lbeChildID.Text + "' and followup_num='" + lbeFollowupNum.Text + "'", con);
            con.Open();
            try
            {
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read() == true)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('Record Already Exist!');window.location.href='searchChild.aspx';", true);
                    exist = true;
                }
            }
            finally
            {
                con.Close();
            }
            return exist;
        }


    }
}