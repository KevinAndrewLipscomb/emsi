// Derived from KiAspdotnetFramework/component/biz/Class~biz~~template~kicrudhelped~item.cs~template

using Class_biz_user;
using Class_db_coned_offering_rosters;
using Class_db_practitioners;
using Class_db_teaching_entities;
using kix;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Web;

namespace Class_biz_coned_offering_rosters
  {
  public class TClass_biz_coned_offering_rosters
    {

    private TClass_biz_user biz_user = null;
    private TClass_db_coned_offering_rosters db_coned_offering_rosters = null;
    private TClass_db_practitioners db_practitioners = null;
    private TClass_db_teaching_entities db_teaching_entities = null;

    public TClass_biz_coned_offering_rosters() : base()
      {
      biz_user = new TClass_biz_user();
      db_coned_offering_rosters = new TClass_db_coned_offering_rosters();
      db_practitioners = new TClass_db_practitioners();
      db_teaching_entities = new TClass_db_teaching_entities();
      }

    internal class attendance_rec_class
      {
      internal string email_address = k.EMPTY;
      internal string first_name = k.EMPTY;
      internal string middle_initial = k.EMPTY;
      internal string last_name = k.EMPTY;
      internal string certification_number = k.EMPTY;
      internal string level_emsrs_code = k.EMPTY;
      internal string level_short_description = k.EMPTY;
      internal string dob = k.EMPTY;
      internal string instructor_hours = k.EMPTY;
      internal string coned_offering_id = k.EMPTY;
      }

    public bool Bind(string partial_spec, object target)
      {
      return db_coned_offering_rosters.Bind(partial_spec, target);
      }

    public void BindBaseDataListByClassId
      (
      string sort_order,
      bool be_sort_order_ascending,
      object target,
      string id
      )
      {
      db_coned_offering_rosters.BindBaseDataListByConedOfferingId(sort_order,be_sort_order_ascending,target,id);
      }

    internal void BindBaseDataListForAnalysisOfRegionByCounty(string sort_order, bool be_sort_order_ascending, System.Web.UI.WebControls.DataGrid target, string region_code, string year)
      {
      db_coned_offering_rosters.BindBaseDataListForAnalysisOfRegionByCounty(sort_order,be_sort_order_ascending,target,region_code,year);
      }

    internal void BindBaseDataListForAnalysisOfRegionByCourse
      (
      string sort_order,
      bool be_sort_order_ascending,
      object target,
      string region_code,
      string year
      )
      {
      db_coned_offering_rosters.BindBaseDataListForAnalysisOfRegionByCourse(sort_order,be_sort_order_ascending,target,region_code,year);
      }

    internal void BindBaseDataListForAnalysisOfRegionByMonth
      (
      string sort_order,
      bool be_sort_order_ascending,
      object target,
      string region_code,
      string year
      )
      {
      db_coned_offering_rosters.BindBaseDataListForAnalysisOfRegionByMonth(sort_order,be_sort_order_ascending,target,region_code,year);
      }

    internal void BindBaseDataListForAnalysisOfRegionBySponsor
      (
      string sort_order,
      bool be_sort_order_ascending,
      object target,
      string region_code,
      string year
      )
      {
      db_coned_offering_rosters.BindBaseDataListForAnalysisOfRegionBySponsor(sort_order,be_sort_order_ascending,target,region_code,year);
      }

    internal void BindBaseDataListForAnalysisOfRegionByYear
      (
      string sort_order,
      bool be_sort_order_ascending,
      object target,
      string region_code
      )
      {
      db_coned_offering_rosters.BindBaseDataListForAnalysisOfRegionByYear(sort_order,be_sort_order_ascending,target,region_code);
      }

    internal void BindBaseDataListForAnalysisOfSponsorByCounty
      (
      string sort_order,
      bool be_sort_order_ascending,
      object target,
      string coned_sponsor_user_id,
      string year
      )
      {
      db_coned_offering_rosters.BindBaseDataListForAnalysisOfSponsorByCounty(sort_order,be_sort_order_ascending,target,coned_sponsor_user_id,year);
      }

    internal void BindBaseDataListForAnalysisOfSponsorByCourse
      (
      string sort_order,
      bool be_sort_order_ascending,
      object target,
      string coned_sponsor_user_id,
      string year
      )
      {
      db_coned_offering_rosters.BindBaseDataListForAnalysisOfSponsorByCourse(sort_order,be_sort_order_ascending,target,coned_sponsor_user_id,year);
      }

    internal void BindBaseDataListForAnalysisOfSponsorByMonth
      (
      string sort_order,
      bool be_sort_order_ascending,
      object target,
      string coned_sponsor_user_id,
      string year
      )
      {
      db_coned_offering_rosters.BindBaseDataListForAnalysisOfSponsorByMonth(sort_order,be_sort_order_ascending,target,coned_sponsor_user_id,year);
      }

    internal void BindBaseDataListForAnalysisOfSponsorByYear
      (
      string sort_order,
      bool be_sort_order_ascending,
      object target,
      string coned_sponsor_user_id
      )
      {
      db_coned_offering_rosters.BindBaseDataListForAnalysisOfSponsorByYear(sort_order,be_sort_order_ascending,target,coned_sponsor_user_id);
      }

      public void BindDirectToListControl(object target)
      {
      db_coned_offering_rosters.BindDirectToListControl(target);
      }

    public void Copy
      (
      string source_id,
      string target_id
      )
      {
      db_coned_offering_rosters.Copy(source_id,target_id);
      }

    public bool Delete(string id)
      {
      return db_coned_offering_rosters.Delete(id);
      }

    public bool Get
      (
      string id,
      out string coned_offering_id,
      out string practitioner_id,
      out string instructor_hours
      )
      {
      return db_coned_offering_rosters.Get
        (
        id,
        out coned_offering_id,
        out practitioner_id,
        out instructor_hours
        );
      }

    internal void GetAppropriateCeuValuesForPractitioner
      (
      decimal fr_med_trauma_ceus,
      decimal fr_other_ceus,
      decimal emt_med_trauma_ceus,
      decimal emt_other_ceus,
      decimal emtp_med_trauma_ceus,
      decimal emtp_other_ceus,
      decimal phrn_med_trauma_ceus,
      decimal phrn_other_ceus,
      string level_short_description,
      ref k.decimal_nonnegative med_trauma_ceus_for_this_practitioner,
      ref k.decimal_nonnegative other_ceus_for_this_practitioner
      )
      {
      if (level_short_description == "EMR")
        {
        med_trauma_ceus_for_this_practitioner.val = fr_med_trauma_ceus;
        other_ceus_for_this_practitioner.val = fr_other_ceus;
        }
      else if (level_short_description == "EMT")
        {
        med_trauma_ceus_for_this_practitioner.val = emt_med_trauma_ceus;
        other_ceus_for_this_practitioner.val = emt_other_ceus;
        }
      else if (new ArrayList() {"AEMT","EMT-P","HP"}.Contains(level_short_description))
        {
        med_trauma_ceus_for_this_practitioner.val = emtp_med_trauma_ceus;
        other_ceus_for_this_practitioner.val = emtp_other_ceus;
        }
      else if (level_short_description == "PHRN")
        {
        med_trauma_ceus_for_this_practitioner.val = phrn_med_trauma_ceus;
        other_ceus_for_this_practitioner.val = phrn_other_ceus;
        }
      }

    internal attendance_rec_class GetAttendanceRec(string id)
      {
      var attendance_rec = new attendance_rec_class();
      var coned_offering_id = k.EMPTY;
      var practitioner_id = k.EMPTY;
      db_coned_offering_rosters.Get(id,out coned_offering_id,out practitioner_id,out attendance_rec.instructor_hours);
      db_practitioners.GetForAttendanceRec
        (
        practitioner_id,
        out attendance_rec.certification_number,
        out attendance_rec.dob,
        out attendance_rec.email_address,
        out attendance_rec.first_name,
        out attendance_rec.last_name,
        out attendance_rec.level_emsrs_code,
        out attendance_rec.level_short_description,
        out attendance_rec.middle_initial
        );
      attendance_rec.coned_offering_id = coned_offering_id;
      return attendance_rec;
      }

    internal void SendTrainingCertificates
      (
      Queue<attendance_rec_class> attendance_rec_q,
      string sponsor_name,
      string sponsor_number,
      string reply_to_email_address,
      string class_number,
      string course_title,
      string date_final,
      decimal fr_med_trauma_ceus,
      decimal fr_other_ceus,
      decimal emt_med_trauma_ceus,
      decimal emt_other_ceus,
      decimal emtp_med_trauma_ceus,
      decimal emtp_other_ceus,
      decimal phrn_med_trauma_ceus,
      decimal phrn_other_ceus,
      string working_directory
      )
      {
      var arguments = new ArrayList();
      var stdout = k.EMPTY;
      var stderr = k.EMPTY;
      attendance_rec_class attendance_rec;
      var num_practitioners = attendance_rec_q.Count;
      var med_trauma_ceus_for_this_practitioner = new k.decimal_nonnegative();
      var other_ceus_for_this_practitioner = new k.decimal_nonnegative();
      for (var i = new k.subtype<int>(0,num_practitioners); i.val < num_practitioners; i.val++)
        {
        attendance_rec = attendance_rec_q.Dequeue() as attendance_rec_class;
        GetAppropriateCeuValuesForPractitioner
          (
          fr_med_trauma_ceus,
          fr_other_ceus,
          emt_med_trauma_ceus,
          emt_other_ceus,
          emtp_med_trauma_ceus,
          emtp_other_ceus,
          phrn_med_trauma_ceus,
          phrn_other_ceus,
          attendance_rec.level_short_description,
          ref med_trauma_ceus_for_this_practitioner,
          ref other_ceus_for_this_practitioner
          );
        arguments.Add
          (
          "--output-document=/dev/null --no-check-certificate"
          + " --post-data"
          +   "=practitioner_email_address=" + attendance_rec.email_address
          +   "&reply_to_email_address=" + reply_to_email_address
          +   "&sponsor_name=" + HttpUtility.UrlEncode(sponsor_name)
          +   "&sponsor_number=" + sponsor_number
          +   "&first_name=" + HttpUtility.UrlEncode(attendance_rec.first_name)
          +   "&middle_initial=" + HttpUtility.UrlEncode(attendance_rec.middle_initial)
          +   "&last_name=" + HttpUtility.UrlEncode(attendance_rec.last_name)
          +   "&certification_number=" + attendance_rec.certification_number
          +   "&level_emsrs_code=" + attendance_rec.level_emsrs_code
          +   "&level_short_description=" + attendance_rec.level_short_description
          +   "&dob=" + HttpUtility.UrlEncode(attendance_rec.dob)
          +   "&class_number=" + class_number
          +   "&course_title=" + HttpUtility.UrlEncode(course_title)
          +   "&med_trauma_ceus=" + med_trauma_ceus_for_this_practitioner.val.ToString()
          +   "&other_ceus=" + other_ceus_for_this_practitioner.val.ToString()
          +   "&date_final=" + HttpUtility.UrlEncode(date_final)
          +   "&instructor_hours=" + attendance_rec.instructor_hours
          + k.SPACE
          + "\"" + ConfigurationManager.AppSettings["runtime_root_fullspec"] + "noninteractive/report_commanded_training_certificate.aspx\""
          );
        }
      k.RunCommandIteratedOverArguments("c:\\cygwin\\bin\\wget",arguments,working_directory,out stdout,out stderr);
      }

    public void Set
      (
      string id,
      string coned_offering_id,
      string practitioner_id,
      string instructor_hours
      )
      {
      db_coned_offering_rosters.Set
        (
        id,
        coned_offering_id,
        practitioner_id,
        instructor_hours
        );
      }

    internal bool SetFromBatch
      (
      string coned_offering_id,
      string cert_num
      )
      {
      return db_coned_offering_rosters.SetFromBatch(coned_offering_id,cert_num);
      }

    internal string SizeOf(string coned_offering_id)
      {
      return db_coned_offering_rosters.SizeOf(coned_offering_id);
      }

    } // end TClass_biz_coned_offering_rosters

  }
