using kix;
using UserControl_about;
using UserControl_coned_sponsors;
using UserControl_practitioner;
using UserControl_ready_rosters;

namespace UserControl_regional_staffer_binder
  {

  public static class UserControl_regional_staffer_binder_Static
    {
    public const int TSSI_READY_ROSTERS = 0;
    public const int TSSI_SPONSORS = 1;
    public const int TSSI_PRACTITIONERS = 2;
    public const int TSSI_ABOUT = 3;
    }

  public partial class TWebUserControl_regional_staffer_binder: ki_web_ui.usercontrol_class
    {

    private struct p_type
      {
      public bool be_loaded;
      public string content_id;
      public uint tab_index;
      }

    private p_type p;

    protected void Page_Load(object sender, System.EventArgs e)
      {
      if (!p.be_loaded)
        {
        TabContainer_control.ActiveTabIndex = (int)(p.tab_index);
        p.be_loaded = true;
        }
      }

    protected override void OnInit(System.EventArgs e)
      {
      // Required for Designer support
      InitializeComponent();
      base.OnInit(e);
      if (Session[InstanceId() + ".p"] != null)
        {
        p = (p_type)(Session[InstanceId() + ".p"]);
        p.be_loaded = IsPostBack;
        //
        // Dynamic controls must be re-added on each postback.
        //
        FillPlaceHolder(be_fresh_control_required:false);
        }
      else
        {
        p.be_loaded = false;
        p.tab_index = UserControl_regional_staffer_binder_Static.TSSI_READY_ROSTERS;
        FillPlaceHolder(be_fresh_control_required:true);
        }
      }

    private void TabContainer_control_ActiveTabChanged(object sender, System.EventArgs e)
      {
      p.tab_index = (uint)(TabContainer_control.ActiveTabIndex);
      PlaceHolder_content.Controls.Clear();
      FillPlaceHolder(be_fresh_control_required:true);
      }

    // / <summary>
    // / Required method for Designer support -- do not modify
    // / the contents of this method with the code editor.
    // / </summary>
    private void InitializeComponent()
      {
      TabContainer_control.ActiveTabChanged += TabContainer_control_ActiveTabChanged;
      PreRender += TWebUserControl_regional_staffer_binder_PreRender;
      }

    private void TWebUserControl_regional_staffer_binder_PreRender(object sender, System.EventArgs e)
      {
      //
      // Indicate to children which content control was active on this pass, so that on subsequent passes a child can detect whether or
      // not it is already loaded in the user's browser.
      //
      SessionSet(PlaceHolder_content.ClientID, p.content_id);
      SessionSet(InstanceId() + ".p", p);
      }

    public TWebUserControl_regional_staffer_binder Fresh()
      {
      Session.Remove(InstanceId() + ".p");
      return this;
      }

    private void FillPlaceHolder
      (
      bool be_fresh_control_required,
      string target
      )
      {
      if (p.tab_index == UserControl_regional_staffer_binder_Static.TSSI_READY_ROSTERS)
        {
        var c = ((TWebUserControl_ready_rosters)(LoadControl("~/usercontrol/app/UserControl_ready_rosters.ascx")));
        p.content_id = AddIdentifiedControlToPlaceHolder(c,"UserControl_ready_rosters",PlaceHolder_content,(be_fresh_control_required ? InstanceId() : k.EMPTY));
        }
      else if (p.tab_index == UserControl_regional_staffer_binder_Static.TSSI_SPONSORS)
        {
        var c = ((TWebUserControl_coned_sponsors)(LoadControl("~/usercontrol/app/UserControl_coned_sponsors.ascx")));
        p.content_id = AddIdentifiedControlToPlaceHolder(c,"UserControl_coned_sponsors",PlaceHolder_content,(be_fresh_control_required ? InstanceId() : k.EMPTY));
        }
      else if (p.tab_index == UserControl_regional_staffer_binder_Static.TSSI_PRACTITIONERS)
        {
        var c = ((TWebUserControl_practitioner)(LoadControl("~/usercontrol/app/UserControl_practitioner.ascx")));
        p.content_id = AddIdentifiedControlToPlaceHolder(c,"UserControl_practitioner",PlaceHolder_content,(be_fresh_control_required ? InstanceId() : k.EMPTY));
        }
      else if (p.tab_index == UserControl_regional_staffer_binder_Static.TSSI_ABOUT)
        {
        var c = ((TWebUserControl_about)(LoadControl("~/usercontrol/app/UserControl_about.ascx")));
        p.content_id = AddIdentifiedControlToPlaceHolder(c,"UserControl_about",PlaceHolder_content,(be_fresh_control_required ? InstanceId() : k.EMPTY));
        }
      }
    private void FillPlaceHolder(bool be_fresh_control_required)
      {
      FillPlaceHolder(be_fresh_control_required,k.EMPTY);
      }

    public void SetTarget(string target)
      {
      if (target != k.EMPTY)
        {
        if (target.ToLower().Contains("/ready-rosters/"))
          {
          p.tab_index = UserControl_regional_staffer_binder_Static.TSSI_READY_ROSTERS;
          }
        else if (target.ToLower().Contains("/sponsors/"))
          {
          p.tab_index = UserControl_regional_staffer_binder_Static.TSSI_SPONSORS;
          }
        else if (target.ToLower().Contains("/practitioner/"))
          {
          p.tab_index = UserControl_regional_staffer_binder_Static.TSSI_PRACTITIONERS;
          }
        else if (target.ToLower().Contains("/about/"))
          {
          p.tab_index = UserControl_regional_staffer_binder_Static.TSSI_ABOUT;
          }
        //
        PlaceHolder_content.Controls.Clear();
        FillPlaceHolder
          (
          be_fresh_control_required:false,
          target:target
          );
        //
        }
      }

    }

  }