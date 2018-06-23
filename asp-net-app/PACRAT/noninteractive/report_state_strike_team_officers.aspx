<%@ Page language="c#" Debug="true" Codebehind="report_state_strike_team_officers.aspx.cs" AutoEventWireup="True" Inherits="report_state_strike_team_officers.TWebForm_report_state_strike_team_officers" EnableViewState="false" %>
<%@ Register src="../usercontrol/app/UserControl_common_header_bar.ascx" tagname="UserControl_common_header_bar" tagprefix="uc1" %>
<%@ Register src="../usercontrol/app/UserControl_static_state_strike_team_key_personnel.ascx" tagname="UserControl_static_state_strike_team_key_personnel" tagprefix="uc3" %>
<!DOCTYPE HTML>
<html>
  <head runat="server">
    <title></title>
  </head>
  <body bgcolor="white">
	  <form runat="server">
      <uc1:UserControl_common_header_bar ID="UserControl_common_header_bar_control" runat="server" />
      <p>
        <table bordercolor="#dcdcdc" cellspacing="0" cellpadding="0" border="1" width="100%">
          <tr>
            <td>
              <table cellspacing="0" cellpadding="10" width="100%" border="0">
                <tr><td bgcolor="#f5f5f5"><strong>Monthly CURRENT STATE STRIKE TEAM OFFICERS</strong></td></tr>
                <tr>
                  <td>
                    <small>
                      <p>Best practices:</p>
                      <ul>
                        <li><p>This report shows your state's Strike Team Program officers as currently recorded in <asp:Label ID="Label_application_name_1" runat="server" Font-Bold="True"></asp:Label>.</p></li>
                        <li><p>Keep this data current in case of unscheduled deployments.</p></li>
                        <li>
                          <p>
                            A <asp:Image ID="Image_uncredentialed" runat="server" AlternateText="Uncredentialed" Height="16px" ImageUrl="@image/dialog-warning-2.png" Width="16px" /> icon means the officer's <asp:Label ID="Label_application_name_3" runat="server" Font-Bold="True"></asp:Label> record fails at least one credentialing requirement (that is, the officer is UNCREDENTIALED) for strike team purposes.
                          </p>
                        </li>
                        <li>
                          <p>
                            Visit <asp:Label ID="Label_application_name_2" runat="server" Font-Bold="True"></asp:Label> to make updates and to use additional features, such as advanced filtering, sorting, detail lookups, and
                            QuickMessaging:
                          </p>
                          <blockquote><asp:HyperLink ID="HyperLink_web_site" runat="server" Font-Bold="True"></asp:HyperLink></blockquote>
                        </li>
                      </ul>
                    </small>
                  </td>
                </tr>
              </table>
            </td>
          </tr>
        </table>
      </p>
      <uc3:UserControl_static_state_strike_team_key_personnel ID="UserControl_static_state_strike_team_key_personnel_control" runat="server" />
    </form>
  </body>
</html>
