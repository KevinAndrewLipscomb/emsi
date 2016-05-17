START TRANSACTION
;
ALTER TABLE `coned_offering` 
  ADD INDEX `region_council_num` (`region_council_num` ASC)
,
  ADD INDEX `end_date_time` (`end_date_time` ASC)
;
CREATE TABLE `old_analysis_of_region_by_year`
  (
  id SERIAL,
  `region_code` TINYINT UNSIGNED,
  `fiscal_year_ending` YEAR NOT NULL,
  `practitioner_level_id` BIGINT UNSIGNED,
  `num_classes` BIGINT UNSIGNED NOT NULL,
  `num_sittings` BIGINT UNSIGNED NOT NULL,
  `avg_num_students_per_class` DECIMAL(7,1) UNSIGNED,
  `num_distinct_practitioners` BIGINT UNSIGNED NOT NULL,
  PRIMARY KEY (id),
  UNIQUE INDEX region_code (`region_code`, `fiscal_year_ending`, `practitioner_level_id`),
  UNIQUE INDEX `fiscal_year_ending` (`fiscal_year_ending` ASC, `region_code` ASC, `practitioner_level_id` ASC),
  UNIQUE INDEX `practitioner_level_id` (`practitioner_level_id` ASC, `region_code` ASC, `fiscal_year_ending` ASC),
  INDEX `num_classes` (`num_classes` ASC, `region_code` ASC, `fiscal_year_ending` ASC, `practitioner_level_id` ASC),
  INDEX `num_sittings` (`num_sittings` ASC, `region_code` ASC, `fiscal_year_ending` ASC, `practitioner_level_id` ASC),
  INDEX `avg_num_students_per_class` (`avg_num_students_per_class` ASC, `region_code` ASC, `fiscal_year_ending` ASC, `practitioner_level_id` ASC),
  INDEX `num_distinct_practitioners` (`num_distinct_practitioners` ASC, `region_code` ASC, `fiscal_year_ending` ASC, `practitioner_level_id` ASC),
  CONSTRAINT `old_analysis_of_region_by_year_region_code` FOREIGN KEY (`region_code`) REFERENCES `region_code_name_map` (`code`),
  CONSTRAINT `old_analysis_of_region_by_year_practitioner_level_id` FOREIGN KEY (`practitioner_level_id`) REFERENCES `practitioner_level` (`id`)
  )
;
COMMIT
