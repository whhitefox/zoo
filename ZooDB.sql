CREATE DATABASE ZooDB
USE ZooDB

CREATE TABLE Role(
	id int NOT NULL identity(1,1) PRIMARY KEY,
	name varchar(50) NOT NULL,
)
CREATE TABLE Zone(
	id int NOT NULL identity(1,1) PRIMARY KEY,
	name varchar(50) NOT NULL,
)
CREATE TABLE Animal(
	id int NOT NULL identity(1,1) PRIMARY KEY,
	name varchar(50) NOT NULL,
	type varchar(50) NOT NULL,
	zone_id int NOT NULL FOREIGN KEY REFERENCES Zone
)
CREATE TABLE Filial(
	id int NOT NULL identity(1,1) PRIMARY KEY,
	address varchar(50) NOT NULL,
	worktime varchar(50) NOT NULL
)
CREATE TABLE Employee(
	id int NOT NULL identity(1,1) PRIMARY KEY,
	name varchar(50) NOT NULL,
	filial_id int NOT NULL FOREIGN KEY REFERENCES Filial,
	animal_id int NOT NULL FOREIGN KEY REFERENCES Animal,
	role_id int NOT NULL FOREIGN KEY REFERENCES Role
)
CREATE TABLE [User](
	id int NOT NULL identity(1,1) PRIMARY KEY,
	login varchar(50) NOT NULL,
	password varchar(50) NOT NULL,
	employee_id int NOT NULL FOREIGN KEY REFERENCES Employee
)
CREATE TABLE Support(
	id int NOT NULL identity(1,1) PRIMARY KEY,
	filial_id int NOT NULL FOREIGN KEY REFERENCES Filial,
	phone varchar(50) NOT NULL,
)
CREATE TABLE Product_Type(
	id int NOT NULL identity(1,1) PRIMARY KEY,
	name varchar(50) NOT NULL,
)
CREATE TABLE Product(
	id int NOT NULL identity(1,1) PRIMARY KEY,
	name varchar(50) NOT NULL,
	product_type_id int NOT NULL FOREIGN KEY REFERENCES Product_Type,
	filial_id int NOT NULL FOREIGN KEY REFERENCES Filial,
	price float NOT NULL
)
CREATE TABLE [Check](
	id int NOT NULL identity(1,1) PRIMARY KEY,
	date datetime NOT NULL,
	pay float NOT NULL
)
CREATE TABLE Product_Check(
	id int NOT NULL identity(1,1) PRIMARY KEY,
	product_id int NOT NULL FOREIGN KEY REFERENCES Product,
	check_id int NOT NULL FOREIGN KEY REFERENCES [Check],
	count int NOT NULL
)

INSERT INTO Zone (name) VALUES ('Африканские животные'), ('Контактная зона'), ('Домашние птицы')
INSERT INTO Animal (name, type, zone_id) VALUES ('Жираф', 'Парнокопытное', 1), ('Курица', 'Птица', 3)
INSERT INTO Role (name) VALUES ('Администратор'), ('Кассир'), ('Работник')
INSERT INTO Filial (address, worktime) VALUES ('метро Славянский бульвар', '08:00-19:00'), ('метро Красносельская', '09:00-22:00')
INSERT INTO Support (filial_id, phone) VALUES (1, '+7(999)333-11-99'), (2, '+7(988)123-32-12')
INSERT INTO Employee (name, filial_id, animal_id, role_id) VALUES ('Трофимов М. Д.', 1, 1, 1), ('Смирнова В. Л.', 2, 2, 2), ('Левин И. К.', 2, 1, 3)
INSERT INTO [User] (login, password, employee_id) VALUES ('admin', 'admin', 1), ('kassa', 'kassa', 2), ('worker', 'worker', 3)
INSERT INTO Product_Type (name) VALUES ('Билет'), ('Сувенир')
INSERT INTO Product (name, product_type_id, filial_id, price) VALUES ('Детский билет', 1, 1, 200), ('Фотография', 2, 2, 100)