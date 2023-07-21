
INSERT INTO Categories values('Electrinicos','Productos Electronicos',null) 
INSERT INTO Categories values('Smarthfones','Telemoveis intelogentes',null) 
INSERT INTO Categories values('Informáticos','Productos Informáticos',null) 
INSERT INTO Categories values('Escritórios','Productos consumíveis para escritórios',null) 
INSERT INTO Categories values('Vestuarios adultos','Vestuario para Adultos',null) 
INSERT INTO Categories values('Vestuarios crianças','Vestuario para Crianças',null) 
GO

SELECT * FROM Categories
GO


WITH Numeros AS (
  SELECT TOP 100
         ROW_NUMBER() OVER(ORDER BY (SELECT NULL)) AS Numero
  FROM master.dbo.spt_values v1, master.dbo.spt_values v2
)
INSERT INTO Products(ProductName, SupplierId,CategoryID,QuantitityPerUbit,UnitPrice,UnitsInStoque,UnitsOnOrder,ReorderLevel,Discontinued)
SELECT 'producto novo' + CAST(Numero AS VARCHAR(10)), 1 ,1,1,15000,25,1,1,1
FROM Numeros;
GO

select * from Products
GO

--delete Products

