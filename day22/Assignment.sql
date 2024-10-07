CREATE DATABASE EmployeeDatabase

USE EmployeeDatabase

CREATE TABLE Employees(
employee_no INT IDENTITY(1,1) CONSTRAINT emp_no PRIMARY KEY,
employee_name VARCHAR(10),salary INT , 
department_name VARCHAR(10) CONSTRAINT dept_name FOREIGN KEY REFERENCES Department(department_name) null,
boss_no INT CONSTRAINT boss_key FOREIGN KEY REFERENCES Employees(employee_no) null
);

CREATE TABLE Department (
department_name VARCHAR(10) CONSTRAINT dept_key PRIMARY KEY,
dept_floor int,
phone varchar(10),
mgr_id int 
)


ALTER TABLE Department 
DROP Column mgr_id

ALTER TABLE Department
ADD mgr_id INT CONSTRAINT fk_emp_id FOREIGN KEY REFERENCES Employees(employee_no) not null;

CREATE TABLE Item(
itemname VARCHAR(200) CONSTRAINT item_name PRIMARY KEY,
itemtype VARCHAR(200) ,
itemColor VARCHAR(200),
)

drop table Item

drop table Sales

CREATE TABLE Sales(
salesNo INT IDENTITY(101,1) CONSTRAINT sales_key PRIMARY KEY,
saleQuantity INT ,
itemName VARCHAR(200) CONSTRAINT fk_item_name FOREIGN KEY REFERENCES Item(itemname) ,
department_name VARCHAR(10) CONSTRAINT fk_sales_dept_name FOREIGN KEY REFERENCES Department(department_name) null,
)

ALTER TABLE Sales 
ADD  deptName VARCHAR(10) CONSTRAINT fk_sales_dept FOREIGN KEY REFERENCES Department(department_name);

EXEC sp_help Employees;

EXEC sp_help Department;

EXEC sp_help Sales;

EXEC sp_help Item;



--INserting 

INSERT INTO Employees (employee_name, salary, boss_no, department_name) VALUES 
('Ned', 45000, 1, NULL),
('Andrew', 25000, 2, NULL),
('Clare', 22000, 2, NULL),
('Todd', 38000, 1, NULL),
('Nancy', 22000, 5, NULL),
('Brier', 43000, 1, NULL),
('Sarah', 56000, 7, NULL),
('Sophia', 35000, 1, NULL),
('Sanjay', 15000, 3, NULL),
('Rita', 15000, 4, NULL),
('Gigi', 16000, 4, NULL),
('Maggie', 11000, 4, NULL),
('Paul', 15000, 3, NULL),
('James', 15000, 3, NULL),
('Pat', 15000, 3, NULL),
('Mark', 15000, 3, NULL);


--inserting department tables

INSERT INTO DEPARTMENT (department_name, dept_floor, phone, mgr_id) VALUES 
('Management', 5, 34, 1),
('Books', 1, 81, 4),
('Clothes', 2, 24, 4),
('Equipment', 3, 57, 3),
('Furniture', 4, 14, 3),
('Navigation', 1, 41, 3),
('Recreation', 2, 29, 4),
('Accounting', 5, 35, 5),
('Purchasing', 5, 36, 7),
('Personnel', 5, 37, 9),
('Marketing', 5, 38, 2);


INSERT INTO Item (itemname, itemtype, itemColor) VALUES 
('Pocket Knife-Nile', 'E', 'Brown'),
('Pocket Knife-Avon', 'E', 'Brown'),
('Compass', 'N', NULL),
('Geo positioning system', 'N', NULL),
('Elephant Polo stick', 'R', 'Bamboo'),
('Camel Saddle', 'R', 'Brown'),
('Sextant', 'N', NULL),
('Map Measure', 'N', NULL),
('Boots-snake proof', 'C', 'Green'),
('Pith Helmet', 'C', 'Khaki'),
('Hat-polar Explorer', 'C', 'White'),
('Exploring in 10 Easy Lessons', 'B', NULL),
('Hammock', 'F', 'Khaki'),
('How to win Foreign Friends', 'B', NULL),
('Map case', 'E', 'Brown'),
('Safari Chair', 'F', 'Khaki'),
('Safari cooking kit', 'F', 'Khaki'),
('Stetson', 'C', 'Black'),
('Tent - 2 person', 'F', 'Khaki'),
('Tent - 8 person', 'F', 'Khaki');


