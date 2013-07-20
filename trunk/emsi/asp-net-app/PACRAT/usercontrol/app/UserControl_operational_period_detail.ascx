<%@ Control Language="c#" AutoEventWireup="True" Codebehind="UserControl_operational_period_detail.ascx.cs" Inherits="UserControl_operational_period_detail.TWebUserControl_operational_period_detail"%>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<table bordercolor="#dcdcdc" cellspacing="0" cellpadding="0" border="1">
  <tr>
    <td>
      <table cellspacing="0" cellpadding="10" border="0">
        <tr>
          <td bgcolor="whitesmoke">
            <table cellspacing="0" cellpadding="5" border="0">
              <tr>
                <td><b><small>Filters:</small></b></td>
                <td><p align="center"><small>Assignment level</small><br/><ASP:DropDownList id="DropDownList_assignment_level_filter" runat="server" autopostback="True" onselectedindexchanged="DropDownList_assignment_level_filter_SelectedIndexChanged">
                  <asp:ListItem Value="">All</asp:ListItem>
                  <asp:ListItem Value="Vehicular">Vehicular</asp:ListItem>
                  </ASP:DropDownList></td>
              </tr>
            </table>
          </td>
        </tr>
        <tr>
          <td>
            <table cellspacing="0" cellpadding="10" border="0">
              <tr>
                <td id="TableCell_no_mappings" runat="server" valign="top"><em>--&nbsp;No&nbsp;mappings&nbsp;--</em></td>
                <td id="TableCell_mappings" runat="server" nowrap="nowrap" valign="top">
                  <asp:DataGrid id="DataGrid_control" runat="server" gridlines="Horizontal" cellpadding="5" autogeneratecolumns="False" allowsorting="True" ondeletecommand="DataGrid_control_DeleteCommand" onitemdatabound="DataGrid_control_ItemDataBound" onsortcommand="DataGrid_control_SortCommand">
                    <Columns>
                      <asp:ButtonColumn text="&lt;IMG src=&quot;~/protected/image/delete_x16_h.png&quot; alt=&quot;Unmap&quot; border=&quot;0&quot; height=&quot;16&quot; width=&quot;16&quot; /&gt;" commandname="Delete"></asp:ButtonColumn>
                      <asp:BoundColumn datafield="vehicle_id" Visible="false"></asp:BoundColumn>
                      <asp:BoundColumn datafield="vehicle_designator" headertext="Vehicle" sortexpression="vehicle_designator%,member_designator">
                        <HeaderStyle horizontalalign="Left"></HeaderStyle>
                        <ItemStyle horizontalalign="Left"></ItemStyle>
                      </asp:BoundColumn>
                      <asp:BoundColumn datafield="member_designator" headertext="Member" sortexpression="member_designator%,vehicle_designator">
                        <HeaderStyle horizontalalign="Left"></HeaderStyle>
                        <ItemStyle horizontalalign="Left"></ItemStyle>
                      </asp:BoundColumn>
                      <asp:BoundColumn datafield="member_id" Visible="false"></asp:BoundColumn>
                    </Columns>
                    <HeaderStyle backcolor="WhiteSmoke"></HeaderStyle>
                  </asp:DataGrid>
                </td>
                <td id="TableCell_add_mapping" runat="server" valign="top" visible="false">
                  <table cellspacing="0" cellpadding="2" border="0">
                    <tr>
                      <td>
                        <asp:DropDownList id="DropDownList_vehicle" runat="server" font-size="Small" datavaluefield="id" datatextfield="name" appenddatabounditems="True">
                          <asp:ListItem selected="True">-- Vehicle --</asp:ListItem>
                          <asp:ListItem Value="0">(none)</asp:ListItem>
                        </asp:DropDownList>
                      </td>
                      <td nowrap="nowrap"><asp:RequiredFieldValidator id="RequiredFieldValidator_vehicle" runat="server" errormessage="Please select a Vehicle." font-bold="True" controltovalidate="DropDownList_vehicle" setfocusonerror="True" display="Dynamic" ValidationGroup="OperationalPeriodDetail">!ERR!</asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                      <td>
                        <asp:DropDownList id="DropDownList_member" runat="server" datatextfield="member_designator" datavaluefield="member_id" font-size="Small" appenddatabounditems="True">
                          <asp:ListItem selected="True">-- Member --</asp:ListItem>
                        </asp:DropDownList>
                      </td>
                      <td nowrap="nowrap"><asp:RequiredFieldValidator id="RequiredFieldValidator_member" runat="server" errormessage="Please select a Member." font-bold="True" controltovalidate="DropDownList_member" setfocusonerror="True" display="Dynamic" ValidationGroup="OperationalPeriodDetail">!ERR!</asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                      <td><asp:Button id="Button_add" runat="server" text="<--&nbsp;Add" onclick="Button_add_Click" ValidationGroup="OperationalPeriodDetail"></asp:Button></td>
                      <td></td>
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
</table>
