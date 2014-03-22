<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/strict.dtd">
<!-- Derived from KiAspdotnetFramework/protected/template~protected~nonlanding.aspx~template -->
<%@ Page language="c#" Debug="true" Codebehind="per_deployment_iap_log.aspx.cs" AutoEventWireup="True" Inherits="per_deployment_iap_log.TWebForm_per_deployment_iap_log" EnableViewState="False" %>
<%@ Register TagPrefix="uc1" TagName="UserControl_common_header_bar" Src="~/usercontrol/app/UserControl_common_header_bar.ascx" %>
<%@ Register TagPrefix="uc2" TagName="UserControl_per_deployment_iap_log" Src="~/usercontrol/app/UserControl_per_deployment_iap_log.ascx" %>
<html>
  <head runat="server">
    <title></title>
    <!-- $Id$ -->
    <link href="../css/standard.css" rel="stylesheet" type="text/css" />
    <!--[if lt IE 7]> <style type="text/css">@import "../css/standard-overrides-for-ie6.css";</style><![endif]-->
  </head>
  <body bgcolor="white">
    <form runat="server">
      <uc1:UserControl_common_header_bar id="UserControl_common_header_bar" runat="server"></uc1:UserControl_common_header_bar>
      <br />
      <uc2:UserControl_per_deployment_iap_log ID="UserControl_per_deployment_iap_log_control" runat="server" />
    </form>
    <script type="text/javascript">window.print();</script>
  </body>
</html>
