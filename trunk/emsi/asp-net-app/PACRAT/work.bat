REM
REM $Id$
REM
cd "C:\Inetpub\wwwroot\PACRAT"
start /max explorer /e,/select,C:\Inetpub\wwwroot\PACRAT\.svn
start /max PACRAT.sln
start "" /max "C:\Program Files\MySQL\MySQL Workbench CE 5.2.47\MySQLWorkbench.exe"
