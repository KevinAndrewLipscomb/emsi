<%@ Control Language="c#" AutoEventWireup="True" Codebehind="UserControl_strike_team_deployment_catalog.ascx.cs" Inherits="UserControl_strike_team_deployment_catalog.TWebUserControl_strike_team_deployment_catalog"%>
<!-- Derived from KiAspdotnetFramework/usercontrol/app/UserControl~template~datagrid~sortable.ascx-template -->
<asp:UpdatePanel id="UpdatePanel_control" runat="server" updatemode="Conditional">
  <ContentTemplate>
    <table bordercolor="#dcdcdc" cellspacing="0" cellpadding="0" border="1">
      <tr>
        <td>
          <table cellspacing="0" cellpadding="10" border="0">
            <tr>
              <td bgcolor="#dcdcdc">
                <table cellspacing="0" cellpadding="0" border="0">
                  <tr>
                    <td><strong>Filter:&nbsp;<asp:DropDownList id="DropDownList_filter" runat="server" autopostback="True"></asp:DropDownList></strong></td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td align="right"><asp:Literal ID="Literal_num_strike_team_deployments" runat="server"></asp:Literal> strike team deployments</td>
                  </tr>
                  <tr>
                    <td align="right" colspan="3" nowrap="nowrap">
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator_new_deployment_name" runat="server" ControlToValidate="TextBox_new_deployment_name" ErrorMessage="Please enter a New deployment name." Font-Bold="True" ValidationGroup="NewDeploymentName">!ERR&gt;</asp:RequiredFieldValidator>
                      New deployment:<asp:TextBox ID="TextBox_new_deployment_name" runat="server" Columns="40" MaxLength="127" ValidationGroup="NewDeploymentName"></asp:TextBox><asp:Button ID="Button_add" runat="server" Text="Add" ValidationGroup="NewDeploymentName" onclick="Button_add_Click" />
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
                    <asp:BoundColumn datafield="id" Visible="false"></asp:BoundColumn>
                    <asp:BoundColumn datafield="creation_date" headertext="Created" sortexpression="creation_date%,name"></asp:BoundColumn>
                    <asp:BoundColumn datafield="name" headertext="Name" sortexpression="name%,creation_date"></asp:BoundColumn>
                    <asp:ButtonColumn text="&lt;IMG src=&quot;~/protected/image/delete_x16_h.png&quot; alt=&quot;Delete&quot; border=&quot;0&quot; height=&quot;16&quot; width=&quot;16&quot; /&gt;" commandname="Delete"></asp:ButtonColumn>
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
