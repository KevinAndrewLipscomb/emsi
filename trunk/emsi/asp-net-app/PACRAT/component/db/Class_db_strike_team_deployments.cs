// Derived from KiAspdotnetFramework/component/db/Class~db~template~kicrudhelped~items.cs~template

using Class_db;
using Class_db_trail;
using kix;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Web.UI.WebControls;
using UserControl_drop_down_date;

namespace Class_db_strike_team_deployments
  {
  public class TClass_db_strike_team_deployments: TClass_db
    {
    private class strike_team_deployment_summary
      {
      public string id;
      public DateTime creation_date;
      public string name;
      public string region_code;
      }

    private TClass_db_trail db_trail = null;

    public TClass_db_strike_team_deployments() : base()
      {
      db_trail = new TClass_db_trail();
      }

    public bool Bind(string partial_spec, object target)
      {
      var concat_clause = "concat(IFNULL(creation_date,'-'),'|',IFNULL(name,'-'),'|',IFNULL(region_code,'-'))";
      Open();
      ((target) as ListControl).Items.Clear();
      var dr = new MySqlCommand
        (
        "select id"
        + " , CONVERT(" + concat_clause + " USING utf8) as spec"
        + " from strike_team_deployment"
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
      string member_id,
      string sort_order,
      bool be_sort_order_ascending,
      object target
      )
      {
      Open();
      ((target) as BaseDataList).DataSource = new MySqlCommand
        (
        "select strike_team_deployment.id as id"
        + " , DATE_FORMAT(creation_date,'%Y-%m-%d') as creation_date"
        + " , name"
        + " from strike_team_deployment"
        + " where region_code in"
        +   " ("
        +   " select GROUP_CONCAT(code)"
        +   " from region_code_name_map"
        +     " join role_member_map on (role_member_map.region_code=region_code_name_map.code or (role_member_map.region_code is null and role_member_map.service_id is null))"
        +     " join role_privilege_map on (role_privilege_map.role_id=role_member_map.role_id)"
        +     " join privilege on (privilege.id=role_privilege_map.privilege_id)"
        +   " where member_id = '" + member_id + "'"
        +     " and privilege.name = 'config-strike-team-deployments'"
        +     " and be_pacrat_subscriber"
        +   " )",
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
        + " , CONVERT(concat(IFNULL(creation_date,'-'),'|',IFNULL(name,'-'),'|',IFNULL(region_code,'-')) USING utf8) as spec"
        + " FROM strike_team_deployment"
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
        new MySqlCommand(db_trail.Saved("delete from strike_team_deployment where id = \"" + id + "\""), connection).ExecuteNonQuery();
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
      out DateTime creation_date,
      out string name,
      out string region_code
      )
      {
      creation_date = DateTime.MinValue;
      name = k.EMPTY;
      region_code = k.EMPTY;
      var result = false;
      //
      Open();
      var dr = new MySqlCommand("select * from strike_team_deployment where CAST(id AS CHAR) = \"" + id + "\"", connection).ExecuteReader();
      if (dr.Read())
        {
        creation_date = DateTime.Parse(dr["creation_date"].ToString());
        name = dr["name"].ToString();
        region_code = dr["region_code"].ToString();
        result = true;
        }
      dr.Close();
      Close();
      return result;
      }

    public void Set
      (
      string id,
      DateTime creation_date,
      string name,
      string region_code
      )
      {
      var childless_field_assignments_clause = k.EMPTY
      + "creation_date = '" + creation_date.ToString("yyyy-MM-dd") + "'"
      + " , name = NULLIF('" + name + "','')"
      + " , region_code = NULLIF('" + region_code + "','')"
      + k.EMPTY;
      db_trail.MimicTraditionalInsertOnDuplicateKeyUpdate
        (
        target_table_name:"strike_team_deployment",
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
          + " FROM strike_team_deployment"
          + " where id = '" + id + "'",
          connection
          )
          .ExecuteReader()
        );
      dr.Read();
      var the_summary = new strike_team_deployment_summary()
        {
        id = id,
        creation_date = DateTime.Parse(dr["creation_date"].ToString()),
        name = dr["name"].ToString(),
        region_code = dr["region_code"].ToString()
        };
      Close();
      return the_summary;
      }

    } // end TClass_db_strike_team_deployments

  }
