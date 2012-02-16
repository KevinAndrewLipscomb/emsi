<%@ Control Language="c#" AutoEventWireup="True" CodeBehind="UserControl_training_certificate.ascx.cs" Inherits="UserControl_training_certificate.TWebUserControl_training_certificate" %>
<!-- Derived from KiAspdotnetFramework/usercontrol/app/UserControl~template~std.ascx-template -->
<table cellspacing="0" cellpadding="10" width="100%" style="border: 1px double gray" align="center">
  <tr align="center"><td><img alt="" src="../../protected/image/training-certificate-banner.png" /></td></tr>
  <tr align="center"><td><h2><asp:Literal ID="Literal_sponsor_name" runat="server"></asp:Literal></h2></td></tr>
  <tr align="center"><td><em>hereby certifies that</em></td></tr>
  <tr align="center"><td><h1><asp:Literal ID="Literal_practitioner_name" runat="server"></asp:Literal></h1></td></tr>
  <tr align="center">
    <td>
      <table cellpadding="5" cellspacing="0" width="75%">
        <tr align="center">
          <td><small>Cert # <asp:Literal ID="Literal_certification_number" runat="server"></asp:Literal></small></td>
          <td><small>Cert level: <asp:Literal ID="Literal_practitioner_level_emsrs_code" runat="server"></asp:Literal> (<asp:Literal ID="Literal_practitioner_level_short_description" runat="server"></asp:Literal>)</small></td>
          <td><small>DOB: <asp:Literal ID="Literal_dob" runat="server"></asp:Literal></small></td>
        </tr>
      </table>
    </td>
  </tr>
  <tr align="center"><td><em>successfully completed the following Continuing Education Course:</em></td></tr>
  <tr align="center"><td><h3># <asp:Literal ID="Literal_course_number" runat="server"></asp:Literal><br /><asp:Literal ID="Literal_course_title" runat="server"></asp:Literal></h3></td></tr>
  <tr align="center"><td><em>for</em></td></tr>
  <tr align="center"><td><strong><asp:Literal ID="Literal_total_ce_hours" runat="server"></asp:Literal></strong> CEUs (<strong><asp:Literal ID="Literal_num_med_trauma_hours" runat="server"></asp:Literal></strong> Med/Trauma)</td></tr>
  <tr align="center"><td><em>on</em></td></tr>
  <tr align="center"><td><strong><asp:Literal ID="Literal_date_final" runat="server"></asp:Literal></strong></td></tr>
  <tr align="center"><td><pre><small>[frompaper2web.com/ConEdLink authentication hex code: <asp:Literal ID="Literal_authentication_hex_code" runat="server"></asp:Literal>]</small></pre></td></tr>
</table>
