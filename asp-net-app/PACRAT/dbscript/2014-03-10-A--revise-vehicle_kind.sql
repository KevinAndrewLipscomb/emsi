START TRANSACTION
;
update vehicle_kind
set description = 'Air Ambulance (Fixed-Wing)'
where description = 'Air ambulance - fixed wing'
;
update vehicle_kind
set description = 'Air Ambulance (Rotary-Wing)'
where description = 'Air ambulance - rotary wing'
;
update vehicle_kind
set description = 'MEOC truck'
where description = 'Mobile command & control truck'
;
insert ignore vehicle_kind
set description = 'Bus'
, be_target_pm_mileage_meaningful = TRUE
, be_dmv_inspection_due_meaningful = TRUE
, elaboration = 'Transports seated personnel or patients'
;
COMMIT