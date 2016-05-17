<%@ Control Language="c#" AutoEventWireup="True" Codebehind="UserControl_analysis_of_region_by_year.ascx.cs" Inherits="UserControl_analysis_of_region_by_year.TWebUserControl_analysis_of_region_by_year"%>
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
                    <td><strong>Level:</strong><asp:DropDownList ID="DropDownList_practitioner_level" runat="server" autopostback="True" onselectedindexchanged="DropDownList_practitioner_level_SelectedIndexChanged"></asp:DropDownList></td>
                  </tr>
                </table>
              </td>
            </tr>
            <tr id="TableRow_recent" runat="server">
              <td>
                <p>Computed on-the-fly from recent volatile data:</p>
                <blockquote>
                  <table cellpadding="10" cellspacing="0" width="100%" style="border: 1px solid black;">
                    <tr bgcolor="WhiteSmoke">
                      <td>Fiscal year ending</td>
                      <td># classes</td>
                      <td># sittings</td>
                      <td>Avg # students / class</td>
                      <td># distinct practitioners</td>
                    </tr>
                    <tr>
                      <td align="right" style="border-top: 1px solid black"><strong><asp:Literal ID="Literal_current_fiscal_year_ending" runat="server"></asp:Literal></strong></td>
                      <td align="right" style="border-top: 1px solid black"><asp:Literal ID="Literal_current_num_classes" runat="server"></asp:Literal></td>
                      <td align="right" style="border-top: 1px solid black"><asp:Literal ID="Literal_current_num_sittings" runat="server"></asp:Literal></td>
                      <td align="right" style="border-top: 1px solid black"><asp:Literal ID="Literal_current_avg_num_students_per_class" runat="server"></asp:Literal></td>
                      <td align="right" style="border-top: 1px solid black"><asp:Literal ID="Literal_current_num_distinct_practitioners" runat="server"></asp:Literal></td>
                    </tr>
                    <tr id="TableRow_prior_unreduced" runat="server">
                      <td align="right" style="border-top: 1px solid black"><strong><asp:Literal ID="Literal_prior_unreduced_fiscal_year_ending" runat="server"></asp:Literal></strong></td>
                      <td align="right" style="border-top: 1px solid black"><asp:Literal ID="Literal_prior_unreduced_num_classes" runat="server"></asp:Literal></td>
                      <td align="right" style="border-top: 1px solid black"><asp:Literal ID="Literal_prior_unreduced_num_sittings" runat="server"></asp:Literal></td>
                      <td align="right" style="border-top: 1px solid black"><asp:Literal ID="Literal_prior_unreduced_avg_num_students_per_class" runat="server"></asp:Literal></td>
                      <td align="right" style="border-top: 1px solid black"><asp:Literal ID="Literal_prior_unreduced_num_distinct_practitioners" runat="server"></asp:Literal></td>
                    </tr>
                  </table>
                </blockquote>
              </td>
            </tr>
            <tr>
              <td>
                <p>Reduced from historical settled data:</p>
                <blockquote>
                  <asp:DataGrid id="DataGrid_control" runat="server" gridlines="Horizontal" cellpadding="10" autogeneratecolumns="False" allowsorting="True">
                    <Columns>
                      <asp:BoundColumn datafield="fiscal_year_ending" headertext="Fiscal year ending" sortexpression="fiscal_year_ending%">
                        <ItemStyle HorizontalAlign="Right" Font-Bold="true" />
                      </asp:BoundColumn>
                      <asp:BoundColumn datafield="num_classes" headertext="# classes" sortexpression="num_classes%, fiscal_year_ending">
                        <ItemStyle HorizontalAlign="Right" />
                      </asp:BoundColumn>
                      <asp:BoundColumn datafield="num_sittings" headertext="# sittings" sortexpression="num_sittings%, fiscal_year_ending">
                        <ItemStyle HorizontalAlign="Right" />
                      </asp:BoundColumn>
                      <asp:BoundColumn datafield="avg_num_students_per_class" headertext="Avg # students / class" sortexpression="CAST(avg_num_students_per_class AS DECIMAL(10,1))%, fiscal_year_ending">
                        <ItemStyle HorizontalAlign="Right" />
                      </asp:BoundColumn>
                      <asp:BoundColumn datafield="num_distinct_practitioners" headertext="# distinct practitioners" sortexpression="num_distinct_practitioners%, fiscal_year_ending">
                        <ItemStyle HorizontalAlign="Right" />
                      </asp:BoundColumn>
                    </Columns>
                    <HeaderStyle backcolor="WhiteSmoke"></HeaderStyle>
                  </asp:DataGrid>
                </blockquote>
              </td>
            </tr>
          </table>
        </td>
      </tr>
    </table>
  </ContentTemplate>
</asp:UpdatePanel>
