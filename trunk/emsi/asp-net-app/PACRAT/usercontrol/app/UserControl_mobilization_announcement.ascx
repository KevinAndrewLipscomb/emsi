<%@ Control Language="c#" AutoEventWireup="True" Codebehind="UserControl_mobilization_announcement.ascx.cs" Inherits="UserControl_mobilization_announcement.TWebUserControl_mobilization_announcement"%>
<!-- Derived from KiAspdotnetFramework/usercontrol/app/UserControl~template~std.ascx-template -->
<h3>Mobilization announcement</h3>
<asp:UpdatePanel ID="UpdatePanel_control" runat="server" UpdateMode="Conditional">
  <ContentTemplate>
<table cellpadding="5" cellspacing="0">
  <tr>
    <td valign="top">To managers at:</td>
    <td valign="top">
      <table>
        <tr>
          <td nowrap="nowrap"valign="top"><small><strong>All:</strong><asp:CheckBox ID="CheckBox_force_all" runat="server" Checked="true" AutoPostBack="True" oncheckedchanged="CheckBox_force_all_CheckedChanged" style="outline:2px solid SlateGray" ToolTip="Select/Unselect all"/></small></td>
          <td><small><asp:CheckBoxList ID="CheckBoxList_service_strike_teams" runat="server" RepeatLayout="Flow" RepeatDirection="Vertical"></asp:CheckBoxList></small></td>
        </tr>
      </table>
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
