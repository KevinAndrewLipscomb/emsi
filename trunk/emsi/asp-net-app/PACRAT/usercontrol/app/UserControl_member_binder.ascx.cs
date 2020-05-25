using Class_biz_members;
using Class_biz_privileges;
using Class_biz_strike_team_deployments;
using Class_biz_user;
using kix;
using UserControl_about;
using UserControl_config_binder;
using UserControl_practitioner;
using UserControl_preparation_binder;
using UserControl_strike_team_deployment_catalog;

namespace UserControl_member_binder
  {

  public partial class TWebUserControl_member_binder: ki_web_ui.usercontrol_class
    {

    //--
    //
    // PRIVATE
    //
    //--

    public static class Static
      {
      public const int TSSI_MEMBER_PROFILE = 0;
      public const int TSSI_PREPARATION = 1;
      public const int TSSI_COORDINATION = 2;
      public const int TSSI_CONFIG = 3;
      public const int TSSI_ABOUT = 4;
      }

    private struct p_type
      {
      internal bool be_loaded;
      internal bool be_more_than_examiner;
      internal bool be_ok_to_config_strike_team_state;
      internal bool be_ok_to_config_strike_team_region;
      internal bool be_ok_to_config_strike_team_service;
      internal bool be_ok_to_see_all_strike_team_data;
      internal TClass_biz_members biz_members;
      internal TClass_biz_privileges biz_privileges;
      internal TClass_biz_strike_team_deployments biz_strike_team_deployments;
      internal TClass_biz_user biz_user;
      internal string content_id;
      internal string user_member_id;
      internal uint tab_index;
      }

    private p_type p; // Private Parcel of Page-Pertinent Process-Persistent Parameters

    private void FillPlaceHolder
      (
      #pragma warning disable CA1801 // Remove unused parameter
      bool be_fresh_control_required,
      string target
      #pragma warning restore CA1801 // Remove unused parameter
      )
      {
      if (p.tab_index == Static.TSSI_MEMBER_PROFILE)
        {
        var c = ((TWebUserControl_practitioner)(LoadControl("~/usercontrol/app/UserControl_practitioner.ascx")));
        p.content_id = AddIdentifiedControlToPlaceHolder(c,"UserControl_practitioner",PlaceHolder_content,(be_fresh_control_required ? InstanceId() : k.EMPTY));
        c.SetAfterPageLoad(p.biz_members.IdOfUserId(p.biz_user.IdNum()));
        }
      else if (p.tab_index == Static.TSSI_PREPARATION)
        {
        var c = ((TWebUserControl_preparation_binder)(LoadControl("~/usercontrol/app/UserControl_preparation_binder.ascx")));
        p.content_id = AddIdentifiedControlToPlaceHolder(c,"UserControl_preparation_binder",PlaceHolder_content,(be_fresh_control_required ? InstanceId() : k.EMPTY));
        }
      else if (p.tab_index == Static.TSSI_COORDINATION)
        {
        var c = ((TWebUserControl_strike_team_deployment_catalog)(LoadControl("~/usercontrol/app/UserControl_strike_team_deployment_catalog.ascx")));
        p.content_id = AddIdentifiedControlToPlaceHolder(c,"UserControl_strike_team_deployment_catalog",PlaceHolder_content,(be_fresh_control_required ? InstanceId() : k.EMPTY));
        c.SetP(p.be_more_than_examiner,p.be_ok_to_see_all_strike_team_data);
        }
      else if (p.tab_index == Static.TSSI_CONFIG)
        {
        var c = ((TWebUserControl_config_binder)(LoadControl("~/usercontrol/app/UserControl_config_binder.ascx")));
        p.content_id = AddIdentifiedControlToPlaceHolder(c,"UserControl_config_binder",PlaceHolder_content,(be_fresh_control_required ? InstanceId() : k.EMPTY));
        }
      else if (p.tab_index == Static.TSSI_ABOUT)
        {
        var c = ((TWebUserControl_about)(LoadControl("~/usercontrol/app/UserControl_about.ascx")));
        p.content_id = AddIdentifiedControlToPlaceHolder(c,"UserControl_about",PlaceHolder_content,(be_fresh_control_required ? InstanceId() : k.EMPTY));
        }
      }
    private void FillPlaceHolder(bool be_fresh_control_required)
      {
      FillPlaceHolder(be_fresh_control_required,k.EMPTY);
      }

    // / <summary>
    // / Required method for Designer support -- do not modify
    // / the contents of this method with the code editor.
    // / </summary>
    private void InitializeComponent()
      {
      TabContainer_control.ActiveTabChanged += TabContainer_control_ActiveTabChanged;
      PreRender += TWebUserControl_member_binder_PreRender;
      }

    private void TabContainer_control_ActiveTabChanged(object sender, System.EventArgs e)
      {
      p.tab_index = (uint)(TabContainer_control.ActiveTabIndex);
      PlaceHolder_content.Controls.Clear();
      FillPlaceHolder(be_fresh_control_required:(p.tab_index != Static.TSSI_MEMBER_PROFILE)); // Special case: Never freshen UserControl_practitioner under the MEMBER_PROFILE tab.
      }

    private void TWebUserControl_member_binder_PreRender(object sender, System.EventArgs e)
      {
      //
      // Indicate to children which content control was active on this pass, so that on subsequent passes a child can detect whether or not it is already loaded in the user's browser.
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
      if (Session[InstanceId() + ".p"] != null)
        {
        p = (p_type)(Session[InstanceId() + ".p"]);
        //
        // Dynamic controls must be re-added on each postback.
        //
        FillPlaceHolder(false);
        }
      else
        {
        p.biz_members = new TClass_biz_members();
        p.biz_privileges = new TClass_biz_privileges();
        p.biz_strike_team_deployments = new TClass_biz_strike_team_deployments();
        p.biz_user = new TClass_biz_user();
        //
        p.be_loaded = false;
        p.be_more_than_examiner = false;
        p.user_member_id = p.biz_members.IdOfUserId(p.biz_user.IdNum());
        //
        p.be_ok_to_config_strike_team_state = p.biz_privileges.HasForAnyScope(p.user_member_id,"config-strike-team-state");
        p.be_ok_to_config_strike_team_region = p.biz_privileges.HasForAnyScope(p.user_member_id,"config-strike-team-region");
        p.be_ok_to_config_strike_team_service = p.biz_privileges.HasForAnyScope(p.user_member_id,"config-strike-team-service");
        p.be_ok_to_see_all_strike_team_data = p.biz_privileges.HasForAnyScope(p.user_member_id,"see-all-strike-team-data");
        if (p.be_ok_to_config_strike_team_state || p.be_ok_to_config_strike_team_region || p.be_ok_to_config_strike_team_service || p.be_ok_to_see_all_strike_team_data)
          {
          if (p.biz_strike_team_deployments.BeAllConcludedWithinScope(p.user_member_id))
            {
            p.tab_index = Static.TSSI_PREPARATION;
            }
          else
            {
            p.tab_index = Static.TSSI_COORDINATION;
            }
          }
        else
          {
          p.tab_index = Static.TSSI_MEMBER_PROFILE;
          }
        //
        FillPlaceHolder(true);
        }
      }

    protected void Page_Load(object sender, System.EventArgs e)
      {
      if (!p.be_loaded)
        {
        p.be_loaded = true;
        }
      //
      TabPanel_preparation.Enabled =
        (p.be_ok_to_config_strike_team_state || p.be_ok_to_config_strike_team_region || p.be_ok_to_config_strike_team_service || p.be_ok_to_see_all_strike_team_data);
      //
      p.be_more_than_examiner = p.biz_privileges.HasForAnyScope(p.user_member_id,"see-strike-team-deployments") || p.biz_privileges.HasForAnyScope(p.user_member_id,"config-strike-team-deployments");
      TabPanel_coordination.Enabled = p.be_more_than_examiner || p.be_ok_to_see_all_strike_team_data;
      //
      TabContainer_control.ActiveTabIndex = (int)(p.tab_index);
      }

    //--
    //
    // PUBLIC
    //
    //--

    public TWebUserControl_member_binder Fresh()
      {
      Session.Remove(InstanceId() + ".p");
      return this;
      }

    public void SetTarget(string target)
      {
      if (target.Length > 0)
        {
        if (target.ToLower().Contains("/member_profile/"))
          {
          p.tab_index = Static.TSSI_MEMBER_PROFILE;
          }
        else if (target.ToLower().Contains("/preparation/"))
          {
          p.tab_index = Static.TSSI_PREPARATION;
          }
        else if (target.ToLower().Contains("/coordination/"))
          {
          p.tab_index = Static.TSSI_COORDINATION;
          }
        else if (target.ToLower().Contains("/config/"))
          {
          p.tab_index = Static.TSSI_CONFIG;
          }
        else if (target.ToLower().Contains("/about/"))
          {
          p.tab_index = Static.TSSI_ABOUT;
          }
        //
        TabContainer_control.ActiveTabIndex = (int)p.tab_index;
        PlaceHolder_content.Controls.Clear();
        FillPlaceHolder(false,target);
        //
        }
      }

    }

  }
