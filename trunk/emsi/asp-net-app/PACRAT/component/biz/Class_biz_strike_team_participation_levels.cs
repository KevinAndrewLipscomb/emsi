// Derived from KiAspdotnetFramework/component/biz/Class~biz~~template~kicrudhelped~item.cs~template

using Class_db_strike_team_participation_levels;
using kix;
using System;
using System.Collections;

namespace Class_biz_strike_team_participation_levels
  {
  internal enum presentation_mode_enum
    {
    NONE,
    FULL_FUNCTION,
    NEW,
    REVIEW_ONLY
    };

  public class TClass_biz_strike_team_participation_levels
    {
    private TClass_db_strike_team_participation_levels db_strike_team_participation_levels = null;

    public TClass_biz_strike_team_participation_levels() : base()
      {
      db_strike_team_participation_levels = new TClass_db_strike_team_participation_levels();
      }

    public bool Bind(string partial_spec, object target)
      {
      return db_strike_team_participation_levels.Bind(partial_spec, target);
      }

    public void BindBaseDataList
      (
      string sort_order,
      bool be_sort_order_ascending,
      object target
      )
      {
      db_strike_team_participation_levels.BindBaseDataList(sort_order,be_sort_order_ascending,target);
      }

    public void BindDirectToListControl
      (
      object target,
      string selected_value = k.EMPTY
      )
      {
      db_strike_team_participation_levels.BindDirectToListControl(target,selected_value);
      }

    public bool Delete(string id)
      {
      return db_strike_team_participation_levels.Delete(id);
      }

    internal string ElaborationOf(string id)
      {
      return db_strike_team_participation_levels.ElaborationOf(id);
      }

    public bool Get
      (
      string id,
      out string description,
      out string pecking_order,
      out string elaboration
      )
      {
      return db_strike_team_participation_levels.Get
        (
        id,
        out description,
        out pecking_order,
        out elaboration
        );
      }

    public void Set
      (
      string id,
      string description,
      string pecking_order,
      string elaboration
      )
      {
      db_strike_team_participation_levels.Set
        (
        id,
        description,
        pecking_order,
        elaboration
        );
      }

    internal object Summary(string id)
      {
      return db_strike_team_participation_levels.Summary(id);
      }

    } // end TClass_biz_strike_team_participation_levels

  }
