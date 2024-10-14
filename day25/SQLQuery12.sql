use pubs

--use join mainly 

--1) Print the storeid and number of orders for the store
	SELECT s.stor_id, count(ord_num) no_of_orders FROM stores s
	left join sales sl on s.stor_id= sl.stor_id
	group by s.stor_id
	
	
--2) print the number of orders for every title
	select t.title,count(s.ord_num) number_of_order from titles t 
	left join sales s on s.title_id=t.title_id
	group by t.title

--3) print the publisher name and book name
	select p.pub_name,t.title from publishers p 
	left join titles t on t.pub_id=p.pub_id

--4) Print the author full name for al the authors
	select CONCAT(au_fname,' ', au_lname) author_fullname from authors

--5) Print the price or every book with tax (price + price*12.36/100)
select title_id,title , Round((price + ((price*12.36)/100)),2) price_with_tax from titles

--6) Print the author name, title name
select CONCAT(a.au_fname,' ', a.au_lname) author_name, t.title from authors a 
left join titleauthor ta on ta.au_id=a.au_id 
join titles t on t.title_id=ta.title_id

--7) print the author name, title name and the publisher name
select CONCAT(a.au_fname,' ', a.au_lname) author_name, t.title, p.pub_name from authors a
left join titleauthor ta on ta.au_id=a.au_id
join titles t on t.title_id=ta.title_id
join publishers p on t.pub_id=p.pub_id

select * from titleauthor

--8) Print the average price of books published by every publisher
select p.pub_id, avg(t.price) average_price from publishers p 
left join titles t on t.pub_id=p.pub_id
group by p.pub_id

select * from authors
--9) print the books published by 'Marjorie'
select t.title,au_fname from titles t
join titleauthor ta on t.title_id=ta.title_id
join authors a on a.au_id=ta.au_id
where a.au_fname='Marjorie'

--10) Print the order numbers of books published by 'New Moon Books'
select s.ord_num,p.pub_name from sales s
join titles t on t.title_id=s.title_id
join publishers p on p.pub_id=t.pub_id
where p.pub_name='New Moon Books'

--11) Print the number of orders for every publisher
select p.pub_name,count(s.ord_num) number_of_order from publishers p
left join titles t on t.pub_id=p.pub_id
left join sales s on s.title_id =t.title_id
group by p.pub_name

--12) print the order number , book name, quantity, price and the total price for all orders
select s.ord_num,t.title,s.qty, t.price, (s.qty*t.price) total_price from sales s 
join titles t on s.title_id = t.title_id

--13) print he total order quantity for every book
select t.title,sum(s.qty) total_order_quantity from titles t
left join sales s on s.title_id=t.title_id
group by t.title

--14) print the total order value for every book
select t.title,sum(s.qty*t.price) total_order_value from titles t
left join sales s on s.title_id=t.title_id
group by t.title

--15) print the orders that are for the books published by the publisher for which 'Paolo' works for

select s.ord_num,s.ord_date,t.title, p.pub_name from employee e
join titles t on t.pub_id=e.pub_id
join sales s on s.title_id=t.title_id
join publishers p on p.pub_id=t.pub_id
where e.fname='Paolo'