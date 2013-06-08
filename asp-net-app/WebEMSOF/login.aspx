<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/strict.dtd">
<%@ Page language="c#" Debug="true" Codebehind="login.aspx.cs" AutoEventWireup="True" Inherits="login.TWebForm_login" %>
<%@ Register TagPrefix="uc1" TagName="UserControl_precontent" Src="~/usercontrol/app/UserControl_precontent.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UserControl_postcontent" Src="~/usercontrol/app/UserControl_postcontent.ascx" %>
<%@ Register TagPrefix="uc2" TagName="UserControl_update_progress_blocker" Src="~/usercontrol/app/UserControl_update_progress_blocker.ascx" %>
<html>
  <head runat="server">
    <!-- $Id$ -->
    <title></title>
    <link href="css/standard.css" rel="stylesheet" type="text/css" />
    <!--[if lt IE 7]> <style type="text/css">@import "css/standard-overrides-for-ie6.css";</style><![endif]-->
    <script type="text/javascript" src="js/sha1.js"></script>
  </head>

  <body bgcolor="white">
  <form id="Form_control" runat="server">
		  <uc1:UserControl_precontent id="UserControl_precontent" runat="server"></uc1:UserControl_precontent>
		  <table bordercolor="#dcdcdc" cellspacing="0" cellpadding="0" border="1">
			  <tr>
				<td>
				  <table cellspacing="0" cellpadding="5" border="0">
					  <tr>
						<td bgcolor="#f5f5f5">
						<table cellspacing="0" cellpadding="0" width="100%" border="0">
							<tr>
							  <td><strong>Log in</strong></td>
							  <td>
								<div align="right">
							  <ASP:CustomValidator id="CustomValidator_account_exists" runat="server" errormessage="Invalid user/password combination. Please try again." font-bold="True" onservervalidate="CustomValidator_account_exists_ServerValidate">!ERR!</ASP:CustomValidator>
								</div></td>
							</tr>
						</table></td>
					  </tr>
					  <tr>
						<td>
<asp:UpdatePanel id="UpdatePanel_control" runat="server" updatemode="Conditional">
  <ContentTemplate>
			    <table cellspacing="0" cellpadding="5">
			      <tbody>
				    <tr>
				      <td><p align="right">Regional council:</p></td>
				      <td>
						    <asp:dropdownlist id="DropDownList_region" runat="server" onselectedindexchanged="DropDownList_region_SelectedIndexChanged">
  						    <ASP:ListItem value="1" Selected="True">EMSI</ASP:ListItem>
                </asp:dropdownlist>
				        <asp:RequiredFieldValidator ID="RequiredFieldValidator_region" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="DropDownList_region" Font-Bold="True">!ERR!</asp:RequiredFieldValidator>
				      </td>
				    </tr>
				    <tr>
				      <td>What kind of user are you?</td>
				      <td>
									      <ASP:DropDownList id="DropDownList_user_kind" runat="server" autopostback="True" onselectedindexchanged="DropDownList_user_kind_SelectedIndexChanged">
								    <ASP:ListItem value="0">-- Select --</ASP:ListItem>
								    <ASP:ListItem value="service">Service (Ambulance, QRS, ALS Squad, etc)</ASP:ListItem>
								    <ASP:ListItem value="county">County Coordinator</ASP:ListItem>
								    <ASP:ListItem value="regional_staffer">Regional staffer</ASP:ListItem></ASP:DropDownList><ASP:RegularExpressionValidator id="RegularExpressionValidator_user_kind" runat="server" errormessage="Please select a user kind." font-bold="True" controltovalidate="DropDownList_user_kind" validationexpression="[a-z_]+">!ERR!</ASP:RegularExpressionValidator>
									    </td>
				    </tr>
				    <tr>
				      <td>
					    <p align="right"><ASP:Label id="Label_user" runat="server" enabled="False">User</ASP:Label>:</p>
				      </td>
				      <td>
							    <asp:dropdownlist id="DropDownList_user"
											      runat="server" onselectedindexchanged="DropDownList_user_SelectedIndexChanged">
							    </asp:dropdownlist><ASP:RegularExpressionValidator id="RegularExpressionValidator_user" runat="server" errormessage="Please select a user." font-bold="True" controltovalidate="DropDownList_user" validationexpression="[^0].+">!ERR!</ASP:RegularExpressionValidator>
				      </td>
				    </tr>
				    <tr>
				      <td>
					    <p align="right">Password:</p>
				      </td>
				      <td>
					    <asp:textbox id="TextBox_noop_ie_behavior_workaround" runat="server" style="DISPLAY: none; VISIBILITY: hidden" /><!-- To work around an IE bug that otherwise prevents Enter in a textbox from submitting a form. -->
					    <asp:textbox id="TextBox_password" runat="server" textmode="Password"></asp:textbox>
                <asp:HiddenField ID="HiddenField_hashed_password" runat="server" />
				      </td>
				    </tr>
				    <tr>
				      <td>
				      </td>
				      <td>
					    <asp:checkbox id="CheckBox_keep_me_logged_in"
								      runat="server"
								      text="Keep me logged in on this computer" enabled="False" visible="False">
					    </asp:checkbox>
				      </td>
				    </tr>
				    <tr>
				      <td valign="top">
				      </td>
				      <td>

						    <table cellspacing="0" cellpadding="5" width="1%">
							    <tr>
							      <td><asp:button id="Button_log_in"
								    runat="server" text="Log in" font-bold="True" onclick="Button_log_in_Click">
					    </asp:button></td>
							      <td nowrap="nowrap">
								    <ASP:button id="Button_new_password" runat="server" text="Email new password" onclick="Button_new_password_Click"></ASP:button></td>
							    </tr>
						    </table>
				      </td>
				    </tr>
			      </tbody>
			    </table>
  </ContentTemplate>
</asp:UpdatePanel>
						</td>
					  </tr>
				  </table>
				</td>
			  </tr>
		  </table>
      <br />
      <table cellspacing="0" cellpadding="10" border="0">
        <tr>
          <td style="border-top:2px dashed sandybrown; border-bottom:2px dashed sandybrown;" valign="top">
            <small>
              <strong><asp:Literal ID="Literal_application_name" runat="server"></asp:Literal></strong> is
              <asp:HyperLink ID="HyperLink_open_source_software_definition" runat="server" NavigateUrl="http://en.wikipedia.org/wiki/Open_source_software" Target="_blank">open source software</asp:HyperLink>.&nbsp;
              Its <asp:HyperLink ID="HyperLink_software_repository_definition" runat="server" NavigateUrl="http://en.wikipedia.org/wiki/Software_repository" Target="_blank">repository</asp:HyperLink> is
              <asp:HyperLink ID="HyperLink_repository_here" runat="server" NavigateUrl="http://sourceforge.net/p/kveo-it-project/code/HEAD/tree/trunk/emsi/asp-net-app/WebEMSOF/" Target="_blank">HERE</asp:HyperLink>.&nbsp;
              <asp:HyperLink ID="HyperLink_Frompaper2webDotCom" runat="server" NavigateUrl="http://frompaper2web.com" Target="_blank">FromPaper2Web.com</asp:HyperLink> provides development, hosting, and maintenance.
            </small>
          </td>
        </tr>
      </table>
    <input id="Hidden_client_timezone_offset" runat="server" type="hidden" />
  <uc1:UserControl_postcontent id="UserControl_postcontent" runat="server"></uc1:UserControl_postcontent>
      <uc2:UserControl_update_progress_blocker id="UserControl_update_progress_blocker_control" runat="server"></uc2:UserControl_update_progress_blocker>
    </form>
</body>
</html>
