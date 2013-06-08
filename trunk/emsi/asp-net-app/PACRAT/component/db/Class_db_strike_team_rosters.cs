// Derived from KiAspdotnetFramework/component/db/Class~db~template~kicrudhelped~items.cs~template

using Class_db;
using Class_db_trail;
using kix;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Web.UI.WebControls;
using UserControl_drop_down_date;

namespace Class_db_strike_team_rosters
  {
  public class TClass_db_strike_team_rosters: TClass_db
    {
    private TClass_db_trail db_trail = null;

    public TClass_db_strike_team_rosters() : base()
      {
      db_trail = new TClass_db_trail();
      }

    public bool Bind(string partial_spec, object target)
      {
      var concat_clause = "concat(id)";
      Open();
      ((target) as ListControl).Items.Clear();
      var dr = new MySqlCommand
        (
        "select id"
        + " , CONVERT(" + concat_clause + " USING utf8) as spec"
        + " from strike_team_roster"
        + " where " + concat_clause + " like '%" + partial_spec.ToUpper() + "%'"
        + " order by spec",
        connection
        )
        .ExecuteReader();
      while (dr.Read())
        {
        ((target) as ListControl).Items.Add(new ListItem(dr["spec"].ToString(), dr["id"].ToString()));
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
        "SELECT id"
        + " , CONVERT(concat(id) USING utf8) as spec"
        + " FROM strike_team_roster"
        + " order by spec",
        connection
        )
        .ExecuteReader();
      while (dr.Read())
        {
        ((target) as ListControl).Items.Add(new ListItem(dr["spec"].ToString(), dr["id"].ToString()));
        }
      dr.Close();
      Close();
      }

    public void BindBaseDataListByServiceId
      (
      string sort_order,
      bool be_sort_order_ascending,
      object target,
      string id
      )
      {
      var condition_clause = k.EMPTY
      +   " (act_1985_33_date is not null)"
      + " and"
      +   " (act_1985_34_date is not null)"
      + " and"
      +   " (act_1994_151_date is not null)"
      + " and"
      +   " (phone_number is not null)"
      + " and"
      +   " (phone_service_id is not null)"
      + " and"
      +   " be_immune_hepatitis_b"
      + " and"
      +   " be_immune_diptheria_tetanus"
      + " and"
      +   " (emergency_contact_1_name is not null)"
      + " and"
      +   " (emergency_contact_1_phone_number is not null)"
      + " and"
      +   " (drivers_license_expiration <= CURDATE())"
      + " and"
      +   " nims_is_100_date is not null"
      + " and"
      +   " nims_is_200_date is not null"
      + " and"
      +   " nims_is_700_date is not null";
      Open();
      ((target) as BaseDataList).DataSource = new MySqlCommand
        (
        "select strike_team_roster.id as id"
        + " , IF(" + condition_clause + ",'Y','N') as be_credentialed"
        + " , practitioner.id as practitioner_id"
        + " , last_name"
        + " , first_name"
        + " , middle_initial"
        + " , practitioner_level.short_description as level"
        + " , LPAD(certification_number,6,'0') as certification_number_for_display"
        + " , IFNULL(DATE_FORMAT(birth_date,'%m/%d/%Y'),'REQUIRED') as birth_date"
        + " , be_birth_date_confirmed"
        + " , IFNULL(email_address,'DESIRED') as email_address"
        + " , practitioner_level.emsrs_code as level_emsrs_code"
        + " , practitioner_status.description as practitioner_status_description"
        + " from strike_team_roster"
        +   " join practitioner on (practitioner.id=strike_team_roster.practitioner_id)"
        +   " join practitioner_level on (practitioner_level.id=practitioner.level_id)"
        +   " join service on (service.id=strike_team_roster.service_id)"
        +   " join practitioner_status on (practitioner_status.id=practitioner.status_id)"
        +   " left join practitioner_strike_team_detail on (practitioner_strike_team_detail.practitioner_id=practitioner.id)"
        + " where service.id = '" + id + "'"
        + " order by " + sort_order.Replace("%", (be_sort_order_ascending ? " asc" : " desc")),
        connection
        )
        .ExecuteReader();
      ((target) as BaseDataList).DataBind();
      (((target) as BaseDataList).DataSource as MySqlDataReader).Close();
      Close();
      }

    public bool Delete(string id)
      {
      var result = true;
      Open();
      try
        {
        new MySqlCommand
          (
          db_trail.Saved
            (
            "delete from strike_team_roster"
            + " where id = '" + id + "'"
            +   " and 'NEEDS_CONED_SPONSOR_FINALIZATION' ="
            +     " ("
            +     " select description"
            +     " from service"
            +       " join service_status on (service_status.id=service.status_id)"
            +     " where service.id = strike_team_roster.service_id"
            +     " )"
            ),
          connection
          )
          .ExecuteNonQuery();
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
      string id,
      out string service_id,
      out string practitioner_id
      )
      {
      service_id = k.EMPTY;
      practitioner_id = k.EMPTY;
      var result = false;
      //
      Open();
      var dr = new MySqlCommand("select * from strike_team_roster where CAST(id AS CHAR) = \"" + id + "\"", connection).ExecuteReader();
      if (dr.Read())
        {
        service_id = dr["service_id"].ToString();
        practitioner_id = dr["practitioner_id"].ToString();
        result = true;
        }
      dr.Close();
      Close();
      return result;
      }

    public void Set
      (
      string id,
      string service_id,
      string practitioner_id
      )
      {
      var childless_field_assignments_clause = k.EMPTY
      + "service_id = NULLIF('" + service_id + "','')"
      + " , practitioner_id = NULLIF('" + practitioner_id + "','')"
      + k.EMPTY;
      Open();
      new MySqlCommand
        (
        db_trail.Saved
          (
          "insert strike_team_roster (id,service_id,practitioner_id)"
          + " select NULLIF('" + id + "','') as id"
          + " , NULLIF('" + service_id + "','') as service_id"
          + " , NULLIF('" + practitioner_id + "','') as practitioner_id"
          + " from service"
          + " where service.id = '" + service_id + "'"
          + " on duplicate key update "
          + childless_field_assignments_clause
          ),
        connection
        )
        .ExecuteNonQuery();
      Close();
      }

    internal string SizeOf(string service_id)
      {
      var size_of = k.EMPTY;
      Open();
      size_of = new MySqlCommand("select count(id) from strike_team_roster where service_id = '" + service_id + "'",connection).ExecuteScalar().ToString();
      Close();
      return size_of;
      }

    } // end TClass_db_strike_team_rosters

  }
