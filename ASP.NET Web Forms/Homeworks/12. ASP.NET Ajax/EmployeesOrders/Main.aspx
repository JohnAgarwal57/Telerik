<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="EmployeesOrders.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">   
        <asp:ScriptManager ID="ScriptManager" runat="server" />
            
        <asp:GridView ID="GridViewEmployees" runat="server" DataSourceID="EmployeesDataSource" AutoGenerateColumns="False" DataKeyNames="EmployeeID">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" />
                <asp:BoundField DataField="HomePhone" HeaderText="HomePhone" SortExpression="HomePhone" />
            </Columns>
        </asp:GridView>
        <asp:EntityDataSource ID="EmployeesDataSource" runat="server" ConnectionString="name=NorthwindEntities" DefaultContainerName="NorthwindEntities" EnableFlattening="False" EntitySetName="Employees">
        </asp:EntityDataSource>

        <asp:UpdateProgress ID="UpdateProgress" runat="server">
            <ProgressTemplate>
                <img src="img/loading.jpeg" alt="Loading..." />
            </ProgressTemplate>
        </asp:UpdateProgress>

        <asp:UpdatePanel ID="UpdatePanelFavoriteDrink" runat="server" class="panel" UpdateMode="Conditional">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="GridViewEmployees" EventName="SelectedIndexChanged" />
            </Triggers>
            <ContentTemplate>
                <asp:GridView ID="GridViewOrders" runat="server" AutoGenerateColumns="False" DataSourceID="OrdersDataSource" OnLoad="GridViewOrders_Load" DataKeyNames="OrderID" AllowPaging="True" AllowSorting="True">
                    <Columns>
                        <asp:BoundField DataField="OrderDate" HeaderText="OrderDate" SortExpression="OrderDate" />
                        <asp:BoundField DataField="RequiredDate" HeaderText="RequiredDate" SortExpression="RequiredDate" />
                        <asp:BoundField DataField="ShippedDate" HeaderText="ShippedDate" SortExpression="ShippedDate" />
                        <asp:BoundField DataField="Shipper.CompanyName" HeaderText="ShipVia" SortExpression="ShipVia" />
                        <asp:BoundField DataField="Freight" HeaderText="Freight" SortExpression="Freight" />
                        <asp:BoundField DataField="ShipName" HeaderText="ShipName" SortExpression="ShipName" />
                        <asp:BoundField DataField="ShipAddress" HeaderText="ShipAddress" SortExpression="ShipAddress" />
                        <asp:BoundField DataField="ShipCity" HeaderText="ShipCity" SortExpression="ShipCity" />
                        <asp:BoundField DataField="ShipRegion" HeaderText="ShipRegion" SortExpression="ShipRegion" />
                        <asp:BoundField DataField="ShipPostalCode" HeaderText="ShipPostalCode" SortExpression="ShipPostalCode" />
                        <asp:BoundField DataField="ShipCountry" HeaderText="ShipCountry" SortExpression="ShipCountry" />
                    </Columns>
                </asp:GridView>
                <asp:EntityDataSource ID="OrdersDataSource" runat="server" ConnectionString="name=NorthwindEntities" DefaultContainerName="NorthwindEntities" EnableFlattening="False" EntitySetName="Orders" Where="it.EmployeeId=@EmployeeID" Include="Shipper">
                    <WhereParameters>
                        <asp:ControlParameter Name="EmployeeID" Type="Int32" ControlID="GridViewEmployees" />
                    </WhereParameters>
                </asp:EntityDataSource>

            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
