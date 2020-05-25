// Derived from KiAspdotnetFramework/component/biz/Class~biz~~template~kicrudhelped~item.cs~template

using Class_db_coned_offering_rosters;
using Class_db_old_analysis_of_region_by_years;
using kix;
using System;

namespace Class_biz_old_analysis_of_region_by_years
  {
  internal enum presentation_mode_enum
    {
    NONE,
    FULL_FUNCTION,
    NEW,
    REVIEW_ONLY
    };

  public class TClass_biz_old_analysis_of_region_by_years
    {

    private readonly TClass_db_coned_offering_rosters db_coned_offering_rosters = null;
    private readonly TClass_db_old_analysis_of_region_by_years db_old_analysis_of_region_by_years = null;

    public TClass_biz_old_analysis_of_region_by_years() : base()
      {
      db_coned_offering_rosters = new TClass_db_coned_offering_rosters();
      db_old_analysis_of_region_by_years = new TClass_db_old_analysis_of_region_by_years();
      }

    public bool Bind(string partial_spec, object target)
      {
      return db_old_analysis_of_region_by_years.Bind(partial_spec, target);
      }

    internal void BindBaseDataList
      (
      string sort_order,
      bool be_sort_order_ascending,
      object target,
      string region_code,
      string practitioner_level_filter
      )
      {
      db_old_analysis_of_region_by_years.BindBaseDataList(sort_order,be_sort_order_ascending,target,region_code,practitioner_level_filter);
      }

    public void BindDirectToListControl(object target)
      {
      db_old_analysis_of_region_by_years.BindDirectToListControl(target);
      }

    public bool Delete(string id)
      {
      return db_old_analysis_of_region_by_years.Delete(id);
      }

    public bool Get
      (
      string id,
      out string region_code,
      out DateTime fiscal_year_ending,
      out string practitioner_level_id,
      out string num_classes,
      out string num_sittings,
      out string avg_num_students_per_class,
      out string num_distinct_practitioners
      )
      {
      return db_old_analysis_of_region_by_years.Get
        (
        id,
        out region_code,
        out fiscal_year_ending,
        out practitioner_level_id,
        out num_classes,
        out num_sittings,
        out avg_num_students_per_class,
        out num_distinct_practitioners
        );
      }

    internal void PopulatePast()
      {
      var region_code = k.EMPTY;
      DateTime fiscal_year_ending;
      var practitioner_level_id = k.EMPTY;
      var num_classes = k.EMPTY;
      var num_sittings = k.EMPTY;
      var avg_num_students_per_class = k.EMPTY;
      var num_distinct_practitioners = k.EMPTY;
      //
      //
      for (var fiscal_year_ending_index = new k.subtype<int>(2013,DateTime.Today.Year); fiscal_year_ending_index.val < fiscal_year_ending_index.LAST; fiscal_year_ending_index.val++)
        {
        fiscal_year_ending = new DateTime(year:fiscal_year_ending_index.val,month:1,day:1);
        for (var region_code_index = new k.subtype<int>(-1,20); region_code_index.val < region_code_index.LAST; region_code_index.val++)
          {
          region_code = (region_code_index.val < 0 ? k.EMPTY : (region_code_index.val + 1).ToString());
          for (var practitioner_level_index = new k.subtype<int>(-1,14); practitioner_level_index.val < practitioner_level_index.LAST; practitioner_level_index.val++)
            {
            practitioner_level_id = (practitioner_level_index.val < 0 ? k.EMPTY : (practitioner_level_index.val + 1).ToString());
            db_coned_offering_rosters.GetAnalysisOfRegionByYear
              (
              year:fiscal_year_ending.Year.ToString(),
              region_code:region_code,
              practitioner_level_filter:practitioner_level_id,
              num_classes:out num_classes,
              num_sittings:out num_sittings,
              avg_num_students_per_class:out avg_num_students_per_class,
              num_distinct_practitioners:out num_distinct_practitioners
              );
            if(
                int.Parse(num_classes) > 0
              ||
                int.Parse(num_sittings) > 0
              ||
                int.Parse(num_distinct_practitioners) > 0
              )
            //then
              {
              db_old_analysis_of_region_by_years.Set
                (
                id:k.EMPTY,
                region_code:region_code,
                fiscal_year_ending:fiscal_year_ending,
                practitioner_level_id:practitioner_level_id,
                num_classes:num_classes,
                num_sittings:num_sittings,
                avg_num_students_per_class:avg_num_students_per_class,
                num_distinct_practitioners:num_distinct_practitioners
                );
              }
            }
          }
        }
      }

    internal void ReduceFiscalYearEndingLastYear()
      {
      var region_code = k.EMPTY;
      var practitioner_level_id = k.EMPTY;
      var num_classes = k.EMPTY;
      var num_sittings = k.EMPTY;
      var avg_num_students_per_class = k.EMPTY;
      var num_distinct_practitioners = k.EMPTY;
      //
      var fiscal_year_ending = new DateTime(year:(DateTime.Today.Year - 1),month:6,day:30);
      for (var region_code_index = new k.subtype<int>(-1,20); region_code_index.val < region_code_index.LAST; region_code_index.val++)
        {
        region_code = (region_code_index.val < 0 ? k.EMPTY : (region_code_index.val + 1).ToString());
        for (var practitioner_level_index = new k.subtype<int>(-1,14); practitioner_level_index.val < practitioner_level_index.LAST; practitioner_level_index.val++)
          {
          practitioner_level_id = (practitioner_level_index.val < 0 ? k.EMPTY : (practitioner_level_index.val + 1).ToString());
          db_coned_offering_rosters.GetAnalysisOfRegionByYear
            (
            year:fiscal_year_ending.Year.ToString(),
            region_code:region_code,
            practitioner_level_filter:practitioner_level_id,
            num_classes:out num_classes,
            num_sittings:out num_sittings,
            avg_num_students_per_class:out avg_num_students_per_class,
            num_distinct_practitioners:out num_distinct_practitioners
            );
          if(
              int.Parse(num_classes) > 0
            ||
              int.Parse(num_sittings) > 0
            ||
              int.Parse(num_distinct_practitioners) > 0
            )
          //then
            {
            db_old_analysis_of_region_by_years.Set
              (
              id:k.EMPTY,
              region_code:region_code,
              fiscal_year_ending:fiscal_year_ending,
              practitioner_level_id:practitioner_level_id,
              num_classes:num_classes,
              num_sittings:num_sittings,
              avg_num_students_per_class:avg_num_students_per_class,
              num_distinct_practitioners:num_distinct_practitioners
              );
            }
          }
        }
      }

    public void Set
      (
      string id,
      string region_code,
      DateTime fiscal_year_ending,
      string practitioner_level_id,
      string num_classes,
      string num_sittings,
      string avg_num_students_per_class,
      string num_distinct_practitioners
      )
      {
      db_old_analysis_of_region_by_years.Set
        (
        id,
        region_code,
        fiscal_year_ending,
        practitioner_level_id,
        num_classes,
        num_sittings,
        avg_num_students_per_class,
        num_distinct_practitioners
        );
      }

    internal object Summary(string id)
      {
      return db_old_analysis_of_region_by_years.Summary(id);
      }

    } // end TClass_biz_old_analysis_of_region_by_years

  }
