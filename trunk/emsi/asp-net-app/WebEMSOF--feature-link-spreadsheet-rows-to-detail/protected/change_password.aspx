<%@ Register TagPrefix="sstchur" Namespace="sstchur.web.SmartNav" Assembly="sstchur.web.smartnav" %><%@ Page language="c#" Debug="true" Codebehind="change_password.pas" AutoEventWireup="false" Inherits="change_password.TWebForm_change_password" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">

<html>
  <head>
	<title id="Title" runat="server"></title>
	<!-- $Id$ -->
  </head>

  <body>
     <form runat="server">
      <asp:placeholder id="PlaceHolder_precontent" runat="server">
      </asp:placeholder>
<p><small>[ 
          <ASP:LinkButton id="LinkButton_logout" runat="server" causesvalidation="False">Logout</ASP:LinkButton>&nbsp;] [ Back to <ASP:LinkButton id="LinkButton_back_to_overview" runat="server" causesvalidation="False"></ASP:LinkButton>&nbsp;form ]</small></p>
<p>
        <ASP:Label id="Label_account_descriptor" runat="server" font-bold="True" font-size="Large"></ASP:Label></p></small>
<p>
        <table bordercolor="#dcdcdc" cellspacing="0" cellpadding="0" border="1">
            <tr>
              <td>
                <table cellspacing="0" cellpadding="5" border="0">
                    <tr>
                      <td bgcolor="#f5f5f5"><strong>Change password</strong></td>
                    </tr>
                    <tr>
                      <td>
						You must change your password before proceeding.<br>
					  </td>
                    </tr>
                    <tr>
					  <td>
				<table cellspacing="0" cellpadding="5" width="%" border="0">
	<tr>
	  <td>
						<p align="right">Enter the password you would prefer to use for this system:</p></td>
	  <td>
						<ASP:TextBox id="TextBox_nominal_password" runat="server" textmode="Password"></ASP:TextBox></td>
	  <td><ASP:RequiredFieldValidator id="RequiredFieldValidator_nominal_password" runat="server" font-bold="True" errormessage="Please enter a nominal password." controltovalidate="TextBox_nominal_password">!ERR!</ASP:RequiredFieldValidator><ASP:RegularExpressionValidator id="RegularExpressionValidator_password" runat="server" errormessage='Please use only letters, numbers, and the underscore ("_") character (or local equivalents) in your password.' font-bold="True" controltovalidate="TextBox_nominal_password" validationexpression="\w+">!ERR!</ASP:RegularExpressionValidator></td>
	</tr>
	<tr>
	  <td>
						<p align="right">Re-enter your prefered password to avoid typographical errors:</p></td>
	  <td>
						<ASP:TextBox id="TextBox_confirmation_password" runat="server" textmode="Password"></ASP:TextBox></td>
	  <td><ASP:RequiredFieldValidator id="RequiredFieldValidator_confirmation_password" runat="server" font-bold="True" errormessage="Please enter a confirmation password." controltovalidate="TextBox_confirmation_password">!ERR!</ASP:RequiredFieldValidator>
						<ASP:CompareValidator id="CompareValidator1" runat="server" font-bold="True" errormessage="Nominal and confirmation passwords must match.  Please try again." controltovalidate="TextBox_confirmation_password"
											  controltocompare="TextBox_nominal_password">!ERR!</ASP:CompareValidator></td>
	</tr>
	<tr>
	  <td></td>
	  <td>
						<ASP:Button id="Button_submit" runat="server" text="Submit"></ASP:Button></td>
	  <td></td>
	</tr>
				</table>
					  </td>
					</tr>
				</table></td>
			</tr>
		</table></p>
    <asp:placeholder id="PlaceHolder_postcontent" runat="server">
    </asp:placeholder>
     <sstchur:SmartScroller runat="server" /></form>
  </body>
</html>
