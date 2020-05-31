using Class_biz_coned_offerings;
using Class_biz_old_analysis_of_region_by_years;
using Class_biz_practitioners;
using Class_biz_teaching_entities;
using ConEdLink.component.os;

namespace Class_biz_scheduled_tasks
  {
  public class TClass_biz_scheduled_tasks
    {

    private readonly TClass_biz_coned_offerings biz_coned_offerings;
    private readonly TClass_biz_old_analysis_of_region_by_years biz_old_analysis_of_region_by_years;
    private readonly TClass_biz_practitioners biz_practitioners;
    private readonly TClass_biz_teaching_entities biz_teaching_entities;
    private readonly Class_fs fs;

    //Constructor  Create()
    public TClass_biz_scheduled_tasks() : base()
      {
      biz_coned_offerings = new TClass_biz_coned_offerings();
      biz_old_analysis_of_region_by_years = new TClass_biz_old_analysis_of_region_by_years();
      biz_practitioners = new TClass_biz_practitioners();
      biz_teaching_entities = new TClass_biz_teaching_entities();
      fs = new Class_fs();
      }

    public void DoDailyChores(string current_working_directory_spec)
      {
      fs.DeleteCondemnedFolders(current_working_directory_spec + "/../protected/attachment");
      biz_coned_offerings.MakeRosterDueNotifications();
      biz_coned_offerings.PurgeStaleUnused();
      }

    internal void DoFirstOfCalendarYearChores()
      {
      biz_old_analysis_of_region_by_years.ReduceFiscalYearEndingLastYear();
      }

    public void ImportLatestConedOfferingsFromEmsrs()
      {
      biz_coned_offerings.ImportLatestFromEmsrs();
      }

    public void ImportLatestTeachingEntitiesFromEmsrs()
      {
      biz_teaching_entities.ImportLatestFromEmsrs();
      biz_teaching_entities.SyncConedSponsorAccounts();
      }

    public void ImportLatestPractitionersFromEmsrs()
      {
      biz_practitioners.ImportLatestFromEmsrs();
      }

    } // end TClass_biz_scheduled_tasks

  }