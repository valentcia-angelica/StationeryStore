<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DetailPage.aspx.cs" Inherits="RAisoStationery.Views.Customer_HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">
    <div>
        <h2>
            Detail Page
        </h2>

    </div>
   
    <div>
        <asp:Label ID="LblStatName" runat="server" Text="Stationery Name"></asp:Label>
        <asp:TextBox ID="TxbStatName" runat="server" ReadOnly="true"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="LblStatPrice" runat="server" Text="Stationery Price"></asp:Label>
        <asp:TextBox ID="TxbStatPrice" runat="server" ReadOnly="true"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Quantity" runat="server" Text="Quantity" Visible="false"></asp:Label>
        <asp:TextBox ID="TxbQty" runat="server" Visible="false"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="LblError" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:Button ID="BtnAddToCart" runat="server" Text="Add to Cart" OnClick="BtnAddToCart_Click" Visible="false"/>
    </div>
</asp:Content>
