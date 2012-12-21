START TRANSACTION
;
insert ignore practitioner_status (description) values
  ("Incomplete")
,
  ("Do Not Certify and Expired")
,
  ("Probation")
,
  ("Denied")
,
  ("Deceased")
,
  ("Deceased - LODD")
,
  ("SSA")
;
ALTER TABLE `practitioner_level`
  CHANGE COLUMN `econed_description` `econed_description` VARCHAR(31) NULL
;
UPDATE `practitioner_level` SET
  `short_description`='EMR'
,
  `emsrs_practitioner_level_description`='EMR'
WHERE `id`='1'
;
insert ignore practitioner_level (short_description,emsrs_practitioner_level_description,pecking_order,emsrs_code) values
("EMT-New","EMT-New Curriculum",43,6),
("Rescue","Rescue",200,8)
;
COMMIT