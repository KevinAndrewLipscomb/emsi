START TRANSACTION
;
ALTER TABLE `role_member_map`
  ADD COLUMN `region_code` TINYINT UNSIGNED NULL
,
  ADD COLUMN `service_id` SMALLINT UNSIGNED NULL
,
  ADD INDEX `region_code` (`region_code` ASC)
,
  ADD INDEX `service_id` (`service_id` ASC)
,
  ADD CONSTRAINT `role_member_map_region_code` FOREIGN KEY (`region_code` ) REFERENCES `region_code_name_map` (`code` )
, 
  ADD CONSTRAINT `role_member_map_service_id` FOREIGN KEY (`service_id` ) REFERENCES `service` (`id` )
;
COMMIT

