<%@ Page language="c#" Debug="true" Codebehind="profile.pas" AutoEventWireup="false" Inherits="profile.TWebForm_profile" %>
<%@ Register TagPrefix="uc1" TagName="UserControl_precontent" Src="~/usercontrol/app/UserControl_precontent.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UserControl_postcontent" Src="~/usercontrol/app/UserControl_postcontent.ascx" %>
<%@ Register TagPrefix="sstchur" Namespace="sstchur.web.SmartNav" Assembly="sstchur.web.smartnav" %>
<%@ Register TagPrefix="uc1" TagName="UserControl_print_div" Src="~/usercontrol/ki/UserControl_print_div.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/strict.dtd">

<%@ Register TagPrefix="uc2" TagName="UserControl_update_progress_blocker" Src="~/usercontrol/app/UserControl_update_progress_blocker.ascx" %><html>
  <head>
	<title id="Title" runat="server"></title>
	<!-- $Id$ -->
    <link href="../css/standard.css" rel="stylesheet" type="text/css" />
    <!--[if lt IE 7]> <style type="text/css">@import "../css/standard-overrides-for-ie6.css";</style><![endif]-->
  </head>

  <body bgcolor="white">
     <form runat="server">
      <uc1:UserControl_precontent id="UserControl_precontent" runat="server"></uc1:UserControl_precontent><strong>Your service's profile
</strong>&nbsp;&nbsp;&nbsp;&nbsp; <uc1:UserControl_print_div id="UserControl_print_div" runat="server"></uc1:UserControl_print_div>
<div id="Div_print_area">
<p>
        <table cellspacing="0" cellpadding="0" width="%" border="1">
            <tr><td>
                <table cellspacing="0" cellpadding="5" width="%" border="0">
	  <tr>
		<td nowrap="true">
                        <p align="right">Affiliate #:
</p></td>
		<td><ASP:Label id="Label_affiliate_num" runat="server"></ASP:Label></td>
                      <td></td>
	  </tr>
	  <tr>
		<td nowrap="true">
                        <p align="right">Service name:
</p></td>
		<td>
                        <ASP:TextBox id="TextBox_service_name" runat="server" maxlength="127"></ASP:TextBox></td>
					  <td><ASP:RequiredFieldValidator id="RequiredFieldValidator_service_name" runat="server" errormessage="Service name is required." controltovalidate="TextBox_service_name" font-bold="True">!ERR!
</ASP:RequiredFieldValidator><ASP:RegularExpressionValidator id="RegularExpressionValidator_service_name" runat="server" errormessage="Please leave disallowed punctuation out of your service name." font-bold="True" controltovalidate="TextBox_service_name" validationexpression="[0-9a-zA-z\.,'#%&amp;()-_ ]+">!ERR!
</ASP:RegularExpressionValidator></td>
	  </tr>
	  <tr>
							  <td valign="top" nowrap="true">
						<p align="right">Type of license/recognition:<br><small>(Check all that apply.)
</small>



</p></td>
		<td>
		  <p>
						  <ASP:CheckBox id="CheckBox_qrs" runat="server" text="QRS"></ASP:CheckBox>&nbsp;&nbsp; <ASP:CheckBox id="CheckBox_bls_amb" runat="server" text="BLS Ambulance"></ASP:CheckBox>&nbsp;&nbsp; <ASP:CheckBox id="CheckBox_als_amb" runat="server" text="ALS Ambulance"></ASP:CheckBox>&nbsp;&nbsp; <ASP:CheckBox id="CheckBox_als_squad" runat="server" text="ALS Squad"></ASP:CheckBox>&nbsp;&nbsp; <ASP:CheckBox id="CheckBox_air_amb" runat="server" text="Air Ambulance"></ASP:CheckBox>&nbsp;&nbsp; <ASP:CheckBox id="CheckBox_rescue" runat="server" text="Rescue"></ASP:CheckBox>
		  



</p></td>
                      <td></td>
	  </tr>
	  <tr>
		<td valign="top" nowrap="true">
                        <p align="right">Address:
</p></td>
		<td>
						<ASP:TextBox id="TextBox_address_line_1" runat="server" maxlength="127"></ASP:TextBox><br>
                        <ASP:TextBox id="TextBox_address_line_2" runat="server" maxlength="127"></ASP:TextBox></td>
                      <td valign="top">
                        <ASP:RequiredFieldValidator id="RequiredFieldValidator_address_line_1" runat="server" font-bold="True" controltovalidate="TextBox_address_line_1" errormessage="At least one address line is required.">!ERR!
</ASP:RequiredFieldValidator><ASP:RegularExpressionValidator id="RegularExpressionValidator_address_line_1" runat="server" font-bold="True" controltovalidate="TextBox_address_line_1" errormessage="Please leave disallowed characters out of the first address line."
                                validationexpression="[0-9a-zA-Z\.,#%&amp;()-_' ]*">!ERR!
</ASP:RegularExpressionValidator>
  <br><ASP:RegularExpressionValidator id="RegularExpressionValidator_address_line_2" runat="server" font-bold="True" controltovalidate="TextBox_address_line_2" errormessage="Please leave disallowed characters out of the second address line."
                                validationexpression="[0-9a-zA-Z\.,#%&amp;()-_' ]*">!ERR!
</ASP:RegularExpressionValidator></td>
	  </tr>
	  <tr>
		<td nowrap="true">
						<p align="right">City:
