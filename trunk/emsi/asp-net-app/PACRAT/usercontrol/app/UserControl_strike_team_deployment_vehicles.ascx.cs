// Derived from KiAspdotnetFramework/UserControl/app/UserControl~template~datagrid~sortable.ascx.cs

using AjaxControlToolkit;
using Class_biz_strike_team_deployment_logs;
using Class_biz_strike_team_deployment_vehicles;
using Class_biz_strike_team_deployments;
using Class_msg_protected;
using kix;
using System;
using System.Collections;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserControl_strike_team_deployment_vehicles
  {
  public partial class TWebUserControl_strike_team_deployment_vehicles: ki_web_ui.usercontrol_class
    {
    public class UserControl_strike_team_deployment_vehicles_Static
      {
      public const int TCI_SELECT = 0;
      public const int TCI_ID = 1;
      public const int TCI_VEHICLE_ID = 2;
      public const int TCI_MOBILIZED = 3;
      public const int TCI_SAVED_TACTICAL_NAME = 4;
      public const int TCI_TACTICAL_NAME = 5;
      public const int TCI_SAVED_TRANSPONDER_NAME = 6;
      public const int TCI_TRANSPONDER_NAME = 7;
      public const int TCI_SERVICE_ID = 8;
      public const int TCI_SERVICE = 9;
      public const int TCI_NAME = 10;
      public const int TCI_LVL = 11;
      public const int TCI_KIND = 12;
      public const int TCI_DECAL_NUM = 13;
      public const int TCI_TOW_CAP = 14;
      public const int TCI_FUEL = 15;
      public const int TCI_AWD = 16;
      public const int TCI_ELABORATION = 17;
      }

    private struct p_type
      {
      public bool be_datagrid_empty;
      public bool be_interactive;
      public bool be_loaded;
      public bool be_sort_order_ascending;
      public TClass_biz_strike_team_deployment_logs biz_strike_team_deployment_logs;
      public TClass_biz_strike_team_deployment_vehicles biz_strike_team_deployment_vehicles;
      public TClass_biz_strike_team_deployments biz_strike_team_deployments;
      public string deployment_id;
      public bool do_include_all_eligible_vehicles;
      public TClass_msg_protected.underway_demobilization msg_protected_underway_demobilization;
      public TClass_msg_protected.vehicle_detail msg_protected_vehicle_detail;
      public uint num_vehicles;
      public string service_strike_team_management_footprint;
      public string sort_order;
      }

    private p_type p;

    private void InjectPersistentClientSideScript()
      {
      // EstablishClientSideFunction(k.client_side_function_enumeral_type.EL);
      // EstablishClientSideFunction(k.client_side_function_enumeral_type.KGS_TO_LBS);
      // EstablishClientSideFunction(k.client_side_function_enumeral_type.LBS_TO_KGS);
      // EstablishClientSideFunction
      // (
      // 'RecalculateDependentValues()',
      // k.EMPTY
      // + 'El("' + TextBox_gain_or_loss_in_lbs.clientid + '").value ='
      // +  ' El("' + TextBox_gross_landed_weight_in_pounds.clientid + '").value - El("' + TextBox_gross_invoiced_weight_in_lbs.clientid + '").value;'
      // + k.NEW_LINE
      // + 'El("' + TextBox_gain_or_loss_in_kgs.clientid + '").value ='
      // +  ' El("' + TextBox_gross_landed_weight_in_kgs.clientid + '").value - El("' + TextBox_gross_invoiced_weight_in_kgs.clientid + '").value;'
      // + k.NEW_LINE
      // + 'El("' + TextBox_gain_or_loss_per_bale_in_lbs.clientid + '").value ='
      // +  ' El("' + TextBox_gain_or_loss_in_lbs.clientid + '").value/El("' + TextBox_bales.clientid + '").value;'
      // + k.NEW_LINE
      // + 'El("' + TextBox_gain_or_loss_per_bale_in_kgs.clientid + '").value ='
      // +  ' El("' + TextBox_gain_or_loss_in_kgs.clientid + '").value/El("' + TextBox_bales.clientid + '").value;'
      // + k.NEW_LINE
      // + 'El("' + TextBox_actual_gain_or_loss_in_lbs.clientid + '").value ='
      // +  ' El("' + TextBox_gain_or_loss_in_lbs.clientid + '").value - El("' + TextBox_franchise_in_lbs.clientid + '").value;'
      // + k.NEW_LINE
      // + 'El("' + TextBox_actual_gain_or_loss_in_kgs.clientid + '").value ='
      // +  ' El("' + TextBox_gain_or_loss_in_kgs.clientid + '").value - El("' + TextBox_franchise_in_kgs.clientid + '").value;'
      // + k.NEW_LINE
      // + 'El("' + TextBox_actual_gain_or_loss_per_bale_in_lbs.clientid + '").value ='
      // +  ' El("' + TextBox_actual_gain_or_loss_in_lbs.clientid + '").value/El("' + TextBox_bales.clientid + '").value;'
      // + k.NEW_LINE
      // + 'El("' + TextBox_actual_gain_or_loss_per_bale_in_kgs.clientid + '").value ='
      // +  ' El("' + TextBox_actual_gain_or_loss_in_kgs.clientid + '").value/El("' + TextBox_bales.clientid + '").value;'
      // + k.NEW_LINE
      // + 'El("' + TextBox_percent_gain_or_loss.clientid + '").value ='
      // +  ' Math.round(El("' + TextBox_actual_gain_or_loss_in_lbs.clientid + '").value/El("' + TextBox_net_invoiced_in_lbs.clientid + '").value*100*100)/100;'
      // + k.NEW_LINE
      // + 'El("' + TextBox_monetary_gain_or_loss.clientid + '").value ='
      // +  ' El("' + TextBox_actual_gain_or_loss_in_lbs.clientid + '").value*El("' + TextBox_unit_price_in_cents_per_pound.clientid + '").value;'
      // );
      // //
      // TextBox_bales.attributes.Add('onkeyup','RecalculateDependentValues();');
      // TextBox_gross_landed_weight_in_pounds.attributes.Add
      // (
      // 'onkeyup',
      // 'El("' + TextBox_gross_landed_weight_in_kgs.clientid + '").value = LbsToKgs(El("' + TextBox_gross_landed_weight_in_pounds.clientid + '").value);'
      // + ' RecalculateDependentValues();'
      // );
      // TextBox_gross_landed_weight_in_kgs.attributes.Add
      // (
      // 'onkeyup',
      // 'El("' + TextBox_gross_landed_weight_in_pounds.clientid + '").value = KgsToLbs(El("' + TextBox_gross_landed_weight_in_kgs.clientid + '").value);'
      // + ' RecalculateDependentValues();'
      // );
      // TextBox_landed_or_ciq_tare.attributes.Add
      // (
      // 'onkeyup',
      // 'El("' + TextBox_landed_or_ciq_tare_in_kgs.clientid + '").value = LbsToKgs(El("' + TextBox_landed_or_ciq_tare.clientid + '").value);'
      // + ' RecalculateDependentValues();'
      // );
      // TextBox_landed_or_ciq_tare_in_kgs.attributes.Add
      // (
      // 'onkeyup',
      // 'El("' + TextBox_landed_or_ciq_tare.clientid + '").value = KgsToLbs(El("' + TextBox_landed_or_ciq_tare_in_kgs.clientid + '").value);'
      // + ' RecalculateDependentValues();'
      // );
      // TextBox_net_landed_in_pounds.attributes.Add
      // (
      // 'onkeyup',
      // 'El("' + TextBox_net_landed_in_kgs.clientid + '").value = LbsToKgs(El("' + TextBox_net_landed_in_pounds.clientid + '").value);'
      // + ' RecalculateDependentValues();'
      // );
      // TextBox_net_landed_in_kgs.attributes.Add
      // (
      // 'onkeyup',
      // 'El("' + TextBox_net_landed_in_pounds.clientid + '").value = KgsToLbs(El("' + TextBox_net_landed_in_kgs.clientid + '").value);'
      // + ' RecalculateDependentValues();'
      // );
      }

    protected void Page_Load(object sender, System.EventArgs e)
      {
      if (!p.be_loaded)
        {
        if (!p.be_interactive)
          {
          DataGrid_control.AllowSorting = false;
          }
        p.be_loaded = true;
        }
      if (DataGrid_control.EditItemIndex > -1)
        {
        //
        // Must rebind to restore the tactical_name and transponder_name columns to their edit-mode TextBox renditions, loaded with the user-supplied values.  Otherwise we can't read those values when the ItemCommand event
        // fires.
        //
        Bind();
        }
      InjectPersistentClientSideScript();
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
        if (instance_id == "ASP.protected_strike_team_deployment_detail_aspx.UserControl_strike_team_deployment_control_strike_team_deployment_binder_control_strike_team_deployment_vehicles")
          {
          p.be_loaded &= ((Session["UserControl_strike_team_deployment_control_UserControl_strike_team_deployment_binder_control_PlaceHolder_content"] as string) == "UserControl_strike_team_deployment_vehicles");
          }
        }
      else
        {
        p.biz_strike_team_deployment_logs = new TClass_biz_strike_team_deployment_logs();
        p.biz_strike_team_deployment_vehicles = new TClass_biz_strike_team_deployment_vehicles();
        p.biz_strike_team_deployments = new TClass_biz_strike_team_deployments();
        p.msg_protected_underway_demobilization = new TClass_msg_protected.underway_demobilization();
        p.msg_protected_vehicle_detail = new TClass_msg_protected.vehicle_detail();
        //
        p.be_interactive = (Session["mode:report"] == null);
        p.be_loaded = false;
        p.be_sort_order_ascending = true;
        p.do_include_all_eligible_vehicles = true;
        p.deployment_id = k.EMPTY;
        p.service_strike_team_management_footprint = k.EMPTY;
        p.sort_order = "service%,name";
        }
      }

    // / <summary>
    // / Required method for Designer support -- do not modify
    // / the contents of this method with the code editor.
    // / </summary>
    private void InitializeComponent()
      {
      this.DataGrid_control.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid_control_ItemDataBound);
      this.DataGrid_control.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.DataGrid_control_SortCommand);
      this.DataGrid_control.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid_control_ItemCommand);
      this.PreRender += this.TWebUserControl_strike_team_deployment_vehicles_PreRender;
      //this.Load += this.Page_Load;
      }

    private void TWebUserControl_strike_team_deployment_vehicles_PreRender(object sender, System.EventArgs e)
      {
      SessionSet(InstanceId() + ".p", p);
      }

    public TWebUserControl_strike_team_deployment_vehicles Fresh()
      {
      Session.Remove(InstanceId() + ".p");
      return this;
      }

    private void DataGrid_control_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
      {
      if (new ArrayList {ListItemType.AlternatingItem, ListItemType.Item, ListItemType.EditItem, ListItemType.SelectedItem}.Contains(e.Item.ItemType))
        {
        var vehicle_id = k.Safe(e.Item.Cells[UserControl_strike_team_deployment_vehicles_Static.TCI_VEHICLE_ID].Text,k.safe_hint_type.NUM);
        if (e.CommandName == "Select")
          {
          p.msg_protected_vehicle_detail.id = vehicle_id;
          p.msg_protected_vehicle_detail.service_id = k.Safe(e.Item.Cells[UserControl_strike_team_deployment_vehicles_Static.TCI_SERVICE_ID].Text,k.safe_hint_type.NUM);
          MessageDropCrumbAndTransferTo(p.msg_protected_vehicle_detail,"protected","vehicle_detail");
          }
        else if (e.CommandName == "ToggleMobilization")
          {
          if (p.biz_strike_team_deployments.BeOkToMakeMobilizationChangesAndQuickMessages(p.deployment_id,p.service_strike_team_management_footprint))
            {
            var id = k.Safe(e.Item.Cells[UserControl_strike_team_deployment_vehicles_Static.TCI_ID].Text,k.safe_hint_type.NUM);
            var static_name = k.EMPTY
            + k.Safe(e.Item.Cells[UserControl_strike_team_deployment_vehicles_Static.TCI_SERVICE].Text,k.safe_hint_type.ORG_NAME).ToUpper()
            + k.SPACE
            + k.Safe(e.Item.Cells[UserControl_strike_team_deployment_vehicles_Static.TCI_NAME].Text,k.safe_hint_type.MAKE_MODEL).ToUpper();
            if (id.Length == 0)
              {
              var tactical_name = k.EMPTY;
              if (p.service_strike_team_management_footprint.Length == 0)
                {
                tactical_name = static_name;
                }
              p.biz_strike_team_deployments.MobilizeVehicle
                (
                deployment_id:p.deployment_id,
                vehicle_id:vehicle_id,
                static_name:static_name,
                tactical_name:tactical_name
                );
              if (p.service_strike_team_management_footprint.Length == 0)
                {
                DataGrid_control.EditItemIndex = e.Item.ItemIndex;
                }
              }
            else
              {
              if (DataGrid_control.EditItemIndex == e.Item.ItemIndex)
                {
                var tactical_name = k.Safe((e.Item.Cells[UserControl_strike_team_deployment_vehicles_Static.TCI_TACTICAL_NAME].Controls[0] as TextBox).Text,k.safe_hint_type.MAKE_MODEL).Trim().ToUpper();
                var saved_tactical_name = k.Safe(e.Item.Cells[UserControl_strike_team_deployment_vehicles_Static.TCI_SAVED_TACTICAL_NAME].Text.Replace("&nbsp;",k.EMPTY),k.safe_hint_type.MAKE_MODEL).Trim().ToUpper();
                var transponder_name = k.Safe((e.Item.Cells[UserControl_strike_team_deployment_vehicles_Static.TCI_TRANSPONDER_NAME].Controls[0] as TextBox).Text,k.safe_hint_type.MAKE_MODEL).Trim().ToUpper();
                var saved_transponder_name = k.Safe(e.Item.Cells[UserControl_strike_team_deployment_vehicles_Static.TCI_SAVED_TRANSPONDER_NAME].Text.Replace("&nbsp;",k.EMPTY),k.safe_hint_type.MAKE_MODEL).Trim().ToUpper();
                var do_continue_editing = false;
                if ((tactical_name != saved_tactical_name) || (transponder_name != saved_transponder_name))
                  {
                  if (!p.biz_strike_team_deployments.AssignVehicleTagTransponder
                      (
                      deployment_id:p.deployment_id,
                      mobilization_id:id,
                      vehicle_id:vehicle_id,
                      static_name:static_name,
                      tactical_name:tactical_name,
                      transponder_name:transponder_name
                      )
                    )
                  //then
                    {
                    Alert
                      (
                      cause:k.alert_cause_type.APPDATA,
                      state:k.alert_state_type.FAILURE,
                      key:"tagtpraryasd",
                      value:"The specified tag OR transponder is already assigned to another vehicle mobilized in this deployment.",
                      be_using_scriptmanager:true
                      );
                    do_continue_editing = true;
                    }
                  }
                if (!do_continue_editing)
                  {
                  DataGrid_control.EditItemIndex = -1;
                  }
                }
              else
                {
                if (!p.do_include_all_eligible_vehicles && (p.service_strike_team_management_footprint.Length == 0))
                  {
                  DataGrid_control.EditItemIndex = e.Item.ItemIndex;
                  }
                else
                  {
                  if(
                      (((e.Item.Cells[UserControl_strike_team_deployment_vehicles_Static.TCI_MOBILIZED].Controls[0]) as LinkButton).Text == "YES")
                    &&
                      (p.biz_strike_team_deployments.BeDemobilizationReasonRequired(p.deployment_id,p.service_strike_team_management_footprint))
                    )
                  // then
                    {
                    p.msg_protected_underway_demobilization.deployment_id = p.deployment_id;
                    p.msg_protected_underway_demobilization.mode = underway_demobilization_mode_enum.VEHICLE;
                    p.msg_protected_underway_demobilization.mobilization_id = id;
                    p.msg_protected_underway_demobilization.asset_designator = static_name;
                    MessageDropCrumbAndTransferTo(p.msg_protected_underway_demobilization,"protected","underway_demobilization");
                    }
                  else
                    {
                    p.biz_strike_team_deployments.DemobilizeVehicle
                      (
                      deployment_id:p.deployment_id,
                      mobilization_id:id,
                      static_name:static_name
                      );
                    }
                  }
                }
              }
            Bind();
            }
          else // changes no longer allowed
            {
            SetRestrictedMode();
            }
          }
        }
      }

    private void DataGrid_control_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
      {
      LinkButton link_button;
      if (p.be_interactive)
        {
        if (new ArrayList {ListItemType.AlternatingItem, ListItemType.Item, ListItemType.EditItem, ListItemType.SelectedItem}.Contains(e.Item.ItemType))
          {
          link_button = ((e.Item.Cells[UserControl_strike_team_deployment_vehicles_Static.TCI_SELECT].Controls[0]) as LinkButton);
          link_button.Text = k.ExpandTildePath(link_button.Text);
          ScriptManager.GetCurrent(Page).RegisterPostBackControl(link_button);
          //
          var be_this_row_in_edit_mode = (DataGrid_control.EditItemIndex == e.Item.ItemIndex);
          link_button = ((e.Item.Cells[UserControl_strike_team_deployment_vehicles_Static.TCI_MOBILIZED].Controls[0]) as LinkButton);
          link_button.Text = (k.Safe(e.Item.Cells[UserControl_strike_team_deployment_vehicles_Static.TCI_ID].Text,k.safe_hint_type.NUM).Length > 0 ? (p.do_include_all_eligible_vehicles || (p.service_strike_team_management_footprint.Length > 0) ? "YES" : "Edit>") : "no");
          link_button.Font.Bold = be_this_row_in_edit_mode;
          if (be_this_row_in_edit_mode)
            {
            link_button.Text = "SAVE>";
            (e.Item.Cells[UserControl_strike_team_deployment_vehicles_Static.TCI_TACTICAL_NAME].Controls[0] as TextBox).Focus();
            }
          if ((link_button.Text == "YES") && (p.biz_strike_team_deployments.BeDemobilizationReasonRequired(p.deployment_id,p.service_strike_team_management_footprint)))
            {
            ToolkitScriptManager.GetCurrent(Page).RegisterPostBackControl(link_button);
            }
          //
          var elaboration = e.Item.Cells[UserControl_strike_team_deployment_vehicles_Static.TCI_ELABORATION].Text;
          if (!new ArrayList() {"&nbsp;",k.EMPTY}.Contains(elaboration))
            {
            e.Item.Cells[UserControl_strike_team_deployment_vehicles_Static.TCI_KIND].ToolTip = elaboration;
            (e.Item.Cells[UserControl_strike_team_deployment_vehicles_Static.TCI_KIND].FindControl("Label_kind") as Label).Attributes.Add("style","border-bottom:2px dotted");
            }
          //
          // Remove all cell controls from viewstate except for the one at TCI_ID.
          //
          foreach (TableCell cell in e.Item.Cells)
            {
            cell.EnableViewState = false;
            }
          e.Item.Cells[UserControl_strike_team_deployment_vehicles_Static.TCI_ID].EnableViewState = true;
          //
          p.num_vehicles++;
          }
        }
      else
        {
        e.Item.Cells[UserControl_strike_team_deployment_vehicles_Static.TCI_SELECT].Visible = false;
        }
      }

    private void DataGrid_control_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
      {
      if (e.SortExpression == p.sort_order)
        {
        p.be_sort_order_ascending = !p.be_sort_order_ascending;
        }
      else
        {
        p.sort_order = k.Safe(e.SortExpression, k.safe_hint_type.KI_SORT_EXPRESSION);
        p.be_sort_order_ascending = true;
        }
      DataGrid_control.EditItemIndex =  -1;
      Bind();
      }

    private void Bind()
      {
      if (!p.biz_strike_team_deployments.BeOkToMakeMobilizationChangesAndQuickMessages(p.deployment_id,p.service_strike_team_management_footprint))
        {
        SetRestrictedMode();
        }
      DataGrid_control.Columns[UserControl_strike_team_deployment_vehicles_Static.TCI_MOBILIZED].HeaderText = (p.do_include_all_eligible_vehicles ? "Mobilized?" : k.EMPTY);
      DataGrid_control.Columns[UserControl_strike_team_deployment_vehicles_Static.TCI_MOBILIZED].HeaderStyle.BackColor = (p.do_include_all_eligible_vehicles ? Color.WhiteSmoke : Color.LightGray);
      DataGrid_control.Columns[UserControl_strike_team_deployment_vehicles_Static.TCI_MOBILIZED].ItemStyle.BackColor = (p.do_include_all_eligible_vehicles ? Color.White : Color.LightGray);
      DataGrid_control.Columns[UserControl_strike_team_deployment_vehicles_Static.TCI_MOBILIZED].Visible = (p.do_include_all_eligible_vehicles || (p.service_strike_team_management_footprint.Length == 0));
      DataGrid_control.Columns[UserControl_strike_team_deployment_vehicles_Static.TCI_TACTICAL_NAME].HeaderStyle.BackColor = (p.do_include_all_eligible_vehicles ? Color.WhiteSmoke : Color.LightGray);
      DataGrid_control.Columns[UserControl_strike_team_deployment_vehicles_Static.TCI_TACTICAL_NAME].ItemStyle.BackColor = (p.do_include_all_eligible_vehicles ? Color.White : Color.LightGray);
      DataGrid_control.Columns[UserControl_strike_team_deployment_vehicles_Static.TCI_TACTICAL_NAME].Visible = (p.service_strike_team_management_footprint.Length == 0);
      DataGrid_control.Columns[UserControl_strike_team_deployment_vehicles_Static.TCI_TRANSPONDER_NAME].HeaderStyle.BackColor = (p.do_include_all_eligible_vehicles ? Color.WhiteSmoke : Color.LightGray);
      DataGrid_control.Columns[UserControl_strike_team_deployment_vehicles_Static.TCI_TRANSPONDER_NAME].ItemStyle.BackColor = (p.do_include_all_eligible_vehicles ? Color.White : Color.LightGray);
      DataGrid_control.Columns[UserControl_strike_team_deployment_vehicles_Static.TCI_TRANSPONDER_NAME].Visible = (p.service_strike_team_management_footprint.Length == 0);
      p.biz_strike_team_deployment_vehicles.BindBaseDataList
        (
        sort_order:p.sort_order,
        be_sort_order_ascending:p.be_sort_order_ascending,
        target:DataGrid_control,
        deployment_id:p.deployment_id,
        do_include_all_eligible_vehicles:p.do_include_all_eligible_vehicles,
        service_strike_team_management_footprint:p.service_strike_team_management_footprint
        );
      p.be_datagrid_empty = (p.num_vehicles == 0);
      TableRow_none.Visible = p.be_datagrid_empty;
      DataGrid_control.Visible = !p.be_datagrid_empty;
      Literal_num_vehicles.Text = p.num_vehicles.ToString();
      p.num_vehicles = 0;
      }

    private void SetRestrictedMode()
      {
      TableRow_operational_period_started.Visible = true;
      CheckBox_do_include_all_eligible_vehicles.Checked = false;
      p.do_include_all_eligible_vehicles = false;
      Td_filter.Visible = false;
      }

    protected void CheckBox_do_include_all_eligible_vehicles_CheckedChanged(object sender, EventArgs e)
      {
      p.do_include_all_eligible_vehicles = CheckBox_do_include_all_eligible_vehicles.Checked;
      DataGrid_control.EditItemIndex =  -1;
      Bind();
      }

    internal void Set
      (
      string deployment_id,
      string service_strike_team_management_footprint,
      bool be_ok_to_config_strike_team_deployments
      )
      {
      if(
          ((Session["UserControl_strike_team_deployment_control_UserControl_strike_team_deployment_binder_control_PlaceHolder_content"] as string) != "UserControl_strike_team_deployment_vehicles")
        ||
          (deployment_id != p.deployment_id)
        )
      //then
        {
        p.do_include_all_eligible_vehicles = !p.biz_strike_team_deployments.BeAnyOperationalPeriodStartedFor(deployment_id:deployment_id);
        }
      CheckBox_do_include_all_eligible_vehicles.Checked = p.do_include_all_eligible_vehicles;
      p.deployment_id = deployment_id;
      p.service_strike_team_management_footprint = service_strike_team_management_footprint;
      //
      if (be_ok_to_config_strike_team_deployments)
        {
        Td_for_iap.Visible = true;
        HyperLink_for_iap.Text = k.ExpandTildePath(HyperLink_for_iap.Text);
        var hash_table = new Hashtable();
        hash_table.Add(key:"vehicles_deployment_id",value:p.deployment_id);
        HyperLink_for_iap.NavigateUrl += ShieldedQueryStringOfHashtable(hash_table);
        }
      //
      Bind();
      }

    } // end TWebUserControl_strike_team_deployment_vehicles

  }