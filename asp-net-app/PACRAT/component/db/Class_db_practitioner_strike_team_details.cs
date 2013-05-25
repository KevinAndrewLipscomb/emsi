// Derived from KiAspdotnetFramework/component/db/Class~db~template~kicrudhelped~items.cs~template

using Class_db;
using Class_db_trail;
using kix;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Web.UI.WebControls;
using UserControl_drop_down_date;

namespace Class_db_practitioner_strike_team_details
  {
  public class TClass_db_practitioner_strike_team_details: TClass_db
    {
    private TClass_db_trail db_trail = null;

    public TClass_db_practitioner_strike_team_details() : base()
      {
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
      out bool be_immune_hepatits_b,
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
      act_1985_33_date = DateTime.MinValue;
      act_1985_34_date = DateTime.MinValue;
      act_1994_151_date = DateTime.MinValue;
      phone_number = k.EMPTY;
      phone_service_id = k.EMPTY;
      be_immune_hepatits_b = false;
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
        be_immune_hepatits_b = (dr["be_immune_hepatits_b"].ToString() == "1");
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
        result = true;
        }
      dr.Close();
      Close();
      return result;
      }

    public void Set
      (
      string practitioner_id,
      DateTime act_1985_33_date,
      DateTime act_1985_34_date,
      DateTime act_1994_151_date,
      string phone_number,
      string phone_service_id,
      bool be_immune_hepatits_b,
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
      var childless_field_assignments_clause = k.EMPTY
      + "act_1985_33_date = '" + act_1985_33_date.ToString("yyyy-MM-dd") + "'"
      + " , act_1985_34_date = '" + act_1985_34_date.ToString("yyyy-MM-dd") + "'"
      + " , act_1994_151_date = '" + act_1994_151_date.ToString("yyyy-MM-dd") + "'"
      + " , phone_number = NULLIF('" + phone_number + "','')"
      + " , phone_service_id = NULLIF('" + phone_service_id + "','')"
      + " , be_immune_hepatits_b = NULLIF('" + be_immune_hepatits_b.ToString() + "','')"
      + " , be_immune_diptheria_tetanus = NULLIF('" + be_immune_diptheria_tetanus.ToString() + "','')"
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
      + k.EMPTY;
      db_trail.MimicTraditionalInsertOnDuplicateKeyUpdate
        (
        target_table_name:"practitioner_strike_team_detail",
        key_field_name:"practitioner_id",
        key_field_value:practitioner_id,
        childless_field_assignments_clause:childless_field_assignments_clause
        );
      }

    } // end TClass_db_practitioner_strike_team_details

  }
