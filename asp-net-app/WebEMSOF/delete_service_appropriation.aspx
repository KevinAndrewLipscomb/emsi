<%@ Page language="c#" Debug="true" Codebehind="delete_service_appropriation.pas" AutoEventWireup="false" Inherits="delete_service_appropriation.TWebForm_delete_service_appropriation" %>
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
        <ASP:Label id="Label_literal_warning" runat="server" font-bold="True" font-size="Large" backcolor="Gold">&nbsp;Warning!&nbsp;</ASP:Label></p>
<p><ASP:Label id="Label_service_name_1" runat="server"></ASP:Label>&nbsp;has&nbsp;already entered equipment requests in association with the 
        <ASP:Label id="Label_fiscal_year" runat="server"></ASP:Label>&nbsp;appropriation of 
        <ASP:Label id="Label_amount" runat="server"></ASP:Label>&nbsp;that you made to them.&nbsp; If you delete the appropriation, WebEMSOF will also <strong>permanently delete</strong> the associated equipment requests.&nbsp; The equipment requests will <strong>not</strong> automatically carry over to any other appropriation.</p>
<p>Are you sure you want to permanently delete this appropriation (and all equipment requests that 
        <ASP:Label id="Label_service_name_2" runat="server"></ASP:Label>&nbsp;has already entered against it)?</p>
<p>
        <table cellspacing="0" cellpadding="10" border="0">
            <tr>
              <td>
                <div align="center">
        <ASP:Button id="Button_yes" runat="server" text="Yes"></ASP:Button>
                </div></td>
              <td>-- Delete the appropriation and the linked equipment requests.</td>
            </tr>
            <tr>
              <td>
                <div align="center"><ASP:Button id="Button_no" runat="server" text="No"></ASP:Button>
                </div></td>
              <td>-- Leave the appropriation the way it is.</td>
            </tr>
        </table>
        </p>
    <asp:placeholder id="PlaceHolder_postcontent" runat="server">
    </asp:placeholder>
     </form>
  </body>
</html>
