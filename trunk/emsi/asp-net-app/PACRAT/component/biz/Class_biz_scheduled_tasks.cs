using Class_biz_practitioner_strike_team_details;
using PACRAT.component.os;

namespace Class_biz_scheduled_tasks
  {
  public class TClass_biz_scheduled_tasks
    {

    private TClass_biz_practitioner_strike_team_details biz_practitioner_strike_team_details;
    private Class_fs fs;

    //Constructor  Create()
    public TClass_biz_scheduled_tasks() : base()
      {
      biz_practitioner_strike_team_details = new TClass_biz_practitioner_strike_team_details();
      fs = new Class_fs();
      }

    public void DoDailyChores(string current_working_directory_spec)
      {
      fs.DeleteCondemnedFolders(current_working_directory_spec + "/../protected/attachment");
      }

    public void DoStrikeTeamMemberStatusStatements()
      {
      biz_practitioner_strike_team_details.MakeMemberStatusStatements();
      }

    } // end TClass_biz_scheduled_tasks

  }