<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UpdateProfilePage.aspx.cs" Inherits="RAisoStationery.Views.UpdateProfilePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">
    <div>
        <h2>
            Update Profile
        </h2>
    </div>
    

     <div>
        <asp:Label ID="LblName" runat="server" Text="Name"></asp:Label>
        <asp:TextBox ID="TxbName" runat="server"></asp:TextBox>
    </div>
  
    <div>
        <asp:Label ID="Lbl_DOB" runat="server" Text="Date of Birth"></asp:Label>
        <asp:Calendar ID="Cld" runat="server"></asp:Calendar>
    </div>
    <div>
        <asp:Label ID="LblGender" runat="server" Text="Gender"></asp:Label>
        <asp:RadioButton ID="RadBtn_Male" runat="server" GroupName="genderSelected" Text="Male"/>
        <asp:RadioButton ID="RadBtn_Female" runat="server" GroupName="genderSelected" Text="Female"/>
    </div>
    <div>
        <asp:Label ID="LblAddress" runat="server" Text="Address"></asp:Label>
        <asp:TextBox ID="TxbAddress" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="LblPhone" runat="server" Text="Phone"></asp:Label>
        <asp:TextBox ID="TxbPhone" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="LblPass_Old" runat="server" Text="Old Password"></asp:Label>
        <asp:TextBox ID="TxbPass_Old" runat="server" ReadOnly="true"></asp:TextBox>
    </div>

    <div>
        <asp:Label ID="LblPass_New" runat="server" Text="New Password"></asp:Label>
        <asp:TextBox ID="TxbPass_New" runat="server"></asp:TextBox>
    </div>

    <div>
        <asp:Label ID="LblError" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:Button ID="BtnUpdate" runat="server" Text="Update" OnClick="BtnUpdate_Click"/>
    </div>
</asp:Content>
