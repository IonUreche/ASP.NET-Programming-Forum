<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManageCategories.aspx.cs" Inherits="AddCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <asp:LoginView ID="LoginView1" runat="server">
        <RoleGroups>
            <asp:RoleGroup Roles="Admin">
                <ContentTemplate>

                    <div>
                        <asp:Label ID="Label1" runat="server" Text="Enter the name of new topic category to be added:" Font-Size="Large"></asp:Label>
                    </div>
                    <div>
                        <asp:TextBox ID="TBCategoryName" runat="server" Height="22px" Width="177px" ></asp:TextBox>                  
                    </div>

                    <div>
                        <asp:Button ID="BAddCategory" runat="server" Text="Add category" OnClick="BAddCategory_Click"/>
                    </div>

                    <div>
                        <asp:Label ID="LResult" runat="server" Text=""></asp:Label>
                    </div>

                    <br />

                    <div>
                        <asp:Label ID="Label2" runat="server" Text="Select the category name from the dropdown list below:" Font-Size="Large"></asp:Label>
                    </div>

                    <div>
                        <asp:DropDownList ID="DDLCategories" runat="server" DataSourceID="SqlDataSource1" DataTextField="title" DataValueField="titleID" AutoPostBack="True"/>
                    </div>

                    <div>
                        <asp:Button ID="BDeleteCategory" runat="server" Text="Delete category" OnClick="BDeleteCategory_Click"/>
                    </div>

                    <div>
                        <asp:Label ID="LDeleteResult" runat="server" Text=""/>
                    </div>

                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [title], [titleID] FROM [Title]"></asp:SqlDataSource>
    
                </ContentTemplate>
            </asp:RoleGroup>
        </RoleGroups>
    </asp:LoginView>
</asp:Content>

