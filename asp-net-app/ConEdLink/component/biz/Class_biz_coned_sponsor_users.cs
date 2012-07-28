using Class_biz_notifications;
using Class_biz_user;
using Class_db_members;
using Class_db_coned_sponsor_users;
using kix;
using System;
using System.Configuration;

namespace Class_biz_coned_sponsor_users
{
    public class TClass_biz_coned_sponsor_users
    {
        private TClass_db_members db_members = null;
        private TClass_db_coned_sponsor_users db_coned_sponsor_users = null;
        private TClass_biz_notifications biz_notifications = null;
        //Constructor  Create()
        public TClass_biz_coned_sponsor_users() : base()
        {
            // TODO: Add any constructor code here
            biz_notifications = new TClass_biz_notifications();
            db_members = new TClass_db_members();
            db_coned_sponsor_users = new TClass_db_coned_sponsor_users();
        }

        public bool AcceptAsMember
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
          return db_coned_sponsor_users.AcceptAsMember(certification_number,level_id,(expiration_date == DateTime.MinValue ? new DateTime(2099,12,31) : expiration_date),regional_council_code,birth_date,gender_id,id);
          }

        public bool BeAuthorized(string username, string encoded_password)
        {
            bool result;
            result = db_coned_sponsor_users.BeAuthorized(username, encoded_password);
            return result;
        }

        public bool BeAuthorizedSysAdmin(string encoded_password)
        {
            bool result;
            result = (encoded_password == ConfigurationManager.AppSettings["sysadmin_encoded_password"]);
            return result;
        }

        public bool BeRegisteredEmailAddress(string email_address)
        {
            bool result;
            result = db_coned_sponsor_users.BeRegisteredEmailAddress(email_address);
            return result;
        }

        public bool BeRegisteredUsername(string username)
        {
            bool result;
            result = db_coned_sponsor_users.BeRegisteredUsername(username);
            return result;
        }

        public bool BeStalePassword(string id)
        {
            bool result;
            result = db_coned_sponsor_users.BeStalePassword(id);
            return result;
        }

        public bool Bind(string partial_username, object target)
        {
            bool result;
            result = db_coned_sponsor_users.Bind(partial_username, target);
            return result;
        }

        public void BindDirectToListControl(object target, string unselected_literal, string selected_value)
        {
            db_coned_sponsor_users.BindDirectToListControl(target, unselected_literal, selected_value);
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
            db_coned_sponsor_users.Delete(username);
        }

        public bool Get
          (
          string id,
          out bool be_active,
          out bool be_ok_to_input_roster_by_batch,
          out bool be_ok_to_input_roster_by_copy
          )
          {
          return db_coned_sponsor_users.Get(id, out be_active, out be_ok_to_input_roster_by_batch, out be_ok_to_input_roster_by_copy);
          }

        public string IdOf(string username)
        {
            string result;
            result = db_coned_sponsor_users.IdOf(username);
            return result;
        }

        public void IssueTemporaryPassword(string username, string client_host_name)
        {
            string temporary_password;
            // Build a suitably-random password string.
            temporary_password = System.Guid.NewGuid().ToString().Substring(0, int.Parse(ConfigurationManager.AppSettings["temp_password_len"]));
            // Make the password string the user's new temporary password, and set the stale flag to force an immediate password change.
            db_coned_sponsor_users.SetTemporaryPassword(username, k.Digest(temporary_password));
            // Send the new password to the user's email address of record.
            biz_notifications.IssueForTemporaryPassword(username, client_host_name, temporary_password);
        }

        public void IssueUsernameReminder(string email_address, string client_host_name)
        {
            biz_notifications.IssueForForgottenUsername(email_address, db_coned_sponsor_users.UsernameOfEmailAddress(email_address), client_host_name);
        }

        public uint NumUnsuccessfulLoginAttemptsOf(string username)
        {
            uint result;
            result = db_coned_sponsor_users.NumUnsuccessfulLoginAttemptsOf(username);
            return result;
        }

        public string PasswordResetEmailAddressOfId(string id)
        {
            string result;
            result = db_coned_sponsor_users.PasswordResetEmailAddressOfId(id);
            return result;
        }

        public string PasswordResetEmailAddressOfUsername(string username)
        {
            string result;
            result = db_coned_sponsor_users.PasswordResetEmailAddressOfUsername(username);
            return result;
        }

        public string[] PrivilegesOf(string id)
        {
            string[] result;
            result = db_coned_sponsor_users.PrivilegesOf(id);
            return result;
        }

        public void RecordSuccessfulLogin(string id)
        {
            db_coned_sponsor_users.RecordSuccessfulLogin(id);
        }

        public void RecordUnsuccessfulLoginAttempt(string username)
        {
            db_coned_sponsor_users.RecordUnsuccessfulLoginAttempt(username);
        }

        public void RegisterNew(string username, string encoded_password, string email_address)
        {
            db_coned_sponsor_users.RegisterNew(username, encoded_password, email_address);
        }

        public string SelfEmailAddress()
        {
            string result;
            result = PasswordResetEmailAddressOfId(new TClass_biz_user().IdNum());
            return result;
        }

        public void Set
          (
          string id,
          bool be_active,
          bool be_ok_to_input_roster_by_batch,
          bool be_ok_to_input_roster_by_copy
          )
          {
          db_coned_sponsor_users.Set(id,be_active,be_ok_to_input_roster_by_batch,be_ok_to_input_roster_by_copy);
          }

        public void SetEmailAddress(string id, string email_address)
        {
            db_coned_sponsor_users.SetEmailAddress(id, email_address);
            db_members.SetEmailAddress(db_members.IdOfUserId(id), email_address);
        }

        public void SetPassword(string id, string encoded_password)
        {
            db_coned_sponsor_users.SetPassword(id, encoded_password);
        }

    } // end TClass_biz_coned_sponsor_users

}
