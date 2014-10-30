<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Continents.Web.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="css/site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:EntityDataSource ID="ContinentDataSource" runat="server" 
            ConnectionString="name=ContinentsEntities" 
            DefaultContainerName="ContinentsEntities" 
            EnableDelete="True" 
            EnableFlattening="False" 
            EnableInsert="True" 
            EnableUpdate="True" 
            EntitySetName="Continents">
        </asp:EntityDataSource>
        <asp:EntityDataSource ID="CountriesDataSource" runat="server" 
            ConnectionString="name=ContinentsEntities" 
            DefaultContainerName="ContinentsEntities" 
            EnableDelete="True" 
            EnableFlattening="False" 
            EnableInsert="True" 
            EnableUpdate="True" 
            EntitySetName="Countries"
            Include="Language"
            Where="it.ContinentId=@ContinentId">
            <WhereParameters>
                <asp:ControlParameter Name="ContinentId" Type="Int32"
                    ControlID="ListBoxContinents" />
            </WhereParameters>
        </asp:EntityDataSource>
        <asp:EntityDataSource ID="TownsDataSource" runat="server" 
            ConnectionString="name=ContinentsEntities" 
            DefaultContainerName="ContinentsEntities" 
            EnableDelete="True" 
            EnableFlattening="False" 
            EnableInsert="True" 
            EnableUpdate="True" 
            EntitySetName="Towns"
            Include="Country"
            Where="it.CountryId=@CountryId">
            <WhereParameters>
                <asp:ControlParameter Name="CountryId" Type="Int32"
                    ControlID="GridViewCountries" />
            </WhereParameters>
        </asp:EntityDataSource>
        <asp:EntityDataSource ID="CountryNameDataSource" runat="server" 
            ConnectionString="name=ContinentsEntities"
            DefaultContainerName="ContinentsEntities" 
            EntitySetName="Countries" EnableFlattening="False">
        </asp:EntityDataSource>
        <asp:EntityDataSource ID="LanguageNameDataSource" runat="server" 
            ConnectionString="name=ContinentsEntities"
            DefaultContainerName="ContinentsEntities" 
            EntitySetName="Languages" EnableFlattening="False">
        </asp:EntityDataSource>

        <h3>Continents:</h3>
        <asp:ListBox ID="ListBoxContinents" runat="server" 
            DataSourceID="ContinentDataSource" 
            DataTextField="Name"  DataValueField="Id"
            AutoPostBack="True" 
            Rows="7">
        </asp:ListBox>


        <h3>Countries:</h3>
        <asp:GridView ID="GridViewCountries" runat="server" class="table table-striped table-hover" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="CountriesDataSource">
            <Columns>
                <asp:CommandField ShowEditButton="True" ShowSelectButton="True" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Population" HeaderText="Population" SortExpression="Population" />
                <asp:BoundField DataField="Language.Name" HeaderText="Language" SortExpression="LanguageId" />
            </Columns>
        </asp:GridView>


        <h3>Towns</h3>
        <asp:ListView ID="ListViewTowns" runat="server" DataSourceID="TownsDataSource" DataKeyNames="Id" InsertItemPosition="LastItem">
            <EditItemTemplate>
                <li style="background-color: #008A8C;color: #FFFFFF;">
                    Name:
                    <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                    <br />
                    Population:
                    <asp:TextBox ID="PopulationTextBox" runat="server" Text='<%# Bind("Population") %>' />
                    <br />
                    Country:
                    <asp:TextBox ID="CountryIdTextBox" runat="server" Text='<%# Bind("Country.Name") %>' />
                    <br />
                    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                </li>
            </EditItemTemplate>
            <EmptyDataTemplate>
                No data was returned.
            </EmptyDataTemplate>
            <InsertItemTemplate>
                <div class="well">
                    <b>Name:</b>
                    <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                    <br />
                    <b>Population:</b>
                    <asp:TextBox ID="PopulationTextBox" runat="server" Text='<%# Bind("Population") %>' />
                    <br />
                    <b>Country:</b>
                    <asp:DropDownList ID="CountryIDropDownList" runat="server" 
                        DataSourceID="CountryNameDataSource"
                        DataValueField="Id"
                        DataTextField="Name"
                        SelectedValue="<%# BindItem.Id %>"
                        AppendDataBoundItems="true">
                    </asp:DropDownList>
                    <br />
                    <asp:Button ID="InsertButton" runat="server" class="btn btn-primary"  CommandName="Insert" Text="Insert" />
                    <asp:Button ID="CancelButton" runat="server" class="btn btn-primary" CommandName="Cancel" Text="Clear" />
                </div>
            </InsertItemTemplate>
            <ItemSeparatorTemplate>
                <br />
            </ItemSeparatorTemplate>
            <ItemTemplate>
                <div class="well">
                    <b>Name:</b>
                    <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                    <br />
                    <b>Population:</b>
                    <asp:Label ID="PopulationLabel" runat="server" Text='<%# Eval("Population") %>' />
                    <br />
                    <b>Country:</b>
                    <asp:Label ID="CountryIdLabel" runat="server" Text='<%# Eval("Country.Name") %>' />
                    <br />
                    <asp:Button ID="EditButton" runat="server" class="btn btn-primary" CommandName="Edit" Text="Edit" />
                    <asp:Button ID="DeleteButton" runat="server" class="btn btn-primary" CommandName="Delete" Text="Delete" />
                </div>
            </ItemTemplate>
            <LayoutTemplate>
                <ul id="itemPlaceholderContainer" runat="server" style="font-family: Verdana, Arial, Helvetica, sans-serif;">
                    <li runat="server" id="itemPlaceholder" />
                </ul>
                <div style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                    <asp:DataPager ID="DataPager1" runat="server">
                        <Fields>
                            <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                            <asp:NumericPagerField />
                            <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                        </Fields>
                    </asp:DataPager>
                </div>
            </LayoutTemplate>
        </asp:ListView>     
    </form>
</body>
</html>
