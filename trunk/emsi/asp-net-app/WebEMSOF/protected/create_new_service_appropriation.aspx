<!DOCTYPE html>
<%@ Page language="c#" codebehind="create_new_service_appropriation.aspx.cs" AutoEventWireup="True" Inherits="create_new_service_appropriation.TWebForm_create_new_service_appropriation" %>
<%@ Register TagPrefix="uc1" TagName="UserControl_precontent" Src="~/usercontrol/app/UserControl_precontent.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UserControl_postcontent" Src="~/usercontrol/app/UserControl_postcontent.ascx" %>
<%@ Register TagPrefix="uc2" TagName="UserControl_update_progress_blocker" Src="~/usercontrol/app/UserControl_update_progress_blocker.ascx" %>
<html>
  <head runat="server">
    <title></title>
    <!-- $Id$ -->
    <link href="../css/standard.css" rel="stylesheet" type="text/css" />
    <!--[if lt IE 7]> <style type="text/css">@import "../css/standard-overrides-for-ie6.css";</style><![endif]-->
  </head>
  <body bgcolor="white">
     <form runat="server">
      <p>
      <uc1:UserControl_precontent id="UserControl_precontent" runat="server"></uc1:UserControl_precontent></p>
      <asp:UpdatePanel id="UpdatePanel_control" runat="server" updatemode="Conditional">
        <ContentTemplate>
	  <table cellspacing="0" cellpadding="0" border="1" bordercolor="#dcdcdc">
        <tr>
          <td>
			<table cellspacing="0" cellpadding="5" border="0">
              <tr>
				<td bgcolor="#f5f5f5">
                  <p align="right">
					<strong>You were allocated:</strong>
                  </p>
                </td>
                <td>
                  <p align="right">
                  <asp:label id="Label_parent_appropriation_amount" runat="server"></asp:label>
				  </p>
				</td>
				<td>from <asp:label id="Label_region_name" runat="server">
				  </asp:label>&nbsp;for <asp:label id="Label_fiscal_year_designator" runat="server"></asp:label>
				</td>
			  </tr>
			  <tr id="TableRow_sum_of_service_appropriations" runat="server">
				<td>
				  <p align="right">- </p>
				</td>
				<td>
				  <p align="right">
				  <asp:label id="Label_sum_of_service_appropriations" runat="server" font-underline="True"></asp:label>
				  </p>
				</td>
				<td>allocated to services (below)</td>
			  </tr>
			  <tr id="TableRow_unappropriated_amount" runat="server">
				<td>
				  <p align="right">= </p>
				</td>
				<td>
				  <p align="right">
				  <asp:label id="Label_unappropriated_amount" runat="server">
				  </asp:label>
				  </p>
				</td>
				<td>remaining </td>
			  </tr>
			</table>
		  </td>
		</tr>
	  </table>
      <p></p>
      <p><strong>
          <table bordercolor="#dcdcdc" cellspacing="0" cellpadding="0" border="1">
              <tr>
                <td>
                  <table cellspacing="0" cellpadding="5" border="0">
                      <tr>
                        <td bgcolor="#f5f5f5"><strong>New allocation</strong></td>
                      </tr>
                      <tr>
                        <td>
		  <table cellspacing="0" cellpadding="5" border="0">
			  <tr>
			  <td>
			  <p align="right">Service:</p></td>
			  <td nowrap="true">
				<ASP:DropDownList id="DropDownList_services" runat="server" autopostback="True" onselectedindexchanged="DropDownList_services_SelectedIndexChanged"></ASP:DropDownList>&nbsp;&nbsp; <ASP:CheckBox id="CheckBox_show_out_of_county_services" runat="server" font-size="Small" text="Check this box to include out-of-county services in the drop-down list" autopostback="True" oncheckedchanged="CheckBox_unfilter_CheckedChanged"></ASP:CheckBox></td>
			  <td nowrap="true"><ASP:RequiredFieldValidator id="RequiredFieldValidator_service" runat="server" errormessage="Please select a service." font-bold="True" controltovalidate="DropDownList_services">!ERR!</ASP:RequiredFieldValidator><ASP:RangeValidator id="RangeValidator_service" runat="server" errormessage="Please select a service for a new allocation." font-bold="True" controltovalidate="DropDownList_services" minimumvalue="1" maximumvalue="99999">!ERR!</ASP:RangeValidator></td>
			  </tr>
			<tr>
			  <td>
			  <p align="right">Amount:&nbsp; $</p></td>
			  <td><ASP:TextBox id="TextBox_new_amount" runat="server" width="6pc"></ASP:TextBox></td>
			  <td nowrap="true"><ASP:RequiredFieldValidator id="RequiredFieldValidator_new_amount" runat="server" errormessage="Please enter an amount for a new allocation." font-bold="True" controltovalidate="TextBox_new_amount">!ERR!</ASP:RequiredFieldValidator><ASP:RegularExpressionValidator id="RegularExpressionValidator_new_amount" runat="server" font-bold="True" errormessage="Please enter a valid amount." validationexpression="[$0\.]*[1-9][0-9,\.]*" controltovalidate="TextBox_new_amount">!ERR!</ASP:RegularExpressionValidator>
                                  <ASP:CustomValidator id="CustomValidator_amount" runat="server" errormessage="Please enter a valid amount not greater than what remains in your county allocation" font-bold="True" controltovalidate="TextBox_new_amount" onservervalidate="CustomValidator_amount_ServerValidate">!ERR!</ASP:CustomValidator></td>
			</tr>
			<tr>
			  <td>
			  <p align="right">Match level:</p></td>
			  <td>
                <ASP:RadioButtonList id="RadioButtonList_match_level" runat="server" repeatdirection="Horizontal" enabled="False">
                                    <asp:ListItem selected="True" value="1">Standard (50%)</asp:ListItem>
                                    <asp:ListItem value="2">Rural (60%)</asp:ListItem>
                                    <asp:ListItem value="3">Distressed (100%)</asp:ListItem>
                </ASP:RadioButtonList></td>
			  <td></td>
			</tr>
			<tr>
			  <td></td>
			  <td><ASP:Button id="Button_add_appropriation_and_repeat" runat="server" text="Add and Repeat" onclick="Button_add_appropriation_and_repeat_Click"></ASP:Button>&nbsp;<ASP:Button id="Button_add_appropriation_and_stop" runat="server" text="Add and Stop" onclick="Button_add_appropriation_and_stop_Click"></ASP:Button>&nbsp;<ASP:Button id="Button_cancel" runat="server" text="Cancel" causesvalidation="False" onclick="Button_cancel_Click"></ASP:Button></td>
			  <td></td>
			</tr>
		  </table></td>
                      </tr>
                  </table></td>
              </tr>
          </table></strong>
      </p>
        </ContentTemplate>
      </asp:UpdatePanel>
	<uc1:UserControl_postcontent id="UserControl_postcontent" runat="server"></uc1:UserControl_postcontent>
      <uc2:UserControl_update_progress_blocker id="UserControl_update_progress_blocker_control" runat="server"></uc2:UserControl_update_progress_blocker>
    </form>
  </body>
</html>
