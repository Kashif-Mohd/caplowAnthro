using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace caplowanthro
{
    public partial class main : System.Web.UI.MasterPage
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            //lbeUserName.Text = "(Logged in: " + Convert.ToString(Session["CPusername"]) + ")";
            lbeUserNav.Text = Convert.ToString(Session["CPusername"]);

            // For Admin User Access:
            if (Convert.ToString(Session["CP_Login_status"]) == "123")
            {
                navEntryForms.Visible = true;
            }


            // End Navigation:





            if (Session["CPusername"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                if (Convert.ToString(Session["WebForm"]) == "ListOfUsers")
                {
                    TabUsr.Attributes.Add("class", "active");
                    listUsr.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "Dashboard")
                {
                    dashboard.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }

                    // Task
                else if (Convert.ToString(Session["WebForm"]) == "taskList")
                {
                    Task.Attributes.Add("class", "active");
                    tasklist.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "taskListPW")
                {
                    Task.Attributes.Add("class", "active");
                    tasklistPW.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }


                    //Entry Forms
                else if (Convert.ToString(Session["WebForm"]) == "searchChild")
                {
                    EntryForms.Attributes.Add("class", "active");
                    searchChild.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }



                // Forms
                else if (Convert.ToString(Session["WebForm"]) == "showvaccination")
                {
                    Forms.Attributes.Add("class", "active");
                    vaccination.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "showform1")
                {
                    Forms.Attributes.Add("class", "active");
                    showform1.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "showform2")
                {
                    Forms.Attributes.Add("class", "active");
                    showform2.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }


                    // Error or Duplicate
                else if (Convert.ToString(Session["WebForm"]) == "duplicateForm1")
                {
                    duplicate.Attributes.Add("class", "active");
                    duplicateForm1.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "duplicateForm2")
                {
                    duplicate.Attributes.Add("class", "active");
                    duplicateForm2.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }


                    // Setting
                else if (Convert.ToString(Session["WebForm"]) == "Setting")
                {
                    setting.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }

            }
        }


    }
}