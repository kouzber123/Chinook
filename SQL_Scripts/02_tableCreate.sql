CREATE TABLE Superhero (
ID int IDENTITY(1,1) PRIMARY KEY,
Name nvarchar(55) not null,
Alias nvarchar(55),
Origin nvarchar(255)
);


CREATE TABLE Assistant (
ID int IDENTITY(1,1) PRIMARY KEY,
Name nvarchar(55) not null
);

CREATE TABLE Power (
ID int IDENTITY(1,1) PRIMARY KEY,
Name nvarchar(55) not null,
Description nvarchar(100)
);



