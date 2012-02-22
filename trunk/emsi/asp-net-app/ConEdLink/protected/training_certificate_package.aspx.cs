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
        p.biz_coned_offering_rosters = new TClass_biz_coned_offering_rosters();
        //
        var meta_hashtable = HashtableOfShieldedRequest();
        //
        var nvc = Request.Form;
        //
        Hashtable attendance_rec_hashtable;
        for (var i = new k.subtype<int>(1,nvc.Count); i.val < i.LAST; i.val++)
          {
          var attendance_rec = new TClass_biz_coned_offering_rosters.attendance_rec_class();
          var med_trauma_ceus_for_this_practitioner = new k.decimal_nonnegative();
          var total_ceus_for_this_practitioner = new k.decimal_nonnegative();
          var UserControl_training_certificate = ((LoadControl("~/usercontrol/app/UserControl_training_certificate.ascx") as TWebUserControl_training_certificate));
          attendance_rec.id = nvc.GetKey(i.val);
          attendance_rec_hashtable = HashtableOfShieldedRequest(attendance_rec.id);
          attendance_rec.certification_number = attendance_rec_hashtable["certification_number"].ToString();
          attendance_rec.dob = attendance_rec_hashtable["dob"].ToString();
          attendance_rec.email_address = attendance_rec_hashtable["email_address"].ToString();
          attendance_rec.first_name = attendance_rec_hashtable["first_name"].ToString();
          attendance_rec.last_name = attendance_rec_hashtable["last_name"].ToString();
          attendance_rec.level_emsrs_code = attendance_rec_hashtable["level_emsrs_code"].ToString();
          attendance_rec.level_short_description = attendance_rec_hashtable["level_short_description"].ToString();
          attendance_rec.middle_initial = attendance_rec_hashtable["middle_initial"].ToString();
          p.biz_coned_offering_rosters.GetAppropriateCeuValuesForPractitioner
            (
            new k.decimal_nonnegative(decimal.Parse(meta_hashtable["fr_total_ceus"].ToString())),
            new k.decimal_nonnegative(decimal.Parse(meta_hashtable["fr_med_trauma_ceus"].ToString())),
            new k.decimal_nonnegative(decimal.Parse(meta_hashtable["emt_total_ceus"].ToString())),
            new k.decimal_nonnegative(decimal.Parse(meta_hashtable["emt_med_trauma_ceus"].ToString())),
            new k.decimal_nonnegative(decimal.Parse(meta_hashtable["emtp_total_ceus"].ToString())),
            new k.decimal_nonnegative(decimal.Parse(meta_hashtable["emtp_med_trauma_ceus"].ToString())),
            new k.decimal_nonnegative(decimal.Parse(meta_hashtable["phrn_total_ceus"].ToString())),
            new k.decimal_nonnegative(decimal.Parse(meta_hashtable["phrn_med_trauma_ceus"].ToString())),
            attendance_rec,
            ref total_ceus_for_this_practitioner,
            ref med_trauma_ceus_for_this_practitioner
            );
          UserControl_training_certificate.Set
            (
            attendance_rec.id,
            meta_hashtable["sponsor_name"].ToString(),
            meta_hashtable["sponsor_number"].ToString(),
            attendance_rec.first_name,
            attendance_rec.middle_initial,
            attendance_rec.last_name,
            attendance_rec.certification_number,
            attendance_rec.level_emsrs_code,
            attendance_rec.level_short_description,
            attendance_rec.dob,
            meta_hashtable["course_number"].ToString(),
            meta_hashtable["course_title"].ToString(),
            total_ceus_for_this_practitioner.val.ToString(),
            med_trauma_ceus_for_this_practitioner.val.ToString(),
            meta_hashtable["date_final"].ToString()
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
