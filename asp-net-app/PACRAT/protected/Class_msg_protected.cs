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
    public class mobilization_announcement
      {
      internal object deployment_summary;
      }
    public class operational_period_detail
      {
      internal string deployment_id = k.EMPTY;
      internal string operational_period_id = k.EMPTY;
      }
    public class overview
      {
      internal string target = k.EMPTY;
      }
    public class practitioner_management
      {
      internal object summary = null;
      }
    public class practitioner_profile
      {
      internal string id = k.EMPTY;
      }
    public class region_detail
      {
      internal object summary = null;
      }
    public class region_management
      {
      internal object summary = null;
      }
    public class service_management
      {
      internal string region_code = k.EMPTY;
      internal object summary = null;
      }
    public class strike_team_deployment_detail
      {
      internal string id = k.EMPTY;
      }
    public class underway_demobilization
      {
      internal string deployment_id = k.EMPTY;
      internal underway_demobilization_mode_enum mode = underway_demobilization_mode_enum.MEMBER;
      internal string mobilization_id = k.EMPTY;
      internal string asset_designator = k.EMPTY;
      }
    public class vehicle_detail
      {
      internal string id = k.EMPTY;
      internal string service_id = k.EMPTY;
      }
    public class vehicle_management
      {
      internal object summary = null;
      }
    }

  }