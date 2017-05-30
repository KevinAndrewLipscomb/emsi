START TRANSACTION
;
insert ignore regional_staffer (region_code,last_name,first_name) values
((select code from region_code_name_map where name = "EMMCO West"),"Davis","Cathy"),
((select code from region_code_name_map where name = "EMMCO West"),"Buttyan","Thomas")
;
insert ignore regional_staffer_user (id,password_reset_email_address) values
((select id from regional_staffer where first_name = "Cathy" and last_name = "Davis"),"cathy@emmco.org"),
((select id from regional_staffer where first_name = "Thomas" and last_name = "Buttyan"),"tom@emmco.org")
;
insert ignore regional_staffer_role (group_id,user_id) values
((select id from regional_staffer_group where name = "education-specialist"),(select id from regional_staffer_user where password_reset_email_address = "cathy@emmco.org")),
((select id from regional_staffer_group where name = "education-specialist"),(select id from regional_staffer_user where password_reset_email_address = "tom@emmco.org"))
;
update regional_staffer_user
set be_active = FALSE
where password_reset_email_address = 'michelle@emmco.org'
;
COMMIT
