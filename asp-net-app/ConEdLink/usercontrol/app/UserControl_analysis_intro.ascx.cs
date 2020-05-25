using System;
using System.Configuration;

namespace UserControl_analysis_intro
  {

  public partial class TWebUserControl_analysis_intro: ki_web_ui.usercontrol_class
    {

    private struct p_type
      {
      public bool be_loaded;
      }

    private p_type p; // Private Parcel of Page-Pertinent Process-Persistent Parameters

    protected void Page_Load(object sender, EventArgs e)
      {
      if (!p.be_loaded)
        {
        Literal_application_name.Text = ConfigurationManager.AppSettings["application_name"];
        //
        p.be_loaded = true;
        }
      }

    protected override void OnInit(EventArgs e)
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
        if (instance_id == "ASP.protected_regional_staffer_overview_aspx.UserControl_regional_staffer_binder_analysis_of_region_binder_analysis_intro")
          {
          p.be_loaded &= ((Session["UserControl_regional_staffer_binder_UserControl_analysis_of_region_binder_PlaceHolder_content"] as string) == "UserControl_analysis_intro");
          }
        else if (instance_id == "ASP.protected_coned_sponsor_overview_aspx.UserControl_coned_sponsor_binder_control_analysis_of_sponsor_binder_analysis_intro")
          {
          p.be_loaded &= ((Session["UserControl_coned_sponsor_binder_control_UserControl_analysis_of_sponsor_binder_PlaceHolder_content"] as string) == "UserControl_analysis_intro");
          }
        }
      else
        {
        p.be_loaded = false;
        }
      }

    // / <summary>
    // / Required method for Designer support -- do not modify
    // / the contents of this method with the code editor.
    // / </summary>
    private void InitializeComponent()
      {
      PreRender += TWebUserControl_analysis_intro_PreRender;
      }

    private void TWebUserControl_analysis_intro_PreRender(object sender, EventArgs e)
      {
      SessionSet(InstanceId() + ".p", p);
      }

    public TWebUserControl_analysis_intro Fresh()
      {
      Session.Remove(InstanceId() + ".p");
      return this;
      }

    }

  }
