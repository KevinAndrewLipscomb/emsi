// Derived from KiAspdotnetFramework/component/db/Class~db~template~kicrudhelped~items.cs~template

using Class_db;
using Class_db_trail;
using kix;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Web.UI.WebControls;
using UserControl_drop_down_date;

namespace Class_db_vehicles
  {
  public class TClass_db_vehicles: TClass_db
    {
    private class vehicle_summary
      {
      public string id;
      public string service_id;
      }

    private TClass_db_trail db_trail = null;

    public TClass_db_vehicles() : base()
      {
      db_trail = new TClass_db_trail();
      }

    public bool Bind(string partial_spec, object target)
      {
      var concat_clause = "concat(IFNULL(service_id,'-'),'|',IFNULL(name,'-'),'|',IFNULL(kind_id,'-'),'|',IFNULL(fuel_id,'-'),'|',IFNULL(license_plate,'-'),'|',IFNULL(be_four_or_all_wheel_drive,'-'))";
      Open();
      ((target) as ListControl).Items.Clear();
      var dr = new MySqlCommand
        (
        "select id"
        + " , CONVERT(" + concat_clause + " USING utf8) as spec"
        + " from vehicle"
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
      string service_filter
      )
      {
      Open();
      ((target) as BaseDataList).DataSource = new MySqlCommand
        (
        "select vehicle.id as id"
        + " , name"
        + " , vehicle_kind.description as kind"
        + " , fuel.description as fuel"
        + " , license_plate"
        + " , IF(be_four_or_all_wheel_drive,'YES','no') as be_four_or_all_wheel_drive"
        + " from vehicle"
        +   " join vehicle_kind on (vehicle_kind.id=vehicle.kind_id)"
        +   " join fuel on (fuel.id=vehicle.fuel_id)"
        + (service_filter.Length > 0 ? " where service_id = '" + service_filter + "'" : k.EMPTY)
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
        + " , CONVERT(concat(IFNULL(service_id,'-'),'|',IFNULL(name,'-'),'|',IFNULL(kind_id,'-'),'|',IFNULL(fuel_id,'-'),'|',IFNULL(license_plate,'-'),'|',IFNULL(be_four_or_all_wheel_drive,'-')) USING utf8) as spec"
        + " FROM vehicle"
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
        new MySqlCommand(db_trail.Saved("delete from vehicle where id = \"" + id + "\""), connection).ExecuteNonQuery();
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
      out string name,
      out string kind_id,
      out string fuel_id,
      out string license_plate,
      out bool be_four_or_all_wheel_drive
      )
      {
      service_id = k.EMPTY;
      name = k.EMPTY;
      kind_id = k.EMPTY;
      fuel_id = k.EMPTY;
      license_plate = k.EMPTY;
      be_four_or_all_wheel_drive = false;
      var result = false;
      //
      Open();
      var dr = new MySqlCommand("select * from vehicle where CAST(id AS CHAR) = \"" + id + "\"", connection).ExecuteReader();
      if (dr.Read())
        {
        service_id = dr["service_id"].ToString();
        name = dr["name"].ToString();
        kind_id = dr["kind_id"].ToString();
        fuel_id = dr["fuel_id"].ToString();
        license_plate = dr["license_plate"].ToString();
        be_four_or_all_wheel_drive = (dr["be_four_or_all_wheel_drive"].ToString() == "1");
        result = true;
        }
      dr.Close();
      Close();
      return result;
      }

    internal string ServiceIdOf(object summary)
      {
      return (summary as vehicle_summary).service_id;
      }

    public void Set
      (
      string id,
      string service_id,
      string name,
      string kind_id,
      string fuel_id,
      string license_plate,
      bool be_four_or_all_wheel_drive
      )
      {
      var childless_field_assignments_clause = k.EMPTY
      + "service_id = NULLIF('" + service_id + "','')"
      + " , name = NULLIF('" + name + "','')"
      + " , kind_id = NULLIF('" + kind_id + "','')"
      + " , fuel_id = NULLIF('" + fuel_id + "','')"
      + " , license_plate = NULLIF('" + license_plate + "','')"
      + " , be_four_or_all_wheel_drive = " + be_four_or_all_wheel_drive.ToString()
      + k.EMPTY;
      db_trail.MimicTraditionalInsertOnDuplicateKeyUpdate
        (
        target_table_name:"vehicle",
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
          + " FROM vehicle"
          + " where id = '" + id + "'",
          connection
          )
          .ExecuteReader()
        );
      dr.Read();
      var the_summary = new vehicle_summary()
        {
        id = id,
        service_id = dr["service_id"].ToString()
        };
      Close();
      return the_summary;
      }

    } // end TClass_db_vehicles

  }
