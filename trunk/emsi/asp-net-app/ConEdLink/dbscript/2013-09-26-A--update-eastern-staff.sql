START TRANSACTION
;
insert ignore regional_staffer (region_code,last_name,first_name) values
((select code from region_code_name_map where name = "Eastern"),"Garrity","Lisa")
;
insert ignore regional_staffer_user (id,password_reset_email_address) values
((select id from regional_staffer where first_name = "Lisa" and last_name = "Garrity"),"lisagarrity@easternemscouncil.org")
;
insert ignore regional_staffer_role (group_id,user_id) values
((select id from regional_staffer_group where name = "education-specialist"),(select id from regional_staffer_user where password_reset_email_address = "lisagarrity@easternemscouncil.org"))
;
update regional_staffer_user set be_active = FALSE where id in (6,9)
;
COMMIT