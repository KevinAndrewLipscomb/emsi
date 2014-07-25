<%@ Control Language="c#" AutoEventWireup="True" Codebehind="UserControl_analysis_of_sponsor_by_month.ascx.cs" Inherits="UserControl_analysis_of_sponsor_by_month.TWebUserControl_analysis_of_sponsor_by_month"%>
<!-- Derived from KiAspdotnetFramework/usercontrol/app/UserControl~template~datagrid~sortable.ascx-template -->
<asp:UpdatePanel id="UpdatePanel_control" runat="server" updatemode="Conditional">
  <ContentTemplate>
    <table bordercolor="#dcdcdc" cellspacing="0" cellpadding="0" border="1">
      <tr>
        <td>
          <table cellspacing="0" cellpadding="10" border="0">
            <tr>
              <td bgcolor="#dcdcdc">
                <table cellspacing="0" cellpadding="5" border="0">
                  <tr>
                    <td><strong>Calendar&nbsp;year:</strong><asp:DropDownList id="DropDownList_year" runat="server" autopostback="True" onselectedindexchanged="DropDownList_year_SelectedIndexChanged"></asp:DropDownList></td>
                    <td><strong>Level:</strong><asp:DropDownList ID="DropDownList_practitioner_level" runat="server" autopostback="True" onselectedindexchanged="DropDownList_practitioner_level_SelectedIndexChanged"></asp:DropDownList></td>
                  </tr>
                </table>
              </td>
            </tr>
            <tr id="TableRow_none" runat="server"><td><em>--&nbsp;NONE&nbsp;--</em></td></tr>
            <tr>
              <td>
                <asp:DataGrid id="DataGrid_control" runat="server" gridlines="Horizontal" cellpadding="10" autogeneratecolumns="False" allowsorting="True">
                  <Columns>
                    <asp:BoundColumn datafield="month" headertext="Month" sortexpression="month_num%">
                      <ItemStyle HorizontalAlign="Right" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn datafield="num_classes" headertext="# classes" sortexpression="num_classes%, month_num">
                      <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundColumn>
                    <asp:BoundColumn datafield="num_sittings" headertext="# sittings" sortexpression="num_sittings%, month_num">
                      <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundColumn>
                    <asp:BoundColumn datafield="avg_num_students_per_class" headertext="Avg # students / class" sortexpression="CAST(avg_num_students_per_class AS DECIMAL(10,1))%, month_num">
                      <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundColumn>
                    <asp:BoundColumn datafield="num_distinct_practitioners" headertext="# distinct practitioners" sortexpression="num_distinct_practitioners%, month_num">
                      <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundColumn>
                  </Columns>
                  <HeaderStyle backcolor="WhiteSmoke"></HeaderStyle>
                </asp:DataGrid>
              </td>
            </tr>
          </table>
        </td>
      </tr>
    </table>
  </ContentTemplate>
</asp:UpdatePanel>
