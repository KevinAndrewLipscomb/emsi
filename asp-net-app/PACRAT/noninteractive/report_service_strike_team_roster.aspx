<%@ Page language="c#" Debug="true" Codebehind="report_service_strike_team_roster.aspx.cs" AutoEventWireup="True" Inherits="report_service_strike_team_roster.TWebForm_report_service_strike_team_roster" EnableViewState="false" %>
<%@ Register src="../usercontrol/app/UserControl_common_header_bar.ascx" tagname="UserControl_common_header_bar" tagprefix="uc1" %>
<%@ Register src="../usercontrol/app/UserControl_static_service_strike_team_roster.ascx" tagname="UserControl_static_service_strike_team_roster" tagprefix="uc2" %>
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
                <tr><td bgcolor="#f5f5f5"><strong>Monthly CURRENT STRIKE TEAM ROSTER</strong></td></tr>
                <tr>
                  <td>
                    <small>
                      <p>Best practices:</p>
                      <ul>
                        <li><p>This report shows your service's strike team roster as currently recorded in <asp:Label ID="Label_application_name_1" runat="server" Font-Bold="True"></asp:Label>.</p></li>
                        <li><p>Keep your strike team roster current in case of unscheduled deployments.</p></li>
                        <li>
                          <p>
                            A <asp:Image ID="Image_uncredentialed" runat="server" AlternateText="Uncredentialed" Height="16px" ImageUrl="@image/dialog-warning-2.png" Width="16px" /> icon means <span style="text-decoration: underline">your action is required</span> because the
                            member's <asp:Label ID="Label_application_name_3" runat="server" Font-Bold="True"></asp:Label> record fails at least one credentialing requirement (that is, the member is UNCREDENTIALED) for strike team
                            purposes.&nbsp; You should update the member's record to show compliance, compel the member to achieve compliance, or remove the member from your strike team roster.
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
      <uc2:UserControl_static_service_strike_team_roster ID="UserControl_static_service_strike_team_roster_control" runat="server" />
    </form>
  </body>
</html>
