// Derived from template~protected~nonlanding.aspx.cs~template

using Class_msg_protected;
using System;
using System.Configuration;

namespace mobilization_announcement
  {
  public partial class TWebForm_mobilization_announcement: ki_web_ui.page_class
    {

    private struct p_type
      {
      public TClass_msg_protected.mobilization_announcement incoming;
      }

    private p_type p;

    // / <summary>
    // / Required method for Designer support -- do not modify
    // / the contents of this method with the code editor.
    // / </summary>
    private void InitializeComponent()
      {
      PreRender += TWebForm_mobilization_announcement_PreRender;
      }

    protected void Page_Load(object sender, System.EventArgs e)
      {
      if (!IsPostBack)
        {
        Title = Server.HtmlEncode(ConfigurationManager.AppSettings["application_name"]) + " - mobilization_announcement";
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
        p.incoming = Message<TClass_msg_protected.mobilization_announcement>
          (
          folder_name:"protected",
          aspx_name:"mobilization_announcement"
          );
        UserControl_mobilization_announcement_control.Set(deployment_summary:p.incoming.deployment_summary);
        }
      else if (nature_of_visit == nature_of_visit_type.VISIT_POSTBACK_STANDARD)
        {
        p = (p_type)(Session[InstanceId() + ".p"]);
        }
      //
      // ScriptManager.GetCurrent(Page).EnablePartialRendering = false;
      //
      }

    private void TWebForm_mobilization_announcement_PreRender(object sender, System.EventArgs e)
      {
      SessionSet(InstanceId() + ".p", p);
      }

    } // end TWebForm_mobilization_announcement

  }
