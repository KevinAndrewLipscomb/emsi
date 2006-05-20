<%@ Page language="c#" Debug="true" Codebehind="change_email_address.pas" AutoEventWireup="false" Inherits="change_email_address.TWebForm_change_email_address" %>
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
		<table cellspacing="0" cellpadding="0" width="%" border="1" bordercolor="#dcdcdc">
			<tr><td>
				<table cellspacing="0" cellpadding="5" width="%" border="0">
			<tr><td bgcolor="#f5f5f5" colspan="3"><strong>Change email address</strong></td></tr>
	<tr>
	  <td>
                        <p align="right">Enter the email_address you would prefer to use for this system:</p></td>
      <td>
						<ASP:TextBox id="TextBox_nominal_email_address" runat="server"></ASP:TextBox></td>
	  <td><ASP:RequiredFieldValidator id="RequiredFieldValidator_nominal_email_address" runat="server" font-bold="True" errormessage="Please enter a nominal email address." controltovalidate="TextBox_nominal_email_address">!ERR!</ASP:RequiredFieldValidator><ASP:RegularExpressionValidator id="RegularExpressionValidator_nominal_email_address" runat="server" errormessage="Please enter a valid email address." font-bold="True" controltovalidate="TextBox_nominal_email_address" validationexpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">!ERR!</ASP:RegularExpressionValidator>
                        <ASP:CustomValidator id="CustomValidator_nominal_email_address" runat="server" errormessage="Please enter a valid domain name (the part after the @ sign)." controltovalidate="TextBox_nominal_email_address" font-bold="True">!ERR!</ASP:CustomValidator></td>
	</tr>
	<tr>
	  <td>
						<p align="right">Re-enter your prefered email_address to avoid typographical errors:</p></td>
	  <td>
						<ASP:TextBox id="TextBox_confirmation_email_address" runat="server"></ASP:TextBox></td>
	  <td><ASP:RequiredFieldValidator id="RequiredFieldValidator_confirmation_email_address" runat="server" font-bold="True" errormessage="Please enter a confirmation email address." controltovalidate="TextBox_confirmation_email_address">!ERR!</ASP:RequiredFieldValidator>
                        <ASP:CompareValidator id="CompareValidator1" runat="server" font-bold="True" errormessage="Nominal and confirmation email addresss must match.  Please try again." controltovalidate="TextBox_confirmation_email_address"
                                              controltocompare="TextBox_nominal_email_address">!ERR!</ASP:CompareValidator></td>
    </tr>
    <tr>
      <td></td>
      <td>
                        <ASP:Button id="Button_submit" runat="server" text="Submit"></ASP:Button></td>
      <td></td>
    </tr>
                </table></td>
            </tr>
        </table></p>
    <asp:placeholder id="PlaceHolder_postcontent" runat="server">
    </asp:placeholder>
     </form>
  </body>
</html>
