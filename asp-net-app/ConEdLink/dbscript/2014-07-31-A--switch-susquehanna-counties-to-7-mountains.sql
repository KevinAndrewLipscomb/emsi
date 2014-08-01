START TRANSACTION
;
update county_region_map
set region_code = (select code from region_code_name_map where name = 'Seven Mountains')
where region_code = (select code from region_code_name_map where name = 'Susquehanna')
;
COMMIT