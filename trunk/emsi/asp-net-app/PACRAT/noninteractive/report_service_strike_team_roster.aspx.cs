using Class_biz_role_member_map;
using Class_biz_services;
using kix;
using System;
using System.Configuration;
using System.IO;
using System.Text;
using System.Web.UI;

namespace report_service_strike_team_roster
  {

  public partial class TWebForm_report_service_strike_team_roster: Page
    {

    private struct p_type
      {
      public TClass_biz_role_member_map biz_role_member_map;
      public TClass_biz_services biz_services;
      public string service_id;
      }

    private p_type p;

    // / <summary>
    // / Required method for Designer support -- do not modify
    // / the contents of this method with the code editor.
    // / </summary>
    private void InitializeComponent()
      {
      }

    protected void Page_Load(object sender, EventArgs e)
      {
      Title = ConfigurationManager.AppSettings["application_name"] + " - report_service_strike_team_roster";
      Label_application_name_1.Text = ConfigurationManager.AppSettings["application_name"];
      Label_application_name_2.Text = Label_application_name_1.Text;
      Image_uncredentialed.ImageUrl = k.ExpandAsperand(Image_uncredentialed.ImageUrl);
      var url = "http://" + ConfigurationManager.AppSettings["host_domain_name"] + "/" + ConfigurationManager.AppSettings["application_name"];
      HyperLink_web_site.Text = url;
      HyperLink_web_site.NavigateUrl = url;
      }

    protected override void OnInit(EventArgs e)
      {
      // Required for Designer support
      InitializeComponent();
      base.OnInit(e);
      //
      p.biz_role_member_map = new TClass_biz_role_member_map();
      p.biz_services = new TClass_biz_services();
      //
      p.service_id = k.Safe(Request["service_id"],k.safe_hint_type.NUM);
      //
      UserControl_static_service_strike_team_roster_control.Set
        (
        service_summary:p.biz_services.Summary(p.service_id),
        be_for_email_transmission:true
        );
      }

    protected override void Render(HtmlTextWriter writer)
      {
      //
      // Write the HTML stream into a StringBuilder.
      //
      var sb = new StringBuilder();
      base.Render(new HtmlTextWriter(new StringWriter(sb)));
      //
      // Send output stream as an email message.
      //
      k.SmtpMailSend
        (
        from:ConfigurationManager.AppSettings["sender_email_address"],
        to:p.biz_role_member_map.EmailTargetOfByExplicitServiceId
          (
          role_name:"Service Strike Team Manager",
          service_id:p.service_id
          ),
        subject:"Service Strike Team Roster",
        message_string:sb.ToString(),
        be_html:true,
        cc:k.EMPTY,
        bcc:k.EMPTY,
        reply_to:k.EMPTY
        + p.biz_role_member_map.EmailTargetOfByExplicitRegionCode("Region Strike Team Manager",p.biz_services.RegionCodeOf(p.service_id))
        + k.COMMA
        + p.biz_role_member_map.EmailTargetForPennsylvania("State Strike Team Manager")
        );
      }

    } // end TWebForm_report_service_strike_team_roster

  }
