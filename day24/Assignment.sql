--1) Learn what is cross join
--Use Northwind database for the following queries
use Northwind

--2) Print the product from the category 'Dairy Products'
SELECT * FROM Products  WHERE CategoryID=
(SELECT CategoryID FROM Categories WHERE CategoryName='Dairy Products')

--3) Print the products supplied by 'Tokyo Traders'
SELECT * FROM Products WHERE SupplierID = (
SELECT SupplierID FROM Suppliers WHERE CompanyName='Tokyo Traders')

--4) Print the categories in which 'Tokyo Traders' supply products
SELECT * FROM Categories WHERE CategoryID in (
SELECT CategoryID FROM Products WHERE SupplierID=(
SELECT SupplierID FROM Suppliers WHERE CompanyName='Tokyo Traders'))

--5) Print all orders by customers from 'Spain'
SELECT * FROM Orders WHERE ShipCountry='Spain'


--6) Print the Customer name and the freight charge
SELECT ContactName, Freight FROM Customers c join Orders o on c.CustomerID=o.CustomerID 

--7) Print product name and quantity sold for all orders
SELECT ProductName,Quantity FROM Products p JOIN [Order Details] o on p.ProductID=o.ProductID 


--8) print the products that are billed and the unbilled products with the price and sale price and the difference
SELECT p.ProductName, p.UnitPrice price, o.UnitPrice sale_price, (p.UnitPrice - o.UnitPrice) Difference FROM Products p left join [Order Details] o on p.ProductID=o.ProductID

--9) Print the order number, Customer name, Product name and the quantity sold for all orders
SELECT o.OrderID,p.ProductName ,c.ContactName,o.Quantity FROM [Order Details] o 
JOIN Products p on  o.ProductID =p.ProductID
JOIN  Orders od on od.OrderID=o.OrderID
JOIN Customers c on c.CustomerID=od.CustomerID

--10) Print the total order amount for every order(price*quantity)+freight
SELECT o.OrderID,SUM( (od.UnitPrice * od.Quantity)+o.Freight) total_Amount FROM Orders o
JOIN  [Order Details] od ON od.OrderID=o.OrderID  GROUP BY o.OrderID



--11) Print the customer name, Phone, shipper name, phone for every order

SELECT c.ContactName AS 'Customer Name',c.Phone as 'Customer Phone', s.CompanyName as Supplier_Name,s.Phone as Supplier_Phone FROM Orders o JOIN Shippers s ON o.ShipVia=s.ShipperID JOIN Customers c on c.CustomerID=o.CustomerID

--12) print the shipper name and number of order by the shipper and the total freight charge

SELECT  s.CompanyName,COUNT(o.OrderID) No_of_order, SUM(Freight) Total_Freight
FROM Orders o
JOIN Shippers s ON s.ShipperID=o.ShipVia 
GROUP BY s.CompanyName
--13) Print the product name, customer name, total quantity bought for all products sold by employees from 'USA'
SELECT p.ProductName, c.ContactName Customer_Name,sum(od.Quantity) TotalQuantity FROM Orders o 
JOIN Customers c on  c.CustomerID=o.CustomerID
JOIN [Order Details] od on od.OrderID=o.OrderID
JOIN Products p on p.ProductID= od.ProductID 
WHERE o.EmployeeID in (SElECT EmployeeID FROM Employees WHERE Country='USA')
group by p.ProductName,c.ContactName

select * from Employees

--14) Print the product name, category and the total sale amount sorted by category, Include all products and all categories
SELECT p.ProductName,c.CategoryID,sum(od.UnitPrice*od.Quantity) total_sale_amount FROM Products p 
LEFT JOIN Categories c on p.CategoryID=c.CategoryID
LEFT JOIN [Order Details] od on od.ProductID=p.ProductID
GROUP BY p.ProductName,c.CategoryID
ORDER BY c.CategoryID

--15) Print the category name and the total sale for category for all

SELECT c.CategoryName,Count(od.OrderID) Total_sale FROM [Order Details] od 
JOIN Orders o ON od.OrderID=o.OrderID
JOIN Products p ON p.ProductID=od.ProductID
JOIN Categories c ON c.CategoryID=p.CategoryID
GROUP BY c.CategoryName