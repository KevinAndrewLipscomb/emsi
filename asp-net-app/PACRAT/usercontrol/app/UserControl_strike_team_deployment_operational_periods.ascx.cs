// Derived from KiAspdotnetFramework/UserControl/app/UserControl~template~datagrid~sortable.ascx.cs

using Class_biz_members;
using Class_biz_privileges;
using Class_biz_user;
using Class_biz_strike_team_deployment_operational_periods;
using Class_biz_strike_team_deployments;
using Class_msg_protected;
using kix;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Collections;
using AjaxControlToolkit;

namespace UserControl_strike_team_deployment_operational_periods
  {
  public partial class TWebUserControl_strike_team_deployment_operational_periods: ki_web_ui.usercontrol_class
    {
    public class UserControl_strike_team_deployment_operational_periods_Static
      {
      public const string NOT_APPLICABLE_INDICATION_HTML = "-&nbsp;-&nbsp;-";
      //
      public const int TCI_SELECT = 0;
      public const int TCI_ID = 1;
      public const int TCI_KIND = 2;
      public const int TCI_PRELIM_NAME = 3;
      public const int TCI_START = 4;
      public const int TCI_END = 5;
      public const int TCI_BE_CONVOY = 6;
      public const int TCI_FOR_IAP = 7;
      }

    private struct p_type
      {
      public bool be_datagrid_empty;
      public bool be_interactive;
      public bool be_loaded;
      public bool be_unlimited;
      public bool be_sort_order_ascending;
      public TClass_biz_members biz_members;
      public TClass_biz_privileges biz_privileges;
      public TClass_biz_strike_team_deployment_operational_periods biz_strike_team_deployment_operational_periods;
      public TClass_biz_strike_team_deployments biz_strike_team_deployments;
      public TClass_biz_user biz_user;
      public string deployment_id;
      public TClass_msg_protected.operational_period_detail msg_protected_operational_period_detail;
      public uint num_operational_periods;
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
        Bind();
        p.be_loaded = true;
        }
      ToolkitScriptManager.GetCurrent(Page).RegisterPostBackControl(LinkButton_new);
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
        if (instance_id == "ASP.protected_strike_team_deployment_detail_aspx.UserControl_strike_team_deployment_control_strike_team_deployment_binder_control_strike_team_deployment_operational_periods")
          {
          p.be_loaded &= ((Session["UserControl_strike_team_deployment_control_UserControl_strike_team_deployment_binder_control_PlaceHolder_content"] as string) == "UserControl_strike_team_deployment_operational_periods");
          }
        }
      else
        {
        p.biz_members = new TClass_biz_members();
        p.biz_privileges = new TClass_biz_privileges();
        p.biz_strike_team_deployment_operational_periods = new TClass_biz_strike_team_deployment_operational_periods();
        p.biz_strike_team_deployments = new TClass_biz_strike_team_deployments();
        p.biz_user = new TClass_biz_user();
        p.msg_protected_operational_period_detail = new TClass_msg_protected.operational_period_detail();
        //
        p.be_interactive = (Session["mode:report"] == null);
        p.be_loaded = false;
        p.be_unlimited = false;
        p.be_sort_order_ascending = true;
        p.deployment_id = k.EMPTY;
        p.service_strike_team_management_footprint = k.EMPTY;
        p.sort_order = "start%,end";
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
      this.PreRender += this.TWebUserControl_operational_periods_PreRender;
      //this.Load += this.Page_Load;
      }

    private void TWebUserControl_operational_periods_PreRender(object sender, System.EventArgs e)
      {
      SessionSet(InstanceId() + ".p", p);
      }

    public TWebUserControl_strike_team_deployment_operational_periods Fresh()
      {
      Session.Remove(InstanceId() + ".p");
      return this;
      }

    private void DataGrid_control_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
      {
      if (new ArrayList {ListItemType.AlternatingItem, ListItemType.Item, ListItemType.EditItem, ListItemType.SelectedItem}.Contains(e.Item.ItemType))
        {
        p.msg_protected_operational_period_detail.operational_period_id = k.Safe(e.Item.Cells[UserControl_strike_team_deployment_operational_periods_Static.TCI_ID].Text,k.safe_hint_type.NUM);
        p.msg_protected_operational_period_detail.deployment_id = p.deployment_id;
        p.msg_protected_operational_period_detail.service_strike_team_management_footprint = p.service_strike_team_management_footprint;
        p.msg_protected_operational_period_detail.be_unlimited = p.be_unlimited;
        MessageDropCrumbAndTransferTo(p.msg_protected_operational_period_detail,"protected","operational_period_detail");
        }
      }

    private void DataGrid_control_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
      {
      LinkButton link_button;
      if (p.be_interactive)
        {
        if (new ArrayList {ListItemType.AlternatingItem, ListItemType.Item, ListItemType.EditItem, ListItemType.SelectedItem}.Contains(e.Item.ItemType))
          {
          link_button = ((e.Item.Cells[UserControl_strike_team_deployment_operational_periods_Static.TCI_SELECT].Controls[0]) as LinkButton);
          link_button.Text = k.ExpandTildePath(link_button.Text);
          ScriptManager.GetCurrent(Page).RegisterPostBackControl(link_button);
          //
          var kind = p.biz_strike_team_deployment_operational_periods.KindOf
            (
            start:e.Item.Cells[UserControl_strike_team_deployment_operational_periods_Static.TCI_START].Text.Replace("&nbsp;",k.EMPTY),
            end:e.Item.Cells[UserControl_strike_team_deployment_operational_periods_Static.TCI_END].Text.Replace("&nbsp;",k.EMPTY),
            be_convoy:e.Item.Cells[UserControl_strike_team_deployment_operational_periods_Static.TCI_BE_CONVOY].Text,
            prelim_shift_name:e.Item.Cells[UserControl_strike_team_deployment_operational_periods_Static.TCI_PRELIM_NAME].Text.Replace("&nbsp;",k.EMPTY)
            );
          e.Item.Cells[UserControl_strike_team_deployment_operational_periods_Static.TCI_KIND].Text = kind.ToString();
          if (kind == kind_enum.PRELIM)
            {
            e.Item.Cells[UserControl_strike_team_deployment_operational_periods_Static.TCI_START].Text = UserControl_strike_team_deployment_operational_periods_Static.NOT_APPLICABLE_INDICATION_HTML;
            e.Item.Cells[UserControl_strike_team_deployment_operational_periods_Static.TCI_END].Text = UserControl_strike_team_deployment_operational_periods_Static.NOT_APPLICABLE_INDICATION_HTML;
            e.Item.Cells[UserControl_strike_team_deployment_operational_periods_Static.TCI_FOR_IAP].Controls.Clear();
            e.Item.Cells[UserControl_strike_team_deployment_operational_periods_Static.TCI_FOR_IAP].Text = UserControl_strike_team_deployment_operational_periods_Static.NOT_APPLICABLE_INDICATION_HTML;
            }
          else
            {
            e.Item.Cells[UserControl_strike_team_deployment_operational_periods_Static.TCI_PRELIM_NAME].Text = UserControl_strike_team_deployment_operational_periods_Static.NOT_APPLICABLE_INDICATION_HTML;
            //
            var hash_table = new Hashtable();
            hash_table.Add(key:"operational_period_id",value:e.Item.Cells[UserControl_strike_team_deployment_operational_periods_Static.TCI_ID].Text);
            ((e.Item.Cells[UserControl_strike_team_deployment_operational_periods_Static.TCI_FOR_IAP].Controls[0]) as HyperLink).NavigateUrl += ShieldedQueryStringOfHashtable(hash_table);
            }
          //
          // Remove all cell controls from viewstate except for the one at TCI_ID.
          //
          foreach (TableCell cell in e.Item.Cells)
            {
            cell.EnableViewState = false;
            }
          e.Item.Cells[UserControl_strike_team_deployment_operational_periods_Static.TCI_ID].EnableViewState = true;
          //
          p.num_operational_periods++;
          }
        }
      else
        {
        e.Item.Cells[UserControl_strike_team_deployment_operational_periods_Static.TCI_SELECT].Visible = false;
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
      p.biz_strike_team_deployment_operational_periods.BindBaseDataList
        (
        sort_order:p.sort_order,
        be_sort_order_ascending:p.be_sort_order_ascending,
        target:DataGrid_control,
        deployment_id:p.deployment_id,
        be_unlimited:p.be_unlimited
        );
      p.be_datagrid_empty = (p.num_operational_periods == 0);
      TableRow_none.Visible = p.be_datagrid_empty;
      DataGrid_control.Visible = !p.be_datagrid_empty;
      Literal_num_operational_periods.Text = p.num_operational_periods.ToString();
      p.num_operational_periods = 0;
      }

    protected void LinkButton_new_Click(object sender, EventArgs e)
    {
    p.msg_protected_operational_period_detail.operational_period_id = k.EMPTY;
    p.msg_protected_operational_period_detail.deployment_id = p.deployment_id;
    p.msg_protected_operational_period_detail.service_strike_team_management_footprint = p.service_strike_team_management_footprint;
    p.msg_protected_operational_period_detail.be_unlimited = p.be_unlimited;
    MessageDropCrumbAndTransferTo
      (
      msg:p.msg_protected_operational_period_detail,
      folder_name:"protected",
      aspx_name:"operational_period_detail"
      );
    }

    internal void Set
      (
      string deployment_id,
      string service_strike_team_management_footprint,
      bool be_unlimited
      )
      {
      p.deployment_id = deployment_id;
      p.service_strike_team_management_footprint = service_strike_team_management_footprint;
      p.be_unlimited = be_unlimited;
      //
      var be_mobilizing = p.biz_strike_team_deployments.BeDemobilizationReasonRequired
        (
        deployment_id:p.deployment_id,
        service_strike_team_management_footprint:k.EMPTY
        );
      TableRow_initial_actions.Visible = p.be_unlimited && !be_mobilizing;
      TableRow_service_actions.Visible = !p.be_unlimited && !be_mobilizing;
      LinkButton_new.Visible = p.be_unlimited;
      DataGrid_control.Columns[UserControl_strike_team_deployment_operational_periods_Static.TCI_START].Visible = p.be_unlimited;
      DataGrid_control.Columns[UserControl_strike_team_deployment_operational_periods_Static.TCI_END].Visible = p.be_unlimited;
      DataGrid_control.Columns[UserControl_strike_team_deployment_operational_periods_Static.TCI_FOR_IAP].Visible = p.be_unlimited;
      Bind();
      }

    } // end TWebUserControl_operational_periods

  }