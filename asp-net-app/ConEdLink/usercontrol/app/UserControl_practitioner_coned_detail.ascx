<%@ Control Language="c#" AutoEventWireup="True" Codebehind="UserControl_practitioner_coned_detail.ascx.cs" Inherits="UserControl_practitioner_coned_detail.TWebUserControl_practitioner_coned_detail"%>
<!-- Derived from KiAspdotnetFramework/usercontrol/app/UserControl~template~datagrid~sortable.ascx-template -->
<asp:UpdatePanel id="UpdatePanel_control" runat="server" updatemode="Conditional">
  <ContentTemplate>
    <table bordercolor="#dcdcdc" cellspacing="0" cellpadding="0" border="1">
      <tr>
        <td>
          <table cellspacing="0" cellpadding="10" border="0">
            <tr>
              <td bgcolor="#dcdcdc">
                <table cellspacing="0" cellpadding="0" border="0">
                  <tr>
                    <td>
                      <strong>Filter:&nbsp;<asp:DropDownList id="DropDownList_filter" runat="server" autopostback="True"></asp:DropDownList></strong>
                    </td>
                    <td align="right">
                      <asp:Literal ID="Literal_num_classes" runat="server"></asp:Literal> classes
                    </td>
                  </tr>
                </table>
              </td>
            </tr>
            <tr id="TableRow_none" runat="server"><td><em>--&nbsp;NONE&nbsp;--</em></td></tr>
            <tr>
              <td>
                <asp:DataGrid id="DataGrid_control" runat="server" gridlines="Horizontal" cellpadding="10" autogeneratecolumns="False" allowsorting="True">
                  <Columns>
                    <asp:ButtonColumn text="&lt;IMG src=&quot;~/protected/image/open_document16_h.png&quot; alt=&quot;Detail&quot; border=&quot;0&quot; height=&quot;16&quot; width=&quot;16&quot; /&gt;" commandname="Select"></asp:ButtonColumn>
                    <asp:BoundColumn datafield="coned_offering_id" Visible="false"></asp:BoundColumn>
                    <asp:TemplateColumn HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                      <HeaderTemplate>
                        <small><asp:CheckBox ID="CheckBox_force_all" runat="server" AutoPostBack="True" oncheckedchanged="CheckBox_force_all_CheckedChanged" style="outline:2px solid SlateGray" ToolTip="Select/Unselect all" />
                      </HeaderTemplate>
                      <ItemTemplate>
                        <asp:CheckBox ID="CheckBox_selected" runat="server" AutoPostBack="True" oncheckedchanged="CheckBox_selected_CheckedChanged" />
                      </ItemTemplate>
                      <HeaderStyle HorizontalAlign="Center" />
                      <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateColumn>
                    <asp:BoundColumn datafield="class_number" headertext="Class #" sortexpression="class_number%,start" ReadOnly="True"></asp:BoundColumn>
                    <asp:BoundColumn DataField="course_title" HeaderText="Course title" ReadOnly="True" SortExpression="course_title%,start"></asp:BoundColumn>
                    <asp:BoundColumn DataField="location" HeaderText="Location" ReadOnly="True" SortExpression="location%,start"></asp:BoundColumn>
                    <asp:BoundColumn DataField="region" HeaderText="Region" ReadOnly="True" SortExpression="region%,start"></asp:BoundColumn>
                    <asp:BoundColumn DataField="start" HeaderText="Start" ReadOnly="True" SortExpression="start%"></asp:BoundColumn>
                    <asp:BoundColumn DataField="end" HeaderText="End" ReadOnly="True" SortExpression="end%,start"></asp:BoundColumn>
                    <asp:BoundColumn DataField="sponsor" HeaderText="Sponsor" ReadOnly="True" SortExpression="sponsor%,start"></asp:BoundColumn>
                    <asp:BoundColumn DataField="med_trauma_hours" HeaderText="M/T" ReadOnly="True" SortExpression="med_trauma_hours%,other_hours,start"></asp:BoundColumn>
                    <asp:BoundColumn DataField="other_hours" HeaderText="Oth" ReadOnly="True" SortExpression="other_hours%,med_trauma_hours,start"></asp:BoundColumn>
                    <asp:BoundColumn DataField="instructor_hours" HeaderText="Inst" ReadOnly="True" SortExpression="instructor_hours%,start"></asp:BoundColumn>
                    <asp:BoundColumn datafield="roster_id" Visible="false"></asp:BoundColumn>
                  </Columns>
                  <HeaderStyle backcolor="WhiteSmoke"></HeaderStyle>
                </asp:DataGrid>
              </td>
            </tr>
            <tr id="TableRow_email_view_print" runat="server" visible="false">
              <td>
                For selected (<asp:CheckBox ID="CheckBox_item_sample" runat="server" Checked="True" Enabled="false" />) classes...
                <ul>
                  <li><p><asp:LinkButton ID="LinkButton_email_completion_documentation" runat="server" Text="Email completion documentation" onclick="LinkButton_email_completion_documentation_Click"></asp:LinkButton></p></li>
                  <li><p><asp:HyperLink ID="HyperLink_print_completion_documentation" runat="server" Text="Print completion documentation" Target="_blank"></asp:HyperLink></p></li>
                </ul>
                <small>Use <asp:CheckBox ID="CheckBox_header_sample" runat="server" Checked="True" style="outline:2px solid SlateGray" Enabled="false" /> in header row to select or unselect all classes at once.</small>
              </td>
            </tr>
          </table>
        </td>
      </tr>
    </table>
  </ContentTemplate>
</asp:UpdatePanel>
