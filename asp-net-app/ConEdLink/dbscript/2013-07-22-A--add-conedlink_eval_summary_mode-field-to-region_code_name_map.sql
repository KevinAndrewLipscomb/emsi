START TRANSACTION
;
DROP TABLE IF EXISTS eval_summary_mode
;
CREATE TABLE IF NOT EXISTS eval_summary_mode (
  id SERIAL,
  description VARCHAR(63) NOT NULL,
  PRIMARY KEY(id),
  UNIQUE(description)
)
ENGINE = InnoDB
;
insert ignore eval_summary_mode (description) values
("Optional"),
("Hidden"),
("Mandatory")
;
ALTER TABLE `region_code_name_map`
  ADD COLUMN `conedlink_eval_summary_mode_id` BIGINT UNSIGNED NOT NULL DEFAULT 1
,
  ADD INDEX `conedlink_eval_summary_mode_id` (`conedlink_eval_summary_mode_id` ASC)
,
  ADD CONSTRAINT region_code_name_map_conedlink_eval_summary_mode_id FOREIGN KEY (conedlink_eval_summary_mode_id) REFERENCES eval_summary_mode (id)
;
COMMIT