using AjaxControlToolkit;
using Class_biz_members;
using Class_biz_patient_care_levels;
using Class_biz_practitioner_strike_team_details;
using Class_biz_strike_team_deployment_assignments;
using Class_biz_strike_team_deployment_members;
using Class_biz_strike_team_deployment_vehicles;
using Class_biz_user;
using kix;
using System;
using System.Collections;
using System.Configuration;
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
    public const int DIGEST_CI_SELECT_FOR_QUICKMESSAGE = 0;
    public const int DIGEST_CI_VEHICLE = 1;
    public const int DIGEST_CI_VEHICLE_PATIENT_CARE_LEVEL_ID = 2;
    public const int DIGEST_CI_MAX_PRACTITIONER_LEVEL_PECKING_ORDER = 3;
    public const int DIGEST_CI_EFFECTIVE_PATIENT_CARE_LEVEL = 4;
    public const int DIGEST_CI_KIND = 5;
    public const int DIGEST_CI_PAR = 6;
    public const int DIGEST_CI_SMS_TARGET = 7;
    public const string INITIAL_DIGEST_SORT_ORDER = "vehicle_designator%";
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
      public bool be_datagrid_empty;
      public bool be_digest_empty;
      public bool be_interactive;
      public bool be_loaded;
      public bool be_digest_sort_order_ascending;
      public bool be_sort_order_ascending;
      public TClass_biz_members biz_members;
      public TClass_biz_patient_care_levels biz_patient_care_levels;
      public TClass_biz_practitioner_strike_team_details biz_practitioner_strike_team_details;
      public TClass_biz_strike_team_deployment_members biz_strike_team_deployment_members;
      public TClass_biz_strike_team_deployment_assignments biz_strike_team_deployment_assignments;
      public TClass_biz_strike_team_deployment_vehicles biz_strike_team_deployment_vehicles;
      public TClass_biz_user biz_user;
      public string deployment_id;
      public string digest_sort_order;
      public string distribution_list_email;
      public string distribution_list_sms;
      public bool may_add_mappings;
      public k.int_nonnegative num_digest_items;
      public k.int_nonnegative num_mappings;
      public string operational_period_id;
      public string sort_order;
      public string user_target_email;
      public string user_target_sms;
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
      p.be_datagrid_empty = (p.num_mappings.val == 0);
      TableCell_no_mappings.Visible = p.be_datagrid_empty;
      TableCell_mappings.Visible = !p.be_datagrid_empty;
      TableCell_add_mapping.Visible = p.may_add_mappings;
      Table_quick_message.Visible = !p.be_datagrid_empty;
      p.num_mappings.val = 0;
      //
      p.biz_strike_team_deployment_assignments.BindDigest
        (
        sort_order:p.digest_sort_order,
        be_sort_order_ascending:p.be_digest_sort_order_ascending,
        target:DataGrid_digest,
        operational_period_id:p.operational_period_id
        );
      p.be_digest_empty = (p.num_digest_items.val == 0);
      TableRow_none.Visible = p.be_digest_empty;
      TableRow_digest.Visible = !p.be_digest_empty;
      p.num_digest_items.val = 0;
      //
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
      BuildDistributionListAndRegisterPostBackControls();
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
        p.num_mappings.val++;
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
      DataGrid_control.EditItemIndex = -1;
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
      p.assignment_level_filter = k.Safe(DropDownList_assignment_level_filter.SelectedValue, k.safe_hint_type.ALPHA);
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
        p.biz_members = new TClass_biz_members();
        p.biz_patient_care_levels = new TClass_biz_patient_care_levels();
        p.biz_practitioner_strike_team_details = new TClass_biz_practitioner_strike_team_details();
        p.biz_strike_team_deployment_assignments = new TClass_biz_strike_team_deployment_assignments();
        p.biz_strike_team_deployment_members = new TClass_biz_strike_team_deployment_members();
        p.biz_strike_team_deployment_vehicles = new TClass_biz_strike_team_deployment_vehicles();
        p.biz_user = new TClass_biz_user();
        //
        p.assignment_level_filter = k.EMPTY;
        p.be_datagrid_empty = false;
        p.be_digest_empty = false;
        p.be_digest_sort_order_ascending = true;
        p.be_interactive = !(Session["mode:report"] != null);
        p.be_loaded = false;
        p.be_sort_order_ascending = true;
        p.deployment_id = k.EMPTY;
        p.digest_sort_order = UserControl_operational_period_detail_Static.INITIAL_DIGEST_SORT_ORDER;
        p.distribution_list_email = k.EMPTY;
        p.distribution_list_sms = k.EMPTY;
        p.may_add_mappings = p.be_interactive;
        p.num_digest_items = new k.int_nonnegative();
        p.num_mappings = new k.int_nonnegative();
        p.operational_period_id = k.EMPTY;
        p.sort_order = UserControl_operational_period_detail_Static.INITIAL_SORT_ORDER;
        //
        var member_id = p.biz_members.IdOfUserId(user_id:p.biz_user.IdNum());
        p.user_target_email = p.biz_members.EmailAddressOf(member_id:member_id);
        p.user_target_sms = p.biz_practitioner_strike_team_details.SmsTargetOf(practitioner_id:member_id);
        }
      }

    protected void Page_Load(object sender, System.EventArgs e)
      {
      if (!p.be_loaded)
        {
        DataGrid_control.AllowSorting = p.be_interactive;
        DataGrid_digest.AllowSorting = p.be_interactive;
        Literal_author_target.Text = (RadioButtonList_quick_message_mode.SelectedValue == "email" ? p.user_target_email : p.user_target_sms);
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

    protected void DataGrid_digest_ItemDataBound(object sender, DataGridItemEventArgs e)
      {
      if (new ArrayList {ListItemType.AlternatingItem, ListItemType.Item, ListItemType.EditItem, ListItemType.SelectedItem}.Contains(e.Item.ItemType))
        {
        e.Item.Cells[UserControl_operational_period_detail_Static.DIGEST_CI_EFFECTIVE_PATIENT_CARE_LEVEL].Text = p.biz_patient_care_levels.EffectiveOf
          (
          vehicle_patient_care_level_description:k.Safe(e.Item.Cells[UserControl_operational_period_detail_Static.DIGEST_CI_VEHICLE_PATIENT_CARE_LEVEL_ID].Text,k.safe_hint_type.HYPHENATED_ALPHA),
          practitioner_level_short_description:k.Safe(e.Item.Cells[UserControl_operational_period_detail_Static.DIGEST_CI_MAX_PRACTITIONER_LEVEL_PECKING_ORDER].Text,k.safe_hint_type.HYPHENATED_ALPHA)
          );
        p.num_digest_items.val++;
        }
      }

    protected void DataGrid_digest_SortCommand(object source, DataGridSortCommandEventArgs e)
      {
      if (e.SortExpression == p.digest_sort_order)
        {
        p.be_digest_sort_order_ascending = !p.be_digest_sort_order_ascending;
        }
      else
        {
        p.digest_sort_order = e.SortExpression;
        p.be_digest_sort_order_ascending = true;
        }
      DataGrid_digest.EditItemIndex = -1;
      Bind();
      }

    protected void CheckBox_force_all_CheckedChanged(object sender, EventArgs e)
      {
      for (var i = new k.subtype<int>(0,DataGrid_digest.Items.Count); i.val < i.LAST; i.val++)
        {
        (DataGrid_digest.Items[i.val].Cells[UserControl_operational_period_detail_Static.DIGEST_CI_SELECT_FOR_QUICKMESSAGE].FindControl("CheckBox_selected") as CheckBox).Checked = (sender as CheckBox).Checked;
        }
      BuildDistributionListAndRegisterPostBackControls();
      }

    protected void CheckBox_selected_CheckedChanged(object sender, EventArgs e)
      {
      BuildDistributionListAndRegisterPostBackControls();
      }

    private void BuildDistributionListAndRegisterPostBackControls()
      {
      p.distribution_list_email = k.EMPTY;
      p.distribution_list_sms = k.EMPTY;
      TableCellCollection tcc;
      for (var i = new k.subtype<int>(0, DataGrid_digest.Items.Count); i.val < i.LAST; i.val++)
        {
        tcc = DataGrid_digest.Items[i.val].Cells;
        if ((tcc[UserControl_operational_period_detail_Static.DIGEST_CI_SELECT_FOR_QUICKMESSAGE].FindControl("CheckBox_selected") as CheckBox).Checked)
          {
          //p.distribution_list_email += tcc[UserControl_operational_period_detail_Static.DIGEST_CI_EMAIL_ADDRESS].Text + k.COMMA_SPACE;
          p.distribution_list_sms += (tcc[UserControl_operational_period_detail_Static.DIGEST_CI_SMS_TARGET].Text + k.COMMA_SPACE).Replace("&nbsp;,",k.EMPTY);
          }
        //
        // Calls to ToolkitScriptManager.GetCurrent(Page).RegisterPostBackControl() from DataGrid_~_ItemDataBound go here.
        //
        }
      Label_distribution_list.Text = (RadioButtonList_quick_message_mode.SelectedValue == "email" ? p.distribution_list_email : p.distribution_list_sms).TrimEnd(new char[] {Convert.ToChar(k.COMMA),Convert.ToChar(k.SPACE)});
      }

    protected void Button_send_Click(object sender, EventArgs e)
      {
      var be_email_mode = (RadioButtonList_quick_message_mode.SelectedValue == "email");
      var distribution_list = (be_email_mode ? p.distribution_list_email : p.distribution_list_sms);
      if (distribution_list.Length > 0)
        {
        var attribution = k.EMPTY;
        if (be_email_mode)
          {
          attribution += "-- From "
          + p.biz_user.Roles()[0] + k.SPACE
          + p.biz_members.FirstNameOfMemberId(Session["member_id"].ToString()) + k.SPACE + p.biz_members.LastNameOfMemberId(Session["member_id"].ToString())
          + " (" + p.biz_user.EmailAddress() + ")"
          + " [via " + ConfigurationManager.AppSettings["application_name"] + "]" + k.NEW_LINE
          + k.NEW_LINE;
          }
        k.SmtpMailSend
          (
          from:ConfigurationManager.AppSettings["sender_email_address"],
          to:distribution_list,
          subject:(be_email_mode ? TextBox_quick_message_subject.Text : k.EMPTY),
          message_string:attribution + k.Safe(TextBox_quick_message_body.Text,k.safe_hint_type.MEMO),
          be_html:false,
          cc:k.EMPTY,
          bcc:k.Safe(Literal_author_target.Text,k.safe_hint_type.EMAIL_ADDRESS),
          reply_to:(RadioButtonList_reply_to.SelectedValue == "bouncer" ? ConfigurationManager.AppSettings["bouncer_email_address"] : (RadioButtonList_reply_to.SelectedValue == "email" ? p.user_target_email : p.user_target_sms))
          );
        TextBox_quick_message_subject.Text = k.EMPTY;
        TextBox_quick_message_body.Text = k.EMPTY;
        Alert
          (
          cause:k.alert_cause_type.LOGIC,
          state:k.alert_state_type.NORMAL,
          key:"messagsnt",
          value:"Message sent",
          be_using_scriptmanager:true
          );
        }
      else
        {
        Alert
          (
          cause:k.alert_cause_type.USER,
          state:k.alert_state_type.FAILURE,
          key:"noqmrecips",
          value:"Message *NOT* sent.  No recipients are selected.",
          be_using_scriptmanager:true
          );
        }
      BuildDistributionListAndRegisterPostBackControls();
      }

    protected void RadioButtonList_quick_message_mode_SelectedIndexChanged(object sender, EventArgs e)
      {
      if (RadioButtonList_quick_message_mode.SelectedValue == "email")
        {
        Literal_quick_message_kind_email.Visible = true;
        Literal_quick_message_kind_sms.Visible = false;
        Literal_author_target.Text = p.user_target_email;
        RadioButtonList_reply_to.SelectedValue = "email";
        TableRow_subject.Visible = true;
        TextBox_quick_message_body.Columns = 72;
        TextBox_quick_message_body.Rows = 18;
        Label_distribution_list.Text = p.distribution_list_email;
        }
      else
        {
        Literal_quick_message_kind_email.Visible = false;
        Literal_quick_message_kind_sms.Visible = true;
        Literal_author_target.Text = p.user_target_sms;
        RadioButtonList_reply_to.SelectedValue = "sms";
        TableRow_subject.Visible = false;
        TextBox_quick_message_body.Columns = 40;
        TextBox_quick_message_body.Rows = 4;
        Label_distribution_list.Text = p.distribution_list_sms;
        }
      BuildDistributionListAndRegisterPostBackControls();
      }

    }

  }
