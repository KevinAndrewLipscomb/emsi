// Derived from KiAspdotnetFramework/component/db/Class~db~template~kicrudhelped~items.cs~template

using Class_db;
using Class_db_trail;
using kix;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Web.UI.WebControls;
using UserControl_drop_down_date;

namespace Class_db_tow_capacities
  {
  public class TClass_db_tow_capacities: TClass_db
    {
    private class tow_capacity_summary
      {
      public string id;
      }

    private TClass_db_trail db_trail = null;

    public TClass_db_tow_capacities() : base()
      {
      db_trail = new TClass_db_trail();
      }

    public bool Bind(string partial_spec, object target)
      {
      var concat_clause = "concat(IFNULL(short_description,'-'),'|',IFNULL(long_description,'-'),'|',IFNULL(pecking_order,'-'))";
      Open();
      ((target) as ListControl).Items.Clear();
      var dr = new MySqlCommand
        (
        "select id"
        + " , CONVERT(" + concat_clause + " USING utf8) as spec"
        + " from tow_capacity"
        + " where " + concat_clause + " like '%" + partial_spec.ToUpper() + "%'"
        + " order by pecking_order",
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
      object target
      )
      {
      Open();
      ((target) as BaseDataList).DataSource = new MySqlCommand
        (
        "select tow_capacity.id as id"
        + " from tow_capacity",
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
        + " , CONVERT(concat(IFNULL(short_description,'-'),'|',IFNULL(long_description,'-'),'|',IFNULL(pecking_order,'-')) USING utf8) as spec"
        + " FROM tow_capacity"
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

    public void BindLongDescriptionDirectToListControl(object target)
      {
      Open();
      ((target) as ListControl).Items.Clear();
      var dr = new MySqlCommand
        (
        "SELECT id"
        + " , long_description as spec"
        + " FROM tow_capacity"
        + " order by pecking_order",
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
        new MySqlCommand(db_trail.Saved("delete from tow_capacity where id = \"" + id + "\""), connection).ExecuteNonQuery();
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
      out string short_description,
      out string long_description,
      out string pecking_order
      )
      {
      short_description = k.EMPTY;
      long_description = k.EMPTY;
      pecking_order = k.EMPTY;
      var result = false;
      //
      Open();
      var dr = new MySqlCommand("select * from tow_capacity where CAST(id AS CHAR) = \"" + id + "\"", connection).ExecuteReader();
      if (dr.Read())
        {
        short_description = dr["short_description"].ToString();
        long_description = dr["long_description"].ToString();
        pecking_order = dr["pecking_order"].ToString();
        result = true;
        }
      dr.Close();
      Close();
      return result;
      }

    public void Set
      (
      string id,
      string short_description,
      string long_description,
      string pecking_order
      )
      {
      var childless_field_assignments_clause = k.EMPTY
      + "short_description = NULLIF('" + short_description + "','')"
      + " , long_description = NULLIF('" + long_description + "','')"
      + " , pecking_order = NULLIF('" + pecking_order + "','')"
      + k.EMPTY;
      db_trail.MimicTraditionalInsertOnDuplicateKeyUpdate
        (
        target_table_name:"tow_capacity",
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
          + " FROM tow_capacity"
          + " where id = '" + id + "'",
          connection
          )
          .ExecuteReader()
        );
      dr.Read();
      var the_summary = new tow_capacity_summary()
        {
        id = id
        };
      Close();
      return the_summary;
      }

    } // end TClass_db_tow_capacities

  }
