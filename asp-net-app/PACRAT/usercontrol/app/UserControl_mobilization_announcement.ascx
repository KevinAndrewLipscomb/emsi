<%@ Control Language="c#" AutoEventWireup="True" Codebehind="UserControl_mobilization_announcement.ascx.cs" Inherits="UserControl_mobilization_announcement.TWebUserControl_mobilization_announcement"%>
<!-- Derived from KiAspdotnetFramework/usercontrol/app/UserControl~template~std.ascx-template -->
<h3>Mobilization announcement</h3>
<asp:UpdatePanel ID="UpdatePanel_control" runat="server" UpdateMode="Conditional">
  <ContentTemplate>
<table cellpadding="5" cellspacing="0">
  <tr>
    <td valign="top">To Service Strike Team Managers in:</td>
    <td valign="top">
      <asp:LinkButton ID="LinkButton_expand_state" runat="server" OnClick="LinkButton_expand_state_Click" Font-Names="Courier New" CausesValidation="False">[+]</asp:LinkButton><asp:CheckBox ID="CheckBox_force_state" runat="server" Checked="true" AutoPostBack="True" oncheckedchanged="CheckBox_force_state_CheckedChanged" ToolTip="Select/Unselect state"/> Pennsylvania
      <asp:DataGrid id="DataGrid_regions" runat="server" cellpadding="5" autogeneratecolumns="False" ShowHeader="False" GridLines="None" Visible="false" OnItemDataBound="DataGrid_regions_ItemDataBound">
        <Columns>
          <asp:BoundColumn DataField="code" Visible="False"></asp:BoundColumn>
          <asp:TemplateColumn><ItemTemplate>&nbsp;&nbsp;</ItemTemplate></asp:TemplateColumn>
          <asp:TemplateColumn>
            <ItemTemplate>
              <asp:LinkButton ID="LinkButton_expand_region" runat="server" OnClick="LinkButton_expand_region_Click" Font-Names="Courier New" CausesValidation="False">[+]</asp:LinkButton><asp:CheckBox ID="CheckBox_force_region" runat="server" Checked="true" AutoPostBack="True" oncheckedchanged="CheckBox_force_region_CheckedChanged" ToolTip="Select/Unselect region"/> <asp:Label id="Label_service_name" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.name") %>'></asp:Label>
              <asp:DataGrid id="DataGrid_services" runat="server" cellpadding="5" autogeneratecolumns="False" ShowHeader="False" GridLines="None" Visible="false">
                <Columns>
                <asp:BoundColumn DataField="id" Visible="False"></asp:BoundColumn>
                <asp:TemplateColumn><ItemTemplate>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</ItemTemplate></asp:TemplateColumn>
                <asp:TemplateColumn>
                  <ItemTemplate>
                    <asp:CheckBox ID="CheckBox_include_service" runat="server" Checked="true" ToolTip="Select/Unselect service"/> <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.short_name") %>'></asp:Label>
                  </ItemTemplate>
                </asp:TemplateColumn>
                </Columns>
              </asp:DataGrid>
            </ItemTemplate>
          </asp:TemplateColumn>
        </Columns>
      </asp:DataGrid>
    </td>
    <td valign="top">
      <asp:CustomValidator ID="CustomValidator_service_strike_teams" runat="server" ErrorMessage="Please select at least one Service Strike Team." Font-Bold="True" onservervalidate="CustomValidator_service_strike_teams_ServerValidate">!ERR!</asp:CustomValidator>
    </td>
  </tr>
  <tr>
    <td valign="top">Deployment open for mobilization:</td>
    <td valign="top"><asp:Label ID="Label_deployment_name" runat="server" Font-Bold="True"></asp:Label></td>
    <td valign="top">&nbsp;</td>
  </tr>
  <tr>
    <td valign="top">Announcement:</td>
    <td valign="top">
      When you announce this mobilization, <asp:Literal ID="Literal_application_name" runat="server"></asp:Literal> will send the following to the selected Service Strike Team Managers:
      <ul>
        <li><p>An SMS message indicating that a deployment is open for mobilization and advising them to check their email.</p></li>
        <li>
          An email containing:
          <ul>
            <li>Instructions for marking their personnel and vehicles as mobilized for this deployment</li>
            <li>An indication of whether this is an actual deployment or a drill, as you previously specified</li>
            <li><strong>Any <u>supplemental message</u> that you specify below &darr;&darr;&darr;</strong></li>
          </ul>
        </li>
      </ul>
    </td>
    <td valign="top">&nbsp;</td>
  </tr>
  <tr>
    <td valign="top">
      <p>Supplemental message:</p>
      <asp:Panel ID="Panel_hint" runat="server" BackColor="Khaki">
        <small>Specify time and place to muster if known &rarr;</small>
      </asp:Panel>
    </td>
    <td valign="top"><asp:TextBox ID="TextBox_supplemental_message" runat="server" Columns="72" Rows="6" TextMode="MultiLine"></asp:TextBox></td>
    <td valign="top">&nbsp;</td>
  </tr>
  <tr>
    <td>&nbsp;</td>
    <td><asp:Button ID="Button_submit" runat="server" Text="Announce mobilization" onclick="Button_submit_Click" /></td>
    <td valign="top">&nbsp;</td>
  </tr>
</table>
  </ContentTemplate>
</asp:UpdatePanel>
