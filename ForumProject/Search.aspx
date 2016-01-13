<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <asp:SqlDataSource ID="SDSSearch" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" 
        SelectCommand="SELECT title, Forum.forumId, question, Forum.postername, datetime, answer 
                       FROM Title INNER JOIN Forum ON Title.titleID = Forum.titleId
                                  FULL JOIN Thread ON Forum.forumId = Thread.forumId">
    </asp:SqlDataSource>

    <asp:Label ID="LSelect" runat="server" Text=""></asp:Label>
    <br />
    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SDSSearch">
        <HeaderTemplate>
            Search results:
        </HeaderTemplate>

        <ItemTemplate>
            <div style="padding: 10px; background-color: azure">
                <h3><%# DataBinder.Eval(Container.DataItem, "title")%> <%# DataBinder.Eval(Container.DataItem, "question")%></h3>
            
                <div>
                    Posted by: <%# DataBinder.Eval(Container.DataItem, "postername")%>
                </div>
                <div>
                    DateTime: <%# DataBinder.Eval(Container.DataItem, "datetime")%>
                </div>
                <div>
                    answer: <%# DataBinder.Eval(Container.DataItem, "answer")%>
                </div>
                 
                <asp:LoginView ID="LoginView1" runat="server">
                    <LoggedInTemplate>
                        <asp:HyperLink ID="HyperLink1" NavigateUrl='<%# "~/Comments.aspx?forumId=" + DataBinder.Eval((Container.Parent as RepeaterItem).DataItem, "forumId")%>' runat="server" ForeColor="Black" > Go to topic </asp:HyperLink>
                    </LoggedInTemplate>
                </asp:LoginView>
             </div>
        </ItemTemplate>

        <SeparatorTemplate>
            <br />
        </SeparatorTemplate>
    </asp:Repeater>
</asp:Content>

