START TRANSACTION
;
ALTER TABLE `coned_offering`
  ADD COLUMN `fr_med_trauma_hours` DECIMAL(5,1) UNSIGNED NULL
,
  ADD COLUMN `fr_other_hours` DECIMAL(5,1) UNSIGNED NULL
,
  ADD COLUMN `emt_med_trauma_hours` DECIMAL(5,1) UNSIGNED NULL
,
  ADD COLUMN `emt_other_hours` DECIMAL(5,1) UNSIGNED NULL
,
  ADD COLUMN `emtp_med_trauma_hours` DECIMAL(5,1) UNSIGNED NULL
,
  ADD COLUMN `emtp_other_hours` DECIMAL(5,1) UNSIGNED NULL
,
  ADD COLUMN `phrn_med_trauma_hours` DECIMAL(5,1) UNSIGNED NULL
,
  ADD COLUMN `phrn_other_hours` DECIMAL(5,1) UNSIGNED NULL
;
COMMIT
