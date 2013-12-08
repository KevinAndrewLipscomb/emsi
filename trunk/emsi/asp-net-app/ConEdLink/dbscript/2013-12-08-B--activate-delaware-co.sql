START TRANSACTION
;
update region_code_name_map set be_conedlink_subscriber = TRUE where name = "Delaware County"
;
COMMIT