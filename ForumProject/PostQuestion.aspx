<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PostQuestion.aspx.cs" Inherits="PostQuestion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <div>
        <asp:LoginView ID="LoginView1" runat="server">
            <LoggedInTemplate>
                <h3> Select category for your question from the list below </h3>
                <asp:DropDownList ID="DDLCategories" runat="server" DataSourceID="SqlDataSource1" DataTextField="title" DataValueField="titleID" AutoPostBack="True">

                 </asp:DropDownList>

                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [title], [titleID] FROM [Title]"></asp:SqlDataSource>

                <div>
                    Post question as <asp:LoginName ID="LoginName1" runat="server" />
                </div>

                <asp:TextBox ID="TBQuestion" runat="server" TextMode="MultiLine" Width="500px" Height="70px"></asp:TextBox>

                <div>
                    <asp:Button ID="BPostQuestion" runat="server" Text="Post Your Question" OnClick="BPostQuestion_Click" />
                </div>

                <div>
                    <asp:Label ID="LResult" runat="server" Text="" ForeColor="Red"></asp:Label>
                </div>

           </LoggedInTemplate>
        </asp:LoginView>
    </div>

</asp:Content>

