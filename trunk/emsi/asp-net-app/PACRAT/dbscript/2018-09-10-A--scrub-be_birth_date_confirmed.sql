START TRANSACTION
;
update associate
set be_birth_date_confirmed = FALSE
where birth_date is null
  and be_birth_date_confirmed
;
COMMIT
