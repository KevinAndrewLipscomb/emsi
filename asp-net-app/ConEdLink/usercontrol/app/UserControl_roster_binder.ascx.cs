// Derived from KiAspdotnetFramework/UserControl/app/UserControl~template~binder.cs~template

using kix;
using UserControl_outstanding_rosters;
using UserControl_ready_rosters;
using UserControl_discarded_rosters;

namespace UserControl_roster_binder
  {

  public class UserControl_roster_binder_Static
    {
    public const int TSSI_OUTSTANDING = 0;
    public const int TSSI_READY = 1;
    public const int TSSI_DISCARDED = 2;
    }

  public partial class TWebUserControl_roster_binder: ki_web_ui.usercontrol_class
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

    private p_type p; // Private Parcel of Page-Pertinent Process-Persistent Parameters

    private void FillPlaceHolder
      (
      #pragma warning disable CA1801 // Remove unused parameter
      bool be_fresh_control_required,
      string target
      #pragma warning restore CA1801 // Remove unused parameter
      )
      {
      if (p.tab_index == UserControl_roster_binder_Static.TSSI_OUTSTANDING)
        {
        var c = ((TWebUserControl_outstanding_rosters)(LoadControl("~/usercontrol/app/UserControl_outstanding_rosters.ascx")));
        p.content_id = AddIdentifiedControlToPlaceHolder(c,"UserControl_outstanding_rosters",PlaceHolder_content,(be_fresh_control_required ? InstanceId() : k.EMPTY));
        }
      else if (p.tab_index == UserControl_roster_binder_Static.TSSI_READY)
        {
        var c = ((TWebUserControl_ready_rosters)(LoadControl("~/usercontrol/app/UserControl_ready_rosters.ascx")));
        p.content_id = AddIdentifiedControlToPlaceHolder(c,"UserControl_ready_rosters",PlaceHolder_content,(be_fresh_control_required ? InstanceId() : k.EMPTY));
        }
      else if (p.tab_index == UserControl_roster_binder_Static.TSSI_DISCARDED)
        {
        var c = ((TWebUserControl_discarded_rosters)(LoadControl("~/usercontrol/app/UserControl_discarded_rosters.ascx")));
        p.content_id = AddIdentifiedControlToPlaceHolder(c,"UserControl_discarded_rosters",PlaceHolder_content,(be_fresh_control_required ? InstanceId() : k.EMPTY));
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
      PreRender += TWebUserControl_roster_binder_PreRender;
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

    private void TWebUserControl_roster_binder_PreRender(object sender, System.EventArgs e)
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
        p.be_loaded = IsPostBack && ((Session["UserControl_regional_staffer_binder_PlaceHolder_content"] as string) == "UserControl_roster_binder");
        //
        // Dynamic controls must be re-added on each postback.
        //
        FillPlaceHolder(false);
        }
      else
        {
        p.be_loaded = false;
        //
        p.tab_index = UserControl_roster_binder_Static.TSSI_READY;
        FillPlaceHolder(true);
        }
      }

    //--
    //
    // PUBLIC
    //
    //--

    public TWebUserControl_roster_binder Fresh()
      {
      Session.Remove(InstanceId() + ".p");
      return this;
      }

    public void SetTarget(string target)
      {
      if (target.Length > 0)
        {
        if (target.ToLower().Contains("/outstanding/"))
          {
          p.tab_index = UserControl_roster_binder_Static.TSSI_OUTSTANDING;
          }
        else if (target.ToLower().Contains("/ready/"))
          {
          p.tab_index = UserControl_roster_binder_Static.TSSI_READY;
          }
        else if (target.ToLower().Contains("/discarded/"))
          {
          p.tab_index = UserControl_roster_binder_Static.TSSI_DISCARDED;
          }
        //
        TabContainer_control.ActiveTabIndex = (int)p.tab_index;
        PlaceHolder_content.Controls.Clear();
        FillPlaceHolder(false,target);
        //
        }
      }

    } // end TWebUserControl_roster_binder

  }

