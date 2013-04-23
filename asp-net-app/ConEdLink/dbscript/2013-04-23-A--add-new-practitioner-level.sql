START TRANSACTION
;
ALTER TABLE `practitioner_level` 
  DROP INDEX `emsrs_code` 
,
  ADD INDEX `emsrs_code` (`emsrs_code` ASC)
;
insert ignore practitioner_level (short_description,emsrs_practitioner_level_description,pecking_order,emsrs_code) values
("MCMD","MC Physician",110,5)
;
COMMIT