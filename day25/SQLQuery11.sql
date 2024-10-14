
create procedure GetEmployeeSkills(@eid int)
as 
begin
select * from EmployeesSkills where Employee_id=@eid
end


exec GetEmployeeSkills 1;

select * from Products where CategoryID =3
union all
select * from Products where SupplierID in(2,4,7)

select * from Products where CategoryID =3
union 
select * from Products where SupplierID in(2,4,7)

select * from Products where CategoryID =3
intersect 
select * from Products where SupplierID in(2,4,7)


select * from Products where CategoryID =3
except 
select * from Products where SupplierID in(2,4,7)

select top 5 * from Products order by UnitPrice desc

select distinct SupplierId from Products

select * from Suppliers

select s.SupplierId,s.ContactName, count(p.ProductName) no_of_products from Suppliers s left join Products p on s.SupplierID=p.SupplierID join [Order Details] o on
o.ProductID=p.ProductID group by s.SupplierID, s.ContactName where p.ProductName is null

select * from Orders

select supplierId from Suppliers
except
select distinct  supplierId from Products

select emp.EmployeeID Employee_Id, CONCAT(emp.FirstName, ' ',emp.LastName) Employee_Name, mgr.EmployeeID Manager_Id,CONCAT(mgr.FirstName, ' ',mgr.LastName) ManagerName
From Employees emp left join Employees mgr on emp.ReportsTo=mgr.EmployeeID


select * from products
where UnitPrice>all(select UnitPrice from products where SupplierID in
(select SupplierID from Suppliers where Country = 'Germany'))

select * from products
where UnitPrice> (select max(UnitPrice) from products where SupplierID in
(select SupplierID from Suppliers where Country = 'Germany'))


--stored procedures

use databasecourse07oct2024
