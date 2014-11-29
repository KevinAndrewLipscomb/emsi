<%@ Control Language="c#" AutoEventWireup="True" Codebehind="UserControl_discarded_rosters.ascx.cs" Inherits="UserControl_discarded_rosters.TWebUserControl_discarded_rosters"%>
<!-- Derived from KiAspdotnetFramework/usercontrol/app/UserControl~template~datagrid~sortable.ascx-template -->
<asp:UpdatePanel id="UpdatePanel_control" runat="server" updatemode="Conditional">
  <ContentTemplate>
    <table bordercolor="#dcdcdc" cellspacing="0" cellpadding="0" border="1">
      <tr>
        <td>
          <table cellspacing="0" cellpadding="10" border="0">
            <tr>
              <td bgcolor="#dcdcdc" style="height: 50px">
                <table cellspacing="0" cellpadding="0" border="0">
                  <tr>
                    <td align="right">
                      <asp:Button ID="Button_default_sort" runat="server" Text="Default sort" OnClick="Button_default_sort_Click" />
                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                      <strong>Filter:</strong>
                      <asp:DropDownList ID="DropDownList_filter" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList_filter_SelectedIndexChanged">
                        <asp:ListItem Value="CurrentYear">Current year</asp:ListItem>
                        <asp:ListItem Value="">All</asp:ListItem>
                      </asp:DropDownList>
                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                      <asp:Literal ID="Literal_num_coned_offerings" runat="server"></asp:Literal> classes discarded</td>
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
                    <asp:BoundColumn DataField="sponsor" HeaderText="Sponsor" ReadOnly="True" SortExpression="sponsor%,course_title,end desc">
                      <ItemStyle VerticalAlign="Top" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="course_title" HeaderText="Course title" ReadOnly="True" SortExpression="course_title%,end desc">
                      <ItemStyle VerticalAlign="Top" />
                    </asp:BoundColumn>
                    <asp:BoundColumn datafield="location" headertext="Location" sortexpression="location%,end desc" ReadOnly="True">
                      <ItemStyle VerticalAlign="Top" />
                    </asp:BoundColumn>
                    <asp:BoundColumn datafield="start" headertext="Start" sortexpression="start%" ReadOnly="True">
                      <ItemStyle VerticalAlign="Top" Wrap="False" />
                    </asp:BoundColumn>
                    <asp:BoundColumn datafield="end" headertext="End" sortexpression="end%" ReadOnly="True">
                      <ItemStyle VerticalAlign="Top" Wrap="False" />
                    </asp:BoundColumn>
                    <asp:BoundColumn datafield="disposition" headertext="Disposition" sortexpression="disposition%,course_title,end desc" ReadOnly="True">
                      <ItemStyle VerticalAlign="Top" />
                    </asp:BoundColumn>
                    <asp:ButtonColumn CommandName="Undiscard" Text="UNdiscard">
                      <ItemStyle VerticalAlign="Top" />
                    </asp:ButtonColumn>
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
