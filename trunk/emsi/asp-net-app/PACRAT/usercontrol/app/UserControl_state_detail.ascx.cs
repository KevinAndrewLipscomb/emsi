// Derived from KiAspdotnetFramework/UserControl/app/UserControl~template~datagrid~sortable.ascx.cs

using Class_biz_members;
using Class_biz_practitioner_strike_team_details;
using Class_biz_regions;
using Class_biz_user;
using Class_msg_protected;
using kix;
using System;
using System.Collections;
using System.Configuration;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserControl_state_detail
  {
  public partial class TWebUserControl_state_detail: ki_web_ui.usercontrol_class
    {
    private class Static
      {
      public const int TCI_SELECT = 0;
      public const int TCI_CODE = 1;
      public const int TCI_NAME = 2;
      public const int TCI_PARTICIPANT = 3;
      public const int TCI_EMAIL_TARGET = 4;
      public const int TCI_SMS_TARGET = 5;
      public const int TCI_SELECT_FOR_QUICKMESSAGE = 6;
      }

    private struct p_type
      {
      public bool be_datagrid_empty;
      public bool be_interactive;
      public bool be_loaded;
      public bool be_more_than_examiner;
      public bool be_sort_order_ascending;
      public TClass_biz_members biz_members;
      public TClass_biz_practitioner_strike_team_details biz_practitioner_strike_team_details;
      public TClass_biz_regions biz_regions;
      public TClass_biz_user biz_user;
      public bool do_include_all_regions;
      public TClass_msg_protected.region_management msg_protected_region_management;
      public uint num_regions;
      public string sort_order;
      public string user_target_email;
      public string user_target_sms;
      }

    private struct v_type
      {
      public StringBuilder distribution_list_email;
      public StringBuilder distribution_list_sms;
      }

    private p_type p; // Private Parcel of Page-Pertinent Process-Persistent Parameters
    private v_type v; // Volatile instance Variable container

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
        if (p.be_interactive)
          {
          Literal_author_target.Text = (RadioButtonList_quick_message_mode.SelectedValue == "email" ? p.user_target_email : p.user_target_sms);
          }
        else
          {
          DataGrid_control.AllowSorting = false;
          }
        Table_quick_message.Visible = p.be_more_than_examiner;
        DataGrid_control.Columns[Static.TCI_SELECT_FOR_QUICKMESSAGE].Visible = p.be_more_than_examiner;
        Bind();
        p.be_loaded = true;
        }
      InjectPersistentClientSideScript();
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
        p.biz_practitioner_strike_team_details = new TClass_biz_practitioner_strike_team_details();
        p.biz_regions = new TClass_biz_regions();
        p.msg_protected_region_management = new TClass_msg_protected.region_management();
        p.biz_user = new TClass_biz_user();
        //
        p.be_interactive = (Session["mode:report"] == null);
        p.be_loaded = false;
        p.be_more_than_examiner = k.Has(Session["privilege_array"] as string[],"config-strike-team-state");
        p.be_sort_order_ascending = true;
        p.do_include_all_regions = false;
        p.sort_order = "be_pacrat_subscriber desc,name";
        //
        var member_id = p.biz_members.IdOfUserId(user_id:p.biz_user.IdNum());
        p.user_target_email = p.biz_members.EmailAddressOf(member_id:member_id);
        p.user_target_sms = p.biz_practitioner_strike_team_details.SmsTargetOf(practitioner_id:member_id);
        }
      v.distribution_list_email = new StringBuilder();
      v.distribution_list_sms = new StringBuilder();
      }

    // / <summary>
    // / Required method for Designer support -- do not modify
    // / the contents of this method with the code editor.
    // / </summary>
    private void InitializeComponent()
      {
      DataGrid_control.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(DataGrid_control_ItemDataBound);
      DataGrid_control.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(DataGrid_control_SortCommand);
      DataGrid_control.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(DataGrid_control_ItemCommand);
      PreRender += TWebUserControl_state_detail_PreRender;
      }

    private void TWebUserControl_state_detail_PreRender(object sender, System.EventArgs e)
      {
      SessionSet(InstanceId() + ".p", p);
      }

    public TWebUserControl_state_detail Fresh()
      {
      Session.Remove(InstanceId() + ".p");
      return this;
      }

    private void DataGrid_control_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
      {
      if (new ArrayList {ListItemType.AlternatingItem, ListItemType.Item, ListItemType.EditItem, ListItemType.SelectedItem}.Contains(e.Item.ItemType))
        {
        p.msg_protected_region_management.summary = p.biz_regions.Summary(k.Safe(e.Item.Cells[Static.TCI_CODE].Text,k.safe_hint_type.NUM));
        p.msg_protected_region_management.be_more_than_examiner = p.be_more_than_examiner;
        MessageDropCrumbAndTransferTo(p.msg_protected_region_management,"protected","region_management");
        }
      }

    private void DataGrid_control_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
      {
      LinkButton link_button;
      if (p.be_interactive)
        {
        if (new ArrayList {ListItemType.AlternatingItem, ListItemType.Item, ListItemType.EditItem, ListItemType.SelectedItem}.Contains(e.Item.ItemType))
          {
          link_button = ((e.Item.Cells[Static.TCI_SELECT].Controls[0]) as LinkButton);
          link_button.Text = k.ExpandTildePath(link_button.Text);
          //
          p.num_regions++;
          }
        }
      else
        {
        e.Item.Cells[Static.TCI_SELECT].Visible = false;
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
      p.biz_regions.BindPacratManagementBaseDataList
        (
        sort_order:p.sort_order,
        be_sort_order_ascending:p.be_sort_order_ascending,
        target:DataGrid_control,
        do_include_all_regions:p.do_include_all_regions
        );
      p.be_datagrid_empty = (p.num_regions == 0);
      TableRow_none.Visible = p.be_datagrid_empty;
      DataGrid_control.Visible = !p.be_datagrid_empty;
      Literal_num_regions.Text = p.num_regions.ToString();
      p.num_regions = 0;
      BuildDistributionListAndRegisterPostBackControls();
      }

    protected void CheckBox_force_all_CheckedChanged(object sender, EventArgs e)
      {
      for (var i = new k.subtype<int>(0,DataGrid_control.Items.Count); i.val < i.LAST; i.val++)
        {
        (DataGrid_control.Items[i.val].Cells[Static.TCI_SELECT_FOR_QUICKMESSAGE].FindControl("CheckBox_selected") as CheckBox).Checked = (sender as CheckBox).Checked;
        }
      BuildDistributionListAndRegisterPostBackControls();
      }

    protected void CheckBox_selected_CheckedChanged(object sender, EventArgs e)
      {
      BuildDistributionListAndRegisterPostBackControls();
      }

    private void BuildDistributionListAndRegisterPostBackControls()
      {
      v.distribution_list_email.Clear();
      v.distribution_list_sms.Clear();
      TableCellCollection tcc;
      for (var i = new k.subtype<int>(0, DataGrid_control.Items.Count); i.val < i.LAST; i.val++)
        {
        tcc = DataGrid_control.Items[i.val].Cells;
        if ((tcc[Static.TCI_SELECT_FOR_QUICKMESSAGE].FindControl("CheckBox_selected") as CheckBox).Checked)
          {
          v.distribution_list_email.Append((tcc[Static.TCI_EMAIL_TARGET].Text + k.COMMA_SPACE).Replace("&nbsp;,",k.EMPTY));
          v.distribution_list_sms.Append((tcc[Static.TCI_SMS_TARGET].Text + k.COMMA_SPACE).Replace("&nbsp;,",k.EMPTY));
          }
        ScriptManager.GetCurrent(Page).RegisterPostBackControl((tcc[Static.TCI_SELECT].Controls[0]) as LinkButton);
        }
      Label_distribution_list.Text = (RadioButtonList_quick_message_mode.SelectedValue == "email" ? v.distribution_list_email : v.distribution_list_sms).ToString().TrimEnd(new char[] {Convert.ToChar(k.COMMA),Convert.ToChar(k.SPACE)});
      }

    protected void Button_send_Click(object sender, EventArgs e)
      {
      BuildDistributionListAndRegisterPostBackControls();
      var be_email_mode = (RadioButtonList_quick_message_mode.SelectedValue == "email");
      if (Label_distribution_list.Text.Length > 0)
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
          to:Label_distribution_list.Text,
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
      }

    protected void RadioButtonList_quick_message_mode_SelectedIndexChanged(object sender, EventArgs e)
      {
      BuildDistributionListAndRegisterPostBackControls();
      if (RadioButtonList_quick_message_mode.SelectedValue == "email")
        {
        Literal_quick_message_kind_email.Visible = true;
        Literal_quick_message_kind_sms.Visible = false;
        Literal_author_target.Text = p.user_target_email;
        RadioButtonList_reply_to.SelectedValue = "email";
        TableRow_subject.Visible = true;
        TextBox_quick_message_body.Columns = 72;
        TextBox_quick_message_body.Rows = 18;
        }
      else
        {
        Literal_quick_message_kind_email.Visible = false;
        Literal_quick_message_kind_sms.Visible = true;
        Literal_author_target.Text = p.user_target_sms;
        RadioButtonList_reply_to.SelectedValue = "phone";
        TableRow_subject.Visible = false;
        TextBox_quick_message_body.Columns = 40;
        TextBox_quick_message_body.Rows = 4;
        }
      }

    protected void CheckBox_do_include_all_regions_CheckedChanged(object sender, EventArgs e)
      {
      p.do_include_all_regions = CheckBox_do_include_all_regions.Checked;
      Bind();
      }

    } // end TWebUserControl_state_detail

  }