<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="TransactionHistory.aspx.cs" Inherits="RAisoStationery.Views.TransactionHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">
    <div>
        <h2>
            Transaction History
        </h2>
    </div>

    <div>
        <asp:GridView ID="History_GV" runat="server" OnSelectedIndexChanged="History_GV_SelectedIndexChanged">
            <Columns>
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:Button ID="BtnDetail" runat="server" Text="Detail"  CommandName="Select" UseSubmitBehavior="false"/>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="TransactionId" HeaderText="Transaction Id" SortExpression="TransactionId" />
                <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" SortExpression="TransactionDate" />
                <asp:BoundField DataField="UserName" HeaderText="Customer Name" SortExpression="CustomerName" />


            </Columns>
        </asp:GridView>
    </div>
    

</asp:Content>
