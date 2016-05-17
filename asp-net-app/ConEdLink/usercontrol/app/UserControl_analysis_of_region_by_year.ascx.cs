// Derived from KiAspdotnetFramework/UserControl/app/UserControl~template~datagrid~sortable.ascx.cs

using Class_biz_coned_offering_rosters;
using Class_biz_old_analysis_of_region_by_years;
using Class_biz_practitioner_levels;
using kix;
using System;
using System.Collections;
using System.Web.UI.WebControls;

namespace UserControl_analysis_of_region_by_year
  {
  public partial class TWebUserControl_analysis_of_region_by_year: ki_web_ui.usercontrol_class
    {

    private static class Static
      {
      public const int TCI_FISCAL_YEAR_ENDING = 0;
      public const int TCI_NUM_CLASSES = 1;
      public const int TCI_NUM_SITTINGS = 2;
      public const int TCI_AVG_NUM_STUDENTS_PER_CLASS = 3;
      public const int TCI_NUM_DISTINCT_PRACTITIONERS = 4;
      }

    private struct p_type
      {
      public bool be_datagrid_empty;
      public bool be_interactive;
      public bool be_loaded;
      public bool be_sort_order_ascending;
      public TClass_biz_coned_offering_rosters biz_coned_offering_rosters;
      public TClass_biz_old_analysis_of_region_by_years biz_old_analysis_of_region_by_years;
      public TClass_biz_practitioner_levels biz_practitioner_levels;
      public uint num_fiscal_years;
      public string practitioner_level_filter;
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
        p.biz_practitioner_levels.BindDirectToListControl
          (
          target:DropDownList_practitioner_level,
          unselected_literal:"(All)"
          );
        //
        Bind();
        //
        p.be_loaded = true;
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
        if (instance_id == "ASP.protected_overview_aspx.UserControl_regional_staffer_binder_analysis_of_region_binder_analysis_of_region_by_year")
          {
          p.be_loaded &= ((Session["UserControl_regional_staffer_binder_UserControl_analysis_of_region_binder_PlaceHolder_content"] as string) == "UserControl_analysis_of_region_by_year");
          }
        }
      else
        {
        p.biz_coned_offering_rosters = new TClass_biz_coned_offering_rosters();
        p.biz_old_analysis_of_region_by_years = new TClass_biz_old_analysis_of_region_by_years();
        p.biz_practitioner_levels = new TClass_biz_practitioner_levels();
        //
        p.be_interactive = (Session["mode:report"] == null);
        p.be_loaded = false;
        p.be_sort_order_ascending = true;
        p.practitioner_level_filter = k.EMPTY;
        p.sort_order = "fiscal_year_ending desc";
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
      this.PreRender += this.TWebUserControl_analysis_of_region_by_year_PreRender;
      }

    private void TWebUserControl_analysis_of_region_by_year_PreRender(object sender, System.EventArgs e)
      {
      SessionSet(InstanceId() + ".p", p);
      }

    public TWebUserControl_analysis_of_region_by_year Fresh()
      {
      Session.Remove(InstanceId() + ".p");
      return this;
      }

    private void DataGrid_control_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
      {
      if (p.be_interactive)
        {
        if (new ArrayList {ListItemType.AlternatingItem, ListItemType.Item, ListItemType.EditItem, ListItemType.SelectedItem}.Contains(e.Item.ItemType))
          {
          //
          // Remove all cell controls from viewstate except for the one at TCI_ID.
          //
          foreach (TableCell cell in e.Item.Cells)
            {
            cell.EnableViewState = false;
            }
          //
          p.num_fiscal_years++;
          }
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
      var fiscal_year_ending = k.EMPTY;
      var num_classes = k.EMPTY;
      var num_sittings = k.EMPTY;
      var avg_num_students_per_class = k.EMPTY;
      var num_distinct_practitioners = k.EMPTY;
      //
      fiscal_year_ending = DateTime.Today.AddMonths(6).Year.ToString();
      p.biz_coned_offering_rosters.GetAnalysisOfRegionByYear
        (
        year:fiscal_year_ending,
        region_code:Session["region_code"].ToString(),
        practitioner_level_filter:p.practitioner_level_filter,
        num_classes:out num_classes,
        num_sittings:out num_sittings,
        avg_num_students_per_class:out avg_num_students_per_class,
        num_distinct_practitioners:out num_distinct_practitioners
        );
      Literal_current_fiscal_year_ending.Text = fiscal_year_ending;
      Literal_current_num_classes.Text = num_classes;
      Literal_current_num_sittings.Text = num_sittings;
      Literal_current_avg_num_students_per_class.Text = avg_num_students_per_class;
      Literal_current_num_distinct_practitioners.Text = num_distinct_practitioners;
      //
      TableRow_prior_unreduced.Visible = (DateTime.Today.Month > 6);
      if (TableRow_prior_unreduced.Visible)
        {
        fiscal_year_ending = DateTime.Today.Year.ToString();
        p.biz_coned_offering_rosters.GetAnalysisOfRegionByYear
          (
          year:fiscal_year_ending,
          region_code:Session["region_code"].ToString(),
          practitioner_level_filter:p.practitioner_level_filter,
          num_classes:out num_classes,
          num_sittings:out num_sittings,
          avg_num_students_per_class:out avg_num_students_per_class,
          num_distinct_practitioners:out num_distinct_practitioners
          );
        Literal_prior_unreduced_fiscal_year_ending.Text = fiscal_year_ending;
        Literal_prior_unreduced_num_classes.Text = num_classes;
        Literal_prior_unreduced_num_sittings.Text = num_sittings;
        Literal_prior_unreduced_avg_num_students_per_class.Text = avg_num_students_per_class;
        Literal_prior_unreduced_num_distinct_practitioners.Text = num_distinct_practitioners;
        }
      //
      p.biz_old_analysis_of_region_by_years.BindBaseDataList
        (
        sort_order:p.sort_order,
        be_sort_order_ascending:p.be_sort_order_ascending,
        target:DataGrid_control,
        region_code:Session["region_code"].ToString(),
        practitioner_level_filter:p.practitioner_level_filter
        );
      p.be_datagrid_empty = (p.num_fiscal_years == 0);
      DataGrid_control.Visible = !p.be_datagrid_empty;
      p.num_fiscal_years = 0;
      }

    protected void DropDownList_practitioner_level_SelectedIndexChanged(object sender, EventArgs e)
      {
      p.practitioner_level_filter = k.Safe(DropDownList_practitioner_level.SelectedValue,k.safe_hint_type.NUM);
      Bind();
      }

    } // end TWebUserControl_analysis_of_region_by_year

  }