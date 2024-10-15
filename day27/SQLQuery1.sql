use northwind


create table Users(id INT IDENTITY(100,1) Primary Key,username varchar(20),email varchar(30),phone varchar(10), password varchar(20));


select * from users where  
select * from Categories

Select * from Users where username='rohit' and password='intel'
drop table Users

select * from Customers where ;

select * from orders where CustomerID='ALFKI' order by OrderDate desc;

select * from [Order Details] where OrderID in (select OrderID from Orders where CustomerID='ALFKI')
select * from Products



-- order number, customername, products ordered, -- take order no. from user

select od.OrderID as OrderNumber, c.ContactName CustomerName, p.ProductName ProductsOrder  from [Order Details] od 
join Orders o on  od.OrderID=o.OrderId
join Customers c on c.CustomerID=o.CustomerID
join Products p on p.ProductID=od.ProductID
where o.OrderID=11011

update users set password = 'hello' where username='rohit' and password='intel';

select * from Customers
select * from Shippers where ShipperID = (Select shipVia from Orders where OrderID=11011)

sp_help Orders
--previous order 


select * from Orders