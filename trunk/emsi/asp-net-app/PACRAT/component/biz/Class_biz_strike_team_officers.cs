// Derived from KiAspdotnetFramework/component/biz/Class~biz~~template~kicrudhelped~item.cs~template

using Class_biz_user;
using Class_db_practitioners;
using Class_db_regions;
using Class_db_services;
using kix;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Class_biz_strike_team_officers
  {
  public class TClass_biz_strike_team_officers
    {

    private TClass_biz_user biz_user = null;
    private TClass_db_regions db_regions = null;
    private TClass_db_services db_services = null;
    private TClass_db_practitioners db_practitioners = null;

    public TClass_biz_strike_team_officers() : base()
      {
      biz_user = new TClass_biz_user();
      db_regions = new TClass_db_regions();
      db_services = new TClass_db_services();
      db_practitioners = new TClass_db_practitioners();
      }

    internal void SendRegionStatements(string working_directory)
      {
      var arguments = new ArrayList();
      var stdout = k.EMPTY;
      var stderr = k.EMPTY;
      var participating_region_emsrs_code = k.EMPTY;
      var participating_region_emsrs_code_q = db_regions.PacratSubscriberEmsrsCodeQ();
      var participating_region_emsrs_code_q_count = participating_region_emsrs_code_q.Count;
      for (var i = new k.subtype<int>(0,participating_region_emsrs_code_q_count); i.val < participating_region_emsrs_code_q_count; i.val++)
        {
        participating_region_emsrs_code = participating_region_emsrs_code_q.Dequeue() as string;
        arguments.Add
          (
          "--output-document=/dev/null --no-check-certificate"
          + " --post-data"
          +   "=region_emsrs_code=" + participating_region_emsrs_code
          + k.SPACE
          + "\"" + ConfigurationManager.AppSettings["runtime_root_fullspec"] + "noninteractive/report_service_strike_team_officers_in_region.aspx\""
          );
        }
      k.RunCommandIteratedOverArguments("c:\\cygwin\\bin\\wget",arguments,working_directory,out stdout,out stderr);
      }

    } // end TClass_biz_strike_team_officers

  }
