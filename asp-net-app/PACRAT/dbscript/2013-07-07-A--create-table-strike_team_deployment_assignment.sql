DROP TABLE IF EXISTS strike_team_deployment_assignment;
CREATE TABLE IF NOT EXISTS strike_team_deployment_assignment (
  id SERIAL,
  operational_period_id BIGINT UNSIGNED NOT NULL,
  member_id BIGINT UNSIGNED NOT NULL,
  vehicle_id BIGINT UNSIGNED,
  PRIMARY KEY(id),
  UNIQUE (operational_period_id,member_id),
  KEY (member_id),
  KEY (vehicle_id),
  CONSTRAINT strike_team_deployment_assignment_operational_period_id FOREIGN KEY (operational_period_id) REFERENCES strike_team_deployment_operational_period (id),
  CONSTRAINT strike_team_deployment_assignment_member_id FOREIGN KEY (member_id) REFERENCES practitioner (id),
  CONSTRAINT strike_team_deployment_assignment_vehicle_id FOREIGN KEY (vehicle_id) REFERENCES vehicle (id)
)
ENGINE = InnoDB;
