DROP TABLE IF EXISTS strike_team_deployment;
CREATE TABLE IF NOT EXISTS strike_team_deployment (
  id SERIAL,
  creation_date DATE NOT NULL,
  name VARCHAR(127) NOT NULL,
  region_code TINYINT UNSIGNED NOT NULL,
  PRIMARY KEY(id),
  UNIQUE practical (region_code,creation_date,name),
  CONSTRAINT strike_team_deployment_region_code FOREIGN KEY (region_code) REFERENCES region_code_name_map (code)
)
ENGINE = InnoDB;
