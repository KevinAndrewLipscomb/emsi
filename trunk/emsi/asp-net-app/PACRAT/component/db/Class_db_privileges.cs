using Class_db;
using Class_db_trail;
using kix;
using MySql.Data.MySqlClient;
using System.Web.UI.WebControls;

namespace Class_db_privileges
{
    public class TClass_db_privileges: TClass_db
    {
        private TClass_db_trail db_trail = null;
        //Constructor  Create()
        public TClass_db_privileges() : base()
        {
            // TODO: Add any constructor code here
            db_trail = new TClass_db_trail();
        }
        public bool Bind(string partial_name, object target)
        {
            bool result;
            MySqlDataReader dr;
            this.Open();
            ((target) as ListControl).Items.Clear();
            dr = new MySqlCommand("SELECT name FROM privilege WHERE name like \"" + partial_name + "%\" order by name", this.connection).ExecuteReader();
            while (dr.Read())
            {
                ((target) as ListControl).Items.Add(new ListItem(dr["name"].ToString(), dr["name"].ToString()));
            }
            dr.Close();
            this.Close();
            result = ((target) as ListControl).Items.Count > 0;
            return result;
        }

        public void BindDirectToListControl(object target, string unselected_literal, string selected_value)
        {
            MySqlDataReader dr;
            ((target) as ListControl).Items.Clear();
            if (unselected_literal != k.EMPTY)
            {
                ((target) as ListControl).Items.Add(new ListItem(unselected_literal, k.EMPTY));
            }
            this.Open();
            dr = new MySqlCommand("select privilege.id as privilege_id" + " , name as privilege_name" + " from privilege" + " order by privilege_name", this.connection).ExecuteReader();
            while (dr.Read())
            {
                ((target) as ListControl).Items.Add(new ListItem(dr["privilege_name"].ToString(), dr["privilege_id"].ToString()));
            }
            dr.Close();
            this.Close();
            if (selected_value != k.EMPTY)
            {
                ((target) as ListControl).SelectedValue = selected_value;
            }

        }

        public void BindDirectToListControl(object target)
        {
            BindDirectToListControl(target, "-- Privilege --");
        }

        public void BindDirectToListControl(object target, string unselected_literal)
        {
            BindDirectToListControl(target, unselected_literal, k.EMPTY);
        }

        internal void BindRegionsInWhichMemberHasPrivilegeDirectToListControl
          (
          string member_id,
          string privilege_name,
          object target,
          string unselected_literal,
          string selected_value
          )
          {
          ((target) as ListControl).Items.Clear();
          if (unselected_literal != k.EMPTY)
            {
            (target as ListControl).Items.Add(new ListItem(unselected_literal, k.EMPTY));
            }
          Open();
          var dr = new MySqlCommand
            (
            "select region_code_name_map.code as region_code"
            + " , region_code_name_map.name as region_name"
            + " from region_code_name_map"
            +   " join role_member_map on (role_member_map.region_code=region_code_name_map.code or (role_member_map.region_code is null and role_member_map.service_id is null))"
            +   " join role_privilege_map on (role_privilege_map.role_id=role_member_map.role_id)"
            +   " join privilege on (privilege.id=role_privilege_map.privilege_id)"
            + " where member_id = '" + member_id + "'"
            +   " and privilege.name = '" + privilege_name + "'"
            +   " and be_pacrat_subscriber"
            + " order by region_name",
            connection
            )
            .ExecuteReader();
          while (dr.Read())
            {
            (target as ListControl).Items.Add(new ListItem(dr["region_name"].ToString(), dr["region_code"].ToString()));
            }
          dr.Close();
          Close();
          if (selected_value != k.EMPTY)
            {
            (target as ListControl).SelectedValue = selected_value;
            }
          }
        internal void BindRegionsInWhichMemberHasPrivilegeDirectToListControl(string member_id,string privilege_name,object target,string unselected_literal)
          {
          BindRegionsInWhichMemberHasPrivilegeDirectToListControl(member_id,privilege_name,target,unselected_literal,selected_value:k.EMPTY);
          }
        internal void BindRegionsInWhichMemberHasPrivilegeDirectToListControl(string member_id,string privilege_name,object target)
          {
          BindRegionsInWhichMemberHasPrivilegeDirectToListControl(member_id,privilege_name,target,unselected_literal:"-- Region --");
          }

