<%@ Control Language="c#" AutoEventWireup="True" Codebehind="UserControl_underway_demobilization.ascx.cs" Inherits="UserControl_underway_demobilization.TWebUserControl_underway_demobilization"%>
<!-- Derived from KiAspdotnetFramework/usercontrol/app/UserControl~template~std.ascx-template -->
<h3>Underway demobilization</h3>
<p>Additional information is required.</p>
<table cellpadding="5" cellspacing="0">
  <tr>
    <td>Underway deployment:</td>
    <td><asp:Literal ID="Literal_deployment_name" runat="server"></asp:Literal></td>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td><asp:Literal ID="Literal_asset_mode" runat="server"></asp:Literal> being demobilized:</td>
    <td><asp:Literal ID="Literal_asset_designator" runat="server"></asp:Literal></td>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td>Reason:</td>
    <td><asp:TextBox ID="TextBox_reason" runat="server" Columns="72" MaxLength="255"></asp:TextBox></td>
    <td>
      <asp:RequiredFieldValidator ID="RequiredFieldValidator_reason" runat="server" ErrorMessage="Please enter a Reason." Font-Bold="True" ControlToValidate="TextBox_reason">!ERR!</asp:RequiredFieldValidator></td>
  </tr>
  <tr>
    <td>&nbsp;</td>
    <td>
      <asp:Button ID="Button_submit" runat="server" Text="Submit" onclick="Button_submit_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button_cancel" runat="server" Text="Cancel" onclick="Button_cancel_Click" CausesValidation="False" /></td>
    <td>
      &nbsp;</td>
  </tr>
</table>
