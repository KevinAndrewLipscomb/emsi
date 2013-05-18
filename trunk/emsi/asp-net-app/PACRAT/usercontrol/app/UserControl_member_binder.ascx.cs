using Class_biz_members;
using Class_biz_user;
using kix;
using UserControl_about;
using UserControl_config_binder;
using UserControl_practitioner;
using UserControl_preparation_binder;

namespace UserControl_member_binder
  {

  public class UserControl_member_binder_Static
    {
    public const int TSSI_MEMBER_PROFILE = 0;
    public const int TSSI_PREPARATION = 1;
    public const int TSSI_CONFIG = 2;
    public const int TSSI_ABOUT = 3;
    }

  public partial class TWebUserControl_member_binder: ki_web_ui.usercontrol_class
    {

    //--
    //
    // PRIVATE
    //
    //--

    private struct p_type
      {
      internal bool be_loaded;
      internal TClass_biz_members biz_members;
      internal TClass_biz_user biz_user;
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
      if (p.tab_index == UserControl_member_binder_Static.TSSI_MEMBER_PROFILE)
        {
        var c = ((TWebUserControl_practitioner)(LoadControl("~/usercontrol/app/UserControl_practitioner.ascx")));
        p.content_id = AddIdentifiedControlToPlaceHolder(c,"UserControl_practitioner",PlaceHolder_content,(be_fresh_control_required ? InstanceId() : k.EMPTY));
        c.SetTarget(p.biz_members.IdOfUserId(p.biz_user.IdNum()));
        }
      else if (p.tab_index == UserControl_member_binder_Static.TSSI_PREPARATION)
        {
        var c = ((TWebUserControl_preparation_binder)(LoadControl("~/usercontrol/app/UserControl_preparation_binder.ascx")));
        p.content_id = AddIdentifiedControlToPlaceHolder(c,"UserControl_preparation_binder",PlaceHolder_content,(be_fresh_control_required ? InstanceId() : k.EMPTY));
        }
      else if (p.tab_index == UserControl_member_binder_Static.TSSI_CONFIG)
        {
        var c = ((TWebUserControl_config_binder)(LoadControl("~/usercontrol/app/UserControl_config_binder.ascx")));
        p.content_id = AddIdentifiedControlToPlaceHolder(c,"UserControl_config_binder",PlaceHolder_content,(be_fresh_control_required ? InstanceId() : k.EMPTY));
        }
      else if (p.tab_index == UserControl_member_binder_Static.TSSI_ABOUT)
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
      FillPlaceHolder(be_fresh_control_required:(p.tab_index != UserControl_member_binder_Static.TSSI_MEMBER_PROFILE)); // Special case: Never freshen UserControl_practitioner under the MEMBER_PROFILE tab.
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
      if (IsPostBack && (Session[InstanceId() + ".p"] != null))
        {
        p = (p_type)(Session[InstanceId() + ".p"]);
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
        p.biz_user = new TClass_biz_user();
        //
        p.tab_index = UserControl_member_binder_Static.TSSI_MEMBER_PROFILE;
        FillPlaceHolder(true);
        }
      }

    protected void Page_Load(object sender, System.EventArgs e)
      {
      if (!p.be_loaded)
        {
        TabPanel_preparation.Enabled =
          (
            k.Has((string[])(Session["privilege_array"]),"config-roles-and-matrices")
          ||
            k.Has((string[])(Session["privilege_array"]),"config-strike-team-region")
          ||
            k.Has((string[])(Session["privilege_array"]),"config-strike-team-service")
          );
        TabPanel_config.Enabled = (k.Has((string[])(Session["privilege_array"]),"config-users") || k.Has((string[])(Session["privilege_array"]),"config-roles-and-matrices"));
        p.be_loaded = true;
        }
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
      if (target != k.EMPTY)
        {
        if (target.ToLower().Contains("/member_profile/"))
          {
          p.tab_index = UserControl_member_binder_Static.TSSI_MEMBER_PROFILE;
          }
        else if (target.ToLower().Contains("/preparation/"))
          {
          p.tab_index = UserControl_member_binder_Static.TSSI_PREPARATION;
          }
        else if (target.ToLower().Contains("/config/"))
          {
          p.tab_index = UserControl_member_binder_Static.TSSI_CONFIG;
          }
        else if (target.ToLower().Contains("/about/"))
          {
          p.tab_index = UserControl_member_binder_Static.TSSI_ABOUT;
          }
        //
        PlaceHolder_content.Controls.Clear();
        FillPlaceHolder(false,target);
        //
        }
      }

    }

  }
