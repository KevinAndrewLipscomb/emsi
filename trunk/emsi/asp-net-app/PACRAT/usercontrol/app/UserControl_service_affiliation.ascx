<%@ Control Language="c#" AutoEventWireup="True" Codebehind="UserControl_service_affiliation.ascx.cs" Inherits="UserControl_service_affiliation.TWebUserControl_service_affiliation"%>
<!-- Derived from KiAspdotnetFramework/usercontrol/app/UserControl~template~datagrid~sortable.ascx-template -->
<asp:UpdatePanel id="UpdatePanel_control" runat="server" updatemode="Conditional">
  <ContentTemplate>
    <table bordercolor="#dcdcdc" cellspacing="0" cellpadding="0" border="1">
      <tr>
        <td>
          <table cellspacing="0" cellpadding="10" border="0">
            <tr><td bgcolor="#dcdcdc"><b>Service EMS Strike Teams that you manage</b></td></tr>
            <tr id="TableRow_none" runat="server"><td><em>--&nbsp;NONE&nbsp;--</em></td></tr>
            <tr id="TableRow_data" runat="server" visible="false">
              <td>
                <asp:DataGrid id="DataGrid_control" runat="server" gridlines="Horizontal" cellpadding="10" autogeneratecolumns="False" allowsorting="True">
                  <Columns>
                    <asp:ButtonColumn text="&lt;IMG src=&quot;~/protected/image/open_document16_h.png&quot; alt=&quot;Detail&quot; border=&quot;0&quot; height=&quot;16&quot; width=&quot;16&quot; /&gt;&lt;br/&gt;&lt;small&gt;MEMBERS&lt;/small&gt;" commandname="ManagePersonnel">
                      <ItemStyle HorizontalAlign="Center" />
                    </asp:ButtonColumn>
                    <asp:ButtonColumn text="&lt;IMG src=&quot;~/protected/image/open_document16_h.png&quot; alt=&quot;Detail&quot; border=&quot;0&quot; height=&quot;16&quot; width=&quot;16&quot; /&gt;&lt;br/&gt;&lt;small&gt;VEHICLES&lt;/small&gt;" commandname="ManageVehicles">
                      <ItemStyle HorizontalAlign="Center" />
                    </asp:ButtonColumn>
                    <asp:BoundColumn datafield="service_id" Visible="false"></asp:BoundColumn>
                    <asp:BoundColumn datafield="service_affiliate_num" headertext="#" sortexpression="service_affiliate_num%">
                      <HeaderStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn datafield="service_name" headertext="Name" sortexpression="service_name%">
                      <HeaderStyle horizontalalign="Left"></HeaderStyle>
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
