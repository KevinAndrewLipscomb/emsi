DROP TABLE IF EXISTS strike_team_deployment_member;
CREATE TABLE IF NOT EXISTS strike_team_deployment_member (
  id SERIAL,
  deployment_id BIGINT UNSIGNED NOT NULL,
  practitioner_id BIGINT UNSIGNED NOT NULL,
  PRIMARY KEY(id),
  CONSTRAINT strike_team_deployment_member_deployment_id FOREIGN KEY (deployment_id) REFERENCES strike_team_deployment (id),
  CONSTRAINT strike_team_deployment_member_practitioner_id FOREIGN KEY (practitioner_id) REFERENCES practitioner (id)
)
ENGINE = InnoDB;
