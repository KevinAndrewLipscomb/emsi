using Class_biz_scheduled_tasks;
using System;

namespace statement_strike_team_member_status
  {

  public partial class TWebForm_statement_strike_team_member_status: System.Web.UI.Page
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
      new TClass_biz_scheduled_tasks().DoStrikeTeamMemberStatusStatements();
      }

    protected override void OnInit(EventArgs e)
      {
      // Required for Designer support
      InitializeComponent();
      base.OnInit(e);
      }

    } // end TWebForm_statement_strike_team_member_status

  }
