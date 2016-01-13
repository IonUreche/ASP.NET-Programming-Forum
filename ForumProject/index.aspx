<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" MasterPageFile="~/MasterPage.master"%>

<asp:Content runat="server" ContentPlaceHolderID="head">
    <!--
    <asp:DropDownList ID="DDLCategories" runat="server" DataSourceID="SqlDataSource1" DataTextField="title" DataValueField="titleID" AutoPostBack="True">
    </asp:DropDownList>
      -->  
    <div style="width:600px; background-color: grey; padding-left:35px; padding-top:15px; padding-bottom:15px; padding-right:35px">

        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
        
        <ItemTemplate>
            <div style="height:40px; vertical-align:middle; background-color: cornflowerblue; padding-bottom: 5px; padding-top: 2px; padding-left:10px; padding-right: 10px">
                 <asp:HyperLink ID="HLCategory" runat="server" NavigateUrl='<%# Eval("titleId", "~/Topic.aspx?id={0}") %>' >
                     <h4> <%# Eval("title") %> </h4>
                 </asp:HyperLink>
            </div>
        </ItemTemplate>

        <SeparatorTemplate>
            <div style="height: 2px; background-color:#533DD1"></div>
        </SeparatorTemplate>
        
    </asp:Repeater>

    </div>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [title], [titleID] FROM [Title]"></asp:SqlDataSource>

    <div>
        <!--
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1">
                <Columns>
                    <asp:BoundField DataField="question" HeaderText="question" SortExpression="question" />
                    <asp:BoundField DataField="postername" HeaderText="postername" SortExpression="postername" />
                    <asp:BoundField DataField="dateTim" HeaderText="datetime" SortExpression="dateTim" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="Button1" runat="server" CommandName="select" OnClick="Button1_Click" Text="View Comments" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Height="55px" Text='<%# Bind("question") %>' TextMode="MultiLine" Width="453px"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        -->
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [forumId], [question], [postername], [dateTim] FROM [Forum] WHERE ([titleId] = @titleId)">
            <SelectParameters>
                <asp:ControlParameter ControlID="DDLCategories" Name="titleId" PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
    <div>
        <asp:Label ID="LQueryResult" runat="server" Text=""></asp:Label>
    </div>

</asp:Content>
