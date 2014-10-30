<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="NestedMasterPages.MainPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="well text-center">
        <h2>Wellcome to our website</h2>
        <h3>Please choose language</h3>
        <asp:HyperLink runat="server" NavigateUrl="~/Bulgarian/Home.aspx" 
            Text="Български" CssClass="bulgarian-icon"/>
        <asp:HyperLink runat="server" NavigateUrl="~/English/Home.aspx"
            Text="English" CssClass="english-icon"/>
        <asp:HyperLink runat="server" NavigateUrl="~/Arabic/Home.aspx"
            Text="العربية" CssClass="arabic-icon"/>
    </div>
</asp:Content>
