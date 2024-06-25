<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DetailTransactionHistory.aspx.cs" Inherits="RAisoStationery.Views.DetailTransactionHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">
    <div>
        <h1>
            Detail Transaction History
        </h1>
    </div>
    <div>
        <asp:Label ID="LblTransactionId" runat="server" Text="Transaction Id"></asp:Label>
        <asp:TextBox ID="TxbTransactionID" runat="server" ReadOnly="true"></asp:TextBox>
    </div>
    <div>
        <asp:GridView ID="DetailTransaction_GV" runat="server">
            <Columns>
                <asp:BoundField DataField="StationeryName" HeaderText="Stationery Name" SortExpression="StationeryName" />
                <asp:BoundField DataField="StationeryPrice" HeaderText="Stationery Price" SortExpression="StationeryPrice" />
                <asp:BoundField DataField="StationeryQuantity" HeaderText="Stationery Quantity" SortExpression="StationeryQuantity" />
            </Columns>

        </asp:GridView>
    </div>
    <div>
        <asp:Button ID="BtnBack" runat="server" Text="Back" OnClick="BtnBack_Click" />
    </div>
</asp:Content>
