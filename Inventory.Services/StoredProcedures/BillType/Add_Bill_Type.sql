CREATE OR ALTER PROCEDURE Add_Bill_Type
(
  @BillTypeName NVARCHAR(100),
  @Description NVARCHAR(500)
)
AS
BEGIN
  INSERT INTO BillTypes
  (
    BillTypeName,
    [Description]
  )
  VALUES
  (
    @BillTypeName,
    @Description
  )
END;