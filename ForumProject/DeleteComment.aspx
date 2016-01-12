<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DeleteComment.aspx.cs" Inherits="DeleteComment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <div>
        <h4> <asp:Label ID="LConfirm" runat="server" Text="Are you sure you want to delete this comment ?"></asp:Label>
        </h4>
    </div> 
    <div>
        <asp:Button ID="BYes" runat="server" Text="Yes" OnClick="BYes_Click"/>
        |
        <asp:Button ID="BNo" runat="server" Text="No" OnClick="BNo_Click"/>
    </div>
    <div>
        <asp:Label ID="LResult" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>

