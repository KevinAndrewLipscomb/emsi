// Derived from KiAspdotnetFramework/component/biz/Class~biz~~template~kicrudhelped~item.cs~template

using Class_biz_notifications;
using Class_biz_role_member_map;
using Class_biz_services;
using Class_biz_strike_team_deployment_assignments;
using Class_biz_strike_team_deployment_logs;
using Class_biz_strike_team_deployment_members;
using Class_biz_strike_team_deployment_operational_periods;
using Class_biz_strike_team_deployment_vehicles;
using Class_db_practitioner_strike_team_details;
using Class_db_strike_team_deployments;
using kix;
using System;
using System.Web.UI.WebControls;
using UserControl_operational_period_detail;

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
    private TClass_biz_role_member_map biz_role_member_map = null;
    private TClass_biz_services biz_services = null;
    private TClass_biz_strike_team_deployment_assignments biz_strike_team_deployment_assignments = null;
    private TClass_biz_strike_team_deployment_logs biz_strike_team_deployment_logs = null;
    private TClass_biz_strike_team_deployment_members biz_strike_team_deployment_members = null;
    private TClass_biz_strike_team_deployment_operational_periods biz_strike_team_deployment_operational_periods = null;
    private TClass_biz_strike_team_deployment_vehicles biz_strike_team_deployment_vehicles = null;
    private TClass_db_practitioner_strike_team_details db_practitioner_strike_team_details = null;
    private TClass_db_strike_team_deployments db_strike_team_deployments = null;

    public TClass_biz_strike_team_deployments() : base()
      {
      biz_notifications = new TClass_biz_notifications();
      biz_role_member_map = new TClass_biz_role_member_map();
      biz_services = new TClass_biz_services();
      biz_strike_team_deployment_assignments = new TClass_biz_strike_team_deployment_assignments();
      biz_strike_team_deployment_logs = new TClass_biz_strike_team_deployment_logs();
      biz_strike_team_deployment_members = new TClass_biz_strike_team_deployment_members();
      biz_strike_team_deployment_operational_periods = new TClass_biz_strike_team_deployment_operational_periods();
      biz_strike_team_deployment_vehicles = new TClass_biz_strike_team_deployment_vehicles();
      db_practitioner_strike_team_details = new TClass_db_practitioner_strike_team_details();
      db_strike_team_deployments = new TClass_db_strike_team_deployments();
      }

    internal void AnnounceMobilization
      (
      object summary,
      string supplemental_message,
      string service_id
      )
      {
      var target = k.EMPTY;
      if ((target = biz_role_member_map.EmailTargetOfByExplicitServiceId("Service Strike Team Manager",service_id)).Length > 0)
        {
        biz_notifications.IssueMobilizationAnnouncementEmail
          (
          target:target,
          deployment_name:NameOf(summary),
          service_name:biz_services.ShortNameOf(service_id),
          region_name:RegionNameOf(summary),
          actual_vs_drill_indicator:(BeDrill(summary) ? "This deployment is a DRILL." : "This is an ACTUAL DEPLOYMENT, not a drill."),
          supplemental_message:supplemental_message,
          region_strike_team_manager_target:biz_role_member_map.EmailTargetOfByExplicitRegionCode("Region Strike Team Manager",RegionCodeOf(summary))
          );
        if ((target = biz_role_member_map.SmsTargetOfByExplicitServiceId("Service Strike Team Manager",service_id)).Length > 0)
          {
          biz_notifications.IssueMobilizationAnnouncementSms
            (
            target:target,
            actual_vs_drill_indicator:(BeDrill(summary) ? "This is a DRILL." : "This is NOT A DRILL.")
            );
          }
        }
      }

    internal bool AssignMemberTag
      (
      string deployment_id,
      string mobilization_id,
      string practitioner_id,
      string name,
      string tag_num,
      string sms_target
      )
      {
      var assign_member_tag = false;
      if (biz_strike_team_deployment_members.BeTagAvailableForAssignment(deployment_id,practitioner_id,tag_num) || (tag_num.Length == 0))
        {
        biz_strike_team_deployment_members.Set
          (
          id: mobilization_id,
          deployment_id: deployment_id,
          practitioner_id: practitioner_id,
          tag_num: tag_num
          );
        biz_strike_team_deployment_logs.Enter
          (
          deployment_id: deployment_id,
          action: "assigned tag `" + tag_num + "` to member `" + name + "`"
          );
        if (tag_num.Length > 0)
          {
          biz_notifications.IssueForDeploymentMemberTagAssignment
            (
            target:sms_target,
            tag_num:tag_num
            );
          }
        else
          {
          biz_notifications.IssueForDeploymentMemberTagDeassignment(target:sms_target);
          }
        assign_member_tag = true;
        }
      return assign_member_tag;
      }

    internal bool AssignVehicleTagTransponder
      (
      string deployment_id,
      string mobilization_id,
      string vehicle_id,
      string static_name,
      string tactical_name,
      string transponder_name
      )
      {
      var assign_vehicle_tag_transponder = false;
      if (biz_strike_team_deployment_vehicles.BeTagTransponderAvailableForAssignment(deployment_id,vehicle_id,tactical_name,transponder_name) || (tactical_name.Length + transponder_name.Length == 0))
        {
        biz_strike_team_deployment_vehicles.Set
          (
          id: mobilization_id,
          deployment_id: deployment_id,
          vehicle_id: vehicle_id,
          tactical_name: tactical_name,
          transponder_name: transponder_name
          );
        biz_strike_team_deployment_logs.Enter
          (
          deployment_id: deployment_id,
          action: "assigned tactical name `" + tactical_name + "` and transponder `" + transponder_name + "` to vehicle `" + static_name + "`"
          );
        assign_vehicle_tag_transponder = true;
        }
      return assign_vehicle_tag_transponder;
      }

    internal bool BeAllConcludedWithinScope(string member_id)
      {
      return db_strike_team_deployments.BeAllConcludedWithinScope(member_id);
      }

    internal bool BeDemobilizationReasonRequired
      (
      string deployment_id,
      string service_strike_team_management_footprint
      )
      {
      return (service_strike_team_management_footprint.Length == 0) && db_strike_team_deployments.BeAnyOperationalPeriodStartedFor(deployment_id);
      }

    internal bool BeDrill(object summary)
      {
      return db_strike_team_deployments.BeDrill(summary);
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

    internal void CopyAssignments
      (
      string deployment_id,
      string source_operational_period_id,
      string target_operational_period_id,
      DataGrid datagrid_control
      )
      {
      //
      // Take advantage of the fact that we already have a way to pull a prior op period's assignments into a DataGrid, and we already have constant indexes into the DataGrid's columns defined in
      // UserControl_operational_period_detail.  This cheat depends on receiving a pointer to the DataGrid from the caller, so that the DataSource-to-DataBind transformation will be what we expect (that is, it will be defined
      // by the code in the caller's ASCX file.
      //
      biz_strike_team_deployment_assignments.BindActualsByOperationalPeriod
        (
        sort_order:UserControl_operational_period_detail_Static.INITIAL_SORT_ORDER,
        be_sort_order_ascending:true,
        target:datagrid_control,
        operational_period_id:source_operational_period_id,
        assignment_level_filter:k.EMPTY
        );
      foreach (DataGridItem source_assignment in datagrid_control.Items)
        {
        MakeOperationalPeriodAssignment
          (
          deployment_id:deployment_id,
          operational_period_id:target_operational_period_id,
          member_id:source_assignment.Cells[UserControl_operational_period_detail_Static.CI_MEMBER_ID].Text,
          member_designator:source_assignment.Cells[UserControl_operational_period_detail_Static.CI_MEMBER_DESIGNATOR].Text,
          vehicle_id:source_assignment.Cells[UserControl_operational_period_detail_Static.CI_VEHICLE_ID].Text,
          vehicle_designator:source_assignment.Cells[UserControl_operational_period_detail_Static.CI_VEHICLE].Text
          );
        }
      }

    public bool Delete(string id)
      {
      return db_strike_team_deployments.Delete(id);
      }

    internal void DemobilizeMember
      (
      string deployment_id,
      string deployment_name,
      string mobilization_id,
      string name,
      string sms_target
      )
      {
      biz_strike_team_deployment_members.Delete(mobilization_id);
      biz_strike_team_deployment_logs.Enter
        (
        deployment_id: deployment_id,
        action: "demobilized member `" + name + "`"
        );
      biz_notifications.IssueForDeploymentMemberDemobilization
        (
        target:sms_target,
        deployment_name:deployment_name
        );
      }

    internal void DemobilizeMemberUnderway
      (
      string deployment_id,
      string deployment_name,
      string mobilization_id,
      string asset_designator,
      string reason,
      string sms_target
      )
      {
      biz_strike_team_deployment_members.Delete(mobilization_id);
      biz_strike_team_deployment_logs.Enter
        (
        deployment_id: deployment_id,
        action: "performed an underway demobilization of member `" + asset_designator + "` citing `" + reason + "`"
        );
      biz_notifications.IssueForDeploymentMemberDemobilization
        (
        target:sms_target,
        deployment_name:deployment_name
        );
      }

    internal void DemobilizeVehicle
      (
      string deployment_id,
      string mobilization_id,
      string static_name
      )
      {
      biz_strike_team_deployment_vehicles.Delete(mobilization_id);
      biz_strike_team_deployment_logs.Enter
        (
        deployment_id:deployment_id,
        action:"demobilized vehicle `" + static_name + "`"
        );
      }

    internal void DemobilizeVehicleUnderway
      (
      string deployment_id,
      string mobilization_id,
      string asset_designator,
      string reason
      )
      {
      biz_strike_team_deployment_vehicles.Delete(mobilization_id);
      biz_strike_team_deployment_logs.Enter
        (
        deployment_id: deployment_id,
        action: "performed an underway demobilization of vehicle `" + asset_designator + "` citing `" + reason + "`"
        );
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

    internal void MakeOperationalPeriodAssignment
      (
      string deployment_id,
      string operational_period_id,
      string member_id,
      string member_designator,
      string vehicle_id,
      string vehicle_designator
      )
      {
      biz_strike_team_deployment_assignments.Save
        (
        operational_period_id: operational_period_id,
        member_id: member_id,
        vehicle_id: vehicle_id,
        be_assigned: true
        );
      var operational_period_summary = biz_strike_team_deployment_operational_periods.Summary(id: operational_period_id);
      var be_convoy = biz_strike_team_deployment_operational_periods.BeConvoyOf(operational_period_summary);
      var start = biz_strike_team_deployment_operational_periods.StartOf(operational_period_summary);
      var end = biz_strike_team_deployment_operational_periods.EndOf(operational_period_summary);
      biz_strike_team_deployment_logs.Enter
        (
        deployment_id: deployment_id,
        action: "assigned member `" + member_designator + "`"
        + " to vehicle `" + vehicle_designator + "`"
        + " for " + (be_convoy ? "convoy" : "operational period")
        + " from " + start.ToString("yyyy-MM-dd HH:mm")
        + " to " + end.ToString("yyyy-MM-dd HH:mm")
        );
      biz_notifications.IssueForOperationalPeriodAssignment
        (
        target:db_practitioner_strike_team_details.SmsTargetOf(member_id),
        vehicle_designator:vehicle_designator,
        nature:(be_convoy ? "convoy" : "op period"),
        start:start.ToString("M/d HH:mm"),
        end:end.ToString("M/d HH:mm")
        );
      }

    internal void MakeOperationalPeriodDeassignment
      (
      string deployment_id,
      string operational_period_id,
      string member_id,
      string member_designator,
      string vehicle_id
      )
      {
      biz_strike_team_deployment_assignments.Save
        (
        operational_period_id: operational_period_id,
        member_id: member_id,
        vehicle_id: vehicle_id,
        be_assigned: false
        );
      var operational_period_summary = biz_strike_team_deployment_operational_periods.Summary(id: operational_period_id);
      var be_convoy = biz_strike_team_deployment_operational_periods.BeConvoyOf(operational_period_summary);
      var start = biz_strike_team_deployment_operational_periods.StartOf(operational_period_summary);
      var end = biz_strike_team_deployment_operational_periods.EndOf(operational_period_summary);
      biz_strike_team_deployment_logs.Enter
        (
        deployment_id: deployment_id,
        action: "deassigned member `" + member_designator + "` from " + (be_convoy ? "convoy" : "operational period") + " from " + start.ToString("yyyy-MM-dd HH:mm") + " to " + end.ToString("yyyy-MM-dd HH:mm")
        );
      biz_notifications.IssueForOperationalPeriodDeassignment
        (
        target:db_practitioner_strike_team_details.SmsTargetOf(member_id),
        nature:(be_convoy ? "convoy" : "op period"),
        start:start.ToString("M/d HH:mm"),
        end:end.ToString("M/d HH:mm")
        );
      }

    internal void MobilizeMember
      (
      string deployment_id,
      string deployment_name,
      string practitioner_id,
      string name,
      string sms_target
      )
      {
      biz_strike_team_deployment_members.Set
        (
        id: k.EMPTY,
        deployment_id: deployment_id,
        practitioner_id: practitioner_id,
        tag_num: k.EMPTY
        );
      biz_strike_team_deployment_logs.Enter
        (
        deployment_id: deployment_id,
        action: "mobilized member `" + name + "`"
        );
      biz_notifications.IssueForDeploymentMemberMobilization
        (
        target:sms_target,
        deployment_name:deployment_name
        );
      }

    internal void MobilizeVehicle
      (
      string deployment_id,
      string vehicle_id,
      string static_name,
      string tactical_name
      )
      {
      biz_strike_team_deployment_vehicles.Set
        (
        id: k.EMPTY,
        deployment_id: deployment_id,
        vehicle_id: vehicle_id,
        tactical_name: tactical_name,
        transponder_name: k.EMPTY
        );
      biz_strike_team_deployment_logs.Enter
        (
        deployment_id: deployment_id,
        action: "mobilized vehicle `" + static_name + "`"
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
