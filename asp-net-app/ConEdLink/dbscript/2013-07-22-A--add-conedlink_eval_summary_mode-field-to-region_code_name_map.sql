START TRANSACTION
;
DROP TABLE IF EXISTS eval_summary_mode
;
CREATE TABLE IF NOT EXISTS eval_summary_mode (
  id SERIAL,
  description VARCHAR(63) NOT NULL,
  elaboration VARCHAR(511) NOT NULL,
  PRIMARY KEY(id),
  UNIQUE(description)
)
ENGINE = InnoDB
;
insert ignore eval_summary_mode (description,elaboration) values
("Optional","Sponsors MAY complete all or part of a Class Evaluation Summary as they close their rosters."),
("Hidden","The application will not display or accept Class Evaluation Summary information."),
("Mandatory","Sponsors MUST complete a Class Evaluation Summary as they close their rosters.")
;
ALTER TABLE `region_code_name_map`
  ADD COLUMN `conedlink_eval_summary_mode_id` BIGINT UNSIGNED NOT NULL DEFAULT 1
,
  ADD INDEX `conedlink_eval_summary_mode_id` (`conedlink_eval_summary_mode_id` ASC)
,
  ADD CONSTRAINT region_code_name_map_conedlink_eval_summary_mode_id FOREIGN KEY (conedlink_eval_summary_mode_id) REFERENCES eval_summary_mode (id)
;
update region_code_name_map
set conedlink_eval_summary_mode_id = (select id from eval_summary_mode where description = "Mandatory")
where name = "Southern Alleghenies"
;
COMMIT