<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfileView.aspx.cs" Inherits="Fizicki_dizajn_aplikacija.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Profile view</title>
</head>
<body>
    <form id="form1" runat="server">

        <div>

            <div>
                <asp:Label ID="lblNameFix" Text="First Name: " runat="server" Width="100px"></asp:Label>
                <asp:Label ID="lblName" runat="server"></asp:Label>
            </div>

            <div>
                <asp:Label ID="lblLastNameFix" Text="Last Name: " runat="server" Width="100px"></asp:Label>
                <asp:Label ID="lblLastName" runat="server"></asp:Label>
            </div>

            <div>
                <asp:Button ID="btnAddNewWork" runat="server" Text="Add New Work" OnClick="btnAddWork_Click" />
                <asp:Button ID="btnAddExistingWork" runat="server" Text="Add Existing Work" OnClick="btnAddExistingWork_Click" />
            </div>

            <div>
                <div>
                    <asp:Label ID="lblWorksFix" Text="Works: " runat="server" Width="100px"></asp:Label>
                </div>


                <!--tuka naldoeeeeeee -->

                <asp:GridView ID="gvWorks" runat="server" AutoGenerateColumns="False"
                    ForeColor="#333333" Width="450px" EmptyDataText="No data" BorderColor="#999999"
                    BorderWidth="2">
                    <Columns>
                        <asp:TemplateField>
                        <ItemTemplate>                            
                            <asp:Label ID="lblID" runat="server" Text='<%# Bind("WorkID") %>' Visible="false"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>

                        <%--<asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />--%>
                        <asp:BoundField DataField="Title" HeaderText="TItle" SortExpression="Name" />
                        <asp:BoundField DataField="DateOfMaking" HeaderText="Date of making" SortExpression="Date of making" />
                        
                        <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="linkBtnDelete" runat="server" Text="Delete" OnClick="linkBtnDelete_Click"></asp:LinkButton>
                            <%--<asp:Label ID="lblID" runat="server" Text='<%# Bind("WorkID") %>' Visible="false"></asp:Label>--%>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                    </Columns>
                </asp:GridView>

            </div>
            

        </div>

    </form>
</body>
</html>
