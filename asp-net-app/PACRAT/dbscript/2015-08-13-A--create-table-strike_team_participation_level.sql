START TRANSACTION
;
DROP TABLE IF EXISTS strike_team_participation_level
;
CREATE TABLE IF NOT EXISTS strike_team_participation_level (
  id SERIAL,
  description VARCHAR(31) NOT NULL,
  pecking_order SMALLINT UNSIGNED NOT NULL,
  elaboration TEXT NOT NULL,
  PRIMARY KEY(id)
)
ENGINE = InnoDB
;
insert ignore strike_team_participation_level (description,pecking_order,elaboration) values
('None',0,'Nonparticipant'),
('Ad-hoc',20000,"Does not participate or comply with strict Strike Team program plans, drills, or rules, but must be tracked for the duration of a particular unconventional deployment.  Will be reset to 'None - Nonparticipant' (with PACRAT assistance) at conclusion of upcoming deployment.  PACRAT will not send periodic status maintenance reports to officers or members of this team."),
('Standing',40000,'Regularly participates and complies with strict Strike Team program plans, drills, and rules.  Is tracked as a Strike Team during and between deployments.  PACRAT will send periodic status maintenance reports to officers and members of this team.')
;
insert ignore privilege set name = 'config-strike-team-participation-levels'
;
insert ignore role_privilege_map (privilege_id,role_id) values
((select id from privilege where name = 'config-strike-team-participation-levels'),(select id from role where name = 'Application Administrator'))
;
ALTER TABLE `service` 
  ADD COLUMN `strike_team_participation_level_id` BIGINT UNSIGNED NOT NULL DEFAULT 1
,
  ADD INDEX `strike_team_participation_level_id` (`strike_team_participation_level_id` ASC)
;
update service
set strike_team_participation_level_id = (select id from strike_team_participation_level where description = 'Standing')
where be_strike_team_participant
;
ALTER TABLE `service` 
  DROP COLUMN `be_strike_team_participant`
,
  DROP INDEX `be_strike_team_participant`
;
COMMIT
