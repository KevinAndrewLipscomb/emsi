START TRANSACTION
;
update vehicle
set kind_id = (select id from vehicle_kind where description = 'Squad')
where name = 'SQUAD 518 PASSENGER VAN (10 PERSON OR LARGE CARGO)'
;
update vehicle
set kind_id = (select id from vehicle_kind where description = 'Squad')
where name in ('SQUAD 981','SQUAD 982')
;
update vehicle
set name = REPLACE(name,'MEDIC ','')
where name like 'MEDIC %'
;
update vehicle
set name = REPLACE(name,'AMBULANCE ','')
where name like 'AMBULANCE %'
;
update vehicle
set name = REPLACE(name,'SQUAD ','')
where name like 'SQUAD %'
;
update vehicle
set name = REPLACE(name,'UTILITY ','')
, kind_id = (select id from vehicle_kind where description = 'Utility')
where name like 'UTILITY %'
;
update vehicle
set name = REPLACE(name,'FAYETTE ','')
where name like 'FAYETTE %'
;
update vehicle
set name = REPLACE(name,'MURRYSVILLE ','')
where name like 'MURRYSVILLE %'
;
update vehicle
set name = REPLACE(name,'SMRT ','')
where name like 'SMRT %'
;
update vehicle
set name = REPLACE(name,'Z ','')
where name like 'Z %'
;
update vehicle
set kind_id = (select id from vehicle_kind where description = 'Support truck')
where kind_id = (select id from vehicle_kind where description = 'Canteen')
;
COMMIT
;
START TRANSACTION
;
update vehicle
set name = REPLACE(name,'MEDIC ','')
where name like 'MEDIC %'
;
COMMIT