</p></td>
		<td>
						<ASP:TextBox id="TextBox_city" runat="server" maxlength="127"></ASP:TextBox></td>
					  <td><ASP:RequiredFieldValidator id="RequiredFieldValidator_city" runat="server" errormessage="City is required." controltovalidate="TextBox_city" font-bold="True">!ERR!
</ASP:RequiredFieldValidator><ASP:RegularExpressionValidator id="RegularExpressionValidator_city" runat="server" font-bold="True" controltovalidate="TextBox_city" errormessage="Please leave disallowed characters out of the city name." validationexpression="[a-zA-Z\.' ]+">!ERR!
</ASP:RegularExpressionValidator></td>
	  </tr>
	  <tr>
		<td nowrap="true">
						<p align="right">State:
</p></td>
		<td>
						<strong>PA
</strong></td>
					  <td></td>
	  </tr>
	  <tr>
		<td nowrap="true">
						<p align="right">Zip code: <br><small>(5 or 9 numerals only)
</small>



</p></td>
		<td>
						<ASP:TextBox id="TextBox_zip_code" runat="server" maxlength="9"></ASP:TextBox></td>
					  <td><ASP:RequiredFieldValidator id="RequiredFieldValidator_zip_code" runat="server" errormessage="Zip code is required." controltovalidate="TextBox_zip_code" font-bold="True">!ERR!
</ASP:RequiredFieldValidator>
						<ASP:RegularExpressionValidator id="RegularExpressionValidator_zip_code" runat="server" errormessage="Invalid zip code." controltovalidate="TextBox_zip_code" validationexpression="\d{5}(\d{4})?" font-bold="True">!ERR!
</ASP:RegularExpressionValidator></td>
	  </tr>
	  <tr>
		<td nowrap="true">						<p align="right">Federal Employer (tax) ID #: <br><small>(numerals only)
</small>



</p></td>
</td>
		<td>
                        <ASP:TextBox id="TextBox_federal_tax_id_num" runat="server" maxlength="9"></ASP:TextBox></td>
                      <td><ASP:RequiredFieldValidator id="RequiredFieldValidator_federal_tax_id_num" runat="server" errormessage="Federal Employer (tax) ID is required." controltovalidate="TextBox_contact_person_name" font-bold="True">!ERR!
</ASP:RequiredFieldValidator><ASP:RegularExpressionValidator id="RegularExpressionValidator_federal_tax_id_num" runat="server" errormessage="Invalid Federal Employer (tax) ID number." controltovalidate="TextBox_federal_tax_id_num" validationexpression="\d{9}" font-bold="True">!ERR!
</ASP:RegularExpressionValidator></td></tr>
	  <tr>
		<td nowrap="true">
                        <p align="right">Contact person's name:
</p></td>
        <td>
                        <ASP:TextBox id="TextBox_contact_person_name" runat="server" maxlength="127"></ASP:TextBox></td>
                      <td><ASP:RequiredFieldValidator id="RequiredFieldValidator_contact_person_name" runat="server" errormessage="Contact person's name is required." controltovalidate="TextBox_contact_person_name" font-bold="True">!ERR!
</ASP:RequiredFieldValidator><ASP:RegularExpressionValidator id="RegularExpressionValidator_contact_person_name" runat="server" errormessage="Please leave disallowed characters out of contact person's name." font-bold="True" controltovalidate="TextBox_contact_person_name" validationexpression="[a-zA-Z\., ]+">!ERR!
</ASP:RegularExpressionValidator></td>
      </tr>
      <tr>
		<td nowrap="true">
						<p align="right">Contact person's phone #: <br><small>(Include area code, numerals only)
</small>



</p></td>
        <td>
                        <ASP:TextBox id="TextBox_contact_person_phone_num" runat="server" maxlength="10"></ASP:TextBox></td>
                      <td><ASP:RequiredFieldValidator id="RequiredFieldValidator_contact_person_phone_num" runat="server" errormessage="Contact person's phone number is required." controltovalidate="TextBox_contact_person_phone_num" font-bold="True">!ERR!
</ASP:RequiredFieldValidator><ASP:RegularExpressionValidator id="RegularExpressionValidator_contact_person_phone_num" runat="server" errormessage="Invalid phone number." controltovalidate="TextBox_contact_person_phone_num" validationexpression="\d{10}" font-bold="True">!ERR!
</ASP:RegularExpressionValidator></td>
      </tr>
                    <tr>
                      <td></td>
                      <td>
                <p>By submitting this form to WebEMSOF, you are affirming that you are the contact person listed above, and you are agreeing to serve as the above service's EMSOF point of contact for this EMSOF cycle.&nbsp; You further affirm that if you must relinquish your responsibilities as the service's EMSOF point of contact during this cycle, you will give reasonable advanced notice to the service and to the regional council.
</p>
                <p>
                        <ASP:Button id="Button_submit" runat="server" text="Submit"></ASP:Button></p></td>
                      <td></td>
                    </tr></table></td></tr></tbody></table></p>
</div>
	<uc1:UserControl_postcontent id="UserControl_postcontent" runat="server"></uc1:UserControl_postcontent>
      <p><sstchur:SmartScroller id="SmartScroller_control" runat="server" /></p>
      <uc2:UserControl_update_progress_blocker id="UserControl_update_progress_blocker_control" runat="server"></uc2:UserControl_update_progress_blocker>
    </form>
  </body>
</html>
