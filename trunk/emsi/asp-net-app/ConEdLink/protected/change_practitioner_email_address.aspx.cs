// Derived from template~protected~nonlanding.aspx.cs~template

using Class_msg_protected;
using kix;
using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace change_practitioner_email_address
  {
  public partial class TWebForm_change_practitioner_email_address: ki_web_ui.page_class
    {

    private struct p_type
      {
      public TClass_msg_protected.change_practitioner_email_address incoming;
      }

    private p_type p; // Private Parcel of Page-Pertinent Process-Persistent Parameters

    // / <summary>
    // / Required method for Designer support -- do not modify
    // / the contents of this method with the code editor.
    // / </summary>
    private void InitializeComponent()
      {
      PreRender += TWebForm_change_practitioner_email_address_PreRender;
      }

    protected void Page_Load(object sender, System.EventArgs e)
      {
      Title = Server.HtmlEncode(ConfigurationManager.AppSettings["application_name"]) + " - change_practitioner_email_address";
      if (!IsPostBack)
        {
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
        p.incoming = Message<TClass_msg_protected.change_practitioner_email_address>
          (
          folder_name:"protected",
          aspx_name:"change_practitioner_email_address"
          );
        UserControl_change_practitioner_email_address_control.Set(practitioner_summary:p.incoming.practitioner_summary);
        }
      else if (nature_of_visit == nature_of_visit_type.VISIT_POSTBACK_STANDARD)
        {
        p = (p_type)(Session[InstanceId() + ".p"]);
        }
      //
      // ScriptManager.GetCurrent(Page).EnablePartialRendering = false;
      //
      }

    private void TWebForm_change_practitioner_email_address_PreRender(object sender, System.EventArgs e)
      {
      SessionSet(InstanceId() + ".p", p);
      }

    } // end TWebForm_change_practitioner_email_address

  }
