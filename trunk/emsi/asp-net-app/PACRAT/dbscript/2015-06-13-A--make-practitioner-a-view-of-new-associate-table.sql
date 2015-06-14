START TRANSACTION
;
ALTER TABLE `practitioner` 
  DROP FOREIGN KEY `practitioner_level_id`;
;
ALTER TABLE `practitioner`
  CHANGE COLUMN `level_id` `level_id` BIGINT(20) UNSIGNED NULL
,
  CHANGE COLUMN `certification_number` `certification_number` CHAR(6) NULL
,
  ADD COLUMN `be_practitioner` TINYINT(1) NOT NULL DEFAULT TRUE
,
  ADD COLUMN `registration_code` VARCHAR(15) NULL
,
  ADD UNIQUE INDEX `registration_code` (`registration_code` ASC)
,
  RENAME TO  `associate`
;
ALTER TABLE `associate`
  ADD CONSTRAINT `practitioner_level_id` FOREIGN KEY (`level_id`) REFERENCES `practitioner_level` (`id`)
;
CREATE OR REPLACE VIEW practitioner AS
select *
from associate
where be_practitioner
  and level_id is not null
  and certification_number is not null
with check option
;
drop view if exists member
;
create or replace view member as
select *
from associate
;
COMMIT