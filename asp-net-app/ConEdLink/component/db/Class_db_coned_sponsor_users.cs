using Class_db;
using Class_db_trail;
using kix;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Specialized;
using System.Web.UI.WebControls;

namespace Class_db_coned_sponsor_users
{
    public class TClass_db_coned_sponsor_users: TClass_db
    {
        private TClass_db_trail db_trail = null;
        //Constructor  Create()
        public TClass_db_coned_sponsor_users() : base()
        {
            // TODO: Add any constructor code here
            db_trail = new TClass_db_trail();
        }

        internal bool AcceptAsMember
          (
          string certification_number,
          string level_id,
          DateTime expiration_date,
          string regional_council_code,
          DateTime birth_date,
          string gender_id,
          string id
          )
          {
          var accept_as_member = false;
          object member_id_obj;
          //
          Open();
          member_id_obj = new MySqlCommand
            (
            "select id"
            + " from member"
            + " where certification_number = '" + certification_number + "'"
            +   " and level_id = '" + level_id + "'"
            +   " and expiration_date = '" + expiration_date.ToString("yyyy-MM-dd") + "'"
            +   " and regional_council_code = '" + regional_council_code + "'"
            +   " and birth_date = '" + birth_date.ToString("yyyy-MM-dd") + "'"
            +   " and gender_id = '" + gender_id + "'",
            connection
            )
            .ExecuteScalar();
          if (member_id_obj != null)
            {
            new MySqlCommand("insert user_member_map set user_id = '" + id + "' , member_id = '" + member_id_obj.ToString() + "' on duplicate key update user_id = '" + id + "'",connection).ExecuteNonQuery();
            accept_as_member = true;
            }
          Close();
          return accept_as_member;
          }

        public bool BeAuthorized(string username, string encoded_password)
        {
            bool result;
            this.Open();
            result = null != new MySqlCommand("SELECT 1 FROM user" + " where username = \"" + username + "\"" + " and encoded_password_hash = SHA1('" + encoded_password + "')", this.connection).ExecuteScalar();
            this.Close();
            return result;
        }

        public bool BeRegisteredEmailAddress(string email_address)
        {
            bool result;
            this.Open();
            result = null != new MySqlCommand("SELECT 1 FROM user where password_reset_email_address = \"" + email_address + "\"", this.connection).ExecuteScalar();
            this.Close();
            return result;
        }

        public bool BeRegisteredUsername(string username)
        {
            bool result;
            this.Open();
            result = null != new MySqlCommand("SELECT 1 FROM user where username = \"" + username + "\"", this.connection).ExecuteScalar();
            this.Close();
            return result;
        }

        public bool BeStalePassword(string id)
        {
            bool result;
            this.Open();
            result = "1" == new MySqlCommand("SELECT be_stale_password FROM user where id=" + id, this.connection).ExecuteScalar().ToString();
            this.Close();
            return result;
        }

