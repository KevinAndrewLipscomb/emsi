// Derived from KiAspdotnetFramework/UserControl/app/UserControl~template~binder.cs~template

using kix;
using UserControl_analysis_intro;
using UserControl_analysis_of_region_by_year;
using UserControl_analysis_of_region_by_month;
using UserControl_analysis_of_region_by_sponsor;
using UserControl_analysis_of_region_by_course;
using UserControl_analysis_of_region_by_county;

namespace UserControl_analysis_of_region_binder
  {

  public partial class TWebUserControl_analysis_of_region_binder: ki_web_ui.usercontrol_class
    {

    //--
    //
    // PRIVATE
    //
    //--

    private static class Static
      {
      public const int TSSI_INTRODUCTION = 0;
      public const int TSSI_BY_YEAR = 1;
      public const int TSSI_BY_MONTH = 2;
      public const int TSSI_BY_SPONSOR = 3;
      public const int TSSI_BY_COURSE = 4;
      public const int TSSI_BY_COUNTY = 5;
      }

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
      if (p.tab_index == Static.TSSI_INTRODUCTION)
        {
        var c = ((TWebUserControl_analysis_intro)(LoadControl("~/usercontrol/app/UserControl_analysis_intro.ascx")));
        p.content_id = AddIdentifiedControlToPlaceHolder(c,"UserControl_analysis_intro",PlaceHolder_content,(be_fresh_control_required ? InstanceId() : k.EMPTY));
        }
      else if (p.tab_index == Static.TSSI_BY_YEAR)
        {
        var c = ((TWebUserControl_analysis_of_region_by_year)(LoadControl("~/usercontrol/app/UserControl_analysis_of_region_by_year.ascx")));
        p.content_id = AddIdentifiedControlToPlaceHolder(c,"UserControl_analysis_of_region_by_year",PlaceHolder_content,(be_fresh_control_required ? InstanceId() : k.EMPTY));
        }
      else if (p.tab_index == Static.TSSI_BY_MONTH)
        {
        var c = ((TWebUserControl_analysis_of_region_by_month)(LoadControl("~/usercontrol/app/UserControl_analysis_of_region_by_month.ascx")));
        p.content_id = AddIdentifiedControlToPlaceHolder(c,"UserControl_analysis_of_region_by_month",PlaceHolder_content,(be_fresh_control_required ? InstanceId() : k.EMPTY));
        }
      else if (p.tab_index == Static.TSSI_BY_SPONSOR)
        {
        var c = ((TWebUserControl_analysis_of_region_by_sponsor)(LoadControl("~/usercontrol/app/UserControl_analysis_of_region_by_sponsor.ascx")));
        p.content_id = AddIdentifiedControlToPlaceHolder(c,"UserControl_analysis_of_region_by_sponsor",PlaceHolder_content,(be_fresh_control_required ? InstanceId() : k.EMPTY));
        }
      else if (p.tab_index == Static.TSSI_BY_COURSE)
        {
        var c = ((TWebUserControl_analysis_of_region_by_course)(LoadControl("~/usercontrol/app/UserControl_analysis_of_region_by_course.ascx")));
        p.content_id = AddIdentifiedControlToPlaceHolder(c,"UserControl_analysis_of_region_by_course",PlaceHolder_content,(be_fresh_control_required ? InstanceId() : k.EMPTY));
        }
      else if (p.tab_index == Static.TSSI_BY_COUNTY)
        {
        var c = ((TWebUserControl_analysis_of_region_by_county)(LoadControl("~/usercontrol/app/UserControl_analysis_of_region_by_county.ascx")));
        p.content_id = AddIdentifiedControlToPlaceHolder(c,"UserControl_analysis_of_region_by_county",PlaceHolder_content,(be_fresh_control_required ? InstanceId() : k.EMPTY));
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
      PreRender += TWebUserControl_analysis_binder_PreRender;
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

    private void TWebUserControl_analysis_binder_PreRender(object sender, System.EventArgs e)
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
        if (instance_id == "ASP.protected_overview_aspx.UserControl_regional_staffer_binder_analysis_binder")
          {
          p.be_loaded &= ((Session["UserControl_regional_staffer_binder_PlaceHolder_content"] as string) == "UserControl_analysis_binder");
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
        p.tab_index = Static.TSSI_INTRODUCTION;
        FillPlaceHolder(true);
        }
      }

    //--
    //
    // PUBLIC
    //
    //--

    public TWebUserControl_analysis_of_region_binder Fresh()
      {
      Session.Remove(InstanceId() + ".p");
      return this;
      }

    public void SetTarget(string target)
      {
      if (target.Length > 0)
        {
        if (target.ToLower().Contains("/introduction/"))
          {
          p.tab_index = Static.TSSI_INTRODUCTION;
          }
        else if (target.ToLower().Contains("/by-year/"))
          {
          p.tab_index = Static.TSSI_BY_YEAR;
          }
        else if (target.ToLower().Contains("/by-month/"))
          {
          p.tab_index = Static.TSSI_BY_MONTH;
          }
        else if (target.ToLower().Contains("/by-sponsor/"))
          {
          p.tab_index = Static.TSSI_BY_SPONSOR;
          }
        else if (target.ToLower().Contains("/by-course/"))
          {
          p.tab_index = Static.TSSI_BY_COURSE;
          }
        else if (target.ToLower().Contains("/by-county/"))
          {
          p.tab_index = Static.TSSI_BY_COUNTY;
          }
        //
        TabContainer_control.ActiveTabIndex = (int)p.tab_index;
        PlaceHolder_content.Controls.Clear();
        FillPlaceHolder(false,target);
        //
        }
      }

    } // end TWebUserControl_analysis_binder

  }
