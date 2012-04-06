START TRANSACTION
;
ALTER TABLE `region_code_name_map`
  ADD COLUMN `be_conedlink_subscriber` TINYINT NOT NULL DEFAULT 0
,
  ADD INDEX `be_conedlink_subscriber` (`be_conedlink_subscriber` ASC)
;
update region_code_name_map set be_conedlink_subscriber = TRUE where name = "EMSI"
;
COMMIT