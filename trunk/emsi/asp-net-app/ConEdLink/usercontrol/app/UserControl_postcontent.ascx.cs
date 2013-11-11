using Class_biz_accounts;

namespace UserControl_postcontent
  {

  public partial class TWebUserControl_postcontent: ki_web_ui.usercontrol_class
    {

    private struct p_type
      {
      public TClass_biz_accounts biz_accounts;
      }

    private p_type p;

    // / <summary>
    // / Required method for Designer support -- do not modify
    // / the contents of this method with the code editor.
    // / </summary>
    private void InitializeComponent()
      {
      }

    protected override void OnInit(System.EventArgs e)
      {
      // Required for Designer support
      InitializeComponent();
      base.OnInit(e);
      //
      p.biz_accounts = new TClass_biz_accounts();
      }

    protected void Page_Load(object sender, System.EventArgs e)
      {
      if (!IsPostBack)
        {
        if (Session["username"] != null)
          {
          //
          // then the user is fully logged in and the following tests will be meaningful
          //
          var be_ok_to_see_barcoding_manuals = (Session["target_user_table"].ToString() == "regional_staffer") || p.biz_accounts.BeOkForConedSponsorToInputRosterByBatch();
          TableRow_creating_rosters_using_barcode_scanners.Visible = be_ok_to_see_barcoding_manuals;
          TableRow_creating_rosters_using_cipherlab_barcode_readers.Visible = be_ok_to_see_barcoding_manuals;
          //
          TableRow_bounty_program.Visible = true;
          }
        }
      }

    } // end TWebUserControl_postcontent

  }
