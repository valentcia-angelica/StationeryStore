<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="RAisoStationery.Views.LoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">
        <h2>
            Login
        </h2>
    
    <div>
        <asp:Label ID="LblName" runat="server" Text="Name"></asp:Label>
        <asp:TextBox ID="TxbName" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="LblPass" runat="server" Text="Password"></asp:Label>
        <asp:TextBox ID="TxbPass" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:CheckBox ID="RememberMe" runat="server" Text="Remember Me"/>
    </div>
    <div>
        <asp:Label ID="LblError" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:Button ID="BtnLogin" runat="server" Text="Login"  OnClick="BtnLogin_Click"/>
    </div>
</asp:Content>
