use master;
go
drop database if exists assign1_sql_23;
go
create database assign1_sql_23;
go
use assign1_sql_23;
go

drop table if exists customer;
create table customer
(
	cust_id char(10) not null,
	cust_name char(50) not null,
	cust_address char(50),
	cust_city char(50),
	cust_contact char(50),
	cust_phone char(15),
	cust_email char(255),
	constraint pk_cust primary key(cust_id)
);

drop table if exists [order];
create table [order]
(
	order_id integer not null,
	order_date datetime	not null,
	cust_id char(10) not null,
	constraint pk_order primary key(order_id),
	constraint fk_order_customer foreign key(cust_id)
	references customer(cust_id)
);


drop table if exists vendor;
create table vendor
(
	vendor_id char(10) not null,
	vendor_name char(50) not null,
	vendor_address char(50),
	vendor_city char(50),
	vendor_phone char(15),
	constraint pk_vendor primary key(vendor_id)
);


drop table if exists product;
create table product
(
	product_id char(10) not null,
	vendor_id char(10) not null,
	product_name char(255) not null,
	product_price decimal(8,2) not null,
	product_desc varchar(100),
	constraint pk_product primary key(product_id),
	constraint fk_product_vendor foreign key(vendor_id)
	references vendor(vendor_id)
);


--drop table order_item;
create table order_item
(
	order_id integer not null,
	order_item integer not null,
	product_id char(10)	not null,
	quantity integer not null,
	item_price decimal(8,2) not null,
	constraint pk_order_item primary key(order_id, product_id),
	constraint fk_order_item_order foreign key(order_id)
	references [order](order_id),
	constraint fk_order_item_product foreign key(product_id)
	references product(product_id)
);