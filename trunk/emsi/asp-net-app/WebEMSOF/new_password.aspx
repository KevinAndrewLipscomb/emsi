<%@ Page language="c#" Debug="true" Codebehind="new_password.aspx.cs" AutoEventWireup="True" Inherits="new_password.TWebForm_new_password" %>
<%@ Register TagPrefix="uc1" TagName="UserControl_precontent" Src="~/usercontrol/app/UserControl_precontent.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UserControl_postcontent" Src="~/usercontrol/app/UserControl_postcontent.ascx" %>
<!DOCTYPE HTML>

<%@ Register TagPrefix="uc2" TagName="UserControl_update_progress_blocker" Src="~/usercontrol/app/UserControl_update_progress_blocker.ascx" %>
<html>
  <head runat="server">
	  <title></title>
	  <!-- $Id$ -->
    <link href="css/standard.css" rel="stylesheet" type="text/css" />
    <!--[if lt IE 7]> <style type="text/css">@import "css/standard-overrides-for-ie6.css";</style><![endif]-->
  </head>

  <body bgcolor="white">
     <form runat="server">
      <p>
      <uc1:UserControl_precontent id="UserControl_precontent" runat="server"></uc1:UserControl_precontent></p>
      <p>
        <ASP:Label id="Label_user_name" runat="server" font-bold="True" font-size="Large"></ASP:Label></p>
      <p>
        <table bordercolor="#dcdcdc" cellspacing="0" cellpadding="0" border="1">
            <tr>
              <td>
                <table cellspacing="0" cellpadding="5" border="0">
                    <tr>
                      <td bgcolor="#f5f5f5"><strong>New password</strong></td>
                    </tr>
                    <tr>
                      <td>A temporary password has been sent to 
                <ASP:Label id="Label_email_address" runat="server" font-bold="True"></ASP:Label>.&nbsp; Please&nbsp;<ASP:HyperLink id="HyperLink_login" runat="server" navigateurl="login.aspx" font-bold="True">log in</ASP:HyperLink> again after you receive it.&nbsp; You will receive further instructions at that time.</td>
                    </tr>
                </table></td>
            </tr>
        </table></p>
      <p>
        &nbsp;<uc1:UserControl_postcontent id="UserControl_postcontent" runat="server"></uc1:UserControl_postcontent></p>
      <uc2:UserControl_update_progress_blocker id="UserControl_update_progress_blocker_control" runat="server"></uc2:UserControl_update_progress_blocker>
    </form>
  </body>
</html>
