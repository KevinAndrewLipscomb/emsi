START TRANSACTION
;
delete from role_member_map
where role_id = (select id from role where name = 'Region Strike Team Manager')
  and region_code = (select code from region_code_name_map where name = 'PA DOH EMSB')
  and member_id = (select id from member where certification_number = '011751')
;
delete from role_member_map
where role_id = (select id from role where name = 'Region Strike Team Manager')
  and region_code = (select code from region_code_name_map where name = 'PA DOH EMSB')
  and member_id = (select id from member where certification_number = '053903')
;
delete from role_member_map
where role_id = (select id from role where name = 'Region Strike Team Manager')
  and region_code = (select code from region_code_name_map where name = 'PA DOH EMSB')
  and member_id = (select id from member where certification_number = '150071')
;
update region_code_name_map set be_pacrat_subscriber = FALSE where name = 'PA DOH EMSB'
;
insert ignore role_member_map set member_id = (select id from member where certification_number = '053903'), role_id = (select id from role where name = 'State Strike Team Examiner')
;
insert ignore role_member_map set member_id = (select id from member where certification_number = '150071'), role_id = (select id from role where name = 'State Strike Team Examiner')
;
insert ignore role_member_map set member_id = (select id from member where certification_number = '060769'), role_id = (select id from role where name = 'State Strike Team Examiner')
;
COMMIT
