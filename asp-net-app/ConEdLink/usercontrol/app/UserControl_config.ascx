<%@ Control Language="c#" AutoEventWireup="True" Codebehind="UserControl_config.ascx.cs" Inherits="UserControl_config.TWebUserControl_config"%>
<!-- Derived from KiAspdotnetFramework/usercontrol/app/UserControl~template~std.ascx-template -->
<table bordercolor="#dcdcdc" cellspacing="0" cellpadding="0" width="100%" border="1">
  <tr>
    <td>
      <table cellspacing="0" cellpadding="10" width="100%" border="0">
        <tr bgcolor="#f5f5f5"><td><strong>Regional configuration settings</strong></td></tr>
        <tr>
          <td>
            <table cellpadding="10" cellspacing="0">
              <tr>
                <td valign="top"><strong>Evaluation Summary Mode:</strong></td>
                <td valign="top"><asp:RadioButtonList ID="RadioButtonList_eval_summary_mode" runat="server" AutoPostBack="True" onselectedindexchanged="RadioButtonList_eval_summary_mode_SelectedIndexChanged"/></td>
              </tr>
            </table>
          </td>
        </tr>
      </table>
    </td>
  </tr>
</table>
