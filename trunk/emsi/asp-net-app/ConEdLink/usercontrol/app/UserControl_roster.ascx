<%@ Control Language="c#" AutoEventWireup="True" Codebehind="UserControl_roster.ascx.cs" Inherits="UserControl_roster.TWebUserControl_roster"%>
<!-- Derived from KiAspdotnetFramework/usercontrol/app/UserControl~template~std.ascx-template -->
<table cellpadding="0" cellspacing="0">
  <tr>
    <td>
      <table border="1" cellpadding="0" cellspacing="0" style="border-color:Gainsboro; border-width:1px">
        <tr>
          <td>
            <table cellpadding="5" cellspacing="0">
              <tr><td colspan="5"><b><asp:Literal ID="Literal_course_title" runat="server"></asp:Literal></b></td></tr>
              <tr>
                <td nowrap="nowrap" valign="top"><b>Start:</b></td>
                <td nowrap="nowrap" valign="top"><asp:Literal ID="Literal_start" runat="server"></asp:Literal></td>
                <td>&nbsp;</td>
                <td nowrap="nowrap" valign="top"><b>Approved:</b></td>
                <td nowrap="nowrap" valign="top"><asp:Literal ID="Literal_be_approved" runat="server"></asp:Literal></td>
                <td>&nbsp;</td>
                <td nowrap="nowrap" valign="top"><b>Class #:</b></td>
                <td nowrap="nowrap" valign="top"><asp:Literal ID="Literal_class_number" runat="server"></asp:Literal></td>
              </tr>
              <tr>
                <td nowrap="nowrap" valign="top"><b>End:</b></td>
                <td nowrap="nowrap" valign="top"><asp:Literal ID="Literal_end" runat="server"></asp:Literal></td>
                <td>&nbsp;</td>
                <td nowrap="nowrap" valign="top"><b>Length:</b></td>
                <td nowrap="nowrap" valign="top"><asp:Literal ID="Literal_length" runat="server"></asp:Literal></td>
              </tr>
              <tr>
                <td nowrap="nowrap" valign="top"><b>Location:</b></td>
                <td colspan="7" valign="top"><asp:Literal ID="Literal_location" runat="server"></asp:Literal></td>
              </tr>
            </table>
          </td>
        </tr>
      </table>
    </td>
  </tr>
  <tr><td>&nbsp;</td></tr>
  <tr>
    <td>
      <table border="1" cellpadding="0" cellspacing="0" style="border-color:Gainsboro; border-width:1px">
        <tr>
          <td>
            <table cellpadding="10" cellspacing="0">
              <tr><td style="background-color:WhiteSmoke"><b>Attendees</b></td></tr>
              <tr id="TableRow_none" runat="server"><td><em>--&nbsp;NONE&nbsp;--</em></td></tr>
              <tr id="TableRow_attendees" runat="server">
                <td valign="top">
                  <asp:DataGrid id="DataGrid_control" runat="server" gridlines="Horizontal" cellpadding="5" autogeneratecolumns="False" allowsorting="True" onsortcommand="DataGrid_control_SortCommand" onitemdatabound="DataGrid_control_ItemDataBound" Font-Size="85%">
                    <Columns>
                      <asp:BoundColumn datafield="last_name" headertext="Last name" sortexpression="last_name%,first_name,middle_initial,practitioner_level.pecking_order,certification_number,birth_date desc" ReadOnly="True"></asp:BoundColumn>
                      <asp:BoundColumn datafield="first_name" headertext="First_name" sortexpression="first_name%,last_name,middle_initial,practitioner_level.pecking_order,certification_number,birth_date desc" ReadOnly="True"></asp:BoundColumn>
                      <asp:BoundColumn datafield="middle_initial" ReadOnly="True"></asp:BoundColumn>
                      <asp:BoundColumn DataField="level" HeaderText="Level" ReadOnly="True" SortExpression="practitioner_level.pecking_order%,last_name,first_name,middle_initial,certification_number,birth_date desc">
                        <ItemStyle Wrap="False" />
                      </asp:BoundColumn>
                      <asp:BoundColumn datafield="certification_number_for_display" headertext="Cert#" sortexpression="certification_number%,last_name,first_name,middle_initial,practitioner_level.pecking_order,birth_date desc" ReadOnly="True"></asp:BoundColumn>
                      <asp:BoundColumn datafield="birth_date" HeaderText="DOB" SortExpression="birth_date%,last_name,first_name,middle_initial,practitioner_level.pecking_order,certification_number" ReadOnly="True"></asp:BoundColumn>
                      <asp:BoundColumn datafield="county_name" HeaderText="County" SortExpression="county_name%,last_name,first_name,middle_initial,practitioner_level.pecking_order,certification_number,birth_date desc" ReadOnly="True"></asp:BoundColumn>
                      <asp:BoundColumn DataField="instructor_hours" ReadOnly="True" HeaderText="InstHrs" SortExpression="instructor_hours%,last_name,first_name,middle_initial,practitioner_level.pecking_order,certification_number,birth_date desc">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Right" Wrap="False" />
                      </asp:BoundColumn>
                      <asp:BoundColumn datafield="practitioner_status_description" ReadOnly="True" Visible="false"></asp:BoundColumn>
                    </Columns>
                    <HeaderStyle backcolor="WhiteSmoke"></HeaderStyle>
                  </asp:DataGrid>
                  <asp:Label ID="Label_noncurrent_practitioner_on_roster" runat="server" Text="*This roster includes at least one non-current practitioner." BackColor="Gold" Font-Bold="True" Font-Italic="True" Font-Size="Small" Visible="False"></asp:Label>
                </td>
              </tr>
            </table>
          </td>
        </tr>
      </table>
    </td>
  </tr>
</table>
