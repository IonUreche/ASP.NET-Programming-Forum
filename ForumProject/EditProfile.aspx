<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditProfile.aspx.cs" Inherits="EditProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <asp:LoginView ID="LoginView1" runat="server">
        <LoggedInTemplate>
            <div style="background-color:azure; width:400px">
                <div style="padding: 10px">
                    <asp:Label ID="LUsernameText" runat="server" Text="Username:"></asp:Label>
                    <asp:Label ID="LUsernameValue" runat="server" Text=""></asp:Label>
                </div>

                <div style="padding: 10px">
                    <asp:Label ID="LFirstname" runat="server" Text="First name"></asp:Label>
                    <br />
                    <asp:TextBox ID="TBFirstname" runat="server" MaxLength="20"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TBFirstname" ErrorMessage="First name is required" ForeColor="Red" />
                </div>
                <div style="padding: 10px">
                    <asp:Label ID="LLastname" runat="server" Text="Last name:"></asp:Label>
                    <br />
                    <asp:TextBox ID="TBLastname" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TBLastname" ErrorMessage="Last name is required" ForeColor="Red" />
                </div>
                <div style="padding: 10px">
                    <asp:Label ID="LAge" runat="server" Text="Age:"></asp:Label>
                    <br />
                    <asp:TextBox ID="TBAge" runat="server"></asp:TextBox>
                    <asp:RangeValidator ID="RV1" runat="server" ControlToValidate="TBAge" ErrorMessage="RangeValidator" MinimumValue="12" MaximumValue="100" Type="Integer" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TBAge" ErrorMessage="Age is required" ForeColor="Red"/>
                </div>
    
                <div style="padding: 10px">
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                        <asp:ListItem Text="Male" Value="Male"/>
                        <asp:ListItem Text="Female" Value="Female"/>
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="RadioButtonList1" ErrorMessage="RequiredFieldValidator" ForeColor="Red" />
                </div>

                <div style="padding: 10px">
                    <asp:Button ID="BFinish" runat="server" Text="Finish" OnClick="BFinish_Click"/>
                </div>

                <div style="padding: 10px">
                    <asp:Label ID="LResult" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </LoggedInTemplate>
    </asp:LoginView>

</asp:Content>

