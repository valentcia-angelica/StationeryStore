<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Admin_InsertPage.aspx.cs" Inherits="RAisoStationery.Views.Admin_InsertPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">
    <div>
        <h2>
            Insert New Stationery
        </h2>
    </div>

    <div>
        <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
        <asp:TextBox ID="TxbName" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="lblPrice" runat="server" Text="Price"></asp:Label>
        <asp:TextBox ID="TxbPrice" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    </div>

    <div>
        <asp:Button ID="btnInsert" runat="server" Text="Insert" OnClick="btnInsert_Click"/>
    </div>
</asp:Content>
