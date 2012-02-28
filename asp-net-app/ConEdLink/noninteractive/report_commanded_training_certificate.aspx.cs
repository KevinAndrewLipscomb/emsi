// Derived from template~protected~nonlanding.aspx.cs~template

using kix;
using System;
using System.Configuration;
using System.IO;
using System.Text;
using System.Web.UI;

namespace report_commanded_training_certificate
  {

  public partial class TWebForm_report_commanded_training_certificate: ki_web_ui.page_class
    {

    private struct p_type
      {
      internal string practitioner_email_address;
      internal string reply_to_email_address;
      }

    private p_type p;

    // / <summary>
    // / Required method for Designer support -- do not modify
    // / the contents of this method with the code editor.
    // / </summary>
    private void InitializeComponent()
      {
      PreRender += TWebForm_report_commanded_training_certificate_PreRender;
      }

    private void TWebForm_report_commanded_training_certificate_PreRender(object sender, System.EventArgs e)
      {
      SessionSet(InstanceId() + ".p", p);
      }

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
        {
        p.practitioner_email_address = k.Safe(Request["practitioner_email_address"],k.safe_hint_type.EMAIL_ADDRESS);
        p.reply_to_email_address = k.Safe(Request["reply_to_email_address"],k.safe_hint_type.EMAIL_ADDRESS);
        //
        SessionSet("mode:report",k.EMPTY);
        //
        UserControl_training_certificate_control.Set
          (
          k.Safe(Request["id"],k.safe_hint_type.NUM),
          k.Safe(Request["sponsor_name"],k.safe_hint_type.ORG_NAME),
          k.Safe(Request["sponsor_number"],k.safe_hint_type.NUM),
          k.Safe(Request["first_name"],k.safe_hint_type.HUMAN_NAME),
          k.Safe(Request["middle_initial"],k.safe_hint_type.ALPHA),
          k.Safe(Request["last_name"],k.safe_hint_type.HUMAN_NAME),
          k.Safe(Request["certification_number"],k.safe_hint_type.NUM),
          k.Safe(Request["level_emsrs_code"],k.safe_hint_type.NUM),
          k.Safe(Request["level_short_description"],k.safe_hint_type.HYPHENATED_ALPHA),
          k.Safe(Request["dob"],k.safe_hint_type.DATE_TIME),
          k.Safe(Request["course_number"],k.safe_hint_type.NUM),
          k.Safe(Request["course_title"],k.safe_hint_type.PUNCTUATED),
          k.Safe(Request["total_ceus"],k.safe_hint_type.REAL_NUM),
          k.Safe(Request["med_trauma_ceus"],k.safe_hint_type.REAL_NUM),
          k.Safe(Request["date_final"],k.safe_hint_type.DATE_TIME),
          k.Safe(Request["instructor_hours"],k.safe_hint_type.REAL_NUM)
          );
        }
      else if (nature_of_visit_unlimited == nature_of_visit_type.VISIT_POSTBACK_STANDARD)
        {
        p = (p_type)(Session[InstanceId() + ".p"]);
        }
      }

    protected void Page_Load(object sender, System.EventArgs e)
      {
      if (!IsPostBack)
        {
        Title = Server.HtmlEncode(ConfigurationManager.AppSettings["application_name"]) + " - report_commanded_training_certificate";
        }
      }

    protected override void Render(HtmlTextWriter writer)
      {
      var sb = new StringBuilder();
      base.Render(new HtmlTextWriter(new StringWriter(sb)));
      // //
      // writer.Write(sb.ToString());
      // //
      var body = sb.ToString();
      k.SmtpMailSend
        (
        from:ConfigurationManager.AppSettings["sender_email_address"],
        to:p.practitioner_email_address,
        subject:"Certificate of Training",
        message_string:body,
        be_html:true,
        cc:k.EMPTY,
        bcc:k.EMPTY,
        reply_to:p.reply_to_email_address
        );
      Session.Abandon();
      }

    } // end TWebForm_report_commanded_training_certificate

  }
