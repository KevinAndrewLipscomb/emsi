<%@ Page language="c#" Debug="true" Codebehind="choose_county_appropriation.pas" AutoEventWireup="false" Inherits="choose_county_appropriation.TWebForm_county_appropriation" %>
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
<p>
        <ASP:Label id="Label_county_name" runat="server" font-bold="True" font-size="Large"></ASP:Label><strong>&nbsp;<ASP:Label id="Label_literal_county" runat="server" font-bold="True" font-size="Large">County</ASP:Label></strong></p>
<p>Which appropriation do you want to work with?&nbsp; <ASP:RequiredFieldValidator id="RequiredFieldValidator_appropriation" runat="server" errormessage="Please choose an appropriation." font-bold="True" controltovalidate="RadioButtonList_appropriation">!ERR!</ASP:RequiredFieldValidator></p>
<p>
        <ASP:RadioButtonList id="RadioButtonList_appropriation" runat="server"></ASP:RadioButtonList></p>
<p>
        <ASP:Button id="Button_continue" runat="server" text="Continue"></ASP:Button></p>
	  <p><small>Change WebEMSOF
		<a href="change_password.aspx">password</a>&nbsp;| <a href="change_email_address.aspx">email address</a>
	  </small></p></strong>
    <asp:placeholder id="PlaceHolder_postcontent" runat="server">
    </asp:placeholder>
     </form>
  </body>
</html>
