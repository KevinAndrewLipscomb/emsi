// Derived from template~protected~nonlanding.aspx.cs~template

using Class_biz_counties;
using Class_biz_members;
using Class_biz_practitioner_levels;
using Class_biz_privileges;
using Class_biz_role_member_map;
using Class_biz_roles;
using Class_biz_tiers;
using Class_biz_user;
using Class_msg_protected;
using kix;
using System;
using System.Collections;
using System.Configuration;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace state_management
  {
  public partial class TWebForm_state_management: ki_web_ui.page_class
    {
    private static class Static
      {
      public const int TCI_BE_CREDENTIALED = 0;
      public const int TCI_UNCREDENTIALED = 1;
      public const int TCI_PROFILE = 2;
      public const int TCI_SELECT = 3;
      public const int TCI_DELETE = 4;
      public const int TCI_PRACTITIONER_ID = 5;
      public const int TCI_LAST_NAME = 6;
      public const int TCI_FIRST_NAME = 7;
      public const int TCI_MIDDLE_INITIAL = 8;
      public const int TCI_LEVEL_ID = 9;
      public const int TCI_LEVEL_SHORT_DESCRIPTION = 10;
      public const int TCI_CERT_NUM = 11;
      public const int TCI_BE_DOB_CONFIRMED = 12;
      public const int TCI_DOB = 13;
      public const int TCI_ROLE_ID = 14;
      public const int TCI_ROLE_NAME = 15;
      public const int TCI_EMAIL_ADDRESS = 16;
      public const int TCI_EDIT_UPDATE_CANCEL = 17;
      public const int TCI_STATUS_DESCRIPTION = 18;
      }

    private struct p_type
      {
      public bool be_more_than_examiner;
      public bool be_noncurrent_practitioners_on_roster;
      public bool be_ok_to_add_associate;
      public bool be_ok_to_edit_roster;
      public bool be_sort_order_ascending;
      public TClass_biz_counties biz_counties;
      public TClass_biz_members biz_members;
      public TClass_biz_practitioner_levels biz_practitioner_levels;
      public TClass_biz_privileges biz_privileges;
      public TClass_biz_role_member_map biz_role_member_map;
      public TClass_biz_roles biz_roles;
      public TClass_biz_tiers biz_tiers;
      public TClass_biz_user biz_user;
      public TClass_msg_protected.add_associate msg_protected_add_associate;
      public TClass_msg_protected.practitioner_profile msg_protected_practitioner_profile;
      public k.int_nonnegative num_assignees;
      public k.int_nonnegative num_assignees_with_known_birth_dates;
      public string state_strike_team_manager_role_id;
      public string state_tier_id;
      public ArrayList roster_id_arraylist;
      public string sort_order;
      public string user_email_address;
      }

    private p_type p;

    private void AddPractitionerToRosterAndInitForNewSearch(ListItem list_item)
      {
//      try
//        {
        if (p.be_ok_to_edit_roster)
          {
          p.biz_role_member_map.Save
            (
            member_id:list_item.Value,
            role_id:p.state_strike_team_manager_role_id,
            be_granted:true
            );
          Bind();
          }
        TextBox_practitioner.Text = k.EMPTY;
        InitForNewSearch();
//        }
//      catch (NullReferenceException)
//        {
//        }
      }

    private void Bind()
      {
      p.be_noncurrent_practitioners_on_roster = false;
      p.num_assignees.val = 0;
      p.num_assignees_with_known_birth_dates.val = 0;
      DataGrid_control.Columns[Static.TCI_DELETE].Visible = p.be_ok_to_edit_roster;
      DataGrid_control.Columns[Static.TCI_EDIT_UPDATE_CANCEL].Visible = p.be_ok_to_edit_roster;
      p.biz_role_member_map.BindBaseDataListForPennsylvania(p.sort_order,p.be_sort_order_ascending,DataGrid_control);
      TableRow_none.Visible = (p.num_assignees.val == 0);
      DataGrid_control.Visible = (p.num_assignees.val > 0);
      Label_noncurrent_practitioner_on_roster.Visible = p.be_noncurrent_practitioners_on_roster;
      Focus(TextBox_practitioner,be_using_scriptmanager:true,be_redo:true);
      }

    private void InitForNewSearch()
      {
      Literal_click_to_add.Text = k.NO_BREAK_SPACE;
      ListBox_practitioner.Items.Clear();
      ListBox_practitioner.Items.Add(k.EMPTY);
      ListBox_practitioner.Items.Add("Type at least one letter into the Search box above.");
      ListBox_practitioner.Items.Add(k.EMPTY);
      ListBox_practitioner.Items.Add("Format is:");
      ListBox_practitioner.Items.Add(k.NO_BREAK_SPACE + k.NO_BREAK_SPACE + "Lastname, Firstname MI, Cert#, DOB");
      ListBox_practitioner.Enabled = false;
      Focus(TextBox_practitioner,be_using_scriptmanager:true);
      }

    // / <summary>
    // / Required method for Designer support -- do not modify
    // / the contents of this method with the code editor.
    // / </summary>
    private void InitializeComponent()
      {
      this.PreRender += this.TWebForm_state_management_PreRender;
      }

    private void InjectPersistentClientSideScript()
      {
      ScriptManager.RegisterStartupScript(Page,Page.GetType(),"SearchAsYouTypePostBackDelayTimer","var search_as_you_type_post_back_delay_timer;",true);
      EstablishClientSideFunction(k.client_side_function_enumeral_type.EL);
      EstablishClientSideFunction("SearchAsYouTypePostBack()","__doPostBack('<%= TextBox_practitioner.ClientID %>','');");
      Body_control.Attributes.Add
        (
        "onkeypress",
        k.EMPTY
        + " return (document.activeElement.name != 'TextBox_practitioner' || event.keyCode != 13)"  // Prevent default behavior of performing a postback when enter key is pressed since we want to evaluate the situation first in the TextBox_practitioner onkeyup event.
        );
      TextBox_practitioner.Attributes.Add
        (
        "onkeyup",
        k.EMPTY
        + " if (value != El('" + HiddenField_practitioner_saved.ClientID + "').value)"
        +   " {"
        +   " El('" + HiddenField_practitioner_saved.ClientID + "').value = value;"
        +   " search_as_you_type_post_back_delay_timer = setTimeout(SearchAsYouTypePostBack,1000);" // 1000 millseconds = 1 second delay
        +   " }"
        + " else"
        +   " {"
        +   " if (El('" + ListBox_practitioner.ClientID + "').options.length == 1)"
        +     " {"
        +     " return WebForm_FireDefaultButton(event, 'Button_add');"
        +     " }"
        +   " }"
        );
      TextBox_practitioner.Attributes.Add
        (
        "onkeydown",
        k.EMPTY
        + " var new_value;"
        + " window.setTimeout(function(){new_value = value},1);" // When onkeydown event initially fires, the handlers have not finalized the change to value.  One millisecond should be long enoough of a wait.  God this sucks!
        + " if (new_value != El('" + HiddenField_practitioner_saved.ClientID + "').value) clearTimeout(search_as_you_type_post_back_delay_timer);"
        );
      }

    private void SetCloseAndSubmitAblementsAndVisibilities(bool be_open)
      {
      Button_send.Enabled = (DataGrid_control.EditItemIndex == -1);
      }

    private void TWebForm_state_management_PreRender(object sender, System.EventArgs e)
      {
      SessionSet(InstanceId() + ".p", p);
      }

    //==
    //
    // protected
    //
    //==

    protected void Button_add_Click(object sender, EventArgs e)
      {
      if (ListBox_practitioner.Items.Count == 1)
        {
        AddPractitionerToRosterAndInitForNewSearch(ListBox_practitioner.Items[0]);
        }
      }

    protected void Button_send_Click(object sender, System.EventArgs e)
      {
      var distribution_list = k.EMPTY;
      var email_address_text = k.EMPTY;
      TableCellCollection tcc;
      for (var i = new k.subtype<int>(0,DataGrid_control.Items.Count); i.val < i.LAST; i.val++)
        {
        tcc = DataGrid_control.Items[i.val].Cells;
        email_address_text = k.Safe((tcc[Static.TCI_EMAIL_ADDRESS].FindControl("Label_email_address") as Label).Text,k.safe_hint_type.EMAIL_ADDRESS);
        distribution_list += ((email_address_text != "DESIRED") && (tcc[Static.TCI_SELECT].FindControl("CheckBox_selected") as CheckBox).Checked ? email_address_text + k.COMMA : k.EMPTY);
        }
      if (distribution_list.Length > 0)
        {
        k.SmtpMailSend
          (
          from:ConfigurationManager.AppSettings["sender_email_address"],
          to:distribution_list.TrimEnd(new char[] {Convert.ToChar(k.COMMA)}),
          subject:TextBox_quick_message_subject.Text,
          message_string:"-- From " + p.biz_user.Roles()[0] + k.SPACE + p.biz_members.FirstNameOfMemberId(Session["member_id"].ToString()) + k.SPACE + p.biz_members.LastNameOfMemberId(Session["member_id"].ToString()) + " (" + p.biz_user.EmailAddress() + ") [via " + ConfigurationManager.AppSettings["application_name"] + "]" + k.NEW_LINE + k.NEW_LINE + TextBox_quick_message_body.Text,
          be_html:false,
          cc:k.EMPTY,
          bcc:p.user_email_address,
          reply_to:p.user_email_address
          );
        TextBox_quick_message_subject.Text = k.EMPTY;
        TextBox_quick_message_body.Text = k.EMPTY;
        Alert(k.alert_cause_type.LOGIC,k.alert_state_type.NORMAL,"messagsnt","Message sent",be_using_scriptmanager:true);
        }
      else
        {
        Alert(k.alert_cause_type.USER,k.alert_state_type.FAILURE,"noqmrecips","Message *NOT* sent.  No recipients are selected.",be_using_scriptmanager:true);
        }
      }

    protected void CheckBox_force_all_CheckedChanged(object sender, EventArgs e)
      {
      for (var i = new k.subtype<int>(0,DataGrid_control.Items.Count); i.val < i.LAST; i.val++)
        {
        (DataGrid_control.Items[i.val].Cells[Static.TCI_SELECT].FindControl("CheckBox_selected") as CheckBox).Checked = (sender as CheckBox).Checked;
        }
      }

    protected void CustomValidator_dob_ServerValidate(object source, ServerValidateEventArgs args)
      {
      var dob = DateTime.MinValue;
      args.IsValid = DateTime.TryParse(args.Value,out dob) && (dob > DateTime.Today.AddYears(-130)) && (dob <= DateTime.Today.AddYears(-16));
      }

    protected void CustomValidator_email_address_ServerValidate(object source, ServerValidateEventArgs args)
      {
      var args_value = k.Safe(args.Value.Replace("user@domain.tld",k.EMPTY),k.safe_hint_type.EMAIL_ADDRESS);
      args.IsValid = (args_value.Length == 0) || k.BeValidDomainPartOfEmailAddress(args_value);
      }

    protected void DataGrid_control_CancelCommand(object source, DataGridCommandEventArgs e)
      {
      DataGrid_control.EditItemIndex = -1;
      Bind();
      SetCloseAndSubmitAblementsAndVisibilities(p.be_ok_to_edit_roster);
      }

    protected void DataGrid_control_DeleteCommand(object source, DataGridCommandEventArgs e)
      {
      if (new ArrayList {ListItemType.AlternatingItem,ListItemType.Item,ListItemType.EditItem,ListItemType.SelectedItem}.Contains(e.Item.ItemType))
        {        
        p.biz_role_member_map.Save
          (
          member_id:k.Safe(e.Item.Cells[Static.TCI_PRACTITIONER_ID].Text,k.safe_hint_type.NUM),
          role_id:k.Safe(e.Item.Cells[Static.TCI_ROLE_ID].Text,k.safe_hint_type.NUM),
          be_granted:false
          );
        DataGrid_control.EditItemIndex = -1;
        Bind();
        SetCloseAndSubmitAblementsAndVisibilities(p.be_ok_to_edit_roster);
        }
      }

    protected void DataGrid_control_EditCommand(object source, DataGridCommandEventArgs e)
      {
      DataGrid_control.EditItemIndex = e.Item.ItemIndex;
      Bind();
      SetCloseAndSubmitAblementsAndVisibilities(false);
      }

    protected void DataGrid_control_ItemDataBound(object sender, DataGridItemEventArgs e)
      {
      LinkButton link_button;
      if (new ArrayList {ListItemType.AlternatingItem,ListItemType.Item,ListItemType.EditItem,ListItemType.SelectedItem}.Contains(e.Item.ItemType))
        {
        if (e.Item.Cells[Static.TCI_BE_CREDENTIALED].Text == "Y")
          {
          link_button = ((e.Item.Cells[Static.TCI_UNCREDENTIALED].Controls[0]) as LinkButton);
          link_button.Visible = false;
          }
        else
          {
          link_button = ((e.Item.Cells[Static.TCI_UNCREDENTIALED].Controls[0]) as LinkButton);
          link_button.Text = k.ExpandTildePath(link_button.Text);
          link_button.ToolTip = "UNCREDENTIALED";
          ScriptManager.GetCurrent(Page).RegisterPostBackControl(link_button);
          }
        //
        link_button = ((e.Item.Cells[Static.TCI_PROFILE].Controls[0]) as LinkButton);
        link_button.Text = k.ExpandTildePath(link_button.Text);
        link_button.ToolTip = "Profile";
        ScriptManager.GetCurrent(Page).RegisterPostBackControl(link_button);
        //
        link_button = ((e.Item.Cells[Static.TCI_DELETE].Controls[0]) as LinkButton);
        link_button.Text = k.ExpandTildePath(link_button.Text);
        link_button.ToolTip = "Delete";
        link_button.Visible = (e.Item.Cells[Static.TCI_ROLE_ID].Text != "1"); // Disable for an Application Administrator
        //
        var edit_update_cancel_controls = e.Item.Cells[Static.TCI_EDIT_UPDATE_CANCEL].Controls;
        if (edit_update_cancel_controls.Count == 1)
          {
          var label_dob = (e.Item.Cells[Static.TCI_DOB].FindControl("Label_dob") as Label);
          if (label_dob.Text == "REQUIRED")
            {
            label_dob.Font.Bold = true;
            label_dob.ForeColor = Color.Red;
            }
          else
            {
            p.num_assignees_with_known_birth_dates.val++;
            }
          //
          var label_email_address = (e.Item.Cells[Static.TCI_EMAIL_ADDRESS].FindControl("Label_email_address") as Label);
          if (label_email_address.Text == "DESIRED")
            {
            label_email_address.ForeColor = Color.DarkOrange;
            }
          //
          link_button = (edit_update_cancel_controls[0] as LinkButton);
          link_button.Text = k.ExpandTildePath(link_button.Text);
          link_button.ToolTip = "Edit";
          link_button.Visible = (e.Item.Cells[Static.TCI_ROLE_ID].Text != "1"); // Disable for an Application Administrator
          }
        else
          {
          link_button = (edit_update_cancel_controls[0] as LinkButton);
          link_button.Text = k.ExpandTildePath(link_button.Text);
          link_button.ToolTip = "Save edit";
          // Skip comment_edit_update_cancel_controls[1].  It's a literal spacer.
          link_button = (edit_update_cancel_controls[2] as LinkButton);
          link_button.Text = k.ExpandTildePath(link_button.Text);
          link_button.ToolTip = "Cancel edit";
          //
          var drop_down_list_level = e.Item.Cells[Static.TCI_LEVEL_SHORT_DESCRIPTION].FindControl("DropDownList_level") as DropDownList;
          p.biz_practitioner_levels.BindDirectToListControl
            (
            target:drop_down_list_level,
            unselected_literal:"nocert",
            selected_value:e.Item.Cells[Static.TCI_LEVEL_ID].Text,
            be_short_description_desired:true
            );
          //
          var text_box_dob = (e.Item.Cells[Static.TCI_DOB].FindControl("TextBox_dob") as TextBox);
          if (text_box_dob.Text == "REQUIRED")
            {
            text_box_dob.Text = k.EMPTY;
            }
          text_box_dob.Enabled = p.be_ok_to_edit_roster && (e.Item.Cells[Static.TCI_BE_DOB_CONFIRMED].Text == "0");
          //
          var drop_down_list_role = e.Item.Cells[Static.TCI_ROLE_NAME].FindControl("DropDownList_role") as DropDownList;
          p.biz_roles.BindDirectToListControl
            (
            target:drop_down_list_role,
            has_config_roles_and_matrices:false,
            tier_filter:p.state_tier_id,
            unselected_literal:k.EMPTY,
            selected_value:e.Item.Cells[Static.TCI_ROLE_ID].Text
            );
          //
          var text_box_email_address = (e.Item.Cells[Static.TCI_EMAIL_ADDRESS].FindControl("TextBox_email_address") as TextBox);
          if (text_box_email_address.Text == "DESIRED")
            {
            text_box_email_address.Text = k.EMPTY;
            }
          //
          var be_non_pa_practitioner = (e.Item.Cells[Static.TCI_CERT_NUM].Text == "nocert");
          (e.Item.Cells[Static.TCI_LAST_NAME].Controls[0] as TextBox).Enabled = be_non_pa_practitioner;
          (e.Item.Cells[Static.TCI_FIRST_NAME].Controls[0] as TextBox).Enabled = be_non_pa_practitioner;
          (e.Item.Cells[Static.TCI_MIDDLE_INITIAL].Controls[0] as TextBox).Enabled = be_non_pa_practitioner;
          drop_down_list_level.Enabled = be_non_pa_practitioner;
          }
        if (!(new ArrayList {"Active","Probation","Suspended"}).Contains(e.Item.Cells[Static.TCI_STATUS_DESCRIPTION].Text))
          {
          e.Item.BackColor = Color.Gold;
          p.be_noncurrent_practitioners_on_roster = true;
          }
        //--
        // DON'T disable viewstate here since thes server needs it to repopulate bound controls when an update is made to an UpdatePanel other than the one that isolates the DataGrid_control.
        //--
        //
        // Remove all cell controls from viewstate except for the one at TCI_ID.
        //
        //foreach (TableCell cell in e.Item.Cells)
        //  {
        //  cell.EnableViewState = false;
        //  }
        //e.Item.Cells[state_management_Static.TCI_ID].EnableViewState = true;
        //
        p.num_assignees.val++;
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
        p.sort_order = k.Safe(e.SortExpression, k.safe_hint_type.KI_SORT_EXPRESSION);
        p.be_sort_order_ascending = true;
        }
      DataGrid_control.EditItemIndex = -1;
      Bind();
      SetCloseAndSubmitAblementsAndVisibilities(p.be_ok_to_edit_roster);
      }

    protected void DataGrid_control_UpdateCommand(object source, DataGridCommandEventArgs e)
      {
      if (IsValid)
        {
        var practitioner_id = k.Safe(e.Item.Cells[Static.TCI_PRACTITIONER_ID].Text,k.safe_hint_type.NUM);
        //
        // The order of the next two calls is significant.  If the practitioner's email address is being updated, we must do that before we make the next call, otherwise any notification generated by the next call will go to the
        // old email address.
        //
        p.biz_members.SetFieldsNotImportedFromState
          (
          id:practitioner_id,
          birth_date:DateTime.Parse(k.Safe((e.Item.Cells[Static.TCI_DOB].FindControl("TextBox_dob") as TextBox).Text,k.safe_hint_type.DATE_TIME)),
          email_address:k.Safe((e.Item.Cells[Static.TCI_EMAIL_ADDRESS].FindControl("TextBox_email_address") as TextBox).Text.Replace("user@domain.tld",k.EMPTY),k.safe_hint_type.EMAIL_ADDRESS)
          );
        var role_id_new = k.Safe((e.Item.Cells[Static.TCI_ROLE_NAME].FindControl("DropDownList_role") as DropDownList).SelectedValue,k.safe_hint_type.NUM);
        var role_id_old = k.Safe(e.Item.Cells[Static.TCI_ROLE_ID].Text,k.safe_hint_type.NUM);
        if (role_id_new != role_id_old)
          {
          p.biz_role_member_map.Save
            (
            member_id:practitioner_id,
            role_id:role_id_old,
            be_granted:false
            );
          p.biz_role_member_map.Save
            (
            member_id:practitioner_id,
            role_id:role_id_new,
            be_granted:true
            );
          }
        //
        if (e.Item.Cells[Static.TCI_CERT_NUM].Text == "nocert")
          {
          p.biz_members.SetForNonPaPractitionerOnly
            (
            id:practitioner_id,
            last_name:k.Safe((e.Item.Cells[Static.TCI_LAST_NAME].Controls[0] as TextBox).Text,k.safe_hint_type.HUMAN_NAME),
            first_name:k.Safe((e.Item.Cells[Static.TCI_FIRST_NAME].Controls[0] as TextBox).Text,k.safe_hint_type.HUMAN_NAME),
            middle_initial:k.Safe((e.Item.Cells[Static.TCI_MIDDLE_INITIAL].Controls[0] as TextBox).Text,k.safe_hint_type.ALPHA),
            level_id:k.Safe((e.Item.Cells[Static.TCI_LEVEL_ID].FindControl("DropDownList_level") as DropDownList).SelectedValue,k.safe_hint_type.NUM)
            );
          }
        DataGrid_control.EditItemIndex = -1;
        Bind();
        SetCloseAndSubmitAblementsAndVisibilities(p.be_ok_to_edit_roster);
        }
      else
        {
        ValidationAlert(be_using_scriptmanager:true);
        }
      }

    protected void ListBox_practitioner_SelectedIndexChanged(object sender, EventArgs e)
      {
      AddPractitionerToRosterAndInitForNewSearch(ListBox_practitioner.SelectedItem);
      }

    protected override void OnInit(EventArgs e)
      {
      // Required for Designer support
      InitializeComponent();
      base.OnInit(e);
      var nature_of_visit = NatureOfVisit(InstanceId() + ".p");
      if (nature_of_visit == nature_of_visit_type.VISIT_INITIAL)
        {
        //
        // Initialize p.~ objects here.
        //
        p.biz_counties = new TClass_biz_counties();
        p.biz_members = new TClass_biz_members();
        p.biz_practitioner_levels = new TClass_biz_practitioner_levels();
        p.biz_privileges = new TClass_biz_privileges();
        p.biz_role_member_map = new TClass_biz_role_member_map();
        p.biz_roles = new TClass_biz_roles();
        p.biz_tiers = new TClass_biz_tiers();
        p.biz_user = new TClass_biz_user();
        //
        p.be_noncurrent_practitioners_on_roster = false;
        p.be_more_than_examiner = k.Has(Session["privilege_array"] as string[],"config-strike-team-state");
        p.be_ok_to_add_associate = p.biz_privileges.HasForAnyScope
          (
          member_id:p.biz_members.IdOfUserId(p.biz_user.IdNum()),
          privilege_name:"add-associates"
          );
        p.be_sort_order_ascending = true;
        p.msg_protected_add_associate = new TClass_msg_protected.add_associate();
        p.msg_protected_add_associate.tier_name = "State";
        p.msg_protected_practitioner_profile = new TClass_msg_protected.practitioner_profile();
        p.num_assignees = new k.int_nonnegative();
        p.num_assignees_with_known_birth_dates = new k.int_nonnegative();
        p.state_strike_team_manager_role_id = p.biz_roles.IdOfName("State Strike Team Manager");
        p.state_tier_id = p.biz_tiers.IdOfName("State");
        p.roster_id_arraylist = new ArrayList();
        p.sort_order = "role.pecking_order,last_name,first_name,middle_initial,certification_number";
        p.user_email_address = p.biz_members.EmailAddressOf(p.biz_members.IdOfUserId(p.biz_user.IdNum()));
        //
        p.be_ok_to_edit_roster = k.Has(Session["privilege_array"] as string[],"config-strike-team-state-unlimited");
        }
      else if (nature_of_visit == nature_of_visit_type.VISIT_POSTBACK_STANDARD)
        {
        p = (p_type)(Session[InstanceId() + ".p"]);
        }
//
//ScriptManager.GetCurrent(Page).EnablePartialRendering = false;
//
      }

    protected void Page_Load(object sender, System.EventArgs e)
      {
      if (!IsPostBack)
        {
        Title = Server.HtmlEncode(ConfigurationManager.AppSettings["application_name"]) + " - state_management";
        var max_spec_length = p.biz_members.MaxSpecLength(k.EMPTY,k.EMPTY);
        TextBox_practitioner.Width = new Unit(max_spec_length.val*0.535,UnitType.Em);
        ListBox_practitioner.Width = new Unit(max_spec_length.val*0.650,UnitType.Em);
        LinkButton_add_associate.Visible = p.be_ok_to_add_associate;
        ScriptManager.GetCurrent(Page).RegisterPostBackControl(LinkButton_add_associate);
        InitForNewSearch();
        LinkButton_drill_down.Text = k.ExpandTildePath(LinkButton_drill_down.Text);
        //
        HyperLink_print_roster.NavigateUrl = "~/protected/hardcopy_state_strike_team_key_personnel.aspx";
        //
        DataGrid_control.Columns[Static.TCI_SELECT].Visible = p.be_more_than_examiner;
        TableRow_quickmessage.Visible = p.be_more_than_examiner;
        Bind();
        SetCloseAndSubmitAblementsAndVisibilities(p.be_ok_to_edit_roster);
        Literal_author_email_address.Text = p.user_email_address;
        }
      InjectPersistentClientSideScript();
      ScriptManager.GetCurrent(Page).RegisterPostBackControl(LinkButton_drill_down);
      }

    protected void TextBox_practitioner_TextChanged(object sender, EventArgs e)
      {
      DataGrid_control.EditItemIndex = -1;
      Bind();
      SetCloseAndSubmitAblementsAndVisibilities(p.be_ok_to_edit_roster);
      UpdatePanel_assignees.Update();
      //
      var practitioner = k.Safe(TextBox_practitioner.Text,k.safe_hint_type.PUNCTUATED);
      p.biz_members.BindDirectToListControlForRoster(ListBox_practitioner,k.EMPTY,practitioner,new k.int_positive(12));
      if (practitioner.Length > 0)
        {
        if (ListBox_practitioner.Items.Count > 0)
          {
          Literal_click_to_add.Text = "Click a practitioner below to add to roster:";
          ListBox_practitioner.Enabled = true;
          }
        else
          {
          Literal_click_to_add.Text = k.NO_BREAK_SPACE;
          ListBox_practitioner.Items.Add(k.EMPTY);
          ListBox_practitioner.Items.Add("No match. Try backspacing.");
          ListBox_practitioner.Items.Add(k.EMPTY);
          ListBox_practitioner.Enabled = false;
          }
        }
      else
        {
        InitForNewSearch();
        }
      Focus(TextBox_practitioner,be_using_scriptmanager:true,be_redo:true);
      }

    protected void LinkButton_drill_down_Click(object sender, EventArgs e)
      {
      MessageDropCrumbAndTransferTo
        (
        msg:null,
        folder_name:"protected",
        aspx_name:"state_detail"
        );
      }

    protected void DataGrid_control_ItemCommand(object source, DataGridCommandEventArgs e)
      {
      if (new ArrayList {ListItemType.AlternatingItem,ListItemType.Item,ListItemType.EditItem,ListItemType.SelectedItem}.Contains(e.Item.ItemType))
        {
        if (e.CommandName == "Profile")
          {
          p.msg_protected_practitioner_profile.id = k.Safe(e.Item.Cells[Static.TCI_PRACTITIONER_ID].Text,k.safe_hint_type.NUM);
          MessageDropCrumbAndTransferTo
            (
            msg:p.msg_protected_practitioner_profile,
            folder_name:"protected",
            aspx_name:"practitioner_profile"
            );
          }
        }
      }

    protected void LinkButton_add_associate_Click(object sender, EventArgs e)
      {
      MessageDropCrumbAndTransferTo
        (
        msg:p.msg_protected_add_associate,
        folder_name:"protected",
        aspx_name:"add_associate"
        );
      }

    } // end TWebForm_state_management

  }