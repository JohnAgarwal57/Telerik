USE [TelerikAcademy]
GO

DECLARE ScanCursor CURSOR READ_ONLY FOR

	SELECT e.FirstName, e.LastName, t.Name, o.FirstName, o.LastName
	FROM Employees e
			INNER JOIN Addresses a ON a.AddressID = e.AddressID
			INNER JOIN Towns t ON t.TownID = a.TownID,
	Employees o
			INNER JOIN Addresses ad ON ad.AddressID = o.AddressID
			INNER JOIN Towns tw ON tw.TownID = ad.TownID               
 
OPEN ScanCursor
DECLARE @EmployeeOneFirstName NVARCHAR(20)
DECLARE @EmployeeOneLastName NVARCHAR(30)
DECLARE @EmployeeTwoFirstName NVARCHAR(20)
DECLARE @EmployeeTwoLastName NVARCHAR(30)
DECLARE @town NVARCHAR(30)

FETCH NEXT FROM ScanCursor INTO @EmployeeOneFirstName, @EmployeeOneLastName, @town, @EmployeeTwoFirstName, @EmployeeTwoLastName
 
WHILE @@FETCH_STATUS = 0
	BEGIN
		PRINT @EmployeeOneFirstName + ' ' + @EmployeeOneLastName +'--' + @town + '--' + @EmployeeTwoFirstName + ' ' + @EmployeeTwoLastName
		FETCH NEXT FROM ScanCursor INTO @EmployeeOneFirstName, @EmployeeOneLastName, @town, @EmployeeTwoFirstName, @EmployeeTwoLastName
	END
 
CLOSE ScanCursor
DEALLOCATE ScanCursor