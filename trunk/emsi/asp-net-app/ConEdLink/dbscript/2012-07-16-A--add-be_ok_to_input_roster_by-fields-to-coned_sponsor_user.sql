START TRANSACTION
;
ALTER TABLE `coned_sponsor_user`
  ADD COLUMN `be_ok_to_input_roster_by_batch` BOOLEAN NOT NULL DEFAULT FALSE
,
  ADD COLUMN `be_ok_to_input_roster_by_copy` BOOLEAN NOT NULL DEFAULT FALSE
;
update coned_sponsor_user
  join teaching_entity on (teaching_entity.id=coned_sponsor_user.id)
set be_ok_to_input_roster_by_batch = TRUE
, be_ok_to_input_roster_by_copy = TRUE
where name = "Emergency Medical Service Institute"
;
COMMIT