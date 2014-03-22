<%@ Control Language="c#" AutoEventWireup="True" Codebehind="UserControl_per_op_period_iap.ascx.cs" Inherits="UserControl_per_op_period_iap.TWebUserControl_per_op_period_iap"%>
<!-- Derived from KiAspdotnetFramework/usercontrol/app/UserControl~template~datagrid~sortable.ascx-template -->
<table cellpadding="2" cellspacing="0" align="center">
  <tr>
    <td align="center">
      <table align="center" cellpadding="2" cellspacing="0">
        <tr><td align="center">&nbsp;</td></tr>
        <tr><td align="center"><small>Refer to this document as</small></td></tr>
        <tr><td align="center" nowrap="nowrap"><big><b><asp:Literal ID="Literal_application_name" runat="server"></asp:Literal> Resource Assignment Report # <asp:Literal ID="Literal_ref_num" runat="server"></asp:Literal></b></big></td></tr>
        <tr><td align="center"><small>on NIMS ICS Form 204</small></td></tr>
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
                  <table width="100%">
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
        <tr bgcolor="Gainsboro"><td align="center"><small><b>RESOURCES ASSIGNED</b></small></td></tr>
        <tr id="TableRow_none" runat="server"><td><em>--&nbsp;NONE&nbsp;--</em></td></tr>
        <tr id="TableRow_control" runat="server">
          <td>
            <asp:DataGrid id="DataGrid_control" runat="server" gridlines="Horizontal" cellpadding="10" autogeneratecolumns="False">
              <Columns>
                <asp:BoundColumn datafield="vehicle_designator" headertext="Vehicle">
                  <HeaderStyle Wrap="False" />
                  <ItemStyle Wrap="False" />
                </asp:BoundColumn>
                <asp:BoundColumn datafield="vehicle_patient_care_level_description" visible="false"></asp:BoundColumn>
                <asp:BoundColumn datafield="max_practitioner_level_short_description" visible="false"></asp:BoundColumn>
                <asp:BoundColumn DataField="effective_patient_care_level" HeaderText="Lvl">
                  <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                  <ItemStyle HorizontalAlign="Center" Wrap="False" />
                </asp:BoundColumn>
                <asp:TemplateColumn HeaderText="Kind">
                  <ItemTemplate>
                    <asp:Label id="Label_kind" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.kind") %>'></asp:Label>
                  </ItemTemplate>
                  <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                  <ItemStyle HorizontalAlign="Center" Wrap="False" />
                </asp:TemplateColumn>
                <asp:BoundColumn datafield="leader" headertext="Leader">
                  <HeaderStyle Wrap="False" />
                  <ItemStyle Wrap="False" />
                </asp:BoundColumn>
                <asp:BoundColumn datafield="par" headertext="Par">
                  <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                  <ItemStyle HorizontalAlign="Center" Wrap="False" />
                </asp:BoundColumn>
                <asp:BoundColumn DataField="leader_phone_num" HeaderText="Contact #">
                  <HeaderStyle Wrap="False" />
                  <ItemStyle Wrap="False" />
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
