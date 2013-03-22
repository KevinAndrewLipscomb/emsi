START TRANSACTION
;
update region_code_name_map set be_conedlink_subscriber = TRUE where name = "Chester County"
;
insert ignore regional_staffer (region_code,last_name,first_name) values
((select code from region_code_name_map where name = "Chester County"),"Webb","Steve"),
((select code from region_code_name_map where name = "Chester County"),"Moore","Harry")
;
insert ignore regional_staffer_user (id,password_reset_email_address) values
((select id from regional_staffer where first_name = "Steve" and last_name = "Webb"),"swebb@chesco.org"),
((select id from regional_staffer where first_name = "Harry" and last_name = "Moore"),"hemoore@chesco.org")
;
insert ignore regional_staffer_role (group_id,user_id) values
((select id from regional_staffer_group where name = "director"),(select id from regional_staffer_user where password_reset_email_address = "swebb@chesco.org")),
((select id from regional_staffer_group where name = "education-coordinator"),(select id from regional_staffer_user where password_reset_email_address = "hemoore@chesco.org"))
;
COMMIT