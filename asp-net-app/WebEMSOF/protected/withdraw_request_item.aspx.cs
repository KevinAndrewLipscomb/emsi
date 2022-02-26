using Class_biz_accounts;
using Class_db;
using Class_db_trail;
using kix;
using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.IO;

namespace withdraw_request_item
{
    public partial class TWebForm_withdraw_request_item: ki_web_ui.page_class
    {

    private struct p_type
    {
    public TClass_db db;
    public TClass_db_trail db_trail;
    public decimal saved_emsof_ante;
    public decimal saved_shortage;
    }

    private p_type p; // Private Parcel of Page-Pertinent Process-Persistent Parameters

        // / <summary>
        // / Required method for Designer support -- do not modify
        // / the contents of this method with the code editor.
        // / </summary>
        private void InitializeComponent()
        {
            PreRender += TWebForm_withdraw_request_item_PreRender;
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            Title = Server.HtmlEncode(ConfigurationManager.AppSettings["application_name"]) + " - withdraw_request_item";
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
                p.db = new TClass_db();
                p.db_trail = new TClass_db_trail();
                p.saved_emsof_ante = decimal.Parse(Session["emsof_request_item_emsof_ante"].ToString());
                p.saved_shortage = decimal.Parse(Session["emsof_request_item_additional_service_ante"].ToString());
                Label_priority.Text = Session["emsof_request_item_priority"].ToString();
                Label_description.Text = Session["emsof_request_item_make_model"].ToString() + k.SPACE + Session["emsof_request_item_equipment_category"].ToString();
                Label_emsof_ante.Text = p.saved_emsof_ante.ToString("C");
            }
        }

        protected override void OnInit(EventArgs e)
        {
            // Required for Designer support
            InitializeComponent();
            base.OnInit(e);
        }

        private void TWebForm_withdraw_request_item_PreRender(object sender, System.EventArgs e)
        {
            SessionSet(InstanceId() + ".p", p);
        }

        protected void Button_no_Click(object sender, System.EventArgs e)
        {
            BackTrack(2);
        }

        protected void Button_yes_Click(object sender, System.EventArgs e)
        {
            TClass_biz_accounts biz_accounts;
            string service_email_address;
            p.db.Open();
            using var mysql_command = new MySqlCommand(p.db_trail.Saved("START TRANSACTION;" + "update emsof_request_detail" + " set quantity = 0," + " additional_service_ante = 0," + " emsof_ante = 0," + " status_code = 6" + " where master_id = " + Session["emsof_request_master_id"].ToString() + " and priority = " + Session["emsof_request_item_priority"].ToString() + ";" + "update emsof_request_master" + " set value = value - " + p.saved_emsof_ante.ToString() + " , shortage = shortage - " + p.saved_shortage.ToString() + " where id = " + Session["emsof_request_master_id"].ToString() + ";" + "COMMIT;"), p.db.connection);
            mysql_command.ExecuteNonQuery();
            p.db.Close();
            if (Directory.Exists(Session["emsof_request_item_attachment_folder"].ToString()))
              {
              using var the_file = File.Create(Session["emsof_request_item_attachment_folder"].ToString() + "\\noninteractive_delete_pending.kaf");
              }
            // Send the notification message.
            biz_accounts = new TClass_biz_accounts();
            service_email_address = biz_accounts.EmailAddressByKindId("service", Session["service_user_id"].ToString());
            // be_html
            // cc
            // bcc
            // reply_to
            k.SmtpMailSend(ConfigurationManager.AppSettings["sender_email_address"], biz_accounts.EmailTargetByRegionAndRole(Session["region_code"].ToString(),"emsof-request-withdrawal-stakeholder"), "Withdrawal of EMSOF request item", Session["service_name"].ToString() + " has withdrawn a(n) \"" + Label_description.Text + "\" item from their " + Session["fiscal_year_designator"].ToString() + " EMSOF request.  The associated sponsor county is " + Session["sponsor_county"].ToString() + " and the status of this service\'s EMSOF request is \"" + Session["emsof_request_master_status"].ToString() + "\"." + k.NEW_LINE + k.NEW_LINE + Session["service_name"].ToString() + " is aware that this action effectively surrenders " + Label_emsof_ante.Text + " of EMSOF matching funds for use by others." + k.NEW_LINE + k.NEW_LINE + "You can see the effect of this action by visiting:" + k.NEW_LINE + k.NEW_LINE + "   http://" + ConfigurationManager.AppSettings["host_domain_name"] + "/" + ConfigurationManager.AppSettings["application_name"] + k.NEW_LINE + k.NEW_LINE + "You can contact the " + Session["service_name"].ToString() + " EMSOF Coordinator at:" + k.NEW_LINE + k.NEW_LINE + "   " + service_email_address + "  (mailto:" + service_email_address + ")" + k.NEW_LINE + k.NEW_LINE + "-- " + ConfigurationManager.AppSettings["application_name"], false, k.EMPTY, k.EMPTY, service_email_address);
            BackTrack(2);
        }

    } // end TWebForm_withdraw_request_item

}
