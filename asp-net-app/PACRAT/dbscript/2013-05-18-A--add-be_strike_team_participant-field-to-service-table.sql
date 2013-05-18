START TRANSACTION
;
ALTER TABLE `service`
  ADD COLUMN `be_strike_team_participant` TINYINT NOT NULL DEFAULT '0'
,
  ADD INDEX `be_strike_team_participant` (`be_strike_team_participant` ASC)
;
COMMIT