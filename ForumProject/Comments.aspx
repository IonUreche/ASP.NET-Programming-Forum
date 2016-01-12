<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Comments.aspx.cs" Inherits="Comments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <div style="align-content:center; background-color:aliceblue">
        <h3>
            <asp:Label ID="LTopicname" runat="server" Text=""></asp:Label>
        </h3>
    </div>

    <asp:LoginView ID="LoginView3" runat="server">
        <RoleGroups>
            <asp:RoleGroup Roles="Admin,Moderator">
                <ContentTemplate>
                    <asp:DropDownList ID="DDLCategories" runat="server" DataSourceID="SqlDataSource2" DataTextField="title" 
                        DataValueField="titleID" AutoPostBack="True"/>
                    <asp:Button ID="BMove" runat="server" Text="Move topic to selected category" OnClick="BMove_Click"/>
                </ContentTemplate>
            </asp:RoleGroup>
        </RoleGroups>
    </asp:LoginView>
    
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [title], [titleID] FROM [Title]"></asp:SqlDataSource>

    <asp:Repeater ID="RepComments" runat="server" DataSourceID="SqlDataSource1">
        <ItemTemplate>
            <div style="background-color: coral">
                <div>
                    <h4> By <asp:HyperLink ID="HLViewProfile" runat="server" NavigateUrl='<%# "~/ViewProfile.aspx?username=" + Eval("postername") %>'><%# Eval("postername") %></asp:HyperLink> at <%# Eval("datetime") %></h4>
                </div>
                <br />

                <div>
                    <h4> <%# Eval("answer") %> </h4>
                </div>
                <br />
            </div>

            <asp:LoginView ID="LoginView2" runat="server">
                <RoleGroups>
                    <asp:RoleGroup Roles="Admin,Moderator">
                        <ContentTemplate>
                            <asp:LinkButton ID="DeleteLink" runat="server" 
                                CommandArgument='<%#Eval("threadId")%>' OnClick="deleteComment"> Delete </asp:LinkButton>
                            |
                            <asp:LinkButton ID="EditButton" runat="server"  
                                CommandArgument='<%#Eval("threadId")%>' OnClick="editComment"> Edit </asp:LinkButton>
                        </ContentTemplate>
                    </asp:RoleGroup>

                 </RoleGroups>
            </asp:LoginView>

        </ItemTemplate>

        <SeparatorTemplate>
            <div style="height: 2px; background-color: azure">
            </div>
        </SeparatorTemplate>

    </asp:Repeater>

    <asp:LoginView ID="LoginView1" runat="server">
        <AnonymousTemplate>
            <div style="background-color: goldenrod">NavigateUrl='<%# "~/Comments.aspx?forumId=" + DataBinder.Eval((Container.Parent as RepeaterItem).DataItem, "forumId")%>'
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

