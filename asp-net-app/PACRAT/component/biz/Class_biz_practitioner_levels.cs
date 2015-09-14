using Class_db_practitioner_levels;
using kix;

namespace Class_biz_practitioner_levels
  {

    public class TClass_biz_practitioner_levels
    {

        private TClass_db_practitioner_levels db_practitioner_levels = null;

        public TClass_biz_practitioner_levels() : base()
        {
            db_practitioner_levels = new TClass_db_practitioner_levels();
        }

        public bool Bind(string partial_code, object target)
        {
            bool result;
            result = db_practitioner_levels.Bind(partial_code, target);
            return result;
        }

    public void BindDirectToListControl
      (
      object target,
      string unselected_literal = "-- practitioner level --",
      string selected_value = k.EMPTY,
      bool be_short_description_desired = false
      )
      {
      db_practitioner_levels.BindDirectToListControl(target,unselected_literal,selected_value,be_short_description_desired);
      }

        public bool Delete(string code)
        {
            bool result;
            result = db_practitioner_levels.Delete(code);
            return result;
        }

        public bool Get(string code, out string description)
        {
            bool result;
            result = db_practitioner_levels.Get(code, out description);

            return result;
        }

        public void Set(string code, string description)
        {
            db_practitioner_levels.Set(code, description);

        }

    } // end TClass_biz_practitioner_levels

  }
