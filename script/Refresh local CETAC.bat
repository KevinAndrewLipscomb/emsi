rem
rem $Id$
rem
if not exist c:\cetac mkdir c:\CETAC
if not exist c:\cetac\bats mkdir c:\CETAC\BATS
copy \\emsi-scanner\D\cetac\*.* c:\cetac /y
copy \\emsi-scanner\D\cetac\bats\*.* c:\cetac\bats /y
