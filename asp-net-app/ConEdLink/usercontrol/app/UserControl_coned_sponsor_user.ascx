<%@ Control Language="c#" AutoEventWireup="True" Codebehind="UserControl_coned_sponsor_user.ascx.cs" Inherits="UserControl_coned_sponsor_user.TWebUserControl_coned_sponsor_user"%>
<%@ Register TagPrefix="uc1" TagName="UserControl_drop_down_date" Src="~/usercontrol/ki/UserControl_drop_down_date.ascx" %>
<table cellspacing="0" cellpadding="5" width="100%" border="0">
  <tr>
    <td valign="top">
      <table cellspacing="0" cellpadding="5" border="0">
  <tr>
    <td>Be stale password:</td>
    <td>
      <ASP:CheckBox id="CheckBox_be_stale_password" runat="server" enabled="False"></ASP:CheckBox>
    </td>
    <td>
    </td>
    <td><small><i>Check to force user to reset password upon next login.&nbsp; Clear to allow user to keep using current password.</i></small></td>
  </tr>
  <tr>
    <td>Be active:</td>
    <td>
      <ASP:CheckBox id="CheckBox_be_active" runat="server" enabled="False"></ASP:CheckBox>
    </td>
    <td>
    </td>
    <td><small><i>Check to allow user to use the application.&nbsp; Clear to prevent user from using the application.</i></small></td>
  </tr>
  <tr>
    <td>Be ok to input roster by batch:</td>
    <td>
      <ASP:CheckBox id="CheckBox_be_ok_to_input_roster_by_batch" runat="server" enabled="False"></ASP:CheckBox>
    </td>
    <td>
    </td>
    <td><small><i>Check to allow user to input rosters using the "Scan batch" method.&nbsp; Clear to prevent user from using the "Scan batch" method.</i></small></td>
  </tr>
  <tr>
    <td>Be ok to input roster by copy:</td>
    <td>
      <ASP:CheckBox id="CheckBox_be_ok_to_input_roster_by_copy" runat="server" enabled="False"></ASP:CheckBox>
    </td>
    <td>
    </td>
    <td><small><i>Check to allow user to input rosters using the "Copy from other roster" method.&nbsp; Clear to prevent user from using the "Copy from other roster" method.</i></small></td>
  </tr>
      </table>
    </td>
  </tr>
</table>
<ASP:Button id="Button_submit" text="Submit" runat="server" enabled="False" onclick="Button_submit_Click"></ASP:Button>
