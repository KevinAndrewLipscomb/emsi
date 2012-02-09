START TRANSACTION
;
ALTER TABLE `coned_offering`
  CHANGE COLUMN `public_contact_website` `public_contact_website` VARCHAR(255) NULL DEFAULT NULL
;
COMMIT