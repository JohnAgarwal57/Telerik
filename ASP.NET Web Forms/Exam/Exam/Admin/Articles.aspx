<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Articles.aspx.cs" Inherits="NewsSite.Admin.Articles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server"> 
    
    <asp:ListView runat="server" ID="ListViewArticles" ItemType="NewsSite.Models.Article" SelectMethod="ListViewArticles_GetData" DeleteMethod="ListViewArticles_DeleteItem" UpdateMethod="ListViewArticles_UpdateItem" DataKeyNames="Id">
        <LayoutTemplate>
            <div class="container body-content">  
                <div class="row">
                    <asp:LinkButton Text="Sort by Title" runat="server" ID="LinkButtonSortByTitle" CommandName="Sort" CommandArgument="Title" CssClass="btn btn-default" />
                    <asp:LinkButton Text="Sort by Date" runat="server" ID="LinkButtonSortByDate" CommandName="Sort" CommandArgument="DateCreated" CssClass="btn btn-default" />
                    <asp:LinkButton Text="Sort by Category" runat="server" ID="LinkButtonSortByCategory" CommandName="Sort" CommandArgument="CategoryId" CssClass="btn btn-default" />
                    <asp:LinkButton Text="Sort by Likes" runat="server" ID="LinkButtonSortByLikes" CommandName="Sort"  CommandArgument="LikesCount" CssClass="btn btn-default" />
		        </div>
                <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
                <div class="row">
                    <asp:DataPager runat="server" ID="DataPagerCategories" PagedControlID="ListViewArticles" PageSize="3">
                        <Fields>
                            <asp:NextPreviousPagerField ShowNextPageButton="False" ButtonCssClass="previousNextLink" />
                            <asp:NumericPagerField ButtonCount="10" ButtonType="Link" NumericButtonCssClass="numericLink" />
                            <asp:NextPreviousPagerField ShowPreviousPageButton="False" ButtonCssClass="previousNextLink" />                
                        </Fields>
                    </asp:DataPager>
                </div>
        </LayoutTemplate>
        <ItemTemplate>
            <div class="row">
                <h3>
                    <%#: Item.Title %>
                    <asp:LinkButton runat="server" ID="LinkButtonEdit" Text="Edit" CommandName="Edit" CssClass="btn btn-info" />
                    <asp:LinkButton runat="server" ID="LinkButtonDelete" Text="Delete" CommandName="Delete" CssClass="btn btn-danger" />
                </h3>
                <p><%#: Item.Category.Name %></p>
                <p><%#: Item.Content.Substring(0, Math.Min(Item.Content.Length, 300)) %>...</p>
                <p>Likes count: <%#: Item.Likes.Count %></p>
			    <div>
				    <i>by <%#: Item.Author.UserName %></i>
				    <i>created on: <%#: Item.DateCreated %></i>
			    </div>
            </div>
            
        </ItemTemplate>
        <EditItemTemplate>
            <div class="row">
                <div>
                    <h3>
                        <asp:TextBox runat="server" ID="TextBoxTitle" Text="<%#: BindItem.Title %>" CssClass="width:300px" />
                        <asp:RequiredFieldValidator  ID="RequiredFieldValidatorTitle" ControlToValidate="TextBoxTitle" runat="server" Display="Dynamic" Text="Title is required!" ErrorMessage="Name is required!" ForeColor="Red" EnableClientScript="true"/>
                        <asp:LinkButton runat="server" ID="LinkButtonEdit" Text="Save" CommandName="Update" CssClass="btn btn-success" />
                        <asp:LinkButton runat="server" ID="LinkButtonDelete" Text="Cancel" CommandName="Cancel" CssClass="btn btn-danger" />
                    </h3>
                    <br />
                </div>
                <div>
                    <asp:DropDownList runat="server" ID="DropDownListCategoriesCreate" DataTextField="Name" DataValueField="Id" ItemType="NewsSite.Models.Category" SelectedValue="<%#: BindItem.CategoryId %>" SelectMethod="DropDownListCategoriesCreate_GetData">
                    </asp:DropDownList>
                    <br />
                </div>
                <div>
                    <asp:TextBox runat="server" ID="TextBoxContent" Text="<%#: BindItem.Content %>" TextMode="MultiLine" Columns="200" Rows="5"/>
                    <asp:RequiredFieldValidator  ID="RequiredFieldValidatorContent" ControlToValidate="TextBoxContent" runat="server" Display="Dynamic" Text="Content is required!" ErrorMessage="Content is required!" ForeColor="Red" EnableClientScript="true"/>
                </div>
            </div>
        </EditItemTemplate>

        <EmptyDataTemplate>
            No articles
        </EmptyDataTemplate>
    </asp:ListView>

    <div runat="server" id="btnWrapper">
        <asp:LinkButton Text="Insert new Article" ID="LinkButtonInsert" runat="server" OnClick="LinkButtonInsert_Click" CssClass="btn btn-info pull-right" />
    </div>

    <asp:UpdatePanel runat="server" ID="UpdatePanelInsertBook" CssClass="panel">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="LinkButtonInsert" EventName="Click" />
        </Triggers>
        <ContentTemplate>
            <asp:FormView runat="server" ID="FormViewInsertArticle" DefaultMode="Insert" ItemType="NewsSite.Models.Article"
                InsertMethod="FormViewInsertArticle_InsertItem" Visible="false">
                <InsertItemTemplate>
                    <div>
                        <h3>Title:</h3>
                        <asp:TextBox runat="server" ID="TextBoxBookTitleCreate" Text=" <%#: BindItem.Title %>"></asp:TextBox>
                        <asp:RequiredFieldValidator  ID="RequiredFieldValidatorTitle" ControlToValidate="TextBoxBookTitleCreate" runat="server" Display="Dynamic" Text="Title is required!" ErrorMessage="Title is required!" ForeColor="Red" EnableClientScript="true"/>

                    </div>
                    <div>
                        <span>Category:</span>
                        <asp:DropDownList runat="server" ID="DropDownListCategoriesCreate" DataTextField="Name" DataValueField="ID" ItemType="NewsSite.Models.Category" SelectedValue="<%#: BindItem.CategoryId %>" SelectMethod="DropDownListCategoriesCreate_GetData">
                        </asp:DropDownList>
                    </div>
                    <div>
                        <asp:TextBox runat="server" ID="TextBoxContent" Text="<%#: BindItem.Content %>" TextMode="MultiLine" Columns="200" Rows="5"/>
                        <asp:RequiredFieldValidator  ID="RequiredFieldValidatorContent" ControlToValidate="TextBoxContent" runat="server" Display="Dynamic" Text="Content is required!" ErrorMessage="Content is required!" ForeColor="Red" EnableClientScript="true"/>
                    </div>
                    <asp:LinkButton runat="server" ID="LinkButtonCreate" CssClass="btn btn-success" Text="Create" CommandName="Insert"  />
                    <asp:LinkButton runat="server" ID="LinkButtonCancel" CssClass="btn btn-danger" Text="Cancel" CommandName="Cancel" PostBackUrl="~/Admin/Articles.aspx" />
                </InsertItemTemplate>
            </asp:FormView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
