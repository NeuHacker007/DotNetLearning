USE DotnetCoreCentralDemo

IF EXISTS 
(
SELECT * 
FROM INFORMATION_SCHEMA.TABLES 
WHERE TABLE_TYPE = 'BASE TABLE' 
AND TABLE_NAME = 'EMPLOYEE'
AND TABLE_SCHEMA = 'DBO' 
)
DROP TABLE EMPLOYEE

CREATE TABLE EMPLOYEE (
 id INT IDENTITY(1,1) PRIMARY KEY,
 first_name nvarchar(40) not null,
 last_name nvarchar(40) not null,
 address nvarchar(50),
 home_phone nvarchar(10),
 cell_phone nvarchar(10)
)

INSERT INTO EMPLOYEE values ('Ivan', 'Zhang','Indianapolis Navient', '857300999', '8573XX00XX')

SELECT * FROM EMPLOYEE