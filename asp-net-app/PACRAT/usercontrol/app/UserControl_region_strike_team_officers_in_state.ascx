<%@ Control Language="c#" AutoEventWireup="True" Codebehind="UserControl_region_strike_team_officers_in_state.ascx.cs" Inherits="UserControl_region_strike_team_officers_in_state.TWebUserControl_region_strike_team_officers_in_state"%>
<%@ Register src="UserControl_static_region_strike_team_key_personnel.ascx" tagname="UserControl_static_region_strike_team_key_personnel" tagprefix="uc1" %>
<!-- Derived from KiAspdotnetFramework/usercontrol/app/UserControl~template~datagrid~sortable.ascx-template -->
<table bordercolor="#dcdcdc" cellspacing="0" cellpadding="0" border="1">
  <tr>
    <td>
      <table cellspacing="0" cellpadding="10" border="0">
        <tr>
          <td bgcolor="#dcdcdc">
            <table cellspacing="0" cellpadding="5" border="0" width="100%">
              <tr>
                <td><strong>State:&nbsp;Pennsylvania</strong></td>
                <td align="right"><asp:Literal ID="Literal_num_regions" runat="server"></asp:Literal> regions</td>
              </tr>
            </table>
          </td>
        </tr>
        <tr id="TableRow_none" runat="server"><td><em>--&nbsp;NONE&nbsp;--</em></td></tr>
        <tr>
          <td>
            <asp:DataGrid id="DataGrid_control" runat="server" gridlines="Horizontal" cellpadding="10" autogeneratecolumns="False" ShowHeader="False">
              <Columns>
                <asp:BoundColumn DataField="code" Visible="False"></asp:BoundColumn>
                <asp:TemplateColumn>
                  <ItemTemplate>
                    <uc1:UserControl_static_region_strike_team_key_personnel ID="UserControl_static_region_strike_team_key_personnel_control" runat="server" />
                  </ItemTemplate>
                </asp:TemplateColumn>
              </Columns>
              <HeaderStyle backcolor="WhiteSmoke"></HeaderStyle>
            </asp:DataGrid>
          </td>
        </tr>
      </table>
    </td>
  </tr>
</table>
