<%@ Control Language="c#" AutoEventWireup="True" Codebehind="UserControl_per_deployment_iap_vehicles.ascx.cs" Inherits="UserControl_per_deployment_iap_vehicles.TWebUserControl_per_deployment_iap_vehicles"%>
<!-- Derived from KiAspdotnetFramework/usercontrol/app/UserControl~template~datagrid~sortable.ascx-template -->
<table cellpadding="2" cellspacing="0" align="center">
  <tr>
    <td align="center">
      <table align="center" cellpadding="2" cellspacing="0">
        <tr><td align="center">&nbsp;</td></tr>
        <tr><td align="center"><small>Refer to this document as</small></td></tr>
        <tr><td align="center" nowrap="nowrap"><big><b><asp:Literal ID="Literal_application_name" runat="server"></asp:Literal> Mobilized Vehicles Report # <asp:Literal ID="Literal_ref_num" runat="server"></asp:Literal></b></big></td></tr>
        <tr><td align="center"><small>on NIMS ICS Form 211</small></td></tr>
        <tr><td align="center">&nbsp;</td></tr>
      </table>
    </td>
  </tr>
  <tr>
    <td align="center">
      <table width="100%">
        <tr>
          <td valign="top">
            <table width="100%">
              <tr bgcolor="Gainsboro"><td align="center"><small><b>INCIDENT NAME</b></small></td></tr>
              <tr><td align="center"><tt><asp:Literal ID="Literal_deployment_name" runat="server"></asp:Literal></tt></td></tr>
            </table>
          </td>
        </tr>
        </table>
    </td>
  </tr>
  <tr>
    <td align="center">
      <table width="100%">
        <tr bgcolor="Gainsboro"><td align="center"><small><b>MOBILIZED VEHICLES</b></small></td></tr>
        <tr id="TableRow_none" runat="server"><td align="center"><em>--&nbsp;NONE&nbsp;--</em></td></tr>
        <tr id="TableRow_control" runat="server">
          <td>
            <asp:DataGrid id="DataGrid_control" runat="server" gridlines="Horizontal" cellpadding="5" autogeneratecolumns="False">
              <Columns>
                <asp:BoundColumn datafield="tactical_name" headertext="Tac name"></asp:BoundColumn>
                <asp:BoundColumn datafield="transponder_name" headertext="Xpndr name"></asp:BoundColumn>
                <asp:BoundColumn datafield="service" headertext="Service"></asp:BoundColumn>
                <asp:BoundColumn datafield="name" headertext="Name"></asp:BoundColumn>
                <asp:BoundColumn datafield="patient_care_level" headertext="Lvl">
                  <HeaderStyle HorizontalAlign="Center" />
                  <ItemStyle HorizontalAlign="Center" />
                </asp:BoundColumn>
                <asp:BoundColumn datafield="kind" HeaderText="Kind">
                  <HeaderStyle HorizontalAlign="Center" />
                  <ItemStyle HorizontalAlign="Center" />
                </asp:BoundColumn>
                <asp:BoundColumn datafield="pa_doh_decal_num" headertext="Decal #">
                  <HeaderStyle HorizontalAlign="Center" />
                </asp:BoundColumn>
                <asp:BoundColumn DataField="tow_capacity" HeaderText="Tow cap">
                  <HeaderStyle HorizontalAlign="Center" />
                  <ItemStyle HorizontalAlign="Center" Wrap="False" />
                </asp:BoundColumn>
                <asp:BoundColumn datafield="fuel" headertext="Fuel">
                  <HeaderStyle HorizontalAlign="Center" />
                  <ItemStyle HorizontalAlign="Center" />
                </asp:BoundColumn>
                <asp:BoundColumn datafield="be_four_or_all_wheel_drive" headertext="AWD?">
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
  <tr>
    <td align="center">
      <table width="100%">
        <tr bgcolor="Gainsboro"><td align="center"><small><b>PREPARED BY</b></small></td></tr>
        <tr>
          <td>
            <table width="100%">
              <tr>
                <td nowrap="nowrap" valign="top" width="1%">
                  <table width="100%">
                    <tr bgcolor="WhiteSmoke"><td align="center"><small><b>NAME</b></small></td></tr>
                    <tr><td align="center"><tt><asp:Literal ID="Literal_prepared_name" runat="server"></asp:Literal></tt></td></tr>
                  </table>
                </td>
                <td nowrap="nowrap" width="1%" valign="top">
                  <table width="100%">
                    <tr bgcolor="WhiteSmoke"><td align="center"><small><b>TIMESTAMP</b></small></td></tr>
                    <tr><td align="center"><tt><asp:Literal ID="Literal_prepared_timestamp" runat="server"></asp:Literal></tt></td></tr>
                  </table>
                </td>
              </tr>
            </table>
          </td>
        </tr>
      </table>
    </td>
  </tr>
  </table>
