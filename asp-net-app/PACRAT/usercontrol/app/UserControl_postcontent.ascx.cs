using System;

namespace UserControl_postcontent
  {

  public partial class TWebUserControl_postcontent: ki_web_ui.usercontrol_class
    {

    protected void Page_Load(object sender, System.EventArgs e)
      {
      if (!IsPostBack)
        {
        Table_realtime_tech_support.Visible = DateTime.Now < new DateTime(2015,10,1);
        TableRow_bounty_program.Visible = (Session["user_id"] != null);
        }
      }

    protected override void OnInit(System.EventArgs e)
      {
      InitializeComponent();
      base.OnInit(e);
      }

    // / <summary>
    // / Required method for Designer support -- do not modify
    // / the contents of this method with the code editor.
    // / </summary>
    private void InitializeComponent()
      {
      }

    } // end TWebUserControl_postcontent

  }
