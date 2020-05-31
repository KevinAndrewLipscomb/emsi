using Class_db_tiers;
using kix;

namespace Class_biz_tiers
  {
  public class TClass_biz_tiers
    {
        private readonly TClass_db_tiers db_tiers = null;

        //Constructor  Create()
        public TClass_biz_tiers() : base()
        {
            // TODO: Add any constructor code here
            db_tiers = new TClass_db_tiers();
        }

    public void BindListControl
      (
      #pragma warning disable CA1801 // Remove unused parameter
      object target,
      string selected_id = k.EMPTY,
      bool be_available_option_all = true,
      string unselected_literal = "All"
      #pragma warning restore CA1801 // Remove unused parameter
      )
      {
      db_tiers.BindListControl(target, unselected_literal, selected_id);
      }

        public string IdOfName(string name)
        {
            string result;
            result = db_tiers.IdOfName(name);
            return result;
        }

        public string NameOfId(string id)
        {
            string result;
            result = db_tiers.NameOfId(id);
            return result;
        }

    } // end TClass_biz_tiers

}
