<%@ Control Language="c#" AutoEventWireup="True" Codebehind="UserControl_strike_team_deployment_snapshot.ascx.cs" Inherits="UserControl_strike_team_deployment_snapshot.TWebUserControl_strike_team_deployment_snapshot"%>
<!-- Derived from KiAspdotnetFramework/usercontrol/app/UserControl~template~std.ascx-template -->
<asp:Button ID="Button_export" runat="server" onclick="Button_export_Click" Text="Export snapshot workbook" />
<asp:DataGrid id="DataGrid_personnel" runat="server" autogeneratecolumns="False" onitemdatabound="DataGrid_personnel_ItemDataBound" style="display:none">
  <Columns>
    <asp:BoundColumn datafield="tag_num" headertext="Tag #"></asp:BoundColumn>
    <asp:BoundColumn datafield="last_name" headertext="Last name" ReadOnly="True"></asp:BoundColumn>
    <asp:BoundColumn datafield="first_name" headertext="First name" ReadOnly="True"></asp:BoundColumn>
    <asp:BoundColumn datafield="level" headertext="Level" ReadOnly="True"></asp:BoundColumn>
    <asp:BoundColumn DataField="affiliation" HeaderText="Affiliation" ReadOnly="True"></asp:BoundColumn>
  </Columns>
</asp:DataGrid>
<asp:DataGrid id="DataGrid_vehicles" runat="server" autogeneratecolumns="False" onitemdatabound="DataGrid_vehicles_ItemDataBound" style="display:none">
  <Columns>
    <asp:BoundColumn datafield="tactical_name" headertext="Tac name"></asp:BoundColumn>
    <asp:BoundColumn datafield="transponder_name" headertext="Xpndr name"></asp:BoundColumn>
    <asp:BoundColumn datafield="service" headertext="Service" ReadOnly="True"></asp:BoundColumn>
    <asp:BoundColumn datafield="name" headertext="Name" ReadOnly="True"></asp:BoundColumn>
    <asp:BoundColumn datafield="patient_care_level" headertext="Lvl" ReadOnly="True"></asp:BoundColumn>
    <asp:BoundColumn datafield="kind" headertext="Kind" ReadOnly="True"></asp:BoundColumn>
    <asp:BoundColumn datafield="pa_doh_decal_num" headertext="Decal #" ReadOnly="True"></asp:BoundColumn>
    <asp:BoundColumn DataField="tow_capacity" HeaderText="Tow cap" ReadOnly="True"></asp:BoundColumn>
    <asp:BoundColumn datafield="fuel" headertext="Fuel" ReadOnly="True"></asp:BoundColumn>
    <asp:BoundColumn datafield="be_four_or_all_wheel_drive" headertext="AWD?" ReadOnly="True"></asp:BoundColumn>
  </Columns>
</asp:DataGrid>
<asp:DataGrid id="DataGrid_operational_periods" runat="server" autogeneratecolumns="False" onitemdatabound="DataGrid_operational_periods_ItemDataBound" style="display:none">
  <Columns>
    <asp:BoundColumn datafield="prelim_shift_name" headertext="Prelim shift name"></asp:BoundColumn>
    <asp:BoundColumn datafield="start" headertext="Start"></asp:BoundColumn>
    <asp:BoundColumn datafield="end" headertext="End"></asp:BoundColumn>
    <asp:BoundColumn DataField="be_convoy" HeaderText="Convoy?"></asp:BoundColumn>
  </Columns>
</asp:DataGrid>
<asp:DataGrid id="DataGrid_digest" runat="server" autogeneratecolumns="False" onitemdatabound="DataGrid_digest_ItemDataBound" style="display:none">
  <Columns>
    <asp:BoundColumn datafield="prelim_shift_name" headertext="Prelim shift name"></asp:BoundColumn>
    <asp:BoundColumn datafield="start" headertext="Start"></asp:BoundColumn>
    <asp:BoundColumn datafield="end" headertext="End"></asp:BoundColumn>
    <asp:BoundColumn DataField="be_convoy" HeaderText="Convoy?"></asp:BoundColumn>
    <asp:BoundColumn datafield="vehicle_designator" headertext="Vehicle" sortexpression="vehicle_designator%"></asp:BoundColumn>
    <asp:BoundColumn datafield="vehicle_patient_care_level_description" visible="false"></asp:BoundColumn>
    <asp:BoundColumn datafield="max_practitioner_level_short_description" visible="false"></asp:BoundColumn>
    <asp:BoundColumn DataField="effective_patient_care_level" HeaderText="Lvl"></asp:BoundColumn>
    <asp:BoundColumn datafield="kind" headertext="Kind"></asp:BoundColumn>
    <asp:BoundColumn datafield="par" headertext="Par"></asp:BoundColumn>
  </Columns>
</asp:DataGrid>
<asp:DataGrid id="DataGrid_assignments" runat="server" autogeneratecolumns="False" onitemdatabound="DataGrid_assignments_ItemDataBound" style="display:none">
  <Columns>
    <asp:BoundColumn datafield="prelim_shift_name" headertext="Prelim shift name"></asp:BoundColumn>
    <asp:BoundColumn datafield="start" headertext="Start"></asp:BoundColumn>
    <asp:BoundColumn datafield="end" headertext="End"></asp:BoundColumn>
    <asp:BoundColumn DataField="be_convoy" HeaderText="Convoy?"></asp:BoundColumn>
    <asp:BoundColumn datafield="vehicle_designator" headertext="Vehicle"></asp:BoundColumn>
    <asp:BoundColumn datafield="member_designator" headertext="Member"></asp:BoundColumn>
  </Columns>
</asp:DataGrid>
<asp:DataGrid id="DataGrid_log" runat="server" autogeneratecolumns="False" onitemdatabound="DataGrid_log_ItemDataBound" style="display:none">
  <Columns>
    <asp:BoundColumn datafield="timestamp" headertext="Timestamp" ReadOnly="True"></asp:BoundColumn>
    <asp:BoundColumn datafield="actor" headertext="Actor" ReadOnly="True"></asp:BoundColumn>
    <asp:BoundColumn datafield="action" headertext="Action" ReadOnly="True"></asp:BoundColumn>
  </Columns>
</asp:DataGrid>
