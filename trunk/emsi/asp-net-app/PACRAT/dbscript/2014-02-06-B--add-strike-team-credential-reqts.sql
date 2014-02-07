START TRANSACTION
;
ALTER TABLE `practitioner_strike_team_detail`
  ADD COLUMN `nims_is_800_date` DATE NULL DEFAULT '0001-01-01'
,
  ADD COLUMN `lms_disaster_stress_response_date` DATE NULL DEFAULT '0001-01-01'
,
  ADD COLUMN `lms_ems_mci_ops_date` DATE NULL DEFAULT '0001-01-01'
,
  ADD COLUMN `lms_wmd_date` DATE NULL DEFAULT '0001-01-01'
,
  ADD COLUMN `lms_smallpox_date` DATE NULL DEFAULT '0001-01-01'
,
  ADD COLUMN `lms_basic_med_terrorism_response_date` DATE NULL DEFAULT '0001-01-01'
,
  ADD COLUMN `lms_electrical_hazards_date` DATE NULL DEFAULT '0001-01-01'
,
  ADD COLUMN `lms_ems_bioterror_date` DATE NULL DEFAULT '0001-01-01'
;
COMMIT