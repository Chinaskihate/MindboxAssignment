CREATE TABLE Products(
	ProductId INT PRIMARY KEY IDENTITY(1,1),
	ProductName VARCHAR(30)
);

CREATE TABLE Categories(
	CategoryId INT PRIMARY KEY IDENTITY(1,1),
	CategoryName VARCHAR(30)
);
-- Íå áûëî èíôîðìàöèè î òîì êàê õðàíÿòñÿ äàííûå, ïðåäïîëîæèë ÷òî òàê.
CREATE TABLE ProductCategory(
	ProductId INT,
	CategoryId INT
);

SELECT 
	ProductName,
	CategoryName
FROM
	Products AS p
	LEFT JOIN ProductCategory AS pc
	ON pc.ProductId = p.ProductID
	LEFT JOIN Categories AS c
	ON pc.CategoryId = c.CategoryId