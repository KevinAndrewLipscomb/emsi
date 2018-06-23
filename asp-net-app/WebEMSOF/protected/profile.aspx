<!DOCTYPE html>
<%@ Page language="c#" Debug="true" Codebehind="profile.aspx.cs" AutoEventWireup="True" Inherits="profile.TWebForm_profile" %>
<%@ Register TagPrefix="uc1" TagName="UserControl_precontent" Src="~/usercontrol/app/UserControl_precontent.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UserControl_postcontent" Src="~/usercontrol/app/UserControl_postcontent.ascx" %>
<%@ Register TagPrefix="uc2" TagName="UserControl_update_progress_blocker" Src="~/usercontrol/app/UserControl_update_progress_blocker.ascx" %><%@ Register TagPrefix="uc3" TagName="UserControl_service_profile" Src="~/usercontrol/app/UserControl_service_profile.ascx" %>
<html>
  <head runat="server"><title id="Title"></title>
    <!-- $Id$ -->
    <link href="../css/standard.css" rel="stylesheet" type="text/css" />
    <!--[if lt IE 7]> <style type="text/css">@import "../css/standard-overrides-for-ie6.css";</style><![endif]-->
  </head>
  <body bgcolor="white">
    <form runat="server">
      <uc1:UserControl_precontent id="UserControl_precontent" runat="server"></uc1:UserControl_precontent>
      <p><strong>Your service's profile</strong></p>
      <uc3:UserControl_service_profile id="UserControl_service_profile_control" runat="server"></uc3:UserControl_service_profile>
      <uc1:UserControl_postcontent id="UserControl_postcontent" runat="server"></uc1:UserControl_postcontent>
      <uc2:UserControl_update_progress_blocker id="UserControl_update_progress_blocker_control" runat="server"></uc2:UserControl_update_progress_blocker>
    </form>
  </body>
</html>
