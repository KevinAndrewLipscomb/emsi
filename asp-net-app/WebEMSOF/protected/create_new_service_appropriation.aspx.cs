using Class_biz_appropriations;
using Class_biz_services;
using Class_db;
using Class_db_trail;
using kix;
using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Drawing;
using System.Web.UI;

namespace create_new_service_appropriation
  {
  public partial class TWebForm_create_new_service_appropriation: ki_web_ui.page_class
    {

    private struct p_type
      {
      public decimal amount;
      public TClass_biz_appropriations biz_appropriations;
      public TClass_biz_services biz_services;
      public TClass_db db;
      public TClass_db_trail db_trail;
      public string match_level_id_of_region_dictum;
      public decimal unappropriated_amount;
      }

    private p_type p; // Private Parcel of Page-Pertinent Process-Persistent Parameters

        // / <summary>
        // / Required method for Designer support -- do not modify
        // / the contents of this method with the code editor.
        // / </summary>
        private void InitializeComponent()
        {
            PreRender += TWebForm_create_new_service_appropriation_PreRender;
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            Title = Server.HtmlEncode(ConfigurationManager.AppSettings["application_name"]) + " - create_new_service_appropriation";
            if (IsPostBack)
            {
                if ((Session[InstanceId() + ".p"] != null))
                {
                    p = (p_type)(Session[InstanceId() + ".p"]);
                }
                else
                {
                    Server.Transfer("~/timeout.aspx");
                }
            }
            else
            {
                if (Request.ServerVariables["URL"] == Request.CurrentExecutionFilePath)
                {
                    Session.Clear();
                    Server.Transfer("~/login.aspx");
                }
                // Initialize implementation-scoped variables.
                p.amount = 0;
                p.db = new TClass_db();
                p.db_trail = new TClass_db_trail();
                Label_parent_appropriation_amount.Text = decimal.Parse(Session["parent_appropriation_amount"].ToString()).ToString("C");
                Label_region_name.Text = Session["region_name"].ToString();
                Label_fiscal_year_designator.Text = Session["fiscal_year_designator"].ToString();
                Label_sum_of_service_appropriations.Text = decimal.Parse(Session["sum_of_service_appropriations"].ToString()).ToString("C");
                p.unappropriated_amount = (decimal)(Session["unappropriated_amount"]);
                Label_unappropriated_amount.Text = p.unappropriated_amount.ToString("C");
                if (p.unappropriated_amount < 0)
                {
                    Label_unappropriated_amount.Font.Bold = true;
                    Label_unappropriated_amount.ForeColor = Color.Red;
                }
                p.biz_appropriations = new TClass_biz_appropriations();
                p.biz_services = new TClass_biz_services();
                p.biz_services.BindListControl(Session["county_user_id"].ToString(), DropDownList_services, CheckBox_show_out_of_county_services.Checked);
                p.match_level_id_of_region_dictum = p.biz_appropriations.MatchLevelIdOfRegionDictum(Session["region_dictated_appropriation_id"].ToString()).ToString();
                RadioButtonList_match_level.SelectedValue = p.match_level_id_of_region_dictum;
            }
            ScriptManager.GetCurrent(Page).RegisterPostBackControl(Button_add_appropriation_and_repeat);
            ScriptManager.GetCurrent(Page).RegisterPostBackControl(Button_add_appropriation_and_stop);
            ScriptManager.GetCurrent(Page).RegisterPostBackControl(Button_cancel);

        }

        protected override void OnInit(EventArgs e)
        {
            // Required for Designer support
            InitializeComponent();
            base.OnInit(e);
        }

        protected void DropDownList_services_SelectedIndexChanged(object sender, System.EventArgs e)
          {
          if (DropDownList_services.SelectedValue.Length == 0)
            {
            RadioButtonList_match_level.ClearSelection();
            }
          else
            {
            if (p.biz_services.BeDistressed(k.Safe(DropDownList_services.SelectedValue, k.safe_hint_type.NUM)))
              {
              RadioButtonList_match_level.SelectedValue = "3";
              }
            else
              {
              RadioButtonList_match_level.SelectedValue = p.match_level_id_of_region_dictum;
              }
            }
          }

        private void TWebForm_create_new_service_appropriation_PreRender(object sender, System.EventArgs e)
        {
            SessionSet(InstanceId() + ".p", p);
        }

        protected void CustomValidator_amount_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            string amount_string;
            amount_string = k.Safe(args.Value, k.safe_hint_type.REAL_NUM);
            if (amount_string.Length == 0)
            {
                args.IsValid = false;
            }
            else
            {
                p.amount = decimal.Parse(amount_string);
                args.IsValid = (p.amount > 0) && (p.amount <= p.unappropriated_amount);
            }
        }

        protected void CheckBox_unfilter_CheckedChanged(object sender, System.EventArgs e)
        {
            p.biz_services.BindListControl(Session["county_user_id"].ToString(), DropDownList_services, CheckBox_show_out_of_county_services.Checked);
        }

        protected void Button_add_appropriation_and_stop_Click(object sender, System.EventArgs e)
        {
            if (Page.IsValid)
            {
                AddAppropriation();
                BackTrack();
            }
            else
            {
                ValidationAlert();
            }
        }

        protected void Button_cancel_Click(object sender, System.EventArgs e)
        {
            BackTrack();
        }

        protected void Button_add_appropriation_and_repeat_Click(object sender, System.EventArgs e)
        {
            if (Page.IsValid)
            {
                AddAppropriation();
                TextBox_new_amount.Text = k.EMPTY;
                DropDownList_services.SelectedIndex =  -1;
                // Update labels in the Parent appropriation section.
                Label_sum_of_service_appropriations.Text = (decimal.Parse(k.Safe(Label_sum_of_service_appropriations.Text, k.safe_hint_type.REAL_NUM)) + p.amount).ToString("C");
                p.unappropriated_amount -= p.amount;
                Label_unappropriated_amount.Text = p.unappropriated_amount.ToString("C");
                if (p.unappropriated_amount < 0)
                {
                    Label_unappropriated_amount.Font.Bold = true;
                    Label_unappropriated_amount.ForeColor = Color.Red;
                }
            }
        }

        private void AddAppropriation()
        {
            string cc_email_address;
            string max_county_dictated_appropriation_id_string;
            string messageText;
            string service_id_string;
            service_id_string = k.Safe(DropDownList_services.SelectedValue, k.safe_hint_type.NUM);
            p.db.Open();
            // Record the new appropriation.
            using var mysql_command_1 = new MySqlCommand(p.db_trail.Saved("insert into county_dictated_appropriation" + " set region_dictated_appropriation_id = " + Session["region_dictated_appropriation_id"].ToString() + k.COMMA + " service_id = " + service_id_string + k.COMMA + " amount = " + p.amount.ToString() + k.COMMA + " match_level_id = " + k.Safe(RadioButtonList_match_level.SelectedValue, k.safe_hint_type.NUM)), p.db.connection);
            mysql_command_1.ExecuteNonQuery();
            // Initialize a new emsof_request_master record, since at this time there must be a one-to-one relationship between a county-
            // dictated appropriation and an EMSOF request.
            // Get max(county_dictated_appropriation.id), which must be the id of the county_dictated_appropriation record that we just
            // inserted.
            using var mysql_command_2 = new MySqlCommand("select max(id) from county_dictated_appropriation", p.db.connection);
            max_county_dictated_appropriation_id_string = mysql_command_2.ExecuteScalar().ToString();
            // Insert and link back to the above max id.
            using var mysql_command_3 = new MySqlCommand(p.db_trail.Saved("insert into emsof_request_master set county_dictated_appropriation_id = " + max_county_dictated_appropriation_id_string), p.db.connection);
            mysql_command_3.ExecuteNonQuery();
            // Send notice of the appropriation to the service's email address of record.
            // Set up the command to get service's email address of record.
            using var mysql_get_service_email_address = new MySqlCommand("select password_reset_email_address from service_user " + "where id = " + service_id_string, p.db.connection);
            // Set up the command to get the appropriate fiscal year designator.
            using var mysql_get_fy_designator = new MySqlCommand("select designator" + " from fiscal_year" + " join state_dictated_appropriation on (state_dictated_appropriation.fiscal_year_id=fiscal_year.id)" + " join region_dictated_appropriation" + " on (region_dictated_appropriation.state_dictated_appropriation_id=state_dictated_appropriation.id)" + " where region_dictated_appropriation.id = " + Session["region_dictated_appropriation_id"].ToString(), p.db.connection);
            // Set up the command to get the County Coorindator's email address.
            using var mysql_command_4 = new MySqlCommand("select password_reset_email_address from county_user where id = " + Session["county_user_id"].ToString(), p.db.connection);
            cc_email_address = mysql_command_4.ExecuteScalar().ToString();
            // Set up the messageText.
            messageText = "The " + Session["county_name"].ToString() + " County EMSOF Coordinator has made a new EMSOF allocation " + "of " + p.amount.ToString("C") + " to your service for " + mysql_get_fy_designator.ExecuteScalar().ToString() + k.PERIOD + k.NEW_LINE + k.NEW_LINE + "You can work on this allocation by visiting:" + k.NEW_LINE + k.NEW_LINE + "   http://" + ConfigurationManager.AppSettings["host_domain_name"] + "/" + ConfigurationManager.AppSettings["application_name"] + k.NEW_LINE + k.NEW_LINE + "You can contact the " + Session["county_name"].ToString() + " County EMSOF Coordinator at:" + k.NEW_LINE + k.NEW_LINE + "   " + cc_email_address + "  (mailto:" + cc_email_address + ")" + k.NEW_LINE + k.NEW_LINE + "-- " + ConfigurationManager.AppSettings["application_name"];
            // Send the email message.
            // be_html
            // cc
            // bcc
            // reply_to
            k.SmtpMailSend(ConfigurationManager.AppSettings["sender_email_address"], mysql_get_service_email_address.ExecuteScalar().ToString(), "New " + ConfigurationManager.AppSettings["application_name"] + " allocation for your service", messageText, false, k.EMPTY, k.EMPTY, cc_email_address);
            p.db.Close();
        }

    } // end TWebForm_create_new_service_appropriation

}
