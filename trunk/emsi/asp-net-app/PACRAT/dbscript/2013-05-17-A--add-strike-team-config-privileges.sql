START TRANSACTION
;
insert ignore privilege (name) values
("config-strike-team-region"),
("config-strike-team-service")
;
insert ignore role_privilege_map (role_id,privilege_id) values
((select id from role where name = "Region Strike Team Manager"),(select id from privilege where name = "config-strike-team-region")),
((select id from role where name = "Service Strike Team Manager"),(select id from privilege where name = "config-strike-team-service"))
;
COMMIT