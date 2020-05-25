using Class_db_eval_summary_modes;
using kix;

namespace Class_biz_eval_summary_modes
  {

  public class TClass_biz_eval_summary_modes
    {

    private readonly TClass_db_eval_summary_modes db_eval_summary_modes = null;

    public TClass_biz_eval_summary_modes() : base()
      {
      db_eval_summary_modes = new TClass_db_eval_summary_modes();
      }

    public bool Bind(string partial_code, object target)
      {
      return db_eval_summary_modes.Bind(partial_code, target);
      }

    public void BindDirectToListControl(object target, string unselected_literal, string selected_value)
      {
      db_eval_summary_modes.BindDirectToListControl(target, unselected_literal, selected_value);
      }

    public void BindDirectToListControl(object target)
      {
      BindDirectToListControl(target, "-- eval_summary_mode --");
      }

    public void BindDirectToListControl(object target, string unselected_literal)
      {
      BindDirectToListControl(target, unselected_literal, k.EMPTY);
      }

    public void BindRadioButtonList(object target)
      {
      db_eval_summary_modes.BindRadioButtonList(target);
      }

    public bool Delete(string code)
      {
      return db_eval_summary_modes.Delete(code);
      }

    public bool Get(string code, out string description)
      {
      return db_eval_summary_modes.Get(code, out description);
      }

    public void Set(string code, string description)
      {
      db_eval_summary_modes.Set(code, description);
      }

    } // end TClass_biz_eval_summary_modes

  }