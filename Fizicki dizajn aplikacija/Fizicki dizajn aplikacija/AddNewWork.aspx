<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNewWork.aspx.cs" Inherits="Fizicki_dizajn_aplikacija.EditWork" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add New Work</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <asp:Label ID="lblTitle" Text="Work title: " runat="server"></asp:Label>
            <asp:TextBox ID="txtTitle" runat="server" Width="300px"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblDatum" Text="Date of making: " runat="server"></asp:Label>
            <asp:TextBox ID="txtDate" runat="server" Width="300px"></asp:TextBox>
        </div>        
        <div>
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
        </div>
   
    </div>
    </form>
</body>
</html>
