START TRANSACTION
;
update teaching_entity set contact_email = null
, public_contact_email = null
;
COMMIT