START TRANSACTION
;
update coned_offering set class_id = null
;
ALTER TABLE `coned_offering`
  CHANGE COLUMN `region_comments` `region_comments` TEXT NULL DEFAULT NULL
,
  ADD COLUMN `length` DECIMAL(5,1) UNSIGNED NULL DEFAULT NULL
;
COMMIT