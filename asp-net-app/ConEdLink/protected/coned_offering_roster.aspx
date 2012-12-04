<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/strict.dtd">
<!-- Derived from KiAspdotnetFramework/protected/template~protected~nonlanding.aspx~template -->
<%@ Page language="c#" Debug="true" Codebehind="coned_offering_roster.aspx.cs" AutoEventWireup="True" Inherits="coned_offering_roster.TWebForm_coned_offering_roster" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit"%>
<%@ Register TagPrefix="uc1" TagName="UserControl_precontent" Src="~/usercontrol/app/UserControl_precontent.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UserControl_postcontent" Src="~/usercontrol/app/UserControl_postcontent.ascx" %>
<%@ Register TagPrefix="uc3" TagName="UserControl_update_progress_blocker" Src="~/usercontrol/app/UserControl_update_progress_blocker.ascx" %>
<html>
  <head runat="server">
    <title></title>
    <!-- $Id$ -->
    <link href="../css/standard.css" rel="stylesheet" type="text/css" />
    <!--[if lt IE 7]> <style type="text/css">@import "../css/standard-overrides-for-ie6.css";</style><![endif]-->
  </head>
  <body id="Body_control" runat="server" bgcolor="white">
    <form runat="server" defaultfocus="TextBox_practitioner">
      <uc1:UserControl_precontent id="UserControl_precontent" runat="server"></uc1:UserControl_precontent>
        <table cellpadding="0" cellspacing="0">
          <tr>
            <td valign="top">
              <asp:Panel ID="Panel_input_method" runat="server" Visible="false" style="border:1px solid Gainsboro">
                <table cellpadding="0" cellspacing="0">
                  <tr>
                    <td valign="top"><small>Input:</small></td>
                    <td nowrap="nowrap">
                      <asp:RadioButtonList ID="RadioButtonList_input_method" runat="server" AutoPostBack="True" Font-Size="Smaller" RepeatDirection="Vertical" RepeatLayout="Flow" onselectedindexchanged="RadioButtonList_input_method_SelectedIndexChanged">
                        <asp:ListItem Selected="True">Standard</asp:ListItem>
                        <asp:ListItem Value="Batch" Enabled="false">Scan batch</asp:ListItem>
                        <asp:ListItem Value="Copy" Enabled="false">Copy other roster</asp:ListItem>
                      </asp:RadioButtonList>
                    </td>
                  </tr>
                </table>
              </asp:Panel>
              <asp:Panel ID="Panel_one_at_a_time" runat="server">
                <table cellpadding="3" cellspacing="0" style="font-size:85%">
                  <tr>
                    <td nowrap="nowrap" bgcolor="Gainsboro">
                      <asp:UpdatePanel ID="UpdatePanel_search_upper" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                          <asp:HiddenField ID="HiddenField_practitioner_saved" runat="server" />
                          <b>Search></b>&nbsp;<asp:TextBox ID="TextBox_practitioner" runat="server" OnTextChanged="TextBox_practitioner_TextChanged" autocomplete="off"></asp:TextBox>
                          <asp:Button ID="Button_add" runat="server" Text="" style="display:none; visibility:hidden" CausesValidation="false" OnClick="Button_add_Click"/>
                          <br />
                          <small><i><asp:Literal ID="Literal_click_to_add" runat="server"></asp:Literal></i></small>
                        </ContentTemplate>
                        <Triggers>
                          <asp:AsyncPostBackTrigger ControlID="ListBox_practitioner" EventName="SelectedIndexChanged" />
                        </Triggers>
                      </asp:UpdatePanel>
                    </td>
                  </tr>
                  <tr>
                    <td valign="top" bgcolor="Gainsboro">
                      <asp:UpdatePanel ID="UpdatePanel_search_lower" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                          <asp:ListBox ID="ListBox_practitioner" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ListBox_practitioner_SelectedIndexChanged" Rows="13" Width="100%"></asp:ListBox>
                        </ContentTemplate>
                        <Triggers>
                          <asp:AsyncPostBackTrigger ControlID="TextBox_practitioner" EventName="TextChanged" />
                          <asp:AsyncPostBackTrigger ControlID="Button_add" EventName="Click" />
                        </Triggers>
                      </asp:UpdatePanel>
                    </td>
                  </tr>
                </table>
              </asp:Panel>
              <asp:Panel ID="Panel_batch" runat="server" Visible="false">
                <table align="right">
                  <tr>
                    <td valign="top" align="right">
                      Enter<br />
                      collected<br />
                      certification<br />
                      numbers<br />here:<br />
                      <br />
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator_certification_number_batch" runat="server" ErrorMessage="Please enter one or more certification numbers." Display="Dynamic" Font-Bold="True" Text="!ERR!" ControlToValidate="TextBox_certification_number_batch" ValidationGroup="ScanBatch"></asp:RequiredFieldValidator>
                    </td>
                    <td valign="top"><asp:TextBox ID="TextBox_certification_number_batch" runat="server" Columns="7" Rows="25" TextMode="MultiLine" ValidationGroup="ScanBatch"></asp:TextBox></td>
                  </tr>
                  <tr><td align="right" colspan="2"><asp:Button ID="Button_add_batch" runat="server" onclick="Button_add_batch_Click" Text="Add batch" CausesValidation="False" ValidationGroup="ScanBatch" /></td></tr>
                </table>
              </asp:Panel>
              <asp:Panel ID="Panel_copy" runat="server" Visible="false">
                <table>
                  <tr><td>Copy attendees from which other roster?</td></tr>
                  <tr>
                    <td>
                      <asp:DropDownList ID="DropDownList_other_roster" runat="server" ValidationGroup="Copy" onselectedindexchanged="DropDownList_other_roster_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                    </td>
                  </tr>
                  <tr><td nowrap="nowrap" align="right"><asp:Button ID="Button_copy" runat="server" Text="Copy attendees &gt;&gt;&gt;" onclick="Button_copy_Click" ValidationGroup="Copy" /><asp:RequiredFieldValidator ID="RequiredFieldValidator_copy" runat="server" ErrorMessage="Please select another roster from which to copy attendees." Font-Bold="True" Text="!ERR!" ControlToValidate="DropDownList_other_roster" ValidationGroup="Copy"></asp:RequiredFieldValidator></td></tr>
                </table>
              </asp:Panel>
            </td>
            <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
            <td valign="top">
              <table cellpadding="0" cellspacing="0">
                <tr>
                  <td>
                    <table cellpadding="0" cellspacing="0" style="border:1px solid Gainsboro">
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
                              <td>&nbsp;</td>
                              <td colspan="2" valign="top" align="center">
                                <asp:HyperLink ID="HyperLink_print_roster" runat="server" Target="_blank" text="&lt;IMG src=&quot;image/print16_h.png&quot; alt=&quot;Print roster&quot; border=&quot;0&quot; height=&quot;16&quot; width=&quot;16&quot; /&gt;"></asp:HyperLink>
                              </td>
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
                    <table cellpadding="0" cellspacing="0" style="border:1px solid Gainsboro">
                      <tr>
                        <td>
                          <asp:UpdatePanel ID="UpdatePanel_attendees" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                              <table cellpadding="10" cellspacing="0">
                                <tr><td style="background-color:WhiteSmoke">
                                  <table cellpadding="0" cellspacing="0" style="width: 100%">
                                    <tr>
                                      <td><b>Attendees</b></td>
                                      <td>&nbsp;&nbsp;&nbsp;</td>
                                      <td align="center"><asp:Button ID="Button_close_and_submit" runat="server" Font-Bold="True" onclick="Button_close_and_submit_Click" Text="CLOSE CLASS and SUBMIT FOR CREDIT" /></td>
                                      <td>&nbsp;&nbsp;&nbsp;</td>
                                      <td>
                                        <asp:CustomValidator ID="CustomValidator_close_class_and_submit_for_credit" runat="server" Display="Dynamic" ErrorMessage="You cannot submit a roster for a class that is not Approved, or could not have been completely presented given the registered Start and actual required Length, or that has no Attendees, or still shows that a DOB is 'REQUIRED'." Font-Bold="true" OnServerValidate="CustomValidator_close_class_and_submit_for_credit_ServerValidate">!ERR!</asp:CustomValidator>
                                      </td>
                                    </tr>
                                  </table>
                                  </td></tr>
                                <tr id="TableRow_none" runat="server"><td><em>--&nbsp;NONE&nbsp;--</em></td></tr>
                                <tr id="TableRow_attendees" runat="server">
                                  <td valign="top">
                                    <asp:DataGrid id="DataGrid_control" runat="server" gridlines="Horizontal" cellpadding="5" autogeneratecolumns="false" allowsorting="True" onsortcommand="DataGrid_control_SortCommand" onitemdatabound="DataGrid_control_ItemDataBound" oncancelcommand="DataGrid_control_CancelCommand" ondeletecommand="DataGrid_control_DeleteCommand" oneditcommand="DataGrid_control_EditCommand" onupdatecommand="DataGrid_control_UpdateCommand" Font-Size="85%">
                                      <Columns>
                                        <asp:BoundColumn datafield="id" Visible="false" ReadOnly="True"></asp:BoundColumn>
                                        <asp:TemplateColumn HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                          <HeaderTemplate>
                                            <asp:CheckBox ID="CheckBox_force_all" runat="server" AutoPostBack="True" oncheckedchanged="CheckBox_force_all_CheckedChanged" style="outline:2px solid SlateGray" ToolTip="Select/Unselect all" Checked="True" />
                                          </HeaderTemplate>
                                          <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox_selected" runat="server" Checked="True" AutoPostBack="True" oncheckedchanged="CheckBox_selected_CheckedChanged" />
                                          </ItemTemplate>
                                          <HeaderStyle HorizontalAlign="Center" />
                                          <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateColumn>
                                        <asp:ButtonColumn text="&lt;IMG src=&quot;~/protected/image/delete_x16_h.png&quot; alt=&quot;Delete&quot; border=&quot;0&quot; height=&quot;16&quot; width=&quot;16&quot; /&gt;" commandname="Delete" Visible="false"></asp:ButtonColumn>
                                        <asp:BoundColumn datafield="practitioner_id" Visible="false" ReadOnly="True"></asp:BoundColumn>
                                        <asp:BoundColumn datafield="last_name" headertext="Last name" sortexpression="last_name%,first_name,middle_initial,practitioner_level.pecking_order,certification_number,birth_date desc" ReadOnly="True"></asp:BoundColumn>
                                        <asp:BoundColumn datafield="first_name" headertext="First name" sortexpression="first_name%,last_name,middle_initial,practitioner_level.pecking_order,certification_number,birth_date desc" ReadOnly="True"></asp:BoundColumn>
                                        <asp:BoundColumn datafield="middle_initial" ReadOnly="True"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="level" HeaderText="Level" ReadOnly="True" SortExpression="practitioner_level.pecking_order%,last_name,first_name,middle_initial,certification_number,birth_date desc">
                                          <ItemStyle Wrap="false" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="level_emsrs_code" Visible="false" ReadOnly="True"></asp:BoundColumn>
                                        <asp:BoundColumn datafield="certification_number_for_display" headertext="Cert#" sortexpression="certification_number%,last_name,first_name,middle_initial,practitioner_level.pecking_order,birth_date desc" ReadOnly="True"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="be_birth_date_confirmed" ReadOnly="True" Visible="false"></asp:BoundColumn>
                                        <asp:TemplateColumn HeaderText="DOB" SortExpression="birth_date%,last_name,first_name,middle_initial,practitioner_level.pecking_order,certification_number">
                                          <ItemTemplate><asp:Label ID="Label_dob" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.birth_date") %>'></asp:Label></ItemTemplate>
                                          <EditItemTemplate>
                                            <asp:TextBox ID="TextBox_dob" runat="server" Columns="9" MaxLength="10" Text='<%# DataBinder.Eval(Container, "DataItem.birth_date") %>' enabled="false"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator_dob" runat="server" ControlToValidate="TextBox_dob" Display="Dynamic" ErrorMessage="Please enter a Birth date." Font-Bold="True" >!ERR!</asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator_dob" runat="server" ControlToValidate="TextBox_dob" Display="Dynamic" ErrorMessage="Please enter a valid Birth date using the m/d/yyyy format." Font-Bold="True" ValidationExpression="\d{1,2}[-/]\d{1,2}[-/]\d{4}">!ERR!</asp:RegularExpressionValidator>
                                            <asp:CustomValidator ID="CustomValidator_dob" runat="server" ControlToValidate="TextBox_dob" Display="Dynamic" ErrorMessage="Please enter a valid Birth date consistent with an age of 16-130 years." Font-Bold="True" onservervalidate="CustomValidator_dob_ServerValidate">!ERR!</asp:CustomValidator>
                                            <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender_dob" runat="server" TargetControlID="TextBox_dob" WatermarkText="m/d/yyyy" WatermarkCssClass="textbox_watermark"></asp:TextBoxWatermarkExtender>
                                          </EditItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:BoundColumn DataField="county_code" ReadOnly="True" Visible="false"></asp:BoundColumn>
                                        <asp:TemplateColumn HeaderText="County" SortExpression="county_name%,last_name,first_name,middle_initial,practitioner_level.pecking_order,certification_number,birth_date desc">
                                          <ItemTemplate><asp:Label ID="Label_county" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.county_name") %>'></asp:Label></ItemTemplate>
                                          <EditItemTemplate>
                                            <asp:DropDownList ID="DropDownList_county" runat="server"></asp:DropDownList>
                                          </EditItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="Email address" SortExpression="email_address%,last_name,first_name,middle_initial,practitioner_level.pecking_order,certification_number,birth_date desc">
                                          <ItemTemplate><asp:Label ID="Label_email_address" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.email_address") %>'></asp:Label></ItemTemplate>
                                          <EditItemTemplate>
                                            <asp:TextBox ID="TextBox_email_address" runat="server" Columns="15" MaxLength="127" Text='<%# DataBinder.Eval(Container, "DataItem.email_address") %>'></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator_email_address" runat="server" ControlToValidate="TextBox_email_address" Display="Dynamic" ErrorMessage="Please enter a valid Email address." Font-Bold="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">!ERR!</asp:RegularExpressionValidator>
                                            <asp:CustomValidator ID="CustomValidator_email_address" runat="server" ControlToValidate="TextBox_email_address" Display="Dynamic" ErrorMessage='Please enter an Email address with a valid Domain Name (the part after the "@").' Font-Bold="True" onservervalidate="CustomValidator_email_address_ServerValidate">!ERR!</asp:CustomValidator>
                                            <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender_email_address" runat="server" TargetControlID="TextBox_email_address" WatermarkText="user@domain.tld" WatermarkCssClass="textbox_watermark"></asp:TextBoxWatermarkExtender>
                                          </EditItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:BoundColumn DataField="be_instructor" ReadOnly="True" Visible="false"></asp:BoundColumn>
                                        <asp:TemplateColumn headertext="InstHrs" sortexpression="instructor_hours%,last_name,first_name,middle_initial,practitioner_level.pecking_order,certification_number,birth_date desc">
                                          <HeaderStyle HorizontalAlign="Center" />
                                          <ItemTemplate><asp:Label ID="Label_instructor_hours" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.instructor_hours") %>' Visible="false"></asp:Label></ItemTemplate>
                                          <ItemStyle HorizontalAlign="Right" Wrap="false" />
                                          <EditItemTemplate>
                                            <asp:TextBox ID="TextBox_instructor_hours" runat="server" Columns="3" MaxLength="5" Text='<%# DataBinder.Eval(Container, "DataItem.instructor_hours") %>' visible="false"></asp:TextBox>
                                            <asp:CustomValidator ID="CustomValidator_instructor_hours" runat="server" ControlToValidate="TextBox_instructor_hours" Display="Dynamic" ErrorMessage='Please enter a valid Instructor hours value that does not exceed the Total class hours value.' Font-Bold="True" onservervalidate="CustomValidator_instructor_hours_ServerValidate">!ERR!</asp:CustomValidator>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender_instructor_hours" runat="server" TargetControlID="TextBox_instructor_hours" FilterType="Numbers,Custom" ValidChars="."></asp:FilteredTextBoxExtender>
                                            <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender_instructor_hours" runat="server" TargetControlID="TextBox_instructor_hours" WatermarkText="#.#" WatermarkCssClass="textbox_watermark"></asp:TextBoxWatermarkExtender>
                                          </EditItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:EditCommandColumn CancelText="&lt;IMG src=&quot;~/protected/image/edit-undo-8.png&quot; alt=&quot;Cancel&quot; border=&quot;0&quot; height=&quot;16&quot; width=&quot;16&quot; /&gt;" EditText="&lt;IMG src=&quot;~/protected/image/draw_freehand_16_h.png&quot; alt=&quot;Edit&quot; border=&quot;0&quot; height=&quot;16&quot; width=&quot;16&quot; /&gt;" UpdateText="&lt;IMG src=&quot;~/protected/image/document-save-5.png&quot; alt=&quot;Update&quot; border=&quot;0&quot; height=&quot;16&quot; width=&quot;16&quot; /&gt;">
                                          <ItemStyle Wrap="false" />
                                        </asp:EditCommandColumn>
                                        <asp:BoundColumn DataField="practitioner_status_description" ReadOnly="True" Visible="false"></asp:BoundColumn>
                                      </Columns>
                                      <HeaderStyle backcolor="WhiteSmoke"></HeaderStyle>
                                    </asp:DataGrid>
                                  </td>
                                </tr>
                                <tr>
                                  <td><asp:Label ID="Label_noncurrent_practitioner_on_roster" runat="server" Text="*This roster includes at least one non-current practitioner." BackColor="Gold" Font-Bold="True" Font-Italic="True" Font-Size="Small" Visible="False"></asp:Label></td>
                                  <td align="right">
                                    <asp:Button ID="Button_mark_class_canceled" runat="server" CausesValidation="False" onclick="Button_mark_class_canceled_Click" Text="Mark class CANCELED" Visible="False" />
                                  </td>
                                </tr>
                                <tr>
                                  <td>
                                    For selected (<asp:CheckBox ID="CheckBox_item_sample" runat="server" Checked="True" Enabled="false" />) attendees...
                                    <ul>
                                      <li><p><asp:HyperLink ID="HyperLink_quickmessage" runat="server" NavigateUrl="#QuickMessage" Text="Send a QuickMessage"></asp:HyperLink></p></li>
                                      <li><p><asp:LinkButton ID="LinkButton_email_completion_documentation" runat="server" Text="Email completion documentation" Enabled="false" onclick="LinkButton_email_completion_documentation_Click"></asp:LinkButton></p></li>
                                      <li><p><asp:HyperLink ID="HyperLink_print_completion_documentation" runat="server" Text="Print completion documentation" Enabled="false" Target="_blank"></asp:HyperLink></p></li>
                                    </ul>
                                    <small>Use <asp:CheckBox ID="CheckBox_header_sample" runat="server" Checked="True" style="outline:2px solid SlateGray" Enabled="false" /> in header row to select or unselect all attendees at once.</small></td>
                                </tr>
                              </table>
                            </ContentTemplate>
                            <Triggers>
                              <asp:AsyncPostBackTrigger ControlID="Button_add" EventName="Click" />
                              <asp:AsyncPostBackTrigger ControlID="ListBox_practitioner" EventName="SelectedIndexChanged" />
                            </Triggers>
                          </asp:UpdatePanel>
                        </td>
                      </tr>
                    </table>
                  </td>
                </tr>
                <tr><td>&nbsp;</td></tr>
                <tr>
                  <td>
                    <table cellspacing="0" cellpadding="0" style="border:1px solid Gainsboro">
                      <tr>
	                      <td>
	                        <table cellspacing="0" cellpadding="10" border="0">
		                        <tr><td bgcolor="#f5f5f5"><a id="QuickMessage"><strong>QuickMessage</strong></a></td></tr>
		                        <tr>
			                        <td>
                                <p>Send email to the attendees selected above.</p>
			                          <table cellspacing="0" cellpadding="10" width="100%" border="0">
                                  <tr>
                                    <td>Bcc:</td>
                                    <td><ASP:Literal id="Literal_author_email_address" runat="server"></ASP:Literal></td>
                                    <td></td>
                                  </tr>
				                          <tr>
					                          <td>Subject:</td>
					                          <td><ASP:TextBox id="TextBox_quick_message_subject" runat="server" maxlength="255" columns="72"></ASP:TextBox></td>
					                          <td></td>
				                          </tr>
				                          <tr>
					                          <td valign="top">Body:</td>
					                          <td><ASP:TextBox id="TextBox_quick_message_body" runat="server" columns="72" rows="18" textmode="MultiLine"></ASP:TextBox></td>
					                          <td nowrap="nowrap" valign="top">
                                      <ASP:RequiredFieldValidator id="RequiredFieldValidator_quick_message_body" runat="server" errormessage="Please enter a message body." font-bold="True" controltovalidate="TextBox_quick_message_body" ValidationGroup="QuickMessage">!ERR!</ASP:RequiredFieldValidator>
                                    </td>
				                          </tr>
				                          <tr>
					                          <td></td>
					                          <td>
                                      <asp:UpdatePanel ID="UpdatePanel_send_button" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                          <ASP:Button id="Button_send" runat="server" text="Send" onclick="Button_send_Click" ValidationGroup="QuickMessage"></ASP:Button>
                                        </ContentTemplate>
                                        <Triggers>
                                          <asp:AsyncPostBackTrigger ControlID="DataGrid_control" EventName="ItemCommand" />
                                        </Triggers>
                                      </asp:UpdatePanel>
                                    </td>
					                          <td></td>
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
      <uc1:UserControl_postcontent id="UserControl_postcontent" runat="server"></uc1:UserControl_postcontent>
      <uc3:UserControl_update_progress_blocker id="UserControl_update_progress_blocker_control" runat="server"></uc3:UserControl_update_progress_blocker>
    </form>
  </body>
</html>