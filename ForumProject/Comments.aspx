<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Comments.aspx.cs" Inherits="Comments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <div style="align-content:center">
        <asp:Label ID="LTopicname" runat="server" Text=""></asp:Label>
    </div>
    
    <asp:Repeater ID="RepComments" runat="server" DataSourceID="SqlDataSource1">
        <ItemTemplate>
            <div style="background-color: coral">
                <div>
                    <h4> By <%# Eval("postername") %> at <%# Eval("datetime") %></h4>
                </div>
                <br />

                <div>
                    <h4> <%# Eval("answer") %> </h4>
                </div>
                <br />
            </div>
        </ItemTemplate>

        <SeparatorTemplate>
            <div style="height: 2px; background-color: azure">
            </div>
        </SeparatorTemplate>

    </asp:Repeater>

    <asp:LoginView ID="LoginView1" runat="server">
        <AnonymousTemplate>
            <div style="background-color: goldenrod">
                You can't post answers as anonymous. Please sign up here: <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/SignUp.aspx"> Sign Up </asp:HyperLink>
            </div>
        </AnonymousTemplate>

        <LoggedInTemplate>
            <div>
                <h3> Post your answer as <asp:LoginName ID="LoginName1" runat="server" />  here: </h3>
                   
                <asp:TextBox ID="TBAnswer" runat="server" TextMode="MultiLine"></asp:TextBox>
                
                <div>
                    <asp:Button ID="BPostComment" runat="server" Text="Post Your Answer" OnClick="BPostQuestion_Click" />
                </div>

                <div>
                    <asp:Label ID="LResult" runat="server" Text="" ForeColor="Red"></asp:Label>
                </div>

            </div>
        </LoggedInTemplate>
    </asp:LoginView>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [Thread] WHERE ([forumId] = @forumId)">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="0" Name="forumId" QueryStringField="forumId" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>

</asp:Content>

