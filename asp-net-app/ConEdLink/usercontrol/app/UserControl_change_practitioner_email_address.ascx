<%@ Control Language="c#" AutoEventWireup="True" Codebehind="UserControl_change_practitioner_email_address.ascx.cs" Inherits="UserControl_change_practitioner_email_address.TWebUserControl_change_practitioner_email_address"%>
<!-- Derived from KiAspdotnetFramework/usercontrol/app/UserControl~template~std.ascx-template -->
<h3>Change practitioner's email address</h3>
<p>Please check your entry carefully.&nbsp; <asp:Literal ID="Literal_application_name" runat="server"></asp:Literal>, PACRAT, and other entities may use this email address for important communications with this practitioner.</p>
<blockquote>
  <table cellspacing="0" cellpadding="5" border="0">
    <tr>
      <td align="right">Name:</td>
      <td><asp:Literal ID="Literal_name" runat="server"></asp:Literal></td>
      <td>&nbsp;</td>
    </tr>
    <tr>
      <td align="right">Level:</td>
      <td><asp:Literal ID="Literal_level" runat="server"></asp:Literal></td>
      <td>&nbsp;</td>
    </tr>
    <tr>
      <td align="right">Certification #:</td>
      <td><asp:Literal ID="Literal_certification_number" runat="server"></asp:Literal></td>
      <td>&nbsp;</td>
    </tr>
    <tr>
      <td align="right">Birth date:</td>
      <td><asp:Literal ID="Literal_birth_date" runat="server"></asp:Literal></td>
      <td>&nbsp;</td>
    </tr>
    <tr>
      <td align="right">Email address:</td>
      <td>
        <asp:TextBox ID="TextBox_noop_ie_behavior_workaround" runat="server" Style="display: none; visibility: hidden" /><!-- To work around an IE bug that otherwise prevents Enter in a textbox from submitting a form. -->
        <asp:TextBox ID="TextBox_email_address" runat="server" Columns="40"></asp:TextBox>
      </td>
      <td>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator_email_address" runat="server" Font-Bold="True" ErrorMessage="Please enter a valid Email address." ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="TextBox_email_address">!ERR!</asp:RegularExpressionValidator>
        <asp:CustomValidator ID="CustomValidator_email_address" runat="server" ErrorMessage="Please enter a valid domain name (the part after the @ sign)." ControlToValidate="TextBox_email_address" Font-Bold="True" OnServerValidate="CustomValidator_email_address_ServerValidate">!ERR!</asp:CustomValidator>
      </td>
    </tr>
    <tr>
      <td align="right"></td>
      <td>
        <table cellpadding="0" cellspacing="0" width="100%">
          <tr>
            <td align="center"><asp:Button ID="Button_submit" runat="server" Text="Submit" OnClick="Button_submit_Click"></asp:Button></td>
            <td align="center"><asp:Button ID="Button_cancel" runat="server" Text="Cancel" CausesValidation="False" OnClick="Button_cancel_Click"></asp:Button></td>
          </tr>
        </table>
      </td>
      <td></td>
    </tr>
  </table>
</blockquote>
