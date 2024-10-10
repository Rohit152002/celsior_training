use Northwind

--1) Select All the  product details
SELECT * FROM Products;

--2) Select the product which are priced more than 10
SELECT * FROM Products WHERE  UnitPrice>10;

--3)  Print the products in the ascending order of price
SELECT * FROM Products ORDER BY UnitPrice;

--4) Print the products that are price between 10 and 25
SELECT * FROM Products where UnitPrice BETWEEN 10 and 25

--5) Print all the products that are packaged in box
SELECT * FROM Products WHERE QuantityPerUnit LIKE '%box%'

--6) Print the products that are available more than 10 units and are restocked
SELECT * FROM Products WHERE UnitsInStock>10

--7) Print the name and price of all the products that are reordered
SELECT ProductName,UnitPrice FROM Products WHERE ReorderLevel IS NOT NULL;

--8) Print all the customers who have no region
SELECT * FROM Customers WHERE Region IS NULL

--9) print the full name of customers
SELECT ContactName AS FullName FROM Customers 

--10) Print the number of customers from every country
SELECT Country,COUNT(CustomerId)'Number of Customers' FROM Customers GROUP BY Country

--11) Count the number of city in every country from which we have customers
SELECT Country,COUNT(distinct City) 'Number of City' FROM Customers GROUP BY Country

--12) Print the total number of sale done by every employee
SELECT EmployeeID, Count(EmployeeID) 'Number of sale' FROM Orders GROUP BY EmployeeID

--13) Print the total freight charge paid by every customer
SELECT CustomerID, SUM(Freight) 'Total Freight Charge' FROM Orders GROUP BY CustomerID ORDER BY SUM(Freight) DESC


--14) Print the total number of times every product was ordered
SELECT ProductID , COUNT(ProductID) 'Number of ordered' FROM "Order Details"
GROUP BY ProductID



--15) Print the average price of the products in descending order for every category. Consider the category only if we have more than 2 products in it
SELECT CategoryID ,
   AVG(UnitPrice) 'Average Price',
   COUNT(CategoryID) 'number of product'
   FROM Products
GROUP BY CategoryID
HAVING Count(ProductID)>2
ORDER BY AVG(UnitPrice) DESC


