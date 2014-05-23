<%@ Control Language="c#" AutoEventWireup="True" Codebehind="UserControl_operational_period_detail.ascx.cs" Inherits="UserControl_operational_period_detail.TWebUserControl_operational_period_detail"%>
<asp:UpdatePanel id="UpdatePanel_control" runat="server" updatemode="Conditional">
  <ContentTemplate>
<asp:ValidationSummary ID="ValidationSummary_operational_period_detail" runat="server" ValidationGroup="OperationalPeriodDetail"/>
<asp:ValidationSummary ID="ValidationSummary_quick_message" runat="server" ValidationGroup="quick_message"/>
<table bordercolor="#dcdcdc" cellspacing="0" cellpadding="0" border="1">
  <tr>
    <td>
      <table cellspacing="0" cellpadding="10" border="0">
        <tr id="TableRow_operational_period_started" runat="server" bgcolor="khaki" visible="false">
          <td>An operational period has started for this deployment, so no further preliminary assignments are allowed from your account.</td>
        </tr>
        <tr>
          <td bgcolor="whitesmoke">
            <table  border="0" cellpadding="5" cellspacing="0" width="100%">
              <tr>
                <td><b><small>Filters:</small></b></td>
                <td align="center" nowrap="nowrap">
                  <small>Assignment level</small><br/>
                  <ASP:DropDownList id="DropDownList_assignment_level_filter" runat="server" autopostback="True" onselectedindexchanged="DropDownList_assignment_level_filter_SelectedIndexChanged">
                    <asp:ListItem Value="">All</asp:ListItem>
                    <asp:ListItem Value="Vehicular">Vehicular</asp:ListItem>
                  </ASP:DropDownList>
                </td>
                <td align="right" width="99%">
                  <small>For&nbsp;IAP:&nbsp;<asp:HyperLink ID="HyperLink_for_iap" runat="server" NavigateUrl="~/protected/per_op_period_iap.aspx?" Target="_blank"><img src="~/protected/image/print16_h.png" alt="For IAP" border="0" height="16" width="16" /></asp:HyperLink></small>
                </td>
              </tr>
            </table>
          </td>
        </tr>
        <tr>
          <td>
            <table cellspacing="0" cellpadding="10" border="0">
              <tr>
                <td id="TableCell_no_mappings" runat="server" valign="top"><em>--&nbsp;No&nbsp;mappings&nbsp;--</em></td>
                <td id="TableCell_mappings" runat="server" nowrap="nowrap" valign="top">
                  <asp:DataGrid id="DataGrid_control" runat="server" gridlines="Horizontal" cellpadding="5" autogeneratecolumns="False" allowsorting="True" ondeletecommand="DataGrid_control_DeleteCommand" onitemdatabound="DataGrid_control_ItemDataBound" onsortcommand="DataGrid_control_SortCommand">
                    <Columns>
                      <asp:ButtonColumn text="&lt;IMG src=&quot;~/protected/image/delete_x16_h.png&quot; alt=&quot;Unmap&quot; border=&quot;0&quot; height=&quot;16&quot; width=&quot;16&quot; /&gt;" commandname="Delete"></asp:ButtonColumn>
                      <asp:BoundColumn datafield="vehicle_id" Visible="false"></asp:BoundColumn>
                      <asp:BoundColumn datafield="vehicle_designator" headertext="Vehicle" sortexpression="vehicle_designator%,member_designator">
                        <HeaderStyle horizontalalign="Left"></HeaderStyle>
                        <ItemStyle horizontalalign="Left"></ItemStyle>
                      </asp:BoundColumn>
                      <asp:BoundColumn datafield="member_designator" headertext="Member" sortexpression="member_designator%,vehicle_designator">
                        <HeaderStyle horizontalalign="Left"></HeaderStyle>
                        <ItemStyle horizontalalign="Left"></ItemStyle>
                      </asp:BoundColumn>
                      <asp:BoundColumn datafield="member_id" Visible="false"></asp:BoundColumn>
                    </Columns>
                    <HeaderStyle backcolor="WhiteSmoke"></HeaderStyle>
                  </asp:DataGrid>
                </td>
                <td id="TableCell_add_mapping" runat="server" valign="top" visible="false">
                  <asp:Panel ID="Panel_copy_other_op_period" runat="server" Visible="false">
                    Copy from:<asp:DropDownList ID="DropDownList_source_op_period" runat="server"></asp:DropDownList><asp:Button ID="Button_copy_other_op_period" runat="server" Text="Copy" onclick="Button_copy_other_op_period_Click" ValidationGroup="copy_from" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator_source_op_period" runat="server" ControlToValidate="DropDownList_source_op_period" Display="Dynamic" ErrorMessage="Please select a source to Copy (assignments) from." Font-Bold="True" ValidationGroup="copy_from">!ERR!</asp:RequiredFieldValidator>
                    <hr />
                  </asp:Panel>
                  <table cellspacing="0" cellpadding="2" border="0">
                    <tr>
                      <td>
                        <asp:DropDownList id="DropDownList_vehicle" runat="server" font-size="Small" datavaluefield="id" datatextfield="name" appenddatabounditems="True">
                          <asp:ListItem selected="True">-- Vehicle --</asp:ListItem>
                          <asp:ListItem Value="0">(none)</asp:ListItem>
                        </asp:DropDownList>
                      </td>
                      <td nowrap="nowrap"><asp:RequiredFieldValidator id="RequiredFieldValidator_vehicle" runat="server" errormessage="Please select a Vehicle." font-bold="True" controltovalidate="DropDownList_vehicle" setfocusonerror="True" display="Dynamic" ValidationGroup="OperationalPeriodDetail">!ERR!</asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                      <td>
                        <asp:DropDownList id="DropDownList_member" runat="server" datatextfield="member_designator" datavaluefield="member_id" font-size="Small" appenddatabounditems="True">
                          <asp:ListItem selected="True">-- Member --</asp:ListItem>
                        </asp:DropDownList>
                      </td>
                      <td nowrap="nowrap"><asp:RequiredFieldValidator id="RequiredFieldValidator_member" runat="server" errormessage="Please select a Member." font-bold="True" controltovalidate="DropDownList_member" setfocusonerror="True" display="Dynamic" ValidationGroup="OperationalPeriodDetail">!ERR!</asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                      <td><asp:Button id="Button_add" runat="server" text="<--&nbsp;Add" onclick="Button_add_Click" ValidationGroup="OperationalPeriodDetail"></asp:Button></td>
                      <td>&nbsp;</td>
                    </tr>
                  </table>
                  <br/>
                  <table bordercolor="#dcdcdc" cellspacing="0" cellpadding="0" border="1">
                    <tr>
                      <td>
                        <table cellspacing="0" cellpadding="10" border="0">
                          <tr><td bgcolor="#dcdcdc"><table cellspacing="0" cellpadding="10" border="0" width="100%"><tr><td><strong>Unit digest</strong></td></tr></table></td></tr>
                          <tr id="TableRow_none" runat="server"><td><em>--&nbsp;NONE&nbsp;--</em></td></tr>
                          <tr id="TableRow_digest" runat="server">
                            <td>
                              <asp:DataGrid id="DataGrid_digest" runat="server" gridlines="Horizontal" cellpadding="10" autogeneratecolumns="False" allowsorting="True" onitemdatabound="DataGrid_digest_ItemDataBound" onsortcommand="DataGrid_digest_SortCommand">
                                <Columns>
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
                                  <asp:BoundColumn datafield="vehicle_designator" headertext="Vehicle" sortexpression="vehicle_designator%"></asp:BoundColumn>
                                  <asp:BoundColumn datafield="vehicle_patient_care_level_description" visible="false"></asp:BoundColumn>
                                  <asp:BoundColumn datafield="max_practitioner_level_short_description" visible="false"></asp:BoundColumn>
                                  <asp:BoundColumn DataField="effective_patient_care_level" HeaderText="Lvl">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center"/>
                                  </asp:BoundColumn>
                                  <asp:TemplateColumn HeaderText="Kind" SortExpression="kind%,vehicle_designator">
                                    <ItemTemplate>
                                      <asp:Label id="Label_kind" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.kind") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                  </asp:TemplateColumn>
                                  <asp:BoundColumn datafield="par" headertext="Par" sortexpression="par%,vehicle_designator">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center"/>
                                  </asp:BoundColumn>
                                  <asp:BoundColumn datafield="sms_target" Visible="false"></asp:BoundColumn>
                                  <asp:BoundColumn DataField="elaboration" Visible="false"></asp:BoundColumn>
                                </Columns>
                                <HeaderStyle backcolor="WhiteSmoke"></HeaderStyle>
                              </asp:DataGrid>
                            </td>
                          </tr>
                        </table>
                      </td>
                    </tr>
                  </table>
                </td>
              </tr>
            </table>
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
                  <asp:RadioButtonList ID="RadioButtonList_quick_message_mode" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" onselectedindexchanged="RadioButtonList_quick_message_mode_SelectedIndexChanged" Visible="false">
                    <asp:ListItem Value="email">Email</asp:ListItem>
                    <asp:ListItem Selected="True" Value="sms">SMS</asp:ListItem>
                  </asp:RadioButtonList>
                </td>
                <td>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator_quick_message_mode" runat="server" ErrorMessage="Please select a QuickMessage mode (Email or SMS)." Text="!ERR!" Font-Bold="True" ControlToValidate="RadioButtonList_quick_message_mode" ValidationGroup="quick_message"></asp:RequiredFieldValidator>
                </td>
              </tr>
            </table>
          </td>
        </tr>
        <tr>
          <td>
            <table cellspacing="0" cellpadding="10" width="100%" border="0">
              <tr>
                <td>Send <asp:Literal ID="Literal_quick_message_kind_email" runat="server" Visible="false">email</asp:Literal><asp:Literal ID="Literal_quick_message_kind_sms" runat="server">SMS</asp:Literal> to:</td>
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
                    <asp:ListItem Value="email">My email</asp:ListItem>
                    <asp:ListItem Selected="True" Value="phone">My phone</asp:ListItem>
                    <asp:ListItem Value="bouncer">BOUNCER</asp:ListItem>
                  </asp:RadioButtonList>
                </td>
                <td>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator_reply_to" runat="server" ControlToValidate="RadioButtonList_reply_to" Display="Dynamic" ErrorMessage="Please specify a Reply-to target." Font-Bold="True" ValidationGroup="quick_message">!ERR!</asp:RequiredFieldValidator>
                </td>
              </tr>
              <tr id="TableRow_subject" runat="server" visible="false">
                <td>Subject:</td>
                <td><ASP:TextBox id="TextBox_quick_message_subject" runat="server" maxlength="255" columns="72"></ASP:TextBox></td>
                <td></td>
              </tr>
              <tr>
                <td valign="top">Message:</td>
                <td><ASP:TextBox id="TextBox_quick_message_body" runat="server" columns="40" rows="4" textmode="MultiLine"></ASP:TextBox></td>
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
