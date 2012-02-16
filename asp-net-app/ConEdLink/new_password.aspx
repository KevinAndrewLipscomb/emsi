<%@ Page language="c#" Debug="true" Codebehind="new_password.aspx.cs" AutoEventWireup="True" Inherits="new_password.TWebForm_new_password" %>
<%@ Register TagPrefix="uc1" TagName="UserControl_precontent" Src="~/usercontrol/app/UserControl_precontent.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UserControl_postcontent" Src="~/usercontrol/app/UserControl_postcontent.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/strict.dtd">

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
      <asp:Panel ID="Panel_done" runat="server">
        <p>
          <table bordercolor="#dcdcdc" cellspacing="0" cellpadding="0" border="1">
            <tr>
              <td>
                <table cellspacing="0" cellpadding="5" border="0">
                  <tr><td bgcolor="#f5f5f5"><strong>New password</strong></td></tr>
                  <tr>
                    <td>
                      A temporary password has been sent to <ASP:Label id="Label_valid_email_address" runat="server" font-bold="True"></ASP:Label>.&nbsp;
                      Please&nbsp;<ASP:HyperLink id="HyperLink_login" runat="server" navigateurl="login.aspx" font-bold="True">log in</ASP:HyperLink> again after you receive it.&nbsp; You will receive further instructions at
                      that time.
                    </td>
                  </tr>
                </table>
              </td>
            </tr>
          </table>
        </p>
      </asp:Panel>
     <asp:Panel ID="Panel_blocked" runat="server" Visible="False">
        <p>
          <table bordercolor="#dcdcdc" cellspacing="0" cellpadding="0" border="1">
            <tr>
              <td>
                <table cellspacing="0" cellpadding="5" border="0">
                  <tr><td bgcolor="#f5f5f5" style="color: #FF0000"><strong><em>Blocked!</em></strong></td></tr>
                  <tr>
                    <td>
                      <p>
                        The email address...
                        <blockquote><ASP:Label id="Label_invalid_email_address" runat="server" font-bold="True"></ASP:Label></blockquote>
                        that <asp:Label ID="Label_application_name" runat="server"></asp:Label> imported from EMSRS for the
                        specified Con Ed Sponsor is <strong>INVALID</strong>.&nbsp; You must
                        <strong><asp:HyperLink ID="HyperLink_emsrs" runat="server" NavigateUrl="https://ems.health.state.pa.us/emsportal" Target="_blank"> set all your email addresses correctly in EMSRS</asp:HyperLink></strong> before
                        you can use <asp:Label ID="Label_application_name_2" runat="server"></asp:Label>.
                      </p>
                      <p>
                        Also note that changes made in EMSRS are not recognized in <asp:Label ID="Label_application_name_3" runat="server"></asp:Label> until <asp:Label ID="Label_application_name_4" runat="server"></asp:Label>
                        performs its next import (for instance, the next calendar day).
                      </p>
                    </td>
                  </tr>
                </table>
              </td>
            </tr>
          </table>
        </p>
     </asp:Panel>
      <p>
        &nbsp;<uc1:UserControl_postcontent id="UserControl_postcontent" runat="server"></uc1:UserControl_postcontent></p>
      <uc2:UserControl_update_progress_blocker id="UserControl_update_progress_blocker_control" runat="server"></uc2:UserControl_update_progress_blocker>
    </form>
  </body>
</html>
