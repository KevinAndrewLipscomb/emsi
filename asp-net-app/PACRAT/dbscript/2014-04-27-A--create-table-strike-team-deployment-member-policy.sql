START TRANSACTION
;
DROP TABLE IF EXISTS strike_team_deployment_member_policy
;
CREATE TABLE IF NOT EXISTS strike_team_deployment_member_policy (
  id SERIAL,
  description VARCHAR(63) NOT NULL,
  PRIMARY KEY(id),
  UNIQUE(description)
)
ENGINE = InnoDB
;
insert ignore strike_team_deployment_member_policy (description) values
("strict"),
("relaxed"),
("drill")
;
ALTER TABLE `strike_team_deployment`
  DROP INDEX `id`
,
  ADD COLUMN `member_policy_id` BIGINT UNSIGNED NOT NULL DEFAULT '1'
,
  ADD INDEX `member_policy_id` (`member_policy_id` ASC)
,
  ADD CONSTRAINT `strike_team_deployment_member_policy_id` FOREIGN KEY (`member_policy_id` ) REFERENCES `strike_team_deployment_member_policy` (`id` )
;
update strike_team_deployment
set member_policy_id = (select id from strike_team_deployment_member_policy where description = IF(be_drill,'drill','strict'))
;
ALTER TABLE `strike_team_deployment`
  DROP COLUMN `be_drill`
;
COMMIT