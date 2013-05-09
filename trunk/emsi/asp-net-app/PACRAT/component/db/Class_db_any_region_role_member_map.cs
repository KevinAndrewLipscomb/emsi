// Derived from KiAspdotnetFramework/component/db/Class~db~template~kicrudhelped~items.cs~template

using Class_db;
using Class_db_trail;
using kix;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Web.UI.WebControls;
using UserControl_drop_down_date;

namespace Class_db_any_region_role_member_map
  {
  public class TClass_db_any_region_role_member_map: TClass_db
    {
    private TClass_db_trail db_trail = null;

    public TClass_db_any_region_role_member_map() : base()
      {
      db_trail = new TClass_db_trail();
      }

    public bool Bind(string partial_spec, object target)
      {
      var concat_clause = "concat(IFNULL(region_code,'-'),'|',IFNULL(role_id,'-'),'|',IFNULL(member_id,'-'))";
      Open();
      ((target) as ListControl).Items.Clear();
      var dr = new MySqlCommand
        (
        "select id"
        + " , CONVERT(" + concat_clause + " USING utf8) as spec"
        + " from any_region_role_member_map"
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

    internal void BindBaseDataListByRegionCode
      (
      string sort_order,
      bool be_sort_order_ascending,
      object target,
      string code
      )
      {
      Open();
      ((target) as BaseDataList).DataSource = new MySqlCommand
        (
        "select any_region_role_member_map.id as id"
        + " , practitioner.id as practitioner_id"
        + " , last_name"
        + " , first_name"
        + " , middle_initial"
        + " , practitioner_level.short_description as level"
        + " , LPAD(certification_number,6,'0') as certification_number"
        + " , LPAD(certification_number,6,'0') as certification_number_for_display"
        + " , IFNULL(DATE_FORMAT(birth_date,'%m/%d/%Y'),'REQUIRED') as birth_date"
        + " , be_birth_date_confirmed"
        + " , IFNULL(email_address,'DESIRED') as email_address"
        + " , practitioner_level.emsrs_code as level_emsrs_code"
        + " , practitioner_status.description as practitioner_status_description"
        + " from any_region_role_member_map"
        +   " join practitioner on (practitioner.id=any_region_role_member_map.member_id)"
        +   " join practitioner_level on (practitioner_level.id=practitioner.level_id)"
        +   " join region_code_name_map on (region_code_name_map.code=any_region_role_member_map.region_code)"
        +   " join practitioner_status on (practitioner_status.id=practitioner.status_id)"
        + " where region_code = '" + code + "'"
        + " order by " + sort_order.Replace("%", (be_sort_order_ascending ? " asc" : " desc")),
        connection
        )
        .ExecuteReader();
      ((target) as BaseDataList).DataBind();
      (((target) as BaseDataList).DataSource as MySqlDataReader).Close();
      Close();
      }

    public void BindDirectToListControl(object target)
      {
      Open();
      ((target) as ListControl).Items.Clear();
      var dr = new MySqlCommand
        (
        "SELECT id"
        + " , CONVERT(concat(IFNULL(region_code,'-'),'|',IFNULL(role_id,'-'),'|',IFNULL(member_id,'-')) USING utf8) as spec"
        + " FROM any_region_role_member_map"
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
        new MySqlCommand(db_trail.Saved("delete from any_region_role_member_map where id = \"" + id + "\""), connection).ExecuteNonQuery();
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
      out string region_code,
      out string role_id,
      out string member_id
      )
      {
      region_code = k.EMPTY;
      role_id = k.EMPTY;
      member_id = k.EMPTY;
      var result = false;
      //
      Open();
      var dr = new MySqlCommand("select * from any_region_role_member_map where CAST(id AS CHAR) = \"" + id + "\"", connection).ExecuteReader();
      if (dr.Read())
        {
        region_code = dr["region_code"].ToString();
        role_id = dr["role_id"].ToString();
        member_id = dr["member_id"].ToString();
        result = true;
        }
      dr.Close();
      Close();
      return result;
      }

    internal void Save
      (
      string region_code,
      string role_name,
      string member_id,
      bool be_granted
      )
      {
      Open();
      if (be_granted)
        {
        new MySqlCommand(db_trail.Saved("insert ignore role_member_map set member_id = '" + member_id + "', role_id = (select id from role where name = '" + role_name + "')"),connection).ExecuteNonQuery();
        }
      else
        {
        new MySqlCommand(db_trail.Saved("delete from role_member_map where member_id = '" + member_id + "' and role_id = (select id from role where name = '" + role_name + "')"),connection).ExecuteNonQuery();
        }
      Close();
      }

    public void Set
      (
      string id,
      string region_code,
      string role_id,
      string member_id
      )
      {
      var childless_field_assignments_clause = k.EMPTY
      + "region_code = NULLIF('" + region_code + "','')"
      + " , role_id = NULLIF('" + role_id + "','')"
      + " , member_id = NULLIF('" + member_id + "','')"
      + k.EMPTY;
      db_trail.MimicTraditionalInsertOnDuplicateKeyUpdate
        (
        target_table_name:"any_region_role_member_map",
        key_field_name:"id",
        key_field_value:id,
        childless_field_assignments_clause:childless_field_assignments_clause
        );
      }

    } // end TClass_db_any_region_role_member_map

  }
