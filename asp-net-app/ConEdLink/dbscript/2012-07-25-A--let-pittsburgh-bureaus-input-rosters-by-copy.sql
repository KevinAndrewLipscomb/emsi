START TRANSACTION
;
update coned_sponsor_user
  join teaching_entity using (id)
set be_ok_to_input_roster_by_copy = TRUE
where name like "%Pittsburgh%Bureau%" 
;
COMMIT