START TRANSACTION
;
insert ignore regional_staffer (region_code,last_name,first_name) values
((select code from region_code_name_map where name = "EMMCO West"),"McClincy","Bill"),
((select code from region_code_name_map where name = "EMMCO West"),"Irwin","Kaylen"),
((select code from region_code_name_map where name = "EMMCO West"),"Eaton","Michelle")
;
insert ignore regional_staffer_user (id,password_reset_email_address) values
((select id from regional_staffer where first_name = "Bill" and last_name = "McClincy"),"bill@emmco.org"),
((select id from regional_staffer where first_name = "Kaylen" and last_name = "Irwin"),"support@emmco.org"),
((select id from regional_staffer where first_name = "Michelle" and last_name = "Eaton"),"michelle@emmco.org")
;
insert ignore regional_staffer_role (group_id,user_id) values
((select id from regional_staffer_group where name = "director"),(select id from regional_staffer_user where password_reset_email_address = "bill@emmco.org")),
((select id from regional_staffer_group where name = "education-coordinator"),(select id from regional_staffer_user where password_reset_email_address = "support@emmco.org")),
((select id from regional_staffer_group where name = "education-specialist"),(select id from regional_staffer_user where password_reset_email_address = "michelle@emmco.org"))
;
update region_code_name_map set be_conedlink_subscriber = TRUE where name = "EMMCO West"
;
COMMIT
