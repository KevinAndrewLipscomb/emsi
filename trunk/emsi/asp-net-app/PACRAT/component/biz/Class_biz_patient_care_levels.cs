// Derived from KiAspdotnetFramework/component/biz/Class~biz~~template~kicrudhelped~item.cs~template

using Class_db_patient_care_levels;
using kix;
using System;
using System.Collections;

namespace Class_biz_patient_care_levels
  {
  public class TClass_biz_patient_care_levels
    {
    private TClass_db_patient_care_levels db_patient_care_levels = null;

    public TClass_biz_patient_care_levels() : base()
      {
      db_patient_care_levels = new TClass_db_patient_care_levels();
      }

    public bool Bind(string partial_spec, object target)
      {
      return db_patient_care_levels.Bind(partial_spec, target);
      }

    public void BindBaseDataList
      (
      string sort_order,
      bool be_sort_order_ascending,
      object target
      )
      {
      db_patient_care_levels.BindBaseDataList(sort_order,be_sort_order_ascending,target);
      }

    public void BindDirectToListControl(object target)
      {
      db_patient_care_levels.BindDirectToListControl(target);
      }

    public bool Delete(string id)
      {
      return db_patient_care_levels.Delete(id);
      }

    public bool Get
      (
      string id,
      out string description,
      out string pecking_order
      )
      {
      return db_patient_care_levels.Get
        (
        id,
        out description,
        out pecking_order
        );
      }

    public void Set
      (
      string id,
      string description,
      string pecking_order
      )
      {
      db_patient_care_levels.Set
        (
        id,
        description,
        pecking_order
        );
      }

    internal object Summary(string id)
      {
      return db_patient_care_levels.Summary(id);
      }

    } // end TClass_biz_patient_care_levels

  }
