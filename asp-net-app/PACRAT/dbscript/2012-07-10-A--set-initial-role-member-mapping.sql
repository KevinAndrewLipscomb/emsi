START TRANSACTION
;
insert ignore role_member_map (role_id,member_id) values
((select id from role where name = "Application Administrator"),(select id from member where certification_number = "171966"))
;
insert ignore privilege (name) values
("config-users"),
("config-users-and-matrices"),
("config-roles-and-matrices"),
("assign-roles-to-members")
;
insert ignore role_privilege_map (role_id,privilege_id) values
((select id from role where name = "Application Administrator"),(select id from privilege where name = "send-quickmessages")),
((select id from role where name = "Application Administrator"),(select id from privilege where name = "config-users")),
((select id from role where name = "Application Administrator"),(select id from privilege where name = "config-users-and-matrices")),
((select id from role where name = "Application Administrator"),(select id from privilege where name = "config-roles-and-matrices")),
((select id from role where name = "Application Administrator"),(select id from privilege where name = "assign-roles-to-members"))
;
COMMIT