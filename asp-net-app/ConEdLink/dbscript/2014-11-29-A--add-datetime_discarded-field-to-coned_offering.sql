START TRANSACTION
;
ALTER TABLE `coned_offering` ADD COLUMN `datetime_discarded` DATETIME NULL
;
ALTER TABLE `coned_offering` ADD INDEX `datetime_discarded` (`datetime_discarded` ASC)
;
COMMIT