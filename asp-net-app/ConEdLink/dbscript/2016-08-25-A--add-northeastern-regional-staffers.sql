START TRANSACTION
;
insert ignore regional_staffer (region_code,last_name,first_name) values
((select code from region_code_name_map where name = "Northeastern"),"Campos","John"),
((select code from region_code_name_map where name = "Northeastern"),"Striefsky","Stanley"),
((select code from region_code_name_map where name = "Northeastern"),"Quinn","Edwin"),
((select code from region_code_name_map where name = "Northeastern"),"Zongila","Kathy")
;
insert ignore regional_staffer_user (id,password_reset_email_address) values
((select id from regional_staffer where first_name = "John" and last_name = "Campos"),"jcampos@emsnp.org"),
((select id from regional_staffer where first_name = "Stanley" and last_name = "Striefsky"),"sstriefsky@emsnp.org"),
((select id from regional_staffer where first_name = "Edwin" and last_name = "Quinn"),"equinn@emsnp.org"),
((select id from regional_staffer where first_name = "Kathy" and last_name = "Zongila"),"kzongila@emsnp.org")
;
insert ignore regional_staffer_role (group_id,user_id) values
((select id from regional_staffer_group where name = "director"),(select id from regional_staffer_user where password_reset_email_address = "jcampos@emsnp.org")),
((select id from regional_staffer_group where name = "education-coordinator"),(select id from regional_staffer_user where password_reset_email_address = "sstriefsky@emsnp.org")),
((select id from regional_staffer_group where name = "education-specialist"),(select id from regional_staffer_user where password_reset_email_address = "equinn@emsnp.org")),
((select id from regional_staffer_group where name = "education-reservist"),(select id from regional_staffer_user where password_reset_email_address = "kzongila@emsnp.org"))
;
COMMIT
