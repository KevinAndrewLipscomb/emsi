<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/strict.dtd">
<%@ Page language="c#" Debug="true" Codebehind="full_request_review_approve.aspx.cs" AutoEventWireup="True" Inherits="full_request_review_approve.TWebForm_full_request_review_approve" %>
<%@ Register TagPrefix="uc1" TagName="UserControl_precontent" Src="~/usercontrol/app/UserControl_precontent.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UserControl_postcontent" Src="~/usercontrol/app/UserControl_postcontent.ascx" %>
<%@ Register TagPrefix="uc2" TagName="UserControl_update_progress_blocker" Src="~/usercontrol/app/UserControl_update_progress_blocker.ascx" %>
<%@ Register src="../usercontrol/ki/UserControl_attachment_explorer.ascx" tagname="UserControl_attachment_explorer" tagprefix="uc3" %>
<html>
  <head runat="server">
    <!-- $Id$ -->
    <link href="../css/standard.css" rel="stylesheet" type="text/css" />
    <!--[if lt IE 7]> <style type="text/css">@import "../css/standard-overrides-for-ie6.css";</style><![endif]-->
  </head>
  <body bgcolor="white">
	<form runat="server">
	  <uc1:UserControl_precontent id="UserControl_precontent" runat="server"></uc1:UserControl_precontent>
	  <h3><asp:label id="Label_fiscal_year_designator" runat="server"></asp:label>&nbsp;request from <asp:label id="Label_service_name" runat="server"></asp:label>&nbsp;(# <asp:label id="Label_affiliate_num" runat="server"></asp:label>)</h3>
	  <p>
		<table bordercolor="#98fb98" cellspacing="0" cellpadding="5" border="1" id="Table_disposition_sentinel" runat="server">
			<tr>
			  <td bgcolor="#98fb98"><strong>ACTION REQUIRED:</strong></td>
			  <td>Please review the following information, then indicate your disposition at the bottom of this form.</td>
			</tr>
		</table>
		<table bordercolor="#98fb98" cellspacing="0" cellpadding="5" border="1" id="Table_action_pending_sentinel" runat="server">
			<tr>
			  <td bgcolor="#98fb98"><strong>ACTION PENDING:</strong></td>
			  <td>See the bottom of this form for a description of the action pending on this request, and for a way to indicate that the pending action has been completed.</td>
			</tr>
		</table>
	  </p>
	  <table bordercolor="#dcdcdc" cellspacing="0" cellpadding="0" border="1">
		<tr>
		  <td>
			<table cellspacing="0" cellpadding="5" border="0">
			  <tr>
				<td bgcolor="#f5f5f5">
				  <p align="right">
					<strong>Allocation:</strong>
				  </p>
				</td>
				<td align="right">
				  <asp:label id="Label_parent_appropriation_amount" runat="server"></asp:label>
				</td>
				<td>from <asp:label id="Label_sponsor_county" runat="server">
				  </asp:label>&nbsp;County </td>
			  </tr>
			  <tr id="TableRow_sum_of_emsof_antes" runat="server">
				<td>
				  <p align="right">- </p>
				</td>
				<td align="right">
				  <asp:label id="Label_sum_of_emsof_antes" runat="server"
				  font-underline="True"></asp:label>
				</td>
				<td>requested from EMSOF (below) </td>
			  </tr>
			  <tr id="TableRow_unrequested_amount" runat="server">
				<td>
				  <p align="right">= </p>
				</td>
				<td align="right">
				  <asp:label id="Label_unused_amount" runat="server">
				  </asp:label>
				</td>
				<td>unused </td>
			  </tr>
			</table>
		  </td>
		</tr>
	  </table>
    <p></p>
    <table id="Table_prior_rejection_comments" bordercolor="#dcdcdc" cellspacing="0" cellpadding="0" border="1" runat="server">
      <tr>
        <td>
          <table cellspacing="0" cellpadding="5" border="0">
            <tr><td bgcolor="#f5f5f5" colspan="2"><strong>Prior rejection comments</strong></td></tr>
            <tr>
              <td>
                <asp:GridView id="GridView_rejection_comments" runat="server" gridlines="Horizontal" cellpadding="10" emptydatatext="None"></asp:GridView>
              </td>
            </tr>
          </table>
        </td>
      </tr>
    </table>
	  <p>
		<table id="Table_prior_approvals" bordercolor="#dcdcdc" cellspacing="0" cellpadding="0" border="1" runat="server">
			<tr><td>
				<table cellspacing="0" cellpadding="5" border="0">
	  <tr>
					  <td bgcolor="#f5f5f5" colspan="2"><strong>Prior approvals</strong></td>
			  </tr>
	  <tr>
		<td><ASP:Label id="Label_sponsor_county_2" runat="server"></ASP:Label>&nbsp;County:</td>
		<td><ASP:Label id="Label_county_approval_timestamp" runat="server"></ASP:Label></td>
	  </tr>
	  <tr id="TableRow_regional_planner_approval_timestamp" runat="server">
		<td>
                        <ASP:Label id="Label_region_name_1" runat="server"></ASP:Label>&nbsp;planner:</td>
		<td><ASP:Label id="Label_regional_planner_approval_timestamp" runat="server"></ASP:Label></td>
	  </tr>
	  <tr id="TableRow_regional_exec_dir_approval_timestamp" runat="server">
		<td>
                        <ASP:Label id="Label_region_name_2" runat="server"></ASP:Label>&nbsp;Executive Director:</td>
		<td><ASP:Label id="Label_regional_exec_dir_approval_timestamp" runat="server"></ASP:Label></td>
	  </tr>
	  <tr id="TableRow_state_approval_timestamp" runat="server">
		<td>PA DOH EMSO:</td>
		<td><ASP:Label id="Label_state_approval_timestamp" runat="server"></ASP:Label></td>
	  </tr>
				</table></td>
			</tr>
        </table>
      </p>
    <p></p>
      <table bordercolor="#dcdcdc" cellspacing="0" cellpadding="0" border="1">
        <tr>
          <td>
            <table cellspacing="0" cellpadding="10" border="0">
              <tr>
				<td bgcolor="#f5f5f5"><strong>Items (<asp:label id="Label_num_items" runat="server"></asp:label>)</strong></td>
              </tr>
              <tr>
                <td>
                  <asp:datagrid id="DataGrid_items" runat="server"
                  autogeneratecolumns="False" useaccessibleheader="True"
                  cellpadding="10" gridlines="Horizontal" bordercolor="Gainsboro" borderwidth="1px">
                        <HeaderStyle backcolor="WhiteSmoke"></HeaderStyle>
                        <Columns>
                          <ASP:BoundColumn datafield="priority" sortexpression="priority" readonly="True" headertext="Priority">
                            <ItemStyle font-size="Large" font-bold="True" horizontalalign="Center" verticalalign="Top"></ItemStyle>
                          </ASP:BoundColumn>
                          <ASP:TemplateColumn headertext="Detail">
                            <ItemStyle horizontalalign="Left" verticalalign="Top"></ItemStyle>
                            <ItemTemplate>
                          <table cellpadding="2">
                            <tr>
                              <td>
								<small>Make/model:</small>
                              </td>
                              <td>
								<small><strong><%# DataBinder.Eval(Container.DataItem, "make_model") %></strong>&nbsp;								<%# DataBinder.Eval(Container.DataItem, "be_refurbished") %></small>
                              </td>
                            </tr>
                            <tr>
                              <td valign="top">
								<small>Category:</small>
							  </td>
							  <td><small><strong><%# DataBinder.Eval(Container.DataItem, "category") %></strong></small>
							                  <uc3:UserControl_attachment_explorer ID="UserControl_attachment_explorer_control" runat="server" />
							                </td>
							</tr>
                            <tr>
							  <td><small>Place kept:</small></td>
							  <td><small><%# DataBinder.Eval(Container.DataItem, "place_kept") %></small></td>
							</tr>
							<tr>
							  <td><small>Qty/unit cost/subtotal:</small></td>
							  <td>
								<small><strong><%# DataBinder.Eval(Container.DataItem, "quantity") %></strong>&nbsp;@								<%# DataBinder.Eval(Container.DataItem, "unit_cost", "{0:C}") %>&nbsp;ea. =								<strong><%# DataBinder.Eval(Container.DataItem, "subtotal", "{0:C}") %></strong></small>
							  </td>
							</tr>
							<tr>
							  <td><small>Max unit cost allowed by EMSOF:</small></td>
							  <td><small><%# DataBinder.Eval(Container.DataItem, "allowable_cost", "{0:C}") %></small></td>
							</tr>
							<tr>
							  <td><small>EMSOF amount:</small></td>
							  <td>
								<small><strong><%# DataBinder.Eval(Container.DataItem, "emsof_ante", "{0:C}") %></strong></small>
							  </td>
							</tr>
						  </table>
                            </ItemTemplate>
                          </ASP:TemplateColumn>
             <asp:BoundColumn DataField="attachment_key" ReadOnly="True" Visible="False"></asp:BoundColumn>
                          <ASP:TemplateColumn headertext="Actuals">
<ItemTemplate>
  <small>
    Invoice #/comment:<br>&nbsp;&nbsp;&nbsp;&nbsp;
      <b><%# DataBinder.Eval(Container.DataItem, "invoice_designator") %></b><br>
    Quantity:<br>&nbsp;&nbsp;&nbsp;&nbsp;
      <b><%# DataBinder.Eval(Container.DataItem, "actual_quantity") %></b><br>
    Subtotal cost:<br>&nbsp;&nbsp;&nbsp;&nbsp;
      <b><%# DataBinder.Eval(Container.DataItem, "actual_subtotal_cost", "{0:C}") %></b><br>
    EMSOF amount:<br>&nbsp;&nbsp;&nbsp;&nbsp;
      <b><%# DataBinder.Eval(Container.DataItem, "actual_emsof_ante", "{0:C}") %></b>
  </small>
</ItemTemplate>
							<EditItemTemplate>
<small>Invoice #/comment:<br>&nbsp;&nbsp;&nbsp;&nbsp; <ASP:TextBox id="TextBox_invoice_designator" runat="server" text='<%# DataBinder.Eval(Container.DataItem, "invoice_designator") %>'></ASP:TextBox><br>Actual quantity:<br>&nbsp;&nbsp;&nbsp;&nbsp; <ASP:TextBox id="TextBox_actual_quantity" runat="server" text='<%# DataBinder.Eval(Container.DataItem, "actual_quantity") %>'></ASP:TextBox><br>Actual subtotal cost:<br>&nbsp;&nbsp;&nbsp;&nbsp; <ASP:TextBox id="TextBox_actual_subtotal_cost" runat="server" text='<%# DataBinder.Eval(Container.DataItem, "actual_subtotal_cost", "{0:C}") %>'></ASP:TextBox><br>EMSOF amount:<br>&nbsp;&nbsp;&nbsp;&nbsp; <i>(autocalculated)</i></small>
							</EditItemTemplate>
						  </ASP:TemplateColumn>
						  <ASP:EditCommandColumn buttontype="LinkButton" updatetext="Update" canceltext="Cancel" edittext="Edit"></ASP:EditCommandColumn>
 						</Columns>
				  </asp:datagrid>
				</td>
			  </tr>
			</table>
		  </td>
		</tr>
	  </table>
	  <p></p>
	  <table cellspacing="0" cellpadding="0" border="1" id="Table_proofs_of_payment" runat="server" bordercolor="#dcdcdc">
		<tr>
		  <td>
			<table cellspacing="0" cellpadding="10" border="0" width="100%">
			  <tr>
				<td bgcolor="#f5f5f5">
				  <strong>
						<table cellspacing="0" cellpadding="5" width="100%" border="0">
							<tr>
							  <td><strong>Proofs of payment</strong></td>
							  <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
							  <td>
								<p align="right"><ASP:LinkButton id="LinkButton_new_proof_of_payment" runat="server" font-bold="True" causesvalidation="False" onclick="LinkButton_new_proof_of_payment_Click">New</ASP:LinkButton></p></td>
							</tr>
						</table></strong>
				</td>
			  </tr>
			  <tr id="TableRow_proofs_of_payment_none" runat="server">
				<td>
				  <p><em>--&nbsp;NONE&nbsp;--</em></p>
				</td>
			  </tr>
			  <tr>
				<td>
						<ASP:DataGrid id="DataGrid_proofs_of_payment" runat="server" autogeneratecolumns="False" useaccessibleheader="True" cellpadding="10" gridlines="Horizontal" bordercolor="Gainsboro" borderwidth="1px">
						<HeaderStyle backcolor="WhiteSmoke"></HeaderStyle>
						<Columns>
						  <ASP:BoundColumn visible="False" datafield="id" readonly="True"></ASP:BoundColumn>
						  <ASP:BoundColumn datafield="date_of" readonly="True" headertext="Date"></ASP:BoundColumn>
						  <ASP:BoundColumn datafield="method" readonly="True" headertext="Method">
							<ItemStyle horizontalalign="Center"></ItemStyle>
						  </ASP:BoundColumn>
						  <ASP:BoundColumn datafield="amount" headertext="Amount" dataformatstring="{0:C}">
							<ItemStyle horizontalalign="Right"></ItemStyle>
						  </ASP:BoundColumn>
						  <ASP:BoundColumn datafield="note" headertext="Note"></ASP:BoundColumn>
						  <ASP:ButtonColumn text="Delete" commandname="Delete"></ASP:ButtonColumn>
						</Columns></ASP:DataGrid>
				</td>
			  </tr>
			</table>
		  </td>
		</tr>
	  </table>
	  <p></p>
	  <table cellspacing="0" cellpadding="10" border="1" id="Table_emphasized_totals" runat="server" bordercolor="darkgray">
		<tr>
		  <td align="center" bgcolor="darkgray"><strong><font color="white">TOTAL OF ACTUAL COSTS</font></strong></td>
		  <td align="center" bgcolor="darkgray"><strong><font color="white">TOTAL OF PROVEN PAYMENTS</font></strong></td>
		  <td align="center" bgcolor="black"><strong><font color="white">TOTAL OF EMSOF AMOUNTS</font></strong></td>
		</tr>
		<tr>
		  <td align="center"><ASP:Label id="Label_total_of_actual_costs" runat="server" font-bold="True"></ASP:Label></td>
		  <td align="center"><ASP:Label id="Label_total_of_proven_payments" runat="server" font-bold="True"></ASP:Label></td>
		  <td align="center"><ASP:Label id="Label_total_of_emsof_amounts" runat="server" font-bold="True"></ASP:Label></td>
		</tr>
	  </table>
	  <p></p>
<table id="Table_quick_message" runat="server" bordercolor="#dcdcdc" cellspacing="0" cellpadding="0" border="1">
  <tr>
    <td>
      <table cellspacing="0" cellpadding="10" width="100%" border="0">
        <tr><td bgcolor="#f5f5f5"><a id="QuickMessage"><strong>QuickMessage</strong></a></td></tr>
        <tr>
          <td>
            <table cellspacing="0" cellpadding="10" width="100%" border="0">
              <tr>
                <td>Send email to:</td>
                <td><ASP:Literal id="Literal_emsof_contact_name" runat="server"></ASP:Literal></td>
                <td></td>
              </tr>
              <tr>
                <td>Bcc:</td>
                <td><ASP:Label id="Label_author_email_address" runat="server"></ASP:Label></td>
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
                <td nowrap="true" valign="top"><ASP:RequiredFieldValidator id="RequiredFieldValidator_quick_message_body" runat="server" errormessage="Please enter a message body." font-bold="True" controltovalidate="TextBox_quick_message_body" validationgroup="quick_message">!ERR!</ASP:RequiredFieldValidator></td>
              </tr>
              <tr>
                <td></td>
                <td><ASP:Button id="Button_send" runat="server" text="Send" validationgroup="quick_message" onclick="Button_send_Click"></ASP:Button></td>
                <td></td>
              </tr>
              <tr><td valign="top"><small><font color="#c0c0c0">Resolves to:</small></font></td><td valign="top"><small><ASP:Label id="Label_distribution_list" runat="server" forecolor="Silver"></ASP:Label></small></td>
                <td></td>
              </tr>
            </table>
          </td>
        </tr>
      </table>
    </td>
  </tr>
</table>
	  <p></p>
	  <table cellspacing="0" cellpadding="0" border="1" id="Table_disposition_nominal" runat="server" bordercolor="#98fb98">
		<tr>
		  <td>
			<table cellspacing="0" cellpadding="10" border="0">
			  <tr>
				<td bgcolor="#98fb98">
				  <strong>Disposition</strong>
				</td>
			  </tr>
			  <tr>
				<td>
				  <p>If you are not ready to disposition this request, <asp:LinkButton id="LinkButton_back_2" runat="server" onclick="LinkButton_back_2_Click">go back to the previous form</asp:LinkButton>. </p></td>
			  </tr>
			  <tr>
				<td>
				  <table cellspacing="0" cellpadding="10" border="0">
					<tr>
					  <td bgcolor="#f5f5f5"><strong>To APPROVE and send to <ASP:Label id="Label_next_reviewer" runat="server"></ASP:Label>...</strong></td>
					</tr>
					<tr>
					  <td>
						
                              <table cellspacing="0" cellpadding="5" border="0">
                                  <tr><td nowrap="true">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                    <td>Check&nbsp; <asp:checkbox id="CheckBox_approve" runat="server">
						</asp:checkbox>&nbsp;and click <asp:button id="Button_approve" runat="server" text="APPROVE" onclick="Button_approve_Click"></asp:button>. </td>
                                  </tr>
                              </table></td>
					</tr>
					<tr id="TableRow_return" runat="server">
					  <td bgcolor="#f5f5f5"><strong>To return to service for rework...</strong></td>
					</tr>
					<tr id="TableRow_reject" runat="server">
					  <td bgcolor="#f5f5f5"><strong>To REJECT...</strong></td>
					</tr>
					<tr>
					  <td>
						<table cellspacing="0" cellpadding="5" border="0">
						  <tr>
							<td valign="top" nowrap="true">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Enter reason: </td>
							<td valign="top">
							  <textarea rows="3" cols="30" id="TextArea_disapproval_reason" name="TextArea_disapproval_comment" runat="Server"></textarea>
							</td>
							<td valign="top">and click <asp:button id="Button_disapprove" runat="server" onclick="Button_disapprove_Click"></asp:button>. </td>
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
	  <table cellspacing="0" cellpadding="0" border="1" id="Table_action_pending_nominal" runat="server" bordercolor="#98fb98">
		<tr>
		  <td>
			<table cellspacing="0" cellpadding="10" border="0">
			  <tr>
				<td bgcolor="#98fb98">
				  <strong>Action pending</strong>
				</td>
			  </tr>
			  <tr>
				<td>
				  <p>The current status of this request in WebEMSOF is <ASP:Label id="Label_current_status" runat="server" font-bold="True"></ASP:Label>.</p>
				</td>
			  </tr>
			  <tr>
				<td>
				  <table cellspacing="0" cellpadding="10" border="0" width="100%" id="Table_mark_done" runat="Server">
					<tr>
					  <td bgcolor="#f5f5f5"><strong>To mark the pending action as DONE...</strong></td>
					</tr>
					<tr><td>
						
                              <table cellspacing="0" cellpadding="5" border="0">
                                  <tr><td nowrap="true">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                    <td>Check&nbsp; <asp:checkbox id="CheckBox_mark_done" runat="server">
						</asp:checkbox>&nbsp;and click <asp:button id="Button_mark_done" runat="server" text="DONE" onclick="Button_mark_done_Click"></asp:button>. </td>
                                  </tr>
                              </table></td>
					</tr>
				  </table>
				  <table cellspacing="0" cellpadding="10" width="100%" border="0" id="Table_mark_failed" runat="server">
					  <tr>
						<td bgcolor="#f5f5f5"><strong>To mark this request as FAILED DEADLINE...</strong></td>
					  </tr>
					  <tr>
						<td>
                              <table cellspacing="0" cellpadding="5" border="0">
                                  <tr><td nowrap="true">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                    <td>Check <ASP:CheckBox id="CheckBox_mark_failed" runat="server"></ASP:CheckBox>&nbsp;and click <ASP:Button id="Button_failed" runat="server" text="FAILED" onclick="Button_failed_Click"></ASP:Button>.</td></tr></table></td></tr>
				  </table>
				  <table cellspacing="0" cellpadding="10" width="100%" border="0" id="Table_special_promotion" runat="server">
					  <tr>
						<td bgcolor="#f5f5f5"><strong>To give this request a SPECIAL PROMOTION...</strong></td>
					  </tr>
					  <tr><td>
                              <table cellspacing="0" cellpadding="5" border="0">
                                  <tr><td nowrap="true">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                    <td>
									  <p><em><small>Note that this request would not normally be ready for reimbursement because not all declared costs have been covered by proven payments. The rules for releasing EMSOF funds in this situation may not be well-defined.</small>
                                        </em>
                                      </p>
                                      <p>Check <ASP:CheckBox id="CheckBox_special_promotion" runat="server"></ASP:CheckBox>&nbsp;and click <ASP:Button id="Button_special_promotion" runat="server" text="SPECIAL PROMOTION" onclick="Button_special_promotion_Click"></ASP:Button>.</p></td>
                                  </tr>
                              </table></td>
					  </tr>
				  </table>
				</td>
			  </tr>
			</table>
		  </td>
		</tr>
	  </table>
      <p>
		<table bordercolor="#dcdcdc" cellspacing="0" cellpadding="0" border="1" id="Table_extraordinary_actions" runat="server">
            <tr>
              <td>
                <table cellspacing="0" cellpadding="10" border="0">
                    <tr>
                      <td bgcolor="#f5f5f5"><strong>Extraordinary actions</strong></td>
                    </tr>
                    <tr>
                      <td><p><table cellspacing="0" cellpadding="10" border="0">
                              <tr id="TableRow_back_step" runat="server">
                                <td><small>Set this request back to <ASP:Label id="Label_predecessor_status" runat="server"></ASP:Label>.</small></td>
								<td valign="top"><ASP:Button id="Button_back_step" runat="server" text="Do" onclick="Button_back_step_Click"></ASP:Button></td>
                              </tr>
                              <tr id="TableRow_force_open" runat="server">
                                <td><small>Force this request back to NEEDS_SERVICE_FINALIZATION status and make it exempt from normal deadlines.&nbsp; This action will cause <ASP:Label id="Label_application_name" runat="server"></ASP:Label>&nbsp;to forget about the invoices and proofs of payment that are currently associated with this request.&nbsp; The request must then advance through the entire approval and evidence collection process again.</small></td>
								<td valign="top"><ASP:Button id="Button_force_open" runat="server" text="Do" onclick="Button_force_open_Click"></ASP:Button></td>
                              </tr>
							  <tr id="TableRow_force_closed" runat="server">
								<td><small>Revoke this request's deadline exemption.&nbsp; This action will prevent the service from making any further modifications to this request.&nbsp; After taking this action, you will still be able to accept or reject the request as usual.</small></td>
								<td valign="top"><ASP:Button id="Button_force_close" runat="server" text="Do" onclick="Button_force_close_Click"></ASP:Button></td>
							  </tr>
						  </table>
                        </p></td>
                    </tr>
                </table></td>
            </tr>
        </table>
      </p>
	  <uc1:UserControl_postcontent id="UserControl_postcontent" runat="server"></uc1:UserControl_postcontent>
	</form>
  </body>
</html>
