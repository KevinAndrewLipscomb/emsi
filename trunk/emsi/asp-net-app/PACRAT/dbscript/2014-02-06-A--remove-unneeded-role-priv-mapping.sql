START TRANSACTION
;
delete from role_privilege_map
where role_id = (select id from role where name = 'Service Strike Team Manager')
  and privilege_id = (select id from privilege where name = 'config-operational-periods')
;
COMMIT