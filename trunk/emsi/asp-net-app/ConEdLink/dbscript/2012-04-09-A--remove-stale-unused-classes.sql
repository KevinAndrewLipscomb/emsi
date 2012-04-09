START TRANSACTION
;
delete from coned_offering where end_date_time < "2012-02-09" and (select count(*) from coned_offering_roster where coned_offering_id = coned_offering.id) = 0
;
COMMIT