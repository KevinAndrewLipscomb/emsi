<%@ Control Language="c#" AutoEventWireup="True" Codebehind="UserControl_vehicles.ascx.cs" Inherits="UserControl_vehicles.TWebUserControl_vehicles"%>
<!-- Derived from KiAspdotnetFramework/usercontrol/app/UserControl~template~datagrid~sortable.ascx-template -->
<asp:UpdatePanel id="UpdatePanel_control" runat="server" updatemode="Conditional">
  <ContentTemplate>
    <table bordercolor="#dcdcdc" cellspacing="0" cellpadding="0" border="1">
      <tr>
        <td>
          <table cellspacing="0" cellpadding="10" border="0">
            <tr>
              <td bgcolor="#dcdcdc">
                <table cellspacing="0" cellpadding="10" border="0" width="100%">
                  <tr>
                    <td colspan="5"><strong><asp:Literal ID="Literal_service_name" runat="server"></asp:Literal> <em>strike team vehicles</em></strong></td>
                  </tr>
                  <tr>
                    <td><strong>Filter:&nbsp;<asp:DropDownList id="DropDownList_filter" runat="server" autopostback="True"></asp:DropDownList></strong></td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td align="right"><asp:Literal ID="Literal_num_vehicles" runat="server"></asp:Literal> vehicles</td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td><asp:LinkButton ID="LinkButton_new" runat="server" Font-Bold="True" onclick="LinkButton_new_Click" Visible="False">NEW</asp:LinkButton></td>
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
                    <asp:BoundColumn datafield="name" headertext="Name" sortexpression="name%"></asp:BoundColumn>
                    <asp:BoundColumn DataField="patient_care_level" HeaderText="Lvl" SortExpression="patient_care_level.pecking_order%,name">
                      <HeaderStyle HorizontalAlign="Center" />
                      <ItemStyle HorizontalAlign="Center"/>
                    </asp:BoundColumn>
                    <asp:BoundColumn datafield="kind" headertext="Kind" sortexpression="kind%,name">
                      <HeaderStyle HorizontalAlign="Center" />
                      <ItemStyle HorizontalAlign="Center"/>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="pa_doh_decal_num" HeaderText="Decal #" ReadOnly="True" SortExpression="pa_doh_decal_num%,name">
                      <HeaderStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="tow_capacity" HeaderText="Tow cap" ReadOnly="True" SortExpression="tow_capacity_id%,name">
                      <HeaderStyle HorizontalAlign="Center" />
                      <ItemStyle HorizontalAlign="Center"/>
                    </asp:BoundColumn>
                    <asp:BoundColumn datafield="fuel" headertext="Fuel" sortexpression="fuel%,name">
                      <HeaderStyle HorizontalAlign="Center" />
                      <ItemStyle HorizontalAlign="Center"/>
                    </asp:BoundColumn>
                    <asp:BoundColumn datafield="be_four_or_all_wheel_drive" headertext="AWD?" sortexpression="be_four_or_all_wheel_drive%,name">
                      <HeaderStyle HorizontalAlign="Center" />
                      <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn datafield="license_plate" headertext="Tag" sortexpression="license_plate%,name"></asp:BoundColumn>
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
