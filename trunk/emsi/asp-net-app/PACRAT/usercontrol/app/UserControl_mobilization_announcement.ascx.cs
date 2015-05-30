using AjaxControlToolkit;
using Class_biz_notifications;
using Class_biz_regions;
using Class_biz_services;
using Class_biz_strike_team_deployments;
using Class_msg_protected;
using kix;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserControl_mobilization_announcement
  {

  public partial class TWebUserControl_mobilization_announcement: ki_web_ui.usercontrol_class
    {

    private static class Static
      {
      public const int TCI_REGION_CODE = 0;
      public const int TCI_REGION_SPACER = 1;
      public const int TCI_REGION_CONTENT = 2;
      public const int TCI_SERVICE_ID = 0;
      public const int TCI_SERVICE_SPACER = 1;
      public const int TCI_SERVICE_CONTENT = 2;
      }

    private struct p_type
      {
      public bool be_loaded;
      public TClass_biz_notifications biz_notifications;
      public TClass_biz_regions biz_regions;
      public TClass_biz_services biz_services;
      public TClass_biz_strike_team_deployments biz_strike_team_deployments;
      public object deployment_summary;
      }

    private p_type p;

    protected void Page_Load(object sender, System.EventArgs e)
      {
      if (!p.be_loaded)
        {
        Label_deployment_name.Text = p.biz_strike_team_deployments.NameOf(p.deployment_summary);
        Literal_application_name.Text = ConfigurationManager.AppSettings["application_name"];
        p.biz_regions.BindPacratManagementBaseDataList
          (
          sort_order:"name",
          be_sort_order_ascending:true,
          target:DataGrid_regions,
          do_include_all_regions:false
          );
        p.be_loaded = true;
        }
      ScriptManager.GetCurrent(Page).RegisterPostBackControl(Button_submit);
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
//#warning Revise the binder-related instance_id to this control appropriately.
//        if (instance_id == "ASP.protected_overview_aspx.UserControl_member_binder_mobilization_announcement")
//          {
//#warning Revise the ClientID path to this control appropriately.
//          p.be_loaded &= ((Session["UserControl_member_binder_PlaceHolder_content"] as string) == "UserControl_mobilization_announcement");
//          }
////      else if (instance_id == "ASP.~_aspx.UserControl_~_binder_mobilization_announcement")
////        {
////        p.be_loaded &= ((Session["UserControl_~_binder_PlaceHolder_content"] as string) == "UserControl_mobilization_announcement");
////        }
        }
      else
        {
        p.biz_notifications = new TClass_biz_notifications();
        p.biz_regions = new TClass_biz_regions();
        p.biz_services = new TClass_biz_services();
        p.biz_strike_team_deployments = new TClass_biz_strike_team_deployments();
        //
        p.be_loaded = false;
        }
      }

    // / <summary>
    // / Required method for Designer support -- do not modify
    // / the contents of this method with the code editor.
    // / </summary>
    private void InitializeComponent()
      {
      PreRender += TWebUserControl_mobilization_announcement_PreRender;
      }

    private void TWebUserControl_mobilization_announcement_PreRender(object sender, System.EventArgs e)
      {
      SessionSet(InstanceId() + ".p", p);
      }

    public TWebUserControl_mobilization_announcement Fresh()
      {
      Session.Remove(InstanceId() + ".p");
      return this;
      }

    internal void Set(object deployment_summary)
      {
      p.deployment_summary = deployment_summary;
      }

    protected void Button_submit_Click(object sender, System.EventArgs e)
      {
      if (Page.IsValid)
        {
        var data_grid_region_items = DataGrid_regions.Items;
        for (var i = 0; i < data_grid_region_items.Count; i++)
          {
          var data_grid_service_items = (data_grid_region_items[i].Cells[Static.TCI_REGION_CONTENT].FindControl("DataGrid_services") as DataGrid).Items;
          for (var j = 0; j < data_grid_service_items.Count; j++)
            {
            var service_cells = data_grid_service_items[j].Cells;
            if ((service_cells[Static.TCI_SERVICE_CONTENT].FindControl("CheckBox_include_service") as CheckBox).Checked)
              {
              p.biz_strike_team_deployments.AnnounceMobilization
                (
                summary:p.deployment_summary,
                supplemental_message:k.Safe(TextBox_supplemental_message.Text,k.safe_hint_type.MEMO),
                service_id:k.Safe(service_cells[Static.TCI_SERVICE_ID].Text,k.safe_hint_type.NUM)
                );
              }
            }
          }
        TextBox_supplemental_message.Text = k.EMPTY;
        var msg_protected_strike_team_deployment_detail = new TClass_msg_protected.strike_team_deployment_detail();
        msg_protected_strike_team_deployment_detail.id = p.biz_strike_team_deployments.IdOf(p.deployment_summary);
        MessageBack
          (
          msg:msg_protected_strike_team_deployment_detail,
          folder_name:"protected",
          aspx_name:"strike_team_deployment_detail"
          );
        AlertAndBackTrack
          (
          cause:k.alert_cause_type.USER,
          state:k.alert_state_type.NORMAL,
          key:"ancmtsent",
          value:"Announcement sent"
          );
        }
      else
        {
        Alert
          (
          cause:k.alert_cause_type.USER,
          state:k.alert_state_type.FAILURE,
          key:"noancmtrecips",
          value:"Announcement *NOT* sent.  No recipients are selected.",
          be_using_scriptmanager:true
          );
        }
      }

    protected void CustomValidator_service_strike_teams_ServerValidate(object source, ServerValidateEventArgs args)
      {
      args.IsValid = false;
      if (CheckBox_force_state.Checked)
        {
        args.IsValid = true;
        }
      else
        {
        var data_grid_region_items = DataGrid_regions.Items;
        for (var region_index = new k.subtype<int>(0,data_grid_region_items.Count); !args.IsValid && region_index.val < region_index.LAST; region_index.val++)
          {
          var region_content_table_cell = data_grid_region_items[region_index.val].Cells[Static.TCI_REGION_CONTENT];
          if ((region_content_table_cell.FindControl("CheckBox_force_region") as CheckBox).Checked)
            {
            args.IsValid = true;
            }
          else
            {
            var data_grid_service_items = (region_content_table_cell.FindControl("DataGrid_services") as DataGrid).Items;
            for (var service_index = new k.subtype<int>(0,data_grid_service_items.Count); !args.IsValid && service_index.val < service_index.LAST; service_index.val++)
              {
              args.IsValid = ((data_grid_service_items[service_index.val].Cells[Static.TCI_SERVICE_CONTENT].FindControl("CheckBox_include_service") as CheckBox).Checked);
              }
            }
          }
        }
      }

    protected void DataGrid_regions_ItemDataBound(object sender, DataGridItemEventArgs e)
      {
      if (e.Item.ItemType.ToString().EndsWith("Item"))
        {
        var datagrid_services = (e.Item.Cells[Static.TCI_REGION_CONTENT].FindControl("DataGrid_services") as DataGrid);
        p.biz_services.BindPacratManagementBaseDataList
          (
          sort_order:"short_name",
          be_sort_order_ascending:true,
          target:datagrid_services,
          region_code:e.Item.Cells[Static.TCI_REGION_CODE].Text,
          do_include_all_services:false
          );
        e.Item.Visible = (datagrid_services.Items.Count > 0);
        }
      }

    protected void CheckBox_force_state_CheckedChanged(object sender, System.EventArgs e)
      {
      var data_grid_region_items = DataGrid_regions.Items;
      for (var i = 0; i < data_grid_region_items.Count; i++)
        {
        var region_table_cell = data_grid_region_items[i].Cells[Static.TCI_REGION_CONTENT];
        (region_table_cell.FindControl("CheckBox_force_region") as CheckBox).Checked = CheckBox_force_state.Checked;
        var data_grid_service_items = (region_table_cell.FindControl("DataGrid_services") as DataGrid).Items;
        for (var j = 0; j < data_grid_service_items.Count; j++)
          {
          (data_grid_service_items[j].Cells[Static.TCI_SERVICE_CONTENT].FindControl("CheckBox_include_service") as CheckBox).Checked = CheckBox_force_state.Checked;
          }
        }
      }

    protected void LinkButton_expand_state_Click(object sender, System.EventArgs e)
      {
      LinkButton_expand_state.Text = (LinkButton_expand_state.Text == "[+]" ? "[-]" : "[+]");
      DataGrid_regions.Visible = !DataGrid_regions.Visible;
      }

    protected void LinkButton_expand_region_Click(object sender, System.EventArgs e)
      {
      var link_button = (sender as LinkButton);
      link_button.Text = (link_button.Text == "[+]" ? "[-]" : "[+]");
      var data_grid = ((link_button.Parent as TableCell).FindControl("DataGrid_services") as DataGrid);
      data_grid.Visible = !data_grid.Visible;
      }

    protected void CheckBox_force_region_CheckedChanged(object sender, System.EventArgs e)
      {
      var check_box_force_region = (sender as CheckBox);
      var data_grid_service_items = ((check_box_force_region.Parent as TableCell).FindControl("DataGrid_services") as DataGrid).Items;
      for (var j = 0; j < data_grid_service_items.Count; j++)
        {
        (data_grid_service_items[j].Cells[Static.TCI_SERVICE_CONTENT].FindControl("CheckBox_include_service") as CheckBox).Checked = check_box_force_region.Checked;
        }
      }

    }

  }
