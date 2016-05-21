// Derived from KiAspdotnetFramework/UserControl/app/UserControl~template~datagrid~sortable.ascx.cs

using Class_biz_members;
using Class_biz_practitioner_strike_team_details;
using Class_biz_services;
using Class_biz_strike_team_deployments;
using Class_biz_user;
using Class_msg_protected;
using kix;
using System;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserControl_attachment_explorer;

namespace UserControl_strike_team_deployment_agreements
  {
  public partial class TWebUserControl_strike_team_deployment_agreements: ki_web_ui.usercontrol_class
    {
    private static class Static
      {
      public const int TCI_SELECT = 0;
      public const int TCI_ID = 1;
      public const int TCI_REGION_CODE = 2;
      public const int TCI_REGION_NAME = 3;
      public const int TCI_AFFILIATE_NUM = 4;
      public const int TCI_SHORT_NAME = 5;
      public const int TCI_LONG_NAME = 6;
      public const int TCI_FILES = 7;
      public const int TCI_EMAIL_TARGET = 8;
      public const int TCI_SMS_TARGET = 9;
      public const int TCI_SELECT_FOR_QUICKMESSAGE = 10;
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
      public TClass_biz_services biz_services;
      public TClass_biz_strike_team_deployments biz_strike_team_deployments;
      public TClass_biz_user biz_user;
      public TClass_msg_protected.service_management msg_protected_service_management;
      public string deployment_id;
      public string distribution_list_email;
      public string distribution_list_sms;
      public uint num_services;
      public string service_strike_team_management_footprint;
      public string sort_order;
      public string user_target_email;
      public string user_target_sms;
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

    protected void Page_Load(object sender, EventArgs e)
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
        p.be_loaded = true;
        }
      InjectPersistentClientSideScript();
      }

    protected override void OnInit(EventArgs e)
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
        if (instance_id == "ASP.protected_strike_team_deployment_detail_aspx.UserControl_strike_team_deployment_control_strike_team_deployment_binder_control_strike_team_deployment_agreements")
          {
          p.be_loaded &= ((Session["UserControl_strike_team_deployment_control_UserControl_strike_team_deployment_binder_control_PlaceHolder_content"] as string) == "UserControl_strike_team_deployment_agreements");
          }
        }
      else
        {
        p.biz_members = new TClass_biz_members();
        p.biz_practitioner_strike_team_details = new TClass_biz_practitioner_strike_team_details();
        p.biz_services = new TClass_biz_services();
        p.biz_strike_team_deployments = new TClass_biz_strike_team_deployments();
        p.biz_user = new TClass_biz_user();
        p.msg_protected_service_management = new TClass_msg_protected.service_management();
        //
        p.be_interactive = (Session["mode:report"] == null);
        p.be_loaded = false;
        p.be_more_than_examiner = false;
        p.be_sort_order_ascending = true;
        p.deployment_id = k.EMPTY;
        p.distribution_list_email = k.EMPTY;
        p.distribution_list_sms = k.EMPTY;
        p.service_strike_team_management_footprint = k.EMPTY;
        p.sort_order = "service.short_name%";
        //
        var user_member_id = p.biz_members.IdOfUserId(user_id:p.biz_user.IdNum());
        p.user_target_email = p.biz_members.EmailAddressOf(member_id:user_member_id);
        p.user_target_sms = p.biz_practitioner_strike_team_details.SmsTargetOf(practitioner_id:user_member_id);
        }
      }

    // / <summary>
    // / Required method for Designer support -- do not modify
    // / the contents of this method with the code editor.
    // / </summary>
    private void InitializeComponent()
      {
      DataGrid_control.ItemDataBound += new DataGridItemEventHandler(DataGrid_control_ItemDataBound);
      DataGrid_control.SortCommand += new DataGridSortCommandEventHandler(DataGrid_control_SortCommand);
      DataGrid_control.ItemCommand += new DataGridCommandEventHandler(DataGrid_control_ItemCommand);
      PreRender += TWebUserControl_strike_team_deployment_agreements_PreRender;
      }

    private void TWebUserControl_strike_team_deployment_agreements_PreRender(object sender, EventArgs e)
      {
      SessionSet(InstanceId() + ".p", p);
      }

    public TWebUserControl_strike_team_deployment_agreements Fresh()
      {
      Session.Remove(InstanceId() + ".p");
      return this;
      }

    private void DataGrid_control_ItemCommand(object source, DataGridCommandEventArgs e)
      {
      if (e.Item.ItemType.ToString().EndsWith("Item"))
        {
        var service_id = k.Safe(e.Item.Cells[Static.TCI_ID].Text,k.safe_hint_type.NUM);
        if (e.CommandName == "Select")
          {
          p.msg_protected_service_management.region_code = k.Safe(e.Item.Cells[Static.TCI_REGION_CODE].Text,k.safe_hint_type.NUM);
          p.msg_protected_service_management.summary = p.biz_services.Summary(id:k.Safe(e.Item.Cells[Static.TCI_ID].Text,k.safe_hint_type.NUM));
          p.msg_protected_service_management.be_more_than_examiner = p.be_more_than_examiner;
          MessageDropCrumbAndTransferTo(p.msg_protected_service_management,"protected","service_management");
          }
        }
      }

    private void DataGrid_control_ItemDataBound(object sender, DataGridItemEventArgs e)
      {
      LinkButton link_button;
      TWebUserControl_attachment_explorer attachment_explorer;
      if (p.be_interactive)
        {
        if (e.Item.ItemType.ToString().EndsWith("Item"))
          {
          link_button = ((e.Item.Cells[Static.TCI_SELECT].Controls[0]) as LinkButton);
          link_button.Text = k.ExpandTildePath(link_button.Text);
          ScriptManager.GetCurrent(Page).RegisterPostBackControl(link_button);
          //
          attachment_explorer = ((e.Item.Cells[Static.TCI_FILES].FindControl(id:"UserControl_attachment_explorer_control")) as TWebUserControl_attachment_explorer);
          attachment_explorer.path = k.EMPTY;
          attachment_explorer.enabled = p.be_more_than_examiner;
          attachment_explorer.be_ok_to_add = p.be_more_than_examiner;
          attachment_explorer.be_ok_to_delete = p.be_more_than_examiner;
          attachment_explorer.Bind(HttpContext.Current.Server.MapPath("~/protected/attachment/service-strike-team-moa/" + e.Item.Cells[Static.TCI_AFFILIATE_NUM].Text));
          ScriptManager.GetCurrent(Page).RegisterPostBackControl(attachment_explorer);
          //
          // Remove all cell controls from viewstate except for the one at TCI_ID.
          //
          foreach (TableCell cell in e.Item.Cells)
            {
            cell.EnableViewState = false;
            }
          e.Item.Cells[Static.TCI_ID].EnableViewState = true;
          //
          p.num_services++;
          }
        }
      else
        {
        e.Item.Cells[Static.TCI_SELECT].Visible = false;
        e.Item.Cells[Static.TCI_SELECT_FOR_QUICKMESSAGE].EnableViewState = true;
        }
      }

    private void DataGrid_control_SortCommand(object source, DataGridSortCommandEventArgs e)
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
      p.biz_services.BindBaseDataListOfAdHocStrikeTeams
        (
        sort_order:p.sort_order,
        be_sort_order_ascending:p.be_sort_order_ascending,
        target:DataGrid_control,
        service_strike_team_management_footprint:p.service_strike_team_management_footprint
        );
      p.be_datagrid_empty = (p.num_services == 0);
      TableRow_none.Visible = p.be_datagrid_empty;
      DataGrid_control.Visible = !p.be_datagrid_empty;
      Literal_num_services.Text = p.num_services.ToString();
      p.num_services = 0;
      //
      BuildDistributionListAndRegisterPostBackControls();
      }

    private void SetRestrictedMode()
      {
      TableRow_operational_period_started.Visible = p.be_more_than_examiner;
      }

    internal void Set
      (
      string deployment_id,
      string service_strike_team_management_footprint,
      bool be_ok_to_config_strike_team_deployments,
      bool be_more_than_examiner
      )
      {
      p.deployment_id = deployment_id;
      p.service_strike_team_management_footprint = service_strike_team_management_footprint;
      //
      p.be_more_than_examiner = be_more_than_examiner;
      //
      // The following two "conditional re-default" settings *must* occur before the *first* Bind().  They are "conditional re-defaults" because this entire complex usercontrol was originally written with the assumption
      // that anyone who could see this control could also make certain changes and/or quickmessages.  When support was added for the State Strike Team Examiner role, 'visible="false"' was applied as a new default to the
      // quickmessage controls in the ASCX file.  Now that we can execute tests, we should re-default those controls to visible if the user is not merely a State Strike Team Examiner.  We must do this before the first
      // Bind() because Bind() tests for subsequent conditions when the quickmessage controls should again be invisible.
      //
      DataGrid_control.Columns[Static.TCI_SELECT_FOR_QUICKMESSAGE].Visible = p.be_more_than_examiner;
      Table_quick_message.Visible = p.be_more_than_examiner;
      //
      Bind();
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
      p.distribution_list_email = k.EMPTY;
      p.distribution_list_sms = k.EMPTY;
      TableCellCollection tcc;
      for (var i = new k.subtype<int>(0, DataGrid_control.Items.Count); i.val < i.LAST; i.val++)
        {
        tcc = DataGrid_control.Items[i.val].Cells;
        if ((tcc[Static.TCI_SELECT_FOR_QUICKMESSAGE].FindControl("CheckBox_selected") as CheckBox).Checked)
          {
          p.distribution_list_email += (tcc[Static.TCI_EMAIL_TARGET].Text + k.COMMA_SPACE).Replace("&nbsp;,",k.EMPTY);
          p.distribution_list_sms += (tcc[Static.TCI_SMS_TARGET].Text + k.COMMA_SPACE).Replace("&nbsp;,",k.EMPTY);
          }
        ScriptManager.GetCurrent(Page).RegisterPostBackControl((tcc[Static.TCI_SELECT].Controls[0]) as LinkButton);
        }
      Label_distribution_list.Text = (RadioButtonList_quick_message_mode.SelectedValue == "email" ? p.distribution_list_email : p.distribution_list_sms).TrimEnd(new char[] {Convert.ToChar(k.COMMA),Convert.ToChar(k.SPACE)});
      }

    protected void Button_send_Click(object sender, EventArgs e)
      {
      if (p.biz_strike_team_deployments.BeOkToMakeMobilizationChangesAndQuickMessages(p.deployment_id,p.service_strike_team_management_footprint))
        {
        BuildDistributionListAndRegisterPostBackControls();
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
        }
      else // changes and QuickMessages no longer allowed
        {
        SetRestrictedMode();
        }
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
        RadioButtonList_reply_to.SelectedValue = "phone";
        TableRow_subject.Visible = false;
        TextBox_quick_message_body.Columns = 40;
        TextBox_quick_message_body.Rows = 4;
        Label_distribution_list.Text = p.distribution_list_sms;
        }
      BuildDistributionListAndRegisterPostBackControls();
      }

    } // end TWebUserControl_strike_team_deployment_agreements

  }