<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/strict.dtd">
<%@ Page language="c#" Debug="true" Codebehind="state_required_report.aspx.cs" AutoEventWireup="True" Inherits="state_required_report.TWebForm_state_required_report" %>
<%@ Register TagPrefix="uc1" TagName="UserControl_precontent" Src="~/usercontrol/app/UserControl_precontent.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UserControl_postcontent" Src="~/usercontrol/app/UserControl_postcontent.ascx" %>
<%@ Register TagPrefix="uc2" TagName="UserControl_update_progress_blocker" Src="~/usercontrol/app/UserControl_update_progress_blocker.ascx" %>
<html>
  <head>
    <title id="Title" runat="server"></title>
    <!-- $Id$ -->
    <link href="../css/standard.css" rel="stylesheet" type="text/css" />
    <!--[if lt IE 7]> <style type="text/css">@import "../css/standard-overrides-for-ie6.css";</style><![endif]-->
  </head>
  <body bgcolor="white">
    <form runat="server">
      <uc1:UserControl_precontent id="UserControl_precontent" runat="server"></uc1:UserControl_precontent>
      <table bordercolor="#dcdcdc" cellspacing="0" cellpadding="0" border="1">
        <tr>
          <td>
            <table cellspacing="0" cellpadding="10" border="0">
              <tr>
                <td bgcolor="#f5f5f5">
                  <table cellspacing="0" cellpadding="5" width="75%" border="0">
                    <tr>
                      <td><strong>State-required report</strong></td>
                      <td>
                        <p align="center">
                          <ASP:LinkButton id="LinkButton_export_scratch_copy" runat="server" enabled="False" onclick="LinkButton_export_scratch_copy_Click">Export scratch copy</ASP:LinkButton>
                        </p>
                      </td>
                      <td>
                        <div align="center">
                          <asp:linkbutton id="LinkButton_transmit_to_state" runat="server" enabled="False" font-bold="True" onclick="LinkButton_transmit_to_state_Click">TRANSMIT TO STATE</asp:linkbutton>
                        </div>
                      </td>
                    </tr>
                    <tr>
                      <td colspan="3">
                        <small>A total of <ASP:Label id="Label_total_num_requests" runat="server" font-bold="True"></ASP:Label>&nbsp;requests are ready to be transmitted to the state.</small>
                      </td>
                    </tr>
                    <tr id="TableRow_this_is_everything" runat="server" visible="False">
                      <td colspan="3">
                        <small>This report includes request items from all&nbsp;<ASP:Label id="Label_total_num_requests_2" runat="server" font-bold="True"></ASP:Label> requests.</small>
                      </td>
                    </tr>
                    <tr id="TableRow_this_is_just_some" runat="server" visible="False">
                      <td colspan="3">
                        <small>This report only includes items from the&nbsp;<ASP:Label id="Label_num_filtered_requests" runat="server" font-bold="True"></ASP:Label>&nbsp;requests made against <ASP:DropDownList id="DropDownList_amendment" runat="server" autopostback="True" onselectedindexchanged="DropDownList_amendment_SelectedIndexChanged"></ASP:DropDownList>.</small>
                      </td>
                    </tr>
                  </table>
                </td>
              </tr>
              <tr>
                <td>
                  <table cellspacing="0" cellpadding="5" border="0" id="Table_report" runat="server">
                    <tr><td>Regional EMS council name: <strong>EMERGENCY MEDICAL SERVICE INSTITUTE</strong></td></tr>
                    <tr id="TableRow_none" runat="server"><td><em>-- NONE --</em></td></tr>
                    <tr>
                      <td>
                        <asp:datagrid id="DataGrid_state_export_batch" runat="server" autogeneratecolumns="False" visible="False" font-size="X-Small" showfooter="True" bordercolor="Gainsboro">
                          <FooterStyle font-bold="True" backcolor="LightGray"></FooterStyle>
                          <AlternatingItemStyle backcolor="WhiteSmoke"></AlternatingItemStyle>
                          <HeaderStyle backcolor="LightGray"></HeaderStyle>
                          <Columns>
                            <ASP:BoundColumn datafield="w_num" readonly="True" headertext="W#">
                              <HeaderStyle font-italic="True"></HeaderStyle>
                              <ItemStyle font-italic="True"></ItemStyle>
                            </ASP:BoundColumn>
                            <ASP:BoundColumn datafield="be_reopened_after_going_to_state" readonly="True" headertext="*">
                              <HeaderStyle horizontalalign="Center"></HeaderStyle>
                              <ItemStyle font-bold="True" horizontalalign="Center"></ItemStyle>
                            </ASP:BoundColumn>
                            <ASP:BoundColumn datafield="service_name" readonly="True" headertext="Organization Name"></ASP:BoundColumn>
                            <ASP:BoundColumn datafield="life_support_level" readonly="True" headertext="Type of Organization"></ASP:BoundColumn>
                            <ASP:BoundColumn datafield="equipment_description" readonly="True" headertext="Equipment/Program">
                            </ASP:BoundColumn>
                            <ASP:BoundColumn datafield="make_model" readonly="True" headertext="Make/Model">
                            </ASP:BoundColumn>
                            <ASP:BoundColumn datafield="quantity" readonly="True" headertext="# Units">
                              <ItemStyle horizontalalign="Right"></ItemStyle>
                            </ASP:BoundColumn>
                            <ASP:BoundColumn datafield="unit_cost" readonly="True" headertext="Unit Cost" dataformatstring="{0:C}">
                              <ItemStyle horizontalalign="Right"></ItemStyle>
                              <FooterStyle horizontalalign="Right"></FooterStyle>
                            </ASP:BoundColumn>
                            <ASP:BoundColumn datafield="total_cost" readonly="True" headertext="Total Cost Amount" dataformatstring="{0:C}">
                              <HeaderStyle horizontalalign="Center"></HeaderStyle>
                              <ItemStyle horizontalalign="Right"></ItemStyle>
                              <FooterStyle horizontalalign="Right"></FooterStyle>
                            </ASP:BoundColumn>
                            <ASP:BoundColumn datafield="emsof_ante" readonly="True" headertext="EMSOF Amount" dataformatstring="{0:C}">
                              <HeaderStyle horizontalalign="Center"></HeaderStyle>
                              <ItemStyle horizontalalign="Right"></ItemStyle>
                              <FooterStyle horizontalalign="Right"></FooterStyle>
                            </ASP:BoundColumn>
                            <ASP:BoundColumn datafield="provider_match" readonly="True" headertext="Provider Match" dataformatstring="{0:C}">
                              <HeaderStyle horizontalalign="Center"></HeaderStyle>
                              <ItemStyle horizontalalign="Right"></ItemStyle>
                              <FooterStyle horizontalalign="Right"></FooterStyle>
                            </ASP:BoundColumn>
                            <ASP:BoundColumn datafield="recommendation" readonly="True" headertext="Recomm">
                              <HeaderStyle horizontalalign="Center"></HeaderStyle>
                              <ItemStyle horizontalalign="Center"></ItemStyle>
                            </ASP:BoundColumn>
                            <ASP:BoundColumn readonly="True" headertext="EMSOF Approved"></ASP:BoundColumn>
                            <ASP:BoundColumn readonly="True" headertext="Actual Total Cost" dataformatstring="{0:C}">
                              <HeaderStyle horizontalalign="Center"></HeaderStyle>
                              <ItemStyle horizontalalign="Right"></ItemStyle>
                              <FooterStyle horizontalalign="Right"></FooterStyle>
                            </ASP:BoundColumn>
                          </Columns>
                        </asp:datagrid>
                      </td>
                    </tr>
                    <tr>
                      <td>
                        <table cellspacing="0" cellpadding="5" border="0">
                          <tr>
                            <td align="right" valign="top">Reviewed and Recommended by Regional EMS Council (name):</td>
                            <td></td>
                            <td valign="top"><strong>William E. Groft</strong><br>President</td>
                          </tr>
                          <tr>
                            <td></td>
                            <td></td>
                            <td valign="top"><strong>Thomas J. McElree</strong><br>Regional EMS Council Director</td>
                          </tr>
                          <tr>
                            <td align="right">Funding Round:</td>
                            <td></td>
                            <td><asp:label id="Label_funding_round" runat="server"></asp:label></td>
                          </tr>
                          <tr>
                            <td align="right">Submission Date:</td>
                            <td></td>
                            <td><asp:label id="Label_submission_date" runat="server"></asp:label></td>
                          </tr>
                          <tr>
                            <td align="right">Review Date:</td>
                            <td></td>
                            <td>__________________________________</td>
                          </tr>
                          <tr>
                            <td align="right">Approval Date:</td>
                            <td></td>
                            <td>__________________________________</td>
                          </tr>
                          <tr>
                            <td align="right">DOH Approval:</td>
                            <td></td>
                            <td>__________________________________</td>
                          </tr>
                          <tr>
                            <td align="right">Date:</td>
                            <td></td>
                            <td>__________________________________</td>
                          </tr>
                        </table>
                        <p>
                          <table cellspacing="0" cellpadding="5" border="0" id="Table_replacement_note" runat="server">
                            <tr>
                              <td valign="top">*</td>
                              <td>Rows marked with a star in this column are <u>replacements</u> for rows that were reported in a previous funding round in this fiscal year.&nbsp; PA DOH EMSO should <u>delete</u> the associated batch of rows from its previous records and use the items in this batch instead.&nbsp; The "W#" can be used to positively determine associated batches.</td>
                            </tr>
                          </table>
                        </p>
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
      <uc2:UserControl_update_progress_blocker id="UserControl_update_progress_blocker_control" runat="server"></uc2:UserControl_update_progress_blocker>
    </form>
  </body>
</html>
