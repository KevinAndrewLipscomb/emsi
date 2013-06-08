START TRANSACTION
;
insert ignore privilege (name) values
("config-strike-team-region"),
("config-strike-team-service"),
("config-practitioner-strike-team-details"),
("config-strike-team-deployments")
;
insert ignore role_privilege_map (role_id,privilege_id) values
((select id from role where name = "Application Administrator"),(select id from privilege where name = "config-practitioner-strike-team-details")),
((select id from role where name = "Application Administrator"),(select id from privilege where name = "config-strike-team-deployments")),
((select id from role where name = "Region Strike Team Manager"),(select id from privilege where name = "config-strike-team-region")),
((select id from role where name = "Region Strike Team Manager"),(select id from privilege where name = "config-practitioner-strike-team-details")),
((select id from role where name = "Region Strike Team Manager"),(select id from privilege where name = "config-strike-team-deployments")),
((select id from role where name = "Service Strike Team Manager"),(select id from privilege where name = "config-strike-team-service")),
((select id from role where name = "Service Strike Team Manager"),(select id from privilege where name = "config-practitioner-strike-team-details"))
;
COMMIT