START TRANSACTION
;
ALTER TABLE `strike_team_deployment_operational_period`
  CHANGE COLUMN `start` `start` DATETIME NULL
,
  CHANGE COLUMN `end` `end` DATETIME NULL
,
  ADD COLUMN `prelim_shift_name` VARCHAR(31) NULL
;
COMMIT