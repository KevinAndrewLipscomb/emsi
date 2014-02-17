// Derived from KiAspdotnetFramework/UserControl/app/UserControl~template~kicrudhelped~item.ascx.cs~template

using AjaxControlToolkit;
using Class_biz_counties;
using Class_biz_practitioner_levels;
using Class_biz_practitioners;
using Class_biz_regions;
using Class_msg_protected;
using kix;
using System;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserControl_practitioner
  {

  public partial class TWebUserControl_practitioner: ki_web_ui.usercontrol_class
    {

    private struct p_type
      {
      public bool be_educational_reservist_or_higher;
      public bool be_loaded;
      public bool be_ok_to_config_practitioners;
      public bool be_ok_to_config_practitioner_coned_details;
      public TClass_biz_counties biz_counties;
      public TClass_biz_practitioners biz_practitioners;
      public TClass_biz_practitioner_levels biz_practitioner_levels;
      public TClass_biz_regions biz_regions;
      public TClass_msg_protected.change_practitioner_email_address msg_protected_change_practitioner_email_address;
      public string id;
      public string user_sponsor_id_filter;
      }

    private p_type p;

    private void Clear()
      {
      TextBox_id.Text = k.EMPTY;
      DropDownList_id.Visible = false;
      TextBox_last_name.Text = k.EMPTY;
      TextBox_first_name.Text = k.EMPTY;
      TextBox_middle_initial.Text = k.EMPTY;
      TextBox_certification_number.Text = k.EMPTY;
      DropDownList_level.ClearSelection();
      DropDownList_regional_council.ClearSelection();
      UserControl_drop_down_date_birth_date.Clear();
      TextBox_email_address.Text = k.EMPTY;
      CheckBox_be_stale.Checked = false;
      DropDownList_residence_county.ClearSelection();
      CheckBox_be_birth_date_confirmed.Checked = false;
      TextBox_street_address_1.Text = k.EMPTY;
      TextBox_street_address_2.Text = k.EMPTY;
      TextBox_city_state_zip.Text = k.EMPTY;
      CheckBox_be_instructor.Checked = false;
      CheckBox_be_past.Checked = false;
      UserControl_practitioner_coned_detail_control.SetTarget
        (
        practitioner_id:k.EMPTY,
        user_sponsor_id_filter:p.user_sponsor_id_filter
        );
      Literal_match_index.Text = k.EMPTY;
      Literal_num_matches.Text = k.EMPTY;
      Panel_match_numbers.Visible = false;
      LinkButton_go_to_match_prior.Visible = false;
      LinkButton_go_to_match_next.Visible = false;
      LinkButton_go_to_match_last.Visible = false;
      LinkButton_go_to_match_first.Visible = false;
      SetDependentFieldAblements(false);
      LinkButton_change_email_address.Visible = false;
      Button_submit.Enabled = false;
      Button_delete.Enabled = false;
      p.id = k.EMPTY;
      }

    private void InjectPersistentClientSideScript()
      {
      // EstablishClientSideFunction(k.client_side_function_enumeral_type.EL);
      // EstablishClientSideFunction(k.client_side_function_enumeral_type.KGS_TO_LBS);
      // EstablishClientSideFunction(k.client_side_function_enumeral_type.LBS_TO_KGS);
      // EstablishClientSideFunction
      //   (
      //   'RecalculateDependentValues()',
      //   k.EMPTY
      //   + 'El("' + TextBox_gain_or_loss_in_lbs.clientid + '").value ='
      //   +  ' El("' + TextBox_gross_landed_weight_in_pounds.clientid + '").value - El("' + TextBox_gross_invoiced_weight_in_lbs.clientid + '").value;'
      //   + k.NEW_LINE
      //   + 'El("' + TextBox_gain_or_loss_in_kgs.clientid + '").value ='
      //   +  ' El("' + TextBox_gross_landed_weight_in_kgs.clientid + '").value - El("' + TextBox_gross_invoiced_weight_in_kgs.clientid + '").value;'
      //   + k.NEW_LINE
      //   + 'El("' + TextBox_gain_or_loss_per_bale_in_lbs.clientid + '").value ='
      //   +  ' El("' + TextBox_gain_or_loss_in_lbs.clientid + '").value/El("' + TextBox_bales.clientid + '").value;'
      //   + k.NEW_LINE
      //   + 'El("' + TextBox_gain_or_loss_per_bale_in_kgs.clientid + '").value ='
      //   +  ' El("' + TextBox_gain_or_loss_in_kgs.clientid + '").value/El("' + TextBox_bales.clientid + '").value;'
      //   + k.NEW_LINE
      //   + 'El("' + TextBox_actual_gain_or_loss_in_lbs.clientid + '").value ='
      //   +  ' El("' + TextBox_gain_or_loss_in_lbs.clientid + '").value - El("' + TextBox_franchise_in_lbs.clientid + '").value;'
      //   + k.NEW_LINE
      //   + 'El("' + TextBox_actual_gain_or_loss_in_kgs.clientid + '").value ='
      //   +  ' El("' + TextBox_gain_or_loss_in_kgs.clientid + '").value - El("' + TextBox_franchise_in_kgs.clientid + '").value;'
      //   + k.NEW_LINE
      //   + 'El("' + TextBox_actual_gain_or_loss_per_bale_in_lbs.clientid + '").value ='
      //   +  ' El("' + TextBox_actual_gain_or_loss_in_lbs.clientid + '").value/El("' + TextBox_bales.clientid + '").value;'
      //   + k.NEW_LINE
      //   + 'El("' + TextBox_actual_gain_or_loss_per_bale_in_kgs.clientid + '").value ='
      //   +  ' El("' + TextBox_actual_gain_or_loss_in_kgs.clientid + '").value/El("' + TextBox_bales.clientid + '").value;'
      //   + k.NEW_LINE
      //   + 'El("' + TextBox_percent_gain_or_loss.clientid + '").value ='
      //   +  ' Math.round(El("' + TextBox_actual_gain_or_loss_in_lbs.clientid + '").value/El("' + TextBox_net_invoiced_in_lbs.clientid + '").value*100*100)/100;'
      //   + k.NEW_LINE
      //   + 'El("' + TextBox_monetary_gain_or_loss.clientid + '").value ='
      //   +  ' El("' + TextBox_actual_gain_or_loss_in_lbs.clientid + '").value*El("' + TextBox_unit_price_in_cents_per_pound.clientid + '").value;'
      //   );
      // //
      // TextBox_bales.attributes.Add('onkeyup','RecalculateDependentValues();');
      // TextBox_gross_landed_weight_in_pounds.attributes.Add
      //   (
      //   'onkeyup',
      //   'El("' + TextBox_gross_landed_weight_in_kgs.clientid + '").value = LbsToKgs(El("' + TextBox_gross_landed_weight_in_pounds.clientid + '").value);'
      //   + ' RecalculateDependentValues();'
      //   );
      // TextBox_gross_landed_weight_in_kgs.attributes.Add
      //   (
      //   'onkeyup',
      //   'El("' + TextBox_gross_landed_weight_in_pounds.clientid + '").value = KgsToLbs(El("' + TextBox_gross_landed_weight_in_kgs.clientid + '").value);'
      //   + ' RecalculateDependentValues();'
      //   );
      // TextBox_landed_or_ciq_tare.attributes.Add
      //   (
      //   'onkeyup',
      //   'El("' + TextBox_landed_or_ciq_tare_in_kgs.clientid + '").value = LbsToKgs(El("' + TextBox_landed_or_ciq_tare.clientid + '").value);'
      //   + ' RecalculateDependentValues();'
      //   );
      // TextBox_landed_or_ciq_tare_in_kgs.attributes.Add
      //   (
      //   'onkeyup',
      //   'El("' + TextBox_landed_or_ciq_tare.clientid + '").value = KgsToLbs(El("' + TextBox_landed_or_ciq_tare_in_kgs.clientid + '").value);'
      //   + ' RecalculateDependentValues();'
      //   );
      // TextBox_net_landed_in_pounds.attributes.Add
      //   (
      //   'onkeyup',
      //   'El("' + TextBox_net_landed_in_kgs.clientid + '").value = LbsToKgs(El("' + TextBox_net_landed_in_pounds.clientid + '").value);'
      //   + ' RecalculateDependentValues();'
      //   );
      // TextBox_net_landed_in_kgs.attributes.Add
      //   (
      //   'onkeyup',
      //   'El("' + TextBox_net_landed_in_pounds.clientid + '").value = KgsToLbs(El("' + TextBox_net_landed_in_kgs.clientid + '").value);'
      //   + ' RecalculateDependentValues();'
      //   );
      }

    protected void Page_Load(object sender, System.EventArgs e)
      {
      if (!p.be_loaded)
        {
        LinkButton_new_record.Visible = p.be_ok_to_config_practitioners;
        LinkButton_go_to_match_first.Text = k.ExpandTildePath(LinkButton_go_to_match_first.Text);
        LinkButton_go_to_match_prior.Text = k.ExpandTildePath(LinkButton_go_to_match_prior.Text);
        LinkButton_go_to_match_next.Text = k.ExpandTildePath(LinkButton_go_to_match_next.Text);
        LinkButton_go_to_match_last.Text = k.ExpandTildePath(LinkButton_go_to_match_last.Text);
        p.biz_practitioner_levels.BindDirectToListControl(DropDownList_level);
        p.biz_regions.BindDirectToListControl
          (
          target:DropDownList_regional_council,
          unselected_literal:"-- region --",
          selected_value:k.EMPTY,
          application_filter:k.EMPTY
          );
        p.biz_counties.BindDirectToListControl(DropDownList_residence_county);
        UserControl_drop_down_date_birth_date.minyear = DateTime.Today.AddYears(-130).Year.ToString();
        UserControl_drop_down_date_birth_date.maxyear = DateTime.Today.AddYears(-16).Year.ToString();
        TableRow_birth_date_confirmed.Visible = p.be_educational_reservist_or_higher;
        TableRow_street_address_1.Visible = p.be_educational_reservist_or_higher;
        TableRow_street_address_2.Visible = p.be_educational_reservist_or_higher;
        TableRow_city_state_zip.Visible = p.be_educational_reservist_or_higher;
        TableRow_be_stale.Visible = p.be_educational_reservist_or_higher;
        TableRow_be_past.Visible = p.be_educational_reservist_or_higher;
        Literal_application_name.Text = ConfigurationManager.AppSettings["application_name"];
        Literal_application_name_2.Text = Literal_application_name.Text;
        RequireConfirmation(Button_delete, "Are you sure you want to delete this record?");
        if (p.id.Length > 0)
          {
          PresentRecord(p.id);
          }
        else
          {
          TextBox_id.Focus();
          }
        p.be_loaded = true;
        }
      InjectPersistentClientSideScript();
      ToolkitScriptManager.GetCurrent(Page).RegisterPostBackControl(LinkButton_change_email_address);
      }

    public bool PresentRecord(string id)
      {
      Literal_match_index.Text = DropDownList_id.SelectedIndex.ToString();
      bool result;
      string last_name;
      string first_name;
      string middle_initial;
      string certification_number;
      string level_id;
      string regional_council_code;
      DateTime birth_date;
      string email_address;
      bool be_stale;
      string residence_county_code;
      bool be_birth_date_confirmed;
      string street_address_1;
      string street_address_2;
      string city_state_zip;
      bool be_instructor;
      bool be_past;
      result = false;
      if
        (
        p.biz_practitioners.Get
          (
          id,
          out last_name,
          out first_name,
          out middle_initial,
          out certification_number,
          out level_id,
          out regional_council_code,
          out birth_date,
          out email_address,
          out be_stale,
          out residence_county_code,
          out be_birth_date_confirmed,
          out street_address_1,
          out street_address_2,
          out city_state_zip,
          out be_instructor,
          out be_past
          )
        )
        {
        TextBox_id.Text = id;
        TextBox_id.Enabled = false;
        TextBox_last_name.Text = last_name;
        TextBox_first_name.Text = first_name;
        TextBox_middle_initial.Text = middle_initial;
        TextBox_certification_number.Text = certification_number;
        DropDownList_level.SelectedValue = level_id;
        DropDownList_regional_council.SelectedValue = regional_council_code;
        UserControl_drop_down_date_birth_date.selectedvalue = birth_date;
        TextBox_email_address.Text = email_address;
        CheckBox_be_stale.Checked = be_stale;
        DropDownList_residence_county.SelectedValue = residence_county_code;
        CheckBox_be_birth_date_confirmed.Checked = be_birth_date_confirmed;
        TextBox_street_address_1.Text = street_address_1;
        TextBox_street_address_2.Text = street_address_2;
        TextBox_city_state_zip.Text = city_state_zip;
        CheckBox_be_instructor.Checked = be_instructor;
        CheckBox_be_past.Checked = be_past;
        UserControl_practitioner_coned_detail_control.SetTarget
          (
          practitioner_id:id,
          user_sponsor_id_filter:p.user_sponsor_id_filter
          );
        Button_lookup.Enabled = false;
        Label_lookup_arrow.Enabled = false;
        Label_lookup_hint.Enabled = false;
        LinkButton_reset.Enabled = true;
        SetDependentFieldAblements(p.be_ok_to_config_practitioners);
        var regional_council = k.Safe(DropDownList_regional_council.SelectedValue,k.safe_hint_type.NUM);
        LinkButton_change_email_address.Visible = true;
        Button_submit.Enabled = p.be_ok_to_config_practitioners;
        Button_delete.Enabled = p.be_ok_to_config_practitioners;
        result = true;
        p.id = id;
        }
      return result;
      }

    private void SetDataEntryMode()
      {
      Clear();
      TextBox_id.Text = "*";
      TextBox_id.Enabled = false;
      Button_lookup.Enabled = false;
      Label_lookup_arrow.Enabled = false;
      Label_lookup_hint.Enabled = false;
      LinkButton_reset.Enabled = true;
      LinkButton_new_record.Enabled = false;
      SetDependentFieldAblements(p.be_ok_to_config_practitioners);
      Button_submit.Enabled = p.be_ok_to_config_practitioners;
      Button_delete.Enabled = false;
      TextBox_id.Focus();
      }

    private void SetLookupMode()
      {
      Clear();
      TextBox_id.Enabled = true;
      Button_lookup.Enabled = true;
      Label_lookup_arrow.Enabled = true;
      Label_lookup_hint.Enabled = true;
      LinkButton_reset.Enabled = false;
      LinkButton_new_record.Enabled = true;
      UserControl_practitioner_coned_detail_control.SetTarget
        (
        practitioner_id:k.EMPTY,
        user_sponsor_id_filter:p.user_sponsor_id_filter
        );
      TextBox_id.Focus();
      }

    internal void SetTarget(string target)
      {
      var id = target.Substring(target.LastIndexOf("/") + 1);
      if (id.Length > 0)
        {
        p.id = id;
        UserControl_practitioner_coned_detail_control.SetTarget
          (
          practitioner_id:p.id,
          user_sponsor_id_filter:p.user_sponsor_id_filter
          );
        }
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
        if (instance_id == "ASP.protected_regional_staffer_overview_aspx.UserControl_regional_staffer_binder_control_practitioner")
          {
          p.be_loaded &= ((Session["UserControl_regional_staffer_binder_PlaceHolder_content"] as string) == "UserControl_practitioner");
          }
        else if (instance_id == "ASP.protected_coned_sponsor_overview_aspx.UserControl_coned_sponsor_binder_control_practitioner")
          {
          p.be_loaded &= ((Session["UserControl_coned_sponsor_binder_control_PlaceHolder_content"] as string) == "UserControl_practitioner");
          }
        }
      else
        {
        p.be_loaded = false;
        //
        p.biz_counties = new TClass_biz_counties();
        p.biz_practitioners = new TClass_biz_practitioners();
        p.biz_practitioner_levels = new TClass_biz_practitioner_levels();
        p.biz_regions = new TClass_biz_regions();
        p.msg_protected_change_practitioner_email_address = new TClass_msg_protected.change_practitioner_email_address();
        //
        p.be_educational_reservist_or_higher = HttpContext.Current.User.IsInRole("director")
        || HttpContext.Current.User.IsInRole("education-coordinator")
        || HttpContext.Current.User.IsInRole("education-specialist")
        || HttpContext.Current.User.IsInRole("education-reservist");
        p.be_ok_to_config_practitioners = k.Has((string[])(Session["privilege_array"]), "config-practitioners");
        p.be_ok_to_config_practitioner_coned_details = k.Has((string[])(Session["privilege_array"]), "config-practitioner-coned-details");
        p.id = k.EMPTY;
        p.user_sponsor_id_filter = k.EMPTY;
        //
        Clear();
        }
      }

    // / <summary>
    // / Required method for Designer support -- do not modify
    // / the contents of this method with the code editor.
    // / </summary>
    private void InitializeComponent()
      {
      //this.Load += this.Page_Load;
      this.PreRender += this.TWebUserControl_practitioner_PreRender;
      }

    private void TWebUserControl_practitioner_PreRender(object sender, System.EventArgs e)
      {
      SessionSet(InstanceId() + ".p", p);
      }

    public TWebUserControl_practitioner Fresh()
      {
      Session.Remove(InstanceId() + ".p");
      UserControl_drop_down_date_birth_date.Fresh();
      return this;
      }

    protected void Button_submit_Click(object sender, System.EventArgs e)
      {
      if (Page.IsValid)
        {
        p.biz_practitioners.Set
          (
          k.Safe(TextBox_id.Text,k.safe_hint_type.NUM),
          k.Safe(TextBox_last_name.Text,k.safe_hint_type.HUMAN_NAME).Trim(),
          k.Safe(TextBox_first_name.Text,k.safe_hint_type.HUMAN_NAME).Trim(),
          k.Safe(TextBox_middle_initial.Text,k.safe_hint_type.ALPHA),
          k.Safe(TextBox_certification_number.Text,k.safe_hint_type.NUM),
          k.Safe(DropDownList_level.SelectedValue,k.safe_hint_type.NUM),
          k.Safe(DropDownList_regional_council.SelectedValue,k.safe_hint_type.NUM),
          UserControl_drop_down_date_birth_date.selectedvalue,
          k.Safe(TextBox_email_address.Text,k.safe_hint_type.EMAIL_ADDRESS),
          CheckBox_be_stale.Checked,
          k.Safe(DropDownList_residence_county.SelectedValue,k.safe_hint_type.EMAIL_ADDRESS),
          CheckBox_be_birth_date_confirmed.Checked,
          k.Safe(TextBox_street_address_1.Text,k.safe_hint_type.POSTAL_STREET_ADDRESS),
          k.Safe(TextBox_street_address_2.Text,k.safe_hint_type.POSTAL_STREET_ADDRESS),
          k.Safe(TextBox_city_state_zip.Text,k.safe_hint_type.POSTAL_CITY),
          CheckBox_be_instructor.Checked,
          CheckBox_be_past.Checked
          );
        Alert(k.alert_cause_type.USER, k.alert_state_type.SUCCESS, "recsaved", "Record saved.", true);
        SetLookupMode();
        }
      else
        {
        ValidationAlert(true);
        }
      }

    protected void DropDownList_id_SelectedIndexChanged(object sender, System.EventArgs e)
      {
      PresentRecord(k.Safe(DropDownList_id.SelectedValue, k.safe_hint_type.NUM));
      }

    protected void LinkButton_go_to_match_first_Click(object sender, System.EventArgs e)
      {
      DropDownList_id.SelectedIndex = 1;
      PresentRecord(k.Safe(DropDownList_id.SelectedValue, k.safe_hint_type.NUM));
      }

    protected void LinkButton_go_to_match_prior_Click(object sender, System.EventArgs e)
      {
      DropDownList_id.SelectedIndex = Math.Max(1, (DropDownList_id.SelectedIndex - 1));
      PresentRecord(k.Safe(DropDownList_id.SelectedValue, k.safe_hint_type.NUM));
      }

    protected void LinkButton_go_to_match_next_Click(object sender, System.EventArgs e)
      {
      DropDownList_id.SelectedIndex = Math.Min((DropDownList_id.SelectedIndex + 1), (DropDownList_id.Items.Count - 1));
      PresentRecord(k.Safe(DropDownList_id.SelectedValue, k.safe_hint_type.NUM));
      }

    protected void LinkButton_go_to_match_last_Click(object sender, System.EventArgs e)
      {
      DropDownList_id.SelectedIndex = DropDownList_id.Items.Count - 1;
      PresentRecord(k.Safe(DropDownList_id.SelectedValue, k.safe_hint_type.NUM));
      }

    protected void Button_delete_Click(object sender, System.EventArgs e)
      {
      if (p.biz_practitioners.Delete(k.Safe(TextBox_id.Text, k.safe_hint_type.NUM)))
        {
        SetLookupMode();
        }
      else
        {
        Alert(k.alert_cause_type.APPDATA,k.alert_state_type.FAILURE, "dependency", " Cannot delete this record because another record depends on it.", true);
        }
      }

    protected void LinkButton_new_record_Click(object sender, System.EventArgs e)
      {
      SetDataEntryMode();
      }

    protected void LinkButton_reset_Click(object sender, System.EventArgs e)
      {
      SetLookupMode();
      }

    private void SetDependentFieldAblements(bool ablement)
      {
      TextBox_last_name.Enabled = ablement;
      TextBox_first_name.Enabled = ablement;
      TextBox_middle_initial.Enabled = ablement;
      TextBox_certification_number.Enabled = ablement;
      DropDownList_level.Enabled = ablement;
      DropDownList_regional_council.Enabled = ablement;
      UserControl_drop_down_date_birth_date.enabled = ablement;
      TextBox_email_address.Enabled = ablement;
      CheckBox_be_stale.Enabled = ablement;
      DropDownList_residence_county.Enabled = ablement;
      CheckBox_be_birth_date_confirmed.Enabled = ablement;
      TextBox_street_address_1.Enabled = ablement;
      TextBox_street_address_2.Enabled = ablement;
      TextBox_city_state_zip.Enabled = ablement;
      CheckBox_be_instructor.Enabled = ablement;
      CheckBox_be_past.Enabled = ablement;
      }

    protected void Button_lookup_Click(object sender, System.EventArgs e)
      {
      var saved_id = k.Safe(TextBox_id.Text,k.safe_hint_type.PUNCTUATED);
      Clear();
      if (!PresentRecord(saved_id))
        {
        TextBox_id.Text = saved_id;
        p.biz_practitioners.Bind
          (
          partial_spec:saved_id,
          target:DropDownList_id,
          sponsor_id_filter:p.user_sponsor_id_filter
          );
        var num_matches = (uint)(DropDownList_id.Items.Count);
        if (num_matches > 0)
          {
          DropDownList_id.Visible = true;
          if (num_matches == 1)
            {
            PresentRecord(k.Safe(DropDownList_id.SelectedValue, k.safe_hint_type.NUM));
            }
          else
            {
            Literal_match_index.Text = "0";
            Literal_num_matches.Text = num_matches.ToString();
            Panel_match_numbers.Visible = true;
            LinkButton_go_to_match_prior.Visible = true;
            LinkButton_go_to_match_next.Visible = true;
            LinkButton_go_to_match_last.Visible = true;
            LinkButton_go_to_match_first.Visible = true;
            DropDownList_id.Items.Insert(0, new ListItem("-- Select --", k.EMPTY));
            }
          }
        }
      }

    protected void CustomValidator_email_address_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
      {
      args.IsValid = k.BeValidDomainPartOfEmailAddress(k.Safe(TextBox_email_address.Text, k.safe_hint_type.EMAIL_ADDRESS));
      }

    internal void Set(string user_sponsor_id_filter)
      {
      p.user_sponsor_id_filter = user_sponsor_id_filter;
      }

    protected void LinkButton_change_email_address_Click(object sender, EventArgs e)
      {
      p.msg_protected_change_practitioner_email_address.practitioner_summary = p.biz_practitioners.Summary(k.Safe(TextBox_id.Text,k.safe_hint_type.NUM));
      MessageDropCrumbAndTransferTo
        (
        msg:p.msg_protected_change_practitioner_email_address,
        folder_name:"protected",
        aspx_name:"change_practitioner_email_address"
        );
      }

    } // end TWebUserControl_practitioner

  }
