<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Promote.aspx.cs" Inherits="PromoteToModerator" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <asp:LoginView ID="LoginView1" runat="server">
        <RoleGroups>
            <asp:RoleGroup Roles="Admin">
                <ContentTemplate>

                    <div>
                        <asp:Label ID="Label1" runat="server" Text="Enter the name of user to promote:" Font-Size="Large"></asp:Label>
                    </div>
                    <div>
                        <asp:TextBox ID="TBUsername" runat="server" Height="22px" Width="177px" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Empty username is proxibited" ControlToValidate="TBUsername" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>

                    <div>
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" >
                            <asp:ListItem Value="User"> User </asp:ListItem>
                            <asp:ListItem Value="Moderator"> Moderator </asp:ListItem>
                            <asp:ListItem Value="Admin"> Admin </asp:ListItem>
                        </asp:RadioButtonList>
                    </div>

                    <div>
                        <asp:Button ID="BPromote" runat="server" Text="Promote" OnClick="BPromote_Click"/>
                    </div>

                    <div>
                        <asp:Label ID="LResult" runat="server" Text=""></asp:Label>
                    </div>
    
                </ContentTemplate>
            </asp:RoleGroup>
        </RoleGroups>
    </asp:LoginView>

</asp:Content>

