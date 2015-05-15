using Class_biz_role_member_map;
using kix;
using System;
using System.Configuration;
using System.IO;
using System.Text;
using System.Web.UI;

namespace report_service_strike_team_officers_in_region
  {

  public partial class TWebForm_report_service_strike_team_officers_in_region: System.Web.UI.Page
    {

    private struct p_type
      {
      public string region_emsrs_code;
      }

    private p_type p;

    // / <summary>
    // / Required method for Designer support -- do not modify
    // / the contents of this method with the code editor.
    // / </summary>
    private void InitializeComponent()
      {
      }

    protected void Page_Load(object sender, System.EventArgs e)
      {
      Title = ConfigurationManager.AppSettings["application_name"] + " - report_service_strike_team_officers_in_region";
      Literal_emsrs_code.Text = p.region_emsrs_code;
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
      p.region_emsrs_code = k.Safe(Request["region_emsrs_code"],k.safe_hint_type.NUM);
      //
      UserControl_service_strike_team_officers_in_region_control.Set(region_emsrs_code:p.region_emsrs_code);
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
        to:new TClass_biz_role_member_map().EmailTargetOfByExplicitRegionCode
          (
          role_name:"Region Strike Team Manager",
          region_code:p.region_emsrs_code
          ),
        subject:"Service Strike Team Officers in Region " + p.region_emsrs_code.ToString(),
        message_string:sb.ToString(),
        be_html:true
        );
      }

    } // end TWebForm_report_service_strike_team_officers_in_region

  }
