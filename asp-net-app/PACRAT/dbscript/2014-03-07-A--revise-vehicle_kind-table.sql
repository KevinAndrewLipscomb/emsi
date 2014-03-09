START TRANSACTION
;
ALTER TABLE `vehicle_kind`
  ADD COLUMN `elaboration` VARCHAR(127)
;
update ignore vehicle_kind
set description = 'Squad'
, elaboration = 'Delivers personnel and some (usually handheld) gear to a scene'
where description = 'Zone car'
;
update ignore vehicle_kind
set description = 'Utility'
, elaboration = 'Moves widely variable kinds of gear around'
where description = 'Utility car'
;
update ignore vehicle_kind
set description = 'Rescue'
, elaboration = 'Rolling toolbox, with extrication gear'
where description = 'Squad truck'
;
update ignore vehicle_kind
set description = 'Canteen'
, elaboration = 'Delivers food and beverages to emergency workers'
where description = 'Support truck'
;
update ignore vehicle_kind
set elaboration = 'No onboard brakes, usually flatbed and unenclosed'
where description = 'Light utility trailer'
;
update ignore vehicle_kind
set elaboration = 'No onboard brakes, enclosed'
where description = 'Light cargo trailer'
;
update ignore vehicle_kind
set elaboration = 'No onboard brakes, specialized as indicated in name'
where description = 'Light special trailer'
;
update ignore vehicle_kind
set elaboration = 'Onboard brakes, usually flatbed and unenclosed'
where description = 'Heavy utility trailer'
;
update ignore vehicle_kind
set elaboration = 'Onboard brakes, enclosed'
where description = 'Heavy cargo trailer'
;
update ignore vehicle_kind
set elaboration = 'Onboard brakes, specialized as indicated in name'
where description = 'Heavy special trailer'
;
update ignore vehicle_kind
set elaboration = 'No onboard brakes'
where description = 'Light boat trailer'
;
update ignore vehicle_kind
set elaboration = 'Onboard brakes'
where description = 'Heavy boat trailer'
;
update ignore vehicle_kind
set elaboration = 'or SUV'
where description = 'Chief car'
;
update ignore vehicle_kind
set elaboration = 'or SUV'
where description = 'Supervisor car'
;
update ignore vehicle_kind
set description = 'Transport cart'
, elaboration = 'Golf-cart or ATV size, carries a patient'
where description = 'Special cart'
;
update ignore vehicle_kind
set description = 'MCI supply truck'
, elaboration = 'Delivers MCI supplies to scene'
where description = 'MCI truck'
;
update ignore vehicle_kind
set description = 'Air ambulance - rotary wing'
where description = 'Air ambulance'
;
insert ignore vehicle_kind set description = 'Air ambulance - fixed wing'
;
insert ignore vehicle_kind
set description = 'MCI transport'
, elaboration = 'Transports multiple cot-bound patients'
;
insert ignore vehicle_kind
set description = 'Mobile command & control truck'
;
update ignore vehicle
set kind_id = (select id from vehicle_kind where description = 'Rescue')
where kind_id = (select id from vehicle_kind where description = 'SAR truck')
;
delete from vehicle_kind where description in ('SAR truck')
;
COMMIT