INSERT INTO Sales (saleQuantity, itemName, department_name) VALUES 
(2, 'Boots-snake proof', 'Clothes'),
(1, 'Pith Helmet', 'Clothes'),
(1, 'Sextant', 'Navigation'),
(3, 'Hat-polar Explorer', 'Clothes'),
(5, 'Pith Helmet', 'Equipment'),
(2, 'Pocket Knife-Nile', 'Clothes'),
(3, 'Pocket Knife-Nile', 'Recreation'),
(1, 'Compass', 'Navigation'),
(2, 'Geo positioning system', 'Navigation'),
(5, 'Map Measure', 'Navigation'),
(1, 'Geo positioning system', 'Books'),
(1, 'Sextant', 'Books'),
(3, 'Pocket Knife-Nile', 'Books'),
(1, 'Pocket Knife-Nile', 'Navigation'),
(1, 'Pocket Knife-Nile', 'Equipment'),
(1, 'Sextant', 'Clothes'),
(1, NULL, 'Equipment'),
(1, NULL, 'Recreation'),
(1, NULL, 'Furniture'),
(1, 'Pocket Knife-Nile', NULL),
(1, 'Exploring in 10 easy lessons', 'Books'),
(1, 'How to win foreign friends', NULL),
(1, 'Compass', NULL),
(1, 'Pith Helmet', NULL),
(1, 'Elephant Polo stick', 'Recreation'),
(1, 'Camel Saddle', 'Recreation');

EXEC sp_tables;

select * from Department;
select * from Employees;
select * from Item;
select * from Sales;

DROP DATABASE EmployeeDatabase;

UPDATE Employees
SET department_name = CASE 
    WHEN employee_no = 1 THEN 'Management'
    WHEN employee_no = 2 THEN 'Marketing'
    WHEN employee_no = 3 THEN 'Marketing'
    WHEN employee_no = 4 THEN 'Marketing'
    WHEN employee_no = 5 THEN 'Accounting'
    WHEN employee_no = 6 THEN 'Accounting'
    WHEN employee_no = 7 THEN 'Purchasing'
    WHEN employee_no = 8 THEN 'Purchasing'
    WHEN employee_no = 9 THEN 'Personnel'
    WHEN employee_no = 10 THEN 'Navigation'
    WHEN employee_no = 11 THEN 'Books'
    WHEN employee_no = 12 THEN 'Clothes'
    WHEN employee_no = 13 THEN 'Clothes'
    WHEN employee_no = 14 THEN 'Equipment'
    WHEN employee_no = 15 THEN 'Equipment'
    WHEN employee_no = 16 THEN 'Furniture'
    WHEN employee_no = 17 THEN 'Recreation'
END;



-- Constraints in the Database

-- Employee Table
-- We cannot insert an employee if their department does not exist.
-- We cannot delete a department if there are employees assigned to it.
-- We cannot update the boss number to a non-existent employee.

-- Department Table
-- We cannot insert a manager ID if the manager is not in the employee table.
-- We cannot delete a department if there are employees assigned to it.
-- We cannot change a department name to one that already exists.

-- Item Table
-- We cannot add an item that already exists.
-- We cannot delete an item if there are sales associated with it.

-- Sales Table
-- We cannot insert a sale if the department name or item name does not exist in their respective tables.
-- We cannot change the department name in a sale to one that does not exist in the department table.
