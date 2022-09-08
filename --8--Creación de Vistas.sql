--8--Creaci�n de Vistas
/*===============================================================*/

use Northwind

/* Una vista es una tabla virtual cuyo contenido est� definido por una consulta. 
Al igual que una tabla, una vista consta de un conjunto de columnas y filas de datos con un nombre.
Una vista act�a como filtro de las tablas subyacentes a las que se hace referencia en ella. */

CREATE VIEW Categorias
AS
SELECT CategoryID,CategoryName,Description
FROM Categories

SELECT *
FROM Categorias --Para llamar a la vista creada:
/*************************************************/
CREATE VIEW Vista_Products
AS
SELECT ProductID ,ProductName, QuantityPerUnit, UnitPrice
FROM Products

SELECT *
FROM Vista_Products --Para llamar a la vista creada:

/*************************************************/
--Si queremos modificar la vista del ejemplo 2 agreg�ndole un nuevo campo, 
-- se puede hacer con el comando ALTER de la siguiente manera
ALTER VIEW Vista_Products
AS
SELECT ProductID, ProductName, QuantityPerUnit, UnitPrice,UnitsInStock
FROM Products

SELECT *
FROM Vista_Products

/******************************************************/
--Las vistas se pueden utilizar como tablas. Para eliminar una vista se utiliza DROP
--Ejemplo:
DROP VIEW Vista_Products

/*************************************************************/
CREATE VIEW VIEW_SUBTOTALES
AS
SELECT OD.ORDERID,SUM(CONVERT(MONEY,(OD.UNITPRICE* QUANTITY*(1-DISCOUNT)/100) )*100) AS SUBTOTAL
FROM [ORDER DETAILS] OD
GROUP BY OD.ORDERID


SELECT *
FROM VIEW_SUBTOTALES

/*************************************************/
--CREACI�N DE VISTA PROVEEDORES Y SUS PEDIDOS

CREATE VIEW VIEW_SUPPLIER_PRODUCS
AS
SELECT S.SUPPLIERID,S.COMPANYNAME,S.CONTACTNAME
,P.PRODUCTID,P.PRODUCTNAME, P.UNITPRICE
FROM SUPPLIERS AS S INNER JOIN PRODUCTS AS P
ON
S.SUPPLIERID=P.SUPPLIERID

--altera una vista usado inner join
alter view  VIEW_SUPPLIER_PRODUCS
as
select S.SUPPLIERID,S.COMPANYNAME,S.CONTACTNAME
,P.PRODUCTID,P.PRODUCTNAME, P.UNITPRICE, p.UnitsInStock
FROM SUPPLIERS AS S INNER JOIN PRODUCTS AS P
ON
S.SUPPLIERID=P.SUPPLIERID


SELECT *
FROM VIEW_SUPPLIER_PRODUCS


