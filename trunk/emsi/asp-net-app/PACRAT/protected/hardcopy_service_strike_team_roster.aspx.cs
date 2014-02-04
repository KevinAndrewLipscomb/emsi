using Class_biz_services;
using System;
using System.Configuration;

namespace hardcopy_service_strike_team_roster
  {

  public partial class TWebForm_hardcopy_service_strike_team_roster: ki_web_ui.page_class
    {

    private struct p_type
      {
      public TClass_biz_services biz_services;
      public object summary;
      }

    private p_type p;

    // / <summary>
    // / Required method for Designer support -- do not modify
    // / the contents of this method with the code editor.
    // / </summary>
    private void InitializeComponent()
      {
      PreRender += TWebForm_hardcopy_service_strike_team_roster_PreRender;
      }

    protected void Page_Load(object sender, System.EventArgs e)
      {
      if (!IsPostBack)
        {
        Title = ConfigurationManager.AppSettings["application_name"] + " - hardcopy_service_strike_team_roster";
        }
      }

    protected override void OnInit(EventArgs e)
      {
      // Required for Designer support
      InitializeComponent();
      base.OnInit(e);
      switch(NatureOfVisitUnlimited(InstanceId() + ".p"))
        {
        case nature_of_visit_type.VISIT_COLD_CALL:
        case nature_of_visit_type.VISIT_INITIAL:
          p.biz_services = new TClass_biz_services();
          p.summary = p.biz_services.Summary(HashtableOfShieldedRequest()["service_id"].ToString());
          UserControl_static_service_strike_team_roster_control.Set(service_summary:p.summary);
          break;
        case nature_of_visit_type.VISIT_POSTBACK_STANDARD:
          p = (p_type)(Session[InstanceId() + ".p"]);
          break;
        }
      }

    private void TWebForm_hardcopy_service_strike_team_roster_PreRender(object sender, System.EventArgs e)
      {
      SessionSet(InstanceId() + ".p", p);
      }

    }

  }
