<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="Friends.aspx.cs" Inherits="MasterPages.Friends" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
        <div class="well">
        <h2>My friends</h2>
        <ul>
            <li>
                <h3>Kaya</h3>
                <img src="/img/Kaya.jpg" alt="Kaya" />
            </li>
            <li>
                <h3>Pesho</h3>
                <img src="/img/Pesho.jpg" alt="Pesho" />
            </li>
            <li>
                <h3>Gosho</h3>
                <img src="/img/Gosho.jpg" alt="Gosho" />
            </li>
            <li>
                <h3>Dragan</h3>
                <img src="/img/Dragan.jpg" alt="Dragan" />
            </li>
        </ul>
    </div>
</asp:Content>
