<%@ Control Language="c#" AutoEventWireup="True" Codebehind="UserControl_per_deployment_iap_log.ascx.cs" Inherits="UserControl_per_deployment_iap_log.TWebUserControl_per_deployment_iap_log"%>
<!-- Derived from KiAspdotnetFramework/usercontrol/app/UserControl~template~datagrid~sortable.ascx-template -->
<table cellpadding="2" cellspacing="0" align="center">
  <tr>
    <td align="center">
      <table align="center" cellpadding="2" cellspacing="0">
        <tr><td align="center">&nbsp;</td></tr>
        <tr><td align="center"><small>Refer to this document as</small></td></tr>
        <tr><td align="center" nowrap="nowrap"><big><b><asp:Literal ID="Literal_application_name" runat="server"></asp:Literal> Log Report # <asp:Literal ID="Literal_ref_num" runat="server"></asp:Literal></b></big></td></tr>
        <tr><td align="center"><small>on NIMS ICS Form 214</small></td></tr>
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
        <tr bgcolor="Gainsboro"><td align="center"><small><b>ACTIVITY</b></small></td></tr>
        <tr id="TableRow_none" runat="server"><td align="center"><em>--&nbsp;NONE&nbsp;--</em></td></tr>
        <tr id="TableRow_control" runat="server">
          <td>
            <asp:DataGrid id="DataGrid_control" runat="server" gridlines="Horizontal" cellpadding="2" autogeneratecolumns="False">
              <Columns>
                <asp:BoundColumn datafield="timestamp" headertext="Timestamp">
                  <HeaderStyle horizontalalign="Left"></HeaderStyle>
                  <ItemStyle VerticalAlign="Top" Wrap="False" />
                </asp:BoundColumn>
                <asp:BoundColumn datafield="actor" headertext="Actor" >
                  <ItemStyle horizontalalign="Left" VerticalAlign="Top" Wrap="False" />
                </asp:BoundColumn>
                <asp:BoundColumn datafield="action" headertext="Action" >
                  <ItemStyle horizontalalign="Left" />
                </asp:BoundColumn>
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
