START TRANSACTION
;
DROP TABLE IF EXISTS tow_capacity
;
CREATE TABLE IF NOT EXISTS tow_capacity (
  id SERIAL,
  short_description VARCHAR(31) NOT NULL,
  long_description VARCHAR(63) NOT NULL,
  pecking_order MEDIUMINT UNSIGNED NOT NULL,
  PRIMARY KEY(id),
  UNIQUE(short_description),
  UNIQUE(long_description),
  UNIQUE(pecking_order)
)
ENGINE = InnoDB
;
insert ignore tow_capacity (short_description,long_description,pecking_order) values
("0","none",0),
("7200","up to 7200 pounds",7200),
("10,000","up to 10,000 pounds",10000),
("16,000","up to 16,000 pounds",16000),
(">16,000","more than 16,000 pounds",16001)
;
ALTER TABLE `vehicle`
  ADD COLUMN `tow_capacity_id` BIGINT UNSIGNED NOT NULL DEFAULT 1
,
  ADD COLUMN pa_doh_decal_num CHAR(7)
,
  ADD INDEX `tow_capacity_id` (`tow_capacity_id` ASC)
,
  ADD UNIQUE pa_doh_decal_num (pa_doh_decal_num)
,
  ADD UNIQUE license_plate (license_plate)
,
  ADD CONSTRAINT vehicle_tow_capacity_id FOREIGN KEY (tow_capacity_id) REFERENCES tow_capacity (id)
;
COMMIT