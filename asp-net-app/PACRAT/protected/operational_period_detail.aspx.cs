// Derived from template~protected~nonlanding.aspx.cs~template

using Class_biz_strike_team_deployment_operational_periods;
using Class_msg_protected;
using System;
using System.Configuration;

namespace operational_period_detail
  {
  public partial class TWebForm_operational_period_detail: ki_web_ui.page_class
    {

    private struct p_type
      {
      public TClass_biz_strike_team_deployment_operational_periods biz_strike_team_deployment_operational_periods;
      public TClass_msg_protected.operational_period_detail incoming;
      }

    private p_type p;

    // / <summary>
    // / Required method for Designer support -- do not modify
    // / the contents of this method with the code editor.
    // / </summary>
    private void InitializeComponent()
      {
      //this.Load += this.Page_Load;
      this.PreRender += this.TWebForm_operational_period_detail_PreRender;
      }

    protected void Page_Load(object sender, System.EventArgs e)
      {
      if (!IsPostBack)
        {
        Title = Server.HtmlEncode(ConfigurationManager.AppSettings["application_name"]) + " - operational_period_detail";
        }
      }

    protected override void OnInit(EventArgs e)
      {
      // Required for Designer support
      InitializeComponent();
      base.OnInit(e);
      var nature_of_visit = NatureOfVisit(InstanceId() + ".p");
      if (nature_of_visit == nature_of_visit_type.VISIT_INITIAL)
        {
        //
        // Initialize p.~ objects here.
        //
        p.biz_strike_team_deployment_operational_periods = new TClass_biz_strike_team_deployment_operational_periods();
        //
        p.incoming = Message<TClass_msg_protected.operational_period_detail>
          (
          folder_name:"protected",
          aspx_name:"operational_period_detail"
          );
        //
        UserControl_strike_team_deployment_operational_period_control.Set
          (
          deployment_id:p.incoming.deployment_id,
          operational_period_id:p.incoming.operational_period_id,
          service_strike_team_management_footprint:p.incoming.service_strike_team_management_footprint,
          be_unlimited:p.incoming.be_unlimited,
          be_more_than_examiner:p.incoming.be_more_than_examiner
          );
        }
      else if (nature_of_visit == nature_of_visit_type.VISIT_POSTBACK_STANDARD)
        {
        p = (p_type)(Session[InstanceId() + ".p"]);
        }
      //
      // ScriptManager.GetCurrent(Page).EnablePartialRendering = false;
      //
      }

    private void TWebForm_operational_period_detail_PreRender(object sender, System.EventArgs e)
      {
      SessionSet(InstanceId() + ".p", p);
      }

    } // end TWebForm_operational_period_detail

  }
