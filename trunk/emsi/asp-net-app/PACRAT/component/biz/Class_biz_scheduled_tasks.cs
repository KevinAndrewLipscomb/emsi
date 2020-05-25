using System;
using Class_biz_practitioner_strike_team_details;
using Class_biz_strike_team_officers;
using Class_biz_strike_team_rosters;
using PACRAT.component.os;

namespace Class_biz_scheduled_tasks
  {
  public class TClass_biz_scheduled_tasks
    {

    private readonly TClass_biz_practitioner_strike_team_details biz_practitioner_strike_team_details;
    private readonly TClass_biz_strike_team_officers biz_strike_team_officers;
    private readonly TClass_biz_strike_team_rosters biz_strike_team_rosters;
    private readonly Class_fs fs;

    //Constructor  Create()
    public TClass_biz_scheduled_tasks() : base()
      {
      biz_practitioner_strike_team_details = new TClass_biz_practitioner_strike_team_details();
      biz_strike_team_officers = new TClass_biz_strike_team_officers();
      biz_strike_team_rosters = new TClass_biz_strike_team_rosters();
      fs = new Class_fs();
      }

    public void DoDailyChores(string current_working_directory_spec)
      {
      fs.DeleteCondemnedFolders(current_working_directory_spec + "/../protected/attachment");
      biz_practitioner_strike_team_details.MakeUpcomingDecredentialingNotifications();
      }

    public void DoServiceStrikeTeamOfficersInRegionStatements(string current_working_directory_spec)
      {
      biz_strike_team_officers.SendRegionStatements(working_directory:current_working_directory_spec);
      }

    public void DoServiceStrikeTeamRosterStatements(string current_working_directory_spec)
      {
      biz_strike_team_rosters.SendServiceStatements(working_directory:current_working_directory_spec);
      }

    public void DoStrikeTeamMemberStatusStatements(bool do_limit_to_uncredentialed)
      {
      biz_practitioner_strike_team_details.MakeMemberStatusStatements(do_limit_to_uncredentialed);
      }

    internal void VerifyPractitionerAttributes()
      {
      throw new NotImplementedException();
      }

    } // end TClass_biz_scheduled_tasks

  }