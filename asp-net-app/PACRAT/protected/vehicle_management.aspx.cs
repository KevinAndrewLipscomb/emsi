// Derived from template~protected~nonlanding.aspx.cs~template

using Class_biz_services;
using Class_msg_protected;
using System;
using System.Configuration;

namespace vehicle_management
  {
  public partial class TWebForm_vehicle_management: ki_web_ui.page_class
    {

    private struct p_type
      {
      public TClass_biz_services biz_services;
      public TClass_msg_protected.vehicle_management incoming;
      }

    private p_type p;

    // / <summary>
    // / Required method for Designer support -- do not modify
    // / the contents of this method with the code editor.
    // / </summary>
    private void InitializeComponent()
      {
      //this.Load += this.Page_Load;
      this.PreRender += this.TWebForm_vehicle_management_PreRender;
      }

    protected void Page_Load(object sender, System.EventArgs e)
      {
      if (!IsPostBack)
        {
        Title = Server.HtmlEncode(ConfigurationManager.AppSettings["application_name"]) + " - vehicle_management";
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
        p.biz_services = new TClass_biz_services();
        //
        p.incoming = Message<TClass_msg_protected.vehicle_management>
          (
          folder_name:"protected",
          aspx_name:"vehicle_management"
          );
        //
        UserControl_vehicles_control.Set(service_id:p.biz_services.IdOf(p.incoming.summary));
        }
      else if (nature_of_visit == nature_of_visit_type.VISIT_POSTBACK_STANDARD)
        {
        p = (p_type)(Session[InstanceId() + ".p"]);
        }
//
// ToolkitScriptManager.GetCurrent(Page).EnablePartialRendering = false;
//
      }

    private void TWebForm_vehicle_management_PreRender(object sender, System.EventArgs e)
      {
      SessionSet(InstanceId() + ".p", p);
      }

    } // end TWebForm_vehicle_management

  }
