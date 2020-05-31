// Derived from KiAspdotnetFramework/component/db/Class~db~template~kicrudhelped~items.cs~template

using Class_db;
using Class_db_trail;
using kix;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Web.UI.WebControls;
using UserControl_drop_down_date;

namespace Class_db_old_analysis_of_region_by_years
  {
  public class TClass_db_old_analysis_of_region_by_years: TClass_db
    {
    private class old_analysis_of_region_by_year_summary
      {
      public string id;
      }

    private readonly TClass_db_trail db_trail = null;

    public TClass_db_old_analysis_of_region_by_years() : base()
      {
      db_trail = new TClass_db_trail();
      }

    public bool Bind(string partial_spec, object target)
      {
      var concat_clause = "concat(IFNULL(region_code,'-'),'|',IFNULL(fiscal_year_ending,'-'),'|',IFNULL(practitioner_level_id,'-'))";
      Open();
      ((target) as ListControl).Items.Clear();
      using var my_sql_command = new MySqlCommand
        (
        "select id"
        + " , CONVERT(" + concat_clause + " USING utf8) as spec"
        + " from old_analysis_of_region_by_year"
        + " where " + concat_clause + " like '%" + partial_spec.ToUpper() + "%'"
        + " order by spec",
        connection
        );
      var dr = my_sql_command.ExecuteReader();
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
      string region_code,
      string practitioner_level_filter
      )
      {
      Open();
      using var my_sql_command = new MySqlCommand
        (
        "select fiscal_year_ending"
        + " , num_classes"
        + " , num_sittings"
        + " , IFNULL(avg_num_students_per_class,'- -') as avg_num_students_per_class"
        + " , num_distinct_practitioners"
        + " from old_analysis_of_region_by_year"
        + " where 1=1"
        +   " and region_code" + (region_code.Length > 0 ? " = '" + region_code + "'" : " is null")
        +   " and practitioner_level_id" + (practitioner_level_filter.Length > 0 ? " = '" + practitioner_level_filter + "'" : " is null")
        + " order by " + sort_order.Replace("%", (be_sort_order_ascending ? " asc" : " desc")),
        connection
        );
      ((target) as BaseDataList).DataSource = my_sql_command.ExecuteReader();
      ((target) as BaseDataList).DataBind();
      Close();
      }

    public void BindDirectToListControl(object target)
      {
      Open();
      ((target) as ListControl).Items.Clear();
      using var my_sql_command = new MySqlCommand
        (
        "SELECT id"
        + " , CONVERT(concat(IFNULL(region_code,'-'),'|',IFNULL(fiscal_year_ending,'-'),'|',IFNULL(practitioner_level_id,'-')) USING utf8) as spec"
        + " FROM old_analysis_of_region_by_year"
        + " order by spec",
        connection
        );
      var dr = my_sql_command.ExecuteReader();
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
        using var my_sql_command = new MySqlCommand(db_trail.Saved("delete from old_analysis_of_region_by_year where id = \"" + id + "\""), connection);
        my_sql_command.ExecuteNonQuery();
        }
      catch(System.Exception e)
        {
        if (e.Message.StartsWith("Cannot delete or update a parent row: a foreign key constraint fails", true, null))
          {
          result = false;
          }
        else
          {
          throw;
          }
        }
      Close();
      return result;
      }

    public bool Get
      (
      string id,
      out string region_code,
      out DateTime fiscal_year_ending,
      out string practitioner_level_id,
      out string num_classes,
      out string num_sittings,
      out string avg_num_students_per_class,
      out string num_distinct_practitioners
      )
      {
      region_code = k.EMPTY;
      fiscal_year_ending = DateTime.MinValue;
      practitioner_level_id = k.EMPTY;
      num_classes = k.EMPTY;
      num_sittings = k.EMPTY;
      avg_num_students_per_class = k.EMPTY;
      num_distinct_practitioners = k.EMPTY;
      var result = false;
      //
      Open();
      using var my_sql_command = new MySqlCommand("select * from old_analysis_of_region_by_year where CAST(id AS CHAR) = \"" + id + "\"", connection);
      var dr = my_sql_command.ExecuteReader();
      if (dr.Read())
        {
        region_code = dr["region_code"].ToString();
        fiscal_year_ending = DateTime.Parse(dr["fiscal_year_ending"].ToString());
        practitioner_level_id = dr["practitioner_level_id"].ToString();
        num_classes = dr["num_classes"].ToString();
        num_sittings = dr["num_sittings"].ToString();
        avg_num_students_per_class = dr["avg_num_students_per_class"].ToString();
        num_distinct_practitioners = dr["num_distinct_practitioners"].ToString();
        result = true;
        }
      dr.Close();
      Close();
      return result;
      }

    public void Set
      (
      string id,
      string region_code,
      DateTime fiscal_year_ending,
      string practitioner_level_id,
      string num_classes,
      string num_sittings,
      string avg_num_students_per_class,
      string num_distinct_practitioners
      )
      {
      var childless_field_assignments_clause = k.EMPTY
      + "region_code = NULLIF('" + region_code + "','')"
      + " , fiscal_year_ending = NULLIF('" + fiscal_year_ending.Year.ToString() + "','')"
      + " , practitioner_level_id = NULLIF('" + practitioner_level_id + "','')"
      + " , num_classes = NULLIF('" + num_classes + "','')"
      + " , num_sittings = NULLIF('" + num_sittings + "','')"
      + " , avg_num_students_per_class = NULLIF('" + k.Safe(avg_num_students_per_class,k.safe_hint_type.REAL_NUM) + "','')"
      + " , num_distinct_practitioners = NULLIF('" + num_distinct_practitioners + "','')"
      + k.EMPTY;
      db_trail.MimicTraditionalInsertOnDuplicateKeyUpdate
        (
        target_table_name:"old_analysis_of_region_by_year",
        key_field_name:"id",
        key_field_value:id,
        childless_field_assignments_clause:childless_field_assignments_clause
        );
      }

    internal object Summary(string id)
      {
      Open();
      using var my_sql_command = new MySqlCommand
        (
        "SELECT *"
        + " FROM old_analysis_of_region_by_year"
        + " where id = '" + id + "'",
        connection
        );
      var dr = my_sql_command.ExecuteReader();
      dr.Read();
      var the_summary = new old_analysis_of_region_by_year_summary()
        {
        id = id
        };
      Close();
      return the_summary;
      }

    } // end TClass_db_old_analysis_of_region_by_years

  }
