<%@ Page Language="C#" AutoEventWireup="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>The application bootstrap</title>
</head>
<body>
    <form id="DefaultForm" runat="server">
        <script runat="server">
            protected void Page_Load(object sender, EventArgs e)
            {
                Response.Redirect("/Administrator/Views/Default.aspx");
            }
        </script>
    </form>
</body>
</html>
