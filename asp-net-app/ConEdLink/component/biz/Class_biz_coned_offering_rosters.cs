// Derived from KiAspdotnetFramework/component/biz/Class~biz~~template~kicrudhelped~item.cs~template

using Class_biz_user;
using Class_db_coned_offering_rosters;
using Class_db_teaching_entities;
using kix;
using System.Collections;
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
