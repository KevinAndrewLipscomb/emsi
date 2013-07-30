START TRANSACTION
;
update regional_staffer_user
  join regional_staffer using (id)
set be_active = FALSE
where last_name = "Gibbons"
  and first_name = "Richard"
;
delete from regional_staffer_role where user_id = (select id from regional_staffer where last_name = "Gibbons" and first_name = "Richard")
;
insert ignore regional_staffer (region_code,last_name,first_name) values
((select code from region_code_name_map where name = "Susquehanna"),"Paul","Charles")
;
insert ignore regional_staffer_user (id,password_reset_email_address) values
((select id from regional_staffer where first_name = "Charles" and last_name = "Paul"),"cpaul@sehsc.org")
;
insert ignore regional_staffer_role (group_id,user_id) values
((select id from regional_staffer_group where name = "education-coordinator"),(select id from regional_staffer_user where password_reset_email_address = "cpaul@sehsc.org"))
;
COMMIT