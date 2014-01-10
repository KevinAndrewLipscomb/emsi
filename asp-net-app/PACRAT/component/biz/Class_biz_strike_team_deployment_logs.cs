// Derived from KiAspdotnetFramework/component/biz/Class~biz~~template~kicrudhelped~item.cs~template

using Class_db_strike_team_deployment_logs;
using kix;
using System;
using System.Collections;

namespace Class_biz_strike_team_deployment_logs
  {
  public class TClass_biz_strike_team_deployment_logs
    {
    private TClass_db_strike_team_deployment_logs db_strike_team_deployment_logs = null;

    public TClass_biz_strike_team_deployment_logs() : base()
      {
      db_strike_team_deployment_logs = new TClass_db_strike_team_deployment_logs();
      }

    public bool Bind(string partial_spec, object target)
      {
      return db_strike_team_deployment_logs.Bind(partial_spec, target);
      }

    public void BindBaseDataList
      (
      string sort_order,
      bool be_sort_order_ascending,
      object target,
      string deployment_id
      )
      {
      db_strike_team_deployment_logs.BindBaseDataList(sort_order,be_sort_order_ascending,target,deployment_id);
      }

    public void BindDirectToListControl(object target)
      {
      db_strike_team_deployment_logs.BindDirectToListControl(target);
      }

    public bool Delete(string id)
      {
      return db_strike_team_deployment_logs.Delete(id);
      }

    internal void Enter
      (
      string deployment_id,
      string action
      )
      {
      db_strike_team_deployment_logs.Enter(deployment_id,action);
      }

    public bool Get
      (
      string id,
      out string deployment_id,
      out string timestamp,
      out string actor_member_id,
      out string action
      )
      {
      return db_strike_team_deployment_logs.Get
        (
        id,
        out deployment_id,
        out timestamp,
        out actor_member_id,
        out action
        );
      }

    public void Set
      (
      string id,
      string deployment_id,
      string timestamp,
      string actor_member_id,
      string action
      )
      {
      db_strike_team_deployment_logs.Set
        (
        id,
        deployment_id,
        timestamp,
        actor_member_id,
        action
        );
      }

    internal object Summary(string id)
      {
      return db_strike_team_deployment_logs.Summary(id);
      }

    } // end TClass_biz_strike_team_deployment_logs

  }
