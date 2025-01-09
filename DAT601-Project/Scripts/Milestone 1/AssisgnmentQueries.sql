use assign1_sql_23;


-- Query 1
select product_name 
from product
order by product_name asc;




-- Query 2
select product_id, product_price, product_name
from product
order by product_price asc, product_name asc;




-- Query 3
select product_id, product_price, product_name
from product
order by product_price desc, product_name asc;




-- Query 4
select product_name, product_price
from product
where product_price = 3.49;




-- Query 5
select product_name, product_price
from product
where product_price < 10;




-- Query 6
select vendor_id, product_name
from product
where vendor_id != 'dll01';




-- Query 7
select product_name, product_price
from product
where product_price between 5 and 10;




-- Query 8
select product_name, product_price
from product
where product_price >= 10 and (vendor_id = 'dll01' or vendor_id = 'brs01');




-- Query 9
select avg(product_price) as average_price
from product;




-- Query 10
select count(cust_id) as total_customers
from customer;




-- Query 11
select count(cust_email) as emails
from customer;




-- Query 12
select count(product_id) as total,
	   min(product_price) as minimum, max(product_price) as maximum, avg(product_price) as average
from product;




-- Query 13
select v.vendor_name, p.product_name, p.product_price
from product p
	join vendor v on v.vendor_id = p.vendor_id;




-- Query 14
select p.product_name, v.vendor_name, p.product_price, oi.quantity
from product p
	join vendor v on v.vendor_id = p.vendor_id
	join order_item oi on oi.product_id = p.product_id
where oi.order_id = 20007
order by vendor_name;




-- Query 15
select cust_name, cust_contact
from customer
where cust_id in (
	select cust_id 
	from [order]
	where order_id in (
		select order_id
		from order_item
		where product_id = 'rgan01'
	)
)




-- Query 16
select c.cust_name, c.cust_city, count(o.order_id) as total
from [order] o
	right join customer c on c.cust_id = o.cust_id
where c.cust_id in (
	select cust_id
	from customer
)
group by o.cust_id, c.cust_name, c.cust_city
order by c.cust_name;

-- works without sub-query
select c.cust_name, c.cust_city, count(o.order_id) as total
from [order] o
	right join customer c on c.cust_id = o.cust_id
group by o.cust_id, c.cust_name, c.cust_city
order by c.cust_name;





-- Query 17
-- using only where clause
select cust_name, cust_contact, cust_email
from customer
where cust_city = 'nelson' or cust_city = 'wellington' or cust_name = 'fun4all'
order by cust_name, cust_contact;

-- using a sub query
select cust_name, cust_contact, cust_email
from customer
where cust_name in (
	select cust_name
	from customer
	where cust_city = 'nelson' or cust_city = 'wellington' or cust_name = 'fun4all'
)
order by cust_name, cust_contact;

-- using a union
select cust_name, cust_contact, cust_email
from customer
where cust_city = 'nelson' or cust_city = 'wellington'
union
select cust_name, cust_contact, cust_email
from customer
where cust_name = 'fun4all'
order by cust_name, cust_contact;




-- Query 18
drop view if exists vProductCustomer;
go
create view vProductCustomer
as
	select c.cust_id, c.cust_name, c.cust_contact, o.order_id, o.order_date, oi.item_price, oi.order_item, oi.quantity, oi.product_id
	from customer c
		inner join [order] o on o.cust_id = c.cust_id
		inner join order_item oi on oi.order_id = o.order_id;
go

select cust_name, cust_contact
from vProductCustomer
where product_id = 'rgan01';





-- Query 19
insert into customer (cust_id, cust_name, cust_phone)
values ('1000000006', 'the toy emporium','09-546-8552');

-- Including null values
drop view if exists vCustomerMailingLabel;
go
create view vCustomerMailingLabel as
select cust_name, cust_address, concat(trim(isnull(cust_city, 'NULL')), ', ', cust_phone) as 'city/phone'
from customer;
go
select * from vCustomerMailingLabel;

-- excluding null values
drop view if exists vCustomerMailingLabel;
go
create view vCustomerMailingLabel as
select cust_name, cust_address, concat(trim(isnull(cust_city, 'NULL')), ', ', cust_phone) as 'city/phone'
from customer
where cust_address is not null
and cust_city is not null
and cust_phone is not null;
go

select * from vCustomerMailingLabel;


-- select * from [order];
-- select * from customer;