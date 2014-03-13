using AjaxControlToolkit;

namespace UserControl_other_prep_ops
  {

  public partial class TWebUserControl_other_prep_ops: ki_web_ui.usercontrol_class
    {

    private struct p_type
      {
      public bool be_loaded;
      }

    private p_type p;

    protected void Page_Load(object sender, System.EventArgs e)
      {
      if (!p.be_loaded)
        {
        p.be_loaded = true;
        }
      ToolkitScriptManager.GetCurrent(Page).RegisterPostBackControl(LinkButton_register_nonpractitioner_associate);
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
//        //
//        // If this control is being used dynamically under one or more parent binder(s), it must ascertain which instance it is, and whether or not that instance's parent binder
//        // had it loaded already.
//        //
//#warning Revise the binder-related instance_id to this control appropriately.
//        if (instance_id == "ASP.protected_overview_aspx.UserControl_member_binder_other_prep_ops")
//          {
//#warning Revise the ClientID path to this control appropriately.
//          p.be_loaded &= ((Session["UserControl_member_binder_PlaceHolder_content"] as string) == "UserControl_other_prep_ops");
//          }
//      else if (instance_id == "ASP.~_aspx.UserControl_~_binder_other_prep_ops")
//        {
//        p.be_loaded &= ((Session["UserControl_~_binder_PlaceHolder_content"] as string) == "UserControl_other_prep_ops");
//        }
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
      PreRender += TWebUserControl_other_prep_ops_PreRender;
      }

    private void TWebUserControl_other_prep_ops_PreRender(object sender, System.EventArgs e)
      {
      SessionSet(InstanceId() + ".p", p);
      }

    public TWebUserControl_other_prep_ops Fresh()
      {
      Session.Remove(InstanceId() + ".p");
      return this;
      }

    protected void LinkButton_register_nonpractitioner_associate_Click(object sender, System.EventArgs e)
      {
      MessageDropCrumbAndTransferTo
        (
        msg:null,
        folder_name:"protected",
        aspx_name:"associate_registration"
        );
      }

    }

  }
