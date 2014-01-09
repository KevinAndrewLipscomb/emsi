START TRANSACTION
;
DROP TABLE IF EXISTS strike_team_deployment_log
;
CREATE TABLE IF NOT EXISTS strike_team_deployment_log (
  id SERIAL,
  deployment_id BIGINT UNSIGNED NOT NULL,
  timestamp TIMESTAMP DEFAULT CURRENT_TIMESTAMP NOT NULL,
  actor_member_id BIGINT UNSIGNED NOT NULL,
  action VARCHAR(511) NOT NULL,
  PRIMARY KEY(id),
  KEY(deployment_id),
  KEY(actor_member_id),
  CONSTRAINT `strike_team_deployment_log_deployment_id` FOREIGN KEY (`deployment_id`) REFERENCES `strike_team_deployment` (`id`),
  CONSTRAINT `strike_team_deployment_log_actor_member_id`FOREIGN KEY (`actor_member_id`) REFERENCES `practitioner` (`id`)
)
ENGINE = InnoDB
;
ALTER TABLE `strike_team_deployment_log` 
  DROP INDEX `id`
;
COMMIT