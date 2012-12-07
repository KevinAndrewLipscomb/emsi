START TRANSACTION
;
insert ignore regional_staffer (region_code,last_name,first_name) values
((select code from region_code_name_map where name = "EMMCO East"),"Fortney","Don"),
((select code from region_code_name_map where name = "EMMCO East"),"Cessna","Robbin"),
((select code from region_code_name_map where name = "EMMCO East"),"Weidow","John")
;
insert ignore regional_staffer_user (id,password_reset_email_address) values
((select id from regional_staffer where first_name = "Don" and last_name = "Fortney"),"dfortney@emmcoeast.org"),
((select id from regional_staffer where first_name = "Robbin" and last_name = "Cessna"),"rcessna@emmcoeast.org"),
((select id from regional_staffer where first_name = "John" and last_name = "Weidow"),"jweidow@emmcoeast.org")
;
insert ignore regional_staffer_role (group_id,user_id) values
((select id from regional_staffer_group where name = "education-coordinator"),(select id from regional_staffer_user where password_reset_email_address = "dfortney@emmcoeast.org")),
((select id from regional_staffer_group where name = "education-specialist"),(select id from regional_staffer_user where password_reset_email_address = "rcessna@emmcoeast.org")),
((select id from regional_staffer_group where name = "director"),(select id from regional_staffer_user where password_reset_email_address = "jweidow@emmcoeast.org"))
;
update coned_sponsor_user
  join teaching_entity using (id)
set be_ok_to_input_roster_by_batch = TRUE
, be_ok_to_input_roster_by_copy = TRUE
where name = "EMMCO East, Inc."
;
update region_code_name_map set
  be_conedlink_subscriber = TRUE
where name = "EMMCO East"
;
COMMIT