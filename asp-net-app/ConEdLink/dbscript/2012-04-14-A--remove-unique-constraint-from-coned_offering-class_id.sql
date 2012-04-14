START TRANSACTION
;
ALTER TABLE `coned_offering`
  DROP INDEX `class_id`
,
  CHANGE COLUMN `course_number` `course_number` CHAR(6) NULL
;
COMMIT