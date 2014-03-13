<%@ Control Language="c#" AutoEventWireup="True" Codebehind="UserControl_region_affiliation.ascx.cs" Inherits="UserControl_region_affiliation.TWebUserControl_region_affiliation"%>
<%@ Register src="UserControl_other_prep_ops.ascx" tagname="UserControl_other_prep_ops" tagprefix="uc1" %>
<!-- Derived from KiAspdotnetFramework/usercontrol/app/UserControl~template~datagrid~sortable.ascx-template -->
<asp:UpdatePanel id="UpdatePanel_control" runat="server" updatemode="Conditional">
  <ContentTemplate>
    <table bordercolor="#dcdcdc" cellspacing="0" cellpadding="0" border="1">
      <tr>
        <td>
          <table cellspacing="0" cellpadding="10" border="0">
            <tr><td bgcolor="#dcdcdc"><b>Region EMS Strike Teams that you manage</b></td></tr>
            <tr id="TableRow_none" runat="server"><td><em>--&nbsp;NONE&nbsp;--</em></td></tr>
            <tr id="TableRow_data" runat="server" visible="false">
              <td>
                <asp:DataGrid id="DataGrid_control" runat="server" gridlines="Horizontal" cellpadding="10" autogeneratecolumns="False" allowsorting="True">
                  <Columns>
                    <asp:ButtonColumn text="&lt;IMG src=&quot;~/protected/image/open_document16_h.png&quot; alt=&quot;Detail&quot; border=&quot;0&quot; height=&quot;16&quot; width=&quot;16&quot; /&gt;" commandname="Select"></asp:ButtonColumn>
                    <asp:BoundColumn datafield="region_code" Visible="false"></asp:BoundColumn>
                    <asp:BoundColumn datafield="region_emsrs_code" headertext="#" sortexpression="region_emsrs_code%"></asp:BoundColumn>
                    <asp:BoundColumn datafield="region_name" headertext="Name" sortexpression="region_name%">
                      <HeaderStyle horizontalalign="Left"></HeaderStyle>
                    </asp:BoundColumn>
                  </Columns>
                  <HeaderStyle backcolor="WhiteSmoke"></HeaderStyle>
                </asp:DataGrid>
              </td>
            </tr>
          </table>
        </td>
      </tr>
    </table>
  </ContentTemplate>
</asp:UpdatePanel>
<uc1:UserControl_other_prep_ops ID="UserControl_other_prep_ops_control" runat="server" visible="false"/>

