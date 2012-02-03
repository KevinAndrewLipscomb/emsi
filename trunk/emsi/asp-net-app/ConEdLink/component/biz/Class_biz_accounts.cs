using Class_biz_counties;
using Class_biz_user;
using Class_db_accounts;
using System.Configuration;

namespace Class_biz_accounts
{
    public class TClass_biz_accounts
    {
        private TClass_biz_counties biz_counties = null;
        private TClass_biz_user biz_user = null;
        private TClass_db_accounts db_accounts = null;

        public TClass_biz_accounts() : base()
        {
            // TODO: Add any constructor code here
            biz_counties = new TClass_biz_counties();
            biz_user = new TClass_biz_user();
            db_accounts = new TClass_db_accounts();
        }

        public bool BeStalePassword(string user_kind, string user_id)
        {
            bool result;
            result = db_accounts.BeStalePassword(user_kind, user_id);
            return result;
        }

        public bool BeValidSysAdminCredentials(string encoded_password)
        {
            bool result;
            result = (encoded_password == ConfigurationManager.AppSettings["sysadmin_encoded_password"]);
            return result;
        }

        internal void BindConedSponsorsInRegion
          (
          string region_code,
          object target
          )
          {
          db_accounts.BindConedSponsorsInRegion(region_code,target);
          }

        public void BindCountiesInRegion
          (
          string region_code,
          object target
          )
          {
          db_accounts.BindCountiesInRegion(region_code,target);
          }

        public void BindRegionalStaffersInRegion
          (
          string region_code,
          object target
          )
          {
          db_accounts.BindRegionalStaffersInRegion(region_code,target);
          }

        public void BindServicesInRegion
          (
          string region_code,
          object target
          )
          {
          db_accounts.BindServicesInRegion(region_code,target);
          }

        public string EmailAddressByKindId(string user_kind, string user_id)
        {
            string result;
            result = db_accounts.EmailAddressByKindId(user_kind, user_id);
            return result;
        }

        public string EmailTargetByRole(string role)
        {
            string result;
            result = db_accounts.EmailTargetByRole(role);
            return result;
        }

        public bool Exists(string user_kind, string user_id, string encoded_password)
        {
            bool result;
            result = db_accounts.Exists(user_kind, user_id, encoded_password);
            return result;
        }

        private string SelfEmailAddress()
        {
            string result;
            result = EmailAddressByKindId(biz_user.Kind(), biz_user.IdNum());
            return result;
        }

        internal void SetPasswordResetEmailAddress
          (
          string kind,
          string id,
          string value
          )
          {
          db_accounts.SetPasswordResetEmailAddress(kind,id,value);
          }

        public void SetTemporaryPassword(string user_kind, string user_id, string encoded_password)
        {
            db_accounts.SetTemporaryPassword(user_kind, user_id, encoded_password);
        }

    } // end TClass_biz_accounts

}
