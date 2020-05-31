// Derived from KiAspdotnetFramework/UserControl/app/UserControl~template~binder.cs~template

using Class_biz_members;
using Class_biz_services;
using Class_biz_user;
using kix;
using UserControl_strike_team_deployment_log;
using UserControl_strike_team_deployment_members;
using UserControl_strike_team_deployment_operational_periods;
using UserControl_strike_team_deployment_agreements;
using UserControl_strike_team_deployment_snapshot;
using UserControl_strike_team_deployment_vehicles;

namespace UserControl_strike_team_deployment_binder
  {

  public partial class TWebUserControl_strike_team_deployment_binder: ki_web_ui.usercontrol_class
    {

    //--
    //
    // PRIVATE
    //
    //--

    private static class Static
      {
      public const int TSSI_PERSONNEL = 0;
      public const int TSSI_VEHICLES = 1;
      public const int TSSI_OPERATIONAL_PERIODS = 2;
      public const int TSSI_AD_HOC_AGREEMENTS = 3;
      public const int TSSI_LOG = 4;
      public const int TSSI_SNAPSHOT = 5;
      }

    private struct p_type
      {
      internal bool be_loaded;
      internal bool be_more_than_examiner;
      internal bool be_ok_to_config_strike_team_deployments;
      internal TClass_biz_members biz_members;
      internal TClass_biz_services biz_services;
      internal TClass_biz_user biz_user;
      internal string content_id;
      internal string deployment_id;
      internal string service_strike_team_management_footprint;
      internal uint tab_index;
      }

    private p_type p; // Private Parcel of Page-Pertinent Process-Persistent Parameters

    private void FillPlaceHolder
      (
      #pragma warning disable CA1801 // Remove unused parameter
      bool be_fresh_control_required,
      string target = k.EMPTY
      #pragma warning restore CA1801 // Remove unused parameter
      )
      {
      if (p.tab_index == Static.TSSI_PERSONNEL)
        {
        var c = ((TWebUserControl_strike_team_deployment_members)(LoadControl("~/usercontrol/app/UserControl_strike_team_deployment_members.ascx")));
        p.content_id = AddIdentifiedControlToPlaceHolder(c,"UserControl_strike_team_deployment_members",PlaceHolder_content,(be_fresh_control_required ? InstanceId() : k.EMPTY));
        c.Set(p.deployment_id,p.service_strike_team_management_footprint,p.be_ok_to_config_strike_team_deployments,p.be_more_than_examiner);
        }
      else if (p.tab_index == Static.TSSI_VEHICLES)
        {
        var c = ((TWebUserControl_strike_team_deployment_vehicles)(LoadControl("~/usercontrol/app/UserControl_strike_team_deployment_vehicles.ascx")));
        p.content_id = AddIdentifiedControlToPlaceHolder(c,"UserControl_strike_team_deployment_vehicles",PlaceHolder_content,(be_fresh_control_required ? InstanceId() : k.EMPTY));
        c.Set(p.deployment_id,p.service_strike_team_management_footprint,p.be_ok_to_config_strike_team_deployments,p.be_more_than_examiner);
        }
      else if (p.tab_index == Static.TSSI_OPERATIONAL_PERIODS)
        {
        var c = ((TWebUserControl_strike_team_deployment_operational_periods)(LoadControl("~/usercontrol/app/UserControl_strike_team_deployment_operational_periods.ascx")));
        p.content_id = AddIdentifiedControlToPlaceHolder(c,"UserControl_strike_team_deployment_operational_periods",PlaceHolder_content,(be_fresh_control_required ? InstanceId() : k.EMPTY));
        c.Set(p.deployment_id,p.service_strike_team_management_footprint,p.be_ok_to_config_strike_team_deployments,p.be_more_than_examiner);
        }
      else if (p.tab_index == Static.TSSI_AD_HOC_AGREEMENTS)
        {
        var c = ((TWebUserControl_strike_team_deployment_agreements)(LoadControl("~/usercontrol/app/UserControl_strike_team_deployment_agreements.ascx")));
        p.content_id = AddIdentifiedControlToPlaceHolder(c,"UserControl_strike_team_deployment_agreements",PlaceHolder_content,(be_fresh_control_required ? InstanceId() : k.EMPTY));
        c.Set
          (
          deployment_id:p.deployment_id,
          service_strike_team_management_footprint:p.service_strike_team_management_footprint,
          be_more_than_examiner:p.be_more_than_examiner
          );
        }
      else if (p.tab_index == Static.TSSI_LOG)
        {
        var c = ((TWebUserControl_strike_team_deployment_log)(LoadControl("~/usercontrol/app/UserControl_strike_team_deployment_log.ascx")));
        p.content_id = AddIdentifiedControlToPlaceHolder(c,"UserControl_strike_team_deployment_log",PlaceHolder_content,(be_fresh_control_required ? InstanceId() : k.EMPTY));
        c.Set(p.deployment_id,p.service_strike_team_management_footprint);
        }
      else if (p.tab_index == Static.TSSI_SNAPSHOT)
        {
        var c = ((TWebUserControl_strike_team_deployment_snapshot)(LoadControl("~/usercontrol/app/UserControl_strike_team_deployment_snapshot.ascx")));
        p.content_id = AddIdentifiedControlToPlaceHolder(c,"UserControl_strike_team_deployment_snapshot",PlaceHolder_content,(be_fresh_control_required ? InstanceId() : k.EMPTY));
        c.Set(p.deployment_id,p.service_strike_team_management_footprint);
        }
      }

    // / <summary>
    // / Required method for Designer support -- do not modify
    // / the contents of this method with the code editor.
    // / </summary>
    private void InitializeComponent()
      {
      TabContainer_control.ActiveTabChanged += TabContainer_control_ActiveTabChanged;
      PreRender += TWebUserControl_strike_team_deployment_binder_PreRender;
      }

    private void Page_Load(object sender, System.EventArgs e)
      {
      if (!p.be_loaded)
        {
        TabContainer_control.ActiveTabIndex = (int)(p.tab_index);
        p.be_loaded = true;
        }
      }

    private void TabContainer_control_ActiveTabChanged(object sender, System.EventArgs e)
      {
      p.tab_index = (uint)(TabContainer_control.ActiveTabIndex);
      PlaceHolder_content.Controls.Clear();
      FillPlaceHolder(true);
      }

    private void TWebUserControl_strike_team_deployment_binder_PreRender(object sender, System.EventArgs e)
      {
      //
      // Indicate to children which content control was active on this pass, so that on subsequent passes a child can detect whether or
      // not it is already loaded in the user's browser.
      //
      SessionSet(PlaceHolder_content.ClientID, p.content_id);
      SessionSet(InstanceId() + ".p", p);
      }

    //--
    //
    // PROTECTED
    //
    //--

    protected override void OnInit(System.EventArgs e)
      {
      // Required for Designer support
      InitializeComponent();
      base.OnInit(e);
      var instance_id = InstanceId();
      if (Session[instance_id + ".p"] != null)
        {
        p = (p_type)(Session[instance_id + ".p"]);
        p.be_loaded = IsPostBack;  // This test is sufficient if this control is being used statically on its page.
        //
        // If this control is being used dynamically under one or more parent binder(s), it must ascertain which instance it is, and whether or not that instance's parent binder
        // had it loaded already.
        //
        //if (instance_id == "ASP.protected_strike_team_deployment_detail_aspx.UserControl_strike_team_deployment_control_strike_team_deployment_binder_control")
        //  {
        //  p.be_loaded &= ((Session["~_PlaceHolder_content"] as string) == "UserControl_strike_team_deployment_binder");
        //  }
        //
        // Dynamic controls must be re-added on each postback.
        //
        FillPlaceHolder(false);
        }
      else
        {
        p.be_loaded = false;
        //
        p.biz_members = new TClass_biz_members();
        p.biz_services = new TClass_biz_services();
        p.biz_user = new TClass_biz_user();
        //
        p.be_more_than_examiner = false;
        p.deployment_id = k.EMPTY;
        p.service_strike_team_management_footprint = k.EMPTY;
        p.tab_index = Static.TSSI_PERSONNEL;
        //Don't FillPlaceHolder(true); since it will be done via Set when target information is known.
        }
      }

    //--
    //
    // INTERNAL
    //
    //--

    internal void Set
      (
      string deployment_id,
      bool be_ok_to_config_strike_team_deployments,
      bool be_more_than_examiner,
      bool be_ok_to_see_all_strike_team_data
      )
      {
      p.deployment_id = deployment_id;
      p.be_ok_to_config_strike_team_deployments = be_ok_to_config_strike_team_deployments;
      p.be_more_than_examiner = be_more_than_examiner;
      //
      //TabPanel_ad_hoc_agreements.Visible = p.be_ok_to_config_strike_team_deployments || be_ok_to_see_all_strike_team_data;
      TabPanel_log.Visible = p.be_ok_to_config_strike_team_deployments || be_ok_to_see_all_strike_team_data;
      TabPanel_snapshot.Visible = p.be_ok_to_config_strike_team_deployments || be_ok_to_see_all_strike_team_data;
      //
      p.service_strike_team_management_footprint = (be_ok_to_config_strike_team_deployments ? k.EMPTY : p.biz_services.ServiceStrikeTeamManagementFootprintOf(p.biz_members.IdOfUserId(p.biz_user.IdNum())));
      //
      SetTarget(target:"//"); // Kludge to do everything SetTarget does except alter p.tab_index.
      }

    //--
    //
    // PUBLIC
    //
    //--

    public TWebUserControl_strike_team_deployment_binder Fresh()
      {
      Session.Remove(InstanceId() + ".p");
      return this;
      }

    public void SetTarget(string target)
      {
      if (target.Length > 0)
        {
        if (target.ToLower().Contains("/personnel/"))
          {
          p.tab_index = Static.TSSI_PERSONNEL;
          }
        else if (target.ToLower().Contains("/vehicles/"))
          {
          p.tab_index = Static.TSSI_VEHICLES;
          }
        else if (target.ToLower().Contains("/operational-periods/"))
          {
          p.tab_index = Static.TSSI_OPERATIONAL_PERIODS;
          }
        else if (target.ToLower().Contains("/ad-hoc-agreements/"))
          {
          p.tab_index = Static.TSSI_AD_HOC_AGREEMENTS;
          }
        else if (target.ToLower().Contains("/log/"))
          {
          p.tab_index = Static.TSSI_LOG;
          }
        else if (target.ToLower().Contains("/snapshot/"))
          {
          p.tab_index = Static.TSSI_SNAPSHOT;
          }
        //
        TabContainer_control.ActiveTabIndex = (int)p.tab_index;
        PlaceHolder_content.Controls.Clear();
        FillPlaceHolder(false,target);
        //
        }
      }

    } // end TWebUserControl_strike_team_deployment_binder

  }
