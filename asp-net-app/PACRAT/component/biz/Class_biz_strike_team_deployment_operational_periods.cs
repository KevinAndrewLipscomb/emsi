// Derived from KiAspdotnetFramework/component/biz/Class~biz~~template~kicrudhelped~item.cs~template

using Class_db_strike_team_deployment_operational_periods;
using kix;
using System;
using System.Collections;

namespace Class_biz_strike_team_deployment_operational_periods
  {

  internal enum presentation_mode_enum
    {
    NONE,
    FULL_FUNCTION,
    NEW,
    REVIEW_ONLY
    };

  public class TClass_biz_strike_team_deployment_operational_periods
    {
    private TClass_db_strike_team_deployment_operational_periods db_strike_team_deployment_operational_periods = null;

    public TClass_biz_strike_team_deployment_operational_periods() : base()
      {
      db_strike_team_deployment_operational_periods = new TClass_db_strike_team_deployment_operational_periods();
      }

    internal bool BeConvoyOf(object summary)
      {
      return db_strike_team_deployment_operational_periods.BeConvoyOf(summary);
      }

    public bool Bind(string partial_spec, object target)
      {
      return db_strike_team_deployment_operational_periods.Bind(partial_spec, target);
      }

    public void BindBaseDataList
      (
      string sort_order,
      bool be_sort_order_ascending,
      object target,
      string deployment_id
      )
      {
      db_strike_team_deployment_operational_periods.BindBaseDataList(sort_order,be_sort_order_ascending,target,deployment_id);
      }

    public void BindDirectToListControl(object target)
      {
      db_strike_team_deployment_operational_periods.BindDirectToListControl(target);
      }

    public bool Delete(string id)
      {
      return db_strike_team_deployment_operational_periods.Delete(id);
      }

    internal DateTime EndOf(object summary)
      {
      return db_strike_team_deployment_operational_periods.EndOf(summary);
      }

    public bool Get
      (
      string id,
      out string deployment_id,
      out DateTime start,
      out DateTime end,
      out bool be_convoy
      )
      {
      return db_strike_team_deployment_operational_periods.Get
        (
        id,
        out deployment_id,
        out start,
        out end,
        out be_convoy
        );
      }

    internal string IdInSameDeploymentWithCompetingTimes
      (
      string id,
      string deployment_id,
      DateTime start,
      DateTime end
      )
      {
      return db_strike_team_deployment_operational_periods.IdInSameDeploymentWithCompetingTimes(id,deployment_id,start,end);
      }

    public void Set
      (
      string id,
      string deployment_id,
      DateTime start,
      DateTime end,
      bool be_convoy
      )
      {
      db_strike_team_deployment_operational_periods.Set
        (
        id,
        deployment_id,
        start,
        end,
        be_convoy
        );
      }

    internal DateTime StartOf(object summary)
      {
      return db_strike_team_deployment_operational_periods.StartOf(summary);
      }

    internal object Summary(string id)
      {
      return db_strike_team_deployment_operational_periods.Summary(id);
      }

    } // end TClass_biz_strike_team_deployment_operational_period

  }
