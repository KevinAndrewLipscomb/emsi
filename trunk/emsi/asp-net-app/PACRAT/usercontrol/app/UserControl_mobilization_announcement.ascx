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
          <td valign="top"><small><strong>All:</strong><asp:CheckBox ID="CheckBox_force_all" runat="server" Checked="true" AutoPostBack="True" oncheckedchanged="CheckBox_force_all_CheckedChanged" style="outline:2px solid SlateGray" ToolTip="Select/Unselect all"/></small></td>
          <td><small><asp:CheckBoxList ID="CheckBoxList_service_strike_teams" runat="server" RepeatLayout="Flow"></asp:CheckBoxList></small></td>
        </tr>
      </table>
    </td>
    <td valign="top">
      <asp:CustomValidator ID="CustomValidator_service_strike_teams" runat="server" ErrorMessage="Please select at least one Service Strike Team." Font-Bold="True" onservervalidate="CustomValidator_service_strike_teams_ServerValidate">!ERR!</asp:CustomValidator>
    </td>
  </tr>
  <tr>
    <td valign="top">Deployment open for mobilization:</td>
    <td valign="top"><asp:Literal ID="Literal_deployment_name" runat="server"></asp:Literal></td>
    <td valign="top">&nbsp;</td>
  </tr>
  <tr>
    <td valign="top">Announcement:</td>
    <td valign="top">
      The selected Service Strike Team Managers will receive:
      <ul>
        <li>An SMS message indicating that a deployment is open for mobilization and advising them to check their email.</li>
        <li>
          An email containing:
          <ul>
            <li>Instructions for marking their personnel and vehicles as mobilized for this deployment</li>
            <li>An indication of whether this is an actual deployment or a drill, as you previously specified</li>
            <li>Any supplemental message that you specify below.</li>
          </ul>
        </li>
      </ul>
    </td>
    <td valign="top">&nbsp;</td>
  </tr>
  <tr>
    <td valign="top">
      <p>Supplemental message:</p>
      <small>Specify time and place to muster if known.</small>
    </td>
    <td valign="top"><asp:TextBox ID="TextBox_supplemental_message" runat="server" Columns="72" Rows="6" TextMode="MultiLine"></asp:TextBox></td>
    <td valign="top">&nbsp;</td>
  </tr>
  <tr>
    <td>&nbsp;</td>
    <td><asp:Button ID="Button_submit" runat="server" Text="Send" onclick="Button_submit_Click" /></td>
    <td valign="top">&nbsp;</td>
  </tr>
</table>
  </ContentTemplate>
</asp:UpdatePanel>
