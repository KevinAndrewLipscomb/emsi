using Class_db_strike_team_deployment_member_policies;
using kix;

namespace Class_biz_strike_team_deployment_member_policies
  {

  public class TClass_biz_strike_team_deployment_member_policies
    {

    private TClass_db_strike_team_deployment_member_policies db_strike_team_deployment_member_policies = null;

    public TClass_biz_strike_team_deployment_member_policies() : base()
      {
      db_strike_team_deployment_member_policies = new TClass_db_strike_team_deployment_member_policies();
      }

    public bool Bind(string partial_code, object target)
      {
      return db_strike_team_deployment_member_policies.Bind(partial_code, target);
      }

    public void BindDirectToListControl(object target, string unselected_literal, string selected_value)
      {
      db_strike_team_deployment_member_policies.BindDirectToListControl(target, unselected_literal, selected_value);
      }

    public void BindDirectToListControl(object target)
      {
      BindDirectToListControl(target, "-- strike_team_deployment_member_policy --");
      }

    public void BindDirectToListControl(object target, string unselected_literal)
      {
      BindDirectToListControl(target, unselected_literal, k.EMPTY);
      }

    public bool Delete(string code)
      {
      return db_strike_team_deployment_member_policies.Delete(code);
      }

    internal string DescriptionOf(string id)
      {
      return db_strike_team_deployment_member_policies.DescriptionOf(id);
      }

    public bool Get(string code, out string description)
      {
      return db_strike_team_deployment_member_policies.Get(code, out description);
      }

    public void Set(string code, string description)
      {
      db_strike_team_deployment_member_policies.Set(code, description);
      }

    } // end TClass_biz_strike_team_deployment_member_policies

  }