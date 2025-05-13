DROP TABLE IF EXISTS Employees;

CREATE TABLE Employees (
    EmployeeId INT PRIMARY KEY,
    Name NVARCHAR(100),
    Email NVARCHAR(100),
    Department NVARCHAR(50),
    Salary DECIMAL(15, 2)
);

INSERT INTO Employees (EmployeeId, Name, Email, Department, Salary)
VALUES 
(1, 'Niteesh', 'niteesh@gmail.com', 'IT', 68000.00),
(2, 'Dheeraj', 'dheeraj@gmail.com', 'HR', 64000.00),
(3, 'Shannu', 'shannu@gmail.com', 'Finance', 71000.00),
(4, 'Jaivardhan', 'jaivardhan@gmail.com', 'Marketing', 63000.00);

select * from Employees;