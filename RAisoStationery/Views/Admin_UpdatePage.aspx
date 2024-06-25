<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Admin_UpdatePage.aspx.cs" Inherits="RAisoStationery.Views.Admin_UpdatePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">
    <h2>Update Stationery</h2>
    <div>
        <asp:Label ID="LblId" runat="server" Text="Id"></asp:Label>
        <asp:TextBox ID="TxbId" runat="server" ReadOnly="true" ></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="LblName" runat="server" Text="Name"></asp:Label>
        <asp:TextBox ID="TxbName" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="LblPrice" runat="server" Text="Price"></asp:Label>
        <asp:TextBox ID="TxbPrice" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="LblError" runat="server" Text=""></asp:Label>
        
    </div>
    <div>
        <asp:Button ID="BtnUpdate" runat="server" Text="Update" OnClick="BtnUpdate_Click" />
    </div>
</asp:Content>