        public bool Get(string name, out string soft_hyphenation_text)
        {
            bool result;
            MySqlDataReader dr;

            soft_hyphenation_text = k.EMPTY;
            result = false;
            this.Open();
            dr = new MySqlCommand("select * from privilege where CAST(name AS CHAR) = \"" + name + "\"", this.connection).ExecuteReader();
            if (dr.Read())
            {
                name = dr["name"].ToString();
                soft_hyphenation_text = dr["soft_hyphenation_text"].ToString();
                result = true;
            }
            dr.Close();
            this.Close();
            return result;
        }

        internal bool HasForAnyScope
          (
          string member_id,
          string privilege_name
          )
          {
          Open();
          //
          // An "access denied" exception attributed to the account INVOKING the following SELECT statement may actually indicate that access has been denied to the EXACT MATCH for the DEFINER of the "member" view.
          //
          var has_for_any_scope_obj = new MySqlCommand
            (
            "select 1"
            + " from member"
            +   " join role_member_map on (role_member_map.member_id=member.id)"
            +   " join role on (role.id=role_member_map.role_id)"
            +   " join role_privilege_map on (role_privilege_map.role_id=role.id)"
            +   " join privilege on (privilege.id=role_privilege_map.privilege_id)"
            + " where member.id = '" + member_id + "'"
            +   " and privilege.name = '" + privilege_name + "'",
            connection
            )
            .ExecuteScalar();
          Close();
          return (has_for_any_scope_obj != null);
          }

        internal bool HasForPennsylvania(string member_id, string privilege_name)
          {
          Open();
          var has_for_any_scope_obj = new MySqlCommand
            (
            "select 1"
            + " from member"
            +   " join role_member_map on (role_member_map.member_id=member.id)"
            +   " join role on (role.id=role_member_map.role_id)"
            +   " join role_privilege_map on (role_privilege_map.role_id=role.id)"
            +   " join privilege on (privilege.id=role_privilege_map.privilege_id)"
            + " where member.id = '" + member_id + "'"
            +   " and privilege.name = '" + privilege_name + "'"
            +   " and region_code is null"
            +   " and service_id is null",
            connection
            )
            .ExecuteScalar();
          Close();
          return (has_for_any_scope_obj != null);
          }

        internal bool HasForRegion
          (
          string member_id,
          string privilege_name,
          string region_code
          )
          {
          Open();
          var has_for_region_obj = new MySqlCommand
            (
            "select 1"
            + " from member"
            +   " join role_member_map on (role_member_map.member_id=member.id)"
            +   " join role on (role.id=role_member_map.role_id)"
            +   " join role_privilege_map on (role_privilege_map.role_id=role.id)"
            +   " join privilege on (privilege.id=role_privilege_map.privilege_id)"
            + " where member.id = '" + member_id + "'"
            +   " and privilege.name = '" + privilege_name + "'"
            +   " and (region_code = '" + region_code + "' or region_code is null)",
            connection
            )
            .ExecuteScalar();
          Close();
          return (has_for_region_obj != null);
          }

        internal bool HasForService
          (
          string member_id,
          string privilege_name,
          string service_id
          )
          {
          Open();
          var has_for_service_obj = new MySqlCommand
            (
            "select 1"
            + " from member"
            +   " join role_member_map on (role_member_map.member_id=member.id)"
            +   " join role on (role.id=role_member_map.role_id)"
            +   " join role_privilege_map on (role_privilege_map.role_id=role.id)"
            +   " join privilege on (privilege.id=role_privilege_map.privilege_id)"
            + " where member.id = '" + member_id + "'"
            +   " and privilege.name = '" + privilege_name + "'"
            +   " and (service_id = '" + service_id + "' or service_id is null)",
            connection
            )
            .ExecuteScalar();
          Close();
          return (has_for_service_obj != null);
          }

    } // end TClass_db_privileges

}
