<%@ Page language="c#" Debug="true" Codebehind="template_std.pas" AutoEventWireup="false" Inherits="template_std.TWebForm_template_std" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">

<html>
  <head>
	<title id="Title" runat="server"></title>
  </head>

  <body>
     <form runat="server">
      <asp:placeholder id="PlaceHolder_precontent" runat="server">
      </asp:placeholder>
<p>{content}</p>
    <asp:placeholder id="PlaceHolder_postcontent" runat="server">
    </asp:placeholder>
     </form>
  </body>
</html>
