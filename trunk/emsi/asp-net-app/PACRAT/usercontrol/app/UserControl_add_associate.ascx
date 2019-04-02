<%@ Control Language="c#" AutoEventWireup="True" Codebehind="UserControl_add_associate.ascx.cs" Inherits="UserControl_add_associate.TWebUserControl_add_associate"%>
<!-- Derived from KiAspdotnetFramework/usercontrol/app/UserControl~template~kicrudhelped~item.ascx-template -->
<%@ Register TagPrefix="uc1" TagName="UserControl_drop_down_date" Src="~/usercontrol/ki/UserControl_drop_down_date.ascx" %>
<table border="1" bordercolor="gainsboro" cellpadding="0" cellspacing="0" width="100%">
  <tr>
    <td>
      <table cellpadding="10" cellspacing="0" width="100%">
        <tr>
          <td bgcolor="whitesmoke">
            <h3>Load a non-Pennsylvania-practitioner into the system</h3>
            <p><asp:Literal ID="Literal_application_name" runat="server"></asp:Literal> is already loaded with a list of all Pennsylvania EMS practitioners, but you must manually load other personnel into the system using this form.</p>
            <p>You are also adding this person<asp:Literal ID="Literal_association_clause" runat="server"></asp:Literal></p>
            <table cellpadding="10" cellspacing="0" bgcolor="red">
              <tr>
                <td align="center">
                  <b>
                    <font color="white">
                      <p>NEVER USE THIS FORM TO ENTER A CURRENT OR FORMER PENNSYLVANIA EMS PRACTITIONER.</p>
                      <p>USE THE <a href="https://ems.health.state.pa.us/emsportal" target="_blank"><font color="lightblue">STATE EMS REGISTRY SYSTEM</font></a> FOR THAT INSTEAD.</p>
                    </font>
                  </b>
                </td>
              </tr>
            </table>
          </td>
        </tr>
        <tr>
          <td>
