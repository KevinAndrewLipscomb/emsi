using Class_biz_accounts;
using kix;
using System;
using System.Configuration;

namespace new_password
  {
  public partial class TWebForm_new_password: ki_web_ui.page_class
    {

        // / <summary>
        // / Required method for Designer support -- do not modify
        // / the contents of this method with the code editor.
        // / </summary>
        private void InitializeComponent()
        {
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            Title = Server.HtmlEncode(ConfigurationManager.AppSettings["application_name"]) + " - new_password";
            if (!IsPostBack)
            {
                if (Request.ServerVariables["URL"] == Request.CurrentExecutionFilePath)
                {
                    Session.Clear();
                    Server.Transfer("~/login.aspx");
                }
                var application_name = ConfigurationManager.AppSettings["application_name"];
                var biz_accounts = new TClass_biz_accounts();
                Label_user_name.Text = Session[Session["target_user_table"].ToString() + "_name"].ToString();
                var email_address = biz_accounts.EmailAddressByKindId(Session["target_user_table"].ToString(), Session[Session["target_user_table"].ToString() + "_user_id"].ToString());
                if (k.EmptyIfInvalidEmailAddress(email_address).Length > 0)
                  {
                  // Build a suitably-random password string.
                  var temporary_password = System.Guid.NewGuid().ToString().Substring(0, 8);
                  // Make the password string the service's new temporary password, and set the stale flag to force an immediate password change.
                  biz_accounts.SetTemporaryPassword(Session["target_user_table"].ToString(), Session[Session["target_user_table"].ToString() + "_user_id"].ToString(), k.Digest(temporary_password));
                  // Send the new password to the service's email address of record.
                  k.SmtpMailSend(ConfigurationManager.AppSettings["sender_email_address"], email_address, ConfigurationManager.AppSettings["application_name"] + " temp password", "Someone at the host known as " + k.Safe(Request.UserHostName, k.safe_hint_type.HOSTNAME) + " (possibly you) requested a new password for the \"" + Session[Session["target_user_table"].ToString() + "_name"].ToString() + "\" " + Session["target_user_table"].ToString() + " account on the " + ConfigurationManager.AppSettings["application_name"] + " system.  Please log into " + ConfigurationManager.AppSettings["application_name"] + " using the following credentials.  " + "You will receive further instructions at that time." + k.NEW_LINE + k.NEW_LINE + "   " + Session["target_user_table"].ToString() + ":" + k.NEW_LINE + "      " + Session[Session["target_user_table"].ToString() + "_name"].ToString() + k.NEW_LINE + "   password:" + k.NEW_LINE + "      " + temporary_password + k.NEW_LINE + k.NEW_LINE + "You can complete this process by visiting:" + k.NEW_LINE + k.NEW_LINE + "   http://" + ConfigurationManager.AppSettings["host_domain_name"] + "/" + Server.UrlEncode(ConfigurationManager.AppSettings["application_name"]) + k.NEW_LINE + k.NEW_LINE + "-- " + ConfigurationManager.AppSettings["application_name"]);
                  // Set Label_email_address.
                  Label_valid_email_address.Text = email_address;
                  Label_application_name_5.Text = application_name;
                  Label_application_name_6.Text = application_name;
                  }
                else
                  {
                  Panel_done.Visible = false;
                  Panel_blocked.Visible = true;
                  Label_application_name.Text = application_name;
                  Label_application_name_2.Text = application_name;
                  Label_application_name_3.Text = application_name;
                  Label_application_name_4.Text = application_name;
                  Label_invalid_email_address.Text = email_address;
                  }
            }
        }

        protected override void OnInit(EventArgs e)
        {
            // Required for Designer support
            InitializeComponent();
            base.OnInit(e);
        }

    } // end TWebForm_new_password

}

