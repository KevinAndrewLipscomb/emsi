START TRANSACTION
;
update coned_sponsor_user
  join teaching_entity using (id)
set be_ok_to_input_roster_by_copy = FALSE
where name is null or name not in
  (
    "Susquehanna EHS Council, Inc."
  ,
    "Eastern Pennsylvania EMS Council, Inc."
  ,
    "City of Reading Dept. of Fire Rescue Services"
  ,
    "City of Pittsburgh, Bureau of EMS"
  ,
    "Pittsburgh Bureau of Fire"
  ,
    "Emergency Medical Service Institute"
  ,
    "City of Reading Dept. of Fire Rescue Services"
  )
;
COMMIT