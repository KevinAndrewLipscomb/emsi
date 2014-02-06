<%@ Control Language="c#" AutoEventWireup="True" Codebehind="UserControl_strike_team_deployment_vehicles.ascx.cs" Inherits="UserControl_strike_team_deployment_vehicles.TWebUserControl_strike_team_deployment_vehicles"%>
<!-- Derived from KiAspdotnetFramework/usercontrol/app/UserControl~template~datagrid~sortable.ascx-template -->
<asp:UpdatePanel id="UpdatePanel_control" runat="server" updatemode="Conditional">
  <ContentTemplate>
    <table bordercolor="#dcdcdc" cellspacing="0" cellpadding="0" border="1">
      <tr>
        <td>
          <table cellspacing="0" cellpadding="10" border="0">
            <tr id="TableRow_operational_period_started" runat="server" bgcolor="khaki" visible="false">
              <td>An operational period has started for this deployment, so no further mobilization changes are allowed from your account.</td>
            </tr>
            <tr>
              <td bgcolor="#dcdcdc">
                <table cellspacing="0" cellpadding="0" border="0">
                  <tr>
                    <td id="Td_filter" runat="server" valign="middle">
                      <strong>Filter:</strong>&nbsp;<asp:CheckBox ID="CheckBox_do_include_all_eligible_vehicles" runat="server" Text="Show all eligible vehicles, whether mobilized or not" AutoPostBack="True" oncheckedchanged="CheckBox_do_include_all_eligible_vehicles_CheckedChanged" />
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td align="right" valign="middle">
                      <asp:Literal ID="Literal_num_vehicles" runat="server"></asp:Literal> vehicles
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
                    <asp:BoundColumn datafield="id" Visible="false" ReadOnly="True"></asp:BoundColumn>
                    <asp:BoundColumn datafield="vehicle_id" visible="false" ReadOnly="True"></asp:BoundColumn>
                    <asp:ButtonColumn CommandName="ToggleMobilization" HeaderText="Mobilized?" SortExpression="(strike_team_deployment_vehicle.id is not null)%,service,name" Text="?">
                      <ItemStyle HorizontalAlign="Center" />
                    </asp:ButtonColumn>
                    <asp:BoundColumn datafield="tactical_name" headertext="Tac name" sortexpression="tactical_name%,name,service"></asp:BoundColumn>
                    <asp:BoundColumn datafield="transponder_name" headertext="Xpndr name" sortexpression="transponder_name%,name,service"></asp:BoundColumn>
                    <asp:BoundColumn datafield="service_id" visible="false" ReadOnly="True"></asp:BoundColumn>
                    <asp:BoundColumn datafield="service" headertext="Service" sortexpression="service%,name" ReadOnly="True"></asp:BoundColumn>
                    <asp:BoundColumn datafield="name" headertext="Name" sortexpression="name%,service" ReadOnly="True"></asp:BoundColumn>
                    <asp:BoundColumn datafield="patient_care_level" headertext="Lvl" sortexpression="patient_care_level.pecking_order%,service,name" ReadOnly="True">
                      <HeaderStyle HorizontalAlign="Center" />
                      <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn datafield="kind" headertext="Kind" sortexpression="kind%,service,name" ReadOnly="True">
                      <HeaderStyle HorizontalAlign="Center" />
                      <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn datafield="pa_doh_decal_num" headertext="Decal #" sortexpression="pa_doh_decal_num%,service,name" ReadOnly="True">
                      <HeaderStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="tow_capacity" HeaderText="Tow cap" ReadOnly="True" SortExpression="tow_capacity_id%,service,name">
                      <HeaderStyle HorizontalAlign="Center" />
                      <ItemStyle HorizontalAlign="Center" Wrap="False" />
                    </asp:BoundColumn>
                    <asp:BoundColumn datafield="fuel" headertext="Fuel" sortexpression="fuel%,service,name" ReadOnly="True">
                      <HeaderStyle HorizontalAlign="Center" />
                      <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn datafield="be_four_or_all_wheel_drive" headertext="AWD?" sortexpression="be_four_or_all_wheel_drive%,service,name" ReadOnly="True">
                      <ItemStyle HorizontalAlign="Center" />
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
