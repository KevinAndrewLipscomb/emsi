<%@ Control Language="c#" AutoEventWireup="True" Codebehind="UserControl_region_detail.ascx.cs" Inherits="UserControl_region_detail.TWebUserControl_region_detail"%>
<!-- Derived from KiAspdotnetFramework/usercontrol/app/UserControl~template~datagrid~sortable.ascx-template -->
<asp:UpdatePanel id="UpdatePanel_control" runat="server" updatemode="Conditional">
  <ContentTemplate>
    <asp:ValidationSummary ID="ValidationSummary_quick_message" runat="server" ValidationGroup="quick_message"/>
    <table bordercolor="#dcdcdc" cellspacing="0" cellpadding="0" border="1">
      <tr>
        <td>
          <table cellspacing="0" cellpadding="10" border="0">
            <tr>
              <td bgcolor="#dcdcdc">
                <p><strong><asp:Literal ID="Literal_region_name" runat="server"></asp:Literal> EMS Strike Team program</strong></p>
                <table cellspacing="0" cellpadding="0" border="0">
                  <tr>
                    <td valign="middle">
                      <strong>Filter:</strong>&nbsp;<asp:CheckBox ID="CheckBox_do_include_all_services" runat="server" Text="Show all services, whether participating or not" AutoPostBack="True" oncheckedchanged="CheckBox_do_include_all_services_CheckedChanged" />
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td align="right" valign="middle">
                      <asp:Literal ID="Literal_num_services" runat="server"></asp:Literal> services
                    </td>
                  </tr>
                </table>
              </td>
            </tr>
            <tr id="TableRow_none" runat="server"><td><em>--&nbsp;NONE&nbsp;--</em></td></tr>
            <tr>
              <td>
                <asp:DataGrid id="DataGrid_control" runat="server" gridlines="Horizontal" cellpadding="10" autogeneratecolumns="False" allowsorting="True">
                  <Columns>
                    <asp:ButtonColumn text="&lt;IMG src=&quot;~/protected/image/open_document16_h.png&quot; alt=&quot;Detail&quot; border=&quot;0&quot; height=&quot;16&quot; width=&quot;16&quot; /&gt;" commandname="Manage"></asp:ButtonColumn>
                    <asp:BoundColumn datafield="id" Visible="false"></asp:BoundColumn>
                    <asp:BoundColumn datafield="affiliate_num" headertext="Affiliate#" sortexpression="affiliate_num%">
                      <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="short_name" HeaderText="Short name" SortExpression="short_name%">
                      <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="name" HeaderText="Long name" SortExpression="name%">
                      <ItemStyle Font-Size="Small" />
                    </asp:BoundColumn>
                    <asp:BoundColumn datafield="be_strike_team_participant" headertext="Participating?" sortexpression="be_strike_team_participant%,name">
                      <ItemStyle horizontalalign="Center"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="num_members" HeaderText="#members" ReadOnly="True" SortExpression="num_members%,be_strike_team_participant desc,name">
                      <HeaderStyle HorizontalAlign="Center" />
                      <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="num_vehicles" HeaderText="#vehicles" ReadOnly="True" SortExpression="num_vehicles%,be_strike_team_participant desc,name">
                      <HeaderStyle HorizontalAlign="Center" />
                      <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn datafield="email_target" Visible="false"></asp:BoundColumn>
                    <asp:BoundColumn datafield="sms_target" Visible="false"></asp:BoundColumn>
                    <asp:TemplateColumn HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" Visible="False">
                      <HeaderTemplate>
                        <small>Include in<br />QuickMessage</small><br /> All:<asp:CheckBox ID="CheckBox_force_all" runat="server" AutoPostBack="True" oncheckedchanged="CheckBox_force_all_CheckedChanged" style="outline:2px solid SlateGray" ToolTip="Select/Unselect all for QuickMessage" Checked="True" />
                      </HeaderTemplate>
                      <ItemTemplate>
                        <asp:CheckBox ID="CheckBox_selected" runat="server" Checked="True" AutoPostBack="True" oncheckedchanged="CheckBox_selected_CheckedChanged" ToolTip="Select/Unselect for QuickMessage" />
                      </ItemTemplate>
                      <HeaderStyle HorizontalAlign="Center" />
                      <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateColumn>
                  </Columns>
                  <HeaderStyle backcolor="WhiteSmoke"></HeaderStyle>
                </asp:DataGrid>
              </td>
            </tr>
          </table>
        </td>
      </tr>
    </table>
    <br/>
    <table id="Table_quick_message" runat="server" bordercolor="#dcdcdc" cellspacing="0" cellpadding="0" border="1" visible="false">
      <tr>
        <td>
          <table cellspacing="0" cellpadding="10" width="100%" border="0">
            <tr>
              <td bgcolor="#f5f5f5">
                <table width="100%">
                  <tr>
                    <td><a id="QuickMessage"><strong>QuickMessage</strong></a></td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td align="right">
                      <asp:RadioButtonList ID="RadioButtonList_quick_message_mode" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" onselectedindexchanged="RadioButtonList_quick_message_mode_SelectedIndexChanged">
                        <asp:ListItem Selected="True" Value="email">Email</asp:ListItem>
                        <asp:ListItem Value="sms">SMS</asp:ListItem>
                      </asp:RadioButtonList>
                    </td>
                    <td>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator_quick_message_mode" runat="server" ErrorMessage="Please select a QuickMessage mode (Email or SMS)." Text="!ERR!" Font-Bold="True" ControlToValidate="RadioButtonList_quick_message_mode"></asp:RequiredFieldValidator>
                    </td>
                  </tr>
                </table>
              </td>
            </tr>
            <tr>
              <td>
                <table cellspacing="0" cellpadding="10" width="100%" border="0">
                  <tr>
                    <td>Send <asp:Literal ID="Literal_quick_message_kind_email" runat="server">email</asp:Literal><asp:Literal ID="Literal_quick_message_kind_sms" runat="server" Visible="false">SMS</asp:Literal> to:</td>
                    <td>Recipients selected (<asp:CheckBox ID="CheckBox_item_sample" runat="server" Checked="True" Enabled="false" />) above.</td>
                    <td></td>
                  </tr>
                  <tr>
                    <td>Bcc:</td>
                    <td><ASP:Literal id="Literal_author_target" runat="server"></ASP:Literal></td>
                    <td></td>
                  </tr>
                  <tr id="TableRow_reply_to" runat="server">
                    <td>Reply-to:</td>
                    <td>
                      <asp:RadioButtonList ID="RadioButtonList_reply_to" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Value="email">My email</asp:ListItem>
                        <asp:ListItem Value="phone">My phone</asp:ListItem>
                        <asp:ListItem Value="bouncer">BOUNCER</asp:ListItem>
                      </asp:RadioButtonList>
                    </td>
                    <td>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator_reply_to" runat="server" ControlToValidate="RadioButtonList_reply_to" Display="Dynamic" ErrorMessage="Please specify a Reply-to target." Font-Bold="True">!ERR!</asp:RequiredFieldValidator>
                    </td>
                  </tr>
                  <tr id="TableRow_subject" runat="server">
                    <td>Subject:</td>
                    <td><ASP:TextBox id="TextBox_quick_message_subject" runat="server" maxlength="255" columns="72"></ASP:TextBox></td>
                    <td></td>
                  </tr>
                  <tr>
                    <td valign="top">Message:</td>
                    <td><ASP:TextBox id="TextBox_quick_message_body" runat="server" columns="72" rows="18" textmode="MultiLine"></ASP:TextBox></td>
                    <td nowrap="nowrap" valign="top"><ASP:RequiredFieldValidator id="RequiredFieldValidator_quick_message_body" runat="server" errormessage="Please enter a message body." font-bold="True" controltovalidate="TextBox_quick_message_body" validationgroup="quick_message">!ERR!</ASP:RequiredFieldValidator></td>
                  </tr>
                  <tr>
                    <td></td>
                    <td><ASP:Button id="Button_send" runat="server" text="Send" validationgroup="quick_message" onclick="Button_send_Click"></ASP:Button></td>
                    <td></td>
                  </tr>
                  <tr><td valign="top"><font color="#c0c0c0"><small>Resolves to:</small></font></td><td valign="top"><small><ASP:Label id="Label_distribution_list" runat="server" forecolor="Silver"></ASP:Label></small></td>
                    <td></td>
                  </tr>
                </table>
              </td>
            </tr>
          </table>
        </td>
      </tr>
    </table>
  </ContentTemplate>
</asp:UpdatePanel>
