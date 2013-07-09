using Class_biz_strike_team_deployment_assignments;
using Class_biz_strike_team_deployment_members;
using Class_biz_strike_team_deployment_vehicles;
using Class_biz_user;
using kix;
using System.Collections;
using System.Web.UI.WebControls;

namespace UserControl_operational_period_detail
  {

  public static class UserControl_operational_period_detail_Static
    {
    public const int CI_UNMAP = 0;
    public const int CI_VEHICLE_ID = 1;
    public const int CI_VEHICLE = 2;
    public const int CI_MEMBER_DESIGNATOR = 3;
    public const int CI_MEMBER_ID = 4;
    public const string INITIAL_SORT_ORDER = "vehicle_designator%,member_designator";
    }

  public partial class TWebUserControl_operational_period_detail: ki_web_ui.usercontrol_class
    {

    //--
    //
    // PRIVATE
    //
    //--

    private struct p_type
      {
      public string assignment_level_filter;
      public bool be_interactive;
      public bool be_loaded;
      public bool be_sort_order_ascending;
      public TClass_biz_strike_team_deployment_members biz_strike_team_deployment_members;
      public TClass_biz_strike_team_deployment_assignments biz_strike_team_deployment_assignments;
      public TClass_biz_strike_team_deployment_vehicles biz_strike_team_deployment_vehicles;
      public TClass_biz_user biz_user;
      public string deployment_id;
      public bool may_add_mappings;
      public string operational_period_id;
      public string sort_order;
      }

    private p_type p;

    private void Bind()
      {
      DataGrid_control.Columns[UserControl_operational_period_detail_Static.CI_UNMAP].Visible = p.be_interactive;
      p.biz_strike_team_deployment_assignments.BindActuals
        (
        sort_order:p.sort_order,
        be_sort_order_ascending:p.be_sort_order_ascending,
        target:DataGrid_control,
        operational_period_id:p.operational_period_id,
        assignment_level_filter:p.assignment_level_filter
        );
      TableCell_add_mapping.Visible = p.may_add_mappings;
      if (TableCell_add_mapping.Visible)
        {
        p.biz_strike_team_deployment_vehicles.BindDirectToListControl
          (
          target:DropDownList_vehicle,
          deployment_id:p.deployment_id
          );
        DropDownList_vehicle.Items.Insert(index:0,item:new ListItem(text:"(none)",value:"0"));
        DropDownList_vehicle.Items.Insert(index:0,item:new ListItem(text:"-- Vehicle -- ",value:k.EMPTY));
        p.biz_strike_team_deployment_members.BindUnassignedInOperationalPeriodDirectToListControl
          (
          target:DropDownList_member,
          deployment_id:p.deployment_id,
          operational_period_id:p.operational_period_id
          );
        DropDownList_member.Items.Insert(index:0,item:new ListItem(text:"-- Member -- ",value:k.EMPTY));
        }
      }

    protected void DataGrid_control_DeleteCommand(object source, DataGridCommandEventArgs e)
      {
      p.biz_strike_team_deployment_assignments.Save
        (
        operational_period_id:p.operational_period_id,
        member_id:k.Safe(e.Item.Cells[UserControl_operational_period_detail_Static.CI_MEMBER_ID].Text, k.safe_hint_type.NUM),
        vehicle_id:k.Safe(e.Item.Cells[UserControl_operational_period_detail_Static.CI_VEHICLE_ID].Text, k.safe_hint_type.NUM),
        be_assigned:false
        );
      Bind();
      }

    protected void DataGrid_control_ItemDataBound(object sender, DataGridItemEventArgs e)
      {
      if (new ArrayList {ListItemType.AlternatingItem, ListItemType.Item, ListItemType.EditItem, ListItemType.SelectedItem}.Contains(e.Item.ItemType))
        {
        LinkButton link_button;
        //
        link_button = ((e.Item.Cells[UserControl_operational_period_detail_Static.CI_UNMAP].Controls[0]) as LinkButton);
        link_button.Text = k.ExpandTildePath(link_button.Text);
        link_button.ToolTip = "Unmap";
        //
        // Remove all cell controls from viewstate except for the ones at ID fields.
        //
        foreach (TableCell cell in e.Item.Cells)
          {
          cell.EnableViewState = false;
          }
        e.Item.Cells[UserControl_operational_period_detail_Static.CI_VEHICLE_ID].EnableViewState = true;
        e.Item.Cells[UserControl_operational_period_detail_Static.CI_MEMBER_ID].EnableViewState = true;
        }
      }

    protected void DataGrid_control_SortCommand(object source, DataGridSortCommandEventArgs e)
      {
      if (e.SortExpression == p.sort_order)
        {
        p.be_sort_order_ascending = !p.be_sort_order_ascending;
        }
      else
        {
        p.sort_order = e.SortExpression;
        p.be_sort_order_ascending = true;
        }
      DataGrid_control.EditItemIndex =  -1;
      Bind();
      }

    // / <summary>
    // / Required method for Designer support -- do not modify
    // / the contents of this method with the code editor.
    // / </summary>
    private void InitializeComponent()
      {
      PreRender += TWebUserControl_operational_period_detail_PreRender;
      }

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

    private void TWebUserControl_operational_period_detail_PreRender(object sender, System.EventArgs e)
      {
      SessionSet(InstanceId() + ".p", p);
      }

    //--
    //
    // PROTECTED
    //
    //--

    protected void Button_add_Click(object sender, System.EventArgs e)
      {
      p.biz_strike_team_deployment_assignments.Save
        (
        operational_period_id:p.operational_period_id,
        member_id:k.Safe(DropDownList_member.SelectedValue, k.safe_hint_type.NUM),
        vehicle_id:k.Safe(DropDownList_vehicle.SelectedValue, k.safe_hint_type.NUM),
        be_assigned:true
        );
      Bind();
      }

    protected void DropDownList_assignment_level_filter_SelectedIndexChanged(object sender, System.EventArgs e)
      {
      p.assignment_level_filter = k.Safe(DropDownList_assignment_level_filter.SelectedValue, k.safe_hint_type.NUM);
      p.sort_order = UserControl_operational_period_detail_Static.INITIAL_SORT_ORDER;
      p.be_sort_order_ascending = true;
      Bind();
      }

    protected override void OnInit(System.EventArgs e)
      {
      // Required for Designer support
      InitializeComponent();
      base.OnInit(e);
      if (Session[InstanceId() + ".p"] != null)
        {
        p = (p_type)(Session[InstanceId() + ".p"]);
        p.be_loaded = IsPostBack;
        }
      else
        {
        p.biz_strike_team_deployment_assignments = new TClass_biz_strike_team_deployment_assignments();
        p.biz_strike_team_deployment_members = new TClass_biz_strike_team_deployment_members();
        p.biz_strike_team_deployment_vehicles = new TClass_biz_strike_team_deployment_vehicles();
        p.biz_user = new TClass_biz_user();
        //
        p.assignment_level_filter = k.EMPTY;
        p.be_interactive = !(Session["mode:report"] != null);
        p.be_loaded = false;
        p.be_sort_order_ascending = true;
        p.deployment_id = k.EMPTY;
        p.may_add_mappings = p.be_interactive;
        p.operational_period_id = k.EMPTY;
        p.sort_order = UserControl_operational_period_detail_Static.INITIAL_SORT_ORDER;
        }
      }

    protected void Page_Load(object sender, System.EventArgs e)
      {
      if (!p.be_loaded)
        {
        DataGrid_control.AllowSorting = p.be_interactive;
        Bind();
        p.be_loaded = true;
        }
      InjectPersistentClientSideScript();
      }

    //--
    //
    // INTERNAL
    //
    //--

    internal TWebUserControl_operational_period_detail Fresh()
      {
      Session.Remove(InstanceId() + ".p");
      return this;
      }

    internal void Set
      (
      string deployment_id,
      string operational_period_id
      )
      {
      p.deployment_id = deployment_id;
      p.operational_period_id = operational_period_id;
      Bind();
      }

    }

  }
