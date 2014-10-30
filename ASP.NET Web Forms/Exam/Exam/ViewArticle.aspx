<%@ Page Title="News" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewArticle.aspx.cs" Inherits="NewsSite.ViewArticle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container body-content"> 
        <asp:LoginView runat="server" ID="LoginViewMenu">
            <LoggedInTemplate>
                <div class="like-control col-md-1">
                    <div>Likes</div>
                    <div>
                        <asp:LinkButton CssClass="btn btn-default glyphicon glyphicon-chevron-up" runat="server" ID="LinkButtonVoteUp" OnClick="LinkButtonVoteUp_Click"></asp:LinkButton>
						<asp:Label CssClass="like-value" ID="LabelLikeValue" runat="server"></asp:Label>
                        <asp:LinkButton CssClass="btn btn-default glyphicon glyphicon-chevron-down" runat="server" ID="LinkButtonVoteDown" OnClick="LinkButtonVoteDown_Click"></asp:LinkButton>
					</div>
                </div>
            </LoggedInTemplate>
        </asp:LoginView>
        <asp:FormView runat="server" ID="FormViewArticleDetails" ItemType="NewsSite.Models.Article" SelectMethod="FormViewArticleDetails_GetItem">
            <ItemTemplate>
                <h2><%#: Item.Title %> <small>Category: <%#: Item.Category.Name %></small></h2>
                <p><%#: Item.Content %></p>
                <p>
                    <span>Author:<%#: Item.Author.UserName %></span>
                    <span class="pull-right"><%#: Item.DateCreated %></span>
                </p>
            </ItemTemplate>
        </asp:FormView>
    </div>

</asp:Content>
