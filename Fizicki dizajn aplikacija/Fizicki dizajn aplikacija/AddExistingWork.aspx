<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddExistingWork.aspx.cs" Inherits="Fizicki_dizajn_aplikacija.AddExistingWork" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Existing Work</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="gvAllWorks" runat="server" AutoGenerateColumns="False"
                ForeColor="#333333" Width="450px" EmptyDataText="No data" BorderColor="#999999"
                BorderWidth="2">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="linkBtnAdd" runat="server" Text="Add" OnClick="linkBtnAdd_Click"></asp:LinkButton>
                            <asp:Label ID="lblID" runat="server" Text='<%# Bind("WorkID") %>' Visible="false"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                   <%-- <asp:BoundField DataField="WorkID" HeaderText="Work ID" SortExpression="Work ID" />--%>

                    <asp:BoundField DataField="Title" HeaderText="TItle" SortExpression="Name" />
                    <asp:BoundField DataField="DateOfMaking" HeaderText="Date of making" SortExpression="Date of making" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>                                                                  