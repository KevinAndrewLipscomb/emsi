// Derived from KiAspdotnetFramework/component/biz/Class~biz~~template~kicrudhelped~item.cs~template

using Class_db_strike_team_deployment_members;
using kix;
using System;
using System.Collections;

namespace Class_biz_strike_team_deployment_members
  {
  public class TClass_biz_strike_team_deployment_members
    {
    private TClass_db_strike_team_deployment_members db_strike_team_deployment_members = null;

    public TClass_biz_strike_team_deployment_members() : base()
      {
      db_strike_team_deployment_members = new TClass_db_strike_team_deployment_members();
      }

    public bool Bind(string partial_spec, object target)
      {
      return db_strike_team_deployment_members.Bind(partial_spec, target);
      }

    public void BindBaseDataList
      (
      string sort_order,
      bool be_sort_order_ascending,
      object target,
      string deployment_id,
      bool do_include_all_eligible_practitioners
      )
      {
      db_strike_team_deployment_members.BindBaseDataList(sort_order,be_sort_order_ascending,target,deployment_id,do_include_all_eligible_practitioners);
      }

    public void BindDirectToListControl(object target)
      {
      db_strike_team_deployment_members.BindDirectToListControl(target);
      }

    internal void BindUnassignedInOperationalPeriodDirectToListControl
      (
      object target,
      string deployment_id,
      string operational_period_id
      )
      {
      db_strike_team_deployment_members.BindUnassignedInOperationalPeriodDirectToListControl(target,deployment_id,operational_period_id);
      }

    public bool Delete(string id)
      {
      return db_strike_team_deployment_members.Delete(id);
      }

    public bool Get
      (
      string id,
      out string deployment_id,
      out string practitioner_id
      )
      {
      return db_strike_team_deployment_members.Get
        (
        id,
        out deployment_id,
        out practitioner_id
        );
      }

    public void Set
      (
      string id,
      string deployment_id,
      string practitioner_id
      )
      {
      db_strike_team_deployment_members.Set
        (
        id,
        deployment_id,
        practitioner_id
        );
      }

    internal object Summary(string id)
      {
      return db_strike_team_deployment_members.Summary(id);
      }

    } // end TClass_biz_strike_team_deployment_members

  }
