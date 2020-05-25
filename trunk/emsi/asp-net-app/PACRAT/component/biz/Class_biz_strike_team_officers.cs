// Derived from KiAspdotnetFramework/component/biz/Class~biz~~template~kicrudhelped~item.cs~template

using Class_db_regions;
using kix;
using System.Collections;
using System.Configuration;

namespace Class_biz_strike_team_officers
  {
  public class TClass_biz_strike_team_officers
    {

    private readonly TClass_db_regions db_regions = null;

    public TClass_biz_strike_team_officers() : base()
      {
      db_regions = new TClass_db_regions();
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
