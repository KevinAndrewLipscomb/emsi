START TRANSACTION
;
drop view if exists member
;
create or replace view member as
select *
from practitioner
;
COMMIT