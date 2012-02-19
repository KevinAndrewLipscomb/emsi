<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/strict.dtd">
<!-- Derived from KiAspdotnetFramework/protected/template~protected~nonlanding.aspx~template -->
<%@ Page language="c#" Debug="true" Codebehind="report_commanded_training_certificate.aspx.cs" AutoEventWireup="True" Inherits="report_commanded_training_certificate.TWebForm_report_commanded_training_certificate" %>
<%@ Register src="../usercontrol/app/UserControl_common_header_bar.ascx" tagname="UserControl_common_header_bar" tagprefix="uc1" %>
<%@ Register TagPrefix="uc1" TagName="UserControl_training_certificate" Src="~/usercontrol/app/UserControl_training_certificate.ascx" %>
<html>
  <head runat="server">
    <!-- $Id$ -->
    <link href="../css/standard.css" rel="stylesheet" type="text/css" />
    <!--[if lt IE 7]> <style type="text/css">@import "../css/standard-overrides-for-ie6.css";</style><![endif]-->
  </head>
  <body bgcolor="white">
    <form runat="server">
      <uc1:UserControl_training_certificate id="UserControl_training_certificate_control" runat="server"></uc1:UserControl_training_certificate>
    </form>
  </body>
</html>
