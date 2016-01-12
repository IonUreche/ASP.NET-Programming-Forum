<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="EditComment.aspx.cs" Inherits="EditComment" MasterPageFile="~/MasterPage.master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <asp:LoginView ID="LoginView1" runat="server">
            <LoggedInTemplate>
                <div>
                    <asp:TextBox TextMode="MultiLine" ID = "TBAnswer" runat="server" Height="222px" Width="451px"></asp:TextBox>
                </div>

                <div>
                    <asp:Button ID="BEdit" runat="server" Text="Edit" OnClick="editComment"/>
                    
                    <asp:Button ID="BBack" runat="server" Text="Go back to thread page" Visible="false" OnClick="BBack_Click"/>
                </div>

                <div>
                    <asp:Label ID="LResult" runat="server" Text="Label"/>
                </div>
            </LoggedInTemplate>
        </asp:LoginView>
</asp:Content>