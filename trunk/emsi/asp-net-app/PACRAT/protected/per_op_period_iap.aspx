<!DOCTYPE HTML>
<!-- Derived from KiAspdotnetFramework/protected/template~protected~nonlanding.aspx~template -->
<%@ Page language="c#" Debug="true" Codebehind="per_op_period_iap.aspx.cs" AutoEventWireup="True" Inherits="per_op_period_iap.TWebForm_per_op_period_iap" EnableViewState="False" %>
<%@ Register TagPrefix="uc1" TagName="UserControl_common_header_bar" Src="~/usercontrol/app/UserControl_common_header_bar.ascx" %>
<%@ Register TagPrefix="uc2" TagName="UserControl_per_op_period_iap" Src="~/usercontrol/app/UserControl_per_op_period_iap.ascx" %>
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
      <uc2:UserControl_per_op_period_iap ID="UserControl_per_op_period_iap_control" runat="server" />
    </form>
    <script type="text/javascript">window.print();</script>
  </body>
</html>
