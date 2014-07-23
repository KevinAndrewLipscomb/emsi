// Derived from KiAspdotnetFramework/component/db/Class~db~template~kicrudhelped~items.cs~template

using Class_db;
using Class_db_trail;
using kix;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Web.UI.WebControls;
using UserControl_drop_down_date;

namespace Class_db_coned_offering_rosters
  {
  public class TClass_db_coned_offering_rosters: TClass_db
    {
    private TClass_db_trail db_trail = null;

    public TClass_db_coned_offering_rosters() : base()
      {
      db_trail = new TClass_db_trail();
      }

    public bool Bind(string partial_spec, object target)
      {
      var concat_clause = "concat(id)";
      Open();
      ((target) as ListControl).Items.Clear();
      var dr = new MySqlCommand
        (
        "select id"
        + " , CONVERT(" + concat_clause + " USING utf8) as spec"
        + " from coned_offering_roster"
        + " where " + concat_clause + " like '%" + partial_spec.ToUpper() + "%'"
        + " order by spec",
        connection
        )
        .ExecuteReader();
      while (dr.Read())
        {
        ((target) as ListControl).Items.Add(new ListItem(dr["spec"].ToString(), dr["id"].ToString()));
        }
      dr.Close();
      Close();
      return ((target) as ListControl).Items.Count > 0;
      }

    public void BindBaseDataListByConedOfferingId
      (
      string sort_order,
      bool be_sort_order_ascending,
      object target,
      string id
      )
      {
      Open();
      ((target) as BaseDataList).DataSource = new MySqlCommand
        (
        "select coned_offering_roster.id as id"
        + " , practitioner.id as practitioner_id"
        + " , last_name"
        + " , first_name"
        + " , middle_initial"
        + " , practitioner_level.short_description as level"
        + " , LPAD(certification_number,6,'0') as certification_number"
        + " , LPAD(certification_number,6,'0') as certification_number_for_display"
        + " , IFNULL(DATE_FORMAT(birth_date,'%m/%d/%Y'),'REQUIRED') as birth_date"
        + " , be_birth_date_confirmed"
        + " , IFNULL(practitioner_county_code_name_map.code,coned_offering_county_code_name_map.code) as county_code"
        + " , IFNULL(practitioner_county_code_name_map.name,coned_offering_county_code_name_map.name) as county_name"
        + " , IFNULL(email_address,'DESIRED') as email_address"
        + " , IFNULL(instructor_hours,'none') as instructor_hours"
        + " , practitioner_level.emsrs_code as level_emsrs_code"
        + " , LPAD(coned_offering.region_council_num,2,'0') as region_emsrs_code"
        + " , LPAD(coned_offering.course_number,6,'0') as course_number"
        + " , RIGHT(coned_offering.class_number,6) as class"
        + " , be_instructor"
        + " , LPAD(FORMAT(IFNULL(instructor_hours*10,0),0),3,'0') as lcds_instructor_hours"
        + " , DATE_FORMAT(end_date_time,'%m/%d/%Y') as end_date"
        + " , LPAD(practitioner_county_code_name_map.emsrs_code,2,'0') as practitioner_county_emsrs_code"
        + " , coned_offering.sponsor_number as sponsor_number"
        + " , practitioner_status.description as practitioner_status_description"
        + " from coned_offering_roster"
        +   " join practitioner on (practitioner.id=coned_offering_roster.practitioner_id)"
        +   " join practitioner_level on (practitioner_level.id=practitioner.level_id)"
        +   " join coned_offering on (coned_offering.id=coned_offering_roster.coned_offering_id)"
        +   " join county_code_name_map coned_offering_county_code_name_map on (coned_offering_county_code_name_map.emsrs_code=coned_offering.class_county_code)"
        +   " left join county_code_name_map practitioner_county_code_name_map on (practitioner_county_code_name_map.code=practitioner.residence_county_code)"
        +   " join practitioner_status on (practitioner_status.id=practitioner.status_id)"
        + " where coned_offering.id = '" + id + "'"
        + " order by " + sort_order.Replace("%", (be_sort_order_ascending ? " asc" : " desc")),
        connection
        )
        .ExecuteReader();
      ((target) as BaseDataList).DataBind();
      (((target) as BaseDataList).DataSource as MySqlDataReader).Close();
      Close();
      }

    internal void BindBaseDataListForAnalysisOfRegionByCounty
      (
      string sort_order,
      bool be_sort_order_ascending,
      object target,
      string region_code,
      string year
      )
      {
      Open();
      ((target) as BaseDataList).DataSource = new MySqlCommand
        (
        "select * from"
        + " ("
        + " select county_code_name_map.name as county_name"
        + " , count(DISTINCT coned_offering.id) as num_classes"
        + " , count(coned_offering_roster.id) as num_sittings"
        + " , FORMAT(count(coned_offering_roster.id)/count(DISTINCT coned_offering.id),1) as avg_num_students_per_class"
        + " from coned_offering_roster"
        +   " join coned_offering on (coned_offering.id=coned_offering_roster.coned_offering_id)"
        +   " join coned_offering_status on (coned_offering_status.id=coned_offering.status_id)"
        +   " join region_code_name_map on (region_code_name_map.emsrs_code=coned_offering.region_council_num)"
        +   " join county_code_name_map on (county_code_name_map.emsrs_code=coned_offering.class_county_code)"
        + " where coned_offering_status.description in ('ARCHIVED','SPONSOR_SAYS_ALREADY_SUBMITTED')"
        +   " and YEAR(end_date_time) = '" + year + "'"
        +   " and region_code_name_map.code = '" + region_code + "'"
        + " group by class_county_code"
        + " )"
        + " as p"
        + " order by " + sort_order.Replace("%", (be_sort_order_ascending ? " asc" : " desc")),
        connection
        )
        .ExecuteReader();
      ((target) as BaseDataList).DataBind();
      (((target) as BaseDataList).DataSource as MySqlDataReader).Close();
      Close();
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
      Open();
      ((target) as BaseDataList).DataSource = new MySqlCommand
        (
        "select * from"
        + " ("
        + " select LPAD(course_number,6,'0') as course_number"
        + " , course_title as course_name"
        + " , count(DISTINCT coned_offering.id) as num_classes"
        + " , count(coned_offering_roster.id) as num_sittings"
        + " , FORMAT(count(coned_offering_roster.id)/count(DISTINCT coned_offering.id),1) as avg_num_students_per_class"
        + " from coned_offering_roster"
        +   " join coned_offering on (coned_offering.id=coned_offering_roster.coned_offering_id)"
        +   " join coned_offering_status on (coned_offering_status.id=coned_offering.status_id)"
        +   " join region_code_name_map on (region_code_name_map.emsrs_code=coned_offering.region_council_num)"
        +   " join teaching_entity on (teaching_entity.emsrs_id=coned_offering.sponsor_id)"
        + " where coned_offering_status.description in ('ARCHIVED','SPONSOR_SAYS_ALREADY_SUBMITTED')"
        +   " and YEAR(end_date_time) = '" + year + "'"
        +   " and region_code_name_map.code = '" + region_code + "'"
        + " group by course_number"
        + " )"
        + " as p"
        + " order by " + sort_order.Replace("%", (be_sort_order_ascending ? " asc" : " desc")),
        connection
        )
        .ExecuteReader();
      ((target) as BaseDataList).DataBind();
      (((target) as BaseDataList).DataSource as MySqlDataReader).Close();
      Close();
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
      Open();
      ((target) as BaseDataList).DataSource = new MySqlCommand
        (
        "select * from"
        + " ("
        + " select MONTH(end_date_time) as month_num"
        + " , DATE_FORMAT(end_date_time,'%b') as month"
        + " , count(DISTINCT coned_offering.id) as num_classes"
        + " , count(coned_offering_roster.id) as num_sittings"
        + " , FORMAT(count(coned_offering_roster.id)/count(DISTINCT coned_offering.id),1) as avg_num_students_per_class"
        + " from coned_offering_roster"
        +   " join coned_offering on (coned_offering.id=coned_offering_roster.coned_offering_id)"
        +   " join coned_offering_status on (coned_offering_status.id=coned_offering.status_id)"
        +   " join region_code_name_map on (region_code_name_map.emsrs_code=coned_offering.region_council_num)"
        + " where coned_offering_status.description in ('ARCHIVED','SPONSOR_SAYS_ALREADY_SUBMITTED')"
        +   " and YEAR(end_date_time) = '" + year + "'"
        +   " and region_code_name_map.code = '" + region_code + "'"
        + " group by MONTH(end_date_time)"
        + " )"
        + " as p"
        + " order by " + sort_order.Replace("%", (be_sort_order_ascending ? " asc" : " desc")),
        connection
        )
        .ExecuteReader();
      ((target) as BaseDataList).DataBind();
      (((target) as BaseDataList).DataSource as MySqlDataReader).Close();
      Close();
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
      Open();
      ((target) as BaseDataList).DataSource = new MySqlCommand
        (
        "select * from"
        + " ("
        + " select teaching_entity.sponsor_number as sponsor_number"
        + " , teaching_entity.name as sponsor_name"
        + " , count(DISTINCT coned_offering.id) as num_classes"
        + " , count(coned_offering_roster.id) as num_sittings"
        + " , FORMAT(count(coned_offering_roster.id)/count(DISTINCT coned_offering.id),1) as avg_num_students_per_class"
        + " from coned_offering_roster"
        +   " join coned_offering on (coned_offering.id=coned_offering_roster.coned_offering_id)"
        +   " join coned_offering_status on (coned_offering_status.id=coned_offering.status_id)"
        +   " join region_code_name_map on (region_code_name_map.emsrs_code=coned_offering.region_council_num)"
        +   " join teaching_entity on (teaching_entity.emsrs_id=coned_offering.sponsor_id)"
        + " where coned_offering_status.description in ('ARCHIVED','SPONSOR_SAYS_ALREADY_SUBMITTED')"
        +   " and YEAR(end_date_time) = '" + year + "'"
        +   " and region_code_name_map.code = '" + region_code + "'"
        + " group by teaching_entity.sponsor_number"
        + " )"
        + " as p"
        + " order by " + sort_order.Replace("%", (be_sort_order_ascending ? " asc" : " desc")),
        connection
        )
        .ExecuteReader();
      ((target) as BaseDataList).DataBind();
      (((target) as BaseDataList).DataSource as MySqlDataReader).Close();
      Close();
      }

    internal void BindBaseDataListForAnalysisOfRegionByYear
      (
      string sort_order,
      bool be_sort_order_ascending,
      object target,
      string region_code
      )
      {
      Open();
      ((target) as BaseDataList).DataSource = new MySqlCommand
        (
        "select * from"
        + " ("
        + " select @fye := YEAR(ADDDATE(end_date_time,INTERVAL 6 MONTH)) as fiscal_year_ending"
        + " , count(DISTINCT coned_offering.id) as num_classes"
        + " , count(coned_offering_roster.id) as num_sittings"
        + " , FORMAT(count(coned_offering_roster.id)/count(DISTINCT coned_offering.id),1) as avg_num_students_per_class"
        + " from coned_offering_roster"
        +   " join coned_offering on (coned_offering.id=coned_offering_roster.coned_offering_id)"
        +   " join coned_offering_status on (coned_offering_status.id=coned_offering.status_id)"
        +   " join region_code_name_map on (region_code_name_map.emsrs_code=coned_offering.region_council_num)"
        + " where coned_offering_status.description in ('ARCHIVED','SPONSOR_SAYS_ALREADY_SUBMITTED')"
        +   " and region_code_name_map.code = '" + region_code + "'"
        + " group by fiscal_year_ending"
        +   " having fiscal_year_ending between 2013 and YEAR(CURDATE())"
        + " )"
        + " as p"
        + " order by " + sort_order.Replace("%", (be_sort_order_ascending ? " asc" : " desc")),
        connection
        )
        .ExecuteReader();
      ((target) as BaseDataList).DataBind();
      (((target) as BaseDataList).DataSource as MySqlDataReader).Close();
      Close();
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
      Open();
      ((target) as BaseDataList).DataSource = new MySqlCommand
        (
        "select * from"
        + " ("
        + " select county_code_name_map.name as county_name"
        + " , count(DISTINCT coned_offering.id) as num_classes"
        + " , count(coned_offering_roster.id) as num_sittings"
        + " , FORMAT(count(coned_offering_roster.id)/count(DISTINCT coned_offering.id),1) as avg_num_students_per_class"
        + " from coned_offering_roster"
        +   " join coned_offering on (coned_offering.id=coned_offering_roster.coned_offering_id)"
        +   " join coned_offering_status on (coned_offering_status.id=coned_offering.status_id)"
        +   " join teaching_entity on (teaching_entity.emsrs_id=coned_offering.sponsor_id)"
        +   " join county_code_name_map on (county_code_name_map.emsrs_code=coned_offering.class_county_code)"
        + " where coned_offering_status.description in ('ARCHIVED','SPONSOR_SAYS_ALREADY_SUBMITTED')"
        +   " and YEAR(end_date_time) = '" + year + "'"
        +   " and teaching_entity.id = '" + coned_sponsor_user_id + "'"
        + " group by class_county_code"
        + " )"
        + " as p"
        + " order by " + sort_order.Replace("%", (be_sort_order_ascending ? " asc" : " desc")),
        connection
        )
        .ExecuteReader();
      ((target) as BaseDataList).DataBind();
      (((target) as BaseDataList).DataSource as MySqlDataReader).Close();
      Close();
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
      Open();
      ((target) as BaseDataList).DataSource = new MySqlCommand
        (
        "select * from"
        + " ("
        + " select LPAD(course_number,6,'0') as course_number"
        + " , course_title as course_name"
        + " , count(DISTINCT coned_offering.id) as num_classes"
        + " , count(coned_offering_roster.id) as num_sittings"
        + " , FORMAT(count(coned_offering_roster.id)/count(DISTINCT coned_offering.id),1) as avg_num_students_per_class"
        + " from coned_offering_roster"
        +   " join coned_offering on (coned_offering.id=coned_offering_roster.coned_offering_id)"
        +   " join coned_offering_status on (coned_offering_status.id=coned_offering.status_id)"
        +   " join region_code_name_map on (region_code_name_map.emsrs_code=coned_offering.region_council_num)"
        +   " join teaching_entity on (teaching_entity.emsrs_id=coned_offering.sponsor_id)"
        + " where coned_offering_status.description in ('ARCHIVED','SPONSOR_SAYS_ALREADY_SUBMITTED')"
        +   " and YEAR(end_date_time) = '" + year + "'"
        +   " and teaching_entity.id = '" + coned_sponsor_user_id + "'"
        + " group by course_number"
        + " )"
        + " as p"
        + " order by " + sort_order.Replace("%", (be_sort_order_ascending ? " asc" : " desc")),
        connection
        )
        .ExecuteReader();
      ((target) as BaseDataList).DataBind();
      (((target) as BaseDataList).DataSource as MySqlDataReader).Close();
      Close();
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
      Open();
      ((target) as BaseDataList).DataSource = new MySqlCommand
        (
        "select * from"
        + " ("
        + " select MONTH(end_date_time) as month_num"
        + " , DATE_FORMAT(end_date_time,'%b') as month"
        + " , count(DISTINCT coned_offering.id) as num_classes"
        + " , count(coned_offering_roster.id) as num_sittings"
        + " , FORMAT(count(coned_offering_roster.id)/count(DISTINCT coned_offering.id),1) as avg_num_students_per_class"
        + " from coned_offering_roster"
        +   " join coned_offering on (coned_offering.id=coned_offering_roster.coned_offering_id)"
        +   " join coned_offering_status on (coned_offering_status.id=coned_offering.status_id)"
        +   " join teaching_entity on (teaching_entity.emsrs_id=coned_offering.sponsor_id)"
        + " where coned_offering_status.description in ('ARCHIVED','SPONSOR_SAYS_ALREADY_SUBMITTED')"
        +   " and YEAR(end_date_time) = '" + year + "'"
        +   " and teaching_entity.id = '" + coned_sponsor_user_id + "'"
        + " group by MONTH(end_date_time)"
        + " )"
        + " as p"
        + " order by " + sort_order.Replace("%", (be_sort_order_ascending ? " asc" : " desc")),
        connection
        )
        .ExecuteReader();
      ((target) as BaseDataList).DataBind();
      (((target) as BaseDataList).DataSource as MySqlDataReader).Close();
      Close();
      }

    internal void BindBaseDataListForAnalysisOfSponsorByYear
      (
      string sort_order,
      bool be_sort_order_ascending,
      object target,
      string coned_sponsor_user_id
      )
      {
      Open();
      ((target) as BaseDataList).DataSource = new MySqlCommand
        (
        "select * from"
        + " ("
        + " select @fye := YEAR(ADDDATE(end_date_time,INTERVAL 6 MONTH)) as fiscal_year_ending"
        + " , count(DISTINCT coned_offering.id) as num_classes"
        + " , count(coned_offering_roster.id) as num_sittings"
        + " , FORMAT(count(coned_offering_roster.id)/count(DISTINCT coned_offering.id),1) as avg_num_students_per_class"
        + " from coned_offering_roster"
        +   " join coned_offering on (coned_offering.id=coned_offering_roster.coned_offering_id)"
        +   " join coned_offering_status on (coned_offering_status.id=coned_offering.status_id)"
        +   " join teaching_entity on (teaching_entity.emsrs_id=coned_offering.sponsor_id)"
        + " where coned_offering_status.description in ('ARCHIVED','SPONSOR_SAYS_ALREADY_SUBMITTED')"
        +   " and teaching_entity.id = '" + coned_sponsor_user_id + "'"
        + " group by fiscal_year_ending"
        +   " having fiscal_year_ending between 2013 and YEAR(CURDATE())"
        + " )"
        + " as p"
        + " order by " + sort_order.Replace("%", (be_sort_order_ascending ? " asc" : " desc")),
        connection
        )
        .ExecuteReader();
      ((target) as BaseDataList).DataBind();
      (((target) as BaseDataList).DataSource as MySqlDataReader).Close();
      Close();
      }

    public void BindDirectToListControl(object target)
      {
      Open();
      ((target) as ListControl).Items.Clear();
      var dr = new MySqlCommand
        (
        "SELECT id"
        + " , CONVERT(concat(id) USING utf8) as spec"
        + " FROM coned_offering_roster"
        + " order by spec",
        connection
        )
        .ExecuteReader();
      while (dr.Read())
        {
        ((target) as ListControl).Items.Add(new ListItem(dr["spec"].ToString(), dr["id"].ToString()));
        }
      dr.Close();
      Close();
      }

    internal void Copy
      (
      string source_id,
      string target_id
      )
      {
      Open();
      new MySqlCommand
        (
        db_trail.Saved
          (
          "insert ignore coned_offering_roster (coned_offering_id,practitioner_id,instructor_hours)"
          + " select '" + target_id + "' as coned_offering_id"
          + " , practitioner_id"
          + " , instructor_hours"
          + " from coned_offering_roster"
          + " where coned_offering_id = '" + source_id + "'"
          ),
        connection
        )
        .ExecuteNonQuery();
      Close();
      }

    public bool Delete(string id)
      {
      var result = true;
      Open();
      try
        {
        new MySqlCommand
          (
          db_trail.Saved
            (
            "delete from coned_offering_roster"
            + " where id = '" + id + "'"
            +   " and 'NEEDS_CONED_SPONSOR_FINALIZATION' ="
            +     " ("
            +     " select description"
            +     " from coned_offering"
            +       " join coned_offering_status on (coned_offering_status.id=coned_offering.status_id)"
            +     " where coned_offering.id = coned_offering_roster.coned_offering_id"
            +     " )"
            ),
          connection
          )
          .ExecuteNonQuery();
        }
      catch(System.Exception e)
        {
        if (e.Message.StartsWith("Cannot delete or update a parent row: a foreign key constraint fails", true, null))
          {
          result = false;
          }
        else
          {
          throw e;
          }
        }
      Close();
      return result;
      }

    public bool Get
      (
      string id,
      out string coned_offering_id,
      out string practitioner_id,
      out string instructor_hours
      )
      {
      coned_offering_id = k.EMPTY;
      practitioner_id = k.EMPTY;
      instructor_hours = k.EMPTY;
      var result = false;
      //
      Open();
      var dr = new MySqlCommand("select * from coned_offering_roster where CAST(id AS CHAR) = \"" + id + "\"", connection).ExecuteReader();
      if (dr.Read())
        {
        coned_offering_id = dr["coned_offering_id"].ToString();
        practitioner_id = dr["practitioner_id"].ToString();
        instructor_hours = dr["instructor_hours"].ToString();
        result = true;
        }
      dr.Close();
      Close();
      return result;
      }

    public void Set
      (
      string id,
      string coned_offering_id,
      string practitioner_id,
      string instructor_hours
      )
      {
      var childless_field_assignments_clause = k.EMPTY
      + "coned_offering_id = NULLIF('" + coned_offering_id + "','')"
      + " , practitioner_id = NULLIF('" + practitioner_id + "','')"
      + " , instructor_hours = NULLIF('" + instructor_hours + "','')"
      + k.EMPTY;
      Open();
      new MySqlCommand
        (
        db_trail.Saved
          (
          "insert coned_offering_roster (id,coned_offering_id,practitioner_id,instructor_hours)"
          + " select NULLIF('" + id + "','') as id"
          + " , NULLIF('" + coned_offering_id + "','') as coned_offering_id"
          + " , NULLIF('" + practitioner_id + "','') as practitioner_id"
          + " , NULLIF('" + instructor_hours + "','') as instructor_hours"
          + " from coned_offering"
          +   " join coned_offering_status on (coned_offering_status.id=coned_offering.status_id)"
          + " where coned_offering.id = '" + coned_offering_id + "'"
          +   " and coned_offering_status.description = 'NEEDS_CONED_SPONSOR_FINALIZATION'"
          + " on duplicate key update "
          + childless_field_assignments_clause
          ),
        connection
        )
        .ExecuteNonQuery();
      Close();
      }

    internal bool SetFromBatch
      (
      string coned_offering_id,
      string cert_num
      )
      {
      var childless_field_assignments_clause = k.EMPTY
      + "coned_offering_id = NULLIF('" + coned_offering_id + "','')"
      + " , practitioner_id = practitioner.id"
      + k.EMPTY;
      Open();
      var num_rows_affected = new MySqlCommand
        (
        db_trail.Saved
          (
          "insert ignore coned_offering_roster (coned_offering_id,practitioner_id)"
          + " select NULLIF('" + coned_offering_id + "','') as coned_offering_id"
          + " , practitioner.id as practitioner_id"
          + " from coned_offering"
          +   " join coned_offering_status on (coned_offering_status.id=coned_offering.status_id)"
          +   " join practitioner on (practitioner.certification_number='" + cert_num + "')"
          + " where coned_offering.id = '" + coned_offering_id + "'"
          +   " and coned_offering_status.description = 'NEEDS_CONED_SPONSOR_FINALIZATION'"
          + " on duplicate key update "
          + childless_field_assignments_clause
          ),
        connection
        )
        .ExecuteNonQuery();
      Close();
      return (num_rows_affected == 1);
      }

    internal string SizeOf(string coned_offering_id)
      {
      var size_of = k.EMPTY;
      Open();
      size_of = new MySqlCommand("select count(id) from coned_offering_roster where coned_offering_id = '" + coned_offering_id + "'",connection).ExecuteScalar().ToString();
      Close();
      return size_of;
      }

    } // end TClass_db_coned_offering_rosters

  }
