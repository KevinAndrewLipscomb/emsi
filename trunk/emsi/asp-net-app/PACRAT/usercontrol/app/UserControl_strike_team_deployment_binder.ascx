<%@ Control Language="c#" AutoEventWireup="True" Codebehind="UserControl_strike_team_deployment_binder.ascx.cs" Inherits="UserControl_strike_team_deployment_binder.TWebUserControl_strike_team_deployment_binder"%>
<!-- Derived from KiAspdotnetFramework/usercontrol/app/UserControl~template~binder.ascx-template -->
<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:UpdatePanel id="UpdatePanel_control" runat="server" updatemode="Conditional">
  <ContentTemplate>
    <table cellspacing="0" cellpadding="0" border="0" width="100%">
      <tr>
        <td>
          <cc1:TabContainer id="TabContainer_control" runat="server" autopostback="True" cssclass="ajax__tab_ki">
            <cc1:TabPanel runat="server" headertext="Personnel" id="TabPanel_personnel"></cc1:TabPanel>
            <cc1:TabPanel runat="server" headertext="Vehicles" id="TabPanel_vehicles"></cc1:TabPanel>
            <cc1:TabPanel runat="server" headertext="Operational periods" id="TabPanel_operational_periods" enabled="false"></cc1:TabPanel>
            <cc1:TabPanel runat="server" headertext="Log" id="TabPanel_log"></cc1:TabPanel>
            <cc1:TabPanel runat="server" headertext="Snapshot" id="TabPanel_snapshot" enabled="false"></cc1:TabPanel>
          </cc1:TabContainer>
        </td>
      </tr>
      <tr>
        <td style="PADDING:8px; BORDER-BOTTOM:thin solid silver; BORDER-LEFT:thin solid silver; BORDER-RIGHT:thin solid silver;">
          <ASP:PlaceHolder id="PlaceHolder_content" runat="server"></ASP:PlaceHolder>
        </td>
      </tr>
    </table>
  </ContentTemplate>
</asp:UpdatePanel>