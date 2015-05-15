<%@ Control Language="c#" AutoEventWireup="True" Codebehind="UserControl_static_service_strike_team_key_personnel.ascx.cs" Inherits="UserControl_static_service_strike_team_key_personnel.TWebUserControl_static_service_strike_team_key_personnel"%>
<!-- Derived from KiAspdotnetFramework/usercontrol/app/UserControl~template~std.ascx-template -->
<table cellpadding="0" cellspacing="0">
  <tr>
    <td>
      <table cellpadding="0" cellspacing="0" style="border:1px solid Gainsboro">
        <tr>
          <td>
            <table cellpadding="5" cellspacing="0">
              <tr><td colspan="2"><b><asp:Literal ID="Literal_service_name" runat="server"></asp:Literal></b></td></tr>
              <tr>
                <td nowrap="nowrap" width="1%">Affiliate #:</td>
                <td><asp:Literal ID="Literal_affiliate_num" runat="server"></asp:Literal></td>
              </tr>
              <tr>
                <td nowrap="nowrap">Service short name:</td>
                <td><asp:Literal ID="Literal_short_name" runat="server"></asp:Literal></td>
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
      <table cellpadding="0" cellspacing="0" style="border:1px solid Gainsboro">
        <tr>
          <td>
            <table cellpadding="10" cellspacing="0">
              <tr bgcolor="#99CCFF"><td><b>SERVICE-level Officers</b></td></tr>
              <tr id="TableRow_none" runat="server" bgcolor="#99CCFF"><td><em>--&nbsp;NONE&nbsp;--</em></td></tr>
              <tr id="TableRow_assignees" runat="server" bgcolor="#99CCFF">
                <td valign="top">
                  <asp:DataGrid id="DataGrid_control" runat="server" gridlines="Horizontal" cellpadding="5" autogeneratecolumns="False" allowsorting="True" onitemdatabound="DataGrid_control_ItemDataBound" Font-Size="85%" BackColor="White">
                    <Columns>
                      <asp:BoundColumn datafield="be_credentialed" Visible="false" ReadOnly="True"></asp:BoundColumn>
                      <asp:TemplateColumn>
                        <ItemTemplate>
                          <asp:Image ID="Image_uncredentialed" runat="server" AlternateText="Uncredentialed" Height="16px" ImageUrl="@image/dialog-warning-2.png" Width="16px" />
                        </ItemTemplate>
                      </asp:TemplateColumn>
                      <asp:BoundColumn datafield="last_name" headertext="Last name" ReadOnly="True"></asp:BoundColumn>
                      <asp:BoundColumn datafield="first_name" headertext="First name" ReadOnly="True"></asp:BoundColumn>
                      <asp:BoundColumn datafield="middle_initial" ReadOnly="True"></asp:BoundColumn>
                      <asp:BoundColumn DataField="level" HeaderText="Level" ReadOnly="True">
                        <ItemStyle Wrap="false" />
                      </asp:BoundColumn>
                      <asp:BoundColumn datafield="certification_number_for_display" headertext="Cert#" ReadOnly="True"></asp:BoundColumn>
                      <asp:TemplateColumn HeaderText="DOB">
                        <ItemTemplate><asp:Label ID="Label_dob" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.birth_date") %>'></asp:Label></ItemTemplate>
                      </asp:TemplateColumn>
                      <asp:BoundColumn DataField="role_name" headertext="Role" ReadOnly="True">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundColumn>
                      <asp:TemplateColumn HeaderText="Email address">
                        <ItemTemplate><asp:Label ID="Label_email_address" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.email_address") %>'></asp:Label></ItemTemplate>
                      </asp:TemplateColumn>
                      <asp:BoundColumn DataField="practitioner_status_description" ReadOnly="True" Visible="false"></asp:BoundColumn>
                    </Columns>
                    <HeaderStyle backcolor="WhiteSmoke"></HeaderStyle>
                  </asp:DataGrid>
                </td>
              </tr>
              <tr>
                <td>
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
