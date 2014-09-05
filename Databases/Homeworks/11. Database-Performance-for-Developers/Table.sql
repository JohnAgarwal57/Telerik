DECLARE @RunDate datetime
SET @RunDate=GETDATE()
CREATE TABLE NumbersTest (Id integer NOT NULL, Info nvarchar(100), InfoDate DateTime);
DECLARE @i INT;
SELECT @i = 1;
SET NOCOUNT ON
WHILE @i <= 10000000
BEGIN
	DECLARE @d INT;
	Select @d = RAND()*30 + 1;
    INSERT INTO dbo.NumbersTest(Id, Info , InfoDate) VALUES (@i, @d, convert(datetime, CAST(@d as varchar) + '-06-12 10:34:09 PM',5))
    SELECT @i = @i + 1;
END;
SET NOCOUNT OFF
ALTER TABLE NumbersTest ADD CONSTRAINT PK_NumbersTest PRIMARY KEY CLUSTERED (Id)
PRINT CONVERT(varchar(20),datediff(ms,@RunDate,GETDATE())/1000.0)+' seconds'
SELECT COUNT(*) FROM NumbersTest