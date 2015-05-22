START TRANSACTION
;
delete
from role_privilege_map
where privilege_id in
    (
    select id
    from privilege
    where name in
      (
      'config-operational-periods',
      'config-strike-team-deployments'
      )
    )
  and
    role_id = (select id from role where name = 'Region Strike Team Manager')
;
insert ignore role_privilege_map (privilege_id,role_id) values
((select id from privilege where name = 'see-strike-team-deployments'),(select id from role where name = 'Application Administrator')),
((select id from privilege where name = 'see-strike-team-deployments'),(select id from role where name = 'State Strike Team Executive')),
((select id from privilege where name = 'see-strike-team-deployments'),(select id from role where name = 'State Strike Team Manager')),
((select id from privilege where name = 'see-strike-team-deployments'),(select id from role where name = 'Region Strike Team Manager'))
;
insert ignore privilege
set name = 'config-strike-team-state'
;
insert ignore role_privilege_map (privilege_id,role_id) values
((select id from privilege where name = 'config-strike-team-state'),(select id from role where name = 'Application Administrator')),
((select id from privilege where name = 'config-strike-team-state'),(select id from role where name = 'State Strike Team Executive')),
((select id from privilege where name = 'config-strike-team-state'),(select id from role where name = 'State Strike Team Manager'))
;
delete
from role_privilege_map
where privilege_id = (select id from privilege where name = 'config-roles-and-matrices')
  and role_id in (select id from role where name <> 'Application Administrator')
;
insert ignore privilege
set name = 'config-strike-team-state-unlimited'
;
insert ignore role_privilege_map (privilege_id,role_id) values
((select id from privilege where name = 'config-strike-team-state-unlimited'),(select id from role where name = 'Application Administrator')),
((select id from privilege where name = 'config-strike-team-state-unlimited'),(select id from role where name = 'State Strike Team Executive'))
;
COMMIT