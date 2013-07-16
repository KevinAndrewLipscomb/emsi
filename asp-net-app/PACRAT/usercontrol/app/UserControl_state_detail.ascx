<%@ Control Language="c#" AutoEventWireup="True" Codebehind="UserControl_state_detail.ascx.cs" Inherits="UserControl_state_detail.TWebUserControl_state_detail"%>
<!-- Derived from KiAspdotnetFramework/usercontrol/app/UserControl~template~datagrid~sortable.ascx-template -->
<asp:UpdatePanel id="UpdatePanel_control" runat="server" updatemode="Conditional">
  <ContentTemplate>
    <table bordercolor="#dcdcdc" cellspacing="0" cellpadding="0" border="1">
      <tr>
        <td>
          <table cellspacing="0" cellpadding="10" border="0">
            <tr><td bgcolor="#dcdcdc"><strong>Pennsylvania EMS Strike Team program</strong></td></tr>
            <tr id="TableRow_none" runat="server"><td><em>--&nbsp;NONE&nbsp;--</em></td></tr>
            <tr>
              <td>
                <asp:DataGrid id="DataGrid_control" runat="server" gridlines="Horizontal" cellpadding="10" autogeneratecolumns="False" allowsorting="True">
                  <Columns>
                    <asp:ButtonColumn text="&lt;IMG src=&quot;~/protected/image/open_document16_h.png&quot; alt=&quot;Detail&quot; border=&quot;0&quot; height=&quot;16&quot; width=&quot;16&quot; /&gt;" commandname="Manage"></asp:ButtonColumn>
                    <asp:BoundColumn datafield="code" Visible="false"></asp:BoundColumn>
                    <asp:BoundColumn datafield="name" headertext="Name" sortexpression="name%">
                      <HeaderStyle horizontalalign="Left"></HeaderStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn datafield="be_pacrat_subscriber" headertext="Subscriber?" sortexpression="be_pacrat_subscriber%,name">
                      <ItemStyle horizontalalign="Center"></ItemStyle>
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
