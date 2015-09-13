// Derived from KiAspdotnetFramework/UserControl/app/UserControl~template~kicrudhelped~item.ascx.cs~template

using Class_biz_counties;
using Class_biz_members;
using Class_biz_practitioner_levels;
using Class_biz_practitioner_strike_team_details;
using Class_biz_privileges;
using Class_biz_regions;
using Class_biz_role_member_map;
using Class_biz_roles;
using Class_biz_sms_gateways;
using Class_biz_strike_team_rosters;
using Class_biz_user;
using kix;
using System;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserControl_drop_down_date;

namespace UserControl_add_associate
  {
  public partial class TWebUserControl_add_associate: ki_web_ui.usercontrol_class
    {
    private struct p_type
      {
      public string appropriate_strike_team_manager_role_id;
      public string association_clause;
      public string association_id;
      public string association_name;
      public bool be_loaded;
      public bool be_ok_to_config_add_associates;
      public TClass_biz_counties biz_counties;
      public TClass_biz_members biz_members;
      public TClass_biz_privileges biz_privileges;
      public TClass_biz_practitioner_levels biz_practitioner_levels;
      public TClass_biz_practitioner_strike_team_details biz_practitioner_strike_team_details;
      public TClass_biz_regions biz_regions;
      public TClass_biz_role_member_map biz_role_member_map;
      public TClass_biz_roles biz_roles;
      public TClass_biz_sms_gateways biz_sms_gateways;
      public TClass_biz_strike_team_rosters biz_strike_team_rosters;
      public TClass_biz_user biz_user;
      public string id;
      public string tier_name;
      }

    private p_type p;

    private void Clear()
      {
      TextBox_last_name.Text = k.EMPTY;
      TextBox_first_name.Text = k.EMPTY;
      TextBox_middle_initial.Text = k.EMPTY;
      DropDownList_level.ClearSelection();
      DropDownList_regional_council.ClearSelection();
      UserControl_drop_down_date_birth_date.Clear();
      TextBox_email_address.Text = k.EMPTY;
      DropDownList_residence_county.ClearSelection();
      TextBox_street_address_1.Text = k.EMPTY;
      TextBox_street_address_2.Text = k.EMPTY;
      TextBox_city_state_zip.Text = k.EMPTY;
      SetDependentFieldAblements(false);
      Button_submit.Enabled = false;
      }

    protected void Page_Load(object sender, System.EventArgs e)
      {
      if (!p.be_loaded)
        {
        Literal_association_clause.Text = p.association_clause;
        p.biz_practitioner_levels.BindDirectToListControl(DropDownList_level,"(none)");
        p.biz_regions.BindDirectToListControl
          (
          target:DropDownList_regional_council,
          application_filter:"pacrat"
          );
        p.biz_counties.BindDirectToListControl(DropDownList_residence_county);
        UserControl_drop_down_date_birth_date.minyear = DateTime.Today.AddYears(-130).Year.ToString();
        UserControl_drop_down_date_birth_date.maxyear = DateTime.Today.AddYears(-16).Year.ToString();
        p.biz_sms_gateways.BindDirectToListControl
          (
          target:DropDownList_phone_service,
          unselected_literal:"-- phone service --"
          );
        Literal_application_name.Text = ConfigurationManager.AppSettings["application_name"];
        SetDataEntryMode();
        p.be_loaded = true;
        }
      }

    private void SetDataEntryMode()
      {
      Clear();
      SetDependentFieldAblements(p.be_ok_to_config_add_associates);
      Button_submit.Enabled = p.be_ok_to_config_add_associates;
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
        }
      else
        {
        p.be_loaded = false;
        //
        p.biz_counties = new TClass_biz_counties();
        p.biz_members = new TClass_biz_members();
        p.biz_practitioner_levels = new TClass_biz_practitioner_levels();
        p.biz_practitioner_strike_team_details = new TClass_biz_practitioner_strike_team_details();
        p.biz_privileges = new TClass_biz_privileges();
        p.biz_regions = new TClass_biz_regions();
        p.biz_role_member_map = new TClass_biz_role_member_map();
        p.biz_roles = new TClass_biz_roles();
        p.biz_sms_gateways = new TClass_biz_sms_gateways();
        p.biz_strike_team_rosters = new TClass_biz_strike_team_rosters();
        p.biz_user = new TClass_biz_user();
        //
        p.association_clause = k.EMPTY;
        p.association_id = k.EMPTY;
        p.be_ok_to_config_add_associates = p.biz_privileges.HasForAnyScope
          (
          member_id:p.biz_members.IdOfUserId(p.biz_user.IdNum()),
          privilege_name:"add-associates"
          );
        p.id = k.EMPTY;
        p.tier_name = k.EMPTY;
        }
      }

    // / <summary>
    // / Required method for Designer support -- do not modify
    // / the contents of this method with the code editor.
    // / </summary>
    private void InitializeComponent()
      {
      PreRender += TWebUserControl_add_associate_PreRender;
      }

    private void TWebUserControl_add_associate_PreRender(object sender, System.EventArgs e)
      {
      SessionSet(InstanceId() + ".p", p);
      }

    public TWebUserControl_add_associate Fresh()
      {
      Session.Remove(InstanceId() + ".p");
      UserControl_drop_down_date_birth_date.Fresh();
      return this;
      }

    protected void Button_submit_Click(object sender, System.EventArgs e)
      {
      if (Page.IsValid)
        {
        var id_of_member_added = p.biz_members.IdOfMemberAdded
          (
          last_name:k.Safe(TextBox_last_name.Text, k.safe_hint_type.HUMAN_NAME).Trim(),
          first_name:k.Safe(TextBox_first_name.Text, k.safe_hint_type.HUMAN_NAME).Trim(),
          middle_initial:k.Safe(TextBox_middle_initial.Text, k.safe_hint_type.ALPHA),
          practitioner_level_id:k.Safe(DropDownList_level.SelectedValue, k.safe_hint_type.NUM),
          practitioner_level_short_description:k.Safe(DropDownList_level.SelectedItem.Text, k.safe_hint_type.HYPHENATED_ALPHANUM),
          regional_council_code:k.Safe(DropDownList_regional_council.SelectedValue, k.safe_hint_type.NUM),
          regional_council_name:k.Safe(DropDownList_regional_council.SelectedItem.Text, k.safe_hint_type.ALPHA_WORDS),
          birth_date:UserControl_drop_down_date_birth_date.selectedvalue,
          email_address:k.Safe(TextBox_email_address.Text, k.safe_hint_type.EMAIL_ADDRESS),
          residence_county_code:k.Safe(DropDownList_residence_county.SelectedValue, k.safe_hint_type.NUM),
          residence_county_name:k.Safe(DropDownList_residence_county.SelectedItem.Text, k.safe_hint_type.ALPHA),
          street_address_1:k.Safe(TextBox_street_address_1.Text, k.safe_hint_type.POSTAL_STREET_ADDRESS),
          street_address_2:k.Safe(TextBox_street_address_2.Text, k.safe_hint_type.POSTAL_STREET_ADDRESS),
          city_state_zip:k.Safe(TextBox_city_state_zip.Text, k.safe_hint_type.POSTAL_CITY)
          );
        if (id_of_member_added.Length > 0)
          {
          p.biz_practitioner_strike_team_details.Set
            (
            practitioner_id:id_of_member_added,
            act_1985_33_date:DateTime.MinValue,
            act_1985_34_date:DateTime.MinValue,
            act_1994_151_date:DateTime.MinValue,
            phone_number:k.Safe(TextBox_phone_number.Text, k.safe_hint_type.NUM).Trim(),
            phone_service_id:k.Safe(DropDownList_phone_service.SelectedValue, k.safe_hint_type.NUM).Trim(),
            be_immune_hepatitis_b:false,
            be_immune_diptheria_tetanus:false,
            emergency_contact_1_name:k.EMPTY,
            emergency_contact_1_phone_number:k.EMPTY,
            emergency_contact_2_name:k.EMPTY,
            emergency_contact_2_phone_number:k.EMPTY,
            meds_doses:k.EMPTY,
            allergies:k.EMPTY,
            pcp_name:k.EMPTY,
            drivers_license_expiration:DateTime.MinValue,
            nims_is_100_date:DateTime.MinValue,
            nims_is_200_date:DateTime.MinValue,
            nims_is_700_date:DateTime.MinValue,
            nims_is_800_date:DateTime.MinValue,
            lms_disaster_stress_response_date:DateTime.MinValue,
            lms_ems_mci_ops_date:DateTime.MinValue,
            lms_wmd_date:DateTime.MinValue,
            lms_smallpox_date:DateTime.MinValue,
            lms_basic_med_terrorism_response_date:DateTime.MinValue,
            lms_electrical_hazards_date:DateTime.MinValue,
            lms_ems_bioterror_date:DateTime.MinValue,
            nims_ics_300_date:DateTime.MinValue,
            nims_ics_400_date:DateTime.MinValue,
            pa_psychological_first_aid_date:DateTime.MinValue,
            pa_water_rescue_awareness_date:DateTime.MinValue,
            pa_hazmat_awareness_date:DateTime.MinValue,
            pa_ems_strike_team_leader_date:DateTime.MinValue,
            two_years_supervisory_experience_date:DateTime.MinValue
            );
          if (p.tier_name == "Practitioner")
            {
            p.biz_strike_team_rosters.Set
              (
              id:k.EMPTY,
              service_id:p.association_id,
              practitioner_id:id_of_member_added
              );
            }
          else if (p.tier_name == "Service")
            {
            p.biz_role_member_map.SaveForExplicitService
              (
              member_id:id_of_member_added,
              role_id:p.appropriate_strike_team_manager_role_id,
              be_granted:true,
              service_id:p.association_id
              );
            }
          else if (p.tier_name == "Region")
            {
            p.biz_role_member_map.SaveForExplicitRegion
              (
              member_id:id_of_member_added,
              role_id:p.appropriate_strike_team_manager_role_id,
              be_granted:true,
              region_code:p.association_id
              );
            }
          else if (p.tier_name == "State")
            {
            p.biz_role_member_map.Save
              (
              member_id:id_of_member_added,
              role_id:p.appropriate_strike_team_manager_role_id,
              be_granted:true
              );
            }
          Alert
            (
            cause:k.alert_cause_type.USER,
            state:k.alert_state_type.SUCCESS,
            key:"asctloaded",
            value:"You have loaded this person into the system and added them" + p.association_clause,
            be_using_scriptmanager:true
            );
          SetDataEntryMode();
          }
        else
          {
          Alert
            (
            cause:k.alert_cause_type.APPDATA,
            state:k.alert_state_type.FAILURE,
            key:"pernotadded",
            value:"This person seems to already be in the system.",
            be_using_scriptmanager:true
            );
          }
        }
      else
        {
        ValidationAlert(true);
        }
      }

    private void SetDependentFieldAblements(bool ablement)
      {
      TextBox_last_name.Enabled = ablement;
      TextBox_first_name.Enabled = ablement;
      TextBox_middle_initial.Enabled = ablement;
      DropDownList_level.Enabled = ablement;
      DropDownList_regional_council.Enabled = ablement;
      UserControl_drop_down_date_birth_date.enabled = ablement;
      TextBox_email_address.Enabled = ablement;
      DropDownList_residence_county.Enabled = ablement;
      TextBox_street_address_1.Enabled = ablement;
      TextBox_street_address_2.Enabled = ablement;
      TextBox_city_state_zip.Enabled = ablement;
      }

    protected void CustomValidator_email_address_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
      {
      args.IsValid = k.BeValidDomainPartOfEmailAddress(k.Safe(TextBox_email_address.Text, k.safe_hint_type.EMAIL_ADDRESS));
      }

    protected void CustomValidator_birth_date_ServerValidate(object source, ServerValidateEventArgs args)
      {
      args.IsValid = UserControl_drop_down_date_birth_date.selectedvalue != UserControl_drop_down_date_Static.NONE;
      }

    protected void CustomValidator_phone_number_ServerValidate(object source, ServerValidateEventArgs args)
      {
      args.IsValid = k.BeValidNanpNumber(k.Safe(TextBox_phone_number.Text, k.safe_hint_type.NUM));
      }

    internal void SetP
      (
      string tier_name,
      string association_id,
      string association_name
      )
      {
      p.tier_name = tier_name;
      p.association_id = association_id;
      p.association_name = association_name;
      //
      p.appropriate_strike_team_manager_role_id = (p.tier_name == "Practitioner" ? k.EMPTY : p.biz_roles.IdOfName(tier_name + " Strike Team Manager"));
      p.association_clause = " as a(n) "
      + (p.association_name.Length == 0 ? "Pennsylvania" : p.association_name)
      + k.SPACE
      + (p.tier_name == "Practitioner" ? "front-line strike team member." : p.tier_name.ToLower() + "-level strike team officer.");
      }

    } // end TWebUserControl_add_associate

  }
