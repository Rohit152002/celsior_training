use pubs


select * from titles
select * from publishers

select * from titles where pub_id=(select pub_id from publishers where pub_name='Binnet & Hardley')

select * from titles where pub_id in (select pub_id from publishers where country='USA')

select pub_id from publishers where country='USA'

select round(14.2323,2)- 14.2300

select round(14.2323,1)- 14.2000

select round(14.2323,0)- 14.0000



SELECT * FROM titles where title_id in 
(SELECT title_id from titleauthor where au_id = 
(select au_id from authors where au_fname='Ann' and au_lname='Dull'))

select * from titles

select * from titleauthor

--print the details of authors who authored the books that sell for more than 15 bucks

SELECT  * FROM authors  where au_id in
(Select au_id from titleauthor where title_id in 
(Select title_id from titles where price>15))


select * from sales where title_id in (
select title_id from titles where pub_id in
(select * from publishers where pub_name='Binnet & Hardley')
)


select concat(substring(title,1,5),'...') titleName from titles


select title_id,title,price,pub_id, Rank() over( order by pub_id) PublisherRank from titles


SELECT 
    title_id, 
    title, 
    price, 
    pub_id,
	RANK() OVER (ORDER BY pub_id) AS PublisherRank
FROM (
    SELECT 
        title_id, 
        title, 
        price, 
        pub_id, 
        RANK() OVER (ORDER BY pub_id) AS PublisherRank
    FROM 
        titles
) AS RankedTitles
WHERE 
    PublisherRank = 1;


--inner join

select 
pub_name PublishersName ,
title BookName  
from publishers join titles 
on 
publishers.pub_id = titles.pub_id

select * from [Order Details]

se
select * from sales

select title  BookName, qty,payterms from titles join sales on titles.title_id = sales.title_id

select
ord_num Order_Number,
t.title_id,
title Book_Name,
qty Number_Of_Books_Sold
from sales s inner join titles t
on
s.title_id = t.title_id


--print the employee full name and his job_id and job description

SELECT CONCAT(fname,' ',lname) FullName, e.job_id , job_desc from employee e inner join jobs j on e.job_id=j.job_id
select * from employee

select job_desc,count(e.emp_id) no_of_employee from jobs j inner join employee e on j.job_id=e.job_id group by j.job_desc


select * from authors
select concat(au_fname,' ',au_lname) 'Author name', title 'Book Name',pub_name 'Publisher Name'
from authors a left join titleauthor ta
on a.au_id = ta.au_id
left join titles t
on t.title_id = ta.title_id
full join publishers p
on p.pub_id = t.pub_id
order by a.au_id


--outer join
--left outer join
select 
pub_name PublishersName ,
title BookName  
from publishers  left outer join titles 
on 
publishers.pub_id = titles.pub_id

--right outer join
select 
title BookName  ,
pub_name PublishersName 
from  titles right outer join  publishers
on 
publishers.pub_id = titles.pub_id