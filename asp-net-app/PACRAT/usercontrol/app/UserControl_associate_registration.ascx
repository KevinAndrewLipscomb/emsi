<%@ Control Language="c#" AutoEventWireup="True" Codebehind="UserControl_associate_registration.ascx.cs" Inherits="UserControl_associate_registration.TWebUserControl_associate_registration"%>
<!-- Derived from KiAspdotnetFramework/usercontrol/app/UserControl~template~std.ascx-template -->
<%@ Register TagPrefix="uc1" TagName="UserControl_drop_down_date" Src="~/usercontrol/ki/UserControl_drop_down_date.ascx" %>
<table bordercolor="#dcdcdc" cellspacing="0" cellpadding="0" width="100%" border="1">
  <tr>
    <td>
      <table cellspacing="0" cellpadding="10" width="100%" border="0">
        <tr bgcolor="#f5f5f5">
          <td><b>Associate registration</b></td>
        </tr>
        <tr>
          <td>
            <p>This form allows you to register a non-practitioner individual as an <b>Associate</b> so that he or she may be treated almost like a Practitioner.</p>
            <blockquote>
              <table cellpadding="10" cellspacing="0" bgcolor="yellow">
                <tr>
                  <td>
                    <p>
                      <b>Do not</b> use this form to register a person who is (or should be) listed as an actual Practitioner.&nbsp; Instead, contact the <asp:Literal ID="Literal_application_name" runat="server"></asp:Literal>
                      Application Administrator or the state EMS authorities for guidance.
                    </p>
                    <p><asp:Literal ID="Literal_application_name_2" runat="server"></asp:Literal> will not allow an <b>Associate</b> to link to a practitioner record or use any practitioner-only features.</p>
                  </td>
                </tr>
              </table>
            </blockquote>
<table cellspacing="0" cellpadding="5" width="100%" border="0">
  <tr>
    <td valign="top">
      <table cellspacing="0" cellpadding="5" border="0">
  <tr>
    <td><font class="">First&nbsp;name:</font></td>
    <td>
      <font class="">
        <ASP:TextBox id="TextBox_first_name" runat="server" columns="31" maxlength="31" cssclass=""></ASP:TextBox>
      </font>
    </td>
    <td nowrap="nowrap">
      <ASP:RequiredFieldValidator id="RequiredFieldValidator_first_name" runat="server" errormessage="Please enter First&nbsp;name." font-bold="True" controltovalidate="TextBox_first_name" Enabled="False">!ERR!</ASP:RequiredFieldValidator>
    </td>
  </tr>
  <tr>
    <td><font class="">Middle&nbsp;initial:</font></td>
    <td>
      <font class="">
        <ASP:TextBox id="TextBox_middle_initial" runat="server" columns="1" maxlength="1" cssclass=""></ASP:TextBox>
      </font>
    </td>
    <td nowrap="nowrap">
    </td>
  </tr>
  <tr>
    <td><font class="">Last&nbsp;name:</font></td>
    <td>
      <font class="">
        <ASP:TextBox id="TextBox_last_name" runat="server" columns="31" maxlength="31" cssclass=""></ASP:TextBox>
      </font>
    </td>
    <td nowrap="nowrap">
      <ASP:RequiredFieldValidator id="RequiredFieldValidator_last_name" runat="server" errormessage="Please enter Last&nbsp;name." font-bold="True" controltovalidate="TextBox_last_name" Enabled="False">!ERR!</ASP:RequiredFieldValidator>
    </td>
  </tr>
  <tr>
    <td><font class="">Level:</font></td>
    <td>[Associate]</td>
    <td nowrap="nowrap">
      &nbsp;
    </td>
  </tr>
  <tr>
    <td><font class="">Birth&nbsp;date:</font></td>
    <td>
      <font class="">
        <uc1:usercontrol_drop_down_date id="UserControl_drop_down_date_birth_date" runat="server"></uc1:usercontrol_drop_down_date>
      </font>
    </td>
    <td nowrap="nowrap">
      <ASP:Label id="Label_invalid_birth_date" runat="server" font-bold="True" forecolor="Red" visible="False">!ERR!</ASP:Label>
    </td>
  </tr>
  <tr>
    <td><font class="">Email&nbsp;address:</font></td>
    <td>
      <font class="">
        <ASP:TextBox id="TextBox_email_address" runat="server"  cssclass="" Columns="72"></ASP:TextBox>
      </font>
    </td>
    <td nowrap="nowrap">
      <asp:RegularExpressionValidator id="RegularExpressionValidator_email_address" runat="server" errormessage="Please enter a valid Email address." font-bold="True" controltovalidate="TextBox_email_address" validationexpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Enabled="False">!ERR!</asp:RegularExpressionValidator>
      <asp:CustomValidator id="CustomValidator_email_address" runat="server" errormessage='Please enter an Email address with a valid Domain Name (the part after the "@").' font-bold="True" controltovalidate="TextBox_email_address" onservervalidate="CustomValidator_email_address_ServerValidate" Enabled="False">!ERR!</asp:CustomValidator>
    </td>
  </tr>
  <tr>
    <td><font class="">Street&nbsp;address&nbsp;1:</font></td>
    <td>
      <font class="">
        <ASP:TextBox id="TextBox_street_address_1" runat="server"  cssclass="" Columns="72"></ASP:TextBox>
      </font>
    </td>
    <td nowrap="nowrap">
      <asp:RegularExpressionValidator id="RegularExpressionValidator_street_address_1" runat="server" errormessage="Please enter a valid Street address 1." font-bold="True" controltovalidate="TextBox_street_address_1" validationexpression="[0-9a-zA-Z#\-,(). ]+" Enabled="False">!ERR!</asp:RegularExpressionValidator>
    </td>
  </tr>
  <tr>
    <td><font class="">Street&nbsp;address&nbsp;2:</font></td>
    <td>
      <font class="">
        <ASP:TextBox id="TextBox_street_address_2" runat="server"  cssclass="" Columns="72"></ASP:TextBox>
      </font>
    </td>
    <td nowrap="nowrap">
      <asp:RegularExpressionValidator id="RegularExpressionValidator_street_address_2" runat="server" errormessage="Please enter a valid Street address 2." font-bold="True" controltovalidate="TextBox_street_address_2" validationexpression="[0-9a-zA-Z#\-,(). ]+" Enabled="False">!ERR!</asp:RegularExpressionValidator>
    </td>
  </tr>
  <tr>
    <td><font class="">City&nbsp;state&nbsp;zip:</font></td>
    <td>
      <font class="">
        <ASP:TextBox id="TextBox_city_state_zip" runat="server"  cssclass="" Columns="72"></ASP:TextBox>
      </font>
    </td>
    <td nowrap="nowrap">
      <asp:RegularExpressionValidator id="RegularExpressionValidator_city_state_zip" runat="server" errormessage="Please enter a valid City state zip." font-bold="True" controltovalidate="TextBox_city_state_zip" validationexpression="[a-zA-Z\-. ]+" Enabled="False">!ERR!</asp:RegularExpressionValidator>
    </td>
  </tr>
  <tr>
    <td>&nbsp;</td>
    <td>
      <font class="">
        <ASP:Button id="Button_add_and_stop" runat="server" text="Add and stop" onclick="Button_add_and_stop_Click"></ASP:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<ASP:Button id="Button_add_and_repeat" runat="server" text="Add and repeat" onclick="Button_add_and_repeat_Click"></ASP:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button_cancel" runat="server" Text="Cancel" onclick="Button_cancel_Click" />
      </font>
    </td>
    <td nowrap="nowrap">
      &nbsp;
    </td>
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
