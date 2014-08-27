select service.short_name
, IF(sum( birth_date is null or DATE_ADD(birth_date,INTERVAL 18 YEAR) > CURDATE() ) = 0,'YES','no') as a1
, IF(sum( pecking_order < (select pecking_order from practitioner_level where short_description = 'EMT') ) = 0,'YES','no') as a2
, IF(sum( not be_immune_hepatitis_b ) = 0,'YES','no') as b1
, IF(sum( not be_immune_diptheria_tetanus ) = 0,'YES','no') as b2
, IF(sum( act_1985_33_date is null or act_1985_33_date < DATE_SUB(CURDATE(),INTERVAL 3 YEAR) ) = 0,'YES','no') as c1
, IF(sum( act_1985_34_date is null or act_1985_34_date < DATE_SUB(CURDATE(),INTERVAL 3 YEAR) ) = 0,'YES','no') as c2
, IF(sum( act_1994_151_date is null or act_1994_151_date < DATE_SUB(CURDATE(),INTERVAL 3 YEAR) ) = 0,'YES','no') as c3
, IF(sum( nims_is_100_date is null or nims_is_100_date = '0001-01-01' ) = 0,'YES','no') as d1
, IF(sum( nims_is_200_date is null or nims_is_200_date = '0001-01-01' ) = 0,'YES','no') as d2
, IF(sum( nims_is_700_date is null or nims_is_700_date = '0001-01-01' ) = 0,'YES','no') as d3
, IF(sum( nims_is_800_date is null or nims_is_800_date = '0001-01-01' ) = 0,'YES','no') as d4
, IF(sum( lms_disaster_stress_response_date is null or lms_disaster_stress_response_date = '0001-01-01' ) = 0,'YES','no') as d5
, IF(sum( lms_ems_mci_ops_date is null or lms_ems_mci_ops_date = '0001-01-01' ) = 0,'YES','no') as d6
, IF(sum( lms_wmd_date is null or lms_wmd_date = '0001-01-01' ) = 0,'YES','no') as d7
, IF(sum( lms_smallpox_date is null or lms_smallpox_date = '0001-01-01' ) = 0,'YES','no') as d8
, IF(sum( lms_basic_med_terrorism_response_date is null or lms_basic_med_terrorism_response_date = '0001-01-01' ) = 0,'YES','no') as d9
, IF(sum( lms_electrical_hazards_date is null or lms_electrical_hazards_date = '0001-01-01' ) = 0,'YES','no') as d10
, IF(sum( lms_ems_bioterror_date is null or lms_ems_bioterror_date = '0001-01-01' ) = 0,'YES','no') as d11
, IF(sum( pa_water_rescue_awareness_date is null or pa_water_rescue_awareness_date = '0001-01-01' ) = 0,'YES','no') as d12
, IF(sum( pa_hazmat_awareness_date is null or pa_hazmat_awareness_date = '0001-01-01' ) = 0,'YES','no') as d13
from strike_team_roster
  join practitioner on (practitioner.id=strike_team_roster.practitioner_id)
  join practitioner_level on (practitioner_level.id=practitioner.level_id)
  left join practitioner_strike_team_detail using (practitioner_id)
  join service on (service.id=strike_team_roster.service_id)
group by service.id
order by service.short_name