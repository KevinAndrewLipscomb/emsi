START TRANSACTION
;
INSERT ignore INTO county_code_name_map (name,default_match_level_id,emsrs_code) VALUES
('OUTOFSTATE','1','68')
;
INSERT ignore INTO county_region_map (county_code,region_code) VALUES
((select code from county_code_name_map where name = 'OUTOFSTATE'),(select code from region_code_name_map where name = 'PA DOH EMSB'))
;
INSERT ignore INTO service
(county_code,affiliate_num,name,           short_name,corpadmin_contact_name,corpadmin_primary_phone_num,be_emsof_participant,coo_name,   coo_work_phone_num,physical_street_address_line_1,physical_city,physical_state,physical_zip_code,mail_address_line_1, mail_city,mail_state,mail_zip_code,num_doh_licensed_vehicles,num_ambulances,be_qrs_unrecognized,be_rescue_unrecognized,strike_team_participation_level_id)
VALUES
((select code from county_code_name_map where name = 'OUTOFSTATE'),       '68036',      'New York',     'NY',      '',                    '',                         FALSE,               '',         '',                '',                            '',           'NY',          '',               '',                  '',       'NY',      '',           '0',                      '0',           FALSE,              FALSE,                 '2'),
((select code from county_code_name_map where name = 'OUTOFSTATE'),       '68034',      'New Jersey',   'NJ',      '',                    '',                         FALSE,               '',         '',                '',                            '',           'NJ',          '',               '',                  '',       'NJ',      '',           '0',                      '0',           FALSE,              FALSE,                 '2'),
((select code from county_code_name_map where name = 'OUTOFSTATE'),       '68010',      'Delaware',     'DE',      '',                    '',                         FALSE,               '',         '',                '',                            '',           'DE',          '',               '',                  '',       'DE',      '',           '0',                      '0',           FALSE,              FALSE,                 '2'),
((select code from county_code_name_map where name = 'OUTOFSTATE'),       '68024',      'Maryland',     'MD',      '',                    '',                         FALSE,               '',         '',                '',                            '',           'MD',          '',               '',                  '',       'MD',      '',           '0',                      '0',           FALSE,              FALSE,                 '2'),
((select code from county_code_name_map where name = 'OUTOFSTATE'),       '68054',      'West Virginia','WV',      '',                    '',                         FALSE,               '',         '',                '',                            '',           'WV',          '',               '',                  '',       'WV',      '',           '0',                      '0',           FALSE,              FALSE,                 '2'),
((select code from county_code_name_map where name = 'OUTOFSTATE'),       '68039',      'Ohio',         'OH',      '',                    '',                         FALSE,               '',         '',                '',                            '',           'OH',          '',               '',                  '',       'OH',      '',           '0',                      '0',           FALSE,              FALSE,                 '2')
;
update region_code_name_map set be_pacrat_subscriber = TRUE where name = 'PA DOH EMSB'
;
COMMIT
