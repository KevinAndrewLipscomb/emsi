START TRANSACTION
;
ALTER TABLE `associate` CHANGE COLUMN `certification_number` `certification_number` VARCHAR(7) NULL DEFAULT NULL ;
;
COMMIT
