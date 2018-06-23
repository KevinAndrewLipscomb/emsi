<!DOCTYPE html>
<!-- Derived from KiAspdotnetFramework/protected/template~protected~nonlanding.aspx~template -->
<%@ Page language="c#" Debug="true" Codebehind="hardcopy_service_strike_team_key_personnel.aspx.cs" AutoEventWireup="True" Inherits="hardcopy_service_strike_team_key_personnel.TWebForm_hardcopy_service_strike_team_key_personnel" %>
<%@ Register src="../usercontrol/app/UserControl_static_service_strike_team_key_personnel.ascx" tagname="UserControl_static_service_strike_team_key_personnel" tagprefix="uc1" %>
<%@ Register src="../usercontrol/app/UserControl_common_header_bar.ascx" tagname="UserControl_common_header_bar" tagprefix="uc2" %>
<html>
  <head runat="server">
    <title></title>
    <!-- $Id$ -->
    <link href="../css/standard.css" rel="stylesheet" type="text/css" />
    <!--[if lt IE 7]> <style type="text/css">@import "../css/standard-overrides-for-ie6.css";</style><![endif]-->
  </head>
  <body bgcolor="white">
    <form runat="server">
      <uc2:UserControl_common_header_bar ID="UserControl_common_header_bar_control" runat="server" />
      <br />
      <uc1:UserControl_static_service_strike_team_key_personnel ID="UserControl_static_service_strike_team_key_personnel_control" runat="server" />
    </form>
    <script type="text/javascript">window.print();</script>
  </body>
</html>
