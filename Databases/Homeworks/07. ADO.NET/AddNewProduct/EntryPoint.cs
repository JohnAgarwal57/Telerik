namespace AddNewProduct
{
    using System;
    using System.Data.SqlClient;

    public class EntryPoint
    {
        private SqlConnection dbCon;

        public static void Main(string[] args)
        {
            EntryPoint entry = new EntryPoint();
            try
            {
                entry.ConnectToDB();
                entry.Insert("Test", true);
            }
            finally
            {
                entry.DisconnectFromDB();
            }
        }

        public void Insert(string productName, bool discontinued, int? supplierID = null, int? categoryID = null, string quantityPerUnit = null, decimal? unitPrice = null, short? unitsInStock = null, short? unitsOnOrder = null, short? reorderLevel = null)
        {
            SqlCommand cmdInsertProject = new SqlCommand(
                "INSERT INTO Products(ProductName, Discontinued, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel) VALUES (@productName, @discontinued, @supplierID, @categoryID, @quantityPerUnit, @unitPrice, @unitsInStock, @unitsOnOrder, @reorderLevel)", this.dbCon);

            cmdInsertProject.Parameters.AddWithValue("@productName", productName);
            cmdInsertProject.Parameters.AddWithValue("@discontinued", discontinued);

            SqlParameter sqlParameterSupplierID = new SqlParameter("@supplierID", supplierID);
            if (supplierID == null)
            {
                sqlParameterSupplierID.Value = DBNull.Value;
            }

            cmdInsertProject.Parameters.Add(sqlParameterSupplierID);

            SqlParameter sqlParameterCategoryID = new SqlParameter("@categoryID", categoryID);
            if (categoryID == null)
            {
                sqlParameterCategoryID.Value = DBNull.Value;
            }

            cmdInsertProject.Parameters.Add(sqlParameterCategoryID);

            SqlParameter sqlParameterQuantityPerUnit = new SqlParameter("@quantityPerUnit", quantityPerUnit);
            if (quantityPerUnit == null)
            {
                sqlParameterQuantityPerUnit.Value = DBNull.Value;
            }

            cmdInsertProject.Parameters.Add(sqlParameterQuantityPerUnit);

            SqlParameter sqlParameterUnitPrice = new SqlParameter("@unitPrice", unitPrice);
            if (unitPrice == null)
            {
                sqlParameterUnitPrice.Value = DBNull.Value;
            }

            cmdInsertProject.Parameters.Add(sqlParameterUnitPrice);

            SqlParameter sqlParameterUnitsInStock = new SqlParameter("@unitsInStock", unitsInStock);
            if (unitsInStock == null)
            {
                sqlParameterUnitsInStock.Value = DBNull.Value;
            }

            cmdInsertProject.Parameters.Add(sqlParameterUnitsInStock);

            SqlParameter sqlParameterUnitsOnOrder = new SqlParameter("@unitsOnOrder", unitsOnOrder);
            if (unitsOnOrder == null)
            {
                sqlParameterUnitsOnOrder.Value = DBNull.Value;
            }

            cmdInsertProject.Parameters.Add(sqlParameterUnitsOnOrder);

            SqlParameter sqlParameterReorderLevel = new SqlParameter("@reorderLevel", reorderLevel);
            if (reorderLevel == null)
            {
                sqlParameterReorderLevel.Value = DBNull.Value;
            }

            cmdInsertProject.Parameters.Add(sqlParameterReorderLevel);

            cmdInsertProject.ExecuteNonQuery();
        }

        private void ConnectToDB()
        {
            this.dbCon = new SqlConnection("Server=.\\SQLEXPRESS; Database=NorthWind; Integrated Security=true");
            this.dbCon.Open();
        }

        private void DisconnectFromDB()
        {
            if (this.dbCon != null)
            {
                this.dbCon.Close();
            }
        }
    }
}