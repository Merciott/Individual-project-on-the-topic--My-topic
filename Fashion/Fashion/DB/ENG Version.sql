CREATE TABLE Polzovatel (
    ID INT PRIMARY KEY NOT NULL,
    Name VARCHAR(100) NOT NULL,
    Password VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL
);



CREATE TABLE Products (
    ID INT PRIMARY KEY NOT NULL,
    Name VARCHAR(100) NOT NULL,
    Description TEXT,
    Price DECIMAL(10, 2) NOT NULL,
    Size VARCHAR(50),
    Color VARCHAR(50),
    Category VARCHAR(100),
    BrandID INT,
);



CREATE TABLE Zakazi (
    ID INT PRIMARY KEY NOT NULL,
    UserID INT NOT NULL,
    OrderDate DATE NOT NULL,
    OrderTime TIME NOT NULL,
	ProductID INT,
);


CREATE TABLE Reviews (
    ID INT PRIMARY KEY NOT NULL,
    UserID INT NOT NULL,
    ProductID INT NOT NULL,
    Rating INT,
    Comment TEXT
);



CREATE TABLE Brand (
    ID INT PRIMARY KEY NOT NULL,
    Brand TEXT NOT NULL
);


INSERT INTO Polzovatel (ID, Name, Password, Email)
VALUES 
(1, 'Ivan Ivanov', 'password1', 'ivanivanov@example.com'),
(2, 'Petr Petrov', 'password2', 'petrpetrov@example.com'),
(3, 'Alexander Alexandrov', 'password3', 'alexanderalexandrov@example.com'),
(4, 'Maria Ivanova', 'password4', 'mariivanova@example.com'),
(5, 'Anna Petrova', 'password5', 'annapetrova@example.com');

INSERT INTO Products (ID, Name, Description, Price, Size, Color, Category, BrandID)
VALUES 
(1, 'T-shirt', 'Red Leather T-shirt', 50.00, 'M', 'Red', 'Clothes', 1),
(2, 'Jeans', 'Blue wool jeans', 75.00, 'L', 'Blue', 'Clothes', 2),
(3, 'Sneakers', 'Black leather sneakers', 100.00, '42', 'Black', 'Shoes', 3),
(4, 'Shirt', 'White wool shirt', 75.00, 'M', 'White', 'Clothes', 4),
(5, 'Shoes', 'Brown leather shoes', 120.00, '40', 'Brown', 'Shoes', 5);

INSERT INTO Zakazi (ID, UserID, OrderDate, OrderTime)
VALUES 
(1, 1, '2022-01-01', '10:00:00'),
(2, 2, '2022-01-02', '11:00:00'),
(3, 3, '2022-01-03', '12:00:00'),
(4, 4, '2022-01-04', '13:00:00'),
(5, 5, '2022-01-05', '14:00:00');

INSERT INTO Reviews (ID, UserID, ProductID, Rating, Comment)
VALUES 
(1, 1, 1, 5, 'Excellent quality'),
(2, 2, 2, 4, 'Good product'),
(3, 3, 3, 3, 'Normal'),
(4, 4, 4, 2, 'Bad product'),
(5, 5, 5, 1, 'Terrible');

INSERT INTO Brand (ID, Brand)
VALUES 
(1, 'Saint Laurent'),
(2, 'Maison Margiela'),
(3, 'Bottega Veneta'),
(4, 'Versace'),
(5, 'Prada');

ALTER TABLE Products ADD FOREIGN KEY (BrandID) REFERENCES Brand (ID);

ALTER TABLE Zakazi ADD FOREIGN KEY (UserID) REFERENCES Polzovatel (ID);

ALTER TABLE Reviews ADD FOREIGN KEY (UserID) REFERENCES polzovatel (ID);