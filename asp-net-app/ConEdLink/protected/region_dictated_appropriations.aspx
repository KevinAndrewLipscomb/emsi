<%@ Page language="c#" Debug="true" Codebehind="region_dictated_appropriations.aspx.cs" AutoEventWireup="True" Inherits="region_dictated_appropriations.TWebForm_region_dictated_appropriations" %>
<%@ Register TagPrefix="uc1" TagName="UserControl_precontent" Src="~/usercontrol/app/UserControl_precontent.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UserControl_postcontent" Src="~/usercontrol/app/UserControl_postcontent.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/strict.dtd">
<%@ Register TagPrefix="uc2" TagName="UserControl_update_progress_blocker" Src="~/usercontrol/app/UserControl_update_progress_blocker.ascx" %>
<html>
  <head>
    <title id="Title" runat="server"></title>
    <!-- $Id$ -->
    <link href="../css/standard.css" rel="stylesheet" type="text/css" />
    <!--[if lt IE 7]> <style type="text/css">@import "../css/standard-overrides-for-ie6.css";</style><![endif]-->
  </head>
  <body bgcolor="white">
    <form runat="server">
	  <p>
      <uc1:UserControl_precontent id="UserControl_precontent" runat="server"></uc1:UserControl_precontent></p>
	  <p>
        <table cellspacing="0" cellpadding="0" border="1">
            <tr>
              <td>
                <table cellspacing="0" cellpadding="10" border="0">
                    <tr>
                      <td bgcolor="#f5f5f5"><a name="ActionRequired" /><strong>Action required</strong></td>
                    </tr>
                    <tr>
                      <td></td>
                    </tr>
                </table></td>
            </tr>
		</table></p>
	  <p></p>
		<table bordercolor="#dcdcdc" cellspacing="0" cellpadding="0" border="1" id="Table_appropriations" runat="server">
            <tr>
              <td>
                <table cellspacing="0" cellpadding="10" border="0">
					<tr>
					  <td bgcolor="#f5f5f5"><a name="Appropriations" /><strong>Allocations</strong></td>
					</tr>
					<tr>
					  <td>
	  <table cellspacing="0" cellpadding="0" border="1" bordercolor="#dcdcdc">
		<tr>
		  <td>
			<table cellspacing="0" cellpadding="5" border="0">
			  <tr>
				<td bgcolor="#f5f5f5">
				  <p align="right">
					<strong>Allocation:</strong>
				  </p>
				</td>
				<td>
				  <p align="right">
				  <asp:label id="Label_parent_appropriation_amount" runat="server"></asp:label>
				  </p>
				</td>
				<td>
				  for
				  <asp:label id="Label_fiscal_year_designator" runat="server"></asp:label>
				</td>
			  </tr>
			  <tr id="TableRow_sum_of_county_appropriations" runat="server">
				<td>
				  <p align="right">
					-
				  </p>
				</td>
				<td>
				  <p align="right">
				  <asp:label id="Label_sum_of_county_appropriations" runat="server" font-underline="True"></asp:label>
				  </p>
				</td>
				<td>allocated to&nbsp;counties (below)</td>
			  </tr>
			  <tr id="TableRow_unappropriated_amount" runat="server">
				<td>
				  <p align="right">
					=
				  </p>
				</td>
				<td>
				  <p align="right">
				  <asp:label id="Label_unappropriated_amount" runat="server">
				  </asp:label>
				  </p>
				</td>
				<td>
				  remaining
				</td>
			  </tr>
			</table>
		  </td>
		</tr>
	  </table>
	  <p></p>
	  <table bordercolor="#dcdcdc" cellspacing="0" cellpadding="0" border="1" id="Table_deadlines" runat="server">
		  <tr>
			<td>
		<table cellspacing="0" cellpadding="5" border="0">
			<tr>
			  <td bgcolor="#f5f5f5" colspan="2">
				<p align="left"><strong>Deadlines</strong>
				</p></td>
			</tr>
			<tr>
			  <td>
