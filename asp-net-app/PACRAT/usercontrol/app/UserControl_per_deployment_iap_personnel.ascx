<%@ Control Language="c#" AutoEventWireup="True" Codebehind="UserControl_per_deployment_iap_personnel.ascx.cs" Inherits="UserControl_per_deployment_iap_personnel.TWebUserControl_per_deployment_iap_personnel"%>
<!-- Derived from KiAspdotnetFramework/usercontrol/app/UserControl~template~datagrid~sortable.ascx-template -->
<table cellpadding="2" cellspacing="0" align="center">
  <tr>
    <td align="center">
      <table align="center" cellpadding="2" cellspacing="0">
        <tr><td align="center">&nbsp;</td></tr>
        <tr><td align="center"><small>Refer to this document as</small></td></tr>
        <tr><td align="center" nowrap="nowrap"><big><b><asp:Literal ID="Literal_application_name" runat="server"></asp:Literal> Mobilized Personnel Report # <asp:Literal ID="Literal_ref_num" runat="server"></asp:Literal></b></big></td></tr>
        <tr><td align="center"><small>on NIMS ICS Form 211</small></td></tr>
        <tr><td align="center">&nbsp;</td></tr>
      </table>
    </td>
  </tr>
  <tr>
    <td align="center">
      <table width="100%">
        <tr>
          <td valign="top">
            <table width="100%">
              <tr bgcolor="Gainsboro"><td align="center"><small><b>INCIDENT NAME</b></small></td></tr>
              <tr><td align="center"><tt><asp:Literal ID="Literal_deployment_name" runat="server"></asp:Literal></tt></td></tr>
            </table>
          </td>
        </tr>
        </table>
    </td>
  </tr>
  <tr>
    <td align="center">
      <table width="100%">
        <tr bgcolor="Gainsboro"><td align="center"><small><b>MOBILIZED PERSONNEL</b></small></td></tr>
        <tr id="TableRow_none" runat="server"><td align="center"><em>--&nbsp;NONE&nbsp;--</em></td></tr>
        <tr id="TableRow_control" runat="server">
          <td>
            <asp:DataGrid id="DataGrid_control" runat="server" gridlines="Horizontal" cellpadding="5" autogeneratecolumns="False">
              <Columns>
                <asp:BoundColumn datafield="tag_num" headertext="Tag #">
                  <ItemStyle HorizontalAlign="Right" />
                </asp:BoundColumn>
                <asp:BoundColumn datafield="last_name" headertext="Last name"></asp:BoundColumn>
                <asp:BoundColumn datafield="first_name" headertext="First name"></asp:BoundColumn>
                <asp:BoundColumn datafield="level" headertext="Level">
                  <HeaderStyle HorizontalAlign="Center" />
                  <ItemStyle HorizontalAlign="Center" />
                </asp:BoundColumn>
                <asp:BoundColumn DataField="affiliation" HeaderText="Affiliation"></asp:BoundColumn>
                <asp:BoundColumn datafield="sms_target" HeaderText="SMS target"></asp:BoundColumn>
              </Columns>
              <HeaderStyle backcolor="WhiteSmoke"></HeaderStyle>
            </asp:DataGrid>
          </td>
        </tr>
      </table>
    </td>
  </tr>
  <tr>
    <td align="center">
      <table width="100%">
        <tr bgcolor="Gainsboro"><td align="center"><small><b>PREPARED BY</b></small></td></tr>
        <tr>
          <td>
            <table width="100%">
              <tr>
                <td nowrap="nowrap" valign="top" width="1%">
                  <table width="100%">
                    <tr bgcolor="WhiteSmoke"><td align="center"><small><b>NAME</b></small></td></tr>
                    <tr><td align="center"><tt><asp:Literal ID="Literal_prepared_name" runat="server"></asp:Literal></tt></td></tr>
                  </table>
                </td>
                <td nowrap="nowrap" width="1%" valign="top">
                  <table width="100%">
                    <tr bgcolor="WhiteSmoke"><td align="center"><small><b>TIMESTAMP</b></small></td></tr>
                    <tr><td align="center"><tt><asp:Literal ID="Literal_prepared_timestamp" runat="server"></asp:Literal></tt></td></tr>
                  </table>
                </td>
              </tr>
            </table>
          </td>
        </tr>
      </table>
    </td>
  </tr>
  </table>
