<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Topic.aspx.cs" Inherits="Topic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <div style="padding: 15px 35px; width:850px; background-color: grey; ">
        <!--
        <asp:Repeater ID="RepTopic" runat="server" DataSourceID="SqlDataSource3" OnItemCommand="RepTopic_ItemCommand">
        
        <ItemTemplate>
            <div style="height:40px; vertical-align:middle; background-color: cornflowerblue; padding-bottom: 5px; padding-top: 2px; padding-left:10px; padding-right: 10px">
                <h4> <%# Eval("question") %> </h4>
            </div>
        </ItemTemplate>

        <SeparatorTemplate>
            <div style="height: 2px; background-color:#533DD1"></div>
        </SeparatorTemplate>
        
        </asp:Repeater>
        -->
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource3" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1" AllowPaging="True" AllowSorting="True" BackColor="#FFFF66" style="margin-right: 5px" Width="882px">
            <AlternatingRowStyle BackColor="#CC9900" BorderStyle="None" ForeColor="Black" />
            <Columns>
                <asp:HyperLinkField DataNavigateUrlFields="forumId"
                    DataNavigateUrlFormatString="~/Comments.aspx?forumId={0}" 
                    DataTextField="question" />
                
                <asp:BoundField DataField="dateTim" HeaderText="datetime" SortExpression="dateTim" />
                <asp:BoundField DataField="postername" HeaderText="postername" SortExpression="postername" />
               
            </Columns>
            <EditRowStyle BackColor="Black" HorizontalAlign="Left" VerticalAlign="Middle" />
        </asp:GridView>
    </div>

    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [forumId], [titleId], [question], [dateTim], [postername] FROM [Forum] WHERE ([titleId] = @titleId)">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="0" Name="titleId" QueryStringField="id" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>

</asp:Content>

