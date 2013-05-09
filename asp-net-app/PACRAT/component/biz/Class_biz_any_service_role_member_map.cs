// Derived from KiAspdotnetFramework/component/biz/Class~biz~~template~kicrudhelped~item.cs~template

using Class_db_any_service_role_member_map;
using kix;
using System;
using System.Collections;

namespace Class_biz_any_service_role_member_map
  {
  public class TClass_biz_any_service_role_member_map
    {
    private TClass_db_any_service_role_member_map db_any_service_role_member_map = null;

    public TClass_biz_any_service_role_member_map() : base()
      {
      db_any_service_role_member_map = new TClass_db_any_service_role_member_map();
      }

    public bool Bind(string partial_spec, object target)
      {
      return db_any_service_role_member_map.Bind(partial_spec, target);
      }

    public void BindDirectToListControl(object target)
      {
      db_any_service_role_member_map.BindDirectToListControl(target);
      }

    public bool Delete(string id)
      {
      return db_any_service_role_member_map.Delete(id);
      }

    public bool Get
      (
      string id,
      out string service_id,
      out string role_id,
      out string member_id
      )
      {
      return db_any_service_role_member_map.Get
        (
        id,
        out service_id,
        out role_id,
        out member_id
        );
      }

    public void Set
      (
      string id,
      string service_id,
      string role_id,
      string member_id
      )
      {
      db_any_service_role_member_map.Set
        (
        id,
        service_id,
        role_id,
        member_id
        );
      }

    } // end TClass_biz_any_service_role_member_map

  }
