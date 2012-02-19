// Derived from KiAspdotnetFramework/component/biz/Class~biz~~template~kicrudhelped~item.cs~template

using Class_biz_user;
using Class_db_coned_offering_rosters;
using Class_db_teaching_entities;
using kix;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Class_biz_coned_offering_rosters
  {
  public class TClass_biz_coned_offering_rosters
    {

    private TClass_biz_user biz_user = null;
    private TClass_db_coned_offering_rosters db_coned_offering_rosters = null;
    private TClass_db_teaching_entities db_teaching_entities = null;

    public TClass_biz_coned_offering_rosters() : base()
      {
      biz_user = new TClass_biz_user();
      db_coned_offering_rosters = new TClass_db_coned_offering_rosters();
      db_teaching_entities = new TClass_db_teaching_entities();
      }

    internal bool BeOkToInputBatch()
      {
      return ((biz_user.Kind() == "coned_sponsor") && (biz_user.IdNum() == db_teaching_entities.IdOfPublicContactName("EMSI")));
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

      public void BindDirectToListControl(object target)
      {
      db_coned_offering_rosters.BindDirectToListControl(target);
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

    internal class attendee_rec
      {
      internal string email_address = k.EMPTY;
      internal string first_name = k.EMPTY;
      internal string middle_initial = k.EMPTY;
      internal string last_name = k.EMPTY;
      internal string certification_number = k.EMPTY;
      internal string level_emsrs_code = k.EMPTY;
      internal string level_short_description = k.EMPTY;
      internal string dob = k.EMPTY;
      }
    internal void SendTrainingCertificates
      (
      Queue<attendee_rec> practitioner_q,
      string sponsor_name,
      string reply_to_email_address,
      string course_number,
      string course_title,
      string date_final,
      k.decimal_nonnegative fr_total_ceus,
      k.decimal_nonnegative fr_med_trauma_ceus,
      k.decimal_nonnegative emt_total_ceus,
      k.decimal_nonnegative emt_med_trauma_ceus,
      k.decimal_nonnegative emtp_total_ceus,
      k.decimal_nonnegative emtp_med_trauma_ceus,
      k.decimal_nonnegative phrn_total_ceus,
      k.decimal_nonnegative phrn_med_trauma_ceus,
      string working_directory
      )
      {
      var arguments = new ArrayList();
      var stdout = k.EMPTY;
      var stderr = k.EMPTY;
      attendee_rec attendee;
      var num_practitioners = practitioner_q.Count;
      for (var i = new k.subtype<int>(0,num_practitioners); i.val < num_practitioners; i.val++)
        {
        attendee = practitioner_q.Dequeue() as attendee_rec;
        var total_ceus_for_this_practitioner = new k.decimal_nonnegative();
        var med_trauma_ceus_for_this_practitioner = new k.decimal_nonnegative();
        if (attendee.level_short_description == "FR")
          {
          total_ceus_for_this_practitioner.val = fr_total_ceus.val;
          med_trauma_ceus_for_this_practitioner.val = fr_med_trauma_ceus.val;
          }
        else if (attendee.level_short_description == "EMT")
          {
          total_ceus_for_this_practitioner.val = emt_total_ceus.val;
          med_trauma_ceus_for_this_practitioner.val = emt_med_trauma_ceus.val;
          }
        else if (attendee.level_short_description == "EMT-P")
          {
          total_ceus_for_this_practitioner.val = emtp_total_ceus.val;
          med_trauma_ceus_for_this_practitioner.val = emtp_med_trauma_ceus.val;
          }
        else if (attendee.level_short_description == "PHRN")
          {
          total_ceus_for_this_practitioner.val = phrn_total_ceus.val;
          med_trauma_ceus_for_this_practitioner.val = phrn_med_trauma_ceus.val;
          }
        arguments.Add
          (
          "--output-document=/dev/null --no-check-certificate"
          + " --post-data"
          +   "=practitioner_email_address=" + attendee.email_address
          +   "&reply_to_email_address=" + reply_to_email_address
          +   "&sponsor_name=" + sponsor_name
          +   "&first_name=" + attendee.first_name
          +   "&middle_initial=" + attendee.middle_initial
          +   "&last_name=" + attendee.last_name
          +   "&certification_number=" + attendee.certification_number
          +   "&level_emsrs_code=" + attendee.level_emsrs_code
          +   "&level_short_description=" + attendee.level_short_description
          +   "&dob=" + attendee.dob
          +   "&course_number=" + course_number
          +   "&course_title=" + course_title
          +   "&total_ceus=" + total_ceus_for_this_practitioner.val.ToString()
          +   "&med_trauma_ceus=" + med_trauma_ceus_for_this_practitioner.val.ToString()
          +   "&date_final=" + date_final
          + k.SPACE
          + "\"" + ConfigurationManager.AppSettings["runtime_root_fullspec"] + "noninteractive/report_commanded_training_certificates.aspx\""
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

    } // end TClass_biz_coned_offering_rosters

  }
