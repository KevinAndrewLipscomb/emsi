START TRANSACTION
;
insert ignore eval_summary_mode
set description = "SAEMS"
, elaboration = "Sponsors MUST complete an SAEMS-formatted Evaluation Summary as they close their rosters."
;
CREATE  TABLE `eval_summary_tally`
  (
    `id` BIGINT UNSIGNED NOT NULL AUTO_INCREMENT
  ,
    `coned_offering_id` BIGINT UNSIGNED NOT NULL
  ,
    `rating` TINYINT UNSIGNED NOT NULL
  ,
    `question` TINYINT UNSIGNED NOT NULL
  ,
    `value` SMALLINT UNSIGNED NOT NULL
  ,
    PRIMARY KEY (`id`)
  ,
    UNIQUE `coned_offering_id` (`coned_offering_id` ASC, `rating`, `question`)
  ,
    CONSTRAINT `eval_summary_tally_coned_offering_id` FOREIGN KEY (`coned_offering_id` ) REFERENCES `coned_offering` (`id` )
  )
;
COMMIT