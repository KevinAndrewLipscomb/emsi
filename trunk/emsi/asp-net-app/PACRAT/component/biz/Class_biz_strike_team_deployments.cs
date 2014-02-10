// Derived from KiAspdotnetFramework/component/biz/Class~biz~~template~kicrudhelped~item.cs~template

using Class_biz_notifications;
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

    private TClass_biz_notifications biz_notifications = null;
    private TClass_db_strike_team_deployments db_strike_team_deployments = null;

    public TClass_biz_strike_team_deployments() : base()
      {
      biz_notifications = new TClass_biz_notifications();
      db_strike_team_deployments = new TClass_db_strike_team_deployments();
      }

    internal void AnnounceMobilization
      (
      object summary,
      string supplemental_message,
      string service_id
      )
      {
      //biz_notifications.Issue();
      //biz_notifications.Issue();
      }

    internal bool BeDemobilizationReasonRequired
      (
      string deployment_id,
      string service_strike_team_management_footprint
      )
      {
      return (service_strike_team_management_footprint.Length == 0) && db_strike_team_deployments.BeAnyOperationalPeriodStartedFor(deployment_id);
      }

    internal bool BeOkToMakeMobilizationChangesAndQuickMessages
      (
      string deployment_id,
      string service_strike_team_management_footprint
      )
      {
      return (service_strike_team_management_footprint.Length == 0) || !db_strike_team_deployments.BeAnyOperationalPeriodStartedFor(deployment_id);
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
      out string region_code,
      out bool be_drill
      )
      {
      return db_strike_team_deployments.Get
        (
        id,
        out creation_date,
        out name,
        out region_code,
        out be_drill
        );
      }

    internal string NameOf(object summary)
      {
      return db_strike_team_deployments.NameOf(summary);
      }

    internal string NameOfId(string id)
      {
      return db_strike_team_deployments.NameOfId(id);
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
      string region_code,
      bool be_drill
      )
      {
      db_strike_team_deployments.Set
        (
        id,
        creation_date,
        name,
        region_code,
        be_drill
        );
      }

    internal object Summary(string id)
      {
      return db_strike_team_deployments.Summary(id);
      }

    } // end TClass_biz_strike_team_deployments

  }
