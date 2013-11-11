// Derived from KiAspdotnetFramework/component/biz/Class~biz~~template~kicrudhelped~item.cs~template

using Class_biz_user;
using Class_db_practitioners;
using Class_db_services;
using Class_db_strike_team_rosters;
using kix;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Class_biz_strike_team_rosters
  {
  public class TClass_biz_strike_team_rosters
    {

    private TClass_biz_user biz_user = null;
    private TClass_db_services db_services = null;
    private TClass_db_strike_team_rosters db_strike_team_rosters = null;
    private TClass_db_practitioners db_practitioners = null;

    public TClass_biz_strike_team_rosters() : base()
      {
      biz_user = new TClass_biz_user();
      db_services = new TClass_db_services();
      db_strike_team_rosters = new TClass_db_strike_team_rosters();
      db_practitioners = new TClass_db_practitioners();
      }

    public bool Bind(string partial_spec, object target)
      {
      return db_strike_team_rosters.Bind(partial_spec, target);
      }

    public void BindBaseDataListByServiceId
      (
      string sort_order,
      bool be_sort_order_ascending,
      object target,
      string id
      )
      {
      db_strike_team_rosters.BindBaseDataListByServiceId(sort_order,be_sort_order_ascending,target,id);
      }

      public void BindDirectToListControl(object target)
      {
      db_strike_team_rosters.BindDirectToListControl(target);
      }

    public bool Delete(string id)
      {
      return db_strike_team_rosters.Delete(id);
      }

    public bool Get
      (
      string id,
      out string service_id,
      out string practitioner_id
      )
      {
      return db_strike_team_rosters.Get
        (
        id,
        out service_id,
        out practitioner_id
        );
      }

    internal void SendServiceStatements(string working_directory)
      {
      var arguments = new ArrayList();
      var stdout = k.EMPTY;
      var stderr = k.EMPTY;
      var participating_service_id = k.EMPTY;
      var participating_service_id_q = db_services.StrikeTeamParticipantIdQ();
      var participating_service_id_q_count = participating_service_id_q.Count;
      for (var i = new k.subtype<int>(0,participating_service_id_q_count); i.val < participating_service_id_q_count; i.val++)
        {
        participating_service_id = participating_service_id_q.Dequeue() as string;
        arguments.Add
          (
          "--output-document=/dev/null --no-check-certificate"
          + " --post-data"
          +   "=service_id=" + participating_service_id
          + k.SPACE
          + "\"" + ConfigurationManager.AppSettings["runtime_root_fullspec"] + "noninteractive/report_service_strike_team_roster.aspx\""
          );
        }
      k.RunCommandIteratedOverArguments("c:\\cygwin\\bin\\wget",arguments,working_directory,out stdout,out stderr);
      }

    public void Set
      (
      string id,
      string service_id,
      string practitioner_id
      )
      {
      db_strike_team_rosters.Set
        (
        id,
        service_id,
        practitioner_id
        );
      }

    internal string SizeOf(string service_id)
      {
      return db_strike_team_rosters.SizeOf(service_id);
      }

    } // end TClass_biz_strike_team_rosters

  }
