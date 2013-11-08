START TRANSACTION
;
insert ignore privilege (name) values
("config-sms-gateways")
;
insert ignore role_privilege_map (role_id,privilege_id) values
((select id from role where name = "Application Administrator"),(select id from privilege where name = "config-sms-gateways")),
((select id from role where name = "State Strike Team Manager"),(select id from privilege where name = "config-sms-gateways"))
;
COMMIT