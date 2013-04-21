START TRANSACTION
;
ALTER TABLE `region_code_name_map`
  ADD COLUMN `be_pacrat_subscriber` BOOLEAN NOT NULL DEFAULT FALSE  AFTER `be_conedLink_subscriber`
;
update region_code_name_map set be_pacrat_subscriber = TRUE where name = "EMSI"
;
COMMIT