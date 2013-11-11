using Class_biz_scheduled_tasks;
using System;

namespace statement_service_strike_team_roster
  {

  public partial class TWebForm_statement_service_strike_team_roster: System.Web.UI.Page
    {

    // / <summary>
    // / Required method for Designer support -- do not modify
    // / the contents of this method with the code editor.
    // / </summary>
    private void InitializeComponent()
      {
      }

    protected void Page_Load(object sender, System.EventArgs e)
      {
      new TClass_biz_scheduled_tasks().DoServiceStrikeTeamRosterStatements(current_working_directory_spec:Server.MapPath("scratch"));
      }

    protected override void OnInit(EventArgs e)
      {
      // Required for Designer support
      InitializeComponent();
      base.OnInit(e);
      }

    } // end TWebForm_statement_service_strike_team_roster

  }
