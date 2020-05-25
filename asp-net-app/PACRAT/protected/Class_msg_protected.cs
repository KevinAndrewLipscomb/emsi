using kix;

namespace Class_msg_protected
  {

  internal enum underway_demobilization_mode_enum
    {
    MEMBER,
    VEHICLE
    };

  public class TClass_msg_protected
    {
    internal class add_associate
      {
      internal string tier_name = k.EMPTY;
      internal string association_id = k.EMPTY;
      internal string association_name = k.EMPTY;
      }
    internal class mobilization_announcement
      {
      internal object deployment_summary;
      }
    internal class operational_period_detail
      {
      internal string deployment_id = k.EMPTY;
      internal string operational_period_id = k.EMPTY;
      internal string service_strike_team_management_footprint = k.EMPTY;
      internal bool be_unlimited = false;
      internal bool be_more_than_examiner = false;
      }
    internal class overview
      {
      internal string target = k.EMPTY;
      }
    internal class practitioner_management
      {
      internal object summary = null;
      internal bool be_more_than_examiner = false;
      }
    internal class practitioner_profile
      {
      internal string id = k.EMPTY;
      }
    internal class region_detail
      {
      internal object summary = null;
      }
    internal class region_management
      {
      internal object summary = null;
      internal bool be_more_than_examiner = false;
      }
    internal class service_management
      {
      internal string region_code = k.EMPTY;
      internal object summary = null;
      internal bool be_more_than_examiner = false;
      }
    internal class strike_team_deployment_detail
      {
      internal string id = k.EMPTY;
      internal bool be_more_than_examiner = false;
      internal bool be_ok_to_see_all_strike_team_data = false;
      }
    internal class underway_demobilization
      {
      internal string deployment_id = k.EMPTY;
      internal underway_demobilization_mode_enum mode = underway_demobilization_mode_enum.MEMBER;
      internal string mobilization_id = k.EMPTY;
      internal string asset_designator = k.EMPTY;
      }
    internal class vehicle_detail
      {
      internal string id = k.EMPTY;
      internal string service_id = k.EMPTY;
      }
    internal class vehicle_management
      {
      internal object summary = null;
      }
    }

  }