using Class_biz_coned_offering_rosters;
using Class_biz_coned_offerings;
using kix;
using System;
using System.Collections;
using System.Web.UI.WebControls;
using UserControl_training_certificate;

namespace UserControl_training_certificate_legacy
  {

  public partial class TWebUserControl_training_certificate_legacy: ki_web_ui.usercontrol_class
    {

    //==
    //
    // INTERNAL
    //
    //==

    internal void Set(Hashtable hash_table)
      {
      p.hash_table = hash_table;
      }

    //==
    //
    // PROTECTED
    //
    //==

    protected override void OnInit(EventArgs e)
      {
      // Required for Designer support
      InitializeComponent();
      base.OnInit(e);
      var instance_id = InstanceId();
      if (Session[instance_id + ".p"] != null)
        {
        p = (p_type)(Session[instance_id + ".p"]);
        p.be_loaded = IsPostBack;  // This test is sufficient if this control is being used statically on its page.
        //
        // If this control is being used dynamically under one or more parent binder(s), it must ascertain which instance it is, and whether or not that instance's parent binder
        // had it loaded already.
        //
//#warning Revise the binder-related instance_id to this control appropriately.
//        if (instance_id == "ASP.protected_overview_aspx.UserControl_member_binder_template_std")
//          {
//#warning Revise the ClientID path to this control appropriately.
//          p.be_loaded &= ((Session["UserControl_member_binder_PlaceHolder_content"] as string) == "UserControl_template_std");
//          }
////      else if (instance_id == "ASP.~_aspx.UserControl_~_binder_template_std")
////        {
////        p.be_loaded &= ((Session["UserControl_~_binder_PlaceHolder_content"] as string) == "UserControl_template_std");
////        }
        }
      else
        {
        p.be_loaded = false;
        //
        p.biz_coned_offerings = new TClass_biz_coned_offerings();
        p.biz_coned_offering_rosters = new TClass_biz_coned_offering_rosters();
        //
        }
      }

    protected void Page_Load(object sender, System.EventArgs e)
      {
      if (!IsPostBack)
        {
        var class_number = k.EMPTY;
        var sponsor_number = k.EMPTY;
        var sponsor_name = k.EMPTY;
        var course_title = k.EMPTY;
        var date_final = k.EMPTY;
        var fr_med_trauma_ceus = new k.decimal_nonnegative();
        var fr_other_ceus = new k.decimal_nonnegative();
        var emt_med_trauma_ceus = new k.decimal_nonnegative();
        var emt_other_ceus = new k.decimal_nonnegative();
        var emtp_med_trauma_ceus = new k.decimal_nonnegative();
        var emtp_other_ceus = new k.decimal_nonnegative();
        var phrn_med_trauma_ceus = new k.decimal_nonnegative();
        var phrn_other_ceus = new k.decimal_nonnegative();
        //
        var roster_ids = (p.hash_table["coned_offering_roster_ids"] as Object[]);
        for (var i = new k.subtype<int>(0,roster_ids.Length); i.val < i.LAST; i.val++)
          {
          var attendance_rec = p.biz_coned_offering_rosters.GetAttendanceRec(roster_ids[i.val].ToString());
          var coned_offering_summary = p.biz_coned_offerings.Summary(attendance_rec.coned_offering_id);
          var be_ceu_breakdown_valid = p.biz_coned_offerings.BeCeuBreakdownValid(coned_offering_summary);
          var UserControl_training_certificate = ((LoadControl("~/usercontrol/app/UserControl_training_certificate.ascx") as TWebUserControl_training_certificate));
          if (be_ceu_breakdown_valid)
            {
            var med_trauma_ceus_for_this_practitioner = new k.decimal_nonnegative();
            var other_ceus_for_this_practitioner = new k.decimal_nonnegative();
            p.biz_coned_offerings.GetForTrainingCertificates
              (
              attendance_rec.coned_offering_id,
              out class_number,
              out sponsor_number,
              out sponsor_name,
              out course_title,
              out date_final,
              ref fr_med_trauma_ceus,
              ref fr_other_ceus,
              ref emt_med_trauma_ceus,
              ref emt_other_ceus,
              ref emtp_med_trauma_ceus,
              ref emtp_other_ceus,
              ref phrn_med_trauma_ceus,
              ref phrn_other_ceus
              );
            p.biz_coned_offering_rosters.GetAppropriateCeuValuesForPractitioner
              (
              fr_med_trauma_ceus.val,
              fr_other_ceus.val,
              emt_med_trauma_ceus.val,
              emt_other_ceus.val,
              emtp_med_trauma_ceus.val,
              emtp_other_ceus.val,
              phrn_med_trauma_ceus.val,
              phrn_other_ceus.val,
              attendance_rec.level_short_description,
              ref med_trauma_ceus_for_this_practitioner,
              ref other_ceus_for_this_practitioner
              );
            UserControl_training_certificate.Set
              (
              sponsor_name,
              sponsor_number,
              attendance_rec.first_name,
              attendance_rec.middle_initial,
              attendance_rec.last_name,
              attendance_rec.certification_number,
              attendance_rec.level_emsrs_code,
              attendance_rec.level_short_description,
              attendance_rec.dob,
              p.biz_coned_offerings.StandardSafeRenditionOf(class_number),
              course_title,
              med_trauma_ceus_for_this_practitioner.val.ToString(),
              other_ceus_for_this_practitioner.val.ToString(),
              date_final,
              attendance_rec.instructor_hours
              );
            }
          if (i.val > i.FIRST)
            {
            var page_break = new Literal();
            page_break.Text = "<div><div style=\"page-break-before:always;\" /></div>";
            PlaceHolder_training_certificate_legacy.Controls.Add(page_break);
            }
          if (be_ceu_breakdown_valid)
            {
            PlaceHolder_training_certificate_legacy.Controls.Add(UserControl_training_certificate);
            }
          else
            {
            var failure_indicator = new Literal();
            failure_indicator.Text = "Sorry, the breakdown of CEUs for class number " + p.biz_coned_offerings.StandardSafeRenditionOf(p.biz_coned_offerings.ClassNumberOf(coned_offering_summary))
            + ", '" + p.biz_coned_offerings.CourseTitleOf(coned_offering_summary) + "', ending " + p.biz_coned_offerings.EndDateOf(coned_offering_summary)
            + " as imported from EMSRS is invalid.  No certificate can be generated.";
            PlaceHolder_training_certificate_legacy.Controls.Add(failure_indicator);
            }
          }
        }
      }

    //==
    //
    // PRIVATE
    //
    //==

    private struct p_type
      {
      public bool be_loaded;
      public TClass_biz_coned_offerings biz_coned_offerings;
      public TClass_biz_coned_offering_rosters biz_coned_offering_rosters;
      public Hashtable hash_table;
      }

    private p_type p; // Private Parcel of Page-Pertinent Process-Persistent Parameters

    private void InitializeComponent()
      {
      PreRender += TWebForm_training_certificate_legacy_PreRender;
      }

    private void TWebForm_training_certificate_legacy_PreRender(object sender, System.EventArgs e)
      {
      SessionSet(InstanceId() + ".p", p);
      }

    } // end TWebForm_training_certificate_legacy

  }
