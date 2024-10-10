use pubs
go


--select query 
select * from publishers

--where clause 
select * from publishers where country='USA'

--same for both for not equal to 
select * from publishers where country!='USA'

select * from publishers where country<>'USA'
--and 
select* from publishers where country= 'USA' and city='Boston'

--or
select * from publishers where country= 'Germany' or city='Paris'

select * from titles

select title,price,notes from titles where price<15
--between 
select title,price from titles where price<=15 and price>=8

select title,price from titles where price between 8 and 15;

select * from titles where type='business' or type='psychology'

--in keyword 
select * from titles where type in ('business','psychology')

select * from titles where type not in ('business','psychology')

select * from titles where price is null;

sp_help titles

select * from titles where title like '%user%'

select * from titles where title like '_he%'

sp_help employee
--select all the employee whose first name has 'e'

select * from employee where fname like '%e%'

--select all the employees who are hired before 1991-10-26
select * from employee where hire_date < '1991-10-26 00:00:00.000'


--select employees who work for the publisher 0877 and is having middle name

select * from employee where pub_id=0877 and minit is not null and minit <> '';


select * from employee order by fname

select * from employee order by fname desc

select * from employee order by pub_id,fname
select * from employee where fname like '%e%' order by pub_id

---how many people work for the publisher 0736
select count(emp_id)  from employee
select count(emp_id) as Number_Of_Employees  from employee
select count(emp_id)  Number_Of_Employees  from employee


select min(job_id) Least_Job_Id  from employee

select min(hire_date) First_Hired_Date  from employee


select * from titles
--minimum
select min(price)  least_price from titles
--average
select AVG(price)  average_price from titles where pub_id=1389
--sum
select sum(price)  total_price from titles where type='business'

--subquery 
select * from titles where price = (select max(price) from titles)

--count
select count(title) count_books from titles

--group by 

select pub_id, avg(price) average_price from titles group by pub_id

select * from employee

select pub_id, count(emp_id) number_of_employee from employee group by pub_id

select country, count(pub_id) publishers from publishers group by country

select pub_id, count(emp_id) Number_of_employee from employee
where fname like '%e%' or fname like '%a%'
group by pub_id
having count(emp_id) > 2 
order by count(emp_id) desc