<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewProfile.aspx.cs" Inherits="ViewProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <div style="background-color:azure; width:400px">

                <div style="padding: 10px">
                    <asp:Label ID="LUsernameText" runat="server" Text="Username:"></asp:Label>
                    <asp:Label ID="LUsernameValue" runat="server" Text=""></asp:Label>
                </div>

                <div style="padding: 10px">
                    <asp:Label ID="LFirstnameText" runat="server" Text="First name"/> 
                    <asp:Label ID="LFirstnameValue" runat="server" Text=""></asp:Label>
                </div>

                <div style="padding: 10px">
                    <asp:Label ID="LLastnameText" runat="server" Text="Last name:"></asp:Label>
                    <asp:Label ID="LLastnameValue" runat="server" Text=""></asp:Label>
                </div>

                <div style="padding: 10px">
                    <asp:Label ID="LAgeText" runat="server" Text="Age:"></asp:Label>
                    <asp:Label ID="LAgeValue" runat="server" Text=""></asp:Label>
                </div>
    
                <div style="padding: 10px">
                    <asp:Label ID="LGenderText" runat="server" Text="Gender:"></asp:Label>
                    <asp:Label ID="LGenderValue" runat="server" Text=""></asp:Label>
                </div>

                <div style="padding: 10px">
                    <asp:Button ID="BBack" runat="server" Text="Go back to previous page" OnClick="BBack_Click"/>
                </div>
            </div>

</asp:Content>

