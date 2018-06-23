<!DOCTYPE HTML>
<%@ Page language="c#" Debug="true" Codebehind="request_overview.aspx.cs" AutoEventWireup="True" Inherits="request_overview.TWebForm_request_overview" %>
<%@ Register TagPrefix="uc1" TagName="UserControl_precontent" Src="~/usercontrol/app/UserControl_precontent.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UserControl_postcontent" Src="~/usercontrol/app/UserControl_postcontent.ascx" %>
<%@ Register TagPrefix="uc2" TagName="UserControl_update_progress_blocker" Src="~/usercontrol/app/UserControl_update_progress_blocker.ascx" %>
<html>
  <head runat="server">
    <!-- $Id$ -->
    <link href="../css/standard.css" rel="stylesheet" type="text/css" />
    <!--[if lt IE 7]> <style type="text/css">@import "../css/standard-overrides-for-ie6.css";</style><![endif]-->
  </head>
  <body bgcolor="white">
	 <form runat="server">
      <uc1:UserControl_precontent id="UserControl_precontent" runat="server"></uc1:UserControl_precontent>
		  <table bordercolor="#dcdcdc" cellspacing="0" cellpadding="0" border="1" id="Table_parent_appropriation_outer" runat="server">
              <tr>
				<td>
	  <table cellspacing="0" cellpadding="5" border="0">
			<tr>
			  <td bgcolor="#f5f5f5">
				<p align="right"><strong>You were allocated:</strong></p></td>
			  <td>
			  <p align="right"><ASP:Label id="Label_parent_appropriation_amount" runat="server"></ASP:Label></p></td>
			  <td>from
		<ASP:Label id="Label_sponsor_county" runat="server"></ASP:Label>&nbsp;for <ASP:Label id="Label_fiscal_year_designator" runat="server"></ASP:Label></td>
			</tr>
			<tr id="TableRow_sum_of_emsof_antes" runat="server">
			  <td>
				<p align="right">-</p></td>
			  <td>
			  <p align="right">
				<ASP:Label id="Label_sum_of_emsof_antes" runat="server" font-underline="True"></ASP:Label></p></td>
			  <td>requested from EMSOF (below)</td>
			</tr>
			<tr id="TableRow_unrequested_amount" runat="server">
			  <td>
				<p align="right">=</p></td>
			  <td>
              <p align="right"><ASP:Label id="Label_unused_amount" runat="server"></ASP:Label></p></td>
			  <td>remaining</td>
			</tr>
		</table>
				</td>
			  </tr>
		  </table>
      <p></p>
      <table bordercolor="#dcdcdc" cellspacing="0" cellpadding="0" border="1">
          <tr>
            <td>
              <table cellspacing="0" cellpadding="5" border="0">
                  <tr>
                    <td bgcolor="#f5f5f5"><strong>Master status:</strong></td>
                    <td>
                      <ASP:Label id="Label_master_status" runat="server"></ASP:Label></td>
                  </tr>
              </table></td>
          </tr>
      </table>
	  <p>
        <table bordercolor="#dcdcdc" cellspacing="0" cellpadding="0" border="1" id="Table_deadlines" runat="server">
            <tr>
              <td>
		<table cellspacing="0" cellpadding="5" border="0">
			<tr>
			  <td bgcolor="#f5f5f5"><strong>Deadlines</strong></td>
			</tr>
			<tr>
			  <td>You must finalize your item requests by <ASP:Label id="Label_make_requests_deadline" runat="server" font-bold="True" font-size="Medium"></ASP:Label>.</td>
			</tr>
		</table></td>
			</tr>
		</table>
	  </p>
