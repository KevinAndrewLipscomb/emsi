// Derived from KiAspdotnetFramework/UserControl/app/UserControl~coned_sponsor~binder.cs~coned_sponsor

using kix;
using System;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using UserControl_about;
using UserControl_class_catalog;
using UserControl_coned_sponsor;
using UserControl_practitioner;
using UserControl_analysis_of_sponsor_binder;

namespace UserControl_coned_sponsor_binder
  {
  public class UserControl_coned_sponsor_binder_Static
    {
    public const int TSSI_MY_PROFILE = 0;
    public const int TSSI_CLASSES = 1;
    public const int TSSI_PRACTITIONERS = 2;
    public const int TSSI_ANALYSES = 3;
    public const int TSSI_ABOUT = 4;
    }

  public partial class TWebUserControl_coned_sponsor_binder: ki_web_ui.usercontrol_class
    {

    private struct p_type
      {
      public bool be_loaded;
    public string content_id;
    public uint tab_index;
    public string user_sponsor_id;
      }

    private p_type p; // Private Parcel of Page-Pertinent Process-Persistent Parameters

    private void Page_Load(object sender, System.EventArgs e)
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
        FillPlaceHolder(false);
        }
      else
        {
        p.be_loaded = false;
        p.tab_index = UserControl_coned_sponsor_binder_Static.TSSI_CLASSES;
        p.user_sponsor_id = k.EMPTY;
        FillPlaceHolder(true);
        }
      }

    // / <summary>
    // / Required method for Designer support -- do not modify
    // / the contents of this method with the code editor.
    // / </summary>
    private void InitializeComponent()
      {
      TabContainer_control.ActiveTabChanged += TabContainer_control_ActiveTabChanged;
      PreRender += TWebUserControl_coned_sponsor_binder_PreRender;
      }

    private void TWebUserControl_coned_sponsor_binder_PreRender(object sender, System.EventArgs e)
      {
      //
      // Indicate to children which content control was active on this pass, so that on subsequent passes a child can detect whether or
      // not it is already loaded in the user's browser.
      //
      SessionSet(PlaceHolder_content.ClientID, p.content_id);
      SessionSet(InstanceId() + ".p", p);
      }

    public TWebUserControl_coned_sponsor_binder Fresh()
      {
      Session.Remove(InstanceId() + ".p");
      return this;
      }

    private void TabContainer_control_ActiveTabChanged(object sender, System.EventArgs e)
      {
      p.tab_index = (uint)(TabContainer_control.ActiveTabIndex);
      PlaceHolder_content.Controls.Clear();
      FillPlaceHolder(true);
      }

    private void FillPlaceHolder
      (
      #pragma warning disable CA1801 // Remove unused parameter
      bool be_fresh_control_required,
      string target
      #pragma warning restore CA1801 // Remove unused parameter
      )
      {
      if (p.tab_index == UserControl_coned_sponsor_binder_Static.TSSI_MY_PROFILE)
        {
        var c = ((TWebUserControl_coned_sponsor)(LoadControl("~/usercontrol/app/UserControl_coned_sponsor.ascx")));
        p.content_id = AddIdentifiedControlToPlaceHolder(c,"UserControl_coned_sponsor",PlaceHolder_content,(be_fresh_control_required ? InstanceId() : k.EMPTY));
        c.SetTarget("/coned_sponsor/" + Session["coned_sponsor_user_id"].ToString());
        }
      else if (p.tab_index == UserControl_coned_sponsor_binder_Static.TSSI_CLASSES)
        {
        var c = ((TWebUserControl_class_catalog)(LoadControl("~/usercontrol/app/UserControl_class_catalog.ascx")));
        p.content_id = AddIdentifiedControlToPlaceHolder(c,"UserControl_class_catalog",PlaceHolder_content,(be_fresh_control_required ? InstanceId() : k.EMPTY));
        }
      else if (p.tab_index == UserControl_coned_sponsor_binder_Static.TSSI_PRACTITIONERS)
        {
        var c = ((TWebUserControl_practitioner)(LoadControl("~/usercontrol/app/UserControl_practitioner.ascx")));
        p.content_id = AddIdentifiedControlToPlaceHolder(c,"UserControl_practitioner",PlaceHolder_content,(be_fresh_control_required ? InstanceId() : k.EMPTY));
        c.Set(user_sponsor_id_filter:p.user_sponsor_id);
        }
      else if (p.tab_index == UserControl_coned_sponsor_binder_Static.TSSI_ANALYSES)
        {
        var c = ((TWebUserControl_analysis_of_sponsor_binder)(LoadControl("~/usercontrol/app/UserControl_analysis_of_sponsor_binder.ascx")));
        p.content_id = AddIdentifiedControlToPlaceHolder(c,"UserControl_analysis_of_sponsor_binder",PlaceHolder_content,(be_fresh_control_required ? InstanceId() : k.EMPTY));
        }
      else if (p.tab_index == UserControl_coned_sponsor_binder_Static.TSSI_ABOUT)
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
      if (target.Length > 0)
        {
        if (target.ToLower().Contains("/profile/"))
          {
          p.tab_index = UserControl_coned_sponsor_binder_Static.TSSI_MY_PROFILE;
          }
        else if (target.ToLower().Contains("/class/"))
          {
          p.tab_index = UserControl_coned_sponsor_binder_Static.TSSI_CLASSES;
          }
        else if (target.ToLower().Contains("/practitioner/"))
          {
          p.tab_index = UserControl_coned_sponsor_binder_Static.TSSI_PRACTITIONERS;
          }
        else if (target.ToLower().Contains("/analysis/"))
          {
          p.tab_index = UserControl_coned_sponsor_binder_Static.TSSI_ANALYSES;
          }
        else if (target.ToLower().Contains("/about/"))
          {
          p.tab_index = UserControl_coned_sponsor_binder_Static.TSSI_ABOUT;
          }
        //
        TabContainer_control.ActiveTabIndex = (int)p.tab_index;
        PlaceHolder_content.Controls.Clear();
        FillPlaceHolder(false,target);
        //
        }
      }

    internal void Set(string user_sponsor_id)
      {
      p.user_sponsor_id = user_sponsor_id;
      }

    } // end TWebUserControl_coned_sponsor_binder

  }
