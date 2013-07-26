// Derived from KiAspdotnetFramework/component/biz/Class~biz~~template~kicrudhelped~item.cs~template

using Class_db_vehicles;
using kix;
using System;
using System.Collections;

namespace Class_biz_vehicles
  {

  internal enum presentation_mode_enum
    {
    NONE,
    FULL_FUNCTION,
    NEW,
    REVIEW_ONLY
    };

  public class TClass_biz_vehicles
    {
    private TClass_db_vehicles db_vehicles = null;

    public TClass_biz_vehicles() : base()
      {
      db_vehicles = new TClass_db_vehicles();
      }

    public bool Bind(string partial_spec, object target)
      {
      return db_vehicles.Bind(partial_spec, target);
      }

    public void BindBaseDataList
      (
      string sort_order,
      bool be_sort_order_ascending,
      object target,
      string service_filter
      )
      {
      db_vehicles.BindBaseDataList(sort_order,be_sort_order_ascending,target,service_filter);
      }

    public void BindDirectToListControl(object target)
      {
      db_vehicles.BindDirectToListControl(target);
      }

    public bool Delete(string id)
      {
      return db_vehicles.Delete(id);
      }

    internal string DesignatorWithCompetingLicensePlate
      (
      string id,
      string license_plate
      )
      {
      return db_vehicles.DesignatorWithCompetingLicensePlate(id,license_plate);
      }

    internal string DesignatorWithCompetingPaDohDecalNum
      (
      string id,
      string pa_doh_decal_num
      )
      {
      return db_vehicles.DesignatorWithCompetingPaDohDecalNum(id,pa_doh_decal_num);
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
      out string patient_care_level_id
      )
      {
      return db_vehicles.Get
        (
        id,
        out service_id,
        out name,
        out kind_id,
        out fuel_id,
        out license_plate,
        out be_four_or_all_wheel_drive,
        out tow_capacity_id,
        out pa_doh_decal_num,
        out patient_care_level_id
        );
      }

    internal string IdByServiceIdAndName
      (
      string service_id,
      string name
      )
      {
      return db_vehicles.IdByServiceIdAndName(service_id,name);
      }

    internal string ServiceIdOf(object summary)
      {
      return db_vehicles.ServiceIdOf(summary);
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
      string patient_care_level_id
      )
      {
      db_vehicles.Set
        (
        id,
        service_id,
        name.ToUpper(),
        kind_id,
        fuel_id,
        license_plate.ToUpper(),
        be_four_or_all_wheel_drive,
        tow_capacity_id,
        pa_doh_decal_num,
        patient_care_level_id
        );
      }

    internal object Summary(string id)
      {
      return db_vehicles.Summary(id);
      }

    } // end TClass_biz_vehicles

  }
