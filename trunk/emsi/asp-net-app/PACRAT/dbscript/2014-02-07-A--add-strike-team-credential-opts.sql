START TRANSACTION
;
ALTER TABLE `practitioner_strike_team_detail`
  ADD COLUMN `nims_ics_300_date` DATE NULL DEFAULT '0001-01-01' AFTER nims_is_800_date
,
  ADD COLUMN `nims_ics_400_date` DATE NULL DEFAULT '0001-01-01' AFTER nims_ics_300_date
,
  ADD COLUMN `pa_psychological_first_aid_date` DATE NULL DEFAULT '0001-01-01'
,
  ADD COLUMN `pa_water_rescue_awareness_date` DATE NULL DEFAULT '0001-01-01'
,
  ADD COLUMN `pa_hazmat_awareness_date` DATE NULL DEFAULT '0001-01-01'
,
  ADD COLUMN `pa_ems_strike_team_leader_date` DATE NULL DEFAULT '0001-01-01'
,
  ADD COLUMN `two_years_supervisory_experience_date` DATE NULL DEFAULT '0001-01-01'
;
COMMIT