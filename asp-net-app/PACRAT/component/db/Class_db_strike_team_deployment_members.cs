// Derived from KiAspdotnetFramework/component/db/Class~db~template~kicrudhelped~items.cs~template

using Class_db;
using Class_db_practitioner_strike_team_details;
using Class_db_trail;
using kix;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Web.UI.WebControls;
using UserControl_drop_down_date;

namespace Class_db_strike_team_deployment_members
  {
  public class TClass_db_strike_team_deployment_members: TClass_db
    {
    private class strike_team_deployment_member_summary
      {
      public string id;
      }

    private TClass_db_trail db_trail = null;

    public TClass_db_strike_team_deployment_members() : base()
      {
      db_trail = new TClass_db_trail();
      }

    internal bool BeNone(string deployment_id)
      {
      Open();
      var be_none = ("0" == new MySqlCommand("select count(*) from strike_team_deployment_member where deployment_id = '" + deployment_id + "'",connection).ExecuteScalar().ToString());
      Close();
      return be_none;
      }

    public bool Bind(string partial_spec, object target)
      {
      var concat_clause = "concat(IFNULL(deployment_id,'-'),'|',IFNULL(practitioner_id,'-'))";
      Open();
      ((target) as ListControl).Items.Clear();
      var dr = new MySqlCommand
        (
        "select id"
        + " , CONVERT(" + concat_clause + " USING utf8) as spec"
        + " from strike_team_deployment_member"
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

    internal void BindBaseDataList
      (
      string sort_order,
      bool be_sort_order_ascending,
      object target,
      string deployment_id,
      bool do_include_all_eligible_practitioners,
      string service_strike_team_management_footprint
      )
      {
      Open();
      ((target) as BaseDataList).DataSource = new MySqlCommand
        (
        "select strike_team_deployment_member.id as id"
        + " , practitioner.id as practitioner_id"
        + " , last_name"
        + " , first_name"
        + " , short_description as level"
        + " , tag_num"
        + " , email_address"
        + " , concat(phone_number,'@',sms_gateway.hostname) as sms_target"
        + " from strike_team_roster"
        +   " join service on (service.id=strike_team_roster.service_id)"
        +   " join county_region_map on (county_region_map.county_code=service.county_code)"
        +   " join strike_team_deployment on (strike_team_deployment.region_code=county_region_map.region_code and strike_team_deployment.id = '" + deployment_id + "')"
        +   " join practitioner on (practitioner.id=strike_team_roster.practitioner_id)"
        +   " join practitioner_level on (practitioner_level.id=practitioner.level_id)"
        +   " left join practitioner_strike_team_detail on (practitioner_strike_team_detail.practitioner_id=practitioner.id)"
        +   " left join sms_gateway on (sms_gateway.id=practitioner_strike_team_detail.phone_service_id)"
        +   (do_include_all_eligible_practitioners ? " left" : k.EMPTY) + " join strike_team_deployment_member on (strike_team_deployment_member.practitioner_id=strike_team_roster.practitioner_id and strike_team_deployment_member.deployment_id = '" + deployment_id + "')"
        + " where TRUE"
        +   " and" + (do_include_all_eligible_practitioners ? " (" + Class_db_practitioner_strike_team_details_Static.BE_CREDENTIALED_EXPRESSION + " or be_drill)" : " (practitioner_strike_team_detail.id is not null and phone_service_id is not null)")
        +   (service_strike_team_management_footprint.Length > 0 ? " and service.id in (" + service_strike_team_management_footprint + ")" : k.EMPTY) 
        + " order by " + sort_order.Replace("%",(be_sort_order_ascending ? " asc" : " desc")),
        connection
        )
        .ExecuteReader();
      ((target) as BaseDataList).DataBind();
      Close();
      }

    public void BindDirectToListControl(object target)
      {
      Open();
      ((target) as ListControl).Items.Clear();
      var dr = new MySqlCommand
        (
        "SELECT id"
        + " , CONVERT(concat(IFNULL(deployment_id,'-'),'|',IFNULL(practitioner_id,'-')) USING utf8) as spec"
        + " FROM strike_team_deployment_member"
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

    internal void BindUnassignedInOperationalPeriodDirectToListControl
      (
      object target,
      string deployment_id,
      string operational_period_id
      )
      {
      Open();
      (target as ListControl).Items.Clear();
      var dr = new MySqlCommand
        (
        "SELECT practitioner.id as id"
        + " , concat(practitioner.last_name,', ',practitioner.first_name,' (',practitioner_level.short_description,' ',practitioner.certification_number,')') as spec"
        + " FROM strike_team_deployment_member"
        +   " join practitioner on (practitioner.id=strike_team_deployment_member.practitioner_id)"
        +   " join practitioner_level on (practitioner_level.id=practitioner.level_id)"
        + " where deployment_id = '" + deployment_id + "'"
        +   " and practitioner.id not in (select member_id from strike_team_deployment_assignment where operational_period_id = '" + operational_period_id + "')"
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

    public bool Delete(string id)
      {
      var result = true;
      Open();
      try
        {
        new MySqlCommand(db_trail.Saved("delete from strike_team_deployment_member where id = \"" + id + "\""), connection).ExecuteNonQuery();
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
      out string deployment_id,
      out string practitioner_id,
      out string tag_num
      )
      {
      deployment_id = k.EMPTY;
      practitioner_id = k.EMPTY;
      tag_num = k.EMPTY;
      var result = false;
      //
      Open();
      var dr = new MySqlCommand("select * from strike_team_deployment_member where CAST(id AS CHAR) = \"" + id + "\"", connection).ExecuteReader();
      if (dr.Read())
        {
        deployment_id = dr["deployment_id"].ToString();
        practitioner_id = dr["practitioner_id"].ToString();
        tag_num = dr["tag_num"].ToString();
        result = true;
        }
      dr.Close();
      Close();
      return result;
      }

    public void Set
      (
      string id,
      string deployment_id,
      string practitioner_id,
      string tag_num
      )
      {
      var childless_field_assignments_clause = k.EMPTY
      + "deployment_id = NULLIF('" + deployment_id + "','')"
      + " , practitioner_id = NULLIF('" + practitioner_id + "','')"
      + " , tag_num = NULLIF('" + tag_num + "','')"
      + k.EMPTY;
      db_trail.MimicTraditionalInsertOnDuplicateKeyUpdate
        (
        target_table_name:"strike_team_deployment_member",
        key_field_name:"id",
        key_field_value:id,
        childless_field_assignments_clause:childless_field_assignments_clause
        );
      }

    internal object Summary(string id)
      {
      Open();
      var dr =
        (
        new MySqlCommand
          (
          "SELECT *"
          + " FROM strike_team_deployment_member"
          + " where id = '" + id + "'",
          connection
          )
          .ExecuteReader()
        );
      dr.Read();
      var the_summary = new strike_team_deployment_member_summary()
        {
        id = id
        };
      Close();
      return the_summary;
      }

    } // end TClass_db_strike_team_deployment_members

  }
