// Derived from KiAspdotnetFramework/component/db/Class~db~template~kicrudhelped~items.cs~template

using Class_db;
using Class_db_trail;
using kix;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Web.UI.WebControls;
using UserControl_drop_down_date;

namespace Class_db_strike_team_deployment_operational_periods
  {
  public class TClass_db_strike_team_deployment_operational_periods: TClass_db
    {
    private class strike_team_deployment_operational_periods_summary
      {
      public string id;
      public DateTime start;
      public DateTime end;
      public bool be_convoy;
      public string prelim_shift_name;
      }

    private TClass_db_trail db_trail = null;

    public TClass_db_strike_team_deployment_operational_periods() : base()
      {
      db_trail = new TClass_db_trail();
      }

    internal bool BeConvoyOf(object summary)
      {
      return (summary as strike_team_deployment_operational_periods_summary).be_convoy;
      }

    public bool Bind(string partial_spec, object target)
      {
      var concat_clause = "concat(IFNULL(deployment_id,'-'),'|',IFNULL(start,'-'),'|',IFNULL(end,'-'))";
      Open();
      ((target) as ListControl).Items.Clear();
      var dr = new MySqlCommand
        (
        "select id"
        + " , CONVERT(" + concat_clause + " USING utf8) as spec"
        + " from strike_team_deployment_operational_period"
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
      string deployment_id
      )
      {
      Open();
      ((target) as BaseDataList).DataSource = new MySqlCommand
        (
        "select id"
        + " , prelim_shift_name"
        + " , DATE_FORMAT(start,'%Y-%m-%d %H:%i') as start"
        + " , DATE_FORMAT(end,'%Y-%m-%d %H:%i') as end"
        + " , be_convoy"
        + " from strike_team_deployment_operational_period"
        + " where deployment_id = '" + deployment_id + "'"
        + " order by " + sort_order.Replace("%",(be_sort_order_ascending ? " asc" : " desc")),
        connection
        )
        .ExecuteReader();
      ((target) as BaseDataList).DataBind();
      Close();
      }

    public bool BindDirectToListControl
      (
      string target_operational_period_id,
      object target
      )
      {
      Open();
      ((target) as ListControl).Items.Clear();
      var dr = new MySqlCommand
        (
        "SELECT id"
        + " , CONVERT(IF(start is null and end is null and prelim_shift_name <> '',concat('PRELIM - ',prelim_shift_name),concat(IF(be_convoy,'CVY','STD'),' ',DATE_FORMAT(start,'%Y-%m-%d %H:%i'),' - ',DATE_FORMAT(end,'%Y-%m-%d %H:%i'))) USING utf8) as spec"
        + " FROM strike_team_deployment_operational_period"
        + " where deployment_id = (select deployment_id from strike_team_deployment_operational_period where id = '" + target_operational_period_id + "')"
        +   " and (start < (select start from strike_team_deployment_operational_period where id = '" + target_operational_period_id + "') or (start is null and end is null and prelim_shift_name <> ''))"
        + " order by start desc, end desc, prelim_shift_name",
        connection
        )
        .ExecuteReader();
      while (dr.Read())
        {
        ((target) as ListControl).Items.Add(new ListItem(dr["spec"].ToString(), dr["id"].ToString()));
        }
      dr.Close();
      Close();
      return (((target) as ListControl).Items.Count > 0);
      }

    public bool Delete(string id)
      {
      var result = true;
      Open();
      try
        {
        new MySqlCommand(db_trail.Saved("delete from strike_team_deployment_operational_period where id = \"" + id + "\""), connection).ExecuteNonQuery();
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

    internal DateTime EndOf(object summary)
      {
      return (summary as strike_team_deployment_operational_periods_summary).end;
      }

    public bool Get
      (
      string id,
      out string deployment_id,
      out DateTime start,
      out DateTime end,
      out bool be_convoy,
      out string prelim_shift_name
      )
      {
      deployment_id = k.EMPTY;
      start = DateTime.MinValue;
      end = DateTime.MinValue;
      be_convoy = false;
      prelim_shift_name = k.EMPTY;
      var result = false;
      //
      Open();
      var dr = new MySqlCommand("select * from strike_team_deployment_operational_period where CAST(id AS CHAR) = \"" + id + "\"", connection).ExecuteReader();
      if (dr.Read())
        {
        var start_obj = dr["start"];
        var end_obj = dr["end"];
        //
        deployment_id = dr["deployment_id"].ToString();
        start = (start_obj == DBNull.Value ? DateTime.MinValue : DateTime.Parse(start_obj.ToString()));
        end = (end_obj == DBNull.Value ? DateTime.MinValue : DateTime.Parse(dr["end"].ToString()));
        be_convoy = ("1" == dr["be_convoy"].ToString());
        prelim_shift_name = dr["prelim_shift_name"].ToString();
        result = true;
        }
      dr.Close();
      Close();
      return result;
      }

    internal string IdInSameDeploymentWithCompetingTimes
      (
      string id,
      string deployment_id,
      DateTime start,
      DateTime end
      )
      {
      Open();
      var id_in_same_deployment_with_competing_times_obj = new MySqlCommand
        (
        "select IFNULL(id,'')"
        + " from strike_team_deployment_operational_period"
        + " where deployment_id = '" + deployment_id + "'"
        +   " and start = '" + start.ToString("yyyy-MM-dd HH:mm") + "'"
        +   " and end = '" + end.ToString("yyyy-MM-dd HH:mm") + "'"
        +   " and id <> '" + id + "'",
        connection
        )
        .ExecuteScalar();
      Close();
      if (id_in_same_deployment_with_competing_times_obj == null)
        {
        return k.EMPTY;
        }
      else
        {
        return id_in_same_deployment_with_competing_times_obj.ToString();
        }
      }

    internal string PrelimShiftNameOf(object summary)
      {
      return (summary as strike_team_deployment_operational_periods_summary).prelim_shift_name;
      }

    public void Set
      (
      string id,
      string deployment_id,
      DateTime start,
      DateTime end,
      bool be_convoy,
      string prelim_shift_name
      )
      {
      var childless_field_assignments_clause = k.EMPTY
      + "deployment_id = NULLIF('" + deployment_id + "','')"
      + " , start = NULLIF('" + (start == DateTime.MinValue ? k.EMPTY : start.ToString("s")) + "','')"
      + " , end = NULLIF('" + (end == DateTime.MinValue ? k.EMPTY : end.ToString("s")) + "','')"
      + " , be_convoy = " + be_convoy.ToString()
      + " , prelim_shift_name = NULLIF('" + prelim_shift_name + "','')"
      + k.EMPTY;
      db_trail.MimicTraditionalInsertOnDuplicateKeyUpdate
        (
        target_table_name:"strike_team_deployment_operational_period",
        key_field_name:"id",
        key_field_value:id,
        childless_field_assignments_clause:childless_field_assignments_clause
        );
      }

    internal DateTime StartOf(object summary)
      {
      return (summary as strike_team_deployment_operational_periods_summary).start;
      }

    internal object Summary(string id)
      {
      Open();
      var dr =
        (
        new MySqlCommand
          (
          "SELECT *"
          + " FROM strike_team_deployment_operational_period"
          + " where id = '" + id + "'",
          connection
          )
          .ExecuteReader()
        );
      dr.Read();
      var start_obj = dr["start"];
      var end_obj = dr["end"];
      var the_summary = new strike_team_deployment_operational_periods_summary()
        {
        id = id,
        start = (start_obj == DBNull.Value ? DateTime.MinValue : DateTime.Parse(start_obj.ToString())),
        end = (end_obj == DBNull.Value ? DateTime.MinValue : DateTime.Parse(end_obj.ToString())),
        be_convoy = (dr["be_convoy"].ToString() == "1"),
        prelim_shift_name = dr["prelim_shift_name"].ToString()
        };
      Close();
      return the_summary;
      }

    } // end TClass_db_strike_team_deployment_operational_period

  }
