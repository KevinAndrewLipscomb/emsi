START TRANSACTION
;
insert ignore regional_staffer (region_code,last_name,first_name) values
((select code from region_code_name_map where name = "Federation"),"Melton","Tim")
;
insert ignore regional_staffer_user (id,password_reset_email_address) values
((select id from regional_staffer where first_name = "Tim" and last_name = "Melton"),"tmelton@ehsf.org")
;
insert ignore regional_staffer_role (group_id,user_id) values
((select id from regional_staffer_group where name = "education-reservist"),(select id from regional_staffer_user where password_reset_email_address = "tmelton@ehsf.org"))
;
COMMIT
