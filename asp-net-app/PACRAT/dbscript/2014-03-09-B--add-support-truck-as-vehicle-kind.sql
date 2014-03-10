START TRANSACTION
;
update vehicle_kind
set elaboration = REPLACE(elaboration,'as indicated in name','as indicated in name or elaboration')
;
insert ignore vehicle_kind
set description = 'Support truck'
, elaboration = 'Specialized as indicated in name or elaboration'
;
COMMIT