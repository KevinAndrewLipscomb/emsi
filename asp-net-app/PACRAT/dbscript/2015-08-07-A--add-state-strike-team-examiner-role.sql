START TRANSACTION
;
insert ignore role set name = 'State Strike Team Examiner'
, pecking_order = 5000
, tier_id = (select id from tier where name = 'State')
;
insert ignore privilege set name = 'see-all-strike-team-data'
;
insert ignore role_privilege_map (role_id,privilege_id) values
((select id from role where name = 'State Strike Team Examiner'),(select id from privilege where name = 'see-all-strike-team-data'))
;
COMMIT
