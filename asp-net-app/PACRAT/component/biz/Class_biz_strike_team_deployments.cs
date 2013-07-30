// Derived from KiAspdotnetFramework/component/biz/Class~biz~~template~kicrudhelped~item.cs~template

using Class_db_strike_team_deployments;
using kix;
using System;
using System.Collections;

namespace Class_biz_strike_team_deployments
  {
  internal enum presentation_mode_enum
    {
    NONE,
    FULL_FUNCTION,
    NEW,
    REVIEW_ONLY
    };

  public class TClass_biz_strike_team_deployments
    {
    private TClass_db_strike_team_deployments db_strike_team_deployments = null;

    public TClass_biz_strike_team_deployments() : base()
      {
      db_strike_team_deployments = new TClass_db_strike_team_deployments();
      }

    public bool Bind(string partial_spec, object target)
      {
      return db_strike_team_deployments.Bind(partial_spec, target);
      }

    public void BindBaseDataList
      (
      string member_id,
      string sort_order,
      bool be_sort_order_ascending,
      object target
      )
      {
      db_strike_team_deployments.BindBaseDataList(member_id,sort_order,be_sort_order_ascending,target);
      }

    public void BindDirectToListControl(object target)
      {
      db_strike_team_deployments.BindDirectToListControl(target);
      }

    public bool Delete(string id)
      {
      return db_strike_team_deployments.Delete(id);
      }

    public bool Get
      (
      string id,
      out DateTime creation_date,
      out string name,
      out string region_code
      )
      {
      return db_strike_team_deployments.Get
        (
        id,
        out creation_date,
        out name,
        out region_code
        );
      }

    internal string RegionCodeOf(object summary)
      {
      return db_strike_team_deployments.RegionCodeOf(summary);
      }

    internal string RegionNameOf(object summary)
      {
      return db_strike_team_deployments.RegionNameOf(summary);
      }

    public void Set
      (
      string id,
      DateTime creation_date,
      string name,
      string region_code
      )
      {
      db_strike_team_deployments.Set
        (
        id,
        creation_date,
        name,
        region_code
        );
      }

    internal object Summary(string id)
      {
      return db_strike_team_deployments.Summary(id);
      }

    } // end TClass_biz_strike_team_deployments

  }
