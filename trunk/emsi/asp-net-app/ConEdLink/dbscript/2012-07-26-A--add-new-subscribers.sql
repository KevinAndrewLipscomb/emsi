START TRANSACTION
;
update region_code_name_map
set be_conedlink_subscriber = TRUE
where name = "Eastern"
;
insert ignore regional_staffer (region_code,last_name,first_name) values
((select code from region_code_name_map where name = "Eastern"),"Binns","Everitt"),
((select code from region_code_name_map where name = "Eastern"),"Kloss","John"),
((select code from region_code_name_map where name = "Eastern"),"Lillington","William"),
((select code from region_code_name_map where name = "Eastern"),"Boyer","Sally")
;
insert ignore regional_staffer_user (id,password_reset_email_address) values
((select id from regional_staffer where first_name = "Everitt" and last_name = "Binns"),"director@easternemscouncil.org"),
((select id from regional_staffer where first_name = "John" and last_name = "Kloss"),"john@easternemscouncil.org"),
((select id from regional_staffer where first_name = "William" and last_name = "Lillington"),"william@easternemscouncil.org"),
((select id from regional_staffer where first_name = "Sally" and last_name = "Boyer"),"sally@easternemscouncil.org")
;
insert ignore regional_staffer_role (group_id,user_id) values
((select id from regional_staffer_group where name = "director"),(select id from regional_staffer_user where password_reset_email_address = "director@easternemscouncil.org")),
((select id from regional_staffer_group where name = "director"),(select id from regional_staffer_user where password_reset_email_address = "john@easternemscouncil.org")),
((select id from regional_staffer_group where name = "education-coordinator"),(select id from regional_staffer_user where password_reset_email_address = "william@easternemscouncil.org")),
((select id from regional_staffer_group where name = "education-specialist"),(select id from regional_staffer_user where password_reset_email_address = "sally@easternemscouncil.org"))
;
update coned_sponsor_user
  join teaching_entity using (id)
set be_ok_to_input_roster_by_batch = TRUE
, be_ok_to_input_roster_by_copy = TRUE
where name = "Eastern Pennsylvania EMS Council, Inc."
;
update coned_sponsor_user
  join teaching_entity using (id)
set be_ok_to_input_roster_by_copy = TRUE
where name = "City of Reading Dept. of Fire Rescue Services"
;
COMMIT