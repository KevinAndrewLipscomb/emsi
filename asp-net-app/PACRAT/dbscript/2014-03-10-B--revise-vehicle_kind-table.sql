START TRANSACTION
;
insert ignore vehicle_kind
set description = 'Stretcher/wheelchair van'
, elaboration = 'Transports non-acute mobility-challenged persons'
;
COMMIT