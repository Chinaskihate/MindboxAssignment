CREATE TABLE Products(
	ProductId INT PRIMARY KEY IDENTITY(1,1),
	ProductName VARCHAR(30)
);

CREATE TABLE Categories(
	CategoryId INT PRIMARY KEY IDENTITY(1,1),
	CategoryName VARCHAR(30)
);

-- There was no information about how the data was stored, I assumed that it was like this.
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