<%@ Control Language="c#" AutoEventWireup="True" Codebehind="UserControl_coned_sponsor_user.ascx.cs" Inherits="UserControl_coned_sponsor_user.TWebUserControl_coned_sponsor_user"%>
<%@ Register TagPrefix="uc1" TagName="UserControl_drop_down_date" Src="~/usercontrol/ki/UserControl_drop_down_date.ascx" %>
<table cellspacing="0" cellpadding="5" width="100%" border="0">
  <tr>
    <td valign="top">
      <table cellspacing="0" cellpadding="5" border="0">
  <tr>
    <td valign="top" nowrap="nowrap">Be active:</td>
    <td valign="top" align="center"><ASP:CheckBox id="CheckBox_be_active" runat="server" enabled="False"></ASP:CheckBox></td>
    <td valign="top"></td>
    <td valign="top"><small><i>Check to allow sponsor to use the application.&nbsp; Clear to prevent sponsor from using the application.</i></small></td>
  </tr>
  <tr>
    <td valign="top" nowrap="nowrap">Be ok to input roster by batch:</td>
    <td valign="top" align="center"><ASP:CheckBox id="CheckBox_be_ok_to_input_roster_by_batch" runat="server" enabled="False"></ASP:CheckBox></td>
    <td valign="top"></td>
    <td valign="top"><small><i>Check to allow sponsor to input rosters using the "Scan batch" method.&nbsp; Clear to prevent sponsor from using the "Scan batch" method.</i></small></td>
  </tr>
  <tr>
    <td valign="top" nowrap="nowrap">Be ok to input roster by copy:</td>
    <td valign="top" align="center"><ASP:CheckBox id="CheckBox_be_ok_to_input_roster_by_copy" runat="server" enabled="False"></ASP:CheckBox></td>
    <td valign="top"></td>
    <td valign="top"><small><i>Check to allow sponsor to input rosters using the "Copy from other roster" method.&nbsp; Clear to prevent sponsor from using the "Copy from other roster" method.</i></small></td>
  </tr>
  <tr>
    <td valign="top"></td>
    <td valign="top" align="center"><ASP:Button id="Button_submit" text="Submit" runat="server" enabled="False" onclick="Button_submit_Click"></ASP:Button></td>
    <td valign="top"></td>
    <td valign="top"><small><i>Changes take effect next time sponsor logs in.</i></small></td>
  </tr>
      </table>
    </td>
  </tr>
</table>
