<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Customer_CartPage.aspx.cs" Inherits="RAisoStationery.Views.Customer_CartPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">
    <div>
        <h1>Cart
        </h1>
    </div>
    <div>
        <asp:GridView ID="Cart_GV" runat="server" OnRowCommand="Cart_GV_RowCommand">
            <Columns>
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:Button ID="BtnUpdate" runat="server" Text="Update" CommandName="Select" UseSubmitBehavior="false"/>
                        <asp:Button ID="BtnDelete" runat="server" Text="Delete" CommandName="Delete" UseSubmitBehavior="false"/>
                    </ItemTemplate>
                </asp:TemplateField>
                
                
                <asp:BoundField DataField="StationeryName" HeaderText="Stationery Name" SortExpression="StationeryName" />
                <asp:BoundField DataField="StationeryPrice" HeaderText="Stationery Price" SortExpression="StationeryPrice" />
                <asp:BoundField DataField="StationeryQuantity" HeaderText="StationeryQuantity" SortExpression="StationeryQuantity" />
                
                
            </Columns>
        </asp:GridView>
    </div>
    <div>
        <asp:Label ID="LblCheck" runat="server" Text="" ></asp:Label>
    </div>

    <div>
       <%-- <asp:Button ID="BtnRemoveAll" runat="server" Text="Remove All Cart" OnClick="BtnRemoveAll_Click" />--%>
        <asp:Button ID="BtnCheckOut" runat="server" Text="CheckOut" OnClick="BtnCheckOut_Click"/>
    </div>
</asp:Content>
