@REM
@REM $Id$
@REM
@rmdir ready-to-deploy /s /q
@REM-cmd--sourcedir----------------------------------------------------------------destdir-----------------------------------------[files]-------------------qualifiers
@robocopy C:\Inetpub\wwwroot\WebEMSOF                                              ready-to-deploy                                 *.asax                    /m /np /z
@robocopy C:\Inetpub\wwwroot\WebEMSOF                                              ready-to-deploy                                 *.aspx                    /m /np /z
@robocopy C:\Inetpub\wwwroot\WebEMSOF                                              ready-to-deploy                                 *.config                  /m /np /z
@robocopy C:\Inetpub\wwwroot\WebEMSOF                                              ready-to-deploy                                 *.pdf                     /m /np /z
@robocopy C:\Inetpub\wwwroot\WebEMSOF\bin                                          ready-to-deploy\bin                                                       /m /np /z
@robocopy C:\Inetpub\wwwroot\WebEMSOF\noninteractive                               ready-to-deploy\noninteractive                  *.crontab                 /m /np /z
@robocopy C:\Inetpub\wwwroot\WebEMSOF\noninteractive                               ready-to-deploy\noninteractive                  *.aspx                    /m /np /z
@robocopy C:\Inetpub\wwwroot\WebEMSOF\protected                                    ready-to-deploy\protected                       *.asax                    /m /np /z
@robocopy C:\Inetpub\wwwroot\WebEMSOF\protected                                    ready-to-deploy\protected                       *.aspx                    /m /np /z
@robocopy C:\Inetpub\wwwroot\WebEMSOF\protected                                    ready-to-deploy\protected                       *.config                  /m /np /z
@robocopy C:\Inetpub\wwwroot\WebEMSOF\protected\image                              ready-to-deploy\protected\image                                           /m /np /z
@robocopy C:\Inetpub\wwwroot\WebEMSOF\protected\template\notification              ready-to-deploy\protected\template\notification                           /m /np /z
@robocopy C:\Inetpub\wwwroot\WebEMSOF\resource                                     ready-to-deploy\resource                                                  /m /np /z
@robocopy C:\Inetpub\wwwroot\WebEMSOF\usercontrol\app                              ready-to-deploy\usercontrol\app                 *.ascx                    /m /np /z
@robocopy C:\Inetpub\wwwroot\WebEMSOF\usercontrol\ki                               ready-to-deploy\usercontrol\ki                  *.ascx                    /A /np /z
@robocopy "C:\Program Files\Common Files\Borland Shared\BDS\Shared Assemblies\4.0" ready-to-deploy\bin                             Borland.Data.Provider.dll /m /np /z
@robocopy "C:\Program Files\Common Files\Borland Shared\BDS\Shared Assemblies\4.0" ready-to-deploy\bin                             Borland.Data.Common.dll   /m /np /z
@robocopy "C:\Program Files\Common Files\Borland Shared\BDS\Shared Assemblies\4.0" ready-to-deploy\bin                             Borland.Delphi.dll        /m /np /z
@robocopy "C:\Program Files\CoreLab\Bdp\MySql\BDS4"                                ready-to-deploy\bin                             CoreLab.Bdp.MySql.dll     /m /np /z
