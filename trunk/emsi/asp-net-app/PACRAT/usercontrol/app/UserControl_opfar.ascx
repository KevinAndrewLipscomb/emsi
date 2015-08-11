<%@ Control Language="c#" AutoEventWireup="True" Codebehind="UserControl_opfar.ascx.cs" Inherits="UserControl_opfar.TWebUserControl_opfar"%>
<!-- Derived from KiAspdotnetFramework/usercontrol/app/UserControl~template~datagrid~sortable.ascx-template -->
<table cellpadding="2" cellspacing="0" align="center">
  <tr>
    <td align="center">
      <table align="center" cellpadding="2" cellspacing="0">
        <tr><td align="center">&nbsp;</td></tr>
        <tr><td align="center" nowrap="nowrap"><big><b><asp:Literal ID="Literal_application_name" runat="server"></asp:Literal> Operational Period Full Accountability Report</b></big></td></tr>
        <tr><td align="center"><small>Not intended for NIMS ICS Form 204</small></td></tr>
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
          <td valign="top">
            <table width="100%">
              <tr bgcolor="Gainsboro"><td align="center"><small><b><asp:Literal ID="Literal_nature" runat="server"></asp:Literal></b></small></td></tr>
              <tr>
                <td align="center">
                  <table id="Table_prelim" runat="server" visible="false" width="100%">
                    <tr><td align="center"><tt><asp:Literal ID="Literal_prelim_shift_name" runat="server"></asp:Literal></tt></td></tr>
                    <tr><td align="center"><tt>assignments</tt></td></tr>
                  </table>
                  <table id="Table_nonprelim" runat="server" visible="false" width="100%">
                    <tr>
                      <td bgcolor="WhiteSmoke">From</td>
                      <td><tt><asp:Literal ID="Literal_start" runat="server"></asp:Literal></tt></td>
                    </tr>
                    <tr>
                      <td bgcolor="WhiteSmoke">To</td>
                      <td><tt><asp:Literal ID="Literal_end" runat="server"></asp:Literal></tt></td>
                    </tr>
                  </table>
                </td>
              </tr>
            </table>
          </td>
        </tr>
        </table>
    </td>
  </tr>
  <tr>
    <td align="center">
      <table width="100%">
        <tr bgcolor="Gainsboro"><td align="center"><small><b>RESOURCES ASSIGNED BY VEHICLE</b></small></td></tr>
        <tr id="TableRow_by_vehicle_none" runat="server"><td align="center"><em>--&nbsp;NONE&nbsp;--</em></td></tr>
        <tr id="TableRow_by_vehicle_control" runat="server">
          <td align="center">
            <asp:DataGrid id="DataGrid_by_vehicle_control" runat="server" gridlines="Horizontal" cellpadding="10" autogeneratecolumns="False">
              <Columns>
                <asp:BoundColumn datafield="vehicle_designator" headertext="Vehicle">
                  <HeaderStyle Wrap="False" />
                  <ItemStyle Wrap="False" VerticalAlign="Top" />
                </asp:BoundColumn>
                <asp:BoundColumn datafield="vehicle_patient_care_level_description" visible="false"></asp:BoundColumn>
                <asp:BoundColumn datafield="max_practitioner_level_short_description" visible="false"></asp:BoundColumn>
                <asp:BoundColumn DataField="effective_patient_care_level" HeaderText="Lvl">
                  <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                  <ItemStyle HorizontalAlign="Center" Wrap="False" VerticalAlign="Top" />
                </asp:BoundColumn>
                <asp:TemplateColumn HeaderText="Kind">
                  <ItemTemplate>
                    <asp:Label id="Label_kind" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.kind") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                  <ItemStyle HorizontalAlign="Center" Wrap="False" VerticalAlign="Top" />
                </asp:TemplateColumn>
                <asp:BoundColumn datafield="crew" headertext="Crew">
                  <HeaderStyle Wrap="False" />
                  <ItemStyle Wrap="False" VerticalAlign="Top" />
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
        <tr bgcolor="Gainsboro"><td align="center"><small><b>RESOURCES ASSIGNED BY MEMBER</b></small></td></tr>
        <tr id="TableRow_by_member_none" runat="server"><td align="center"><em>--&nbsp;NONE&nbsp;--</em></td></tr>
        <tr id="TableRow_by_member_control" runat="server">
          <td align="center">
            <asp:DataGrid id="DataGrid_by_member_control" runat="server" gridlines="Horizontal" cellpadding="5" autogeneratecolumns="False" onitemdatabound="DataGrid_by_member_control_ItemDataBound">
              <Columns>
                <asp:BoundColumn datafield="member_designator" headertext="Member">
                  <HeaderStyle horizontalalign="Left"></HeaderStyle>
                  <ItemStyle horizontalalign="Left"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn datafield="vehicle_designator" headertext="Vehicle">
                  <HeaderStyle horizontalalign="Left"></HeaderStyle>
                  <ItemStyle horizontalalign="Left"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn DataField="member_phone_num" HeaderText="Contact #"></asp:BoundColumn>
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
