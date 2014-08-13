START TRANSACTION
;
insert ignore practitioner_level (short_description,emsrs_practitioner_level_description,pecking_order,emsrs_code) values
("MCFMD","MC Facility Med Dir",120,5)
;
update practitioner_level set short_description = 'MCP' where short_description = 'MCMD'
;
COMMIT