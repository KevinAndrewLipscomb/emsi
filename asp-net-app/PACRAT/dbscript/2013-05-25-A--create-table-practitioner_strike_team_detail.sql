DROP TABLE IF EXISTS practitioner_strike_team_detail;
CREATE TABLE IF NOT EXISTS practitioner_strike_team_detail (
  id SERIAL,
  practitioner_id BIGINT UNSIGNED NOT NULL,
  act_1985_33_date DATE,
  act_1985_34_date DATE,
  act_1994_151_date DATE,
  phone_number VARCHAR(10),
  phone_service_id BIGINT UNSIGNED,
  be_immune_hepatits_b BOOLEAN DEFAULT FALSE NOT NULL,
  be_immune_diptheria_tetanus BOOLEAN DEFAULT FALSE NOT NULL,
  emergency_contact_1_name VARCHAR(127),
  emergency_contact_1_phone_number VARCHAR(10),
  emergency_contact_2_name VARCHAR(127),
  emergency_contact_2_phone_number VARCHAR(10),
  meds_doses TEXT,
  allergies TEXT,
  pcp_name VARCHAR(127),
  drivers_license_expiration DATE,
  nims_is_100_date DATE,
  nims_is_200_date DATE,
  nims_is_700_date DATE,
  PRIMARY KEY(id),
  UNIQUE (practitioner_id),
  INDEX phone_service_id (phone_service_id)
)
ENGINE = InnoDB;
