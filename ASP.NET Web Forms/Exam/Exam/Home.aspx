<%@ Page Title="News" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="NewsSite.Home" %>
<asp:Content ID="ContentBody" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%: this.Title %></h1>

    <h2>Most popular articles</h2>

    <asp:ListView runat="server" ID="ListViewMostPopularArticles" ItemType="NewsSite.Models.Article" SelectMethod="ListViewMostPopularArticles_GetData">
        <ItemTemplate>
            <div class="row">
                <h3>
                    <asp:HyperLink NavigateUrl='<%# string.Format("~/ViewArticle.aspx?id={0}", Item.Id) %>' runat="server" Text='<%# string.Format(@"""{0}""", Item.Title) %>' /> 
                    <small><%#: Item.Category.Name %></small>
                </h3>
                <p><%# Item.Content.Substring(0, Math.Min(Item.Content.Length, 300)) %>...</p>
                <p>Likes:<%#: Item.LikesPower %></p>
                <div>
                    <i>by <%#: Item.Author.UserName %></i>
                    <i>created on: <%#: Item.DateCreated %></i>
                </div>
            </div>
        </ItemTemplate>
        <EmptyDataTemplate>
            No articles
        </EmptyDataTemplate>
    </asp:ListView>

    <h2>All categories</h2>

    <asp:ListView runat="server" ID="ListViewCategories" ItemType="NewsSite.Models.Category" SelectMethod="ListViewCategories_GetData" GroupItemCount="2">
        <GroupTemplate>
            <div class="row">
                <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
            </div>
        </GroupTemplate>
        <ItemTemplate>
            <div class="col-md-6">
                <h3><%#: Item.Name %></h3>
                <asp:ListView runat="server" ID="RepeaterArticles" ItemType="NewsSite.Models.Article" DataSource="<%# Item.Articles.Take(3) %>">
                    <LayoutTemplate>
                        <ul>
                            <asp:PlaceHolder runat="server" ID="itemPlaceHolder" />
                        </ul>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <li>
                            <asp:HyperLink NavigateUrl='<%# string.Format("~/ViewArticle.aspx?id={0}", Item.Id) %>' runat="server" Text='<%# string.Format(@"""{0}"" by <i>{1}</i>", Item.Title, Item.Author.UserName) %>' />
                        </li>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        No articles.
                    </EmptyDataTemplate>
                </asp:ListView>
            </div>
        </ItemTemplate>
        <EmptyDataTemplate>
            No articles
        </EmptyDataTemplate>
    </asp:ListView>
</asp:Content>
