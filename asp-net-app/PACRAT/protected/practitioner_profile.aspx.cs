// Derived from template~protected~nonlanding.aspx.cs~template

using Class_msg_protected;
using System;
using System.Configuration;

namespace practitioner_profile
  {
  public partial class TWebForm_practitioner_profile: ki_web_ui.page_class
    {

    private struct p_type
      {
      }

    private p_type p;

    // / <summary>
    // / Required method for Designer support -- do not modify
    // / the contents of this method with the code editor.
    // / </summary>
    private void InitializeComponent()
      {
      //this.Load += this.Page_Load;
      this.PreRender += this.TWebForm_practitioner_profile_PreRender;
      }

    protected void Page_Load(object sender, System.EventArgs e)
      {
      if (!IsPostBack)
        {
        Title = Server.HtmlEncode(ConfigurationManager.AppSettings["application_name"]) + " - practitioner_profile";
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
        var incoming = Message<TClass_msg_protected.practitioner_profile>(folder_name:"protected",aspx_name:"practitioner_profile");
        UserControl_practitioner_control.SetTarget(target:incoming.id);
        }
      else if (nature_of_visit == nature_of_visit_type.VISIT_POSTBACK_STANDARD)
        {
        p = (p_type)(Session[InstanceId() + ".p"]);
        }
//
// ScriptManager.GetCurrent(Page).EnablePartialRendering = false;
//
      }

    private void TWebForm_practitioner_profile_PreRender(object sender, System.EventArgs e)
      {
      SessionSet(InstanceId() + ".p", p);
      }

    } // end TWebForm_practitioner_profile

  }
