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
pause
