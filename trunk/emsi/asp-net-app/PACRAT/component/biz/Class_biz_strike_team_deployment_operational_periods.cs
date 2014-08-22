// Derived from KiAspdotnetFramework/component/biz/Class~biz~~template~kicrudhelped~item.cs~template

using Class_db_strike_team_deployment_operational_periods;
using kix;
using System;
using System.Collections;

namespace Class_biz_strike_team_deployment_operational_periods
  {

  internal enum kind_enum
    {
    PRELIM,
    CONVOY,
    STANDARD
    }

  internal enum presentation_mode_enum
    {
    NONE,
    FULL_FUNCTION,
    NEW,
    REVIEW_ONLY
    };

  public class TClass_biz_strike_team_deployment_operational_periods
    {

    //--
    //
    // PRIVATE
    //
    //--

    private TClass_db_strike_team_deployment_operational_periods db_strike_team_deployment_operational_periods = null;

    //--
    //
    // PUBLIC/INTERNAL
    //
    //--

    public TClass_biz_strike_team_deployment_operational_periods() : base()
      {
      db_strike_team_deployment_operational_periods = new TClass_db_strike_team_deployment_operational_periods();
      }

    internal bool BeConvoyOf(object summary)
      {
      return db_strike_team_deployment_operational_periods.BeConvoyOf(summary);
      }

    internal bool BeEmpty(string id)
      {
      return db_strike_team_deployment_operational_periods.BeEmpty(id);
      }

    internal bool BeOverlapInSameDeployment
      (
      string id,
      string deployment_id,
      DateTime start,
      DateTime end
      )
      {
      return db_strike_team_deployment_operational_periods.BeOverlapInSameDeployment(id,deployment_id,start,end);
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
      string deployment_id,
      bool be_unlimited
      )
      {
      db_strike_team_deployment_operational_periods.BindBaseDataList(sort_order,be_sort_order_ascending,target,deployment_id,be_unlimited);
      }

    public bool BindDirectToListControl
      (
      string target_operational_period_id,
      object target
      )
      {
      return db_strike_team_deployment_operational_periods.BindDirectToListControl(target_operational_period_id,target);
      }

    public bool Delete(string id)
      {
      return db_strike_team_deployment_operational_periods.Delete(id);
      }

    internal DateTime EndOf(object summary)
      {
      return db_strike_team_deployment_operational_periods.EndOf(summary);
      }

    internal bool Get
      (
      string id,
      out string deployment_id,
      out DateTime start,
      out DateTime end,
      out bool be_convoy,
      out string prelim_shift_name,
      out kind_enum kind
      )
      {
      var get = false;
      //
      kind = kind_enum.STANDARD;
      //
      if(db_strike_team_deployment_operational_periods.Get
          (
          id,
          out deployment_id,
          out start,
          out end,
          out be_convoy,
          out prelim_shift_name
          )
        )
      //then
        {
        kind = KindOf(start,end,be_convoy,prelim_shift_name);
        get = true;
        }
      return get;
      }

    internal string IdInSameDeploymentWithIdenticalTimes
      (
      string id,
      string deployment_id,
      DateTime start,
      DateTime end
      )
      {
      return db_strike_team_deployment_operational_periods.IdInSameDeploymentWithIdenticalTimes(id,deployment_id,start,end);
      }

    internal kind_enum KindOf
      (
      DateTime start,
      DateTime end,
      bool be_convoy,
      string prelim_shift_name
      )
      {
      var kind_of = kind_enum.STANDARD;
      if (be_convoy)
        {
        kind_of = kind_enum.CONVOY;
        }
      else if ((start == DateTime.MinValue) && (end == DateTime.MinValue) && (prelim_shift_name.Length > 0))
        {
        kind_of = kind_enum.PRELIM;
        }
      return kind_of;
      }

    internal kind_enum KindOf
      (
      string start,
      string end,
      string be_convoy,
      string prelim_shift_name
      )
      {
      return KindOf
        (
        start:(start.Length > 0 ? DateTime.Parse(start) : DateTime.MinValue),
        end:(end.Length > 0 ? DateTime.Parse(end) : DateTime.MinValue),
        be_convoy:(be_convoy == "YES"),
        prelim_shift_name:prelim_shift_name
        );
      }

    internal kind_enum KindOf(object summary)
      {
      return KindOf(StartOf(summary),EndOf(summary),BeConvoyOf(summary),PrelimShiftNameOf(summary));
      }

    internal string PrelimShiftNameOf(object summary)
      {
      return db_strike_team_deployment_operational_periods.PrelimShiftNameOf(summary);
      }

    internal void Set
      (
      string id,
      string deployment_id,
      DateTime start,
      DateTime end,
      bool be_convoy,
      string prelim_shift_name,
      string kind
      )
      {
      if (kind == "PRELIM")
        {
        start = DateTime.MinValue;
        end = DateTime.MinValue;
        be_convoy = false;
        }
      else
        {
        prelim_shift_name = k.EMPTY;
        }
      db_strike_team_deployment_operational_periods.Set
        (
        id,
        deployment_id,
        start,
        end,
        be_convoy,
        prelim_shift_name
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
