START TRANSACTION
;
update county_region_map
set region_code = 1
where region_code = 19
;
COMMIT
