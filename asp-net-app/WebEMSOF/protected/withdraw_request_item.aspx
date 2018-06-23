<%@ Page language="c#" Debug="true" Codebehind="withdraw_request_item.aspx.cs" AutoEventWireup="True" Inherits="withdraw_request_item.TWebForm_withdraw_request_item" %>
<%@ Register TagPrefix="uc1" TagName="UserControl_precontent" Src="~/usercontrol/app/UserControl_precontent.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UserControl_postcontent" Src="~/usercontrol/app/UserControl_postcontent.ascx" %>
<!DOCTYPE html>

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
<p>
        <table bordercolor="#ffd700" cellspacing="0" cellpadding="0" border="1">
            <tr>
              <td>
                <table cellspacing="0" cellpadding="5" border="0">
                    <tr>
                      <td bgcolor="#ffd700">
        <ASP:Label id="Label_literal_warning" runat="server" font-bold="True" font-size="Large">&nbsp;Warning!&nbsp;</ASP:Label></td>
                    </tr>
                    <tr>
					  <td>
<p>Withdrawing an item from your request at this point is an <strong>irreversible</strong> action.</p>
<p>Are you sure you want to withdraw&nbsp;your <strong>Priority</strong>
		<ASP:Label id="Label_priority" runat="server" font-bold="True"></ASP:Label>&nbsp;item
		          (<ASP:Label id="Label_description" runat="server" font-bold="True"></ASP:Label>) from your request, and surrender
		<ASP:Label id="Label_emsof_ante" runat="server" font-bold="True"></ASP:Label>&nbsp;of EMSOF funds for use on other approved items in your request (if any, subject to EMSOF rules), or else by other agencies?</p>
<p>
		<table cellspacing="0" cellpadding="10" border="0">
			<tr>
			  <td>
				<div align="center">
		<ASP:Button id="Button_yes" runat="server" text="Yes" onclick="Button_yes_Click"></ASP:Button>
				</div></td>
              <td>-- Withdraw the item from my request.</td>
			</tr>
            <tr>
			  <td>
                <div align="center"><ASP:Button id="Button_no" runat="server" text="No" onclick="Button_no_Click"></ASP:Button>
				</div></td>
              <td>-- Leave the item the way it is.</td>
			</tr>
        </table>
		</p>
					  </td>
					</tr>
				</table></td>
			</tr>
		</table></p>
	<uc1:UserControl_postcontent id="UserControl_postcontent" runat="server"></uc1:UserControl_postcontent>
      <uc2:UserControl_update_progress_blocker id="UserControl_update_progress_blocker_control" runat="server"></uc2:UserControl_update_progress_blocker>
    </form>
  </body>
</html>
