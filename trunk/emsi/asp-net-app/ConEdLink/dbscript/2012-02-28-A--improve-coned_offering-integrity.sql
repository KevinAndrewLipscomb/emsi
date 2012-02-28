START TRANSACTION
;
update coned_offering c
set sponsor_id = (select emsrs_id from teaching_entity where REPLACE(sponsor_number,'-','') = c.sponsor_number)
where sponsor_id is null
;
ALTER TABLE `coned_offering`
  DROP INDEX `id`
,
  CHANGE COLUMN `sponsor_id` `sponsor_id` BIGINT(20) UNSIGNED NOT NULL
,
  ADD INDEX `sponsor_id` (`sponsor_id` ASC)
,
  ADD CONSTRAINT `coned_offering_sponsor_id` FOREIGN KEY (`sponsor_id` ) REFERENCES `teaching_entity` (`emsrs_id` )
;
COMMIT