START TRANSACTION
;
insert ignore privilege (name) values
("config-business-objects")
;
insert role_privilege_map (privilege_id,role_id) values
((select id from privilege where name = "config-business-objects"),(select id from role where name = "Application Administrator")),
((select id from privilege where name = "config-business-objects"),(select id from role where name = "State Strike Team Manager"))
;
COMMIT