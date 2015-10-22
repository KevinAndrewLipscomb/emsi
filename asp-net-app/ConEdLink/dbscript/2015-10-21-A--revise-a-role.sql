START TRANSACTION
;
insert ignore regional_staffer_role
set user_id = 12
, group_id = 9
;
COMMIT