<table cellspacing="0" cellpadding="5" width="100%" border="0">
  <tr>
    <td valign="top">
      <table cellspacing="0" cellpadding="1" border="0">
  <tr>
    <td><font class="">Last&nbsp;name*:</font></td>
    <td>
      <font class="">
        <ASP:TextBox id="TextBox_last_name" runat="server" columns="31" maxlength="31" cssclass="" enabled="False"></ASP:TextBox>
      </font></td>
    <td nowrap="nowrap">
      <ASP:RequiredFieldValidator id="RequiredFieldValidator_last_name" runat="server" errormessage="Please enter Last&nbsp;name." font-bold="True" controltovalidate="TextBox_last_name">!ERR!</ASP:RequiredFieldValidator>
    </td>
  </tr>
  <tr>
    <td><font class="">First&nbsp;name*:</font></td>
    <td>
      <font class="">
        <ASP:TextBox id="TextBox_first_name" runat="server" columns="31" maxlength="31" cssclass="" enabled="False"></ASP:TextBox>
      </font></td>
    <td nowrap="nowrap">
      <ASP:RequiredFieldValidator id="RequiredFieldValidator_first_name" runat="server" errormessage="Please enter First&nbsp;name." font-bold="True" controltovalidate="TextBox_first_name">!ERR!</ASP:RequiredFieldValidator>
    </td>
  </tr>
  <tr>
    <td><font class="">Middle&nbsp;initial:</font></td>
    <td>
      <font class="">
        <ASP:TextBox id="TextBox_middle_initial" runat="server" columns="1" maxlength="1" cssclass="" enabled="False"></ASP:TextBox>
      </font>
    </td>
    <td nowrap="nowrap">
    </td>
  </tr>
  <tr>
    <td><font class="">Level:</font></td>
    <td>
      <asp:DropDownList ID="DropDownList_level" runat="server">
      </asp:DropDownList>
    &nbsp;(rough PA equivalent)</td>
    <td nowrap="nowrap">
      &nbsp;</td>
  </tr>
  <tr>
    <td><font class="">Regional&nbsp;council*:</font></td>
    <td>
      <asp:DropDownList ID="DropDownList_regional_council" runat="server">
      </asp:DropDownList>
    &nbsp;(sponsor)</td>
    <td nowrap="nowrap">
      <ASP:RequiredFieldValidator id="RequiredFieldValidator_regional_council_code" runat="server" errormessage="Please select a Regional&nbsp;council." font-bold="True" controltovalidate="DropDownList_regional_council">!ERR!</ASP:RequiredFieldValidator>
    </td>
  </tr>
  <tr>
    <td><font class="">Residence&nbsp;county:</font></td>
    <td>
      <asp:DropDownList ID="DropDownList_residence_county" runat="server">
      </asp:DropDownList>
    </td>
    <td nowrap="nowrap">
      &nbsp;</td>
  </tr>
  <tr>
    <td><font class="">Birth&nbsp;date*:</font></td>
    <td>
      <font class="">
        <uc1:UserControl_drop_down_date id="UserControl_drop_down_date_birth_date" runat="server"  cssclass=""></uc1:UserControl_drop_down_date>
      </font>
    </td>
    <td nowrap="nowrap">
      <asp:CustomValidator ID="CustomValidator_birth_date" runat="server" ErrorMessage="Please enter a Birth date." Font-Bold="True" OnServerValidate="CustomValidator_birth_date_ServerValidate">!ERR!</asp:CustomValidator>
    </td>
  </tr>
  <tr>
    <td><font class="">Email&nbsp;address:</font></td>
    <td>
      <font class="">
        <ASP:TextBox id="TextBox_email_address" runat="server"  cssclass="" enabled="False" Columns="72"></ASP:TextBox>
      </font>
    </td>
    <td nowrap="nowrap">
      <asp:RegularExpressionValidator id="RegularExpressionValidator_email_address" runat="server" errormessage="Please enter a valid Email address." font-bold="True" controltovalidate="TextBox_email_address" validationexpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">!ERR!</asp:RegularExpressionValidator>
      <asp:CustomValidator id="CustomValidator_email_address" runat="server" errormessage='Please enter an Email address with a valid Domain Name (the part after the "@").' font-bold="True" controltovalidate="TextBox_email_address" onservervalidate="CustomValidator_email_address_ServerValidate">!ERR!</asp:CustomValidator>
    </td>
  </tr>
  <tr id="TableRow_street_address_1" runat="server" visible="false">
    <td><font class="">Street&nbsp;address&nbsp;1:</font></td>
    <td>
      <font class="">
        <ASP:TextBox id="TextBox_street_address_1" runat="server"  cssclass="" enabled="False" Columns="72"></ASP:TextBox>
      </font>
    </td>
    <td nowrap="nowrap">
      <asp:RegularExpressionValidator id="RegularExpressionValidator_street_address_1" runat="server" errormessage="Please enter a valid Street address 1." font-bold="True" controltovalidate="TextBox_street_address_1" validationexpression="[0-9a-zA-Z#\-,(). ]+">!ERR!</asp:RegularExpressionValidator>
    </td>
  </tr>
  <tr id="TableRow_street_address_2" runat="server" visible="false">
    <td><font class="">Street&nbsp;address&nbsp;2:</font></td>
    <td>
      <font class="">
        <ASP:TextBox id="TextBox_street_address_2" runat="server"  cssclass="" enabled="False" Columns="72"></ASP:TextBox>
      </font>
    </td>
    <td nowrap="nowrap">
      <asp:RegularExpressionValidator id="RegularExpressionValidator_street_address_2" runat="server" errormessage="Please enter a valid Street address 2." font-bold="True" controltovalidate="TextBox_street_address_2" validationexpression="[0-9a-zA-Z#\-,(). ]+">!ERR!</asp:RegularExpressionValidator>
    </td>
  </tr>
  <tr id="TableRow_city_state_zip" runat="server" visible="false">
    <td><font class="">City&nbsp;state&nbsp;zip:</font></td>
    <td>
      <font class="">
        <ASP:TextBox id="TextBox_city_state_zip" runat="server"  cssclass="" enabled="False" Columns="72"></ASP:TextBox>
      </font>
    </td>
    <td nowrap="nowrap">
      <asp:RegularExpressionValidator id="RegularExpressionValidator_city_state_zip" runat="server" errormessage="Please enter a valid City state zip." font-bold="True" controltovalidate="TextBox_city_state_zip" validationexpression="[a-zA-Z\-. ]+">!ERR!</asp:RegularExpressionValidator>
    </td>
  </tr>
  <tr>
    <td><font class="">Phone&nbsp;number:</font></td>
    <td>
      <font class="">
        <ASP:TextBox id="TextBox_phone_number" runat="server" columns="10" maxlength="10" cssclass=""></ASP:TextBox>
      </font>
    </td>
    <td nowrap="nowrap">
      <ASP:CustomValidator id="CustomValidator_phone_num" runat="server" errormessage="Please enter a valid Phone number.  Premium and reserved numbers are not allowed." controltovalidate="TextBox_phone_number" font-bold="True" onservervalidate="CustomValidator_phone_number_ServerValidate" Display="Dynamic">!ERR!</ASP:CustomValidator>
    </td>
  </tr>
  <tr>
    <td><font class="">Phone&nbsp;service:</font></td>
    <td>
      <asp:DropDownList ID="DropDownList_phone_service" runat="server">
      </asp:DropDownList>
    </td>
    <td nowrap="nowrap">&nbsp;</td>
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
<br />
<ASP:Button id="Button_submit" text="Submit" runat="server" enabled="False" onclick="Button_submit_Click"></ASP:Button>
