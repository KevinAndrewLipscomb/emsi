<%@ Control Language="c#" AutoEventWireup="True" Codebehind="UserControl_strike_team_deployment.ascx.cs" Inherits="UserControl_strike_team_deployment.TWebUserControl_strike_team_deployment"%>
<!-- Derived from KiAspdotnetFramework/usercontrol/app/UserControl~template~kicrudhelped~item.ascx-template -->
<%@ Register TagPrefix="uc1" TagName="UserControl_drop_down_date" Src="~/usercontrol/ki/UserControl_drop_down_date.ascx" %>
<%@ Register src="UserControl_strike_team_deployment_binder.ascx" tagname="UserControl_strike_team_deployment_binder" tagprefix="uc2" %>
<asp:UpdatePanel ID="UpdatePanel_control" runat="server">
  <ContentTemplate>
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
  <tr runat="server" visible="false">
    <td><font class="">Creation&nbsp;date:</font></td>
    <td>
      <font class="">
        <uc1:UserControl_drop_down_date id="UserControl_drop_down_date_creation_date" runat="server"  cssclass=""></uc1:UserControl_drop_down_date>
      </font>
    </td>
    <td nowrap="nowrap">
    </td>
  </tr>
  <tr runat="server">
    <td><font class="">Region:</font></td>
    <td>
      <font class="">
        <asp:DropDownList ID="DropDownList_region" runat="server"></asp:DropDownList>
      </font>
    </td>
    <td nowrap="nowrap">
      <ASP:RequiredFieldValidator id="RequiredFieldValidator_region" runat="server" errormessage="Please select a Region." font-bold="True" controltovalidate="DropDownList_region">!ERR!</ASP:RequiredFieldValidator>
    </td>
  </tr>
  <tr>
    <td><font class="">Name:</font></td>
    <td>
      <font class="">
        <ASP:TextBox id="TextBox_name" runat="server" columns="72" maxlength="127" cssclass="" enabled="False"></ASP:TextBox>
      </font>
    </td>
    <td nowrap="nowrap">
      <ASP:RequiredFieldValidator id="RequiredFieldValidator_name" runat="server" errormessage="Please enter Name." font-bold="True" controltovalidate="TextBox_name">!ERR!</ASP:RequiredFieldValidator>
    </td>
  </tr>
  <tr>
    <td valign="top"><font class="">Personnel participation policy:</font></td>
    <td valign="top">
      <font class="">
        <asp:RadioButtonList ID="RadioButtonList_member_policy" runat="server" cssclass="" enabled="False">
          <asp:ListItem Value="1" Selected="True">This is an ACTUAL DEPLOYMENT, not a drill, with STRICT enforcement of credential requirements.</asp:ListItem>
          <asp:ListItem Value="2">This is an ACTUAL DEPLOYMENT, not a drill, with RELAXED enforcement of credential requirements.</asp:ListItem>
          <asp:ListItem Value="3">This deployment is a DRILL.  Only cellphone-related credential requirements are enforced.</asp:ListItem>
        </asp:RadioButtonList>
      </font>
    </td>
    <td nowrap="nowrap" valign="top">
      <asp:RequiredFieldValidator ID="RequiredFieldValidator_member_policy" runat="server" ControlToValidate="RadioButtonList_member_policy" ErrorMessage="Please selected a Personnel participation policy." Font-Bold="True">!ERR!</asp:RequiredFieldValidator>
    </td>
  </tr>
  <tr id="TableRow_submit_delete_announce" runat="server" visible="false">
    <td>&nbsp;</td>
    <td>
      <table cellpadding="10" cellspacing="0">
        <tr>
          <td><ASP:Button id="Button_submit" text="Submit" runat="server" enabled="False" onclick="Button_submit_Click" Visible="False"></ASP:Button></td>
          <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
          <td><ASP:Button id="Button_delete" text="Delete" runat="server" enabled="False" onclick="Button_delete_Click" Visible="False"></ASP:Button></td>
          <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
          <td><asp:LinkButton ID="LinkButton_announce" runat="server" CausesValidation="False" onclick="LinkButton_announce_Click" Visible="False">Mobilization announcement...</asp:LinkButton></td>
        </tr>
      </table>
    </td>
    <td>&nbsp;</td>
  </tr>
      </table>
    </td>
  </tr>
</table>
<asp:Panel ID="Panel_active_deployment_detail" runat="server" Visible="false">
  <table id="Table_initial_actions" runat="server" cellpadding="10" cellspacing="0" visible="false">
    <tr>
      <td bgcolor="Khaki">
        The following initial steps are recommended when a deployment is first created:
        <ul>
          <li>Send a <i>mobilization announcement</i> using the above link.</li>
          <li>Define <i>PRELIM</i> and <i>CONVOY</i> operational period templates (for the Service Strike Team Managers to populate) using the tab below.</li>
        </ul>
      </td>
    </tr>
  </table>
  <br />
  <uc2:UserControl_strike_team_deployment_binder ID="UserControl_strike_team_deployment_binder_control" runat="server" />
</asp:Panel>
  </ContentTemplate>
</asp:UpdatePanel>
