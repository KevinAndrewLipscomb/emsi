@REM $Id$
@REM
set base_db_name=emsidb
set the_host=localhost
set the_user=root
if "%1"=="d" set db_instance=%base_db_name%_d
if "%1"=="x" set db_instance=%base_db_name%_x
if "%1"=="p" set db_instance=%base_db_name%
echo on
mysql --host=%the_host% --user=%the_user% --password=%2 --database=%db_instance% <2012-01-24-A--add-missing-integrity-constraints.sql
mysql --host=%the_host% --user=%the_user% --password=%2 --database=%db_instance% <2012-01-24-B--improve-consistency.sql
mysql --host=%the_host% --user=%the_user% --password=%2 --database=%db_instance% <2013-04-18-A--recreate-member-view.sql
mysql --host=%the_host% --user=%the_user% --password=%2 --database=%db_instance% <2013-04-21-A--track-pacrat-subscriptions.sql
mysql --host=%the_host% --user=%the_user% --password=%2 --database=%db_instance% <2013-05-08-C--add-roles.sql
mysql --host=%the_host% --user=%the_user% --password=%2 --database=%db_instance% <2013-05-09-A--add-role_member_map-scope-columns.sql
mysql --host=%the_host% --user=%the_user% --password=%2 --database=%db_instance% <2013-05-10-A--establish-tiers.sql
mysql --host=%the_host% --user=%the_user% --password=%2 --database=%db_instance% <2013-05-17-A--add-strike-team-config-privileges.sql
mysql --host=%the_host% --user=%the_user% --password=%2 --database=%db_instance% <2013-05-18-A--add-be_strike_team_participant-field-to-service-table.sql
mysql --host=%the_host% --user=%the_user% --password=%2 --database=%db_instance% <2013-05-18-B--create-strike_team_roster-table.sql
mysql --host=%the_host% --user=%the_user% --password=%2 --database=%db_instance% <2013-05-25-A--create-table-practitioner_strike_team_detail.sql
mysql --host=%the_host% --user=%the_user% --password=%2 --database=%db_instance% <2013-06-06-A--create-table-strike_team_deployment.sql
mysql --host=%the_host% --user=%the_user% --password=%2 --database=%db_instance% <2013-06-13-A--create-table-strike_team_deployment_member.sql
mysql --host=%the_host% --user=%the_user% --password=%2 --database=%db_instance% <2013-06-13-B--create-table-strike_team_deployment_operational_period.sql
mysql --host=%the_host% --user=%the_user% --password=%2 --database=%db_instance% <2013-06-20-A--create-table-vehicle.sql
mysql --host=%the_host% --user=%the_user% --password=%2 --database=%db_instance% <2013-06-17-A--create-table-strike_team_deployment_vehicle.sql
pause
