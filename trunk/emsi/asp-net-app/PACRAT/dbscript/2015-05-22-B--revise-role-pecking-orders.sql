START TRANSACTION
;
UPDATE `role` SET `pecking_order`='16000' WHERE name = 'State Strike Team Manager'
;
UPDATE `role` SET `pecking_order`='10000' WHERE name = 'State Strike Team Executive'
;
COMMIT