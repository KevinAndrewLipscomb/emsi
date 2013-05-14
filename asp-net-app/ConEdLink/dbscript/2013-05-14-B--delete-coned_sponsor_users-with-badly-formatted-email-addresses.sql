START TRANSACTION
;
delete from coned_sponsor_user where password_reset_email_address not like "%@%.%"
;
COMMIT