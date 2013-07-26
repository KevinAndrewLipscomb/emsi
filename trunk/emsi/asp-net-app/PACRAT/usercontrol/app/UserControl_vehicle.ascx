<%@ Control Language="c#" AutoEventWireup="True" Codebehind="UserControl_vehicle.ascx.cs" Inherits="UserControl_vehicle.TWebUserControl_vehicle"%>
<!-- Derived from KiAspdotnetFramework/usercontrol/app/UserControl~template~kicrudhelped~item.ascx-template -->
<%@ Register TagPrefix="uc1" TagName="UserControl_drop_down_date" Src="~/usercontrol/ki/UserControl_drop_down_date.ascx" %>
<table cellspacing="0" cellpadding="5" width="100%" border="0">
  <tr>
    <td valign="top">
      <table cellspacing="0" cellpadding="5" border="0">
  <tr runat="server" id="TableRow_record_navigation_controls" visible="false">
    <td bgcolor="gainsboro" valign="top"><font class="">id:</font></td>
    <td valign="top"><font class="">
      <table cellspacing="0" cellpadding="0" border="0">
         <tr>
           <td valign="middle">
             <table cellspacing="0" cellpadding="0" border="0">
               <tr>
                 <td>
      <ASP:TextBox id="TextBox_id" runat="server"  cssclass=""></ASP:TextBox><ASP:Button id="Button_lookup" runat="server" causesvalidation="False" text="LOOKUP" onclick="Button_lookup_Click"></ASP:Button>
                </td>
                <td nowrap="nowrap"><small><small><asp:Label id="Label_lookup_arrow" runat="server">&lt;--</asp:Label></small></small></td>
                <td><small><small><em><asp:Label id="Label_lookup_hint" runat="server">Lookup by partial or full field value</asp:Label></em></small></small></td>
              </tr>
            </table>
          </td>
          <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
          <td valign="middle">
            <small>
              <ASP:LinkButton id="LinkButton_reset" runat="server" causesvalidation="False" enabled="False" onclick="LinkButton_reset_Click">New lookup</ASP:LinkButton>
            </small>
          </td>
          <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
          <td valign="middle">
            <small>
              <ASP:LinkButton id="LinkButton_new_record" runat="server" causesvalidation="False" visible="False" onclick="LinkButton_new_record_Click">Enter&nbsp;brand&nbsp;new&nbsp;record</ASP:LinkButton>
            </small>
          </td>
        </tr>
      </table>
      <table>
        <tr>
          <td><asp:Panel ID="Panel_match_numbers" runat="server" Visible="False"><small>(<asp:Literal ID="Literal_match_index" runat="server"></asp:Literal>/<asp:Literal ID="Literal_num_matches" runat="server"></asp:Literal>)</small></asp:Panel></td>
          <td>
            <asp:LinkButton id="LinkButton_go_to_match_first" runat="server" text="<IMG src=&quot;~/protected/image/first_track_blue16_h.png&quot; alt=&quot;First match&quot; border=&quot;0&quot; height=&quot;16&quot; width=&quot;16&quot; />" causesvalidation="False" visible="False" onclick="LinkButton_go_to_match_first_Click"></asp:LinkButton><asp:LinkButton id="LinkButton_go_to_match_prior" runat="server" text="<IMG src=&quot;~/protected/image/play_blue16_h-flipped.png&quot; alt=&quot;Prior match&quot; border=&quot;0&quot; height=&quot;16&quot; width=&quot;16&quot; />" causesvalidation="False" visible="False" onclick="LinkButton_go_to_match_prior_Click"></asp:LinkButton><asp:LinkButton id="LinkButton_go_to_match_next" runat="server" text="<IMG src=&quot;~/protected/image/play_blue16_h.png&quot; alt=&quot;Next match&quot; border=&quot;0&quot; height=&quot;16&quot; width=&quot;16&quot; />" causesvalidation="False" visible="False" onclick="LinkButton_go_to_match_next_Click"></asp:LinkButton><asp:LinkButton id="LinkButton_go_to_match_last" runat="server" text="<IMG src=&quot;~/protected/image/last_track_blue16_h.png&quot; alt=&quot;Last match&quot; border=&quot;0&quot; height=&quot;16&quot; width=&quot;16&quot; />" causesvalidation="False" visible="False" onclick="LinkButton_go_to_match_last_Click"></asp:LinkButton>
          </td>
          <td>
            <div style="width:0px;white-space:nowrap;"><ASP:DropDownList id="DropDownList_id" runat="server" visible="False" autopostback="True" onselectedindexchanged="DropDownList_id_SelectedIndexChanged"></ASP:DropDownList></div>
          </td>
        </tr>
      </table>
    </font>
    </td>
    <td nowrap="nowrap" valign="top">
      <ASP:RequiredFieldValidator id="RequiredFieldValidator_id" runat="server" errormessage="Please enter id." font-bold="True" controltovalidate="TextBox_id">!ERR!</ASP:RequiredFieldValidator>
    </td>
  </tr>
  <tr runat="server" id="TableRow_service" visible="false">
    <td><font class="">Service&nbsp;id:</font></td>
    <td>
      <font class="">
        <ASP:TextBox id="TextBox_service_id" runat="server"  cssclass="" enabled="False"></ASP:TextBox>
      </font>
    </td>
    <td nowrap="nowrap">
      <ASP:RequiredFieldValidator id="RequiredFieldValidator_service_id" runat="server" errormessage="Please enter Service&nbsp;id." font-bold="True" controltovalidate="TextBox_service_id">!ERR!</ASP:RequiredFieldValidator>
      <ASP:RegularExpressionValidator id="RegularExpressionValidator_service_id" runat="server" errormessage="Please enter a valid Service&nbsp;id." font-bold="True" controltovalidate="TextBox_service_id" validationexpression="\d*">!ERR!</ASP:RegularExpressionValidator>
    </td>
  </tr>
  <tr>
    <td><font class="">Name:</font></td>
    <td>
      <font class="">
        <ASP:TextBox id="TextBox_name" runat="server" columns="63" maxlength="63" cssclass="" enabled="False"></ASP:TextBox>
      </font>
    </td>
    <td nowrap="nowrap">
      <ASP:RequiredFieldValidator id="RequiredFieldValidator_name" runat="server" errormessage="Please enter Name." font-bold="True" controltovalidate="TextBox_name">!ERR!</ASP:RequiredFieldValidator>
      <asp:CustomValidator ID="CustomValidator_uniqueness" runat="server" Display="Dynamic" ErrorMessage="A vehicle with this name already exists in the system for this service." Font-Bold="True" onservervalidate="CustomValidator_uniqueness_ServerValidate">!ERR!</asp:CustomValidator>
    </td>
  </tr>
  <tr>
    <td><font class="">Kind:</font></td>
    <td>
      <font class="">
        <ASP:DropDownList id="DropDownList_kind" runat="server"  cssclass="" enabled="False"></ASP:DropDownList>
      </font>
    </td>
    <td nowrap="nowrap">
      <ASP:RequiredFieldValidator id="RequiredFieldValidator_kind_id" runat="server" errormessage="Please selected a vehicle Kind." font-bold="True" controltovalidate="DropDownList_kind">!ERR!</ASP:RequiredFieldValidator>
    </td>
  </tr>
  <tr>
    <td><font class="">Patient care level:</font></td>
    <td>
      <font class="">
        <ASP:DropDownList id="DropDownList_patient_care_level" runat="server"  cssclass="" enabled="False"></ASP:DropDownList>
      </font>
    </td>
    <td nowrap="nowrap">
      <ASP:RequiredFieldValidator id="RequiredFieldValidator_patient_care_level" runat="server" errormessage="Please selected a Patient care level." font-bold="True" controltovalidate="DropDownList_patient_care_level">!ERR!</ASP:RequiredFieldValidator>
    </td>
  </tr>
  <tr>
    <td><font class="">Tow capacity:</font></td>
    <td>
      <font class="">
        <ASP:DropDownList id="DropDownList_tow_capacity" runat="server"  cssclass="" enabled="False"></ASP:DropDownList>
      </font>
    </td>
    <td nowrap="nowrap">
      <ASP:RequiredFieldValidator id="RequiredFieldValidator_tow_capacity" runat="server" errormessage="Please selected a Tow capacity." font-bold="True" controltovalidate="DropDownList_tow_capacity">!ERR!</ASP:RequiredFieldValidator>
    </td>
  </tr>
  <tr>
    <td><font class="">Fuel:</font></td>
    <td>
      <font class="">
        <ASP:DropDownList id="DropDownList_fuel" runat="server"  cssclass="" enabled="False"></ASP:DropDownList>
      </font>
    </td>
    <td nowrap="nowrap">
      <ASP:RequiredFieldValidator id="RequiredFieldValidator_fuel_id" runat="server" errormessage="Please select a Fuel." font-bold="True" controltovalidate="DropDownList_fuel">!ERR!</ASP:RequiredFieldValidator>
    </td>
  </tr>
  <tr>
    <td><font class="">License&nbsp;plate:</font></td>
    <td>
      <font class="">
        <ASP:TextBox id="TextBox_license_plate" runat="server" columns="15" maxlength="15" cssclass="" enabled="False"></ASP:TextBox>
      </font>
    </td>
    <td nowrap="nowrap">
      <asp:CustomValidator ID="CustomValidator_license_plate" runat="server" ErrorMessage="The specified license plate already belongs to " Font-Bold="True" onservervalidate="CustomValidator_license_plate_ServerValidate">!ERR!</asp:CustomValidator>
    </td>
  </tr>
  <tr>
    <td><font class="">PA DOH decal #:</font></td>
    <td>
      <font class="">
        <ASP:TextBox id="TextBox_pa_doh_decal_num" runat="server" columns="7" maxlength="7" cssclass="" enabled="False"></ASP:TextBox>
      </font>
    </td>
    <td nowrap="nowrap">
      <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox_pa_doh_decal_num" Display="Dynamic" ErrorMessage="Please enter a valid 7-digit PA DOH decal number." Font-Bold="True" ValidationExpression="\d{7}">!ERR!</asp:RegularExpressionValidator>
      <asp:CustomValidator ID="CustomValidator_pa_doh_decal_num" runat="server" ErrorMessage="The specified PA DOH decal number already belongs to " Font-Bold="True" onservervalidate="CustomValidator_pa_doh_decal_num_ServerValidate">!ERR!</asp:CustomValidator>
    </td>
  </tr>
  <tr>
    <td><font class="">Be&nbsp;four&nbsp;or&nbsp;all&nbsp;wheel&nbsp;drive:</font></td>
    <td>
      <font class="">
        <ASP:CheckBox id="CheckBox_be_four_or_all_wheel_drive" runat="server"  cssclass="" enabled="False"></ASP:CheckBox>
      </font>
    </td>
    <td nowrap="nowrap">
    </td>
  </tr>
      </table>
    </td>
  </tr>
</table>
<ASP:Button id="Button_submit" text="Submit" runat="server" enabled="False" onclick="Button_submit_Click"></ASP:Button>&nbsp;&nbsp;<ASP:Button id="Button_delete" text="Delete" runat="server" enabled="False" onclick="Button_delete_Click"></ASP:Button>

