<%@ Control Language="c#" AutoEventWireup="True" CodeBehind="UserControl_training_certificate.ascx.cs" Inherits="UserControl_training_certificate.TWebUserControl_training_certificate" %>
<!-- Derived from KiAspdotnetFramework/usercontrol/app/UserControl~template~std.ascx-template -->
<table align="center" cellspacing="0" cellpadding="5" width="100%" style="border:1px double gray">
  <tr align="center"><td><asp:Image ID="Image_banner" runat="server" AlternateText="Banner" Height="235px" ImageUrl="@image/training-certificate-banner.png" Width="868px" /></td></tr>
  <tr align="center">
    <td>
      <table cellpadding="10" cellspacing="0" style="border-left:1px solid gainsboro; border-right:1px solid gainsboro">
        <tr>
          <td align="center">
            <big><big><strong><asp:Literal ID="Literal_sponsor_name" runat="server"></asp:Literal></strong></big></big>
            <table cellpadding="5" cellspacing="0"><tr align="center"><td><small>Sponsor # <asp:Literal ID="Literal_sponsor_number" runat="server"></asp:Literal></small></td></tr></table>
          </td>
        </tr>
      </table>
    </td>
  </tr>
  <tr align="center"><td><em>hereby certifies that</em></td></tr>
  <tr align="center">
    <td>
      <table cellpadding="10" cellspacing="0" style="border-left:1px solid gainsboro; border-right:1px solid gainsboro">
        <tr>
          <td align="center">
            <big><big><big><strong><asp:Literal ID="Literal_practitioner_name" runat="server"></asp:Literal></strong></big></big></big>
            <table cellpadding="5" cellspacing="0">
              <tr align="center">
                <td><small>Cert # <asp:Literal ID="Literal_certification_number" runat="server"></asp:Literal></small></td>
                <td>
                  <small>Cert level: <asp:Literal ID="Literal_practitioner_level_emsrs_code" runat="server"></asp:Literal> (<asp:Literal ID="Literal_practitioner_level_short_description" runat="server"></asp:Literal>)</small>
                </td>
                <td><small>DOB: <asp:Literal ID="Literal_dob" runat="server"></asp:Literal></small></td>
              </tr>
            </table>
          </td>
        </tr>
      </table>
    </td>
  </tr>
  <tr align="center">
    <td>
      <em>
        <asp:Literal ID="Literal_completed" runat="server" Visible="false">successfully completed</asp:Literal>
        <asp:Literal ID="Literal_taught" runat="server" Visible="false">participated as an Instructor for</asp:Literal>
        the following Continuing Education Course:
      </em>
    </td>
  </tr>
  <tr align="center">
    <td>
      <table cellpadding="10" cellspacing="0" style="border-left:1px solid gainsboro; border-right:1px solid gainsboro">
        <tr>
          <td align="center">
            <big><big><big><strong><asp:Literal ID="Literal_course_title" runat="server"></asp:Literal></strong></big></big></big>
            <table cellpadding="5" cellspacing="0"><tr align="center"><td><small># <asp:Literal ID="Literal_course_number" runat="server"></asp:Literal></small></td></tr></table>
          </td>
        </tr>
      </table>
    </td>
  </tr>
  <tr align="center"><td><em>for</em></td></tr>
  <tr id="TableRow_ceus" runat="server" align="center" visible="false">
    <td><strong><asp:Literal ID="Literal_total_ce_hours" runat="server"></asp:Literal></strong> CEUs (<strong><asp:Literal ID="Literal_num_med_trauma_hours" runat="server"></asp:Literal></strong> Med/Trauma)</td>
  </tr>
  <tr id="TableRow_instructor_hours" runat="server" align="center" visible="false"><td><strong><asp:Literal ID="Literal_instructor_hours" runat="server"></asp:Literal></strong> Instructor hours</td></tr>
  <tr align="center"><td><em>on</em></td></tr>
  <tr align="center"><td><strong><asp:Literal ID="Literal_date_final" runat="server"></asp:Literal></strong></td></tr>
</table>
