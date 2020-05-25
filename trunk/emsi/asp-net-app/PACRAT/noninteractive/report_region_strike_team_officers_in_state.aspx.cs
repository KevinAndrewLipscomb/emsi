using Class_biz_role_member_map;
using kix;
using System;
using System.Configuration;
using System.IO;
using System.Text;
using System.Web.UI;

namespace report_region_strike_team_officers_in_state
  {

  public partial class TWebForm_report_region_strike_team_officers_in_state: ki_web_ui.page_class
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
      Title = ConfigurationManager.AppSettings["application_name"] + " - report_region_strike_team_officers_in_state";
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
      }

    protected override void Render(HtmlTextWriter writer)
      {
      var biz_role_member_map = new TClass_biz_role_member_map();
      //
      // Write the HTML stream into a StringBuilder.
      //
      var sb = new StringBuilder();
      using var html_text_writer = new HtmlTextWriter(new StringWriter(sb));
      base.Render(html_text_writer);
      //
      // Send output stream as an email message.
      //
      var state_strike_team_executive_email_target = biz_role_member_map.EmailTargetForPennsylvania(role_name:"State Strike Team Executive");
      k.SmtpMailSend
        (
        from:ConfigurationManager.AppSettings["sender_email_address"],
        to:state_strike_team_executive_email_target + k.COMMA + biz_role_member_map.EmailTargetForPennsylvania(role_name:"State Strike Team Manager"),
        subject:"Region Strike Team Officers in State",
        message_string:sb.ToString(),
        be_html:true,
        cc:k.EMPTY,
        bcc:k.EMPTY,
        reply_to:state_strike_team_executive_email_target
        );
      }

    } // end TWebForm_report_region_strike_team_officers_in_state

  }
