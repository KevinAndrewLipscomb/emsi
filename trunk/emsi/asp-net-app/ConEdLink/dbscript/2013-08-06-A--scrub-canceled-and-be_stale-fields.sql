START TRANSACTION
;
update coned_offering
set class_final_status_id = null
, be_stale = FALSE
where class_final_status_id = (select id from coned_offering_class_final_status where short_description = 'CANCELED')
  and be_stale = TRUE
  and start_date_time < SUBDATE(CURDATE(),INTERVAL 6 MONTH)
  and status_id <> (select id from coned_offering_status where description = 'NEEDS_CONED_SPONSOR_FINALIZATION')
  and (select count(practitioner_id) from coned_offering_roster where coned_offering_roster.coned_offering_id = coned_offering.id) > 0
;
COMMIT