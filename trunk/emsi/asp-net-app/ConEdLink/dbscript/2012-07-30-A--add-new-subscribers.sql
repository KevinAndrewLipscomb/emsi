START TRANSACTION
;
update region_code_name_map
set be_conedlink_subscriber = TRUE
where name = "Susquehanna"
;
insert ignore regional_staffer (region_code,last_name,first_name) values
((select code from region_code_name_map where name = "Susquehanna"),"Dees","Sarah"),
((select code from region_code_name_map where name = "Susquehanna"),"Gibbons","Richard")
;
insert ignore regional_staffer_user (id,password_reset_email_address) values
((select id from regional_staffer where first_name = "Richard" and last_name = "Gibbons"),"rgibbons@sehsc.org"),
((select id from regional_staffer where first_name = "Sarah" and last_name = "Dees"),"sdees@sehsc.org")
;
insert ignore regional_staffer_role (group_id,user_id) values
((select id from regional_staffer_group where name = "director"),(select id from regional_staffer_user where password_reset_email_address = "rgibbons@sehsc.org")),
((select id from regional_staffer_group where name = "education-coordinator"),(select id from regional_staffer_user where password_reset_email_address = "sdees@sehsc.org"))
;
update coned_sponsor_user
  join teaching_entity using (id)
set be_ok_to_input_roster_by_batch = TRUE
, be_ok_to_input_roster_by_copy = TRUE
where name = "Susquehanna EHS Council, Inc."
;
COMMIT