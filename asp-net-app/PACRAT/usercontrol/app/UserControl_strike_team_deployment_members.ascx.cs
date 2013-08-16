// Derived from KiAspdotnetFramework/UserControl/app/UserControl~template~datagrid~sortable.ascx.cs

using AjaxControlToolkit;
using Class_biz_members;
using Class_biz_practitioner_strike_team_details;
using Class_biz_strike_team_deployment_members;
using Class_biz_user;
using Class_msg_protected;
using kix;
using System;
using System.Collections;
using System.Configuration;
using System.Drawing;
using System.Web.UI.WebControls;

namespace UserControl_strike_team_deployment_members
  {
  public partial class TWebUserControl_strike_team_deployment_members: ki_web_ui.usercontrol_class
    {
    public class UserControl_strike_team_deployment_members_Static
      {
      public const int TCI_SELECT = 0;
      public const int TCI_ID = 1;
      public const int TCI_PRACTITIONER_ID = 2;
      public const int TCI_MOBILIZED = 3;
      public const int TCI_TAG_NUM = 4;
      public const int TCI_LAST_NAME = 5;
      public const int TCI_FIRST_NAME = 6;
      public const int TCI_LEVEL = 7;
      public const int TCI_EMAIL_ADDRESS = 8;
      public const int TCI_SMS_TARGET = 9;
      public const int TCI_SELECT_FOR_QUICKMESSAGE = 10;
      }

    private struct p_type
      {
      public bool be_datagrid_empty;
      public bool be_interactive;
      public bool be_loaded;
      public bool be_sort_order_ascending;
      public TClass_biz_members biz_members;
      public TClass_biz_practitioner_strike_team_details biz_practitioner_strike_team_details;
      public TClass_biz_strike_team_deployment_members biz_strike_team_deployment_members;
      public TClass_biz_user biz_user;
      public string deployment_id;
      public bool do_include_all_eligible_practitioners;
      public string distribution_list_email;
      public string distribution_list_sms;
      public TClass_msg_protected.practitioner_profile msg_protected_practitioner_profile;
      public uint num_practitioners;
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
        p.be_loaded = true;
        }
      if (DataGrid_control.EditItemIndex > -1)
        {
        //
        // Must rebind to restore the tag_num column to its edit-mode TextBox rendition, loaded with the user-supplied value.  Otherwise we can't read that value when the ItemCommand event fires.  This will reset each
        // CheckBox_select, but if the user has shifted attention to editing a row, that should not be a big deal.
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
        if (instance_id == "ASP.protected_strike_team_deployment_detail_aspx.UserControl_strike_team_deployment_control_strike_team_deployment_binder_control_strike_team_deployment_members")
          {
          p.be_loaded &= ((Session["UserControl_strike_team_deployment_control_UserControl_strike_team_deployment_binder_control_PlaceHolder_content"] as string) == "UserControl_strike_team_deployment_members");
          }
        }
      else
        {
        p.biz_members = new TClass_biz_members();
        p.biz_practitioner_strike_team_details = new TClass_biz_practitioner_strike_team_details();
        p.biz_strike_team_deployment_members = new TClass_biz_strike_team_deployment_members();
        p.biz_user = new TClass_biz_user();
        p.msg_protected_practitioner_profile = new TClass_msg_protected.practitioner_profile();
        //
        p.be_interactive = (Session["mode:report"] == null);
        p.be_loaded = false;
        p.be_sort_order_ascending = true;
        p.deployment_id = k.EMPTY;
        p.distribution_list_email = k.EMPTY;
        p.distribution_list_sms = k.EMPTY;
        p.service_strike_team_management_footprint = k.EMPTY;
        p.sort_order = "last_name%,first_name";
        //
        var member_id = p.biz_members.IdOfUserId(user_id:p.biz_user.IdNum());
        p.user_target_email = p.biz_members.EmailAddressOf(member_id:member_id);
        p.user_target_sms = p.biz_practitioner_strike_team_details.SmsTargetOf(practitioner_id:member_id);
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
      this.PreRender += this.TWebUserControl_strike_team_deployment_members_PreRender;
      //this.Load += this.Page_Load;
      }

    private void TWebUserControl_strike_team_deployment_members_PreRender(object sender, System.EventArgs e)
      {
      SessionSet(InstanceId() + ".p", p);
      }

    public TWebUserControl_strike_team_deployment_members Fresh()
      {
      Session.Remove(InstanceId() + ".p");
      return this;
      }

    private void DataGrid_control_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
      {
      if (new ArrayList {ListItemType.AlternatingItem, ListItemType.Item, ListItemType.EditItem, ListItemType.SelectedItem}.Contains(e.Item.ItemType))
        {
        var practitioner_id = k.Safe(e.Item.Cells[UserControl_strike_team_deployment_members_Static.TCI_PRACTITIONER_ID].Text,k.safe_hint_type.NUM);
        if (e.CommandName == "Select")
          {
          p.msg_protected_practitioner_profile.id = practitioner_id;
          MessageDropCrumbAndTransferTo(p.msg_protected_practitioner_profile,"protected","practitioner_profile");
          }
        else if (e.CommandName == "ToggleMobilization")
          {
          var id = k.Safe(e.Item.Cells[UserControl_strike_team_deployment_members_Static.TCI_ID].Text,k.safe_hint_type.NUM);
          if (id.Length == 0)
            {
            p.biz_strike_team_deployment_members.Set
              (
              id:k.EMPTY,
              deployment_id:p.deployment_id,
              practitioner_id:practitioner_id,
              tag_num:k.EMPTY
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
              p.biz_strike_team_deployment_members.Set
                (
                id:id,
                deployment_id:p.deployment_id,
                practitioner_id:practitioner_id,
                tag_num:k.Safe((e.Item.Cells[UserControl_strike_team_deployment_members_Static.TCI_TAG_NUM].Controls[0] as TextBox).Text,k.safe_hint_type.NUM)
                );
              DataGrid_control.EditItemIndex = -1;
              }
            else
              {
              if (!p.do_include_all_eligible_practitioners && (p.service_strike_team_management_footprint.Length == 0))
                {
                DataGrid_control.EditItemIndex = e.Item.ItemIndex;
                }
              else
                {
                p.biz_strike_team_deployment_members.Delete(id);
                }
              }
            }
          Bind();
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
          link_button = ((e.Item.Cells[UserControl_strike_team_deployment_members_Static.TCI_SELECT].Controls[0]) as LinkButton);
          link_button.Text = k.ExpandTildePath(link_button.Text);
          //
          var be_this_row_in_edit_mode = (DataGrid_control.EditItemIndex == e.Item.ItemIndex);
          link_button = ((e.Item.Cells[UserControl_strike_team_deployment_members_Static.TCI_MOBILIZED].Controls[0]) as LinkButton);
          link_button.Text = (k.Safe(e.Item.Cells[UserControl_strike_team_deployment_members_Static.TCI_ID].Text,k.safe_hint_type.NUM).Length > 0 ? (p.do_include_all_eligible_practitioners || (p.service_strike_team_management_footprint.Length > 0) ? "YES" : "Edit>") : "no");
          link_button.Font.Bold = be_this_row_in_edit_mode;
          if (be_this_row_in_edit_mode)
            {
            link_button.Text = "SAVE>";
            (e.Item.Cells[UserControl_strike_team_deployment_members_Static.TCI_TAG_NUM].Controls[0] as TextBox).Focus();
            }
          //
          // Remove all cell controls from viewstate except for the one at TCI_ID.
          //
          foreach (TableCell cell in e.Item.Cells)
            {
            cell.EnableViewState = false;
            }
          e.Item.Cells[UserControl_strike_team_deployment_members_Static.TCI_ID].EnableViewState = true;
          e.Item.Cells[UserControl_strike_team_deployment_members_Static.TCI_SELECT_FOR_QUICKMESSAGE].EnableViewState = true;
          //
          p.num_practitioners++;
          }
        }
      else
        {
        e.Item.Cells[UserControl_strike_team_deployment_members_Static.TCI_SELECT].Visible = false;
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
      DataGrid_control.Columns[UserControl_strike_team_deployment_members_Static.TCI_MOBILIZED].HeaderText = (p.do_include_all_eligible_practitioners ? "Mobilized?" : k.EMPTY);
      DataGrid_control.Columns[UserControl_strike_team_deployment_members_Static.TCI_MOBILIZED].HeaderStyle.BackColor = (p.do_include_all_eligible_practitioners ? Color.WhiteSmoke : Color.LightGray);
      DataGrid_control.Columns[UserControl_strike_team_deployment_members_Static.TCI_MOBILIZED].ItemStyle.BackColor = (p.do_include_all_eligible_practitioners ? Color.White : Color.LightGray);
      DataGrid_control.Columns[UserControl_strike_team_deployment_members_Static.TCI_TAG_NUM].HeaderStyle.BackColor = (p.do_include_all_eligible_practitioners ? Color.WhiteSmoke : Color.LightGray);
      DataGrid_control.Columns[UserControl_strike_team_deployment_members_Static.TCI_TAG_NUM].ItemStyle.BackColor = (p.do_include_all_eligible_practitioners ? Color.White : Color.LightGray);
      p.biz_strike_team_deployment_members.BindBaseDataList
        (
        sort_order:p.sort_order,
        be_sort_order_ascending:p.be_sort_order_ascending,
        target:DataGrid_control,
        deployment_id:p.deployment_id,
        do_include_all_eligible_practitioners:p.do_include_all_eligible_practitioners,
        service_strike_team_management_footprint:p.service_strike_team_management_footprint
        );
      p.be_datagrid_empty = (p.num_practitioners == 0);
      TableRow_none.Visible = p.be_datagrid_empty;
      DataGrid_control.Visible = !p.be_datagrid_empty;
      Literal_num_practitioners.Text = p.num_practitioners.ToString();
      p.num_practitioners = 0;
      //
      BuildDistributionListAndRegisterPostBackControls();
      }

    protected void CheckBox_do_include_all_eligible_practitioners_CheckedChanged(object sender, EventArgs e)
      {
      p.do_include_all_eligible_practitioners = CheckBox_do_include_all_eligible_practitioners.Checked;
      Bind();
      }

    internal void Set
      (
      string deployment_id,
      string service_strike_team_management_footprint
      )
      {
      p.deployment_id = deployment_id;
      if ((Session["UserControl_strike_team_deployment_control_UserControl_strike_team_deployment_binder_control_PlaceHolder_content"] as string) != "UserControl_strike_team_deployment_members")
        {
        p.do_include_all_eligible_practitioners = p.biz_strike_team_deployment_members.BeNone(p.deployment_id);
        CheckBox_do_include_all_eligible_practitioners.Checked = p.do_include_all_eligible_practitioners;
        }
      p.service_strike_team_management_footprint = service_strike_team_management_footprint;
      Bind();
      }

    protected void CheckBox_force_all_CheckedChanged(object sender, EventArgs e)
      {
      for (var i = new k.subtype<int>(0,DataGrid_control.Items.Count); i.val < i.LAST; i.val++)
        {
        (DataGrid_control.Items[i.val].Cells[UserControl_strike_team_deployment_members_Static.TCI_SELECT_FOR_QUICKMESSAGE].FindControl("CheckBox_selected") as CheckBox).Checked = (sender as CheckBox).Checked;
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
        if ((tcc[UserControl_strike_team_deployment_members_Static.TCI_SELECT_FOR_QUICKMESSAGE].FindControl("CheckBox_selected") as CheckBox).Checked)
          {
          p.distribution_list_email += (tcc[UserControl_strike_team_deployment_members_Static.TCI_EMAIL_ADDRESS].Text + k.COMMA_SPACE).Replace("&nbsp;,",k.EMPTY);
          p.distribution_list_sms += (tcc[UserControl_strike_team_deployment_members_Static.TCI_SMS_TARGET].Text + k.COMMA_SPACE).Replace("&nbsp;,",k.EMPTY);
          }
        ToolkitScriptManager.GetCurrent(Page).RegisterPostBackControl((tcc[UserControl_strike_team_deployment_members_Static.TCI_SELECT].Controls[0]) as LinkButton);
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
        RadioButtonList_reply_to.SelectedValue = "phone";
        TableRow_subject.Visible = false;
        TextBox_quick_message_body.Columns = 40;
        TextBox_quick_message_body.Rows = 4;
        Label_distribution_list.Text = p.distribution_list_sms;
        }
      BuildDistributionListAndRegisterPostBackControls();
      }

    } // end TWebUserControl_strike_team_deployment_members

  }