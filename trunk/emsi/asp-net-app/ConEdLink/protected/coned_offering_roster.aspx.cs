// Derived from template~protected~nonlanding.aspx.cs~template

using AjaxControlToolkit;
using Class_biz_accounts;
using Class_biz_coned_offering_rosters;
using Class_biz_coned_offerings;
using Class_biz_counties;
using Class_biz_practitioners;
using Class_biz_teaching_entities;
using Class_biz_user;
using Class_msg_protected;
using kix;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Web.UI.WebControls;

namespace coned_offering_roster
  {
  public struct p_type
    {
    public bool be_ceu_breakdown_valid;
    public bool be_noncurrent_practitioners_on_roster;
    public bool be_ok_to_edit_roster;
    public bool be_sort_order_ascending;
    public TClass_biz_accounts biz_accounts;
    public TClass_biz_coned_offering_rosters biz_coned_offering_rosters;
    public TClass_biz_coned_offerings biz_coned_offerings;
    public TClass_biz_counties biz_counties;
    public TClass_biz_practitioners biz_practitioners;
    public TClass_biz_teaching_entities biz_teaching_entities;
    public TClass_biz_user biz_user;
    public string coned_offering_id;
    public TClass_msg_protected.coned_offering_roster incoming;
    public k.decimal_nonnegative length;
    public k.int_nonnegative num_attendees;
    public k.int_nonnegative num_attendees_with_known_birth_dates;
    public string other_roster_id;
    public string region_code;
    public ArrayList roster_id_arraylist;
    public string sort_order;
    public string user_email_address;
    }

  public partial class TWebForm_coned_offering_roster: ki_web_ui.page_class
    {
    private class coned_offering_roster_Static
      {
      public const int TCI_ID = 0;
      public const int TCI_SELECT = 1;
      public const int TCI_DELETE = 2;
      public const int TCI_PRACTITIONER_ID = 3;
      public const int TCI_LAST_NAME = 4;
      public const int TCI_FIRST_NAME = 5;
      public const int TCI_MIDDLE_INITIAL = 6;
      public const int TCI_LEVEL = 7;
      public const int TCI_LEVEL_EMSRS_CODE = 8;
      public const int TCI_CERT_NUM = 9;
      public const int TCI_BE_DOB_CONFIRMED = 10;
      public const int TCI_DOB = 11;
      public const int TCI_COUNTY_CODE = 12;
      public const int TCI_COUNTY_NAME = 13;
      public const int TCI_EMAIL_ADDRESS = 14;
      public const int TCI_BE_INSTRUCTOR = 15;
      public const int TCI_INSTRUCTOR_HOURS = 16;
      public const int TCI_EDIT_UPDATE_CANCEL = 17;
      public const int TCI_STATUS_DESCRIPTION = 18;
      }

    private p_type p;

    private void AddPractitionerToRosterAndInitForNewSearch(ListItem list_item)
      {
      try
        {
        p.biz_coned_offering_rosters.Set(id:k.EMPTY,coned_offering_id:p.coned_offering_id,practitioner_id:list_item.Value,instructor_hours:k.EMPTY);
        Bind();
        TextBox_practitioner.Text = k.EMPTY;
        InitForNewSearch();
        }
      catch (NullReferenceException)
        {
        }
      }

    private void Bind()
      {
      p.be_noncurrent_practitioners_on_roster = false;
      p.num_attendees.val = 0;
      p.num_attendees_with_known_birth_dates.val = 0;
      DataGrid_control.Columns[coned_offering_roster_Static.TCI_DELETE].Visible = p.be_ok_to_edit_roster;
      p.biz_coned_offering_rosters.BindBaseDataListByClassId(p.sort_order,p.be_sort_order_ascending,DataGrid_control,p.coned_offering_id);
      Button_mark_class_canceled.Visible = (p.num_attendees.val == 0) || (Session["imitator_designator"] != null);
      TableRow_none.Visible = (p.num_attendees.val == 0);
      DataGrid_control.Visible = (p.num_attendees.val > 0);
      Label_noncurrent_practitioner_on_roster.Visible = p.be_noncurrent_practitioners_on_roster;
      SetHyperlinkPrintCompletionDocumentation();
      if (RadioButtonList_input_method.SelectedValue == "Standard")
        {
        Focus(TextBox_practitioner,be_using_scriptmanager:true,be_redo:true);
        }
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
      this.PreRender += this.TWebForm_coned_offering_roster_PreRender;
      }

    private void InjectPersistentClientSideScript()
      {
      ToolkitScriptManager.RegisterStartupScript(Page,Page.GetType(),"SearchAsYouTypePostBackDelayTimer","var search_as_you_type_post_back_delay_timer;",true);
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

    private void ManageInputPanels()
      {
      Panel_one_at_a_time.Visible = (RadioButtonList_input_method.SelectedValue == "Standard");
      Panel_batch.Visible = (RadioButtonList_input_method.SelectedValue == "Batch");
      Panel_copy.Visible = (RadioButtonList_input_method.SelectedValue == "Copy");
      //
      if (Panel_batch.Visible)
        {
        TextBox_certification_number_batch.Focus();
        }
      }

    private void SetCloseAndSubmitAblementsAndVisibilities(bool be_open)
      {
      Button_close_and_submit.Visible = be_open;
      Button_close_and_submit.Enabled = (DataGrid_control.EditItemIndex == -1);
      CustomValidator_close_class_and_submit_for_credit.Visible = be_open;
      HyperLink_quickmessage.Enabled = (DataGrid_control.EditItemIndex == -1);
      LinkButton_email_completion_documentation.Enabled = !be_open && (DataGrid_control.EditItemIndex == -1);
      HyperLink_print_completion_documentation.Enabled = !be_open && (DataGrid_control.EditItemIndex == -1) && p.be_ceu_breakdown_valid;
      Button_send.Enabled = (DataGrid_control.EditItemIndex == -1);
      }

    private void SetHyperlinkPrintCompletionDocumentation()
      {
      HyperLink_print_completion_documentation.NavigateUrl = k.EMPTY;
      p.roster_id_arraylist.Clear();
      for (var i = new k.subtype<int>(0,DataGrid_control.Items.Count); i.val < i.LAST; i.val++)
        {
        if ((DataGrid_control.Items[i.val].Cells[coned_offering_roster_Static.TCI_SELECT].FindControl("CheckBox_selected") as CheckBox).Checked)
          {
          p.roster_id_arraylist.Add(k.Safe(DataGrid_control.Items[i.val].Cells[coned_offering_roster_Static.TCI_ID].Text,k.safe_hint_type.NUM));
          }
        }
      if (p.roster_id_arraylist.Count > 0)
        {
        var hash_table = new Hashtable();
        hash_table["coned_offering_id"] = p.biz_coned_offerings.IdOf(p.incoming.summary);
        hash_table["coned_offering_roster_ids"] = p.roster_id_arraylist;
        HyperLink_print_completion_documentation.NavigateUrl = "~/protected/training_certificate_package.aspx?" + ShieldedQueryStringOfHashtable(hash_table);
        }
      }

    private void TWebForm_coned_offering_roster_PreRender(object sender, System.EventArgs e)
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

    protected void Button_add_batch_Click(object sender, EventArgs e)
      {
      var cert_num_array = TextBox_certification_number_batch.Text.Trim().Split(new string[] {k.NEW_LINE,k.SPACE,k.COMMA,k.TAB,k.SEMICOLON},StringSplitOptions.RemoveEmptyEntries);
      TextBox_certification_number_batch.Text = k.EMPTY;
      for (var i = new k.subtype<int>(0,cert_num_array.Length); i.val < i.LAST; i.val++)
        {
        var cert_num = k.Safe(cert_num_array[i.val],k.safe_hint_type.NUM).PadLeft(6,'0');
        if (!p.biz_coned_offering_rosters.SetFromBatch(p.coned_offering_id,cert_num))
          {
          TextBox_certification_number_batch.Text += cert_num + k.NEW_LINE;
          }
        }
      Bind();
      }

    protected void Button_close_and_submit_Click(object sender, EventArgs e)
      {
      if (IsValid)
        {
        p.biz_coned_offerings.CloseAndSubmit(p.incoming.summary,p.num_attendees);
        p.be_ok_to_edit_roster = false;
        Bind();
        SetCloseAndSubmitAblementsAndVisibilities(false);
        }
      else
        {
        ValidationAlert(be_using_scriptmanager:true);
        }
      }

    protected void Button_copy_Click(object sender, EventArgs e)
      {
      if (IsValid)
        {
        p.biz_coned_offering_rosters.Copy(source_id:p.other_roster_id,target_id:p.coned_offering_id);
        Bind();
        RadioButtonList_input_method.SelectedValue = "Standard";
        ManageInputPanels();
        }
      }

    protected void Button_mark_class_canceled_Click(object sender, EventArgs e)
      {
      try
        {
        p.biz_coned_offerings.MarkCanceled(p.incoming.summary,p.region_code);
        BackTrack();
        }
      catch
        {
        Alert
          (
          cause:k.alert_cause_type.NETWORK,
          state:k.alert_state_type.FAILURE,
          key:"bademsrscancel",
          value:"ConEdLink was unable to cancel the class.  This may be due to a temporary problem communicating with EMSRS.  Please try again.  If the problem continues, please try later.  If the problem is persistent, please"
          + " notify your regional council and cite the class number."
          );
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
        email_address_text = k.Safe((tcc[coned_offering_roster_Static.TCI_EMAIL_ADDRESS].FindControl("Label_email_address") as Label).Text,k.safe_hint_type.EMAIL_ADDRESS);
        distribution_list += ((email_address_text != "DESIRED") && (tcc[coned_offering_roster_Static.TCI_SELECT].FindControl("CheckBox_selected") as CheckBox).Checked ? email_address_text + k.COMMA : k.EMPTY);
        }
      if (distribution_list.Length > 0)
        {
        k.SmtpMailSend
          (
          from:ConfigurationManager.AppSettings["sender_email_address"],
          to:distribution_list.TrimEnd(new char[] {Convert.ToChar(k.COMMA)}),
          subject:TextBox_quick_message_subject.Text,
          message_string:"-- From " + Session[p.biz_user.Kind() + "_name"].ToString() + " (via " + ConfigurationManager.AppSettings["application_name"] + ")" + k.NEW_LINE + k.NEW_LINE + TextBox_quick_message_body.Text,
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
        (DataGrid_control.Items[i.val].Cells[coned_offering_roster_Static.TCI_SELECT].FindControl("CheckBox_selected") as CheckBox).Checked = (sender as CheckBox).Checked;
        }
      SetHyperlinkPrintCompletionDocumentation();
      }

    protected void CheckBox_selected_CheckedChanged(object sender, EventArgs e)
      {
      SetHyperlinkPrintCompletionDocumentation();
      }

    protected void CustomValidator_close_class_and_submit_for_credit_ServerValidate(object source, ServerValidateEventArgs args)
      {
      args.IsValid = p.biz_coned_offerings.BeOkToCloseClassAndSubmitForCredit(p.incoming.summary,p.num_attendees,p.num_attendees_with_known_birth_dates);
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

    protected void CustomValidator_instructor_hours_ServerValidate(object source, ServerValidateEventArgs args)
      {
      var args_value = k.Safe(args.Value.Replace("#.#",k.EMPTY),k.safe_hint_type.REAL_NUM);
      decimal instructor_hours;
      args.IsValid = (args_value.Length == 0) || (decimal.TryParse(args_value,out instructor_hours) && (instructor_hours > 0) && (instructor_hours <= p.biz_coned_offerings.FullHourDurationOf(p.incoming.summary)));
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
        p.biz_coned_offering_rosters.Delete(k.Safe(e.Item.Cells[coned_offering_roster_Static.TCI_ID].Text,k.safe_hint_type.NUM));
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
        link_button = ((e.Item.Cells[coned_offering_roster_Static.TCI_DELETE].Controls[0]) as LinkButton);
        link_button.Text = k.ExpandTildePath(link_button.Text);
        link_button.ToolTip = "Delete";
        //
        var edit_update_cancel_controls = e.Item.Cells[coned_offering_roster_Static.TCI_EDIT_UPDATE_CANCEL].Controls;
        if (edit_update_cancel_controls.Count == 1)
          {
          var label_dob = (e.Item.Cells[coned_offering_roster_Static.TCI_DOB].FindControl("Label_dob") as Label);
          if (label_dob.Text == "REQUIRED")
            {
            label_dob.Font.Bold = true;
            label_dob.ForeColor = Color.Red;
            }
          else
            {
            p.num_attendees_with_known_birth_dates.val++;
            }
          //
          var label_email_address = (e.Item.Cells[coned_offering_roster_Static.TCI_EMAIL_ADDRESS].FindControl("Label_email_address") as Label);
          if (label_email_address.Text == "DESIRED")
            {
            label_email_address.ForeColor = Color.DarkOrange;
            }
          //
          if (e.Item.Cells[coned_offering_roster_Static.TCI_BE_INSTRUCTOR].Text == "1")
            {
            var label_instructor_hours = (e.Item.Cells[coned_offering_roster_Static.TCI_INSTRUCTOR_HOURS].FindControl("Label_instructor_hours") as Label);
            label_instructor_hours.Visible = true;
            if (label_instructor_hours.Text == "none")
              {
              label_instructor_hours.ForeColor = Color.LightGray;
              }
            }
          //
          link_button = (edit_update_cancel_controls[0] as LinkButton);
          link_button.Text = k.ExpandTildePath(link_button.Text);
          link_button.ToolTip = "Edit";
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
          var text_box_dob = (e.Item.Cells[coned_offering_roster_Static.TCI_DOB].FindControl("TextBox_dob") as TextBox);
          if (text_box_dob.Text == "REQUIRED")
            {
            text_box_dob.Text = k.EMPTY;
            }
          text_box_dob.Enabled = p.be_ok_to_edit_roster && (e.Item.Cells[coned_offering_roster_Static.TCI_BE_DOB_CONFIRMED].Text == "0");
          //
          var drop_down_list_county = e.Item.Cells[coned_offering_roster_Static.TCI_COUNTY_NAME].FindControl("DropDownList_county") as DropDownList;
          p.biz_counties.BindDirectToListControl(drop_down_list_county,"-- County --",e.Item.Cells[coned_offering_roster_Static.TCI_COUNTY_CODE].Text,k.EMPTY);
          //
          var text_box_email_address = (e.Item.Cells[coned_offering_roster_Static.TCI_EMAIL_ADDRESS].FindControl("TextBox_email_address") as TextBox);
          if (text_box_email_address.Text == "DESIRED")
            {
            text_box_email_address.Text = k.EMPTY;
            }
          //
          if (e.Item.Cells[coned_offering_roster_Static.TCI_BE_INSTRUCTOR].Text == "1")
            {
            var text_box_instructor_hours = (e.Item.Cells[coned_offering_roster_Static.TCI_INSTRUCTOR_HOURS].FindControl("TextBox_instructor_hours") as TextBox);
            text_box_instructor_hours.Visible = true;
            if (text_box_instructor_hours.Text == "none")
              {
              text_box_instructor_hours.Text = k.EMPTY;
              }
            text_box_instructor_hours.Enabled = p.be_ok_to_edit_roster;
            }
          }
        if (!(new ArrayList {"Active","Suspended"}).Contains(e.Item.Cells[coned_offering_roster_Static.TCI_STATUS_DESCRIPTION].Text))
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
        //e.Item.Cells[coned_offering_roster_Static.TCI_ID].EnableViewState = true;
        //
        p.num_attendees.val++;
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
        var practitioner_id = k.Safe(e.Item.Cells[coned_offering_roster_Static.TCI_PRACTITIONER_ID].Text,k.safe_hint_type.NUM);
        p.biz_coned_offering_rosters.Set
          (
          k.Safe(e.Item.Cells[coned_offering_roster_Static.TCI_ID].Text,k.safe_hint_type.NUM),
          p.coned_offering_id,
          practitioner_id,
          k.Safe((e.Item.Cells[coned_offering_roster_Static.TCI_INSTRUCTOR_HOURS].FindControl("TextBox_instructor_hours") as TextBox).Text.Replace("#.#",k.EMPTY),k.safe_hint_type.REAL_NUM)
          );
        p.biz_practitioners.SetFieldsNotImportedFromState
          (
          practitioner_id,
          DateTime.Parse(k.Safe((e.Item.Cells[coned_offering_roster_Static.TCI_DOB].FindControl("TextBox_dob") as TextBox).Text,k.safe_hint_type.DATE_TIME)),
          k.Safe((e.Item.Cells[coned_offering_roster_Static.TCI_COUNTY_CODE].FindControl("DropDownList_county") as DropDownList).SelectedValue,k.safe_hint_type.NUM),
          k.Safe((e.Item.Cells[coned_offering_roster_Static.TCI_EMAIL_ADDRESS].FindControl("TextBox_email_address") as TextBox).Text.Replace("user@domain.tld",k.EMPTY),k.safe_hint_type.EMAIL_ADDRESS)
          );
        DataGrid_control.EditItemIndex = -1;
        Bind();
        SetCloseAndSubmitAblementsAndVisibilities(p.be_ok_to_edit_roster);
        }
      else
        {
        ValidationAlert(be_using_scriptmanager:true);
        }
      }

    protected void DropDownList_other_roster_SelectedIndexChanged(object sender, EventArgs e)
      {
      p.other_roster_id = k.Safe(DropDownList_other_roster.SelectedValue,k.safe_hint_type.NUM);
      }

    protected void LinkButton_email_completion_documentation_Click(object sender, EventArgs e)
      {
      if (p.be_ceu_breakdown_valid)
        {
        var attendance_rec_q = new Queue<TClass_biz_coned_offering_rosters.attendance_rec_class>();
        var email_address_text = k.EMPTY;
        TableCellCollection tcc;
        for (var i = new k.subtype<int>(0,DataGrid_control.Items.Count); i.val < i.LAST; i.val++)
          {
          tcc = DataGrid_control.Items[i.val].Cells;
          email_address_text = k.Safe((tcc[coned_offering_roster_Static.TCI_EMAIL_ADDRESS].FindControl("Label_email_address") as Label).Text,k.safe_hint_type.EMAIL_ADDRESS);
          if ((email_address_text != "DESIRED") && (tcc[coned_offering_roster_Static.TCI_SELECT].FindControl("CheckBox_selected") as CheckBox).Checked)
            {
            var attendance_rec = new TClass_biz_coned_offering_rosters.attendance_rec_class();
            attendance_rec.certification_number = k.Safe(tcc[coned_offering_roster_Static.TCI_CERT_NUM].Text,k.safe_hint_type.NUM);
            attendance_rec.dob = k.Safe((tcc[coned_offering_roster_Static.TCI_DOB].FindControl("Label_dob") as Label).Text,k.safe_hint_type.DATE_TIME);
            attendance_rec.first_name = k.Safe(tcc[coned_offering_roster_Static.TCI_FIRST_NAME].Text,k.safe_hint_type.HUMAN_NAME);
            attendance_rec.last_name = k.Safe(tcc[coned_offering_roster_Static.TCI_LAST_NAME].Text,k.safe_hint_type.HUMAN_NAME);
            attendance_rec.level_emsrs_code = k.Safe(tcc[coned_offering_roster_Static.TCI_LEVEL_EMSRS_CODE].Text,k.safe_hint_type.NUM);
            attendance_rec.level_short_description = k.Safe(tcc[coned_offering_roster_Static.TCI_LEVEL].Text,k.safe_hint_type.HYPHENATED_ALPHANUM);
            attendance_rec.middle_initial = k.Safe(tcc[coned_offering_roster_Static.TCI_MIDDLE_INITIAL].Text,k.safe_hint_type.ALPHA);
            attendance_rec.instructor_hours = k.Safe((tcc[coned_offering_roster_Static.TCI_INSTRUCTOR_HOURS].FindControl("Label_instructor_hours") as Label).Text,k.safe_hint_type.REAL_NUM);
            attendance_rec.email_address = email_address_text;
            attendance_rec_q.Enqueue(attendance_rec);
            }
          }
        if (attendance_rec_q.Count > 0)
          {
          p.biz_coned_offering_rosters.SendTrainingCertificates
            (
            attendance_rec_q:attendance_rec_q,
            sponsor_name:Session["coned_sponsor_name"].ToString(),
            sponsor_number:p.biz_teaching_entities.SponsorNumberOfId(p.biz_user.IdNum()),
            reply_to_email_address:p.user_email_address,
            class_number:p.biz_coned_offerings.ClassNumberOf(p.incoming.summary),
            course_title:Literal_course_title.Text,
            date_final:Literal_end.Text,
            fr_med_trauma_ceus:decimal.Parse(p.biz_coned_offerings.FrMedTraumaHoursOf(p.incoming.summary)),
            fr_other_ceus:decimal.Parse(p.biz_coned_offerings.FrOtherHoursOf(p.incoming.summary)),
            emt_med_trauma_ceus:decimal.Parse(p.biz_coned_offerings.EmtMedTraumaHoursOf(p.incoming.summary)),
            emt_other_ceus:decimal.Parse(p.biz_coned_offerings.EmtOtherHoursOf(p.incoming.summary)),
            emtp_med_trauma_ceus:decimal.Parse(p.biz_coned_offerings.EmtpMedTraumaHoursOf(p.incoming.summary)),
            emtp_other_ceus:decimal.Parse(p.biz_coned_offerings.EmtpOtherHoursOf(p.incoming.summary)),
            phrn_med_trauma_ceus:decimal.Parse(p.biz_coned_offerings.PhrnMedTraumaHoursOf(p.incoming.summary)),
            phrn_other_ceus:decimal.Parse(p.biz_coned_offerings.PhrnOtherHoursOf(p.incoming.summary)),
            working_directory:Server.MapPath("scratch")
            );
          Alert(k.alert_cause_type.LOGIC,k.alert_state_type.NORMAL,"certssent","Certificate(s) sent",be_using_scriptmanager:true);
          }
        else
          {
          Alert(k.alert_cause_type.USER,k.alert_state_type.FAILURE,"norecipts","Certificate(s) *NOT* sent.  No recipients are selected.",be_using_scriptmanager:true);
          }
        }
      else
        {
        Alert(k.alert_cause_type.APPDATA,k.alert_state_type.WARNING,"badceudata","The breakdown of CEUs as imported from EMSRS is invalid.  No certificates can be generated.",be_using_scriptmanager:true);
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
        p.biz_accounts = new TClass_biz_accounts();
        p.biz_coned_offering_rosters = new TClass_biz_coned_offering_rosters();
        p.biz_coned_offerings = new TClass_biz_coned_offerings();
        p.biz_counties = new TClass_biz_counties();
        p.biz_practitioners = new TClass_biz_practitioners();
        p.biz_teaching_entities = new TClass_biz_teaching_entities();
        p.biz_user = new TClass_biz_user();
        //
        p.be_noncurrent_practitioners_on_roster = false;
        p.be_sort_order_ascending = true;
        p.incoming = Message<TClass_msg_protected.coned_offering_roster>(folder_name:"protected",aspx_name:"coned_offering_roster");
        p.num_attendees = new k.int_nonnegative();
        p.num_attendees_with_known_birth_dates = new k.int_nonnegative();
        p.other_roster_id = k.EMPTY;
        p.region_code = Session["region_code"].ToString();
        p.roster_id_arraylist = new ArrayList();
        p.sort_order = "id desc";
        p.user_email_address = p.biz_accounts.EmailAddressByKindId(p.biz_user.Kind(),p.biz_user.IdNum());
        //
        p.be_ceu_breakdown_valid = p.biz_coned_offerings.BeCeuBreakdownValid(p.incoming.summary);
        p.be_ok_to_edit_roster = p.biz_coned_offerings.BeOkToEditRoster(p.incoming.summary);
        p.coned_offering_id = p.biz_coned_offerings.IdOf(p.incoming.summary);
        p.length = p.biz_coned_offerings.LengthOf(p.incoming.summary);
        }
      else if (nature_of_visit == nature_of_visit_type.VISIT_POSTBACK_STANDARD)
        {
        p = (p_type)(Session[InstanceId() + ".p"]);
        }
//
//ToolkitScriptManager.GetCurrent(Page).EnablePartialRendering = false;
//
      }

    protected void Page_Load(object sender, System.EventArgs e)
      {
      if (!IsPostBack)
        {
        Title = Server.HtmlEncode(ConfigurationManager.AppSettings["application_name"]) + " - coned_offering_roster";
        var be_ok_to_input_batch = p.biz_accounts.BeOkForConedSponsorToInputRosterByBatch();
        var be_ok_to_input_copy = p.biz_accounts.BeOkForConedSponsorToInputRosterByCopy();
        RadioButtonList_input_method.Items.FindByValue("Batch").Enabled = be_ok_to_input_batch;
        RadioButtonList_input_method.Items.FindByValue("Copy").Enabled = be_ok_to_input_copy;
        p.biz_coned_offerings.BindDirectToListControlForCopy(p.coned_offering_id,DropDownList_other_roster);
        Panel_input_method.Visible = (be_ok_to_input_batch || be_ok_to_input_copy);
        var max_spec_length = p.biz_practitioners.MaxSpecLength(p.region_code,k.EMPTY);
        TextBox_practitioner.Width = new Unit(max_spec_length.val*0.535,UnitType.Em);
        ListBox_practitioner.Width = new Unit(max_spec_length.val*0.650,UnitType.Em);
        InitForNewSearch();
        Literal_course_title.Text = p.biz_coned_offerings.CourseTitleOf(p.incoming.summary);
        Literal_class_number.Text = p.biz_coned_offerings.StandardSafeRenditionOf(p.biz_coned_offerings.ClassNumberOf(p.incoming.summary));
        Literal_location.Text = p.biz_coned_offerings.LocationOf(p.incoming.summary);
        Literal_start.Text = p.biz_coned_offerings.StartDateOf(p.incoming.summary) + k.SPACE + p.biz_coned_offerings.StartOtherOf(p.incoming.summary);
        Literal_end.Text = p.biz_coned_offerings.EndDateOf(p.incoming.summary) + k.SPACE + p.biz_coned_offerings.EndOtherOf(p.incoming.summary);
        RequireConfirmation(Button_mark_class_canceled,"If you proceed, this class will disappear from " + ConfigurationManager.AppSettings["application_name"] + " and the class will be marked as CANCELED in the state EMSRS.");
        ToolkitScriptManager.GetCurrent(Page).RegisterPostBackControl(Button_mark_class_canceled);
        Literal_length.Text = p.length.val.ToString();
        Literal_be_approved.Text = k.YesNoOf(p.biz_coned_offerings.BeApprovedOf(p.incoming.summary));
        //
        var hash_table = new Hashtable();
        hash_table["coned_offering_id"] = p.biz_coned_offerings.IdOf(p.incoming.summary);
        HyperLink_print_roster.NavigateUrl = "~/protected/hardcopy_roster.aspx?" + ShieldedQueryStringOfHashtable(hash_table);
        //
        Bind();
        SetCloseAndSubmitAblementsAndVisibilities(p.be_ok_to_edit_roster);
        RequireConfirmation
          (
          Button_close_and_submit,
          "Closing this class will prevent you from adding or removing practitioners from the roster, and from editing any birth dates or instructor hours." + k.NEW_LINE
          + k.NEW_LINE
          + "To proceed, click OK:"
          );
        Literal_author_email_address.Text = p.user_email_address;
        }
      InjectPersistentClientSideScript();
      }

    protected void RadioButtonList_input_method_SelectedIndexChanged(object sender, EventArgs e)
      {
      ManageInputPanels();
      }

    protected void TextBox_practitioner_TextChanged(object sender, EventArgs e)
      {
      DataGrid_control.EditItemIndex = -1;
      Bind();
      SetCloseAndSubmitAblementsAndVisibilities(p.be_ok_to_edit_roster);
      UpdatePanel_attendees.Update();
      //
      var practitioner = k.Safe(TextBox_practitioner.Text,k.safe_hint_type.PUNCTUATED);
      p.biz_practitioners.BindDirectToListControlForRoster(ListBox_practitioner,p.region_code,practitioner,new k.int_positive(12));
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

    } // end TWebForm_coned_offering_roster

  }