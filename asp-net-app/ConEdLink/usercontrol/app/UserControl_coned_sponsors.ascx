<%@ Control Language="c#" AutoEventWireup="True" Codebehind="UserControl_coned_sponsors.ascx.cs" Inherits="UserControl_coned_sponsors.TWebUserControl_coned_sponsors"%>
<!-- Derived from KiAspdotnetFramework/usercontrol/app/UserControl~template~datagrid~sortable.ascx-template -->
<asp:UpdatePanel id="UpdatePanel_control" runat="server" updatemode="Conditional">
  <ContentTemplate>
    <p><strong><asp:Label id="Label_num_coned_sponsors" runat="server"></asp:Label>&nbsp;sponsors</strong></p>
    <p><small>If one of your sponsors seems to be missing from this list, make sure their EMSRS record includes an email address.</small></p>
    <asp:DataGrid id="DataGrid_control" runat="server" allowsorting="True" autogeneratecolumns="False" cellpadding="10" gridlines="Horizontal">
      <Columns>
        <asp:ButtonColumn commandname="select" text="&lt;IMG src=&quot;~/protected/image/open_document16_h.png&quot; alt=&quot;Profile (tabbed)&quot; border=&quot;0&quot; height=&quot;16&quot; width=&quot;16&quot; /&gt;"></asp:ButtonColumn>
        <asp:BoundColumn datafield="id" visible="False">
          <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" VerticalAlign="Top" />
        </asp:BoundColumn>
        <asp:TemplateColumn HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
          <HeaderTemplate>
            <asp:CheckBox ID="CheckBox_force_all" runat="server" AutoPostBack="True" oncheckedchanged="CheckBox_force_all_CheckedChanged" style="outline:2px solid SlateGray" ToolTip="Select/Unselect all for QuickMessage" Checked="True" />
          </HeaderTemplate>
          <ItemTemplate>
            <asp:CheckBox ID="CheckBox_selected" runat="server" Checked="True" AutoPostBack="True" oncheckedchanged="CheckBox_selected_CheckedChanged" ToolTip="Select/Unselect for QuickMessage" />
          </ItemTemplate>
          <HeaderStyle HorizontalAlign="Center" />
          <ItemStyle HorizontalAlign="Center" />
        </asp:TemplateColumn>
        <asp:BoundColumn datafield="sponsor_number" headertext="#" sortexpression="sponsor_number%">
          <HeaderStyle horizontalalign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></HeaderStyle>
          <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" VerticalAlign="Top"></ItemStyle>
          <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" VerticalAlign="Top" Wrap="False" />
        </asp:BoundColumn>
        <asp:BoundColumn datafield="name" headertext="Name" sortexpression="name%"></asp:BoundColumn>
        <asp:BoundColumn datafield="email_address" HeaderText="Email address" Visible="false"></asp:BoundColumn>
        <asp:ButtonColumn commandname="imitate" text="&lt;IMG src=&quot;~/protected/image/mask-16-16.png&quot; alt=&quot;Imitate&quot; border=&quot;0&quot; height=&quot;16&quot; width=&quot;16&quot; /&gt;">
          <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" VerticalAlign="Top" />
        </asp:ButtonColumn>
      </Columns>
      <HeaderStyle backcolor="WhiteSmoke"></HeaderStyle>
    </asp:DataGrid>
    <br/>
    <table id="Table_quick_message" runat="server" bordercolor="#dcdcdc" cellspacing="0" cellpadding="0" border="1">
      <tr>
        <td>
          <table cellspacing="0" cellpadding="10" width="100%" border="0">
            <tr><td bgcolor="#f5f5f5"><a id="QuickMessage"><strong>QuickMessage</strong></a></td></tr>
            <tr>
              <td>
                <table cellspacing="0" cellpadding="10" width="100%" border="0">
                  <tr>
                    <td>Send email to:</td>
                    <td>Sponsors selected (<asp:CheckBox ID="CheckBox_item_sample" runat="server" Checked="True" Enabled="false" />) above.</td>
                    <td></td>
                  </tr>
                  <tr>
                    <td>Bcc:</td>
                    <td><ASP:Label id="Label_author_email_address" runat="server"></ASP:Label></td>
                    <td></td>
                  </tr>
                  <tr>
                    <td>Subject:</td>
                    <td><ASP:TextBox id="TextBox_quick_message_subject" runat="server" maxlength="255" columns="72"></ASP:TextBox></td>
                    <td></td>
                  </tr>
                  <tr>
                    <td valign="top">Body:</td>
                    <td><ASP:TextBox id="TextBox_quick_message_body" runat="server" columns="72" rows="18" textmode="MultiLine"></ASP:TextBox></td>
                    <td nowrap="true" valign="top"><ASP:RequiredFieldValidator id="RequiredFieldValidator_quick_message_body" runat="server" errormessage="Please enter a message body." font-bold="True" controltovalidate="TextBox_quick_message_body" validationgroup="quick_message">!ERR!</ASP:RequiredFieldValidator></td>
                  </tr>
                  <tr>
                    <td></td>
                    <td><ASP:Button id="Button_send" runat="server" text="Send" validationgroup="quick_message" onclick="Button_send_Click"></ASP:Button></td>
                    <td></td>
                  </tr>
                  <tr><td valign="top"><small><font color="#c0c0c0">Resolves to:</small></font></td><td valign="top"><small><ASP:Label id="Label_distribution_list" runat="server" forecolor="Silver"></ASP:Label></small></td>
                    <td></td>
                  </tr>
                </table>
              </td>
            </tr>
          </table>
        </td>
      </tr>
    </table>
  </ContentTemplate>
</asp:UpdatePanel>
