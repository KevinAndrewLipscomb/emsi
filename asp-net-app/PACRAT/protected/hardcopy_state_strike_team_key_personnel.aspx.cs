using System;
using System.Configuration;

namespace hardcopy_state_strike_team_key_personnel
  {

  public partial class TWebForm_hardcopy_state_strike_team_key_personnel: ki_web_ui.page_class
    {

    private struct p_type
      {
      }

    private p_type p; // Private Parcel of Page-Pertinent Process-Persistent Parameters

    // / <summary>
    // / Required method for Designer support -- do not modify
    // / the contents of this method with the code editor.
    // / </summary>
    private void InitializeComponent()
      {
      PreRender += TWebForm_hardcopy_state_strike_team_key_personnel_PreRender;
      }

    protected void Page_Load(object sender, System.EventArgs e)
      {
      Title = Server.HtmlEncode(ConfigurationManager.AppSettings["application_name"]) + " - hardcopy_state_strike_team_key_personnel";
      if (!IsPostBack)
        {
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
          break;
        case nature_of_visit_type.VISIT_POSTBACK_STANDARD:
          p = (p_type)(Session[InstanceId() + ".p"]);
          break;
        }
      }

    private void TWebForm_hardcopy_state_strike_team_key_personnel_PreRender(object sender, System.EventArgs e)
      {
      SessionSet(InstanceId() + ".p", p);
      }

    }

  }
