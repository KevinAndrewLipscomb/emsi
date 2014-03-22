<%@ Control Language="c#" AutoEventWireup="True" Codebehind="UserControl_strike_team_deployment_log.ascx.cs" Inherits="UserControl_strike_team_deployment_log.TWebUserControl_strike_team_deployment_log"%>
<!-- Derived from KiAspdotnetFramework/usercontrol/app/UserControl~template~datagrid~sortable.ascx-template -->
<asp:UpdatePanel id="UpdatePanel_control" runat="server" updatemode="Conditional">
  <ContentTemplate>
    <table bordercolor="#dcdcdc" cellspacing="0" cellpadding="0" border="1">
      <tr>
        <td>
          <table border="0" cellpadding="10" cellspacing="0">
            <tr>
              <td bgcolor="#dcdcdc">
                <table border="0" cellpadding="5" cellspacing="0" width="100%">
                  <tr>
                    <td>
                      <small><strong>Filter:&nbsp;<asp:DropDownList id="DropDownList_filter" runat="server" autopostback="True"></asp:DropDownList></strong></small>
                    </td>
                    <td align="center">
                      <small><asp:Literal ID="Literal_num_entries" runat="server"></asp:Literal> entries</small>
                    </td>
                    <td align="right">
                      <small>For&nbsp;IAP:&nbsp;<asp:HyperLink ID="HyperLink_for_iap" runat="server" NavigateUrl="~/protected/per_deployment_iap_log.aspx?" Target="_blank"><img src="~/protected/image/print16_h.png" alt="For IAP" border="0" height="16" width="16" /></asp:HyperLink></small>
                    </td>
                  </tr>
                </table>
              </td>
            </tr>
            <tr id="TableRow_none" runat="server"><td><em>--&nbsp;NONE&nbsp;--</em></td></tr>
            <tr>
              <td>
                <asp:DataGrid id="DataGrid_control" runat="server" gridlines="Horizontal" cellpadding="2" autogeneratecolumns="False" allowsorting="True">
                  <Columns>
                    <asp:BoundColumn datafield="id" ReadOnly="True" Visible="False"></asp:BoundColumn>
                    <asp:BoundColumn datafield="timestamp" headertext="Timestamp" sortexpression="timestamp%" ReadOnly="True">
                      <HeaderStyle horizontalalign="Left"></HeaderStyle>
                      <ItemStyle VerticalAlign="Top" Wrap="False" />
                    </asp:BoundColumn>
                    <asp:BoundColumn datafield="actor" headertext="Actor" sortexpression="actor%,timestamp" ReadOnly="True">
                      <ItemStyle horizontalalign="Left" VerticalAlign="Top" Wrap="False" />
                    </asp:BoundColumn>
                    <asp:BoundColumn datafield="action" headertext="Action" ReadOnly="True">
                      <ItemStyle horizontalalign="Left" />
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
