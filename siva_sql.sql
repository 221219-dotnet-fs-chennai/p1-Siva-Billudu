CREATE SCHEMA siva
go
create TABLE siva.employees(
    empId int IDENTITY(1,1) PRIMARY key,
    empFirstname varchar(max) NOT NULL,
    empLastname varchar(max) NOT NULL,
    
    empDeptId int NOT NULL
);
GO
create TABLE siva.Departments(
    depId int IDENTITY(1,1) PRIMARY key,
    depName varchar(max) not null,
    depLocation varchar(max) not null
);
GO
create TABLE siva.emploDetails(
    id int not null,
    employeeid int UNIQUE,
    empSalary SMALLMONEY not NULL,
    empAddress1 varchar(max) not null ,
    empAddress2 varchar(max) ,
    empCity varchar(max),
    empState varchar(max) NOT null,
    empCountry varchar(max) not null
);


alter TABLE siva.employees
 add empSsn bigint
insert into siva.employees
VALUES('tina','smith',23541,2)

INSERT into siva.Departments
VALUES('marketing','chennai')

INSERT into siva.emploDetails
values(3,351,14000,'sri nagar','madhur','vjw','ap','india')

SELECT * from siva.employees
SELECT * from siva.Departments
SELECT * from siva.emploDetails
 
 alter TABLE siva.emploDetails
 add CONSTRAINT [pk_emplodetails] PRIMARY key(Id)

 alter TABLE siva.emploDetails
 add CONSTRAINT [fk_emploDetails]
FOREIGN KEY (employeeid) REFERENCES siva.employees(empId)

SELECT  empFirstname ,empLastname ,e.empDeptId,d.depName from siva.employees as e 
INNER JOIN 
siva.Departments as d on e.empDeptId=d.depId
where d.depName='marketing';

alter TABLE siva.Departments
add CONSTRAINT [PK_Departments] PRIMARY key(depId)

select * from siva.Departments where depName='marketing'

select sum(empsalary) as  marketing from siva.emploDetails e where e.employeeId in (SELECT e.empId from siva.employees e
INNER join siva.Departments d on e.empDeptId=d.DepId
WHERE d.depName='marketing');

SELECT count(*) as employecount ,d.depName from siva.employees e INNER join siva.Departments d on e.empDeptId=d.depId GROUP by d.depName;

UPDATE siva.emploDetails
set empSalary=5000 from siva.employees e inner join siva.emploDetails ed on e.empId=ed.employeeid WHERE e.empFirstname='tina'