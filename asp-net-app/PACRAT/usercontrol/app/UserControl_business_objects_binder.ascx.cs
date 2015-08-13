// Derived from KiAspdotnetFramework/UserControl/app/UserControl~template~binder.cs~template

using kix;
using UserControl_fuel;
using UserControl_patient_care_level;
using UserControl_sms_gateway;
using UserControl_strike_team_participation_level;
using UserControl_tow_capacity;
using UserControl_vehicle_kind;

namespace UserControl_business_objects_binder
  {

  public class UserControl_business_objects_binder_Static
    {
    public const int TSSI_VEHICLE_KINDS = 0;
    public const int TSSI_TOW_CAPACITIES = 1;
    public const int TSSI_FUELS = 2;
    public const int TSSI_PATIENT_CARE_LEVELS = 3;
    public const int TSSI_SMS_GATEWAYS = 4;
    public const int TSSI_ST_PARTICIPATION_LEVELS = 5;
    }

  public partial class TWebUserControl_business_objects_binder: ki_web_ui.usercontrol_class
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
      internal uint tab_index;
      }

    private p_type p;

    private void FillPlaceHolder
      (
      bool be_fresh_control_required,
      string target
      )
      {
      if (p.tab_index == UserControl_business_objects_binder_Static.TSSI_VEHICLE_KINDS)
        {
        var c = ((TWebUserControl_vehicle_kind)(LoadControl("~/usercontrol/app/UserControl_vehicle_kind.ascx")));
        p.content_id = AddIdentifiedControlToPlaceHolder(c,"UserControl_vehicle_kind",PlaceHolder_content,(be_fresh_control_required ? InstanceId() : k.EMPTY));
        //c.SetTarget(target);
        }
      else if (p.tab_index == UserControl_business_objects_binder_Static.TSSI_TOW_CAPACITIES)
        {
        var c = ((TWebUserControl_tow_capacity)(LoadControl("~/usercontrol/app/UserControl_tow_capacity.ascx")));
        p.content_id = AddIdentifiedControlToPlaceHolder(c,"UserControl_tow_capacity",PlaceHolder_content,(be_fresh_control_required ? InstanceId() : k.EMPTY));
        //c.SetTarget(target);
        }
      else if (p.tab_index == UserControl_business_objects_binder_Static.TSSI_FUELS)
        {
        var c = ((TWebUserControl_fuel)(LoadControl("~/usercontrol/app/UserControl_fuel.ascx")));
        p.content_id = AddIdentifiedControlToPlaceHolder(c,"UserControl_fuel",PlaceHolder_content,(be_fresh_control_required ? InstanceId() : k.EMPTY));
        //c.SetTarget(target);
        }
      else if (p.tab_index == UserControl_business_objects_binder_Static.TSSI_PATIENT_CARE_LEVELS)
        {
        var c = ((TWebUserControl_patient_care_level)(LoadControl("~/usercontrol/app/UserControl_patient_care_level.ascx")));
        p.content_id = AddIdentifiedControlToPlaceHolder(c,"UserControl_patient_care_level",PlaceHolder_content,(be_fresh_control_required ? InstanceId() : k.EMPTY));
        //c.SetTarget(target);
        }
      else if (p.tab_index == UserControl_business_objects_binder_Static.TSSI_SMS_GATEWAYS)
        {
        var c = ((TWebUserControl_sms_gateway)(LoadControl("~/usercontrol/app/UserControl_sms_gateway.ascx")));
        p.content_id = AddIdentifiedControlToPlaceHolder(c,"UserControl_sms_gateway",PlaceHolder_content,(be_fresh_control_required ? InstanceId() : k.EMPTY));
        //c.SetTarget(target);
        }
      else if (p.tab_index == UserControl_business_objects_binder_Static.TSSI_ST_PARTICIPATION_LEVELS)
        {
        var c = ((TWebUserControl_strike_team_participation_level)(LoadControl("~/usercontrol/app/UserControl_strike_team_participation_level.ascx")));
        p.content_id = AddIdentifiedControlToPlaceHolder(c,"UserControl_strike_team_participation_level",PlaceHolder_content,(be_fresh_control_required ? InstanceId() : k.EMPTY));
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
      PreRender += TWebUserControl_business_objects_binder_PreRender;
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

    private void TWebUserControl_business_objects_binder_PreRender(object sender, System.EventArgs e)
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
        if (instance_id == "ASP.protected_overview_aspx.UserControl_member_binder_config_binder_business_objects_binder")
          {
          p.be_loaded &= ((Session["UserControl_member_binder_UserControl_config_binder_PlaceHolder_content"] as string) == "UserControl_business_objects_binder");
          }
        //
        // Dynamic controls must be re-added on each postback.
        //
        FillPlaceHolder(false);
        }
      else
        {
        p.be_loaded = false;
        //
        p.tab_index = UserControl_business_objects_binder_Static.TSSI_VEHICLE_KINDS;
        FillPlaceHolder(true);
        }
      }

    //--
    //
    // PUBLIC
    //
    //--

    public TWebUserControl_business_objects_binder Fresh()
      {
      Session.Remove(InstanceId() + ".p");
      return this;
      }

    public void SetTarget(string target)
      {
      if (target != k.EMPTY)
        {
        if (target.ToLower().Contains("/vehicle-kinds/"))
          {
          p.tab_index = UserControl_business_objects_binder_Static.TSSI_VEHICLE_KINDS;
          }
        else if (target.ToLower().Contains("/tow-capacities/"))
          {
          p.tab_index = UserControl_business_objects_binder_Static.TSSI_TOW_CAPACITIES;
          }
        else if (target.ToLower().Contains("/fuels/"))
          {
          p.tab_index = UserControl_business_objects_binder_Static.TSSI_FUELS;
          }
        else if (target.ToLower().Contains("/patient-care-levels/"))
          {
          p.tab_index = UserControl_business_objects_binder_Static.TSSI_PATIENT_CARE_LEVELS;
          }
        else if (target.ToLower().Contains("/sms-gateways/"))
          {
          p.tab_index = UserControl_business_objects_binder_Static.TSSI_SMS_GATEWAYS;
          }
        else if (target.ToLower().Contains("/st-participation-levels/"))
          {
          p.tab_index = UserControl_business_objects_binder_Static.TSSI_ST_PARTICIPATION_LEVELS;
          }
        //
        TabContainer_control.ActiveTabIndex = (int)p.tab_index;
        PlaceHolder_content.Controls.Clear();
        FillPlaceHolder(false,target);
        //
        }
      }

    } // end TWebUserControl_business_objects_binder

  }
