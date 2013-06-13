// Derived from KiAspdotnetFramework/component/biz/Class~biz~~template~kicrudhelped~item.cs~template

using Class_db_strike_team_deployment_operational_period;
using kix;
using System;
using System.Collections;

namespace Class_biz_strike_team_deployment_operational_period
  {
  public class TClass_biz_strike_team_deployment_operational_period
    {
    private TClass_db_strike_team_deployment_operational_period db_strike_team_deployment_operational_period = null;

    public TClass_biz_strike_team_deployment_operational_period() : base()
      {
      db_strike_team_deployment_operational_period = new TClass_db_strike_team_deployment_operational_period();
      }

    public bool Bind(string partial_spec, object target)
      {
      return db_strike_team_deployment_operational_period.Bind(partial_spec, target);
      }

    public void BindBaseDataList
      (
      string sort_order,
      bool be_sort_order_ascending,
      object target
      )
      {
      db_strike_team_deployment_operational_period.BindBaseDataList(sort_order,be_sort_order_ascending,target);
      }

    public void BindDirectToListControl(object target)
      {
      db_strike_team_deployment_operational_period.BindDirectToListControl(target);
      }

    public bool Delete(string id)
      {
      return db_strike_team_deployment_operational_period.Delete(id);
      }

    public bool Get
      (
      string id,
      out string deployment_id,
      out DateTime start,
      out DateTime end
      )
      {
      return db_strike_team_deployment_operational_period.Get
        (
        id,
        out deployment_id,
        out start,
        out end
        );
      }

    public void Set
      (
      string id,
      string deployment_id,
      DateTime start,
      DateTime end
      )
      {
      db_strike_team_deployment_operational_period.Set
        (
        id,
        deployment_id,
        start,
        end
        );
      }

    internal object Summary(string id)
      {
      return db_strike_team_deployment_operational_period.Summary(id);
      }

    } // end TClass_biz_strike_team_deployment_operational_period

  }
