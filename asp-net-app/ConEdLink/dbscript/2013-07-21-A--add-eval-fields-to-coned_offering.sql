START TRANSACTION
;
ALTER TABLE `coned_offering`
  ADD COLUMN `eval_summary_instructional_staff` TEXT NULL
,
  ADD COLUMN `eval_summary_time_appropriately_used` TEXT NULL
,
  ADD COLUMN `eval_summary_classroom_training_site` TEXT NULL
,
  ADD COLUMN `eval_summary_equipment_av` TEXT NULL
,
  ADD COLUMN `eval_summary_misc_remarks` TEXT NULL
;
COMMIT