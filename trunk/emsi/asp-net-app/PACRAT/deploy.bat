@REM
@REM $Id$
@REM
@rmdir ready-to-deploy /s /q
@REM      sourcedir----------------------------------------------------------------destdir-----------------------------------------[files]---quals---------filter--------
@robocopy C:\Inetpub\wwwroot\PACRAT                                  ready-to-deploy                                 *.asax    /m /np /ns /z | qgrep "New "
@robocopy C:\Inetpub\wwwroot\PACRAT                                  ready-to-deploy                                 *.aspx    /m /np /ns /z | qgrep "New "
@robocopy C:\Inetpub\wwwroot\PACRAT                                  ready-to-deploy                                 *.pdf     /m /np /ns /z | qgrep "New "
@robocopy C:\Inetpub\wwwroot\PACRAT\bin                              ready-to-deploy\bin                             *.dll     /m /np /ns /z | qgrep "New "
@robocopy C:\Inetpub\wwwroot\PACRAT\bin                              ready-to-deploy\bin                             *.pdb     /m /np /ns /z | qgrep "New "
@robocopy C:\Inetpub\wwwroot\PACRAT\bin                              ready-to-deploy\bin                             *.TTF     /m /np /ns /z | qgrep "New "
@robocopy C:\Inetpub\wwwroot\PACRAT\css                              ready-to-deploy\css                                       /m /np /ns /z | qgrep "New "
@robocopy C:\Inetpub\wwwroot\PACRAT\image                            ready-to-deploy\image                                     /m /np /ns /z | qgrep "New "
@robocopy C:\Inetpub\wwwroot\PACRAT\js                               ready-to-deploy\js                                        /m /np /ns /z | qgrep "New "
@robocopy C:\Inetpub\wwwroot\PACRAT\noninteractive                   ready-to-deploy\noninteractive                  *.crontab /m /np /ns /z | qgrep "New "
@robocopy C:\Inetpub\wwwroot\PACRAT\noninteractive                   ready-to-deploy\noninteractive                  *.aspx    /m /np /ns /z | qgrep "New "
@robocopy C:\Inetpub\wwwroot\PACRAT\protected                        ready-to-deploy\protected                       *.asax    /m /np /ns /z | qgrep "New "
@robocopy C:\Inetpub\wwwroot\PACRAT\protected                        ready-to-deploy\protected                       *.aspx    /m /np /ns /z | qgrep "New "
@robocopy C:\Inetpub\wwwroot\PACRAT\protected                        ready-to-deploy\protected                       *.config  /m /np /ns /z | qgrep "New "
@robocopy C:\Inetpub\wwwroot\PACRAT\protected\image                  ready-to-deploy\protected\image                           /m /np /ns /z | qgrep "New "
@robocopy C:\Inetpub\wwwroot\PACRAT\protected\template\notification  ready-to-deploy\protected\template\notification           /m /np /ns /z | qgrep "New "
@robocopy C:\Inetpub\wwwroot\PACRAT\resource                         ready-to-deploy\resource                                  /m /np /ns /z | qgrep "New "
@robocopy C:\Inetpub\wwwroot\PACRAT\template\notification            ready-to-deploy\template\notification                     /m /np /ns /z | qgrep "New "
@robocopy C:\Inetpub\wwwroot\PACRAT\usercontrol\app                  ready-to-deploy\usercontrol\app                 *.ascx    /m /np /ns /z | qgrep "New "
@robocopy C:\Inetpub\wwwroot\PACRAT\usercontrol\ki                   ready-to-deploy\usercontrol\ki                  *.ascx    /A /np /ns /z | qgrep "New "
@robocopy C:\Inetpub\wwwroot\PACRAT\usercontrol\ki\image             ready-to-deploy\usercontrol\ki\image                      /A /np /ns /z | qgrep "New "
@pause