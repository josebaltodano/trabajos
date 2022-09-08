use Northwind

select  YEAR(o.OrderDate)

from [Order Details] as do inner join Orders  o on do.OrderID = o.OrderID



select EmployeeID idempelado, 
LastName nombre,
FirstName apellido,
BirthDate cumpleaños,
getdate() fechaactual,
DATEDIFF(YEAR,BirthDate,GETDATE()) edad,
DATEDIFF(MONTH,BirthDate,GETDATE()) meses
from Employees 

select GETDATE() -1
select DATEDIFF(DAY,GETDATE(),-1 )