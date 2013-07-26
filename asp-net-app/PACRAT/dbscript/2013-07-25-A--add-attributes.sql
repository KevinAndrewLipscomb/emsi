START TRANSACTION
;
DROP TABLE IF EXISTS patient_care_level
;
CREATE TABLE IF NOT EXISTS patient_care_level (
  id SERIAL,
  description VARCHAR(7) NOT NULL,
  pecking_order TINYINT UNSIGNED NOT NULL,
  PRIMARY KEY(id),
  UNIQUE (description),
  UNIQUE (pecking_order)
)
ENGINE = InnoDB;
;
insert ignore patient_care_level (description,pecking_order) values
("---",0),
("BLS",75),
("ALS",150)
;
ALTER TABLE `strike_team_deployment_assignment`
  DROP INDEX `id`
;
ALTER TABLE `strike_team_deployment_vehicle`
  ADD COLUMN `tactical_name` VARCHAR(63)
,
  ADD COLUMN `transponder_name` VARCHAR(31)
,
  DROP INDEX `id`
,
  DROP INDEX `strike_team_deployment_vehicle_deployment_id` 
,
  ADD UNIQUE INDEX deployment_vehicle (`deployment_id` ASC, `vehicle_id` ASC)
,
  ADD UNIQUE INDEX deployment_tactical_name (`deployment_id` ASC, tactical_name)
,
  ADD UNIQUE INDEX deployment_transponder_name (`deployment_id` ASC, transponder_name)
;
ALTER TABLE vehicle
  ADD COLUMN `patient_care_level_id` BIGINT UNSIGNED NOT NULL DEFAULT 1
,
  ADD INDEX `patient_care_level_id` (`patient_care_level_id` ASC)
,
  ADD CONSTRAINT vehicle_patient_care_level_id FOREIGN KEY (patient_care_level_id) REFERENCES patient_care_level (id)
;
update vehicle
  join vehicle_kind on (vehicle_kind.id=vehicle.kind_id)
set patient_care_level_id = (select id from patient_care_level where description = 'ALS')
where vehicle_kind.description = "Ambulance"
;
ALTER TABLE `strike_team_deployment_member`
  ADD COLUMN `tag_num` SMALLINT UNSIGNED
,
  DROP INDEX `id`
,
  DROP INDEX `strike_team_deployment_member_deployment_id` 
,
  ADD UNIQUE INDEX `deployment_practitioner` (`deployment_id` ASC, `practitioner_id` ASC) 
,
  ADD UNIQUE INDEX `deployment_tag_num` (`deployment_id` ASC, tag_num) 
;
COMMIT
