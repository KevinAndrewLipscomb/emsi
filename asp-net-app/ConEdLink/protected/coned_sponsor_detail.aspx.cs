// Derived from template~protected~nonlanding.aspx.cs~template

using Class_biz_teaching_entities;
using Class_msg_protected;
using System;
using System.Configuration;

namespace coned_sponsor_detail
  {
  public partial class TWebForm_coned_sponsor_detail: ki_web_ui.page_class
    {

    private struct p_type
      {
      internal TClass_biz_teaching_entities biz_teaching_entities;
      internal TClass_msg_protected.coned_sponsor_detail incoming;
      }

    private p_type p;

    // / <summary>
    // / Required method for Designer support -- do not modify
    // / the contents of this method with the code editor.
    // / </summary>
    private void InitializeComponent()
      {
      PreRender += TWebForm_coned_sponsor_detail_PreRender;
      }

    protected void Page_Load(object sender, System.EventArgs e)
      {
      if (!IsPostBack)
        {
        Title = Server.HtmlEncode(ConfigurationManager.AppSettings["application_name"]) + " - coned_sponsor_detail";
        Literal_sponsor_name.Text = p.incoming.name;
        Literal_application_name.Text = ConfigurationManager.AppSettings["application_name"];
        Literal_application_name_2.Text = Literal_application_name.Text;
        Literal_application_name_3.Text = Literal_application_name.Text;
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
        p.biz_teaching_entities = new TClass_biz_teaching_entities();
        //
        p.incoming = ConsumedMessage<TClass_msg_protected.coned_sponsor_detail>("protected","coned_sponsor_detail");
        SessionSet("mode:goto","/coned_sponsor/" + p.incoming.id);
        UserControl_coned_sponsor_user_control.SetTarget(p.incoming.id);
        }
      else if (nature_of_visit == nature_of_visit_type.VISIT_POSTBACK_STANDARD)
        {
        p = (p_type)(Session[InstanceId() + ".p"]);
        }
      //
      // ToolkitScriptManager.GetCurrent(Page).EnablePartialRendering = false;
      //
      }

    private void TWebForm_coned_sponsor_detail_PreRender(object sender, System.EventArgs e)
      {
      SessionSet(InstanceId() + ".p", p);
      }

    } // end TWebForm_coned_sponsor_detail

  }
