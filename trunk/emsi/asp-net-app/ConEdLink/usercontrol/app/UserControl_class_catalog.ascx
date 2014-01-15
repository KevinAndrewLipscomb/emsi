<%@ Control Language="c#" AutoEventWireup="True" Codebehind="UserControl_class_catalog.ascx.cs" Inherits="UserControl_class_catalog.TWebUserControl_class_catalog"%>
<!-- Derived from KiAspdotnetFramework/usercontrol/app/UserControl~template~datagrid~sortable.ascx-template -->
<asp:UpdatePanel id="UpdatePanel_control" runat="server" updatemode="Conditional">
  <ContentTemplate>
    <table bordercolor="#dcdcdc" cellspacing="0" cellpadding="0" border="1">
      <tr>
        <td>
          <table cellspacing="0" cellpadding="10" border="0">
            <tr>
              <td bgcolor="#dcdcdc">
                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                  <tr>
                    <td>
                      <strong>Range:&nbsp;<asp:DropDownList id="DropDownList_range" runat="server" autopostback="True" onselectedindexchanged="DropDownList_range_SelectedIndexChanged">
                        <asp:ListItem>Future</asp:ListItem>
                        <asp:ListItem Selected="True" Value="InProcess">In process</asp:ListItem>
                        <asp:ListItem Value="ClosedLastThreeYears">Closed last 3 years</asp:ListItem>
                        <asp:ListItem>All</asp:ListItem>
                      </asp:DropDownList></strong>
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td align="right">
                      <asp:Literal ID="Literal_num_coned_offerings" runat="server"></asp:Literal> classes
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
                    <asp:ButtonColumn text="&lt;IMG src=&quot;~/protected/image/open_document16_h.png&quot; alt=&quot;Detail&quot; border=&quot;0&quot; height=&quot;16&quot; width=&quot;16&quot; /&gt;" commandname="Select">
                      <ItemStyle VerticalAlign="Top" />
                    </asp:ButtonColumn>
                    <asp:BoundColumn datafield="id" ReadOnly="True" Visible="False"></asp:BoundColumn>
                    <asp:BoundColumn datafield="class_number" headertext="Class #" sortexpression="class_number%" ReadOnly="True">
                      <ItemStyle VerticalAlign="Top" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="course_title" HeaderText="Course title" ReadOnly="True" SortExpression="course_title%, start">
                      <ItemStyle VerticalAlign="Top" />
                    </asp:BoundColumn>
                    <asp:BoundColumn datafield="location" headertext="Location" sortexpression="location%, start" ReadOnly="True">
                      <ItemStyle VerticalAlign="Top" />
                    </asp:BoundColumn>
                    <asp:BoundColumn datafield="start" headertext="Start" sortexpression="start%" ReadOnly="True">
                      <ItemStyle VerticalAlign="Top" Wrap="False" />
                    </asp:BoundColumn>
                    <asp:BoundColumn datafield="end" headertext="End" sortexpression="end%" ReadOnly="True">
                      <ItemStyle VerticalAlign="Top" Wrap="False" />
                    </asp:BoundColumn>
                    <asp:ButtonColumn CommandName="ManageRoster" Text="Roster">
                      <ItemStyle VerticalAlign="Top" />
                    </asp:ButtonColumn>
                    <asp:BoundColumn DataField="num_attendees" HeaderText="Size" ReadOnly="True" SortExpression="num_attendees%, start">
                      <HeaderStyle HorizontalAlign="Center" />
                      <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                    </asp:BoundColumn>
                    <asp:BoundColumn datafield="be_in_process" headertext="In process" sortexpression="be_in_process%" ReadOnly="True" Visible="false">
                      <HeaderStyle HorizontalAlign="Center" />
                      <ItemStyle VerticalAlign="Top" HorizontalAlign="Center" />
                    </asp:BoundColumn>
                  </Columns>
                  <HeaderStyle backcolor="WhiteSmoke" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></HeaderStyle>
                </asp:DataGrid>
              </td>
            </tr>
          </table>
        </td>
      </tr>
    </table>
  </ContentTemplate>
</asp:UpdatePanel>
