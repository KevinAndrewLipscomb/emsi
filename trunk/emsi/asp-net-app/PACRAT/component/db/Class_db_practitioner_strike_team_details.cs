// Derived from KiAspdotnetFramework/component/db/Class~db~template~kicrudhelped~items.cs~template

using Class_biz_notifications;
using Class_db;
using Class_db_trail;
using kix;
using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Web.UI.WebControls;

namespace Class_db_practitioner_strike_team_details
  {

  public static class Class_db_practitioner_strike_team_details_Static
    {
    public const string BE_CREDENTIALED_AS_LEADER_EXPRESSION = k.EMPTY
    + " ("
    +   " (nims_ics_300_date is not null and nims_ics_300_date > '0001-01-01')"
    + " and"
    +   " (nims_ics_400_date is not null and nims_ics_400_date > '0001-01-01')"
    + " and"
    +   " (pa_psychological_first_aid_date is not null and pa_psychological_first_aid_date > '0001-01-01')"
    + " and"
    +   " (pa_water_rescue_awareness_date is not null and pa_water_rescue_awareness_date > '0001-01-01')"
    + " and"
    +   " (pa_hazmat_awareness_date is not null and pa_hazmat_awareness_date > '0001-01-01')"
    + " and"
    +   " (pa_ems_strike_team_leader_date is not null and pa_ems_strike_team_leader_date > '0001-01-01')"
    + " and"
    +   " (two_years_supervisory_experience_date is not null and two_years_supervisory_experience_date > '0001-01-01')"
    + " )";
    public const string BE_TEXTABLE_EXPRESSION = k.EMPTY
    + " ("
    +   " (phone_number is not null)"
    + " and"
    +   " (phone_service_id is not null)"
    + " )";
    }

  public class TClass_db_practitioner_strike_team_details: TClass_db
    {

  internal static string BeCredentialedAsMemberExpression()
    {
    var num_years_clearances_considered_valid = ConfigurationManager.AppSettings["num_years_clearances_considered_valid"];
    return k.EMPTY
    + " ("
    +   " (act_1985_33_date is not null and act_1985_33_date >= SUBDATE(CURDATE(),INTERVAL " + num_years_clearances_considered_valid + " YEAR))"
    + " and"
    +   " (act_1985_34_date is not null and act_1985_34_date >= SUBDATE(CURDATE(),INTERVAL " + num_years_clearances_considered_valid + " YEAR))"
    + " and"
    +   " (act_1994_151_date is not null and act_1994_151_date >= SUBDATE(CURDATE(),INTERVAL " + num_years_clearances_considered_valid + " YEAR))"
    + " and"
    +   " be_immune_hepatitis_b"
    + " and"
    +   " be_immune_diptheria_tetanus"
    + " and"
    +   " (emergency_contact_1_name is not null)"
    + " and"
    +   " (emergency_contact_1_phone_number is not null)"
    + " and"
    +   " (drivers_license_expiration >= CURDATE())"
    + " and"
    +   " (nims_is_100_date is not null and nims_is_100_date > '0001-01-01')"
    + " and"
    +   " (nims_is_200_date is not null and nims_is_200_date > '0001-01-01')"
    + " and"
    +   " (nims_is_700_date is not null and nims_is_700_date > '0001-01-01')"
    + " and"
    +   " (nims_is_800_date is not null and nims_is_700_date > '0001-01-01')"
    + " and"
    +   " (lms_disaster_stress_response_date is not null and lms_disaster_stress_response_date > '0001-01-01')"
    + " and"
    +   " (lms_ems_mci_ops_date is not null and lms_ems_mci_ops_date > '0001-01-01')"
    + " and"
    +   " (lms_wmd_date is not null and lms_wmd_date > '0001-01-01')"
    + " and"
    +   " (lms_smallpox_date is not null and lms_smallpox_date > '0001-01-01')"
    + " and"
    +   " (lms_basic_med_terrorism_response_date is not null and lms_basic_med_terrorism_response_date > '0001-01-01')"
    + " and"
    +   " (lms_electrical_hazards_date is not null and lms_electrical_hazards_date > '0001-01-01')"
    + " and"
    +   " (lms_ems_bioterror_date is not null and lms_ems_bioterror_date > '0001-01-01')"
    + " )";
    }

    private TClass_biz_notifications biz_notifications = null;
    private TClass_db_trail db_trail = null;

    public TClass_db_practitioner_strike_team_details() : base()
      {
      biz_notifications = new TClass_biz_notifications();
      db_trail = new TClass_db_trail();
      }

    public bool Bind(string partial_spec, object target)
      {
      var concat_clause = "concat(IFNULL(practitioner_id,'-'))";
      Open();
      ((target) as ListControl).Items.Clear();
      var dr = new MySqlCommand
        (
        "select practitioner_id"
        + " , CONVERT(" + concat_clause + " USING utf8) as spec"
        + " from practitioner_strike_team_detail"
        + " where " + concat_clause + " like '%" + partial_spec.ToUpper() + "%'"
        + " order by spec",
        connection
        )
        .ExecuteReader();
      while (dr.Read())
        {
        ((target) as ListControl).Items.Add(new ListItem(dr["spec"].ToString(), dr["practitioner_id"].ToString()));
        }
      dr.Close();
      Close();
      return ((target) as ListControl).Items.Count > 0;
      }

    public void BindDirectToListControl(object target)
      {
      Open();
      ((target) as ListControl).Items.Clear();
      var dr = new MySqlCommand
        (
        "SELECT practitioner_id"
        + " , CONVERT(concat(IFNULL(practitioner_id,'-')) USING utf8) as spec"
        + " FROM practitioner_strike_team_detail"
        + " order by spec",
        connection
        )
        .ExecuteReader();
      while (dr.Read())
        {
        ((target) as ListControl).Items.Add(new ListItem(dr["spec"].ToString(), dr["practitioner_id"].ToString()));
        }
      dr.Close();
      Close();
      }

    public bool Delete(string practitioner_id)
      {
      var result = true;
      Open();
      try
        {
        new MySqlCommand(db_trail.Saved("delete from practitioner_strike_team_detail where practitioner_id = \"" + practitioner_id + "\""), connection).ExecuteNonQuery();
        }
      catch(System.Exception e)
        {
        if (e.Message.StartsWith("Cannot delete or update a parent row: a foreign key constraint fails", true, null))
          {
          result = false;
          }
        else
          {
          throw e;
          }
        }
      Close();
      return result;
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
      out DateTime lms_ems_bioterror_date,
      out DateTime nims_ics_300_date,
      out DateTime nims_ics_400_date,
      out DateTime pa_psychological_first_aid_date,
      out DateTime pa_water_rescue_awareness_date,
      out DateTime pa_hazmat_awareness_date,
      out DateTime pa_ems_strike_team_leader_date,
      out DateTime two_years_supervisory_experience_date
      )
      {
      act_1985_33_date = DateTime.MinValue;
      act_1985_34_date = DateTime.MinValue;
      act_1994_151_date = DateTime.MinValue;
      phone_number = k.EMPTY;
      phone_service_id = k.EMPTY;
      be_immune_hepatitis_b = false;
      be_immune_diptheria_tetanus = false;
      emergency_contact_1_name = k.EMPTY;
      emergency_contact_1_phone_number = k.EMPTY;
      emergency_contact_2_name = k.EMPTY;
      emergency_contact_2_phone_number = k.EMPTY;
      meds_doses = k.EMPTY;
      allergies = k.EMPTY;
      pcp_name = k.EMPTY;
      drivers_license_expiration = DateTime.MinValue;
      nims_is_100_date = DateTime.MinValue;
      nims_is_200_date = DateTime.MinValue;
      nims_is_700_date = DateTime.MinValue;
      nims_is_800_date = DateTime.MinValue;
      lms_disaster_stress_response_date = DateTime.MinValue;
      lms_ems_mci_ops_date = DateTime.MinValue;
      lms_wmd_date = DateTime.MinValue;
      lms_smallpox_date = DateTime.MinValue;
      lms_basic_med_terrorism_response_date = DateTime.MinValue;
      lms_electrical_hazards_date = DateTime.MinValue;
      lms_ems_bioterror_date = DateTime.MinValue;
      nims_ics_300_date = DateTime.MinValue;
      nims_ics_400_date = DateTime.MinValue;
      pa_psychological_first_aid_date = DateTime.MinValue;
      pa_water_rescue_awareness_date = DateTime.MinValue;
      pa_hazmat_awareness_date = DateTime.MinValue;
      pa_ems_strike_team_leader_date = DateTime.MinValue;
      two_years_supervisory_experience_date = DateTime.MinValue;
      var result = false;
      //
      Open();
      var dr = new MySqlCommand("select * from practitioner_strike_team_detail where CAST(practitioner_id AS CHAR) = \"" + practitioner_id + "\"", connection).ExecuteReader();
      if (dr.Read())
        {
        practitioner_id = dr["practitioner_id"].ToString();
        act_1985_33_date = DateTime.Parse(dr["act_1985_33_date"].ToString());
        act_1985_34_date = DateTime.Parse(dr["act_1985_34_date"].ToString());
        act_1994_151_date = DateTime.Parse(dr["act_1994_151_date"].ToString());
        phone_number = dr["phone_number"].ToString();
        phone_service_id = dr["phone_service_id"].ToString();
        be_immune_hepatitis_b = (dr["be_immune_hepatitis_b"].ToString() == "1");
        be_immune_diptheria_tetanus = (dr["be_immune_diptheria_tetanus"].ToString() == "1");
        emergency_contact_1_name = dr["emergency_contact_1_name"].ToString();
        emergency_contact_1_phone_number = dr["emergency_contact_1_phone_number"].ToString();
        emergency_contact_2_name = dr["emergency_contact_2_name"].ToString();
        emergency_contact_2_phone_number = dr["emergency_contact_2_phone_number"].ToString();
        meds_doses = dr["meds_doses"].ToString();
        allergies = dr["allergies"].ToString();
        pcp_name = dr["pcp_name"].ToString();
        drivers_license_expiration = DateTime.Parse(dr["drivers_license_expiration"].ToString());
        nims_is_100_date = DateTime.Parse(dr["nims_is_100_date"].ToString());
        nims_is_200_date = DateTime.Parse(dr["nims_is_200_date"].ToString());
        nims_is_700_date = DateTime.Parse(dr["nims_is_700_date"].ToString());
        nims_is_800_date = DateTime.Parse(dr["nims_is_800_date"].ToString());
        lms_disaster_stress_response_date = DateTime.Parse(dr["lms_disaster_stress_response_date"].ToString());
        lms_ems_mci_ops_date = DateTime.Parse(dr["lms_ems_mci_ops_date"].ToString());
        lms_wmd_date = DateTime.Parse(dr["lms_wmd_date"].ToString());
        lms_smallpox_date = DateTime.Parse(dr["lms_smallpox_date"].ToString());
        lms_basic_med_terrorism_response_date = DateTime.Parse(dr["lms_basic_med_terrorism_response_date"].ToString());
        lms_electrical_hazards_date = DateTime.Parse(dr["lms_electrical_hazards_date"].ToString());
        lms_ems_bioterror_date = DateTime.Parse(dr["lms_ems_bioterror_date"].ToString());
        nims_ics_300_date = DateTime.Parse(dr["nims_ics_300_date"].ToString());
        nims_ics_400_date = DateTime.Parse(dr["nims_ics_400_date"].ToString());
        pa_psychological_first_aid_date = DateTime.Parse(dr["pa_psychological_first_aid_date"].ToString());
        pa_water_rescue_awareness_date = DateTime.Parse(dr["pa_water_rescue_awareness_date"].ToString());
        pa_hazmat_awareness_date = DateTime.Parse(dr["pa_hazmat_awareness_date"].ToString());
        pa_ems_strike_team_leader_date = DateTime.Parse(dr["pa_ems_strike_team_leader_date"].ToString());
        two_years_supervisory_experience_date = DateTime.Parse(dr["two_years_supervisory_experience_date"].ToString());
        result = true;
        }
      dr.Close();
      Close();
      return result;
      }

    public void MakeMemberStatusStatements(bool do_limit_to_uncredentialed)
      {
      Open();
      var dr = new MySqlCommand
        (
        "select email_address"
        + " , last_name"
        + " , first_name"
        + " , IFNULL(certification_number,'nocert') as certification_number"
        + " , phone_number"
        + " , carrier_name"
        + " , emergency_contact_1_name"
        + " , emergency_contact_1_phone_number"
        + " , emergency_contact_2_name"
        + " , emergency_contact_2_phone_number"
        + " , be_immune_hepatitis_b"
        + " , be_immune_diptheria_tetanus"
        + " , IF(DATE_FORMAT(drivers_license_expiration,'%Y-%m-%d') in (null,'0001-01-01','0000-00-00'),'*not on file*',DATE_FORMAT(drivers_license_expiration,'%e %M %Y')) as drivers_license_expiration"
        + " , IF(DATE_FORMAT(nims_is_100_date,'%Y-%m-%d') in (null,'0001-01-01','0000-00-00'),'*not on file*',DATE_FORMAT(nims_is_100_date,'%e %M %Y')) as nims_is_100_date"
        + " , IF(DATE_FORMAT(nims_is_200_date,'%Y-%m-%d') in (null,'0001-01-01','0000-00-00'),'*not on file*',DATE_FORMAT(nims_is_200_date,'%e %M %Y')) as nims_is_200_date"
        + " , IF(DATE_FORMAT(nims_is_700_date,'%Y-%m-%d') in (null,'0001-01-01','0000-00-00'),'*not on file*',DATE_FORMAT(nims_is_700_date,'%e %M %Y')) as nims_is_700_date"
        + " , IF(DATE_FORMAT(act_1985_33_date,'%Y-%m-%d') in (null,'0001-01-01','0000-00-00'),'*not on file*',DATE_FORMAT(act_1985_33_date,'%e %M %Y')) as act_1985_33_date"
        + " , IF(DATE_FORMAT(act_1985_34_date,'%Y-%m-%d') in (null,'0001-01-01','0000-00-00'),'*not on file*',DATE_FORMAT(act_1985_34_date,'%e %M %Y')) as act_1985_34_date"
        + " , IF(DATE_FORMAT(act_1994_151_date,'%Y-%m-%d') in (null,'0001-01-01','0000-00-00'),'*not on file*',DATE_FORMAT(act_1994_151_date,'%e %M %Y')) as act_1994_151_date"
        + " , IF(" + Class_db_practitioner_strike_team_details_Static.BE_TEXTABLE_EXPRESSION + " and " + TClass_db_practitioner_strike_team_details.BeCredentialedAsMemberExpression() + ",'Yes','*No* - your record in this system fails at least one membership requirement') as credentialed_as_member_clause"
        + " , IF(" + Class_db_practitioner_strike_team_details_Static.BE_TEXTABLE_EXPRESSION + " and " + TClass_db_practitioner_strike_team_details.BeCredentialedAsMemberExpression() + " and " + Class_db_practitioner_strike_team_details_Static.BE_CREDENTIALED_AS_LEADER_EXPRESSION + ",'Yes','*No* - your record in this system fails at least one leadership requirement') as credentialed_as_leader_clause"
        + " , GROUP_CONCAT(affiliated_service.name ORDER BY affiliated_service.name SEPARATOR ', ') as service_strike_team_affiliation"
        + " , IFNULL("
        +       " ("
        +       " select email_address"
        +       " from role_member_map"
        +         " join role on (role.id=role_member_map.role_id)"
        +         " join member on (member.id=role_member_map.member_id)"
        +       " where role.name = 'Service Strike Team Manager'"
        +         " and service_id = affiliated_service.id"
        +       " limit 1"
        +       " )"
        +     " ,"
        +       " ''"
        +     " ) as service_strike_team_primary_manager"
        + " from practitioner_strike_team_detail"
        +   " join member on (member.id=practitioner_strike_team_detail.practitioner_id)"
        +   " join sms_gateway on (sms_gateway.id=practitioner_strike_team_detail.phone_service_id)"
        +   " join strike_team_roster on (strike_team_roster.practitioner_id=member.id)"
        +   " join service affiliated_service on (affiliated_service.id=strike_team_roster.service_id)"
        +   " join strike_team_participation_level on (strike_team_participation_level.id=affiliated_service.strike_team_participation_level_id)"
        + " where email_address is not null"
        +   " and TRIM(email_address) <> ''"
        +   " and strike_team_participation_level.description = 'Standing'"
        +   (do_limit_to_uncredentialed ? " and not (" + Class_db_practitioner_strike_team_details_Static.BE_TEXTABLE_EXPRESSION + " and " + TClass_db_practitioner_strike_team_details.BeCredentialedAsMemberExpression() + ")" : k.EMPTY)
        + " group by practitioner_strike_team_detail.id"
        + " order by RAND()",
        connection
        )
        .ExecuteReader();
      while (dr.Read())
        {
        biz_notifications.IssueStrikeTeamMemberStatusStatement
          (
          email_address:dr["email_address"].ToString(),
          last_name:dr["last_name"].ToString().ToUpper(),
          first_name:dr["first_name"].ToString().ToUpper(),
          certification_number:dr["certification_number"].ToString(),
          phone_number:dr["phone_number"].ToString(),
          carrier_name:dr["carrier_name"].ToString(),
          emergency_contact_1_name:dr["emergency_contact_1_name"].ToString(),
          emergency_contact_1_phone_number:dr["emergency_contact_1_phone_number"].ToString(),
          emergency_contact_2_name:dr["emergency_contact_2_name"].ToString(),
          emergency_contact_2_phone_number:dr["emergency_contact_2_phone_number"].ToString(),
          be_immune_hepatitis_b:(dr["be_immune_hepatitis_b"].ToString() == "1"),
          be_immune_diptheria_tetanus:(dr["be_immune_diptheria_tetanus"].ToString() == "1"),
          drivers_license_expiration:dr["drivers_license_expiration"].ToString(),
          nims_is_100_date:dr["nims_is_100_date"].ToString(),
          nims_is_200_date:dr["nims_is_200_date"].ToString(),
          nims_is_700_date:dr["nims_is_700_date"].ToString(),
          act_1985_33_date:dr["act_1985_33_date"].ToString(),
          act_1985_34_date:dr["act_1985_34_date"].ToString(),
          act_1994_151_date:dr["act_1994_151_date"].ToString(),
          credentialed_as_member_clause:dr["credentialed_as_member_clause"].ToString(),
          credentialed_as_leader_clause:dr["credentialed_as_leader_clause"].ToString(),
          service_strike_team_affiliation:dr["service_strike_team_affiliation"].ToString(),
          service_strike_team_primary_manager:dr["service_strike_team_primary_manager"].ToString()
          );
        }
      dr.Close();
      Close();
      }
    public void MakeMemberStatusStatements()
      {
      MakeMemberStatusStatements(do_limit_to_uncredentialed:false);
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
      DateTime lms_ems_bioterror_date,
      DateTime nims_ics_300_date,
      DateTime nims_ics_400_date,
      DateTime pa_psychological_first_aid_date,
      DateTime pa_water_rescue_awareness_date,
      DateTime pa_hazmat_awareness_date,
      DateTime pa_ems_strike_team_leader_date,
      DateTime two_years_supervisory_experience_date
      )
      {
      var childless_field_assignments_clause = k.EMPTY
      + "act_1985_33_date = '" + act_1985_33_date.ToString("yyyy-MM-dd") + "'"
      + " , act_1985_34_date = '" + act_1985_34_date.ToString("yyyy-MM-dd") + "'"
      + " , act_1994_151_date = '" + act_1994_151_date.ToString("yyyy-MM-dd") + "'"
      + " , phone_number = NULLIF('" + phone_number + "','')"
      + " , phone_service_id = NULLIF('" + phone_service_id + "','')"
      + " , be_immune_hepatitis_b = " + be_immune_hepatitis_b.ToString()
      + " , be_immune_diptheria_tetanus = " + be_immune_diptheria_tetanus.ToString()
      + " , emergency_contact_1_name = NULLIF('" + emergency_contact_1_name + "','')"
      + " , emergency_contact_1_phone_number = NULLIF('" + emergency_contact_1_phone_number + "','')"
      + " , emergency_contact_2_name = NULLIF('" + emergency_contact_2_name + "','')"
      + " , emergency_contact_2_phone_number = NULLIF('" + emergency_contact_2_phone_number + "','')"
      + " , meds_doses = NULLIF('" + meds_doses + "','')"
      + " , allergies = NULLIF('" + allergies + "','')"
      + " , pcp_name = NULLIF('" + pcp_name + "','')"
      + " , drivers_license_expiration = '" + drivers_license_expiration.ToString("yyyy-MM-dd") + "'"
      + " , nims_is_100_date = '" + nims_is_100_date.ToString("yyyy-MM-dd") + "'"
      + " , nims_is_200_date = '" + nims_is_200_date.ToString("yyyy-MM-dd") + "'"
      + " , nims_is_700_date = '" + nims_is_700_date.ToString("yyyy-MM-dd") + "'"
      + " , nims_is_800_date = '" + nims_is_800_date.ToString("yyyy-MM-dd") + "'"
      + " , lms_disaster_stress_response_date = '" + lms_disaster_stress_response_date.ToString("yyyy-MM-dd") + "'"
      + " , lms_ems_mci_ops_date = '" + lms_ems_mci_ops_date.ToString("yyyy-MM-dd") + "'"
      + " , lms_wmd_date = '" + lms_wmd_date.ToString("yyyy-MM-dd") + "'"
      + " , lms_smallpox_date = '" + lms_smallpox_date.ToString("yyyy-MM-dd") + "'"
      + " , lms_basic_med_terrorism_response_date = '" + lms_basic_med_terrorism_response_date.ToString("yyyy-MM-dd") + "'"
      + " , lms_electrical_hazards_date = '" + lms_electrical_hazards_date.ToString("yyyy-MM-dd") + "'"
      + " , lms_ems_bioterror_date = '" + lms_ems_bioterror_date.ToString("yyyy-MM-dd") + "'"
      + " , nims_ics_300_date = '" + nims_ics_300_date.ToString("yyyy-MM-dd") + "'"
      + " , nims_ics_400_date = '" + nims_ics_400_date.ToString("yyyy-MM-dd") + "'"
      + " , pa_psychological_first_aid_date = '" + pa_psychological_first_aid_date.ToString("yyyy-MM-dd") + "'"
      + " , pa_water_rescue_awareness_date = '" + pa_water_rescue_awareness_date.ToString("yyyy-MM-dd") + "'"
      + " , pa_hazmat_awareness_date = '" + pa_hazmat_awareness_date.ToString("yyyy-MM-dd") + "'"
      + " , pa_ems_strike_team_leader_date = '" + pa_ems_strike_team_leader_date.ToString("yyyy-MM-dd") + "'"
      + " , two_years_supervisory_experience_date = '" + two_years_supervisory_experience_date.ToString("yyyy-MM-dd") + "'"
      + k.EMPTY;
      db_trail.MimicTraditionalInsertOnDuplicateKeyUpdate
        (
        target_table_name:"practitioner_strike_team_detail",
        key_field_name:"practitioner_id",
        key_field_value:practitioner_id,
        childless_field_assignments_clause:childless_field_assignments_clause
        );
      }

    internal string SmsTargetOf(string practitioner_id)
      {
      Open();
      var sms_target_of_obj = new MySqlCommand
        (
        "select concat(phone_number,'@',hostname)"
        + " from practitioner_strike_team_detail"
        +   " join sms_gateway on (sms_gateway.id=practitioner_strike_team_detail.phone_service_id)"
        + " where practitioner_id = '" + practitioner_id + "'",
        connection
        )
        .ExecuteScalar();
      Close();
      return (sms_target_of_obj == null ? k.EMPTY : sms_target_of_obj.ToString());
      }

    } // end TClass_db_practitioner_strike_team_details

  }
