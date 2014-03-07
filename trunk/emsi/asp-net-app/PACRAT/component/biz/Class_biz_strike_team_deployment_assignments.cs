// Derived from KiAspdotnetFramework/component/biz/Class~biz~~template~kicrudhelped~item.cs~template

using Class_db_strike_team_deployment_assignments;
using kix;
using System;
using System.Collections;

namespace Class_biz_strike_team_deployment_assignments
  {
  public class TClass_biz_strike_team_deployment_assignments
    {
    private TClass_db_strike_team_deployment_assignments db_strike_team_deployment_assignments = null;

    public TClass_biz_strike_team_deployment_assignments() : base()
      {
      db_strike_team_deployment_assignments = new TClass_db_strike_team_deployment_assignments();
      }

    public bool Bind(string partial_spec, object target)
      {
      return db_strike_team_deployment_assignments.Bind(partial_spec, target);
      }

    public void BindActualsByDeployment
      (
      string sort_order,
      bool be_sort_order_ascending,
      object target,
      string deployment_id
      )
      {
      db_strike_team_deployment_assignments.BindActualsByDeployment(sort_order,be_sort_order_ascending,target,deployment_id);
      }

    public void BindActualsByOperationalPeriod
      (
      string sort_order,
      bool be_sort_order_ascending,
      object target,
      string operational_period_id,
      string assignment_level_filter
      )
      {
      db_strike_team_deployment_assignments.BindActualsByOperationalPeriod(sort_order,be_sort_order_ascending,target,operational_period_id,assignment_level_filter);
      }

    public void BindBaseDataList
      (
      string sort_order,
      bool be_sort_order_ascending,
      object target
      )
      {
      db_strike_team_deployment_assignments.BindBaseDataList(sort_order,be_sort_order_ascending,target);
      }

    internal void BindDigestByDeployment
      (
      string sort_order,
      bool be_sort_order_ascending,
      object target,
      string deployment_id
      )
      {
      db_strike_team_deployment_assignments.BindDigestByDeployment(sort_order,be_sort_order_ascending,target,deployment_id);
      }

    internal void BindDigestByOperationalPeriod
      (
      string sort_order,
      bool be_sort_order_ascending,
      object target,
      string operational_period_id
      )
      {
      db_strike_team_deployment_assignments.BindDigestByOperationalPeriod(sort_order,be_sort_order_ascending,target,operational_period_id);
      }

    public void BindDirectToListControl(object target)
      {
      db_strike_team_deployment_assignments.BindDirectToListControl(target);
      }

    internal void Copy
      (
      string source_id,
      string target_id
      )
      {
      db_strike_team_deployment_assignments.Copy(source_id,target_id);
      }

    public bool Delete(string id)
      {
      return db_strike_team_deployment_assignments.Delete(id);
      }

    public bool Get
      (
      string id,
      out string operational_period_id,
      out string member_id,
      out string vehicle_id
      )
      {
      return db_strike_team_deployment_assignments.Get
        (
        id,
        out operational_period_id,
        out member_id,
        out vehicle_id
        );
      }

    public void Save
      (
      string operational_period_id,
      string member_id,
      string vehicle_id,
      bool be_assigned
      )
      {
      db_strike_team_deployment_assignments.Save(operational_period_id,member_id,vehicle_id,be_assigned);
      //biz_notifications.IssueForStrikeTeamDeploymentAssignment(member_id,vehicle_id,be_assigned);
      }

    public void Set
      (
      string id,
      string operational_period_id,
      string member_id,
      string vehicle_id
      )
      {
      db_strike_team_deployment_assignments.Set
        (
        id,
        operational_period_id,
        member_id,
        vehicle_id
        );
      }

    internal object Summary(string id)
      {
      return db_strike_team_deployment_assignments.Summary(id);
      }

    } // end TClass_biz_strike_team_deployment_assignments

  }
