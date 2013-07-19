// Derived from template~protected~nonlanding.aspx.cs~template

using Class_biz_services;
using Class_biz_vehicles;
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

namespace vehicle_detail
  {
  public partial class TWebForm_vehicle_detail: ki_web_ui.page_class
    {

    private struct p_type
      {
      public TClass_biz_services biz_services;
      public TClass_biz_vehicles biz_vehicles;
      public TClass_msg_protected.vehicle_detail incoming;
      }

    private p_type p;

    // / <summary>
    // / Required method for Designer support -- do not modify
    // / the contents of this method with the code editor.
    // / </summary>
    private void InitializeComponent()
      {
      //this.Load += this.Page_Load;
      this.PreRender += this.TWebForm_vehicle_detail_PreRender;
      }

    protected void Page_Load(object sender, System.EventArgs e)
      {
      if (!IsPostBack)
        {
        Title = Server.HtmlEncode(ConfigurationManager.AppSettings["application_name"]) + " - vehicle_detail";
        Literal_service.Text = p.biz_services.NameOf(p.incoming.service_id);
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
        p.biz_vehicles = new TClass_biz_vehicles();
        //
        p.incoming = Message<TClass_msg_protected.vehicle_detail>
          (
          folder_name:"protected",
          aspx_name:"vehicle_detail"
          );
        //
        UserControl_vehicle_control.Set
          (
          id:p.incoming.id,
          service_id:p.incoming.service_id
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

    private void TWebForm_vehicle_detail_PreRender(object sender, System.EventArgs e)
      {
      SessionSet(InstanceId() + ".p", p);
      }

    } // end TWebForm_vehicle_detail

  }
