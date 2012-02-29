using Class_biz_coned_offerings;
using Class_biz_coned_offering_rosters;
using kix;
using System;
using System.Collections;
using System.Configuration;
using System.Web.UI.WebControls;
using UserControl_training_certificate;

namespace training_certificate_package
  {
  // Derived from KiAspdotnetFramework/protected/template~protected~nonlanding.pas~template
  public partial class TWebForm_training_certificate_package: ki_web_ui.page_class
    {

    protected override void OnInit(EventArgs e)
      {
      // Required for Designer support
      InitializeComponent();
      base.OnInit(e);
      var nature_of_visit_unlimited = NatureOfVisitUnlimited(InstanceId() + ".p");
      if(
          (nature_of_visit_unlimited == nature_of_visit_type.VISIT_COLD_CALL)
        ||
          (nature_of_visit_unlimited == nature_of_visit_type.VISIT_INITIAL)
        )
        {
        p.biz_coned_offerings = new TClass_biz_coned_offerings();
        p.biz_coned_offering_rosters = new TClass_biz_coned_offering_rosters();
        //
        var hash_table = HashtableOfShieldedRequest();
        //
        var class_number = k.EMPTY;
        var sponsor_number = k.EMPTY;
        var sponsor_name = k.EMPTY;
        var course_title = k.EMPTY;
        var date_final = k.EMPTY;
        var fr_total_ceus = new k.decimal_nonnegative();
        var fr_med_trauma_ceus = new k.decimal_nonnegative();
        var emt_total_ceus = new k.decimal_nonnegative();
        var emt_med_trauma_ceus = new k.decimal_nonnegative();
        var emtp_total_ceus = new k.decimal_nonnegative();
        var emtp_med_trauma_ceus = new k.decimal_nonnegative();
        var phrn_total_ceus = new k.decimal_nonnegative();
        var phrn_med_trauma_ceus = new k.decimal_nonnegative();
        p.biz_coned_offerings.GetForTrainingCertificates
          (
          hash_table["coned_offering_id"].ToString(),
          out class_number,
          out sponsor_number,
          out sponsor_name,
          out course_title,
          out date_final,
          ref fr_total_ceus,
          ref fr_med_trauma_ceus,
          ref emt_total_ceus,
          ref emt_med_trauma_ceus,
          ref emtp_total_ceus,
          ref emtp_med_trauma_ceus,
          ref phrn_total_ceus,
          ref phrn_med_trauma_ceus
          );
        //
        var roster_ids = (hash_table["coned_offering_roster_ids"] as Object[]);
        for (var i = new k.subtype<int>(0,roster_ids.Length); i.val < i.LAST; i.val++)
          {
          var attendance_rec = new TClass_biz_coned_offering_rosters.attendance_rec_class();
          var med_trauma_ceus_for_this_practitioner = new k.decimal_nonnegative();
          var total_ceus_for_this_practitioner = new k.decimal_nonnegative();
          var UserControl_training_certificate = ((LoadControl("~/usercontrol/app/UserControl_training_certificate.ascx") as TWebUserControl_training_certificate));
          attendance_rec = p.biz_coned_offering_rosters.GetAttendanceRec(roster_ids[i.val].ToString());
          p.biz_coned_offering_rosters.GetAppropriateCeuValuesForPractitioner
            (
            fr_total_ceus.val,
            fr_med_trauma_ceus.val,
            emt_total_ceus.val,
            emt_med_trauma_ceus.val,
            emtp_total_ceus.val,
            emtp_med_trauma_ceus.val,
            phrn_total_ceus.val,
            phrn_med_trauma_ceus.val,
            attendance_rec.level_short_description,
            ref total_ceus_for_this_practitioner,
            ref med_trauma_ceus_for_this_practitioner
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
            total_ceus_for_this_practitioner.val.ToString(),
            med_trauma_ceus_for_this_practitioner.val.ToString(),
            date_final,
            attendance_rec.instructor_hours
            );
          if (i.val > i.FIRST)
            {
            var page_break = new Literal();
            page_break.Text = "<div><div style=\"page-break-before:always;\" /></div>";
            PlaceHolder_training_certificate_package.Controls.Add(page_break);
            }
          PlaceHolder_training_certificate_package.Controls.Add(UserControl_training_certificate);
          }
        }
      else if (nature_of_visit_unlimited == nature_of_visit_type.VISIT_POSTBACK_STANDARD)
        {
        p = (p_type)(Session[InstanceId() + ".p"]);
        }
      }

    protected void Page_Load(object sender, System.EventArgs e)
      {
      if (!IsPostBack)
        {
        Title = ConfigurationManager.AppSettings["application_name"] + " - training_certificate_package";
        }
      }

    //==
    //
    // PRIVATE
    //
    //==

    private struct p_type
      {
      public TClass_biz_coned_offerings biz_coned_offerings;
      public TClass_biz_coned_offering_rosters biz_coned_offering_rosters;
      }

    private p_type p;

    private void InitializeComponent()
      {
      PreRender += TWebForm_training_certificate_package_PreRender;
      }

    private void TWebForm_training_certificate_package_PreRender(object sender, System.EventArgs e)
      {
      SessionSet(InstanceId() + ".p", p);
      }

    } // end TWebForm_training_certificate_package

  }
