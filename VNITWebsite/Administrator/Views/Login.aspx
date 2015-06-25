<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Administrator_Views_Login" %>

<!DOCTYPE html>
<html>
<head>
    <title>CPanel Login</title>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <link rel="shortcut icon" href="/Design/favicon.png" />
    <link href="/Styles/Admin/LoginPage/style.css" rel="stylesheet" />
</head>

<body>

    <div class="wrapper">
        <div class="container">
            <h1>Welcome</h1>
            <div class="" id="ErrorMess" runat="server" visible="false">
                Tài khoản hoặc mật khẩu không đúng!
            </div>
            <form class="form" id="LoginForm" runat="server">
                <asp:TextBox ID="txtUser" runat="server" type="text" placeholder="Username"></asp:TextBox>
                <asp:TextBox ID="txtPass" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
                <asp:Button ID="btnLogin" runat="server" CssClass="lbnLogin" OnClick="btnLogin_Click" Text="Login"></asp:Button>
            </form>
        </div>

        <ul class="bg-bubbles">
            <li></li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
        </ul>
    </div>
    <script src="/Styles/Admin/BowerComponents/jquery/dist/jquery.min.js"></script>
    <script src="/Styles/Admin/LoginPage/index.js"></script>

</body>
</html>
