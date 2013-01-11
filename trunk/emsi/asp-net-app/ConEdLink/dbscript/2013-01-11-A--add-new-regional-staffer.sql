START TRANSACTION
;
update regional_staffer_user
  join regional_staffer using (id)
set
  be_active = FALSE
where first_name = "Sarah" and last_name = "Dees"
;
insert ignore regional_staffer (region_code,last_name,first_name) values
((select code from region_code_name_map where name = "Susquehanna"),"Rompolski","Laura")
;
insert ignore regional_staffer_user (id,password_reset_email_address) values
((select id from regional_staffer where first_name = "Laura" and last_name = "Rompolski"),"secretary@sehsc.org")
;
insert ignore regional_staffer_role (group_id,user_id) values
((select id from regional_staffer_group where name = "education-coordinator"),(select id from regional_staffer_user where password_reset_email_address = "secretary@sehsc.org"))
;
COMMIT