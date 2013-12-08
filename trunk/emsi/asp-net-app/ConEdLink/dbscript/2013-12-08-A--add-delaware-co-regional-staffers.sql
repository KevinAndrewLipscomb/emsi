START TRANSACTION
;
insert ignore regional_staffer (region_code,last_name,first_name) values
((select code from region_code_name_map where name = "Delaware County"),"Hennessy Herman","Maureen"),
((select code from region_code_name_map where name = "Delaware County"),"Steigerwalt","Janet"),
((select code from region_code_name_map where name = "Delaware County"),"Koerner","Danielle"),
((select code from region_code_name_map where name = "Delaware County"),"Holm","Bob")
;
insert ignore regional_staffer_user (id,password_reset_email_address) values
((select id from regional_staffer where first_name = "Maureen" and last_name = "Hennessy Herman"),"hennesseyhermanm@co.delaware.pa.us"),
((select id from regional_staffer where first_name = "Janet" and last_name = "Steigerwalt"),"steigerwaltj@co.delaware.pa.us"),
((select id from regional_staffer where first_name = "Danielle" and last_name = "Koerner"),"koernerd@co.delaware.pa.us"),
((select id from regional_staffer where first_name = "Bob" and last_name = "Holm"),"holmr@co.delaware.pa.us")
;
insert ignore regional_staffer_role (group_id,user_id) values
((select id from regional_staffer_group where name = "director"),(select id from regional_staffer_user where password_reset_email_address = "hennesseyhermanm@co.delaware.pa.us")),
((select id from regional_staffer_group where name = "education-coordinator"),(select id from regional_staffer_user where password_reset_email_address = "koernerd@co.delaware.pa.us")),
((select id from regional_staffer_group where name = "education-specialist"),(select id from regional_staffer_user where password_reset_email_address = "steigerwaltj@co.delaware.pa.us")),
((select id from regional_staffer_group where name = "education-specialist"),(select id from regional_staffer_user where password_reset_email_address = "holmr@co.delaware.pa.us"))
;
COMMIT