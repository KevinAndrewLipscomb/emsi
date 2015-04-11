START TRANSACTION
;
UPDATE `region_code_name_map` SET `be_pacrat_subscriber`='1' WHERE name not like '(RC%)'
;
COMMIT