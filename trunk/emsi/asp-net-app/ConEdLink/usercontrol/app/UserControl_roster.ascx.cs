using Class_biz_coned_offering_rosters;
using Class_biz_coned_offerings;
using Class_biz_eval_summary_tallies;
using Class_biz_regions;
using kix;
using System.Collections;
using System.Drawing;
using System.Web.UI.WebControls;

namespace UserControl_roster
  {

  public partial class TWebUserControl_roster: ki_web_ui.usercontrol_class
    {

    private static class UserControl_roster_Static
      {
      public const int TCI_LAST_NAME = 0;
      public const int TCI_FIRST_NAME = 1;
      public const int TCI_MIDDLE_INITIAL = 2;
      public const int TCI_LEVEL = 3;
      public const int TCI_CERT_NUM = 4;
      public const int TCI_DOB = 5;
      public const int TCI_COUNTY = 6;
      public const int TCI_INSTRUCTOR_HOURS = 7;
      public const int TCI_STATUS_DESCRIPTION = 8;
      }

    private struct p_type
      {
      public bool be_loaded;
      public bool be_noncurrent_practitioners_on_roster;
      public bool be_sort_order_ascending;
      public TClass_biz_coned_offering_rosters biz_coned_offering_rosters;
      public TClass_biz_coned_offerings biz_coned_offerings;
      public TClass_biz_eval_summary_tallies biz_eval_summary_tallies;
      public TClass_biz_regions biz_regions;
      public string coned_offering_id;
      public k.decimal_nonnegative length;
      public k.int_nonnegative num_attendees;
      public string sort_order;
      public object summary;
      }

    private p_type p; // Private Parcel of Page-Pertinent Process-Persistent Parameters

    private void Bind()
      {
      p.be_noncurrent_practitioners_on_roster = false;
      p.num_attendees.val = 0;
      p.biz_coned_offering_rosters.BindBaseDataListByClassId(p.sort_order,p.be_sort_order_ascending,DataGrid_control,p.coned_offering_id);
      TableRow_none.Visible = (p.num_attendees.val == 0);
      DataGrid_control.Visible = (p.num_attendees.val > 0);
      Label_noncurrent_practitioner_on_roster.Visible = p.be_noncurrent_practitioners_on_roster;
      }

    protected void Page_Load(object sender, System.EventArgs e)
      {
      if (!p.be_loaded)
        {
        Literal_course_title.Text = p.biz_coned_offerings.CourseTitleOf(p.summary);
        Literal_class_number.Text = p.biz_coned_offerings.StandardSafeRenditionOf(p.biz_coned_offerings.ClassNumberOf(p.summary));
        Literal_location.Text = p.biz_coned_offerings.LocationOf(p.summary);
        Literal_start.Text = p.biz_coned_offerings.StartDateOf(p.summary) + k.SPACE + p.biz_coned_offerings.StartOtherOf(p.summary);
        Literal_end.Text = p.biz_coned_offerings.EndDateOf(p.summary) + k.SPACE + p.biz_coned_offerings.EndOtherOf(p.summary);
        Literal_length.Text = p.length.val.ToString();
        Literal_be_approved.Text = k.YesNoOf(p.biz_coned_offerings.BeApprovedOf(p.summary));
        Literal_fr_med_trauma_hours.Text = p.biz_coned_offerings.FrMedTraumaHoursOf(p.summary);
        Literal_fr_other_hours.Text = p.biz_coned_offerings.FrOtherHoursOf(p.summary);
        Literal_emt_med_trauma_hours.Text = p.biz_coned_offerings.EmtMedTraumaHoursOf(p.summary);
        Literal_emt_other_hours.Text = p.biz_coned_offerings.EmtOtherHoursOf(p.summary);
        Literal_emtp_med_trauma_hours.Text = p.biz_coned_offerings.EmtpMedTraumaHoursOf(p.summary);
        Literal_emtp_other_hours.Text = p.biz_coned_offerings.EmtpOtherHoursOf(p.summary);
        Literal_phrn_med_trauma_hours.Text = p.biz_coned_offerings.PhrnMedTraumaHoursOf(p.summary);
        Literal_phrn_other_hours.Text = p.biz_coned_offerings.PhrnOtherHoursOf(p.summary);
        var eval_summary_mode_description = p.biz_regions.ConedlinkEvalSummaryModeDescriptionOf(Session["region_code"].ToString());
        if (eval_summary_mode_description == "SAEMS")
          {
          LoadRatings();
          }
        Literal_eval_summary_instructional_staff.Text = p.biz_coned_offerings.EvalSummaryInstructionalStaffOf(p.summary);
        Literal_eval_summary_time_appropriately_used.Text = p.biz_coned_offerings.EvalSummaryTimeAppropriatelyUsedOf(p.summary);
        Literal_eval_summary_classroom_training_site.Text = p.biz_coned_offerings.EvalSummaryClassroomTrainingSiteOf(p.summary);
        Literal_eval_summary_equipment_av.Text = p.biz_coned_offerings.EvalSummaryEquipmentAvOf(p.summary);
        Literal_eval_summary_misc_remarks.Text = p.biz_coned_offerings.EvalSummaryMiscRemarksOf(p.summary);
        TableRow_eval_summary_head_spacer.Visible = (eval_summary_mode_description != "Hidden");
        TableRow_eval_summary.Visible = TableRow_eval_summary_head_spacer.Visible;
        TableRow_ratings_header.Visible = (eval_summary_mode_description == "SAEMS");
        TableRow_ratings_body.Visible = TableRow_ratings_header.Visible;
        Bind();
        p.be_loaded = true;
        }
      }

    protected override void OnInit(System.EventArgs e)
      {
      // Required for Designer support
      InitializeComponent();
      base.OnInit(e);
      if (Session[InstanceId() + ".p"] != null)
        {
        p = (p_type)(Session[InstanceId() + ".p"]);
        p.be_loaded = IsPostBack;
        }
      else
        {
        p.be_loaded = false;
        //
        p.biz_coned_offering_rosters = new TClass_biz_coned_offering_rosters();
        p.biz_coned_offerings = new TClass_biz_coned_offerings();
        p.biz_eval_summary_tallies = new TClass_biz_eval_summary_tallies();
        p.biz_regions = new TClass_biz_regions();
        //
        p.be_noncurrent_practitioners_on_roster = false;
        p.be_sort_order_ascending = true;
        p.num_attendees = new k.int_nonnegative();
        p.sort_order = "last_name%,first_name,middle_initial,certification_number,birth_date";
        //
        p.coned_offering_id = k.EMPTY;
        }
      }

    // / <summary>
    // / Required method for Designer support -- do not modify
    // / the contents of this method with the code editor.
    // / </summary>
    private void InitializeComponent()
      {
      PreRender += TWebUserControl_roster_PreRender;
      }

    private void TWebUserControl_roster_PreRender(object sender, System.EventArgs e)
      {
      SessionSet(InstanceId() + ".p", p);
      }

    public TWebUserControl_roster Fresh()
      {
      Session.Remove(InstanceId() + ".p");
      return this;
      }

    protected void DataGrid_control_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
      {
      if (new ArrayList {ListItemType.AlternatingItem,ListItemType.Item,ListItemType.EditItem,ListItemType.SelectedItem}.Contains(e.Item.ItemType))
        {
        var instructor_hours_cell = e.Item.Cells[UserControl_roster_Static.TCI_INSTRUCTOR_HOURS];
        if (instructor_hours_cell.Text == "none")
          {
          LabelizeAndSetTextForeColor(instructor_hours_cell,Color.LightGray);
          }
        if (!(new ArrayList {"Active","Probation","Suspended"}).Contains(e.Item.Cells[UserControl_roster_Static.TCI_STATUS_DESCRIPTION].Text))
          {
          e.Item.BackColor = Color.Gold;
          p.be_noncurrent_practitioners_on_roster = true;
          }
        //
        // This datagrid's viewstate is entirely disabled.
        //
        p.num_attendees.val++;
        }
      }

    protected void DataGrid_control_SortCommand(object source, DataGridSortCommandEventArgs e)
      {
      if (e.SortExpression == p.sort_order)
        {
        p.be_sort_order_ascending = !p.be_sort_order_ascending;
        }
      else
        {
        p.sort_order = k.Safe(e.SortExpression, k.safe_hint_type.KI_SORT_EXPRESSION);
        p.be_sort_order_ascending = true;
        }
      Bind();
      }

    internal void SetTarget
      (
      object coned_offering_summary
      )
      {
      p.summary = coned_offering_summary;
      p.coned_offering_id = p.biz_coned_offerings.IdOf(p.summary);
      p.length = p.biz_coned_offerings.LengthOf(p.summary);
      }

    private void LoadRatings()
      {
      var question_1_rating_1 = k.EMPTY;
      var question_1_rating_2 = k.EMPTY;
      var question_1_rating_3 = k.EMPTY;
      var question_1_rating_4 = k.EMPTY;
      var question_1_rating_5 = k.EMPTY;
      var question_2_rating_1 = k.EMPTY;
      var question_2_rating_2 = k.EMPTY;
      var question_2_rating_3 = k.EMPTY;
      var question_2_rating_4 = k.EMPTY;
      var question_2_rating_5 = k.EMPTY;
      var question_3_rating_1 = k.EMPTY;
      var question_3_rating_2 = k.EMPTY;
      var question_3_rating_3 = k.EMPTY;
      var question_3_rating_4 = k.EMPTY;
      var question_3_rating_5 = k.EMPTY;
      var question_4_rating_1 = k.EMPTY;
      var question_4_rating_2 = k.EMPTY;
      var question_4_rating_3 = k.EMPTY;
      var question_4_rating_4 = k.EMPTY;
      var question_4_rating_5 = k.EMPTY;
      var question_5_rating_1 = k.EMPTY;
      var question_5_rating_2 = k.EMPTY;
      var question_5_rating_3 = k.EMPTY;
      var question_5_rating_4 = k.EMPTY;
      var question_5_rating_5 = k.EMPTY;
      var question_6_rating_1 = k.EMPTY;
      var question_6_rating_2 = k.EMPTY;
      var question_6_rating_3 = k.EMPTY;
      var question_6_rating_4 = k.EMPTY;
      var question_6_rating_5 = k.EMPTY;
      p.biz_eval_summary_tallies.Load
        (
        coned_offering_id:p.coned_offering_id,
        question_1_rating_1:out question_1_rating_1,
        question_1_rating_2:out question_1_rating_2,
        question_1_rating_3:out question_1_rating_3,
        question_1_rating_4:out question_1_rating_4,
        question_1_rating_5:out question_1_rating_5,
        question_2_rating_1:out question_2_rating_1,
        question_2_rating_2:out question_2_rating_2,
        question_2_rating_3:out question_2_rating_3,
        question_2_rating_4:out question_2_rating_4,
        question_2_rating_5:out question_2_rating_5,
        question_3_rating_1:out question_3_rating_1,
        question_3_rating_2:out question_3_rating_2,
        question_3_rating_3:out question_3_rating_3,
        question_3_rating_4:out question_3_rating_4,
        question_3_rating_5:out question_3_rating_5,
        question_4_rating_1:out question_4_rating_1,
        question_4_rating_2:out question_4_rating_2,
        question_4_rating_3:out question_4_rating_3,
        question_4_rating_4:out question_4_rating_4,
        question_4_rating_5:out question_4_rating_5,
        question_5_rating_1:out question_5_rating_1,
        question_5_rating_2:out question_5_rating_2,
        question_5_rating_3:out question_5_rating_3,
        question_5_rating_4:out question_5_rating_4,
        question_5_rating_5:out question_5_rating_5,
        question_6_rating_1:out question_6_rating_1,
        question_6_rating_2:out question_6_rating_2,
        question_6_rating_3:out question_6_rating_3,
        question_6_rating_4:out question_6_rating_4,
        question_6_rating_5:out question_6_rating_5
        );
      Literal_question_1_rating_1.Text = question_1_rating_1;
      Literal_question_1_rating_2.Text = question_1_rating_2;
      Literal_question_1_rating_3.Text = question_1_rating_3;
      Literal_question_1_rating_4.Text = question_1_rating_4;
      Literal_question_1_rating_5.Text = question_1_rating_5;
      Literal_question_2_rating_1.Text = question_2_rating_1;
      Literal_question_2_rating_2.Text = question_2_rating_2;
      Literal_question_2_rating_3.Text = question_2_rating_3;
      Literal_question_2_rating_4.Text = question_2_rating_4;
      Literal_question_2_rating_5.Text = question_2_rating_5;
      Literal_question_3_rating_1.Text = question_3_rating_1;
      Literal_question_3_rating_2.Text = question_3_rating_2;
      Literal_question_3_rating_3.Text = question_3_rating_3;
      Literal_question_3_rating_4.Text = question_3_rating_4;
      Literal_question_3_rating_5.Text = question_3_rating_5;
      Literal_question_4_rating_1.Text = question_4_rating_1;
      Literal_question_4_rating_2.Text = question_4_rating_2;
      Literal_question_4_rating_3.Text = question_4_rating_3;
      Literal_question_4_rating_4.Text = question_4_rating_4;
      Literal_question_4_rating_5.Text = question_4_rating_5;
      Literal_question_5_rating_1.Text = question_5_rating_1;
      Literal_question_5_rating_2.Text = question_5_rating_2;
      Literal_question_5_rating_3.Text = question_5_rating_3;
      Literal_question_5_rating_4.Text = question_5_rating_4;
      Literal_question_5_rating_5.Text = question_5_rating_5;
      Literal_question_6_rating_1.Text = question_6_rating_1;
      Literal_question_6_rating_2.Text = question_6_rating_2;
      Literal_question_6_rating_3.Text = question_6_rating_3;
      Literal_question_6_rating_4.Text = question_6_rating_4;
      Literal_question_6_rating_5.Text = question_6_rating_5;
      }

    }

  }
