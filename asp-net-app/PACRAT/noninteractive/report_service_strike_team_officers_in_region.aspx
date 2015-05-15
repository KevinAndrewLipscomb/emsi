<%@ Page language="c#" Debug="true" Codebehind="report_service_strike_team_officers_in_region.aspx.cs" AutoEventWireup="True" Inherits="report_service_strike_team_officers_in_region.TWebForm_report_service_strike_team_officers_in_region" EnableViewState="false" %>
<%@ Register src="../usercontrol/app/UserControl_common_header_bar.ascx" tagname="UserControl_common_header_bar" tagprefix="uc1" %>
<%@ Register src="../usercontrol/app/UserControl_service_strike_team_officers_in_region.ascx" tagname="UserControl_service_strike_team_officers_in_region" tagprefix="uc3" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/strict.dtd">
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
                <tr><td bgcolor="#f5f5f5"><strong>Monthly CURRENT STRIKE TEAM OFFICERS IN REGION <asp:Literal ID="Literal_emsrs_code" runat="server"></asp:Literal></strong></td></tr>
                <tr>
                  <td>
                    <small>
                      <p>Best practices:</p>
                      <ul>
                        <li><p>This report shows your region's Strike Team Program participating services and their officers as currently recorded in <asp:Label ID="Label_application_name_1" runat="server" Font-Bold="True"></asp:Label>.</p></li>
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
      <uc3:UserControl_service_strike_team_officers_in_region ID="UserControl_service_strike_team_officers_in_region_control" runat="server" />
    </form>
  </body>
</html>
