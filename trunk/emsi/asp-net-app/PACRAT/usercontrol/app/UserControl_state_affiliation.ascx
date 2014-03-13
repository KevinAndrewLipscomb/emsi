<%@ Control Language="c#" AutoEventWireup="True" Codebehind="UserControl_state_affiliation.ascx.cs" Inherits="UserControl_state_affiliation.TWebUserControl_state_affiliation"%>
<%@ Register src="UserControl_other_prep_ops.ascx" tagname="UserControl_other_prep_ops" tagprefix="uc1" %>
<!-- Derived from KiAspdotnetFramework/usercontrol/app/UserControl~template~datagrid~sortable.ascx-template -->
<table bordercolor="#dcdcdc" cellspacing="0" cellpadding="0" border="1">
  <tr>
    <td>
      <table cellspacing="0" cellpadding="10" border="0">
        <tr><td bgcolor="#dcdcdc"><b>State EMS Strike Teams that you manage</b></td></tr>
        <tr id="TableRow_none" runat="server"><td><em>--&nbsp;NONE&nbsp;--</em></td></tr>
        <tr id="TableRow_data" runat="server" visible="false">
          <td>
            <table cellpadding="10" cellspacing="0">
              <tr>
                <td>
                  <asp:LinkButton ID="LinkButton_control" runat="server" Text="&lt;IMG src=&quot;~/protected/image/open_document16_h.png&quot; alt=&quot;Detail&quot; border=&quot;0&quot; height=&quot;16&quot; width=&quot;16&quot; /&gt;" onclick="LinkButton_control_Click"></asp:LinkButton>
                </td>
                <td>Pennsylvania</td>
              </tr>
            </table>
          </td>
        </tr>
      </table>
    </td>
  </tr>
</table>
<uc1:UserControl_other_prep_ops ID="UserControl_other_prep_ops_control" runat="server" visible="false"/>

