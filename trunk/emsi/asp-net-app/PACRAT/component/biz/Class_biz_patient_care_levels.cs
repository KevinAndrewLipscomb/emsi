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

    internal string EffectiveOf
      (
      string vehicle_patient_care_level_description,
      string practitioner_level_short_description
      )
      {
      var effective_of = "---";
      if ((vehicle_patient_care_level_description != "---") && (new ArrayList {"EMR","EMT","EMT-New","PHRN","EMT-P","HP","MCMD"}.Contains(practitioner_level_short_description)))
        {
        effective_of = "BLS";
        }
      if ((vehicle_patient_care_level_description == "ALS") && (new ArrayList {"PHRN","EMT-P","HP","MCMD"}.Contains(practitioner_level_short_description)))
        {
        effective_of = "ALS";
        }
      return effective_of;
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
