using MySql.Data.MySqlClient;
using kix;
using System;


using System.Collections;
using System.Web.UI.WebControls;
using Class_db;
using Class_db_trail;
using Class_db_roles;
namespace Class_db_role_member_map
{
  public static class Class_db_role_member_map_Static
    {
    public const int CI_MEMBER_ID = 0;
    public const int CI_MEMBER_NAME = 1;
    public const int CI_FIRST_CROSSTAB = 2;
    public const int ROLE_HOLDER_EMAIL_ADDRESS_CI = 1;
    }

    public class TClass_db_role_member_map: TClass_db
    {
        private TClass_db_trail db_trail = null;
        //Constructor  Create()
        public TClass_db_role_member_map() : base()
        {
            db_trail = new TClass_db_trail();
        }
        public void Bind(string sort_order, bool be_sort_order_descending, object target, out ArrayList crosstab_metadata_rec_arraylist)
        {
            crosstab_metadata_rec_type crosstab_metadata_rec;
            string crosstab_sql;
            string crosstab_where_clause = k.EMPTY;
            MySqlDataReader dr;
            string where_clause;
            crosstab_metadata_rec.index = 1;
            // init to index of last non-dependent column
            crosstab_metadata_rec_arraylist = new ArrayList();
            crosstab_sql = k.EMPTY;
            this.Open();
            dr = new MySqlCommand("select id,name,soft_hyphenation_text,tier_id" + " from role" + " where name <> \"Member\"" + crosstab_where_clause, this.connection).ExecuteReader();
            while (dr.Read())
            {
                crosstab_metadata_rec.index = crosstab_metadata_rec.index + 1;
                crosstab_metadata_rec.id = dr["id"].ToString();
                crosstab_metadata_rec.natural_text = dr["name"].ToString();
                crosstab_metadata_rec.soft_hyphenation_text = dr["soft_hyphenation_text"].ToString();
                crosstab_metadata_rec.sql_name = k.Safe(crosstab_metadata_rec.natural_text, k.safe_hint_type.ECMASCRIPT_WORD);
                crosstab_sql = crosstab_sql + k.COMMA_SPACE + "IFNULL((select 1 from role_member_map where role_id = \"" + dr["id"].ToString() + "\" and member_id = member.id),0) as " + crosstab_metadata_rec.sql_name;
                crosstab_metadata_rec_arraylist.Add(crosstab_metadata_rec);
            }
            dr.Close();
            where_clause = k.EMPTY;
            if (be_sort_order_descending)
            {
                sort_order = sort_order.Replace("%", " desc");
            }
            else
            {
                sort_order = sort_order.Replace("%", " asc");
            }
            ((target) as GridView).DataSource = new MySqlCommand("select member.id as member_id" + " , concat(last_name,\"" + k.COMMA_SPACE + "\",first_name) as member_name" + crosstab_sql + " from member" + " left outer join role_member_map on (role_member_map.member_id=member.id)" + " left outer join role on (role.id=role_member_map.role_id)" + where_clause + " group by member.id" + " order by " + sort_order, this.connection).ExecuteReader();
            ((target) as GridView).DataBind();
            this.Close();

        }

        public void BindActuals(string sort_order, bool be_sort_order_ascending, object target)
        {
            string where_clause;
            where_clause = " where role.name <> \"Member\"";
            if (be_sort_order_ascending)
            {
                sort_order = sort_order.Replace("%", " asc");
            }
            else
            {
                sort_order = sort_order.Replace("%", " desc");
            }
            this.Open();
            ((target) as GridView).DataSource = new MySqlCommand("select role_id" + " , pecking_order as role_pecking_order" + " , role.name as role_name" + " , concat(member.last_name,\", \",first_name) as member_designator" + " , member_id" + " from role_member_map" + " join member on (member.id=role_member_map.member_id)" + " join role on (role.id=role_member_map.role_id)" + where_clause + " order by " + sort_order, this.connection).ExecuteReader();
            ((target) as GridView).DataBind();
            this.Close();

        }

        internal void BindBaseDataListByExplicitRegionCode
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
            "select practitioner.id as practitioner_id"
            + " , last_name"
            + " , first_name"
            + " , middle_initial"
            + " , practitioner_level.short_description as level"
            + " , LPAD(certification_number,6,'0') as certification_number_for_display"
            + " , IFNULL(DATE_FORMAT(birth_date,'%m/%d/%Y'),'REQUIRED') as birth_date"
            + " , be_birth_date_confirmed"
            + " , IFNULL(email_address,'DESIRED') as email_address"
            + " , practitioner_level.emsrs_code as level_emsrs_code"
            + " , practitioner_status.description as practitioner_status_description"
            + " from role_member_map"
            +   " join practitioner on (practitioner.id=role_member_map.member_id)"
            +   " join practitioner_level on (practitioner_level.id=practitioner.level_id)"
            +   " join practitioner_status on (practitioner_status.id=practitioner.status_id)"
            + " where region_code = '" + region_code + "'"
            + " order by " + sort_order.Replace("%", (be_sort_order_ascending ? " asc" : " desc")),
            connection
            )
            .ExecuteReader();
          ((target) as BaseDataList).DataBind();
          (((target) as BaseDataList).DataSource as MySqlDataReader).Close();
          Close();
          }

        public void BindHolders(string role_name, object target, string sort_order, bool be_sort_order_ascending)
        {
            this.Open();
            if (be_sort_order_ascending)
            {
                sort_order = sort_order.Replace("%", " asc");
            }
            else
            {
                sort_order = sort_order.Replace("%", " desc");
            }
            ((target) as GridView).DataSource = new MySqlCommand("select concat(last_name,\", \",first_name) as member_name" + " , email_address" + " from role_member_map" + " join member on (member.id=role_member_map.member_id)" + " join role on (role.id=role_member_map.role_id)" + " where role.name = \"" + role_name + "\"" + " order by " + sort_order, this.connection).ExecuteReader();
            ((target) as GridView).DataBind();
            this.Close();

        }

        public void Save(string member_id, string role_id, bool be_granted)
        {
            this.Open();
            if (be_granted)
            {
                new MySqlCommand(db_trail.Saved("insert ignore role_member_map set member_id = \"" + member_id + "\", role_id = \"" + role_id + "\""), this.connection).ExecuteNonQuery();
            }
            else
            {
                new MySqlCommand(db_trail.Saved("delete from role_member_map where member_id = \"" + member_id + "\" and role_id = \"" + role_id + "\""), this.connection).ExecuteNonQuery();
            }
            this.Close();
        }

        internal void SaveForExplicitRegion
          (
          string member_id,
          string role_id,
          bool be_granted,
          string region_code
          )
          {
          Open();
          if (be_granted)
            {
            new MySqlCommand(db_trail.Saved("insert ignore role_member_map set member_id = '" + member_id + "', role_id = '" + role_id + "', region_code = '" + region_code + "'"),connection).ExecuteNonQuery();
            }
          else
            {
            new MySqlCommand(db_trail.Saved("delete from role_member_map where member_id = '" + member_id + "' and role_id = '" + role_id + "' and region_code = '" + region_code + "'"),connection).ExecuteNonQuery();
            }
          Close();
          }

    } // end TClass_db_role_member_map

}

