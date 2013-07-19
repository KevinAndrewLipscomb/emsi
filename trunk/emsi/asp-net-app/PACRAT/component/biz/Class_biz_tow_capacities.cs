// Derived from KiAspdotnetFramework/component/biz/Class~biz~~template~kicrudhelped~item.cs~template

using Class_db_tow_capacities;
using kix;
using System;
using System.Collections;

namespace Class_biz_tow_capacities
  {
  public class TClass_biz_tow_capacities
    {
    private TClass_db_tow_capacities db_tow_capacities = null;

    public TClass_biz_tow_capacities() : base()
      {
      db_tow_capacities = new TClass_db_tow_capacities();
      }

    public bool Bind(string partial_spec, object target)
      {
      return db_tow_capacities.Bind(partial_spec, target);
      }

    public void BindBaseDataList
      (
      string sort_order,
      bool be_sort_order_ascending,
      object target
      )
      {
      db_tow_capacities.BindBaseDataList(sort_order,be_sort_order_ascending,target);
      }

    public void BindDirectToListControl(object target)
      {
      db_tow_capacities.BindDirectToListControl(target);
      }

    public void BindLongDescriptionDirectToListControl(object target)
      {
      db_tow_capacities.BindLongDescriptionDirectToListControl(target);
      }

    public bool Delete(string id)
      {
      return db_tow_capacities.Delete(id);
      }

    public bool Get
      (
      string id,
      out string short_description,
      out string long_description,
      out string pecking_order
      )
      {
      return db_tow_capacities.Get
        (
        id,
        out short_description,
        out long_description,
        out pecking_order
        );
      }

    public void Set
      (
      string id,
      string short_description,
      string long_description,
      string pecking_order
      )
      {
      db_tow_capacities.Set
        (
        id,
        short_description,
        long_description,
        pecking_order
        );
      }

    internal object Summary(string id)
      {
      return db_tow_capacities.Summary(id);
      }

    } // end TClass_biz_tow_capacities

  }
