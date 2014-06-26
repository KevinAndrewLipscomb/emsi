START TRANSACTION
;
insert ignore regional_staffer (region_code,last_name,first_name) values
((select code from region_code_name_map where name = "Seven Mountains"),"Grimes","Cathy"),
((select code from region_code_name_map where name = "Seven Mountains"),"Wolfgang","Mark"),
((select code from region_code_name_map where name = "Seven Mountains"),"Nilson","Tim")
;
insert ignore regional_staffer_user (id,password_reset_email_address) values
((select id from regional_staffer where first_name = "Cathy" and last_name = "Grimes"),"cgrimes@smemsc.org"),
((select id from regional_staffer where first_name = "Mark" and last_name = "Wolfgang"),"mwolfgang@smemsc.org"),
((select id from regional_staffer where first_name = "Tim" and last_name = "Nilson"),"tim.nilson@smemsc.org")
;
insert ignore regional_staffer_role (group_id,user_id) values
((select id from regional_staffer_group where name = "director"),(select id from regional_staffer_user where password_reset_email_address = "tim.nilson@smemsc.org")),
((select id from regional_staffer_group where name = "education-coordinator"),(select id from regional_staffer_user where password_reset_email_address = "mwolfgang@smemsc.org")),
((select id from regional_staffer_group where name = "education-specialist"),(select id from regional_staffer_user where password_reset_email_address = "cgrimes@smemsc.org"))
;
COMMIT