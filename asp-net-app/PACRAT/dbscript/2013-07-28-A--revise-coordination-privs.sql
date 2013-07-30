START TRANSACTION
;
insert privilege set name = "see-strike-team-deployments"
;
insert ignore role_privilege_map (role_id,privilege_id) values
((select id from role where name = "State Strike Team Manager"),(select id from privilege where name = "config-practitioner-strike-team-details")),
((select id from role where name = "State Strike Team Manager"),(select id from privilege where name = "config-strike-team-deployments")),
((select id from role where name = "State Strike Team Manager"),(select id from privilege where name = "add-vehicles")),
((select id from role where name = "State Strike Team Manager"),(select id from privilege where name = "config-vehicles")),
((select id from role where name = "State Strike Team Manager"),(select id from privilege where name = "config-operational-periods")),
((select id from role where name = "Service Strike Team Manager"),(select id from privilege where name = "see-strike-team-deployments"))
;
COMMIT