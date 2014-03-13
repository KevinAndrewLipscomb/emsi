START TRANSACTION
;
ALTER TABLE `practitioner`
  ADD COLUMN `be_practitioner` TINYINT(1) NOT NULL DEFAULT TRUE
,
  RENAME TO  `associate`
;
CREATE OR REPLACE VIEW practitioner AS select * from associate where be_practitioner
;
ALTER TABLE `practitioner_level`
  CHANGE COLUMN `emsrs_practitioner_level_description` `emsrs_practitioner_level_description` VARCHAR(31) NULL
,
  CHANGE COLUMN `emsrs_code` `emsrs_code` TINYINT(3) UNSIGNED NULL
;
insert ignore practitioner_level
set short_description = '[Associate]'
, pecking_order = 0
;
COMMIT