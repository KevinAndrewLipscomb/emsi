START TRANSACTION
;
insert ignore notification set name = 'member-added';
;
insert ignore role_notification_map (notification_id,role_id) values
((select id from notification where name = 'member-added'),(select id from role where name = 'State Strike Team Executive')),
((select id from notification where name = 'member-added'),(select id from role where name = 'State Strike Team Manager')),
((select id from notification where name = 'member-added'),(select id from role where name = 'Region Strike Team Manager'))
;
insert ignore privilege set name = 'add-associates';
;
insert ignore role_privilege_map (privilege_id,role_id) values
((select id from privilege where name = 'add-associates'),(select id from role where name = 'State Strike Team Executive')),
((select id from privilege where name = 'add-associates'),(select id from role where name = 'Application Administrator')),
((select id from privilege where name = 'add-associates'),(select id from role where name = 'State Strike Team Manager')),
((select id from privilege where name = 'add-associates'),(select id from role where name = 'Region Strike Team Manager'))
;
COMMIT
