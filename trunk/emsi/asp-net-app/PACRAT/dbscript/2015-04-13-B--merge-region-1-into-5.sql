START TRANSACTION
;
update county_region_map
set region_code = (select code from region_code_name_map where name = 'Northeastern')
where region_code = (select code from region_code_name_map where name = 'Bradford Susquehanna')
;
ALTER TABLE `region_code_name_map` 
  ADD COLUMN `be_active` BOOLEAN NOT NULL DEFAULT TRUE
;
update region_code_name_map
set be_active = FALSE
where name like '(RC%)'
  or name in ('Susquehanna','Bradford Susquehanna')
;
update region_code_name_map
set be_pacrat_subscriber = FALSE
where not be_active
;
COMMIT