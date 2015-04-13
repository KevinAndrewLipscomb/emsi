START TRANSACTION
;
insert ignore role_privilege_map
set role_id = (select id from role where name = 'State Strike Team Manager')
, privilege_id = (select id from privilege where name = 'config-roles-and-matrices')
;
COMMIT