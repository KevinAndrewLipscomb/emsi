START TRANSACTION
;
insert ignore regional_staffer (region_code,last_name,first_name) values
((select code from region_code_name_map where name = "Montgomery County"),"Brown","Dave"),
((select code from region_code_name_map where name = "Montgomery County"),"DeShon","Margaret"),
((select code from region_code_name_map where name = "Montgomery County"),"Schulberger","Susan"),
((select code from region_code_name_map where name = "Montgomery County"),"Pasquale","Brian"),
((select code from region_code_name_map where name = "Montgomery County"),"Dunigan","Timothy")
;
insert ignore regional_staffer_user (id,password_reset_email_address) values
((select id from regional_staffer where first_name = "Dave" and last_name = "Brown"),"dbrown@montcopa.org"),
((select id from regional_staffer where first_name = "Margaret" and last_name = "DeShon"),"Mdeshon@montcopa.org"),
((select id from regional_staffer where first_name = "Susan" and last_name = "Schulberger"),"SSchulbe@montcopa.org"),
((select id from regional_staffer where first_name = "Brian" and last_name = "Pasquale"),"Bpasqual@montcopa.org"),
((select id from regional_staffer where first_name = "Timothy" and last_name = "Dunigan"),"tdunigan@montcopa.org")
;
insert ignore regional_staffer_role (group_id,user_id) values
((select id from regional_staffer_group where name = "director"),(select id from regional_staffer_user where password_reset_email_address = "dbrown@montcopa.org")),
((select id from regional_staffer_group where name = "education-coordinator"),(select id from regional_staffer_user where password_reset_email_address = "Mdeshon@montcopa.org")),
((select id from regional_staffer_group where name = "education-reservist"),(select id from regional_staffer_user where password_reset_email_address = "SSchulbe@montcopa.org")),
((select id from regional_staffer_group where name = "education-specialist"),(select id from regional_staffer_user where password_reset_email_address = "Bpasqual@montcopa.org")),
((select id from regional_staffer_group where name = "education-reservist"),(select id from regional_staffer_user where password_reset_email_address = "tdunigan@montcopa.org"))
;
update region_code_name_map set be_conedlink_subscriber = TRUE where name = "Montgomery County"
;
COMMIT
