// Derived from KiAspdotnetFramework/component/db/Class~db~template~kicrudhelped~items.cs~template

using Class_db;
using Class_db_trail;
using kix;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Web.UI.WebControls;
using UserControl_drop_down_date;

namespace Class_db_any_service_role_member_map
  {
  public class TClass_db_any_service_role_member_map: TClass_db
    {
    private TClass_db_trail db_trail = null;

    public TClass_db_any_service_role_member_map() : base()
      {
      db_trail = new TClass_db_trail();
      }

    public bool Bind(string partial_spec, object target)
      {
      var concat_clause = "concat(IFNULL(service_id,'-'),'|',IFNULL(role_id,'-'),'|',IFNULL(member_id,'-'))";
      Open();
      ((target) as ListControl).Items.Clear();
      var dr = new MySqlCommand
        (
        "select id"
        + " , CONVERT(" + concat_clause + " USING utf8) as spec"
        + " from any_service_role_member_map"
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
        + " , CONVERT(concat(IFNULL(service_id,'-'),'|',IFNULL(role_id,'-'),'|',IFNULL(member_id,'-')) USING utf8) as spec"
        + " FROM any_service_role_member_map"
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
        new MySqlCommand(db_trail.Saved("delete from any_service_role_member_map where id = \"" + id + "\""), connection).ExecuteNonQuery();
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
      out string role_id,
      out string member_id
      )
      {
      service_id = k.EMPTY;
      role_id = k.EMPTY;
      member_id = k.EMPTY;
      var result = false;
      //
      Open();
      var dr = new MySqlCommand("select * from any_service_role_member_map where CAST(id AS CHAR) = \"" + id + "\"", connection).ExecuteReader();
      if (dr.Read())
        {
        service_id = dr["service_id"].ToString();
        role_id = dr["role_id"].ToString();
        member_id = dr["member_id"].ToString();
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
      string role_id,
      string member_id
      )
      {
      var childless_field_assignments_clause = k.EMPTY
      + "service_id = NULLIF('" + service_id + "','')"
      + " , role_id = NULLIF('" + role_id + "','')"
      + " , member_id = NULLIF('" + member_id + "','')"
      + k.EMPTY;
      db_trail.MimicTraditionalInsertOnDuplicateKeyUpdate
        (
        target_table_name:"any_service_role_member_map",
        key_field_name:"id",
        key_field_value:id,
        childless_field_assignments_clause:childless_field_assignments_clause
        );
      }

    } // end TClass_db_any_service_role_member_map

  }
