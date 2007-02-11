<%@ Register TagPrefix="sstchur" Namespace="sstchur.web.SmartNav" Assembly="sstchur.web.smartnav" %><%@ Page language="c#" Debug="true" Codebehind="add_proof_of_payment.pas" AutoEventWireup="false" Inherits="add_proof_of_payment.TWebForm_add_proof_of_payment" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">

<html>
  <head>
	<title id="Title" runat="server"></title>
      <!-- $Id$ -->
  </head>

  <body>
     <form runat="server">
	  <asp:placeholder id="PlaceHolder_precontent" runat="server"></asp:placeholder>
	  <p>
		<small>[
		  <ASP:LinkButton id="LinkButton_logout" runat="server" causesvalidation="False">Logout</ASP:LinkButton>&nbsp;]
			         [ Back to <ASP:LinkButton id="LinkButton_back" runat="server">previous</ASP:LinkButton>&nbsp;form ]&nbsp;
			         [ Change your <asp:LinkButton id="LinkButton_change_password" runat="server">password</asp:LinkButton>&nbsp;
			|
			<asp:LinkButton id="LinkButton_change_email_address" runat="server">email address</asp:LinkButton>&nbsp;]
		</small>
	  </p>
	  <p><asp:label id="Label_account_descriptor" runat="server" font-bold="True" font-size="Large"></asp:label></p>
	  <p>
        <table bordercolor="#dcdcdc" cellspacing="0" cellpadding="0" border="1">
            <tr>
              <td>
                <table cellspacing="0" cellpadding="10" border="0">
                    <tr>
                      <td bgcolor="#f5f5f5"><strong>Add a proof of payment record</strong></td>
                    </tr>
                    <tr>
					  <td>
						<table cellspacing="0" cellpadding="5" border="0">
							<tr>
							  <td>Payment made by:</td>
							  <td><ASP:Label id="Label_service_name" runat="server"></ASP:Label></td>
							  <td></td>
							</tr>
                            <tr>
							  <td valign="top">Date of payment:</td>
							  <td>
								<ASP:Calendar id="Calendar_date_of_payment" runat="server"></ASP:Calendar></td>
							  <td></td>
							</tr>
							<tr>
							  <td>Method:</td>
							  <td><ASP:DropDownList id="DropDownList_methods" runat="server"></ASP:DropDownList></td>
							  <td><ASP:RequiredFieldValidator id="RequiredFieldValidator_method" runat="server" errormessage="Please specify the method of the payment." font-bold="True" controltovalidate="DropDownList_method">!ERR!</ASP:RequiredFieldValidator></td>
							</tr>
							<tr>
							  <td>Amount:</td>
							  <td><ASP:TextBox id="TextBox_amount" runat="server"></ASP:TextBox></td>
							  <td><ASP:RequiredFieldValidator id="RequiredFieldValidator_amount" runat="server" errormessage="Please specify the amount of the payment." font-bold="True">!ERR!</ASP:RequiredFieldValidator><ASP:RegularExpressionValidator id="RegularExpressionValidator_amount" runat="server" errormessage="Please specify a valid amount." font-bold="True" controltovalidate="TextBox_amount" validationexpression="[$0\.]*[1-9][0-9,\.]*">!ERR!</ASP:RegularExpressionValidator></td>
							</tr>
							<tr>
							  <td>Note:</td>
							  <td><ASP:TextBox id="TextBox_note" runat="server"></ASP:TextBox></td>
							  <td></td>
							</tr>
							<tr>
							  <td></td>
							  <td><ASP:Button id="Button_submit" runat="server" text="Submit"></ASP:Button>&nbsp; <ASP:Button id="Button_cancel" runat="server" text="Cancel"></ASP:Button></td>
							  <td></td>
							</tr>
						</table></td>
                    </tr>
                </table></td>
            </tr>
        </table></p>
          <ASP:LinkButton id="LinkButton_drill_down" runat="server">There is important waypoint-management code behind this drill-down LinkButton.</ASP:LinkButton>
	  <asp:placeholder id="PlaceHolder_postcontent" runat="server"></asp:placeholder>
     <sstchur:SmartScroller runat="server" /></form>
  </body>
</html>
