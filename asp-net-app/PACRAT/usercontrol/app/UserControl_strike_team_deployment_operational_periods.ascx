<%@ Control Language="c#" AutoEventWireup="True" Codebehind="UserControl_strike_team_deployment_operational_periods.ascx.cs" Inherits="UserControl_strike_team_deployment_operational_periods.TWebUserControl_strike_team_deployment_operational_periods"%>
<!-- Derived from KiAspdotnetFramework/usercontrol/app/UserControl~template~datagrid~sortable.ascx-template -->
<asp:UpdatePanel id="UpdatePanel_control" runat="server" updatemode="Conditional">
  <ContentTemplate>
    <table bordercolor="#dcdcdc" cellspacing="0" cellpadding="0" border="1">
      <tr>
        <td>
          <table cellspacing="0" cellpadding="10" border="0">
            <tr>
              <td bgcolor="#dcdcdc">
                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                  <tr>
                    <td id="Td_filter" runat="server"><strong>Filter:&nbsp;<asp:DropDownList id="DropDownList_filter" runat="server" autopostback="True"></asp:DropDownList></strong></td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td align="right"><asp:Literal ID="Literal_num_operational_periods" runat="server"></asp:Literal> operational&nbsp;periods</td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
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
                    <asp:TemplateColumn HeaderText="Kind">
                      <HeaderStyle HorizontalAlign="Center" />
                      <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateColumn>
                    <asp:BoundColumn DataField="prelim_shift_name" HeaderText="Prelim name" ReadOnly="True">
                      <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn datafield="start" headertext="Start" sortexpression="start%,end"></asp:BoundColumn>
                    <asp:BoundColumn datafield="end" headertext="End" sortexpression="end%,start"></asp:BoundColumn>
                    <asp:BoundColumn DataField="be_convoy" Visible="False"></asp:BoundColumn>
                    <asp:HyperLinkColumn Target="_blank" Text="&lt;IMG src=&quot;image/print16_h.png&quot; alt=&quot;For IAP&quot; border=&quot;0&quot; height=&quot;16&quot; width=&quot;16&quot; /&gt;" HeaderText="For IAP" NavigateUrl="~/protected/per_op_period_iap.aspx?">
                      <ItemStyle HorizontalAlign="Center" />
                    </asp:HyperLinkColumn>
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
