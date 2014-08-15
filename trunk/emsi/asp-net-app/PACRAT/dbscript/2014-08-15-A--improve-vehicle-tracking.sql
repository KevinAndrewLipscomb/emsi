START TRANSACTION
;
ALTER TABLE `vehicle_kind`
  ADD COLUMN `be_hiway_legal_trailer` TINYINT(1) NOT NULL DEFAULT FALSE AFTER `description`
,
  ADD COLUMN `be_large_cargo_carrier` TINYINT(1) NOT NULL DEFAULT FALSE AFTER `be_hiway_legal_trailer`
;
update vehicle_kind
set be_target_pm_mileage_meaningful = TRUE
, be_dmv_inspection_due_meaningful = TRUE
where description in
  (
  'MCI transport',
  'MEOC truck',
  'Support truck',
  'Stretcher/wheelchair van'
  )
;
update vehicle_kind set be_hiway_legal_trailer = TRUE where description like '%trailer'
;
update vehicle_kind set be_large_cargo_carrier = TRUE where be_hiway_legal_trailer or description = 'Utility'
;
COMMIT