        public bool Bind(string partial_username, object target)
        {
            bool result;
            MySqlDataReader dr;
            this.Open();
            ((target) as ListControl).Items.Clear();
            dr = new MySqlCommand("SELECT username FROM user WHERE username like \"" + partial_username + "%\" order by username", this.connection).ExecuteReader();
            while (dr.Read())
            {
                ((target) as ListControl).Items.Add(new ListItem(dr["username"].ToString(), dr["username"].ToString()));
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
            dr = new MySqlCommand("select user.id as user_id" + " , name as user_name" + " from user" + " order by user_name", this.connection).ExecuteReader();
            while (dr.Read())
            {
                ((target) as ListControl).Items.Add(new ListItem(dr["user_name"].ToString(), dr["user_id"].ToString()));
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
            BindDirectToListControl(target, "-- User --");
        }

        public void BindDirectToListControl(object target, string unselected_literal)
        {
            BindDirectToListControl(target, unselected_literal, k.EMPTY);
        }

        public void Delete(string username)
        {
            this.Open();
            new MySqlCommand(db_trail.Saved("delete from user where username = \"" + username + "\""), this.connection).ExecuteNonQuery();
            this.Close();
        }

        public bool Get
          (
          string id,
          out bool be_active,
          out bool be_ok_to_input_roster_by_batch,
          out bool be_ok_to_input_roster_by_copy
          )
          {
          be_active = false;
          be_ok_to_input_roster_by_batch = false;
          be_ok_to_input_roster_by_copy = false;
          var result = false;
          Open();
          var dr = new MySqlCommand
            (
            "select be_active"
            + " , be_ok_to_input_roster_by_batch"
            + " , be_ok_to_input_roster_by_copy"
            + " from coned_sponsor_user"
            + " where id = '" + id + "'",
            connection
            )
            .ExecuteReader();
          if (dr.Read())
            {
            be_active = (dr["be_active"].ToString() == "1");
            be_ok_to_input_roster_by_batch = (dr["be_ok_to_input_roster_by_batch"].ToString() == "1");
            be_ok_to_input_roster_by_copy = (dr["be_ok_to_input_roster_by_copy"].ToString() == "1");
            result = true;
            }
          dr.Close();
          Close();
          return result;
          }

        public string IdOf(string username)
        {
            string result;
            this.Open();
            result = new MySqlCommand("select id from user where username = \"" + username + "\"", this.connection).ExecuteScalar().ToString();
            this.Close();
            return result;
        }

        public uint NumUnsuccessfulLoginAttemptsOf(string username)
        {
            uint result;
            this.Open();
            result = uint.Parse(new MySqlCommand("select num_unsuccessful_login_attempts from user where username = \"" + username + "\"", this.connection).ExecuteScalar().ToString());
            this.Close();
            return result;
        }

        public string PasswordResetEmailAddressOfId(string id)
        {
            string result;
            this.Open();
            result = new MySqlCommand("select password_reset_email_address from user where id = " + id, this.connection).ExecuteScalar().ToString();
            this.Close();
            return result;
        }

        public string PasswordResetEmailAddressOfUsername(string username)
        {
            string result;
            this.Open();
            result = new MySqlCommand("select password_reset_email_address from user where username = \"" + username + "\"", this.connection).ExecuteScalar().ToString();
            this.Close();
            return result;
        }

        public string[] PrivilegesOf(string id)
        {
            MySqlDataReader dr;
            StringCollection privileges_of_string_collection = new StringCollection();
            this.Open();
            dr = new MySqlCommand("select distinct name" + " from user_member_map" + " join role_member_map using (member_id)" + " join role_privilege_map using (role_id)" + " join privilege on (privilege.id=role_privilege_map.privilege_id)" + " where user_id = " + id, this.connection).ExecuteReader();
            while (dr.Read())
            {
                privileges_of_string_collection.Add(dr["name"].ToString());
            }
            dr.Close();
            this.Close();
            string[] privileges_of = new string[privileges_of_string_collection.Count];
            privileges_of_string_collection.CopyTo(privileges_of,0);
            return privileges_of;
        }

        public void RecordSuccessfulLogin(string id)
        {
            this.Open();
            new MySqlCommand(db_trail.Saved("update user" + " set num_unsuccessful_login_attempts = 0" + " , last_login = NOW()" + " where id = " + id), this.connection).ExecuteNonQuery();
            this.Close();
        }

        public void RecordUnsuccessfulLoginAttempt(string username)
        {
            this.Open();
            new MySqlCommand(db_trail.Saved("update user" + " set num_unsuccessful_login_attempts = num_unsuccessful_login_attempts + 1" + " where username = \"" + username + "\""), this.connection).ExecuteNonQuery();
            this.Close();
        }

        public void RegisterNew(string username, string encoded_password, string email_address)
        {
            this.Open();
            new MySqlCommand(db_trail.Saved("insert into user" + " set username = \"" + username + "\"" + " , encoded_password_hash = SHA1('" + encoded_password + "')" + " , be_stale_password = FALSE" + " , password_reset_email_address = \"" + email_address + "\"" + " , last_login = NOW()"), this.connection).ExecuteNonQuery();
            this.Close();
        }

        public void Set
          (
          string id,
          bool be_active,
          bool be_ok_to_input_roster_by_batch,
          bool be_ok_to_input_roster_by_copy
          )
          {
          Open();
          new MySqlCommand
            (
            db_trail.Saved
              (
              "update coned_sponsor_user set be_active = " + be_active.ToString()
              + " , be_ok_to_input_roster_by_batch = " + be_ok_to_input_roster_by_batch.ToString()
              + " , be_ok_to_input_roster_by_copy = " + be_ok_to_input_roster_by_copy.ToString()
              + " where id = '" + id + "'"
              ),
            connection
            )
            .ExecuteNonQuery();
          Close();
          }

        public void SetEmailAddress(string id, string email_address)
        {
            this.Open();
            new MySqlCommand(db_trail.Saved("UPDATE user " + "SET password_reset_email_address = \"" + email_address + "\"" + "WHERE id = " + id), this.connection).ExecuteNonQuery();
            this.Close();
        }

        public void SetPassword(string id, string encoded_password)
        {
            this.Open();
            new MySqlCommand(db_trail.Saved("update user" + " set encoded_password_hash = SHA1('" + encoded_password + "')," + " be_stale_password = FALSE " + " where id = " + id), this.connection).ExecuteNonQuery();
            this.Close();
        }

        public void SetTemporaryPassword(string username, string encoded_password)
        {
            this.Open();
            new MySqlCommand(db_trail.Saved("update user" + " set encoded_password_hash = SHA1('" + encoded_password + "')," + " be_stale_password = TRUE " + " where username = \"" + username + "\""), this.connection).ExecuteNonQuery();
            this.Close();
        }

        public string UsernameOfEmailAddress(string email_address)
        {
            string result;
            this.Open();
            result = new MySqlCommand("select username from user where password_reset_email_address = \"" + email_address + "\"", this.connection).ExecuteScalar().ToString();
            this.Close();
            return result;
        }

    } // end TClass_db_coned_sponsor_users

}
