<%@ Control Language="c#" AutoEventWireup="True" CodeBehind="UserControl_establish_membership.ascx.cs" Inherits="UserControl_establish_membership.TWebUserControl_establish_membership" %>
<%@ Register src="../ki/UserControl_drop_down_date.ascx" tagname="UserControl_drop_down_date" tagprefix="uc1" %>
<table bordercolor="#dcdcdc" cellspacing="0" cellpadding="0" border="1">
  <tr>
    <td>
      <table cellspacing="0" cellpadding="10" width="100%" border="0">
        <tr bgcolor="#f5f5f5">
          <td><strong>Establish membership</strong></td>
        </tr>
        <tr>
          <td>
            <p>Your <asp:Label ID="Label_application_name_1" runat="server"></asp:Label>&nbsp;username is not currently linked to a&nbsp;Pennsylvania EMS practitioner record.</p>
            <p>Are you already a Pennsylvania EMS&nbsp;practitioner?</p>
            <p>
              <table cellspacing="0" cellpadding="10" border="0">
                <tr>
                  <td align="center" valign="top"><strong>NO</strong></td>
                  <td valign="top" nowrap="nowrap">-&gt;</td>
                  <td valign="top">
                    Use the process dictated by the <asp:Label ID="Label_sponsor_4" runat="server"></asp:Label> to become a practitioner.
                    </td>
                </tr>
                <tr>
                  <td align="center" valign="top"><strong>YES</strong></td>
                  <td valign="top" nowrap="nowrap">-&gt;</td>
                  <td valign="top">
                    <asp:UpdatePanel ID="UpdatePanel_control" runat="server">
                      <ContentTemplate>
                        Match yourself to a practitioner record by entering <asp:Label ID="Label_shared_secret_description_1" runat="server"></asp:Label> here:
                        <blockquote>
                          <table>
                            <tr>
                              <td align="right">Regional council:</td>
                              <td><asp:DropDownList ID="DropDownList_regional_council" runat="server"></asp:DropDownList></td>
                            </tr>
                            <tr>
                              <td align="right">Birth date:</td>
                              <td><uc1:UserControl_drop_down_date ID="UserControl_drop_down_date_birth" runat="server" /></td>
                            </tr>
                            <tr>
                              <td align="right">Certification #:</td>
                              <td><asp:TextBox ID="TextBox_certification_number" runat="server" Columns="7" MaxLength="7"></asp:TextBox></td>
                            </tr>
                            <tr>
                              <td align="right">Level:</td>
                              <td><asp:DropDownList ID="DropDownList_level" runat="server" AutoPostBack="True"></asp:DropDownList></td>
                            </tr>
                            <tr>
                              <td></td>
                              <td>
                                <asp:Button ID="Button_submit" runat="server" Text="Submit" Font-Bold="True" OnClick="Button_submit_Click"></asp:Button>
                                <asp:CustomValidator ID="CustomValidator_shared_secret" runat="server" Display="Dynamic" ErrorMessage="Sorry, because of privileges attached to the specified membership record, Application Administrator intervention is required to complete this match.  The Application Administrator has been notified and will be in touch with you." Font-Bold="True" OnServerValidate="CustomValidator_shared_secret_ServerValidate">!ERR!</asp:CustomValidator>
                              </td>
                            </tr>
                          </table>
                        </blockquote>
                        <p>If you have trouble with this feature, <asp:LinkButton ID="LinkButton_trouble_handler" runat="server" CausesValidation="False" OnClick="LinkButton_trouble_handler_Click">click here</asp:LinkButton>.</p>
                        <p>
                          <table id="Table_proceed" runat="server" visible="False" bordercolor="#0000ff" cellspacing="0" cellpadding="10" border="3">
                            <tr><td><asp:LinkButton ID="LinkButton_proceed" runat="server" Font-Bold="True" OnClick="LinkButton_proceed_Click">CLICK HERE TO CONTINUE</asp:LinkButton></td></tr>
                          </table>
                        </p>
                      </ContentTemplate>
                    </asp:UpdatePanel>
                  </td>
                </tr>
              </table>
            </p>
          </td>
        </tr>
      </table>
    </td>
  </tr>
</table>
