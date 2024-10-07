create database databasecourse07oct2024;

use databasecourse07oct2024;

CREATE TABLE Areas(
area varchar(10) constraint pk_area primary key,
zipcode char(6)
);

CREATE TABLE Areas
(area varchar(10) primary key,
zipcode char(6)
)
DROP TABLE Areas;

select * from Areas;

sp_help Areas;

INSERT INTO Areas (area,zipcode) 
values ('imphal','795001'),
('noida','201301');

CREATE TABLE Employees
(id INT IDENTITY(101,1) constraint pk_employee_ID primary key,
name varchar(20) not null,
phone varchar(15),
area varchar(10) constraint fk_area foreign key references Areas(area))


sp_help Employees;

drop table Employees;

INSERT INTO Employees (name,phone,area) values ('Ramu','9876543210','imphal'),
('Samu','98723543210','noida');

select * from Employees;

--error coz of value given to teh identity column
insert into Employees(id,name,phone,area) values(104,'Ramu','9876543210','ABC');

--Foreign key constrint violation
insert into Employees(name,phone,area) values('Ramu','9876543210','KKK');

--Error coz of null to non null column
insert into Employees(name,phone,area) values(null,'9876543210','ABC');


CREATE TABLE Skills
(skill_name varchar(50) constraint pk_skill primary key,
skill_description varchar(1000))

insert into Skills values('C#','Web'),('Java','OOPS'),('SQL','RDBMS')

select * from Skills

CREATE TABLE EmployeesSkills
(Employee_id INT constraint fk_Employee_Skill_id foreign key references Employees(Id),
Employee_Skill varchar(50) constraint fk_Skill foreign key references Skills(skill_name),
skill_level float,
constraint pk_employee_skill primary key(Employee_id,Employee_skill));

-- to remove duplication we add constraint two primary key 

sp_help EmployeesSkills

insert into EmployeesSkills values(101,'C#',7),(101,'SQL',7)
insert into EmployeesSkills values(102,'C#',7),(102,'SQL',7)

select * from EmployeesSkills
--update query 

update EmployeesSkills set skill_level =7.5 where Employee_id=101 and Employee_Skill='C#';

update Employees set phone ='1223233453', area='imphal' where id=101;
