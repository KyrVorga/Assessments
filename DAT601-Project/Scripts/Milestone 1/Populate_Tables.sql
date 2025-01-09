use assign1_sql_23;
go

insert into customer(cust_id,cust_name,cust_address,cust_city,cust_phone,cust_contact,cust_email)
values('1000000001','village toys','200 oak lane','wellington','09-389-2356','john smith','sales@villagetoys.co.nz');

insert into customer(cust_id,cust_name,cust_address,cust_city,cust_phone,cust_contact)
values('1000000002','kids place','333 tahunanui drive','nelson','03-545-6333','michelle green');

insert into customer(cust_id,cust_name,cust_address,cust_city,cust_phone,cust_contact,cust_email)
values('1000000003','fun4all','1 sunny place','nelson','03-548-2285','jim jones','jjones@fun4all.co.nz');

insert into customer(cust_id,cust_name,cust_address,cust_city,cust_phone,cust_contact,cust_email)
values('1000000004','fun4all','829 queen street','auckland','09-368-7894','denise l. stephens','dstephens@fun4all.co.nz');

insert into customer(cust_id,cust_name,cust_address,cust_city,cust_phone,cust_contact)
values('1000000005','the toy store','50 papanui road','christchurch','04-345-4545','kim howard');


insert into [order](order_id,order_date,cust_id)
values(20005,'1999/5/1','1000000001');

insert into [order](order_id,order_date,cust_id)
values(20006,'1999/1/12','1000000003');

insert into [order](order_id,order_date,cust_id)
values(20007,'1999/1/30','1000000004');

insert into [order](order_id,order_date,cust_id)
values(20008,'1999/2/3','1000000005');

insert into [order](order_id,order_date,cust_id)
values(20009, '1999/2/8','1000000001');


insert into vendor(vendor_id, vendor_name, vendor_address, vendor_city, vendor_phone)
values('brs01','bears r us','123 main street','richmond','03-523-8871');

insert into vendor(vendor_id, vendor_name, vendor_address, vendor_city, vendor_phone)
values('bre02','bear emporium','500 park street','auckland','06-396-8854');

insert into vendor(vendor_id, vendor_name, vendor_address, vendor_city, vendor_phone)
values('dll01','doll house inc.','555 high street','motueka','03-455-7898');

insert into vendor(vendor_id, vendor_name, vendor_address, vendor_city, vendor_phone)
values('frb01','furball inc.','1 clifford avenue','nelson','03-546-9978');



insert into product(product_id, vendor_id, product_name, product_price, product_desc)
values('br01', 'brs01', '8 inch teddy bear',5.99,'8 inch teddy bear, comes with cap and jacket');

insert into product(product_id, vendor_id, product_name, product_price, product_desc)
values('br02', 'brs01', '12 inch teddy bear',8.99,'12 inch teddy bear, comes with cap and jacket');

insert into product(product_id, vendor_id, product_name, product_price, product_desc)
values('br03', 'brs01', '18 inch teddy bear',11.99,'18 inch teddy bear, comes with cap and jacket');

insert into product(product_id, vendor_id, product_name, product_price, product_desc)
values('bnbg01', 'dll01', 'fish bean bag toy',3.49,'fish bean bag toy, complete with bean bag worms with which to feed it');

insert into product(product_id, vendor_id, product_name, product_price, product_desc)
values('bnbg02', 'dll01', 'bird bean bag toy',3.49,'bird bean bag toy, eggs are not included');

insert into product(product_id, vendor_id, product_name, product_price, product_desc)
values('bnbg03', 'dll01', 'rabbit bean bag toy',3.49,'rabbit bean bag toy, comes with bean bag carrots');

insert into product(product_id, vendor_id, product_name, product_price, product_desc)
values('rgan01', 'dll01', 'raggedy ann',4.99,'18 inch raggedy ann doll');




insert into order_item(order_id,order_item,product_id,quantity,item_price)
values(20005,1,'br01',100,5.49);

insert into order_item(order_id,order_item,product_id,quantity,item_price)
values(20005,2,'br03',100,10.99);

insert into order_item(order_id,order_item,product_id,quantity,item_price)
values(20006,1,'br01',20,5.99);

insert into order_item(order_id,order_item,product_id,quantity,item_price)
values(20006,2,'br02',10,8.99);

insert into order_item(order_id,order_item,product_id,quantity,item_price)
values(20006,3,'br03',10,11.99);

insert into order_item(order_id,order_item,product_id,quantity,item_price)
values(20007,1,'br03',50,11.49);

insert into order_item(order_id,order_item,product_id,quantity,item_price)
values(20007,2,'bnbg01',100,2.99);

insert into order_item(order_id,order_item,product_id,quantity,item_price)
values(20007,3,'bnbg02',100,2.99);

insert into order_item(order_id,order_item,product_id,quantity,item_price)
values(20007,4,'bnbg03',100,2.99);

insert into order_item(order_id,order_item,product_id,quantity,item_price)
values(20007,5,'rgan01',50,4.49);

insert into order_item(order_id,order_item,product_id,quantity,item_price)
values(20008,1,'rgan01',5,4.99);

insert into order_item(order_id,order_item,product_id,quantity,item_price)
values(20008,2,'br03',5,11.99);

insert into order_item(order_id,order_item,product_id,quantity,item_price)
values(20008,3,'bnbg01',10,3.49);

insert into order_item(order_id,order_item,product_id,quantity,item_price)
values(20008,4,'bnbg02',10,3.49);

insert into order_item(order_id,order_item,product_id,quantity,item_price)
values(20008,5,'bnbg03',10,3.49);

insert into order_item(order_id,order_item,product_id,quantity,item_price)
values(20009,1,'bnbg01',250,2.49);

insert into order_item(order_id,order_item,product_id,quantity,item_price)
values(20009,2,'bnbg02',250,2.49);

insert into order_item(order_id,order_item,product_id,quantity,item_price)
values(20009,3,'bnbg03',250,2.49);

