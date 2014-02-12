// Derived from KiAspdotnetFramework/UserControl/app/UserControl~template~kicrudhelped~item.ascx.cs~template

using Class_biz_practitioner_strike_team_details;
using Class_biz_role_member_map;
using Class_biz_sms_gateways;
using kix;
using System;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserControl_practitioner_strike_team_detail
  {
  public partial class TWebUserControl_practitioner_strike_team_detail: ki_web_ui.usercontrol_class
    {
    private struct p_type
      {
      public bool be_loaded;
      public TClass_biz_practitioner_strike_team_details biz_practitioner_strike_team_details;
      public TClass_biz_role_member_map biz_role_member_map;
      public TClass_biz_sms_gateways biz_sms_gateways;
      public bool be_ok_to_config_practitioner_strike_team_details;
      public string practitioner_id;
      }

    private p_type p;

    internal void Clear()
      {
      TextBox_practitioner_id.Text = k.EMPTY;
      DropDownList_practitioner_id.Visible = false;
      UserControl_drop_down_date_act_1985_33_date.Clear();
      UserControl_drop_down_date_act_1985_34_date.Clear();
      UserControl_drop_down_date_act_1994_151_date.Clear();
      TextBox_phone_number.Text = k.EMPTY;
      DropDownList_phone_service.ClearSelection();
      CheckBox_be_immune_hepatitis_b.Checked = false;
      CheckBox_be_immune_diptheria_tetanus.Checked = false;
      TextBox_emergency_contact_1_name.Text = k.EMPTY;
      TextBox_emergency_contact_1_phone_number.Text = k.EMPTY;
      TextBox_emergency_contact_2_name.Text = k.EMPTY;
      TextBox_emergency_contact_2_phone_number.Text = k.EMPTY;
      TextBox_meds_doses.Text = k.EMPTY;
      TextBox_allergies.Text = k.EMPTY;
      TextBox_pcp_name.Text = k.EMPTY;
      UserControl_drop_down_date_drivers_license_expiration.Clear();
      UserControl_drop_down_date_nims_is_100_date.Clear();
      UserControl_drop_down_date_nims_is_200_date.Clear();
      UserControl_drop_down_date_nims_is_700_date.Clear();
      UserControl_drop_down_date_nims_is_800_date.Clear();
      UserControl_drop_down_date_lms_disaster_stress_response_date.Clear();
      UserControl_drop_down_date_lms_ems_mci_ops_date.Clear();
      UserControl_drop_down_date_lms_wmd_date.Clear();
      UserControl_drop_down_date_lms_smallpox_date.Clear();
      UserControl_drop_down_date_lms_basic_med_terrorism_response_date.Clear();
      UserControl_drop_down_date_lms_electrical_hazards_date.Clear();
      UserControl_drop_down_date_lms_ems_bioterror_date.Clear();
      UserControl_drop_down_date_nims_ics_300_date.Clear();
      UserControl_drop_down_date_nims_ics_400_date.Clear();
      UserControl_drop_down_date_pa_psychological_first_aid_date.Clear();
      UserControl_drop_down_date_pa_water_rescue_awareness_date.Clear();
      UserControl_drop_down_date_pa_hazmat_awareness_date.Clear();
      UserControl_drop_down_date_pa_ems_strike_team_leader_date.Clear();
      UserControl_drop_down_date_two_years_supervisory_experience_date.Clear();
      Literal_match_index.Text = k.EMPTY;
      Literal_num_matches.Text = k.EMPTY;
      Panel_match_numbers.Visible = false;
      LinkButton_go_to_match_prior.Visible = false;
      LinkButton_go_to_match_next.Visible = false;
      LinkButton_go_to_match_last.Visible = false;
      LinkButton_go_to_match_first.Visible = false;
      SetDependentFieldAblements(false);
      Button_submit.Enabled = false;
      Button_delete.Enabled = false;
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
        LinkButton_new_record.Visible = p.be_ok_to_config_practitioner_strike_team_details;
        LinkButton_go_to_match_first.Text = k.ExpandTildePath(LinkButton_go_to_match_first.Text);
        LinkButton_go_to_match_prior.Text = k.ExpandTildePath(LinkButton_go_to_match_prior.Text);
        LinkButton_go_to_match_next.Text = k.ExpandTildePath(LinkButton_go_to_match_next.Text);
        LinkButton_go_to_match_last.Text = k.ExpandTildePath(LinkButton_go_to_match_last.Text);
        //
        var three_year_ago = DateTime.Now.AddYears(-3).Year.ToString();
        var this_year = DateTime.Now.Year.ToString();
        UserControl_drop_down_date_act_1985_33_date.minyear = three_year_ago;
        UserControl_drop_down_date_act_1985_33_date.maxyear = this_year;
        UserControl_drop_down_date_act_1985_34_date.minyear = three_year_ago;
        UserControl_drop_down_date_act_1985_34_date.maxyear = this_year;
        UserControl_drop_down_date_act_1994_151_date.minyear = three_year_ago;
        UserControl_drop_down_date_act_1994_151_date.maxyear = this_year;
        p.biz_sms_gateways.BindDirectToListControl
          (
          target:DropDownList_phone_service,
          unselected_literal:"-- phone service --"
          );
        UserControl_drop_down_date_drivers_license_expiration.minyear = this_year;
        UserControl_drop_down_date_drivers_license_expiration.maxyear = DateTime.Now.AddYears(int.Parse(ConfigurationManager.AppSettings["max_drivers_license_validity_years"])).Year.ToString();
        UserControl_drop_down_date_nims_is_100_date.minyear = "2004";
        UserControl_drop_down_date_nims_is_100_date.maxyear = this_year;
        UserControl_drop_down_date_nims_is_200_date.minyear = "2004";
        UserControl_drop_down_date_nims_is_200_date.maxyear = this_year;
        UserControl_drop_down_date_nims_is_700_date.minyear = "2004";
        UserControl_drop_down_date_nims_is_700_date.maxyear = this_year;
        UserControl_drop_down_date_nims_is_800_date.minyear = "2004";
        UserControl_drop_down_date_nims_is_800_date.maxyear = this_year;
        UserControl_drop_down_date_nims_ics_300_date.minyear = "2004";
        UserControl_drop_down_date_nims_ics_300_date.maxyear = this_year;
        UserControl_drop_down_date_nims_ics_400_date.minyear = "2004";
        UserControl_drop_down_date_nims_ics_400_date.maxyear = this_year;
        UserControl_drop_down_date_lms_disaster_stress_response_date.minyear = "2007";
        UserControl_drop_down_date_lms_disaster_stress_response_date.maxyear = this_year;
        UserControl_drop_down_date_lms_ems_mci_ops_date.minyear = "2006";
        UserControl_drop_down_date_lms_ems_mci_ops_date.maxyear = this_year;
        UserControl_drop_down_date_lms_wmd_date.minyear = "2008";
        UserControl_drop_down_date_lms_wmd_date.maxyear = this_year;
        UserControl_drop_down_date_lms_smallpox_date.minyear = "2007";
        UserControl_drop_down_date_lms_smallpox_date.maxyear = this_year;
        UserControl_drop_down_date_lms_basic_med_terrorism_response_date.minyear = "2003";
        UserControl_drop_down_date_lms_basic_med_terrorism_response_date.maxyear = this_year;
        UserControl_drop_down_date_lms_electrical_hazards_date.minyear = "2008";
        UserControl_drop_down_date_lms_electrical_hazards_date.maxyear = this_year;
        UserControl_drop_down_date_lms_ems_bioterror_date.minyear = "2003";
        UserControl_drop_down_date_lms_ems_bioterror_date.maxyear = this_year;
        UserControl_drop_down_date_pa_psychological_first_aid_date.minyear = "2006";
        UserControl_drop_down_date_pa_psychological_first_aid_date.maxyear = this_year;
        UserControl_drop_down_date_pa_water_rescue_awareness_date.minyear = "1966";
        UserControl_drop_down_date_pa_water_rescue_awareness_date.maxyear = this_year;
        UserControl_drop_down_date_pa_hazmat_awareness_date.minyear = "1984";
        UserControl_drop_down_date_pa_hazmat_awareness_date.maxyear = this_year;
        UserControl_drop_down_date_pa_ems_strike_team_leader_date.minyear = "2008";
        UserControl_drop_down_date_pa_ems_strike_team_leader_date.maxyear = this_year;
        UserControl_drop_down_date_two_years_supervisory_experience_date.minyear = "1968";
        UserControl_drop_down_date_two_years_supervisory_experience_date.maxyear = this_year;
        //
        RequireConfirmation(Button_delete, "Are you sure you want to delete this record?");
        if (p.practitioner_id.Length > 0)
          {
          PresentRecord(p.practitioner_id);
          }
        p.be_loaded = true;
        }
      InjectPersistentClientSideScript();
      }

    internal bool PresentRecord(string practitioner_id)
      {
      Literal_match_index.Text = DropDownList_practitioner_id.SelectedIndex.ToString();
      bool result;
      DateTime act_1985_33_date;
      DateTime act_1985_34_date;
      DateTime act_1994_151_date;
      string phone_number;
      string phone_service_id;
      bool be_immune_hepatitis_b;
      bool be_immune_diptheria_tetanus;
      string emergency_contact_1_name;
      string emergency_contact_1_phone_number;
      string emergency_contact_2_name;
      string emergency_contact_2_phone_number;
      string meds_doses;
      string allergies;
      string pcp_name;
      DateTime drivers_license_expiration;
      DateTime nims_is_100_date;
      DateTime nims_is_200_date;
      DateTime nims_is_700_date;
      DateTime nims_is_800_date;
      DateTime lms_disaster_stress_response_date;
      DateTime lms_ems_mci_ops_date;
      DateTime lms_wmd_date;
      DateTime lms_smallpox_date;
      DateTime lms_basic_med_terrorism_response_date;
      DateTime lms_electrical_hazards_date;
      DateTime lms_ems_bioterror_date;
      DateTime nims_ics_300_date;
      DateTime nims_ics_400_date;
      DateTime pa_psychological_first_aid_date;
      DateTime pa_water_rescue_awareness_date;
      DateTime pa_hazmat_awareness_date;
      DateTime pa_ems_strike_team_leader_date;
      DateTime two_years_supervisory_experience_date;
      result = false;
      if
        (
        p.biz_practitioner_strike_team_details.Get
          (
          practitioner_id,
          out act_1985_33_date,
          out act_1985_34_date,
          out act_1994_151_date,
          out phone_number,
          out phone_service_id,
          out be_immune_hepatitis_b,
          out be_immune_diptheria_tetanus,
          out emergency_contact_1_name,
          out emergency_contact_1_phone_number,
          out emergency_contact_2_name,
          out emergency_contact_2_phone_number,
          out meds_doses,
          out allergies,
          out pcp_name,
          out drivers_license_expiration,
          out nims_is_100_date,
          out nims_is_200_date,
          out nims_is_700_date,
          out nims_is_800_date,
          out lms_disaster_stress_response_date,
          out lms_ems_mci_ops_date,
          out lms_wmd_date,
          out lms_smallpox_date,
          out lms_basic_med_terrorism_response_date,
          out lms_electrical_hazards_date,
          out lms_ems_bioterror_date,
          out nims_ics_300_date,
          out nims_ics_400_date,
          out pa_psychological_first_aid_date,
          out pa_water_rescue_awareness_date,
          out pa_hazmat_awareness_date,
          out pa_ems_strike_team_leader_date,
          out two_years_supervisory_experience_date
          )
        )
        {
        TextBox_practitioner_id.Text = practitioner_id;
        TextBox_practitioner_id.Enabled = false;
        UserControl_drop_down_date_act_1985_33_date.selectedvalue = act_1985_33_date;
        UserControl_drop_down_date_act_1985_34_date.selectedvalue = act_1985_34_date;
        UserControl_drop_down_date_act_1994_151_date.selectedvalue = act_1994_151_date;
        TextBox_phone_number.Text = phone_number;
        DropDownList_phone_service.SelectedValue = phone_service_id;
        CheckBox_be_immune_hepatitis_b.Checked = be_immune_hepatitis_b;
        CheckBox_be_immune_diptheria_tetanus.Checked = be_immune_diptheria_tetanus;
        TextBox_emergency_contact_1_name.Text = emergency_contact_1_name;
        TextBox_emergency_contact_1_phone_number.Text = emergency_contact_1_phone_number;
        TextBox_emergency_contact_2_name.Text = emergency_contact_2_name;
        TextBox_emergency_contact_2_phone_number.Text = emergency_contact_2_phone_number;
        TextBox_meds_doses.Text = meds_doses;
        TextBox_allergies.Text = allergies;
        TextBox_pcp_name.Text = pcp_name;
        UserControl_drop_down_date_drivers_license_expiration.selectedvalue = drivers_license_expiration;
        UserControl_drop_down_date_nims_is_100_date.selectedvalue = nims_is_100_date;
        UserControl_drop_down_date_nims_is_200_date.selectedvalue = nims_is_200_date;
        UserControl_drop_down_date_nims_is_700_date.selectedvalue = nims_is_700_date;
        UserControl_drop_down_date_nims_is_800_date.selectedvalue = nims_is_800_date;
        UserControl_drop_down_date_lms_disaster_stress_response_date.selectedvalue = lms_disaster_stress_response_date;
        UserControl_drop_down_date_lms_ems_mci_ops_date.selectedvalue = lms_ems_mci_ops_date;
        UserControl_drop_down_date_lms_wmd_date.selectedvalue = lms_wmd_date;
        UserControl_drop_down_date_lms_smallpox_date.selectedvalue = lms_smallpox_date;
        UserControl_drop_down_date_lms_basic_med_terrorism_response_date.selectedvalue = lms_basic_med_terrorism_response_date;
        UserControl_drop_down_date_lms_electrical_hazards_date.selectedvalue = lms_electrical_hazards_date;
        UserControl_drop_down_date_lms_ems_bioterror_date.selectedvalue = lms_ems_bioterror_date;
        UserControl_drop_down_date_nims_ics_300_date.selectedvalue = nims_ics_300_date;
        UserControl_drop_down_date_nims_ics_400_date.selectedvalue = nims_ics_400_date;
        UserControl_drop_down_date_pa_psychological_first_aid_date.selectedvalue = pa_psychological_first_aid_date;
        UserControl_drop_down_date_pa_water_rescue_awareness_date.selectedvalue = pa_water_rescue_awareness_date;
        UserControl_drop_down_date_pa_hazmat_awareness_date.selectedvalue = pa_hazmat_awareness_date;
        UserControl_drop_down_date_pa_ems_strike_team_leader_date.selectedvalue = pa_ems_strike_team_leader_date;
        UserControl_drop_down_date_two_years_supervisory_experience_date.selectedvalue = two_years_supervisory_experience_date;
        Button_lookup.Enabled = false;
        Label_lookup_arrow.Enabled = false;
        Label_lookup_hint.Enabled = false;
        LinkButton_reset.Enabled = true;
        SetDependentFieldAblements(p.be_ok_to_config_practitioner_strike_team_details);
        Button_submit.Enabled = p.be_ok_to_config_practitioner_strike_team_details;
        Button_delete.Enabled = p.be_ok_to_config_practitioner_strike_team_details;
        result = true;
        }
      return result;
      }

    internal void SetDataEntryMode()
      {
      Clear();
      TextBox_practitioner_id.Enabled = false;
      Button_lookup.Enabled = false;
      Label_lookup_arrow.Enabled = false;
      Label_lookup_hint.Enabled = false;
      LinkButton_reset.Enabled = true;
      LinkButton_new_record.Enabled = false;
      SetDependentFieldAblements(p.be_ok_to_config_practitioner_strike_team_details);
      Button_submit.Enabled = p.be_ok_to_config_practitioner_strike_team_details;
      Button_delete.Enabled = false;
      TextBox_practitioner_id.Focus();
      }

    internal void SetLookupMode()
      {
      Clear();
      TextBox_practitioner_id.Enabled = true;
      Button_lookup.Enabled = true;
      Label_lookup_arrow.Enabled = true;
      Label_lookup_hint.Enabled = true;
      LinkButton_reset.Enabled = false;
      LinkButton_new_record.Enabled = true;
      TextBox_practitioner_id.Focus();
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
        p.be_loaded = IsPostBack;
        if (instance_id == "ASP.protected_overview_aspx.UserControl_member_binder_practitioner_practitioner_strike_team_detail_control")
          {
          p.be_loaded &= ((Session["UserControl_member_binder_PlaceHolder_content"] as string) == "UserControl_practitioner");
          }
        }
      else
        {
        p.biz_practitioner_strike_team_details = new TClass_biz_practitioner_strike_team_details();
        p.biz_role_member_map = new TClass_biz_role_member_map();
        p.biz_sms_gateways = new TClass_biz_sms_gateways();
        //
        p.be_loaded = false;
        p.be_ok_to_config_practitioner_strike_team_details = k.Has((string[])(Session["privilege_array"]), "config-practitioner-strike-team-details");
        p.practitioner_id = k.EMPTY;
        }
      }

    // / <summary>
    // / Required method for Designer support -- do not modify
    // / the contents of this method with the code editor.
    // / </summary>
    private void InitializeComponent()
      {
      //this.Load += this.Page_Load;
      this.PreRender += this.TWebUserControl_practitioner_strike_team_detail_PreRender;
      }

    private void TWebUserControl_practitioner_strike_team_detail_PreRender(object sender, System.EventArgs e)
      {
      SessionSet(InstanceId() + ".p", p);
      }

    public TWebUserControl_practitioner_strike_team_detail Fresh()
      {
      Session.Remove(InstanceId() + ".p");
      UserControl_drop_down_date_act_1985_33_date.Fresh();
      UserControl_drop_down_date_act_1985_34_date.Fresh();
      UserControl_drop_down_date_act_1994_151_date.Fresh();
      UserControl_drop_down_date_drivers_license_expiration.Fresh();
      UserControl_drop_down_date_nims_is_100_date.Fresh();
      UserControl_drop_down_date_nims_is_200_date.Fresh();
      UserControl_drop_down_date_nims_is_700_date.Fresh();
      UserControl_drop_down_date_nims_is_800_date.Fresh();
      UserControl_drop_down_date_lms_disaster_stress_response_date.Fresh();
      UserControl_drop_down_date_lms_ems_mci_ops_date.Fresh();
      UserControl_drop_down_date_lms_wmd_date.Fresh();
      UserControl_drop_down_date_lms_smallpox_date.Fresh();
      UserControl_drop_down_date_lms_basic_med_terrorism_response_date.Fresh();
      UserControl_drop_down_date_lms_electrical_hazards_date.Fresh();
      UserControl_drop_down_date_lms_ems_bioterror_date.Fresh();
      UserControl_drop_down_date_nims_ics_300_date.Fresh();
      UserControl_drop_down_date_nims_ics_400_date.Fresh();
      UserControl_drop_down_date_pa_psychological_first_aid_date.Fresh();
      UserControl_drop_down_date_pa_water_rescue_awareness_date.Fresh();
      UserControl_drop_down_date_pa_hazmat_awareness_date.Fresh();
      UserControl_drop_down_date_pa_ems_strike_team_leader_date.Fresh();
      UserControl_drop_down_date_two_years_supervisory_experience_date.Fresh();
      return this;
      }

    protected void Button_submit_Click(object sender, System.EventArgs e)
      {
      Submit();
      }

    internal void Submit()
      {
      if (Page.IsValid)
        {
        p.biz_practitioner_strike_team_details.Set
          (
          p.practitioner_id, //k.Safe(TextBox_practitioner_id.Text, k.safe_hint_type.NUM).Trim(),
          UserControl_drop_down_date_act_1985_33_date.selectedvalue,
          UserControl_drop_down_date_act_1985_34_date.selectedvalue,
          UserControl_drop_down_date_act_1994_151_date.selectedvalue,
          k.Safe(TextBox_phone_number.Text, k.safe_hint_type.NUM).Trim(),
          k.Safe(DropDownList_phone_service.SelectedValue, k.safe_hint_type.NUM).Trim(),
          CheckBox_be_immune_hepatitis_b.Checked,
          CheckBox_be_immune_diptheria_tetanus.Checked,
          k.Safe(TextBox_emergency_contact_1_name.Text, k.safe_hint_type.HUMAN_NAME).Trim(),
          k.Safe(TextBox_emergency_contact_1_phone_number.Text, k.safe_hint_type.NUM).Trim(),
          k.Safe(TextBox_emergency_contact_2_name.Text, k.safe_hint_type.HUMAN_NAME).Trim(),
          k.Safe(TextBox_emergency_contact_2_phone_number.Text, k.safe_hint_type.NUM).Trim(),
          k.Safe(TextBox_meds_doses.Text, k.safe_hint_type.PUNCTUATED).Trim(),
          k.Safe(TextBox_allergies.Text, k.safe_hint_type.PUNCTUATED).Trim(),
          k.Safe(TextBox_pcp_name.Text, k.safe_hint_type.PUNCTUATED).Trim(),
          UserControl_drop_down_date_drivers_license_expiration.selectedvalue,
          UserControl_drop_down_date_nims_is_100_date.selectedvalue,
          UserControl_drop_down_date_nims_is_200_date.selectedvalue,
          UserControl_drop_down_date_nims_is_700_date.selectedvalue,
          UserControl_drop_down_date_nims_is_800_date.selectedvalue,
          UserControl_drop_down_date_lms_disaster_stress_response_date.selectedvalue,
          UserControl_drop_down_date_lms_ems_mci_ops_date.selectedvalue,
          UserControl_drop_down_date_lms_wmd_date.selectedvalue,
          UserControl_drop_down_date_lms_smallpox_date.selectedvalue,
          UserControl_drop_down_date_lms_basic_med_terrorism_response_date.selectedvalue,
          UserControl_drop_down_date_lms_electrical_hazards_date.selectedvalue,
          UserControl_drop_down_date_lms_ems_bioterror_date.selectedvalue,
          UserControl_drop_down_date_nims_ics_300_date.selectedvalue,
          UserControl_drop_down_date_nims_ics_400_date.selectedvalue,
          UserControl_drop_down_date_pa_psychological_first_aid_date.selectedvalue,
          UserControl_drop_down_date_pa_water_rescue_awareness_date.selectedvalue,
          UserControl_drop_down_date_pa_hazmat_awareness_date.selectedvalue,
          UserControl_drop_down_date_pa_ems_strike_team_leader_date.selectedvalue,
          UserControl_drop_down_date_two_years_supervisory_experience_date.selectedvalue
          );
        Alert(k.alert_cause_type.USER, k.alert_state_type.SUCCESS, "recsaved", "Record saved.", true);
        //SetLookupMode();  -- inappropriate when not using lookup feature
        }
      else
        {
        ValidationAlert(true);
        }
      }

    protected void DropDownList_practitioner_id_SelectedIndexChanged(object sender, System.EventArgs e)
      {
      PresentRecord(k.Safe(DropDownList_practitioner_id.SelectedValue, k.safe_hint_type.NUM));
      }

    protected void LinkButton_go_to_match_first_Click(object sender, System.EventArgs e)
      {
      DropDownList_practitioner_id.SelectedIndex = 1;
      PresentRecord(k.Safe(DropDownList_practitioner_id.SelectedValue, k.safe_hint_type.NUM));
      }

    protected void LinkButton_go_to_match_prior_Click(object sender, System.EventArgs e)
      {
      DropDownList_practitioner_id.SelectedIndex = Math.Max(1, (DropDownList_practitioner_id.SelectedIndex - 1));
      PresentRecord(k.Safe(DropDownList_practitioner_id.SelectedValue, k.safe_hint_type.NUM));
      }

    protected void LinkButton_go_to_match_next_Click(object sender, System.EventArgs e)
      {
      DropDownList_practitioner_id.SelectedIndex = Math.Min((DropDownList_practitioner_id.SelectedIndex + 1), (DropDownList_practitioner_id.Items.Count - 1));
      PresentRecord(k.Safe(DropDownList_practitioner_id.SelectedValue, k.safe_hint_type.NUM));
      }

    protected void LinkButton_go_to_match_last_Click(object sender, System.EventArgs e)
      {
      DropDownList_practitioner_id.SelectedIndex = DropDownList_practitioner_id.Items.Count - 1;
      PresentRecord(k.Safe(DropDownList_practitioner_id.SelectedValue, k.safe_hint_type.NUM));
      }

    protected void Button_delete_Click(object sender, System.EventArgs e)
      {
      if (p.biz_practitioner_strike_team_details.Delete(k.Safe(TextBox_practitioner_id.Text, k.safe_hint_type.ALPHANUM)))
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

    internal void SetDependentFieldAblements(bool ablement)
      {
      TextBox_practitioner_id.Enabled = ablement;
      UserControl_drop_down_date_act_1985_33_date.enabled = ablement;
      UserControl_drop_down_date_act_1985_34_date.enabled = ablement;
      UserControl_drop_down_date_act_1994_151_date.enabled = ablement;
      TextBox_phone_number.Enabled = ablement;
      DropDownList_phone_service.Enabled = ablement;
      CheckBox_be_immune_hepatitis_b.Enabled = ablement;
      CheckBox_be_immune_diptheria_tetanus.Enabled = ablement;
      TextBox_emergency_contact_1_name.Enabled = ablement;
      TextBox_emergency_contact_1_phone_number.Enabled = ablement;
      TextBox_emergency_contact_2_name.Enabled = ablement;
      TextBox_emergency_contact_2_phone_number.Enabled = ablement;
      TextBox_meds_doses.Enabled = ablement;
      TextBox_allergies.Enabled = ablement;
      TextBox_pcp_name.Enabled = ablement;
      UserControl_drop_down_date_drivers_license_expiration.enabled = ablement;
      UserControl_drop_down_date_nims_is_100_date.enabled = ablement;
      UserControl_drop_down_date_nims_is_200_date.enabled = ablement;
      UserControl_drop_down_date_nims_is_700_date.enabled = ablement;
      UserControl_drop_down_date_nims_is_800_date.enabled = ablement;
      UserControl_drop_down_date_lms_disaster_stress_response_date.enabled = ablement;
      UserControl_drop_down_date_lms_ems_mci_ops_date.enabled = ablement;
      UserControl_drop_down_date_lms_wmd_date.enabled = ablement;
      UserControl_drop_down_date_lms_smallpox_date.enabled = ablement;
      UserControl_drop_down_date_lms_basic_med_terrorism_response_date.enabled = ablement;
      UserControl_drop_down_date_lms_electrical_hazards_date.enabled = ablement;
      UserControl_drop_down_date_lms_ems_bioterror_date.enabled = ablement;
      UserControl_drop_down_date_nims_ics_300_date.enabled = ablement;
      UserControl_drop_down_date_nims_ics_400_date.enabled = ablement;
      UserControl_drop_down_date_pa_psychological_first_aid_date.enabled = ablement;
      UserControl_drop_down_date_pa_water_rescue_awareness_date.enabled = ablement;
      UserControl_drop_down_date_pa_hazmat_awareness_date.enabled = ablement;
      UserControl_drop_down_date_pa_ems_strike_team_leader_date.enabled = ablement;
      UserControl_drop_down_date_two_years_supervisory_experience_date.enabled = ablement;
      }

    protected void Button_lookup_Click(object sender, System.EventArgs e)
      {
      uint num_matches;
      string saved_practitioner_id;
      saved_practitioner_id = k.Safe(TextBox_practitioner_id.Text,k.safe_hint_type.PUNCTUATED);
      Clear();
      if (!PresentRecord(saved_practitioner_id))
        {
        TextBox_practitioner_id.Text = saved_practitioner_id;
        p.biz_practitioner_strike_team_details.Bind(saved_practitioner_id, DropDownList_practitioner_id);
        num_matches = (uint)(DropDownList_practitioner_id.Items.Count);
        if (num_matches > 0)
          {
          DropDownList_practitioner_id.Visible = true;
          if (num_matches == 1)
            {
            PresentRecord(k.Safe(DropDownList_practitioner_id.SelectedValue, k.safe_hint_type.NUM));
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
            DropDownList_practitioner_id.Items.Insert(0, new ListItem("-- Select --", k.EMPTY));
            }
          }
        }
      }

    internal void SetTarget(string target)
      {
      var practitioner_id = target.Substring(target.LastIndexOf("/") + 1);
      if (practitioner_id.Length > 0)
        {
        p.practitioner_id = practitioner_id;
        PresentRecord(p.practitioner_id);
        }
      }

    } // end TWebUserControl_practitioner_strike_team_detail

  }
