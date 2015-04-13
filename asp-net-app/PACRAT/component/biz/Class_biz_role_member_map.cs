using Class_biz_notifications;
using Class_biz_user;
using Class_db_role_member_map;
using System.Collections;

namespace Class_biz_role_member_map
  {

  public class TClass_biz_role_member_map
    {

        private TClass_db_role_member_map db_role_member_map = null;
        private TClass_biz_notifications biz_notifications = null;
        private TClass_biz_user biz_user = null;

        public TClass_biz_role_member_map() : base()
        {
            db_role_member_map = new TClass_db_role_member_map();
            biz_notifications = new TClass_biz_notifications();
            biz_user = new TClass_biz_user();
        }

        public bool BePrivilegedToModifyTuple(bool has_config_roles_and_matrices, bool has_assign_roles_to_members, string role_natural_text)
        {
            bool result;
            result = has_config_roles_and_matrices || ((role_natural_text != "Application Administrator") && has_assign_roles_to_members);
            return result;
        }

        public void Bind(string sort_order, bool be_sort_order_descending, object target, out ArrayList crosstab_metadata)
        {
            db_role_member_map.Bind(sort_order, be_sort_order_descending, target, out crosstab_metadata);
        }

        public void BindActuals(string sort_order, bool be_sort_order_ascending, object target)
        {
            db_role_member_map.BindActuals(sort_order, be_sort_order_ascending, target);
        }

        internal void BindBaseDataListByExplicitRegionCode
          (
          string sort_order,
          bool be_sort_order_ascending,
          object target,
          string region_code
          )
          {
          db_role_member_map.BindBaseDataListByExplicitRegionCode(sort_order,be_sort_order_ascending,target,region_code);
          }

        internal void BindBaseDataListByExplicitServiceId
          (
          string sort_order,
          bool be_sort_order_ascending,
          object target,
          string service_id
          )
          {
          db_role_member_map.BindBaseDataListByExplicitServiceId(sort_order,be_sort_order_ascending,target,service_id);
          }

        internal void BindBaseDataListForPennsylvania
          (
          string sort_order,
          bool be_sort_order_ascending,
          object target
          )
          {
          db_role_member_map.BindBaseDataListForPennsylvania(sort_order,be_sort_order_ascending,target);
          }

        public void BindHolders(string role_name, object target, string sort_order, bool be_sort_order_ascending)
        {
            db_role_member_map.BindHolders(role_name, target, sort_order, be_sort_order_ascending);
        }

        internal string EmailTargetOfByExplicitRegionCode
          (
          string role_name,
          string region_code
          )
          {
          return db_role_member_map.EmailTargetOfByExplicitRegionCode(role_name,region_code);
          }

        internal string EmailTargetOfByExplicitServiceId
          (
          string role_name,
          string service_id
          )
          {
          return db_role_member_map.EmailTargetOfByExplicitServiceId(role_name,service_id);
          }

        public void Save(string member_id, string role_id, bool be_granted)
        {
            db_role_member_map.Save(member_id, role_id, be_granted);
            biz_notifications.IssueForRoleChange(member_id, role_id, be_granted);
        }

        internal void SaveForExplicitRegion
          (
          string member_id,
          string role_id,
          bool be_granted,
          string region_code
          )
          {
          db_role_member_map.SaveForExplicitRegion(member_id,role_id,be_granted,region_code);
          biz_notifications.IssueForExplicitRegionRoleChange(member_id,role_id,be_granted,region_code);
          }

        internal void SaveForExplicitService
          (
          string member_id,
          string role_id,
          bool be_granted,
          string service_id
          )
          {
          db_role_member_map.SaveForExplicitService(member_id,role_id,be_granted,service_id);
          biz_notifications.IssueForExplicitServiceRoleChange(member_id,role_id,be_granted,service_id);
          }

    internal string SmsTargetOfByExplicitServiceId
      (
      string role_name,
      string service_id
      )
      {
      return db_role_member_map.SmsTargetOfByExplicitServiceId(role_name,service_id);
      }

    } // end TClass_biz_role_member_map

  }
