<%@ Control Language="c#" AutoEventWireup="True" Codebehind="UserControl_analysis_of_region_by_sponsor.ascx.cs" Inherits="UserControl_analysis_of_region_by_sponsor.TWebUserControl_analysis_of_region_by_sponsor"%>
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
                      <strong>Calendar&nbsp;year:&nbsp;<asp:DropDownList id="DropDownList_year" runat="server" autopostback="True" onselectedindexchanged="DropDownList_year_SelectedIndexChanged"></asp:DropDownList></strong>
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
                    <asp:BoundColumn datafield="sponsor_number" headertext="#" sortexpression="sponsor_number%">
                      <ItemStyle Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn datafield="sponsor_name" headertext="Name" sortexpression="sponsor_name%">
                      <ItemStyle Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn datafield="num_classes" headertext="# classes" sortexpression="num_classes%">
                      <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundColumn>
                    <asp:BoundColumn datafield="num_sittings" headertext="# sittings" sortexpression="num_sittings%">
                      <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundColumn>
                    <asp:BoundColumn datafield="avg_num_students_per_class" headertext="Avg # students / class" sortexpression="count(coned_offering_roster.id)/count(DISTINCT coned_offering.id)%">
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
