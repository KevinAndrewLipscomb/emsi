DROP TABLE IF EXISTS strike_team_deployment_operational_period;
CREATE TABLE IF NOT EXISTS strike_team_deployment_operational_period (
  id SERIAL,
  deployment_id BIGINT UNSIGNED NOT NULL,
  start DATETIME NOT NULL,
  end DATETIME NOT NULL,
  PRIMARY KEY(id),
  CONSTRAINT strike_team_deployment_operational_period_deployment_id FOREIGN KEY (deployment_id) REFERENCES strike_team_deployment (id)
)
ENGINE = InnoDB;
