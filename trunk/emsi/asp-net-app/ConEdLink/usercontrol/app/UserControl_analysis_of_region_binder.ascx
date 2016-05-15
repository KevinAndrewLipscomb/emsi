<%@ Control Language="c#" AutoEventWireup="True" Codebehind="UserControl_analysis_of_region_binder.ascx.cs" Inherits="UserControl_analysis_of_region_binder.TWebUserControl_analysis_of_region_binder"%>
<!-- Derived from KiAspdotnetFramework/usercontrol/app/UserControl~template~binder.ascx-template -->
<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:UpdatePanel id="UpdatePanel_control" runat="server" updatemode="Conditional">
  <ContentTemplate>
    <table cellspacing="0" cellpadding="0" border="0" width="100%">
      <tr>
        <td>
          <small>
            Based only on rosters processed via ConEdLink
            <p></p>
          </small>
          <cc1:TabContainer id="TabContainer_control" runat="server" autopostback="True" cssclass="ajax__tab_ki">
            <cc1:TabPanel runat="server" headertext="By year" id="TabPanel_by_year"></cc1:TabPanel>
            <cc1:TabPanel runat="server" headertext="By month" id="TabPanel_by_month"></cc1:TabPanel>
            <cc1:TabPanel runat="server" headertext="By sponsor" id="TabPanel_by_sponsor"></cc1:TabPanel>
            <cc1:TabPanel runat="server" headertext="By course" id="TabPanel_by_course"></cc1:TabPanel>
            <cc1:TabPanel runat="server" headertext="By county" id="TabPanel_by_county"></cc1:TabPanel>
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