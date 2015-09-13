// Derived from template~protected~nonlanding.aspx.cs~template

using Class_msg_protected;
using System;
using System.Configuration;

namespace add_associate
  {

  public partial class TWebForm_add_associate: ki_web_ui.page_class
    {

    private struct p_type
      {
      public TClass_msg_protected.add_associate incoming;
      }

    private p_type p;

    // / <summary>
    // / Required method for Designer support -- do not modify
    // / the contents of this method with the code editor.
    // / </summary>
    private void InitializeComponent()
      {
      PreRender += TWebForm_add_associate_PreRender;
      }

    protected void Page_Load(object sender, System.EventArgs e)
      {
      if (!IsPostBack)
        {
        Title = Server.HtmlEncode(ConfigurationManager.AppSettings["application_name"]) + " - add_associate";
        }
      }

    protected override void OnInit(EventArgs e)
      {
      // Required for Designer support
      InitializeComponent();
      base.OnInit(e);
      var nature_of_visit = NatureOfVisit(InstanceId() + ".p");
      if (nature_of_visit == nature_of_visit_type.VISIT_INITIAL)
        {
        //
        // Initialize p.~ objects here.
        //
        p.incoming = Message<TClass_msg_protected.add_associate>
          (
          folder_name:"protected",
          aspx_name:"add_associate"
          );
        UserControl_add_associate_control.SetP
          (
          tier_name:p.incoming.tier_name,
          association_id:p.incoming.association_id,
          association_name:p.incoming.association_name
          );
        }
      else if (nature_of_visit == nature_of_visit_type.VISIT_POSTBACK_STANDARD)
        {
        p = (p_type)(Session[InstanceId() + ".p"]);
        }
//
// ScriptManager.GetCurrent(Page).EnablePartialRendering = false;
//
      }

    private void TWebForm_add_associate_PreRender(object sender, System.EventArgs e)
      {
      SessionSet(InstanceId() + ".p", p);
      }

    } // end TWebForm_add_associate

  }
