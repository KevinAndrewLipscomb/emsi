<%@ Control Language="c#" AutoEventWireup="True" Codebehind="UserControl_strike_team_deployment_members.ascx.cs" Inherits="UserControl_strike_team_deployment_members.TWebUserControl_strike_team_deployment_members"%>
<!-- Derived from KiAspdotnetFramework/usercontrol/app/UserControl~template~datagrid~sortable.ascx-template -->
<asp:UpdatePanel id="UpdatePanel_control" runat="server" updatemode="Conditional">
  <ContentTemplate>
    <table bordercolor="#dcdcdc" cellspacing="0" cellpadding="0" border="1">
      <tr>
        <td>
          <table cellspacing="0" cellpadding="10" border="0">
            <tr>
              <td bgcolor="#dcdcdc">
                <table cellspacing="0" cellpadding="0" border="0">
                  <tr>
                    <td valign="middle">
                      <strong>Filter:</strong>&nbsp;<asp:CheckBox ID="CheckBox_do_include_all_eligible_practitioners" runat="server" Text="Include all eligible practitioners" AutoPostBack="True" oncheckedchanged="CheckBox_do_include_all_eligible_practitioners_CheckedChanged" />
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td align="right" valign="middle">
                      <asp:Literal ID="Literal_num_practitioners" runat="server"></asp:Literal> practitioners
                    </td>
                  </tr>
                </table>
              </td>
            </tr>
            <tr id="TableRow_none" runat="server"><td><em>--&nbsp;NONE&nbsp;--</em></td></tr>
            <tr>
              <td>
                <asp:DataGrid id="DataGrid_control" runat="server" gridlines="Horizontal" cellpadding="10" autogeneratecolumns="False" allowsorting="True">
                  <Columns>
                    <asp:ButtonColumn text="&lt;IMG src=&quot;~/protected/image/open_document16_h.png&quot; alt=&quot;Detail&quot; border=&quot;0&quot; height=&quot;16&quot; width=&quot;16&quot; /&gt;" commandname="Select"></asp:ButtonColumn>
                    <asp:BoundColumn datafield="id" Visible="false"></asp:BoundColumn>
                    <asp:BoundColumn datafield="practitioner_id" visible="false"></asp:BoundColumn>
                    <asp:ButtonColumn CommandName="ToggleMobilization" HeaderText="Mobilized?" SortExpression="(strike_team_deployment_member.id is not null)%,last_name,first_name" Text="?">
                      <ItemStyle HorizontalAlign="Center" />
                    </asp:ButtonColumn>
                    <asp:BoundColumn datafield="tag_num" headertext="Tag #" sortexpression="tag_num%,last_name,first_name"></asp:BoundColumn>
                    <asp:BoundColumn datafield="last_name" headertext="Last name" sortexpression="last_name%,first_name"></asp:BoundColumn>
                    <asp:BoundColumn datafield="first_name" headertext="First name" sortexpression="first_name%,last_name"></asp:BoundColumn>
                    <asp:BoundColumn datafield="level" headertext="Level" sortexpression="practitioner_level.pecking_order%,last_name,first_name"></asp:BoundColumn>
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
