<%@ Control Language="c#" AutoEventWireup="True" Codebehind="UserControl_analyses_binder.ascx.cs" Inherits="UserControl_analyses_binder.TWebUserControl_analyses_binder"%>
<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:UpdatePanel id="UpdatePanel_control" runat="server" updatemode="Conditional">
  <ContentTemplate>
    <table cellspacing="0" cellpadding="0" border="0">
      <tr>
        <td>
          <cc1:TabContainer id="TabContainer_control" runat="server" cssclass="ajax__tab_ki" autopostback="True">
            <cc1:TabPanel runat="server" headertext="Allocations-Reimbursements-Nonspends" id="TabPanel_allocations_reimbursements_returns"></cc1:TabPanel>
            <cc1:TabPanel runat="server" headertext="Equipment procurement" id="TabPanel_equipment_procurement"></cc1:TabPanel>
            <cc1:TabPanel runat="server" headertext="Values to services" id="TabPanel_values_to_services"></cc1:TabPanel>
            <cc1:TabPanel runat="server" headertext="Values to region" id="TabPanel_values_to_region"></cc1:TabPanel>
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
