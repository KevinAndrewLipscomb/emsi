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
      public bool be_active;
      }

    private TClass_db_trail db_trail = null;

    public TClass_db_vehicles() : base()
      {
      db_trail = new TClass_db_trail();
      }

    internal bool BeActiveOf(object summary)
      {
      return (summary as vehicle_summary).be_active;
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
        + " , patient_care_level.description as patient_care_level"
        + " , vehicle_kind.description as kind"
        + " , tow_capacity.short_description as tow_capacity"
        + " , fuel.description as fuel"
        + " , license_plate"
        + " , pa_doh_decal_num"
        + " , IF(be_four_or_all_wheel_drive,'YES','no') as be_four_or_all_wheel_drive"
        + " , IFNULL(vehicle.elaboration,'') as elaboration"
        + " from vehicle"
        +   " join patient_care_level on (patient_care_level.id=vehicle.patient_care_level_id)"
        +   " join vehicle_kind on (vehicle_kind.id=vehicle.kind_id)"
        +   " join tow_capacity on (tow_capacity.id=vehicle.tow_capacity_id)"
        +   " join fuel on (fuel.id=vehicle.fuel_id)"
        + " where be_active"
        + (service_filter.Length > 0 ? " and service_id = '" + service_filter + "'" : k.EMPTY)
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

    internal string DesignatorWithCompetingLicensePlate
      (
      string id,
      string license_plate
      )
      {
      Open();
      var designator_with_competing_license_plate_obj = new MySqlCommand
        (
        "select IFNULL(concat(service.name,' ',vehicle.name),'') from vehicle join service on (service.id=vehicle.service_id) where license_plate = '" + license_plate + "' and vehicle.id <> '" + id + "'",
        connection
        )
        .ExecuteScalar();
      Close();
      if (designator_with_competing_license_plate_obj == null)
        {
        return k.EMPTY;
        }
      else
        {
        return designator_with_competing_license_plate_obj.ToString();
        }
      }

    internal string DesignatorWithCompetingPaDohDecalNum
      (
      string id,
      string pa_doh_decal_num
      )
      {
      Open();
      var designator_with_competing_pa_doh_decal_num_obj = new MySqlCommand
        (
        "select IFNULL(concat(service.name,' ',vehicle.name),'') from vehicle join service on (service.id=vehicle.service_id) where pa_doh_decal_num = '" + pa_doh_decal_num + "' and vehicle.id <> '" + id + "'",
        connection
        )
        .ExecuteScalar();
      Close();
      if (designator_with_competing_pa_doh_decal_num_obj == null)
        {
        return k.EMPTY;
        }
      else
        {
        return designator_with_competing_pa_doh_decal_num_obj.ToString();
        }
      }

    public bool Get
      (
      string id,
      out string service_id,
      out string name,
      out string kind_id,
      out string fuel_id,
      out string license_plate,
      out bool be_four_or_all_wheel_drive,
      out string tow_capacity_id,
      out string pa_doh_decal_num,
      out string patient_care_level_id,
      out string elaboration,
      out bool be_active
      )
      {
      service_id = k.EMPTY;
      name = k.EMPTY;
      kind_id = k.EMPTY;
      fuel_id = k.EMPTY;
      license_plate = k.EMPTY;
      be_four_or_all_wheel_drive = false;
      tow_capacity_id = k.EMPTY;
      pa_doh_decal_num = k.EMPTY;
      patient_care_level_id = k.EMPTY;
      elaboration = k.EMPTY;
      be_active = false;
      var result = false;
      //
      Open();
      var dr = new MySqlCommand("select * from vehicle where CAST(id AS CHAR) = '" + id + "'", connection).ExecuteReader();
      if (dr.Read())
        {
        service_id = dr["service_id"].ToString();
        name = dr["name"].ToString();
        kind_id = dr["kind_id"].ToString();
        fuel_id = dr["fuel_id"].ToString();
        license_plate = dr["license_plate"].ToString();
        be_four_or_all_wheel_drive = (dr["be_four_or_all_wheel_drive"].ToString() == "1");
        tow_capacity_id = dr["tow_capacity_id"].ToString();
        pa_doh_decal_num = dr["pa_doh_decal_num"].ToString();
        patient_care_level_id = dr["patient_care_level_id"].ToString();
        elaboration = dr["elaboration"].ToString();
        be_active = (dr["be_active"].ToString() == "1");
        result = true;
        }
      dr.Close();
      Close();
      return result;
      }

    internal string IdByServiceIdAndName(string service_id, string name)
      {
      Open();
      var id_by_service_id_and_name_obj = new MySqlCommand("select id from vehicle where service_id = '" + service_id + "' and name = '" + name + "'",connection).ExecuteScalar();
      Close();
      return (id_by_service_id_and_name_obj == null ? k.EMPTY : id_by_service_id_and_name_obj.ToString());
      }

    internal void MarkInactive(string id)
      {
      Open();
      new MySqlCommand("update vehicle set be_active = FALSE where id = '" + id + "'",connection).ExecuteNonQuery();
      Close();
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
      bool be_four_or_all_wheel_drive,
      string tow_capacity_id,
      string pa_doh_decal_num,
      string patient_care_level_id,
      string elaboration
      )
      {
      var childless_field_assignments_clause = k.EMPTY
      + "service_id = NULLIF('" + service_id + "','')"
      + " , name = NULLIF('" + name + "','')"
      + " , kind_id = NULLIF('" + kind_id + "','')"
      + " , fuel_id = NULLIF('" + fuel_id + "','')"
      + " , license_plate = NULLIF('" + license_plate + "','')"
      + " , be_four_or_all_wheel_drive = " + be_four_or_all_wheel_drive.ToString()
      + " , tow_capacity_id = NULLIF('" + tow_capacity_id + "','')"
      + " , pa_doh_decal_num = NULLIF('" + pa_doh_decal_num + "','')"
      + " , patient_care_level_id = NULLIF('" + patient_care_level_id + "','')"
      + " , elaboration = NULLIF('" + elaboration + "','')"
      ;
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
        service_id = dr["service_id"].ToString(),
        be_active = (dr["be_active"].ToString() == "1")
        };
      Close();
      return the_summary;
      }

    } // end TClass_db_vehicles

  }
