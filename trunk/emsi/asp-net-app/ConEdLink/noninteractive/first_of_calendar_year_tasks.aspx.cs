using Class_biz_scheduled_tasks;
using System;
using System.Web;

namespace first_of_calendar_year_tasks
  {

  public partial class TWebForm_first_of_calendar_year_tasks: ki_web_ui.page_class
    {

    // / <summary>
    // / Required method for Designer support -- do not modify
    // / the contents of this method with the code editor.
    // / </summary>
    private void InitializeComponent()
      {
      }

    protected void Page_Load(object sender, EventArgs e)
      {
      new TClass_biz_scheduled_tasks().DoFirstOfCalendarYearChores(HttpContext.Current.Server.MapPath("."));
      }

    protected override void OnInit(EventArgs e)
      {
      // Required for Designer support
      InitializeComponent();
      base.OnInit(e);
      }

    } // end TWebForm_first_of_calendar_year_tasks

  }
