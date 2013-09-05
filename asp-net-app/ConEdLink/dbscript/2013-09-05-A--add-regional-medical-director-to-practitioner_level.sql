START TRANSACTION
;
insert ignore practitioner_level (short_description,emsrs_practitioner_level_description,pecking_order,emsrs_code) values
("RMD","Regional Med Dir",180,5)
;
COMMIT