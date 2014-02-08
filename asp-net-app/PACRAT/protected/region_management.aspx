<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/strict.dtd">
<!-- Derived from KiAspdotnetFramework/protected/template~protected~nonlanding.aspx~template -->
<%@ Page language="c#" Debug="true" Codebehind="region_management.aspx.cs" AutoEventWireup="True" Inherits="region_management.TWebForm_region_management" %>
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
      <asp:UpdatePanel ID="UpdatePanel_overall" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
          <asp:ValidationSummary ID="ValidationSummary_quick_message" runat="server" ValidationGroup="QuickMessage"/>
          <asp:CheckBox ID="CheckBox_be_pacrat_subscriber" runat="server" AutoPostBack="True" Text="Subscribing region" oncheckedchanged="CheckBox_be_pacrat_subscriber_CheckedChanged" />
          <hr noshade="noshade" width="100%" size="1" />
          <table cellpadding="0" cellspacing="0">
            <tr>
              <td valign="top">
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
                              <tr><td colspan="2"><b><asp:Literal ID="Literal_region_name" runat="server"></asp:Literal> <i>Strike Team</i></b></td></tr>
                              <tr>
                                <td nowrap="nowrap" valign="top"><b>PA DOH Region #:</b> <asp:Literal ID="Literal_emsrs_code" runat="server"></asp:Literal></td>
                                <td valign="top" align="center">
                                  <asp:HyperLink ID="HyperLink_print_roster" runat="server" Target="_blank" text="&lt;IMG src=&quot;image/print16_h.png&quot; alt=&quot;Print roster&quot; border=&quot;0&quot; height=&quot;16&quot; width=&quot;16&quot; /&gt;"></asp:HyperLink>
                                </td>
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
                            <asp:UpdatePanel ID="UpdatePanel_assignees" runat="server" UpdateMode="Conditional">
                              <ContentTemplate>
                                <table cellpadding="10" cellspacing="0">
                                  <tr bgcolor="#FFFF99"><td><b>Key personnel</b></td></tr>
                                  <tr id="TableRow_none" runat="server" bgcolor="#FFFF99"><td><em>--&nbsp;NONE&nbsp;--</em></td></tr>
                                  <tr id="TableRow_assignees" runat="server" bgcolor="#FFFF99">
                                    <td valign="top">
                                      <asp:DataGrid id="DataGrid_control" runat="server" gridlines="Horizontal" cellpadding="5" autogeneratecolumns="False" allowsorting="True" onsortcommand="DataGrid_control_SortCommand" onitemdatabound="DataGrid_control_ItemDataBound" oncancelcommand="DataGrid_control_CancelCommand" ondeletecommand="DataGrid_control_DeleteCommand" oneditcommand="DataGrid_control_EditCommand" onupdatecommand="DataGrid_control_UpdateCommand" Font-Size="85%" BackColor="White" onitemcommand="DataGrid_control_ItemCommand">
                                        <Columns>
                                          <asp:BoundColumn datafield="be_credentialed" Visible="false" ReadOnly="True"></asp:BoundColumn>
                                          <asp:ButtonColumn text="&lt;IMG src=&quot;~/protected/image/dialog-warning-2.png&quot; alt=&quot;Uncredentialed&quot; border=&quot;0&quot; height=&quot;16&quot; width=&quot;16&quot; /&gt;" commandname="Profile"></asp:ButtonColumn>
                                          <asp:ButtonColumn text="&lt;IMG src=&quot;~/protected/image/open_document16_h.png&quot; alt=&quot;Profile&quot; border=&quot;0&quot; height=&quot;16&quot; width=&quot;16&quot; /&gt;" commandname="Profile"></asp:ButtonColumn>
                                          <asp:TemplateColumn HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <HeaderTemplate>
                                              <small>Include in<br />QuickMessage</small><br /> All:<asp:CheckBox ID="CheckBox_force_all" runat="server" AutoPostBack="True" oncheckedchanged="CheckBox_force_all_CheckedChanged" style="outline:2px solid SlateGray" ToolTip="Select/Unselect all" Checked="True" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                              <asp:CheckBox ID="CheckBox_selected" runat="server" Checked="True" AutoPostBack="True" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                          </asp:TemplateColumn>
                                          <asp:ButtonColumn text="&lt;IMG src=&quot;~/protected/image/delete_x16_h.png&quot; alt=&quot;Delete&quot; border=&quot;0&quot; height=&quot;16&quot; width=&quot;16&quot; /&gt;" commandname="Delete"></asp:ButtonColumn>
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
                                          <asp:BoundColumn DataField="role_id" ReadOnly="True" Visible="false"></asp:BoundColumn>
                                          <asp:TemplateColumn HeaderText="Role" SortExpression="role.pecking_order%,last_name,first_name,middle_initial,certification_number,birth_date desc">
                                            <ItemTemplate><asp:Label ID="Label_role" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.role_name") %>'></asp:Label></ItemTemplate>
                                            <EditItemTemplate>
                                              <asp:DropDownList ID="DropDownList_role" runat="server"></asp:DropDownList>
                                            </EditItemTemplate>
                                            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
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
                                    <td>
                                      <asp:Label ID="Label_noncurrent_practitioner_on_roster" runat="server" Text="*This roster includes at least one non-current practitioner." BackColor="Gold" Font-Bold="True" Font-Italic="True" Font-Size="Small" Visible="False"></asp:Label>
                                    </td>
                                  </tr>
                                  <tr>
                                    <td>
                                      <table>
                                        <tr>
                                          <td align="center" valign="middle">Drill down to</td>
                                          <td align="center" valign="middle"><asp:LinkButton ID="LinkButton_drill_down" runat="server" onclick="LinkButton_drill_down_Click" text="&lt;IMG src=&quot;~/protected/image/open_document16_h.png&quot; alt=&quot;Profile&quot; border=&quot;0&quot; height=&quot;16&quot; width=&quot;16&quot; /&gt;&lt;br/&gt;&lt;small&gt;SERVICES&lt;/small&gt;"></asp:LinkButton></td>
                                          <td align="center" valign="middle">in this region</td>
                                        </tr>
                                      </table>
                                      
                                    </td>
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
                                  <p>Send email to the assignees selected above.</p>
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
        </ContentTemplate>
        <Triggers>
          <asp:AsyncPostBackTrigger ControlID="CheckBox_be_pacrat_subscriber" EventName="CheckedChanged" />
        </Triggers>
      </asp:UpdatePanel>
      <uc1:UserControl_postcontent id="UserControl_postcontent" runat="server"></uc1:UserControl_postcontent>
      <uc3:UserControl_update_progress_blocker id="UserControl_update_progress_blocker_control" runat="server"></uc3:UserControl_update_progress_blocker>
    </form>
  </body>
</html>