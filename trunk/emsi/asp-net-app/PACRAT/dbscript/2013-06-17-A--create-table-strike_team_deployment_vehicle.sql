DROP TABLE IF EXISTS strike_team_deployment_vehicle;
CREATE TABLE IF NOT EXISTS strike_team_deployment_vehicle (
  id SERIAL,
  deployment_id BIGINT UNSIGNED NOT NULL,
  vehicle_id BIGINT UNSIGNED NOT NULL,
  PRIMARY KEY(id),
  CONSTRAINT strike_team_deployment_vehicle_deployment_id FOREIGN KEY (deployment_id) REFERENCES strike_team_deployment (id),
  CONSTRAINT strike_team_deployment_vehicle_vehicle_id FOREIGN KEY (vehicle_id) REFERENCES vehicle (id)
)
ENGINE = InnoDB;