<p>The last day you will accept EMSOF request submissions&nbsp;from services is
				<ASP:LinkButton id="LinkButton_region_dictated_deadline" runat="server" font-bold="True" onclick="LinkButton_region_dictated_deadline_Click">LinkButton_region_dictated_deadline</ASP:LinkButton>.</p></td>
						  </tr>
		</table></td>
		  </tr>
	  </table>
	  <p></p>
	  <table bordercolor="#ffd700" cellspacing="0" cellpadding="0" border="1" id="Table_warning_forced_amount" runat="server">
			<tr>
              <td>
			  <table cellspacing="0" cellpadding="5" border="0">
                  <tr>
					<td bgcolor="#ffd700"><strong>Warning</strong></td>
                  </tr>
				  <tr>
                    <td>To prevent you from exceeding your own allocation, 
					  <ASP:Label id="Label_application_name" runat="server"></ASP:Label>&nbsp;reduced the amount of the county allocation that you just updated.</td>
                  </tr>
			  </table></td>
            </tr>
		</table>
	  <p></p>
	  <table cellspacing="0" cellpadding="0" border="1"  bordercolor="#dcdcdc">
		<tr>
		  <td>
	  <table cellspacing="0" cellpadding="10" border="0">
		<tr bgcolor="#f5f5f5">
		  <td>
			<strong>County allocations</strong>
		  </td>
		  <td>
			<div align="center">
			  <asp:LinkButton id="LinkButton_new_appropriation" runat="server" font-bold="True" enabled="False" onclick="LinkButton_new_appropriation_Click">New</asp:LinkButton>
			</div>
		  </td>
		</tr>
		<tr>
		  <td colspan="4">
						<ASP:Label id="Label_no_appropriations" runat="server" font-italic="True">-- NONE --</ASP:Label>
		  </td>
		</tr>
		<tr>
		  <td colspan="4">
		<asp:datagrid id="DataGrid_county_appropriations" runat="server"
		bordercolor="Gainsboro" borderstyle="None" borderwidth="1px" backcolor="White" cellpadding="10" gridlines="Horizontal" forecolor="Black"
		allowsorting="True" useaccessibleheader="True" autogeneratecolumns="False" onsortcommand="SortCommand_county_appropriations" visible="False">
                                          <FooterStyle forecolor="Black" backcolor="#CCCC99"></FooterStyle>
                                          <SelectedItemStyle font-bold="True" forecolor="White" backcolor="#CC3333"></SelectedItemStyle>
                                          <HeaderStyle forecolor="Blue" backcolor="WhiteSmoke"></HeaderStyle>
                                          <Columns>
                                            <ASP:BoundColumn visible="False" datafield="id" sortexpression="id" readonly="True" headertext="ConEdLink ID#">
                                              <ItemStyle horizontalalign="Center" forecolor="Gray"></ItemStyle>
                                            </ASP:BoundColumn>
                                            <ASP:BoundColumn visible="False" datafield="password_reset_email_address" sortexpression="password_reset_email_address" readonly="True"></ASP:BoundColumn>
                                            <ASP:BoundColumn visible="False" datafield="county_code" sortexpression="county_code" readonly="True"></ASP:BoundColumn>
                                            <ASP:BoundColumn datafield="name" sortexpression="name" readonly="True" headertext="Name"></ASP:BoundColumn>
                                            <ASP:BoundColumn datafield="amount" sortexpression="amount" headertext="Amount" dataformatstring="{0:C}">
                                              <ItemStyle horizontalalign="Right"></ItemStyle>
                                            </ASP:BoundColumn>
                                            <ASP:EditCommandColumn buttontype="LinkButton" updatetext="Update" canceltext="Cancel" edittext="Edit">
                                              <ItemStyle forecolor="Blue"></ItemStyle>
                                            </ASP:EditCommandColumn>
                                            <ASP:ButtonColumn visible="False" text="Delete" commandname="Delete">
                                              <ItemStyle forecolor="Blue"></ItemStyle>
                                            </ASP:ButtonColumn>
                                          </Columns>
                                          <PagerStyle horizontalalign="Right" forecolor="Black" backcolor="White"></PagerStyle>
		</asp:datagrid>
		  </td>
		</tr>
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
	  <p></p>
	  <uc1:UserControl_postcontent id="UserControl_postcontent" runat="server"></uc1:UserControl_postcontent>
      <uc2:UserControl_update_progress_blocker id="UserControl_update_progress_blocker_control" runat="server"></uc2:UserControl_update_progress_blocker>
    </form>
  </body>
</html>
