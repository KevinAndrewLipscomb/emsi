using kix;
using System;
using System.Configuration;
using System.IO;
using System.Text;
using System.Web.UI;

namespace report_commanded_training_certificate_legacy
  {
  // Derived from KiAspdotnetFramework/protected/template~protected~nonlanding.pas~template
  public partial class TWebForm_report_commanded_training_certificate_legacy: ki_web_ui.page_class
    {

    //==
    //
    // PROTECTED
    //
    //==

    protected override void OnInit(EventArgs e)
      {
      // Required for Designer support
      InitializeComponent();
      base.OnInit(e);
      var nature_of_visit_unlimited = NatureOfVisitUnlimited(InstanceId() + ".p");
      if(
          (nature_of_visit_unlimited == nature_of_visit_type.VISIT_COLD_CALL)
        ||
          (nature_of_visit_unlimited == nature_of_visit_type.VISIT_INITIAL)
        )
      //then
        {
        UserControl_training_certificate_legacy_control.Set(hash_table:HashtableOfShieldedRequest());
        }
      else if (nature_of_visit_unlimited == nature_of_visit_type.VISIT_POSTBACK_STANDARD)
        {
        p = (p_type)(Session[InstanceId() + ".p"]);
        }
      }

    protected void Page_Load(object sender, System.EventArgs e)
      {
      Title = Server.HtmlEncode(ConfigurationManager.AppSettings["application_name"]) + " - report_commanded_training_certificate_legacy";
      if (!IsPostBack)
        {
        }
      }

    protected override void Render(HtmlTextWriter writer)
      {
      var sb = new StringBuilder();
      using var html_text_writer = new HtmlTextWriter(new StringWriter(sb));
      base.Render(html_text_writer);
      // //
      // writer.Write(sb.ToString());
      // //
      var body = sb.ToString();
      var sender_email_address = k.Safe(Request["sender_email_address"],k.safe_hint_type.EMAIL_ADDRESS);
      k.SmtpMailSend
        (
        from:ConfigurationManager.AppSettings["sender_email_address"],
        to:k.Safe(Request["practitioner_email_address"],k.safe_hint_type.EMAIL_ADDRESS),
        subject:"Certificate of Training",
        message_string:body,
        be_html:true,
        cc:sender_email_address,
        bcc:k.EMPTY,
        reply_to:sender_email_address
        );
      Session.Abandon();
      }

    //==
    //
    // PRIVATE
    //
    //==

    private struct p_type
      {
      }

    private p_type p; // Private Parcel of Page-Pertinent Process-Persistent Parameters

    private void InitializeComponent()
      {
      PreRender += TWebForm_report_commanded_training_certificate_legacy_PreRender;
      }

    private void TWebForm_report_commanded_training_certificate_legacy_PreRender(object sender, System.EventArgs e)
      {
      SessionSet(InstanceId() + ".p", p);
      }

    } // end TWebForm_report_commanded_training_certificate_legacy

  }
