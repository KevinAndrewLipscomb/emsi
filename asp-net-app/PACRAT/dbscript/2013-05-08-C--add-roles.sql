START TRANSACTION
;
insert ignore role (name,pecking_order) values
("State Strike Team Manager",15000),
("Region Strike Team Manager",25000),
("Service Strike Team Manager",35000),
("Strike Team Member",45000)
;
COMMIT