START TRANSACTION
;
insert ignore coned_offering_status (description) values
("SPONSOR_SAYS_CANCELED"),
("SPONSOR_SAYS_RAN_NO_CE"),
("SPONSOR_SAYS_ALREADY_SUBMITTED")
;
COMMIT