using Class_db_genders;
using kix;

namespace Class_biz_genders
  {

  public class TClass_biz_genders
    {

    private TClass_db_genders db_genders = null;

    public TClass_biz_genders() : base()
      {
      db_genders = new TClass_db_genders();
      }

    public bool Bind(string partial_code, object target)
      {
      return db_genders.Bind(partial_code, target);
      }

    public void BindDirectToListControl(object target, string unselected_literal, string selected_value)
      {
      db_genders.BindDirectToListControl(target, unselected_literal, selected_value);
      }

    public void BindDirectToListControl(object target)
      {
      BindDirectToListControl(target, "-- gender --");
      }

    public void BindDirectToListControl(object target, string unselected_literal)
      {
      BindDirectToListControl(target, unselected_literal, k.EMPTY);
      }

    public bool Delete(string code)
      {
      return db_genders.Delete(code);
      }

    public bool Get(string code, out string description)
      {
      return db_genders.Get(code, out description);
      }

    public void Set(string code, string description)
      {
      db_genders.Set(code, description);
      }

    } // end TClass_biz_genders

  }