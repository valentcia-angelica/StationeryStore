<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="RAisoStationery.Views.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">
    <div>
        <h2>
            Home Page
        </h2>
    </div>
    <div>
        <asp:GridView ID="Stationery_GV" runat="server" OnRowDeleting="Stationery_GV_RowDeleting" OnRowCommand="Stationery_GV_RowCommand" Visible="false">
            <Columns>
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="Delete" UseSubmitBehavior="false" Visible="false" />
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" CommandName="Select" UseSubmitBehavior="false" Visible="false" />
                        
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

        </asp:GridView>
    </div>

    <div>
        <asp:GridView ID="Stationery_GV_Cust" runat="server" OnRowCommand="Stationery_GV_Cust_RowCommand" Visible="false">
            <Columns>
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:Button ID="BtnDetail" runat="server" Text="Detail" CommandName="Detail" UseSubmitBehavior="false" Visible="false" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="StationeryName" HeaderText="Stationery Name" SortExpression="StationeryName" />
            </Columns>

        </asp:GridView>
    </div>


    <div>
        <br />
        <asp:Button ID="btnInsert" runat="server" Text="Insert" Visible="false" OnClick="btnInsert_Click"/>
    </div>
</asp:Content>
