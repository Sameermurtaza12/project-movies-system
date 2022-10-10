create table genre(
genreId int IDENTITY(1,1) PRIMARY KEY,
genreName varchar(255) NOT NULL);
CREATE TABLE movies(
movieId int IDENTITY(1,1) PRIMARY KEY,
movieName varchar(255) NOT NULL,
moviePrice decimal(10,2),
movieRating varchar(255),
);   

create table users(
userId int IDENTITY(1,1) PRIMARY KEY,
userName varchar(255) , 
userPassword varchar(255),
userType varchar(255)
);

create table cart(
invoiceNo int IDENTITY(1,1) PRIMARY KEY,
userId int,
movieName varchar(255),
moviePrice decimal(10,2),
PurchaseDate datetime
);
INSERT INTO users(userName,userPassword, userType)
VALUES('sameer','123','admin'),('umair','123','admin'),('abdullah','123','customer'),('zaryab','123','customer'),('ibtesam','123','customer');

INSERT INTO customers(customerName,customerContact,customerAddress,customerCity,customerCountry,customerState,customerAge,userId)
VALUES('ibtesam','0324457347','Davis Road','Lahore','Pakistan','Punjab',22,5);

INSERT INTO genre(genreName)
VALUES('Action'),('Sci-Fiction'),('Comedy'),('Romance');

INSERT INTO movies(movieName,moviePrice,movieRating)
VALUES('wanted','10','5'),('transformer','14','5'),('Me Time','9','4.5'),('notebook','12','4'),('fast & furious','15','5'); 

INSERT INTO bridge(movieId,genreId)
VALUES (1,1),(2,1),(2,2),(3,3),(4,4),(5,1),(5,3);

delete from customers;
create table history(
invoiceId int IDENTITY(1,1) PRIMARY KEY,
customerId int FOREIGN KEY REFERENCES customer(customerId),
movieId int FOREIGN KEY REFERENCES movies(movieId),
genreId int FOREIGN KEY REFERENCES genre(genreId),
moviePrice decimal(10,2)); 
create table customers(
customerName varchar(255),
customerContact varchar(255),
customerAddress varchar(255),
customerCity varchar(255),
customerCountry varchar(255),
customerState varchar(255),
customerAge int,
userId int FOREIGN KEY REFERENCES users(userId)
);


create table bill_header(
invoiceNo int IDENTITY(1,1) PRIMARY KEY,
userId int FOREIGN KEY REFERENCES users(userId),
purchaseDate date);


create table bill_detail(
movieId int FOREIGN KEY REFERENCES movies(movieId),
invoiceNo int FOREIGN KEY REFERENCES bill_header(invoiceNo));


create table bridge(
movieId int,
genreId int,
PRIMARY KEY(movieId, genreId)
);


DROP TABLE customers;

CREATE PROCEDURE login
(
	@userName varchar(255),
	@userPassword varchar(255) 
)
as

select userType from users where userName=@userName and userPassword=@userPassword
go

exec spGetId @userName='sameer', @userPassword='123';



CREATE PROCEDURE spAddInUser
(
	@userName varchar(255),
	@userPassword varchar(255),
	@userType varchar (255)
)
as
begin

INSERT INTO users
VALUES(@userName, @userPassword, @userType)

end

CREATE PROCEDURE spAddInCartNow
(
	@userId int,
	@movieName varchar(255),
	@moviePrice varchar (255)
)
as
begin

INSERT INTO cart
VALUES(@userId, @movieName, @moviePrice, GETDATE())

end

exec spAddInCartNow @userId=3, @movieName='wanted', @moviePrice=12;

select *from cart;
CREATE PROCEDURE spAddInGenre
(
	@genreName varchar(255)
)
as
begin

INSERT INTO genre
VALUES(@genreName)

end
CREATE PROCEDURE spAddInMovies
(
	@movieName varchar(255),
	@moviePrice decimal(10,2),
	@movieRating varchar(255),
	@genreName varchar(255)
)
as
begin
INSERT INTO movies
VALUES(@movieName,@moviePrice,@movieRating,@genreName)
end

CREATE PROCEDURE spGetDetailsById
(
@movieId int
)
as 
begin
select movieName, moviePrice from movies where movieId=@movieId
end
exec spGetDetailsById @movieId=1;


CREATE PROCEDURE spGetId
(
	@userName varchar(255),
	@userPassword varchar (255)
)
as
begin
 
select userId from users where userName=@userName and userPassword=@userPassword;

 end


 CREATE PROCEDURE spAddInCustomer
(
	@customerName varchar(255),
	@customerContact varchar(255),
	@customerAddress varchar (255),
	@customerCity varchar(255),
	@customerCountry varchar(255),
	@customerState varchar(255),
	@customerAge int,
	@userId int

)
as
begin

INSERT INTO customers
VALUES(@customerName, @customerContact, @customerAddress, @customerCity, @customerCountry,@customerState, @customerAge,@userId )

end

CREATE PROCEDURE spGetMovies
as 
begin 
select * from movies
end
go
drop procedure spGetCartItems;
CREATE PROCEDURE spGetCartItems
(
@userId int
)
as
begin
select * from cart where userId=@userId
end
go
exec spGetCartItems @userId=3
alter table movies
add genreName varchar(255) NULL;
Update movies set genreName='Action' where movieId(primary key column)=1;

INSERT INTO movies(genreName)
VALUES ('ACTION'),('SCI-FICTION'),('COMEDY'),('ROMANCE'),('ACTION/THRILL');

create procedure spDeleteFromCart
(
	@invoiceNo int
)
as
begin
		delete from cart where invoiceNo=@invoiceNo
end
exec spDeleteFromCart @invoiceNo=44
select *from cart;
create procedure spDeleteFromMovies
(
	@movieId int
)
as
begin
		delete from movies where movieId=@movieId
end
drop table cart;



drop procedure spMakeCart

create procedure spDropCart
(
	@userId int
)
as
begin
delete from cart where userId=@userId
end
drop procedure spDropCart
create procedure spGetBill
as
begin
select moviePrice from cart
end

create table cart(
invoiceNo int IDENTITY(1,1) PRIMARY KEY,
userId int,
movieName varchar(255),
moviePrice decimal(10,2),
PurchaseDate datetime
)

create table billReceipt
(
invoiceNo int IDENTITY(1,1) PRIMARY KEY,
userId int,
userName varchar(255),
purchaseDate datetime,
totalBill decimal(10,2)
)
create procedure spAddInBill
(
@userId int,
@userName varchar(255),
@totalBill decimal(10,2)
)
as
begin
INSERT INTO billReceipt
VALUES(@userId,@userName,GETDATE(),@totalBill)
end

select * from billReceipt;

create procedure spGetFromBill
as
begin
select * from billReceipt
end

create procedure spGetFinalBill
(
@invoiceNo int
)
as
begin
select * from billReceipt where invoiceNo=@invoiceNo
end
select * from billReceipt
exec spGetFinalBill @invoiceNo=7

create procedure spGetHistory
(
@userId int
)
as
begin
select * from billReceipt where userId=@userId
end
exec spGetHistory @userId=3


create procedure spDeleteFromBillInvoice
(
	@invoiceNo int
)
as
begin
		delete from billReceipt where invoiceNo=@invoiceNo
end