using Class_biz_notifications;
using Class_biz_services;
using Class_biz_strike_team_deployments;
using kix;
using System.Web.UI.WebControls;

namespace UserControl_mobilization_announcement
  {

  public partial class TWebUserControl_mobilization_announcement: ki_web_ui.usercontrol_class
    {

    private struct p_type
      {
      public bool be_loaded;
      public TClass_biz_notifications biz_notifications;
      public TClass_biz_services biz_services;
      public TClass_biz_strike_team_deployments biz_strike_team_deployments;
      public object deployment_summary;
      }

    private p_type p;

    protected void Page_Load(object sender, System.EventArgs e)
      {
      if (!p.be_loaded)
        {
        Literal_deployment_name.Text = p.biz_strike_team_deployments.NameOf(p.deployment_summary);
        p.biz_services.BindStrikeTeamMobilizationAnnouncementListControl
          (
          region_code:p.biz_strike_team_deployments.RegionCodeOf(p.deployment_summary),
          target:CheckBoxList_service_strike_teams
          );
        //
        p.be_loaded = true;
        }
      }

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
//#warning Revise the binder-related instance_id to this control appropriately.
//        if (instance_id == "ASP.protected_overview_aspx.UserControl_member_binder_mobilization_announcement")
//          {
//#warning Revise the ClientID path to this control appropriately.
//          p.be_loaded &= ((Session["UserControl_member_binder_PlaceHolder_content"] as string) == "UserControl_mobilization_announcement");
//          }
////      else if (instance_id == "ASP.~_aspx.UserControl_~_binder_mobilization_announcement")
////        {
////        p.be_loaded &= ((Session["UserControl_~_binder_PlaceHolder_content"] as string) == "UserControl_mobilization_announcement");
////        }
        }
      else
        {
        p.biz_notifications = new TClass_biz_notifications();
        p.biz_services = new TClass_biz_services();
        p.biz_strike_team_deployments = new TClass_biz_strike_team_deployments();
        //
        p.be_loaded = false;
        }
      }

    // / <summary>
    // / Required method for Designer support -- do not modify
    // / the contents of this method with the code editor.
    // / </summary>
    private void InitializeComponent()
      {
      PreRender += TWebUserControl_mobilization_announcement_PreRender;
      }

    private void TWebUserControl_mobilization_announcement_PreRender(object sender, System.EventArgs e)
      {
      SessionSet(InstanceId() + ".p", p);
      }

    public TWebUserControl_mobilization_announcement Fresh()
      {
      Session.Remove(InstanceId() + ".p");
      return this;
      }

    internal void Set(object deployment_summary)
      {
      p.deployment_summary = deployment_summary;
      }

    protected void Button_submit_Click(object sender, System.EventArgs e)
      {
      if (Page.IsValid)
        {
        var num_possible_services = CheckBoxList_service_strike_teams.Items.Count;
        foreach (ListItem item in CheckBoxList_service_strike_teams.Items)        
          {
          if (item.Selected)
            {
            p.biz_strike_team_deployments.AnnounceMobilization
              (
              summary:p.deployment_summary,
              supplemental_message:k.Safe(TextBox_supplemental_message.Text,k.safe_hint_type.MEMO),
              service_id:item.Value
              );
            }
          }
        Alert
          (
          cause:k.alert_cause_type.USER,
          state:k.alert_state_type.NORMAL,
          key:"ancmtsent",
          value:"Announcement sent"
          );
        BackTrack();
        }
      else
        {
        Alert
          (
          cause:k.alert_cause_type.USER,
          state:k.alert_state_type.FAILURE,
          key:"noancmtrecips",
          value:"Announcement *NOT* sent.  No recipients are selected.",
          be_using_scriptmanager:true
          );
        }
      }

    protected void CustomValidator_service_strike_teams_ServerValidate(object source, ServerValidateEventArgs args)
      {
      args.IsValid = (CheckBoxList_service_strike_teams.SelectedValue.Length > 0);
      }

    }

  }
