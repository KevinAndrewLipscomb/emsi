using Class_db_counties;
using kix;

namespace Class_biz_counties
{
    public class TClass_biz_counties
    {
        private TClass_db_counties db_counties = null;
        //Constructor  Create()
        public TClass_biz_counties() : base()
        {
            // TODO: Add any constructor code here
            db_counties = new TClass_db_counties();
        }
        public void BindDirectToListControl(object target, string unselected_literal, string selected_value)
        {
            db_counties.BindDirectToListControl(target, unselected_literal, selected_value);
        }

        public void BindDirectToListControl(object target)
        {
            BindDirectToListControl(target, "-- County --");
        }

        public void BindDirectToListControl(object target, string unselected_literal)
        {
            BindDirectToListControl(target, unselected_literal, k.EMPTY);
        }

        public void BindGrid
          (
          string sort_order,
          bool be_sort_order_ascending,
          object target
          )
          {
          db_counties.BindGrid(sort_order,be_sort_order_ascending,target);
          }

        internal string CodeOfSummary(object summary)
          {
          return db_counties.CodeOfSummary(summary);
          }

        internal string DefaultMatchLevelIdOfCode(string code)
          {
          return db_counties.DefaultMatchLevelIdOfCode(code);
          }

        internal string DefaultMatchLevelIdOfSummary(object summary)
          {
          return db_counties.DefaultMatchLevelIdOfSummary(summary);
          }

        internal string EmailAddressOfSummary(object summary)
          {
          return db_counties.EmailAddressOfSummary(summary);
          }

        public string NameOf(string code)
        {
            string result;
            result = db_counties.NameOf(code);
            return result;
        }

        internal string NameOfSummary(object summary)
          {
          return db_counties.NameOfSummary(summary);
          }

        internal void Set
          (
          string code,
          string email_address,
          string default_match_level_id
          )
          {
          db_counties.Set(code,email_address,default_match_level_id);
          }

        public object Summary(string code)
          {
          return db_counties.Summary(code);
          }

    } // end TClass_biz_counties

}
