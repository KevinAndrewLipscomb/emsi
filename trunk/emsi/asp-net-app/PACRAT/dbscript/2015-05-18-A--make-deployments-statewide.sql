START TRANSACTION
;
ALTER TABLE `strike_team_deployment` 
  DROP FOREIGN KEY `strike_team_deployment_region_code`
;
ALTER TABLE `strike_team_deployment` 
  DROP COLUMN `region_code`,
  DROP INDEX `practical` ,
  ADD UNIQUE INDEX `practical` (`creation_date` ASC, `name` ASC)
;
COMMIT