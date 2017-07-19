START TRANSACTION
;
UPDATE `region_code_name_map`
SET `emsrs_active_practitioners_name` = 'EMS West'
WHERE `code`='1'
;
COMMIT
