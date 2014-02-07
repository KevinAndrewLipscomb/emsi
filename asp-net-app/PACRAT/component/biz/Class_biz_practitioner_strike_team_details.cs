// Derived from KiAspdotnetFramework/component/biz/Class~biz~~template~kicrudhelped~item.cs~template

using Class_db_practitioner_strike_team_details;
using kix;
using System;
using System.Collections;

namespace Class_biz_practitioner_strike_team_details
  {
  public class TClass_biz_practitioner_strike_team_details
    {
    private TClass_db_practitioner_strike_team_details db_practitioner_strike_team_details = null;

    public TClass_biz_practitioner_strike_team_details() : base()
      {
      db_practitioner_strike_team_details = new TClass_db_practitioner_strike_team_details();
      }

    public bool Bind(string partial_spec, object target)
      {
      return db_practitioner_strike_team_details.Bind(partial_spec, target);
      }

    public void BindDirectToListControl(object target)
      {
      db_practitioner_strike_team_details.BindDirectToListControl(target);
      }

    public bool Delete(string id)
      {
      return db_practitioner_strike_team_details.Delete(id);
      }

    public bool Get
      (
      string practitioner_id,
      out DateTime act_1985_33_date,
      out DateTime act_1985_34_date,
      out DateTime act_1994_151_date,
      out string phone_number,
      out string phone_service_id,
      out bool be_immune_hepatitis_b,
      out bool be_immune_diptheria_tetanus,
      out string emergency_contact_1_name,
      out string emergency_contact_1_phone_number,
      out string emergency_contact_2_name,
      out string emergency_contact_2_phone_number,
      out string meds_doses,
      out string allergies,
      out string pcp_name,
      out DateTime drivers_license_expiration,
      out DateTime nims_is_100_date,
      out DateTime nims_is_200_date,
      out DateTime nims_is_700_date,
      out DateTime nims_is_800_date,
      out DateTime lms_disaster_stress_response_date,
      out DateTime lms_ems_mci_ops_date,
      out DateTime lms_wmd_date,
      out DateTime lms_smallpox_date,
      out DateTime lms_basic_med_terrorism_response_date,
      out DateTime lms_electrical_hazards_date,
      out DateTime lms_ems_bioterror_date
      )
      {
      return db_practitioner_strike_team_details.Get
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
        out lms_ems_bioterror_date
        );
      }

    internal void MakeMemberStatusStatements(bool do_limit_to_uncredentialed)
      {
      db_practitioner_strike_team_details.MakeMemberStatusStatements(do_limit_to_uncredentialed);
      }

    public void Set
      (
      string practitioner_id,
      DateTime act_1985_33_date,
      DateTime act_1985_34_date,
      DateTime act_1994_151_date,
      string phone_number,
      string phone_service_id,
      bool be_immune_hepatitis_b,
      bool be_immune_diptheria_tetanus,
      string emergency_contact_1_name,
      string emergency_contact_1_phone_number,
      string emergency_contact_2_name,
      string emergency_contact_2_phone_number,
      string meds_doses,
      string allergies,
      string pcp_name,
      DateTime drivers_license_expiration,
      DateTime nims_is_100_date,
      DateTime nims_is_200_date,
      DateTime nims_is_700_date,
      DateTime nims_is_800_date,
      DateTime lms_disaster_stress_response_date,
      DateTime lms_ems_mci_ops_date,
      DateTime lms_wmd_date,
      DateTime lms_smallpox_date,
      DateTime lms_basic_med_terrorism_response_date,
      DateTime lms_electrical_hazards_date,
      DateTime lms_ems_bioterror_date
      )
      {
      db_practitioner_strike_team_details.Set
        (
        practitioner_id,
        act_1985_33_date,
        act_1985_34_date,
        act_1994_151_date,
        phone_number,
        phone_service_id,
        be_immune_hepatitis_b,
        be_immune_diptheria_tetanus,
        emergency_contact_1_name,
        emergency_contact_1_phone_number,
        emergency_contact_2_name,
        emergency_contact_2_phone_number,
        meds_doses,
        allergies,
        pcp_name,
        drivers_license_expiration,
        nims_is_100_date,
        nims_is_200_date,
        nims_is_700_date,
        nims_is_800_date,
        lms_disaster_stress_response_date,
        lms_ems_mci_ops_date,
        lms_wmd_date,
        lms_smallpox_date,
        lms_basic_med_terrorism_response_date,
        lms_electrical_hazards_date,
        lms_ems_bioterror_date
        );
      }

    internal string SmsTargetOf(string practitioner_id)
      {
      return db_practitioner_strike_team_details.SmsTargetOf(practitioner_id);
      }

    } // end TClass_biz_practitioner_strike_team_details

  }
