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
      out DateTime nims_is_700_date
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
        out nims_is_700_date
        );
      }

    internal void MakeMemberStatusStatements()
      {
      db_practitioner_strike_team_details.MakeMemberStatusStatements();
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
      DateTime nims_is_700_date
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
        nims_is_700_date
        );
      }

    internal string SmsTargetOf(string practitioner_id)
      {
      return db_practitioner_strike_team_details.SmsTargetOf(practitioner_id);
      }

    } // end TClass_biz_practitioner_strike_team_details

  }
