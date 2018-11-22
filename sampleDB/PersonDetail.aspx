<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonDetail.aspx.cs" Inherits="sampleDB.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>

    table {
    border-collapse: collapse;
}

table, th, td {
    border: 1px solid black;
}

    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Person Detail</h1>
        <br />
    <table>
        <tr>
            <td>ID</td>
            <td>
                <asp:Label ID="lblPersonID" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Full Name</td>
            <td>
                <asp:TextBox ID="tbFullName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Gender</td>
            <td>
                
                <asp:DropDownList ID="ddlGender" runat="server">
                    <asp:ListItem Selected="True" Value="M">Male</asp:ListItem>
                    <asp:ListItem Value="F">Female</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Role</td>
            <td>
                <asp:TextBox ID="tbPersonRole" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
        <br />
        <asp:Button ID="btnAddUpdate" runat="server" OnClick="btnAddUpdate_Click" Text="Add/Update" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCancel" runat="server" Text="Exit" OnClick="btnCancel_Click" />
    </div>
    </form>
</body>
</html>
