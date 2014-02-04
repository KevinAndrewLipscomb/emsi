using Class_biz_regions;
using System;
using System.Configuration;

namespace hardcopy_region_strike_team_key_personnel
  {

  public partial class TWebForm_hardcopy_region_strike_team_key_personnel: ki_web_ui.page_class
    {

    private struct p_type
      {
      public TClass_biz_regions biz_regions;
      public object summary;
      }

    private p_type p;

    // / <summary>
    // / Required method for Designer support -- do not modify
    // / the contents of this method with the code editor.
    // / </summary>
    private void InitializeComponent()
      {
      PreRender += TWebForm_hardcopy_region_strike_team_key_personnel_PreRender;
      }

    protected void Page_Load(object sender, System.EventArgs e)
      {
      if (!IsPostBack)
        {
        Title = ConfigurationManager.AppSettings["application_name"] + " - hardcopy_region_strike_team_key_personnel";
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
          p.biz_regions = new TClass_biz_regions();
          p.summary = p.biz_regions.Summary(HashtableOfShieldedRequest()["region_code"].ToString());
          UserControl_static_region_strike_team_key_personnel_control.Set(region_summary:p.summary);
          break;
        case nature_of_visit_type.VISIT_POSTBACK_STANDARD:
          p = (p_type)(Session[InstanceId() + ".p"]);
          break;
        }
      }

    private void TWebForm_hardcopy_region_strike_team_key_personnel_PreRender(object sender, System.EventArgs e)
      {
      SessionSet(InstanceId() + ".p", p);
      }

    }

  }
