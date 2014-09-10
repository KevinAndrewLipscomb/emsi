select sum(region_code_name_map.name = 'EMSI')
, count(*)
, sum(region_code_name_map.name = 'EMSI')/count(*)*100
from practitioner
  join practitioner_level on (practitioner_level.id=practitioner.level_id)
  join practitioner_status on (practitioner_status.id=practitioner.status_id)
  join region_code_name_map on (region_code_name_map.code=practitioner.regional_council_code)
where short_description in ('AEMT','PHRN','EMT-P','PHPE','HP')
  and not be_stale
  and expiration_date >= CURDATE()
  and practitioner_status.description in ('Active','Probation')
  and not be_past