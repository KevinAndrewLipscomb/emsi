// Derived from KiAspdotnetFramework/component/biz/Class~biz~~template~kicrudhelped~item.cs~template

using Class_db_strike_team_deployment_vehicles;
using kix;
using System;
using System.Collections;

namespace Class_biz_strike_team_deployment_vehicles
  {
  public class TClass_biz_strike_team_deployment_vehicles
    {
    private TClass_db_strike_team_deployment_vehicles db_strike_team_deployment_vehicles = null;

    public TClass_biz_strike_team_deployment_vehicles() : base()
      {
      db_strike_team_deployment_vehicles = new TClass_db_strike_team_deployment_vehicles();
      }

    public bool Bind(string partial_spec, object target)
      {
      return db_strike_team_deployment_vehicles.Bind(partial_spec, target);
      }

    public void BindBaseDataList
      (
      string sort_order,
      bool be_sort_order_ascending,
      object target,
      string deployment_id,
      bool do_include_all_eligible_vehicles
      )
      {
      db_strike_team_deployment_vehicles.BindBaseDataList(sort_order,be_sort_order_ascending,target,deployment_id,do_include_all_eligible_vehicles);
      }

    public void BindDirectToListControl
      (
      object target,
      string deployment_id
      )
      {
      db_strike_team_deployment_vehicles.BindDirectToListControl(target,deployment_id);
      }

    public bool Delete(string id)
      {
      return db_strike_team_deployment_vehicles.Delete(id);
      }

    public bool Get
      (
      string id,
      out string deployment_id,
      out string vehicle_id
      )
      {
      return db_strike_team_deployment_vehicles.Get
        (
        id,
        out deployment_id,
        out vehicle_id
        );
      }

    public void Set
      (
      string id,
      string deployment_id,
      string vehicle_id
      )
      {
      db_strike_team_deployment_vehicles.Set
        (
        id,
        deployment_id,
        vehicle_id
        );
      }

    internal object Summary(string id)
      {
      return db_strike_team_deployment_vehicles.Summary(id);
      }

    } // end TClass_biz_strike_team_deployment_vehicles

  }
