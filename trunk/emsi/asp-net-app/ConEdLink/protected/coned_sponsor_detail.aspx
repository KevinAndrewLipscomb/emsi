<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/strict.dtd">
<!-- Derived from KiAspdotnetFramework/protected/template~protected~nonlanding.aspx~template -->
<%@ Page language="c#" Debug="true" Codebehind="coned_sponsor_detail.aspx.cs" AutoEventWireup="True" Inherits="coned_sponsor_detail.TWebForm_coned_sponsor_detail" %>
<%@ Register TagPrefix="uc1" TagName="UserControl_precontent" Src="~/usercontrol/app/UserControl_precontent.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UserControl_postcontent" Src="~/usercontrol/app/UserControl_postcontent.ascx" %>
<%@ Register TagPrefix="uc3" TagName="UserControl_update_progress_blocker" Src="~/usercontrol/app/UserControl_update_progress_blocker.ascx" %>
<%@ Register src="../usercontrol/app/UserControl_coned_sponsor.ascx" tagname="UserControl_coned_sponsor" tagprefix="uc2" %>
<%@ Register src="../usercontrol/app/UserControl_coned_sponsor_user.ascx" tagname="UserControl_coned_sponsor_user" tagprefix="uc4" %>
<html>
  <head runat="server">
    <title></title>
    <!-- $Id$ -->
    <link href="../css/standard.css" rel="stylesheet" type="text/css" />
    <!--[if lt IE 7]> <style type="text/css">@import "../css/standard-overrides-for-ie6.css";</style><![endif]-->
  </head>
  <body bgcolor="white">
    <form runat="server">
      <uc1:UserControl_precontent id="UserControl_precontent" runat="server"></uc1:UserControl_precontent>
      <h2>Sponsor:&nbsp;&nbsp;<i><asp:Literal ID="Literal_sponsor_name" runat="server"></asp:Literal></i></h2>
      <table border="1" bordercolor="gainsboro" cellpadding="0" cellspacing="0" width="100%">
        <tr>
          <td>
            <table cellpadding="10" cellspacing="0" width="100%">
              <tr>
                <td bgcolor="whitesmoke">
                  <h3><asp:Literal ID="Literal_application_name" runat="server"></asp:Literal> profile attributes</h3>
                  <small>These attributes are managed in real-time by <asp:Literal ID="Literal_application_name_2" runat="server"></asp:Literal>.</small>
                </td>
              </tr>
              <tr><td><uc4:UserControl_coned_sponsor_user ID="UserControl_coned_sponsor_user_control" runat="server" /></td></tr>
            </table>
          </td>
        </tr>
      </table>
      <br />
      <table border="1" bordercolor="gainsboro" cellpadding="0" cellspacing="0" width="100%">
        <tr>
          <td>
            <table cellpadding="10" cellspacing="0" width="100%">
              <tr>
                <td bgcolor="whitesmoke">
                  <h3>EMSRS profile attributes</h3>
                  <small>These are the attributes that <asp:Literal ID="Literal_application_name_3" runat="server"></asp:Literal> has successfully sync from EMSRS.</small>
                </td>
              </tr>
              <tr><td><uc2:UserControl_coned_sponsor ID="UserControl_coned_sponsor_control" runat="server" /></td></tr>
            </table>
          </td>
        </tr>
      </table>
      <uc1:UserControl_postcontent id="UserControl_postcontent" runat="server"></uc1:UserControl_postcontent>
      <uc3:UserControl_update_progress_blocker id="UserControl_update_progress_blocker_control" runat="server"></uc3:UserControl_update_progress_blocker>
    </form>
  </body>
</html>
