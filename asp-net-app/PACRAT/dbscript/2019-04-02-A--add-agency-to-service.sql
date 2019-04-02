START TRANSACTION
;
insert ignore service
set county_code = (select code from county_code_name_map where name = 'Adams')
, affiliate_num = '04253'
, name = 'Adams Regional Emergency Medical Services'
, short_name = 'Adams Regional'
, strike_team_participation_level_id = (select id from strike_team_participation_level where description = 'Standing')
;
COMMIT