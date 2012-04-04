START TRANSACTION
;
DROP TABLE IF EXISTS gender
;
CREATE TABLE IF NOT EXISTS gender (
  id SERIAL,
  description VARCHAR(63) NOT NULL,
  PRIMARY KEY(id),
  UNIQUE(description)
)
ENGINE = InnoDB
;
insert ignore gender (description) values
("Male"),
("Female")
;
DROP TABLE IF EXISTS practitioner_status
;
CREATE TABLE IF NOT EXISTS practitioner_status (
  id SERIAL,
  description VARCHAR(63) NOT NULL,
  PRIMARY KEY(id),
  UNIQUE(description)
)
ENGINE = InnoDB
;
insert ignore practitioner_status (description) values
("Active"),
("Inactive"),
("Revoked"),
("Suspended"),
("Dropped"),
("Expired")
;
ALTER TABLE `practitioner`
  ADD COLUMN `issue_date` DATE NULL  AFTER `be_instructor` 
,
  ADD COLUMN `expiration_date` DATE NULL
,
  ADD COLUMN `gender_id` BIGINT UNSIGNED NULL
,
  ADD COLUMN `status_id` BIGINT UNSIGNED NULL
,
  ADD INDEX `gender_id` (`gender_id` ASC)
,
  ADD INDEX `status_id` (`status_id` ASC)
,
  ADD CONSTRAINT `practitioner_gender_id` FOREIGN KEY (gender_id) REFERENCES `gender` (id)
,
  ADD CONSTRAINT `practitioner_status_id` FOREIGN KEY (status_id) REFERENCES `practitioner_status` (id)
;
COMMIT