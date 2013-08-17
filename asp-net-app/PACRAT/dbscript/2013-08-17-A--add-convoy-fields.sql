START TRANSACTION
;
ALTER TABLE `strike_team_deployment_operational_period`
  ADD COLUMN `be_convoy` BOOLEAN DEFAULT FALSE
;
COMMIT