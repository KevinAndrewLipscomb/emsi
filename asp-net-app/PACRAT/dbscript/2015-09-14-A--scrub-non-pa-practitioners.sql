START TRANSACTION
;
update member set be_practitioner = FALSE where certification_number is null
;
COMMIT
