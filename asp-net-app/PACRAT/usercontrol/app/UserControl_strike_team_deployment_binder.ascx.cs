// Derived from KiAspdotnetFramework/UserControl/app/UserControl~template~binder.cs~template

using kix;
using UserControl_strike_team_deployment_members;
using UserControl_strike_team_deployment_operational_periods;
using UserControl_strike_team_deployment_vehicles;

namespace UserControl_strike_team_deployment_binder
  {

  public class UserControl_strike_team_deployment_binder_Static
    {
    public const int TSSI_PERSONNEL = 0;
    public const int TSSI_VEHICLES = 1;
    public const int TSSI_OPERATIONAL_PERIODS = 2;
    }

  public partial class TWebUserControl_strike_team_deployment_binder: ki_web_ui.usercontrol_class
    {

    //--
    //
    // PRIVATE
    //
    //--

    private struct p_type
      {
      internal bool be_loaded;
      internal string content_id;
      internal string deployment_id;
      internal uint tab_index;
      }

    private p_type p;

    private void FillPlaceHolder
      (
      bool be_fresh_control_required,
      string target
      )
      {
      if (p.tab_index == UserControl_strike_team_deployment_binder_Static.TSSI_PERSONNEL)
        {
        var c = ((TWebUserControl_strike_team_deployment_members)(LoadControl("~/usercontrol/app/UserControl_strike_team_deployment_members.ascx")));
        p.content_id = AddIdentifiedControlToPlaceHolder(c,"UserControl_strike_team_deployment_members",PlaceHolder_content,(be_fresh_control_required ? InstanceId() : k.EMPTY));
        c.Set(p.deployment_id);
        }
      else if (p.tab_index == UserControl_strike_team_deployment_binder_Static.TSSI_VEHICLES)
        {
        var c = ((TWebUserControl_strike_team_deployment_vehicles)(LoadControl("~/usercontrol/app/UserControl_strike_team_deployment_vehicles.ascx")));
        p.content_id = AddIdentifiedControlToPlaceHolder(c,"UserControl_strike_team_deployment_vehicles",PlaceHolder_content,(be_fresh_control_required ? InstanceId() : k.EMPTY));
        //c.SetTarget(target);
        }
      else if (p.tab_index == UserControl_strike_team_deployment_binder_Static.TSSI_OPERATIONAL_PERIODS)
        {
        var c = ((TWebUserControl_strike_team_deployment_operational_periods)(LoadControl("~/usercontrol/app/UserControl_strike_team_deployment_operational_periods.ascx")));
        p.content_id = AddIdentifiedControlToPlaceHolder(c,"UserControl_strike_team_deployment_operational_periods",PlaceHolder_content,(be_fresh_control_required ? InstanceId() : k.EMPTY));
        //c.SetTarget(target);
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
      if (Session[InstanceId() + ".p"] != null)
        {
        p = (p_type)(Session[InstanceId() + ".p"]);
        p.be_loaded = IsPostBack && ((Session["UserControl_strike_team_deployment_PlaceHolder_content"] as string) == "UserControl_strike_team_deployment_binder");
        //
        // Dynamic controls must be re-added on each postback.
        //
        FillPlaceHolder(false);
        }
      else
        {
        p.be_loaded = false;
        //
        p.deployment_id = k.EMPTY;
        p.tab_index = UserControl_strike_team_deployment_binder_Static.TSSI_PERSONNEL;
        FillPlaceHolder(true);
        }
      }

    //--
    //
    // INTERNAL
    //
    //--

    internal void Set(string deployment_id)
      {
      p.deployment_id = deployment_id;
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
      if (target != k.EMPTY)
        {
        if (target.ToLower().Contains("/personnel/"))
          {
          p.tab_index = UserControl_strike_team_deployment_binder_Static.TSSI_PERSONNEL;
          }
        else if (target.ToLower().Contains("/vehicles/"))
          {
          p.tab_index = UserControl_strike_team_deployment_binder_Static.TSSI_VEHICLES;
          }
        else if (target.ToLower().Contains("/operational-periods/"))
          {
          p.tab_index = UserControl_strike_team_deployment_binder_Static.TSSI_OPERATIONAL_PERIODS;
          }
        //
        PlaceHolder_content.Controls.Clear();
        FillPlaceHolder(false,target);
        //
        }
      }

    } // end TWebUserControl_strike_team_deployment_binder

  }

