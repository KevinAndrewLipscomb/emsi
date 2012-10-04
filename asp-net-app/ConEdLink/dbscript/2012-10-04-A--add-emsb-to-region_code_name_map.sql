START TRANSACTION
;
insert ignore region_code_name_map
set name = "PA DOH EMSB"
 , emsrs_code = 88
 , emsrs_active_practitioners_name = "Bureau of Emergency Medical Services"
;
COMMIT