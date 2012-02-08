START TRANSACTION
;
ALTER TABLE `coned_offering_roster`
  DROP FOREIGN KEY `coned_offering_roster_coned_offering_class_id`
;
update coned_offering_roster
  join coned_offering on (coned_offering.class_id=coned_offering_roster.coned_offering_class_id)
set coned_offering_class_id = coned_offering.id
;
ALTER TABLE `coned_offering_roster`
  CHANGE COLUMN `coned_offering_class_id` `coned_offering_id` BIGINT(20) UNSIGNED NOT NULL
,
  ADD CONSTRAINT `coned_offering_roster_coned_offering_id` FOREIGN KEY (`coned_offering_id` ) REFERENCES `coned_offering` (`id` )
,
  DROP INDEX `coned_offering_class_id`
,
  ADD UNIQUE INDEX `coned_offering_id` (`coned_offering_id` ASC, `practitioner_id` ASC)
;
ALTER TABLE `coned_offering` DROP FOREIGN KEY `coned_offering_document_status`
;
ALTER TABLE `coned_offering`
  CHANGE COLUMN `class_id` `class_id` BIGINT(20) UNSIGNED NULL
,
  CHANGE COLUMN `course_id` `course_id` BIGINT(20) UNSIGNED NULL
,
  CHANGE COLUMN `created_by` `created_by` BIGINT(20) UNSIGNED NULL
,
  CHANGE COLUMN `date_created` `date_created` DATE NULL
,
  CHANGE COLUMN `last_edited_by` `last_edited_by` BIGINT(20) UNSIGNED NULL
,
  CHANGE COLUMN `date_last_edited` `date_last_edited` DATE NULL
,
  CHANGE COLUMN `document_status` `document_status` BIGINT(20) UNSIGNED NULL
,
  CHANGE COLUMN `end_date_time` `end_date_time` DATE NULL
,
  CHANGE COLUMN `created_by_first_name` `created_by_first_name` VARCHAR(31) NULL
,
  CHANGE COLUMN `created_by_last_name` `created_by_last_name` VARCHAR(31) NULL
,
  CHANGE COLUMN `courses_course_number` `courses_course_number` CHAR(6) NULL
,
  ADD CONSTRAINT `coned_offering_document_status` FOREIGN KEY (`document_status` ) REFERENCES `coned_offering_document_status` (`id` )
;
COMMIT