<p>
		<table bordercolor="#dcdcdc" cellspacing="0" cellpadding="0" border="1">
			<tr>
			  <td>
		<table cellspacing="0" cellpadding="10" border="0">
			<tr bgcolor="#f5f5f5">
			  <td><strong>Items requested</strong></td>
			  <td>
			  <div align="center"><ASP:LinkButton id="LinkButton_add_item_to_request" runat="server" onclick="LinkButton_add_item_to_request_Click">New</ASP:LinkButton>
			  </div></td>
			  <td>
						<p align="center">
						  <ASP:LinkButton id="LinkButton_finalize" runat="server" font-bold="True" onclick="LinkButton_finalize_Click">FINALIZE...</ASP:LinkButton>
						</p></td>
			</tr>
			<tr>
			  <td colspan="3"><ASP:Label id="Label_no_appropriations" runat="server" visible="False" font-italic="True">-- NONE --</ASP:Label></td>
			</tr>
		  <tr>
			<td colspan="3">
		  <ASP:DataGrid id="DataGrid_items" runat="server"
			bordercolor="Gainsboro"
			borderstyle="None"
			borderwidth="1px"
			backcolor="White"
			cellpadding="10"
			gridlines="Horizontal"
			forecolor="Black"
			useaccessibleheader="True"
			autogeneratecolumns="False"
			visible="False">
                          <FooterStyle forecolor="Black" backcolor="#CCCC99"></FooterStyle>
                          <SelectedItemStyle font-bold="True" forecolor="White" backcolor="#CC3333"></SelectedItemStyle>
                          <HeaderStyle font-bold="True" backcolor="WhiteSmoke"></HeaderStyle>
                          <Columns>
                            <ASP:BoundColumn visible="False" datafield="master_id" readonly="True">
                              <ItemStyle horizontalalign="Center" forecolor="Gray"></ItemStyle>
                            </ASP:BoundColumn>
                            <ASP:BoundColumn datafield="priority" readonly="True" headertext="Priority">
                              <ItemStyle horizontalalign="Center"></ItemStyle>
                            </ASP:BoundColumn>
                            <ASP:BoundColumn visible="False" datafield="code" readonly="True"></ASP:BoundColumn>
                            <ASP:BoundColumn datafield="item_description" readonly="True" headertext="Description"></ASP:BoundColumn>
                            <ASP:BoundColumn datafield="emsof_ante" readonly="True" headertext="EMSOF amount" dataformatstring="{0:C}">
                              <ItemStyle horizontalalign="Right"></ItemStyle>
                            </ASP:BoundColumn>
                            <ASP:BoundColumn datafield="status" readonly="True" headertext="Status"></ASP:BoundColumn>
                            <ASP:ButtonColumn text="Select" commandname="Select">
                              <ItemStyle forecolor="Blue"></ItemStyle>
                            </ASP:ButtonColumn>
                            <ASP:ButtonColumn text="Increase priority" commandname="IncreasePriority">
                              <ItemStyle forecolor="Blue"></ItemStyle>
                            </ASP:ButtonColumn>
                            <ASP:ButtonColumn text="Decrease priority" commandname="DecreasePriority">
                              <ItemStyle forecolor="Blue"></ItemStyle>
                            </ASP:ButtonColumn>
                          </Columns>
                          <PagerStyle horizontalalign="Right" forecolor="Black" backcolor="White"></PagerStyle></ASP:DataGrid>
            </td>
          </tr>
		</table>
			  </td>
			</tr>
		</table>
	  </p>
<p>
        <table bordercolor="#dcdcdc" cellspacing="0" cellpadding="0" border="1">
            <tr>
              <td>
                <table cellspacing="0" cellpadding="10" border="0">
                    <tr>
                      <td bgcolor="#f5f5f5"><strong>Wish list</strong></td>
                    </tr>
                    <tr>
                      <td>
                        <p>If your County EMSOF Coordinator could find a way to allocate more EMSOF money to your service, would you <strong>want</strong> to, and could you <strong>afford</strong> to add more items to your EMSOF request in this cycle? &nbsp;(Keep in mind that your service would have to pay for the additional item(s) up front, with only partial reimbursement.)</p>
<asp:UpdatePanel id="UpdatePanel_control" runat="server" updatemode="Conditional">
  <ContentTemplate>
                        <p>
                          <ASP:CheckBox id="CheckBox_has_wish_list" runat="server" autopostback="True" text='Yes, we have a "wish list".' oncheckedchanged="CheckBox_has_wish_list_CheckedChanged"></ASP:CheckBox></p>
  </ContentTemplate>
</asp:UpdatePanel>
                        </td>
                    </tr>
                </table></td>
            </tr>
        </table>
	  </p>
<p><table id="Table_withdrawal" bordercolor="#dcdcdc" cellspacing="0" cellpadding="0" border="1" runat="Server">
    <tr>
      <td>
        <table cellspacing="0" cellpadding="10" border="0">
            <tr>
              <td bgcolor="#f5f5f5"><strong>Withdrawal</strong></td>
            </tr>
            <tr>
              <td>
<p>If you are sure you want to withdraw&nbsp;your&nbsp;<strong>entire&nbsp;</strong>request, and surrender all of the above allocated EMSOF funds for use by others...</p>
                        <p>Check <ASP:CheckBox id="CheckBox_withdraw" runat="server"></ASP:CheckBox>&nbsp;and click <ASP:Button id="Button_withdraw" runat="server" text="WITHDRAW" onclick="Button_withdraw_Click"></ASP:Button>.</p></td>
            </tr>
        </table></td>
    </tr>
</table>
	  </p>
	<uc1:UserControl_postcontent id="UserControl_postcontent" runat="server"></uc1:UserControl_postcontent>
      <uc2:UserControl_update_progress_blocker id="UserControl_update_progress_blocker_control" runat="server"></uc2:UserControl_update_progress_blocker>
    </form>
  </body>
</html>
