START TRANSACTION
;
insert ignore regional_staffer_group set name = "education-reservist"
;
update regional_staffer_role
  join regional_staffer_user on (regional_staffer_user.id=regional_staffer_role.user_id)
  join regional_staffer on (regional_staffer.id=regional_staffer_user.id)
  join regional_staffer_group on (regional_staffer_group.id=regional_staffer_role.group_id)
set
  group_id = (select id from regional_staffer_group where name = "education-reservist")
where (first_name = "Robbin" and last_name = "Cessna")
;
COMMIT