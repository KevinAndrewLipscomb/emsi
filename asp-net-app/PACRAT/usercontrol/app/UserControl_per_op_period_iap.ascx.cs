// Derived from KiAspdotnetFramework/UserControl/app/UserControl~template~datagrid~sortable.ascx.cs

using Class_biz_members;
using Class_biz_patient_care_levels;
using Class_biz_practitioners;
using Class_biz_strike_team_deployment_assignments;
using Class_biz_strike_team_deployment_operational_periods;
using Class_biz_strike_team_deployments;
using Class_biz_user;
using kix;
using System;
using System.Collections;
using System.Configuration;
using System.Web.UI.WebControls;

namespace UserControl_per_op_period_iap
  {
  public partial class TWebUserControl_per_op_period_iap: ki_web_ui.usercontrol_class
    {
    public static class UserControl_per_op_period_iap_Static
      {
      public const int CI_VEHICLE = 0;
      public const int CI_VEHICLE_PATIENT_CARE_LEVEL_ID = 1;
      public const int CI_MAX_PRACTITIONER_LEVEL_PECKING_ORDER = 2;
      public const int CI_EFFECTIVE_PATIENT_CARE_LEVEL = 3;
      public const int CI_KIND = 4;
      public const int CI_LEADER = 5;
      public const int CI_PAR = 6;
      public const int CI_LEADER_PHONE_NUM= 7;
      }

    private struct p_type
      {
      public bool be_datagrid_empty;
      public bool be_interactive;
      public bool be_loaded;
      public bool be_sort_order_ascending;
      public TClass_biz_members biz_members;
      public TClass_biz_practitioners biz_practitioners;
      public TClass_biz_patient_care_levels biz_patient_care_levels;
      public TClass_biz_strike_team_deployment_assignments biz_strike_team_deployment_assignments;
      public TClass_biz_strike_team_deployment_operational_periods biz_strike_team_deployment_operational_periods;
      public TClass_biz_strike_team_deployments biz_strike_team_deployments;
      public TClass_biz_user biz_user;
      public k.int_nonnegative num_items;
      public string operational_period_id;
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
        var mark = DateTime.Now;
        Literal_application_name.Text = ConfigurationManager.AppSettings["application_name"];
        Literal_ref_num.Text = mark.ToString("yyyy-MM-dd-HH-mm-ss-ff");
        Bind();
        var practitioner_summary = p.biz_practitioners.Summary(p.biz_members.IdOfUserId(p.biz_user.IdNum()));
        Literal_prepared_name.Text = k.EMPTY
        + p.biz_practitioners.LevelOf(practitioner_summary)
        + k.SPACE
        + p.biz_practitioners.FirstNameOf(practitioner_summary)
        + k.SPACE
        + p.biz_practitioners.LastNameOf(practitioner_summary)
        + k.SPACE
        + "(" + p.biz_practitioners.CertificationNumberOf(practitioner_summary) + ")";
        Literal_prepared_timestamp.Text = mark.ToString("yyyy-MM-dd HH:mm:ss.ff");
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
//        //
//        // If this control is being used dynamically under one or more parent binder(s), it must ascertain which instance it is, and whether or not that instance's parent binder
//        // had it loaded already.
//        //
//#warning Revise the binder-related instance_id to this control appropriately.
//        if (instance_id == "ASP.protected_overview_aspx.UserControl_member_binder_per_op_period_iap")
//          {
//#warning Revise the ClientID path to this control appropriately.
//          p.be_loaded &= ((Session["UserControl_member_binder_PlaceHolder_content"] as string) == "UserControl_per_op_period_iap");
//          }
//      else if (instance_id == "ASP.~_aspx.UserControl_~_binder_per_op_period_iap")
//        {
//        p.be_loaded &= ((Session["UserControl_~_binder_PlaceHolder_content"] as string) == "UserControl_per_op_period_iap");
//        }
        }
      else
        {
        p.biz_members = new TClass_biz_members();
        p.biz_patient_care_levels = new TClass_biz_patient_care_levels();
        p.biz_practitioners = new TClass_biz_practitioners();
        p.biz_strike_team_deployment_assignments = new TClass_biz_strike_team_deployment_assignments();
        p.biz_strike_team_deployment_operational_periods = new TClass_biz_strike_team_deployment_operational_periods();
        p.biz_strike_team_deployments = new TClass_biz_strike_team_deployments();
        p.biz_user = new TClass_biz_user();
        //
        p.be_interactive = (Session["mode:report"] == null);
        p.be_loaded = false;
        p.be_sort_order_ascending = true;
        p.num_items = new k.int_nonnegative();
        p.sort_order = "vehicle_designator%";
        }
      }

    // / <summary>
    // / Required method for Designer support -- do not modify
    // / the contents of this method with the code editor.
    // / </summary>
    private void InitializeComponent()
      {
      this.DataGrid_control.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid_control_ItemDataBound);
      this.PreRender += this.TWebUserControl_per_op_period_iap_PreRender;
      //this.Load += this.Page_Load;
      }

    private void TWebUserControl_per_op_period_iap_PreRender(object sender, System.EventArgs e)
      {
      SessionSet(InstanceId() + ".p", p);
      }

    public TWebUserControl_per_op_period_iap Fresh()
      {
      Session.Remove(InstanceId() + ".p");
      return this;
      }

    private void DataGrid_control_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
      {
      if (new ArrayList {ListItemType.AlternatingItem, ListItemType.Item, ListItemType.EditItem, ListItemType.SelectedItem}.Contains(e.Item.ItemType))
        {
        e.Item.Cells[UserControl_per_op_period_iap_Static.CI_EFFECTIVE_PATIENT_CARE_LEVEL].Text = p.biz_patient_care_levels.EffectiveOf
          (
          vehicle_patient_care_level_description:k.Safe(e.Item.Cells[UserControl_per_op_period_iap_Static.CI_VEHICLE_PATIENT_CARE_LEVEL_ID].Text,k.safe_hint_type.HYPHENATED_ALPHA),
          practitioner_level_short_description:k.Safe(e.Item.Cells[UserControl_per_op_period_iap_Static.CI_MAX_PRACTITIONER_LEVEL_PECKING_ORDER].Text,k.safe_hint_type.HYPHENATED_ALPHA)
          );
        //
        e.Item.Cells[UserControl_per_op_period_iap_Static.CI_LEADER_PHONE_NUM].Text = k.FormatAsNanpPhoneNum(e.Item.Cells[UserControl_per_op_period_iap_Static.CI_LEADER_PHONE_NUM].Text);
        //
        p.num_items.val++;
        }
      }

    private void Bind()
      {
      p.biz_strike_team_deployment_assignments.BindDigestByOperationalPeriod
        (
        sort_order:p.sort_order,
        be_sort_order_ascending:p.be_sort_order_ascending,
        target:DataGrid_control,
        operational_period_id:p.operational_period_id
        );
      p.be_datagrid_empty = (p.num_items.val == 0);
      TableRow_none.Visible = p.be_datagrid_empty;
      TableRow_control.Visible = !p.be_datagrid_empty;
      p.num_items.val = 0;
      }

    internal void Set(string operational_period_id)
      {
      p.operational_period_id = operational_period_id;
      //
      var be_convoy = false;
      var deployment_id = k.EMPTY;
      DateTime start;
      DateTime end;
      p.biz_strike_team_deployment_operational_periods.Get
        (
        id:operational_period_id,
        deployment_id:out deployment_id,
        start:out start,
        end:out end,
        be_convoy:out be_convoy
        );
      Literal_deployment_name.Text = p.biz_strike_team_deployments.NameOfId(deployment_id);
      Literal_nature.Text = (be_convoy ? "CONVOY" : "OPERATIONAL PERIOD");
      Literal_start.Text = start.ToString("MM/dd/yyyy HH:mm");
      Literal_end.Text = end.ToString("MM/dd/yyyy HH:mm");
      Bind();
      }

    } // end TWebUserControl_per_op_period_iap

  }