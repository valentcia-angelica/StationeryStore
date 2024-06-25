<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Customer_UpdateCart.aspx.cs" Inherits="RAisoStationery.Views.Customer_UpdateCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">
    <div>
        <h1>
            Update Cart
        </h1>
    </div>
    <%--<div>
        <asp:Label ID="LblName" runat="server" Text="Name"></asp:Label>
        <asp:TextBox ID="TxbName" runat="server" ReadOnly="true"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="LblPrice" runat="server" Text="Price"></asp:Label>
        <asp:TextBox ID="TxbPrice" runat="server" ReadOnly="true"></asp:TextBox>
    </div>--%>
    <div>
        <asp:Label ID="LblStatName" runat="server" Text="Stationery Name"></asp:Label>
        <asp:TextBox ID="TxbStatName" runat="server" ReadOnly="true"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="LblStatPrice" runat="server" Text="Stationery Price"></asp:Label>
        <asp:TextBox ID="TxbStatPrice" runat="server" ReadOnly="true"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Quantity" runat="server" Text="Quantity"></asp:Label>
        <asp:TextBox ID="TxbQty" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="LblError" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:Button ID="BtnUpdate" runat="server" Text="Update" OnClick="BtnUpdate_Click" />
    </div>
</asp:Content>
