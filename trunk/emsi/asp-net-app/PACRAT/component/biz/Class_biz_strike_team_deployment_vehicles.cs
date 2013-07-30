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
      bool do_include_all_eligible_vehicles,
      string service_strike_team_management_footprint
      )
      {
      db_strike_team_deployment_vehicles.BindBaseDataList(sort_order,be_sort_order_ascending,target,deployment_id,do_include_all_eligible_vehicles,service_strike_team_management_footprint);
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

    internal string DesignatorOnDeploymentWithCompetingTacticalName
      (
      string deployment_id,
      string id,
      string tactical_name
      )
      {
      return db_strike_team_deployment_vehicles.DesignatorOnDeploymentWithCompetingTacticalName(deployment_id,id,tactical_name);
      }

    internal string DesignatorOnDeploymentWithCompetingTransponderName
      (
      string deployment_id,
      string id,
      string transponder_name
      )
      {
      return db_strike_team_deployment_vehicles.DesignatorOnDeploymentWithCompetingTransponderName(deployment_id,id,transponder_name);
      }

    public bool Get
      (
      string id,
      out string deployment_id,
      out string vehicle_id,
      out string tactical_name,
      out string transponder_name
      )
      {
      return db_strike_team_deployment_vehicles.Get
        (
        id,
        out deployment_id,
        out vehicle_id,
        out tactical_name,
        out transponder_name
        );
      }

    public void Set
      (
      string id,
      string deployment_id,
      string vehicle_id,
      string tactical_name,
      string transponder_name
      )
      {
      db_strike_team_deployment_vehicles.Set
        (
        id,
        deployment_id,
        vehicle_id,
        tactical_name,
        transponder_name
        );
      }

    internal object Summary(string id)
      {
      return db_strike_team_deployment_vehicles.Summary(id);
      }

    } // end TClass_biz_strike_team_deployment_vehicles

  }
