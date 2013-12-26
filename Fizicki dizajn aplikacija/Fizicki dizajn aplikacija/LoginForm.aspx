<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="Fizicki_dizajn_aplikacija.LoginForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <asp:Label ID="lblUsername" Text="Username: " runat="server" Width="100px"></asp:Label>
            <asp:TextBox ID="txtUsername" runat="server" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvUsername" Text="Required field" ControlToValidate="txtUsername" runat="server" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <div>
             <asp:Label ID="lblPassword" Text="Password: " runat="server"  Width="100px"></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPassword" Text="Required field" ControlToValidate="txtPassword" runat="server" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <div>
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
        </div>
        <div>
            <asp:Label ID="lblWrongData" runat="server" ForeColor="Red"></asp:Label>
        </div>
    
    </div>
    </form>
</body>
</html>
