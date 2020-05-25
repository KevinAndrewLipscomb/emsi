using Class_biz_eval_summary_modes;
using Class_biz_regions;
using kix;

namespace UserControl_config
  {

  public partial class TWebUserControl_config: ki_web_ui.usercontrol_class
    {

    private struct p_type
      {
      public bool be_loaded;
    public TClass_biz_eval_summary_modes biz_eval_summary_modes;
    public TClass_biz_regions biz_regions;
    public string region_code;
      }

    private p_type p; // Private Parcel of Page-Pertinent Process-Persistent Parameters

    protected void Page_Load(object sender, System.EventArgs e)
      {
      if (!p.be_loaded)
        {
        p.biz_eval_summary_modes.BindRadioButtonList(target:RadioButtonList_eval_summary_mode);
        RadioButtonList_eval_summary_mode.SelectedValue = p.biz_regions.ConedlinkEvalSummaryModeIdOf(p.region_code);
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
        if (instance_id == "ASP.protected_regional_staffer_overview_aspx.UserControl_regional_staffer_binder_config")
          {
          p.be_loaded &= ((Session["UserControl_regional_staffer_binder_PlaceHolder_content"] as string) == "UserControl_config");
          }
//      else if (instance_id == "ASP.~_aspx.UserControl_~_binder_config")
//        {
//        p.be_loaded &= ((Session["UserControl_~_binder_PlaceHolder_content"] as string) == "UserControl_config");
//        }
        }
      else
        {
        p.biz_eval_summary_modes = new TClass_biz_eval_summary_modes();
        p.biz_regions = new TClass_biz_regions();
        //
        p.be_loaded = false;
        p.region_code = Session["region_code"].ToString();
        }
      }

    // / <summary>
    // / Required method for Designer support -- do not modify
    // / the contents of this method with the code editor.
    // / </summary>
    private void InitializeComponent()
      {
      PreRender += TWebUserControl_config_PreRender;
      }

    private void TWebUserControl_config_PreRender(object sender, System.EventArgs e)
      {
      SessionSet(InstanceId() + ".p", p);
      }

    public TWebUserControl_config Fresh()
      {
      Session.Remove(InstanceId() + ".p");
      return this;
      }

    protected void RadioButtonList_eval_summary_mode_SelectedIndexChanged(object sender, System.EventArgs e)
      {
      p.biz_regions.SetConedlinkEvalSummaryModeId
        (
        code:p.region_code,
        id:k.Safe(RadioButtonList_eval_summary_mode.SelectedValue,k.safe_hint_type.NUM)
        );
      }

    }

  }
