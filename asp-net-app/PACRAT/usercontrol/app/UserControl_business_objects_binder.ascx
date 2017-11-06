<%@ Control Language="c#" AutoEventWireup="True" Codebehind="UserControl_business_objects_binder.ascx.cs" Inherits="UserControl_business_objects_binder.TWebUserControl_business_objects_binder"%>
<!-- Derived from KiAspdotnetFramework/usercontrol/app/UserControl~template~binder.ascx-template -->
<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:UpdatePanel id="UpdatePanel_control" runat="server" updatemode="Conditional">
  <ContentTemplate>
    <table cellspacing="0" cellpadding="0" border="0" width="100%">
      <tr>
        <td>
          <cc1:TabContainer id="TabContainer_control" runat="server" autopostback="True" cssclass="ajax__tab_ki" CssTheme="None">
            <cc1:TabPanel runat="server" headertext="Vehicle kinds" id="TabPanel_vehicle_kinds"></cc1:TabPanel>
            <cc1:TabPanel runat="server" headertext="Tow capacities" id="TabPanel_tow_capacities"></cc1:TabPanel>
            <cc1:TabPanel runat="server" headertext="Fuels" id="TabPanel_fuels"></cc1:TabPanel>
            <cc1:TabPanel runat="server" headertext="Patient care levels" id="TabPanel_patient_care_levels"></cc1:TabPanel>
            <cc1:TabPanel runat="server" headertext="SMS gateways" id="TabPanel_sms_gateways"></cc1:TabPanel>
            <cc1:TabPanel runat="server" headertext="ST participation levels" id="TabPanel_strike_team_participation_levels"></cc1:TabPanel>
          </cc1:TabContainer>
        </td>
      </tr>
      <tr>
        <td class="ki_tab_body">
          <ASP:PlaceHolder id="PlaceHolder_content" runat="server"></ASP:PlaceHolder>
        </td>
      </tr>
    </table>
  </ContentTemplate>
</asp:UpdatePanel>