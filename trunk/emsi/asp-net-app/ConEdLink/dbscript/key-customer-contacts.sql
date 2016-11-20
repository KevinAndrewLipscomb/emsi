select region_code_name_map.name
, last_name
, first_name
, password_reset_email_address
from region_code_name_map
  join regional_staffer on (regional_staffer.region_code=region_code_name_map.code)
  join regional_staffer_user on (regional_staffer_user.id=regional_staffer.id)
  join regional_staffer_role on (regional_staffer_role.user_id=regional_staffer.id)
  join regional_staffer_group on (regional_staffer_group.id=regional_staffer_role.group_id)
where be_extant and be_conedlink_subscriber
  and be_active
  and regional_staffer_group.name in ('director','education-coordinator','education-specialist')
order by region_code_name_map.code