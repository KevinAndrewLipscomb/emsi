// Derived from KiAspdotnetFramework/component/biz/Class~biz~~template~kicrudhelped~item.cs~template

using Class_db_any_region_role_member_map;
using kix;
using System;
using System.Collections;

namespace Class_biz_any_region_role_member_map
  {
  public class TClass_biz_any_region_role_member_map
    {
    private TClass_db_any_region_role_member_map db_any_region_role_member_map = null;

    public TClass_biz_any_region_role_member_map() : base()
      {
      db_any_region_role_member_map = new TClass_db_any_region_role_member_map();
      }

    public bool Bind(string partial_spec, object target)
      {
      return db_any_region_role_member_map.Bind(partial_spec, target);
      }

    public void BindBaseDataListByRegionCode
      (
      string sort_order,
      bool be_sort_order_ascending,
      object target,
      string code
      )
      {
      db_any_region_role_member_map.BindBaseDataListByRegionCode(sort_order,be_sort_order_ascending,target,code);
      }

    public void BindDirectToListControl(object target)
      {
      db_any_region_role_member_map.BindDirectToListControl(target);
      }

    public bool Delete(string id)
      {
      return db_any_region_role_member_map.Delete(id);
      }

    public bool Get
      (
      string id,
      out string region_code,
      out string role_id,
      out string member_id
      )
      {
      return db_any_region_role_member_map.Get
        (
        id,
        out region_code,
        out role_id,
        out member_id
        );
      }

    internal void Save
      (
      string region_code,
      string role_name,
      string member_id,
      bool be_granted
      )
      {
      db_any_region_role_member_map.Save(region_code,role_name,member_id,be_granted);
      }

    public void Set
      (
      string id,
      string region_code,
      string role_id,
      string member_id
      )
      {
      db_any_region_role_member_map.Set
        (
        id,
        region_code,
        role_id,
        member_id
        );
      }

    } // end TClass_biz_any_region_role_member_map

  }
