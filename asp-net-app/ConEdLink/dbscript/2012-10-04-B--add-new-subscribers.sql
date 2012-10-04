START TRANSACTION
;
--
-- The Federation wants to phase in their subscription such that regional staffers can log in first and sponsors must wait until later.
--
update coned_sponsor_user
  join teaching_entity using (id)
  join region_code_name_map on (region_code_name_map.emsrs_code=teaching_entity.region)
set be_active = FALSE
where region_code_name_map.name = "Federation"
;
update region_code_name_map
set be_conedlink_subscriber = TRUE
where name = "Federation"
;
insert ignore regional_staffer (region_code,last_name,first_name) values
((select code from region_code_name_map where name = "Federation"),"Powell","Ernie"),
((select code from region_code_name_map where name = "Federation"),"Mackey","Jean"),
((select code from region_code_name_map where name = "Federation"),"Guerra","Mike"),
((select code from region_code_name_map where name = "Federation"),"Christie","Ann Marie")
;
insert ignore regional_staffer_user (id,password_reset_email_address) values
((select id from regional_staffer where first_name = "Ernie" and last_name = "Powell"),"epowell@ehsf.org"),
((select id from regional_staffer where first_name = "Jean" and last_name = "Mackey"),"jmackey@ehsf.org"),
((select id from regional_staffer where first_name = "Mike" and last_name = "Guerra"),"mguerra@ehsf.org"),
((select id from regional_staffer where first_name = "Ann Marie" and last_name = "Christie"),"amchristie@ehsf.org")
;
insert ignore regional_staffer_role (group_id,user_id) values
((select id from regional_staffer_group where name = "education-coordinator"),(select id from regional_staffer_user where password_reset_email_address = "epowell@ehsf.org")),
((select id from regional_staffer_group where name = "education-specialist"),(select id from regional_staffer_user where password_reset_email_address = "jmackey@ehsf.org")),
((select id from regional_staffer_group where name = "education-specialist"),(select id from regional_staffer_user where password_reset_email_address = "mguerra@ehsf.org")),
((select id from regional_staffer_group where name = "education-specialist"),(select id from regional_staffer_user where password_reset_email_address = "amchristie@ehsf.org"))
;
update coned_sponsor_user
  join teaching_entity using (id)
set be_ok_to_input_roster_by_batch = TRUE
, be_ok_to_input_roster_by_copy = TRUE
where name = "Emergency Health Services Federation"
;
COMMIT