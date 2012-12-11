START TRANSACTION
;
insert ignore regional_staffer (region_code,last_name,first_name) values
((select code from region_code_name_map where name = "Southern Alleghenies"),"Moen","Carl"),
((select code from region_code_name_map where name = "Southern Alleghenies"),"Driscoll","Lori"),
((select code from region_code_name_map where name = "Southern Alleghenies"),"Tippery","Rachelle"),
((select code from region_code_name_map where name = "Southern Alleghenies"),"Enos","Herb")
;
insert ignore regional_staffer_user (id,password_reset_email_address) values
((select id from regional_staffer where first_name = "Carl" and last_name = "Moen"),"cmoen@saems.com"),
((select id from regional_staffer where first_name = "Lori" and last_name = "Driscoll"),"ldriscoll@saems.com"),
((select id from regional_staffer where first_name = "Rachelle" and last_name = "Tippery"),"rtippery@saems.com"),
((select id from regional_staffer where first_name = "Herb" and last_name = "Enos"),"henos@saems.com")
;
insert ignore regional_staffer_role (group_id,user_id) values
((select id from regional_staffer_group where name = "education-coordinator"),(select id from regional_staffer_user where password_reset_email_address = "rtippery@saems.com")),
((select id from regional_staffer_group where name = "education-specialist"),(select id from regional_staffer_user where password_reset_email_address = "ldriscoll@saems.com")),
((select id from regional_staffer_group where name = "education-specialist"),(select id from regional_staffer_user where password_reset_email_address = "henos@saems.com")),
((select id from regional_staffer_group where name = "director"),(select id from regional_staffer_user where password_reset_email_address = "cmoen@saems.com"))
;
update coned_sponsor_user
  join teaching_entity using (id)
set be_ok_to_input_roster_by_batch = TRUE
, be_ok_to_input_roster_by_copy = TRUE
where name = "Southern Alleghenies EMS Council, Inc."
;
update region_code_name_map set
  be_conedlink_subscriber = TRUE
where name = "Southern Alleghenies"
;
COMMIT