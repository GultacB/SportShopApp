CREATE DATABASE SportShop

CREATE TABLE WareHouse(
Id INT PRIMARY KEY IDENTITY(1,1),
ProductName NVARCHAR(50),
Quantity INT,
PRICE Money
);

CREATE TABLE ProductArchive(
Id INT PRIMARY KEY IDENTITY(1,1),
ProductName NVARCHAR(50),
Price INT
);

CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY(1,1),
EmployeeCategory NVARCHAR(60)
);

CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY(1,1),
FirstName NVARCHAR(60),
LastName NVARCHAR(60),
CategoryId INT FOREIGN KEY REFERENCES Categories(Id)
);

CREATE TABLE EmployeeArchive(
Id INT PRIMARY KEY IDENTITY(1,1),
EmployeesFullName NVARCHAR(150),
EmployeesCategory NVARCHAR(60)
);

CREATE TABLE LastProduct(
Id INT PRIMARY KEY IDENTITY(1,1),
ProductName NVARCHAR(50),
PRICE Money
);

INSERT INTO  WareHouse(ProductName,Quantity,PRICE)
VALUES ('Pullover Hoodie',5,$74.99),
       ('Training Hat',2,$33.99),
	   ('Spalding 44 In',2,$300.00),
	   ('Sneaker',4,$59.99),
	   ('Shield T-Shirt',5,$29.99)

INSERT INTO Categories(EmployeeCategory)
VALUES ('Seller'),
        ('Cashier')

INSERT INTO Employees(FirstName,LastName,CategoryId)
VALUES ('Gifford','Bob',1),
       ('Thomas','Darin',1),
	   ('Diana','Harris',2),
	   ('Maria','Kully',2),
	   ('Jess','Tyler',1)



		

        