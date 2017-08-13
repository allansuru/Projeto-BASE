insert into AspNetRoles values(1,'Admin')
GO

select * from AspNetRoles
GO
select * from AspNetUserRoles
GO
insert into AspNetUserRoles values('42fcc459-1d94-4436-97e4-1d25146c7bab',1)
GO


select * from AspNetUsers where  AspNetUsers.Id = '42fcc459-1d94-4436-97e4-1d25146c7bab'
GO

insert into AspNetClaims  values(NEWID(),'AdmClaims')
GO
select * from AspNetClaims
GO

select * from AspNetUserClaims
GO

CREATE TABLE AspNetRoles
(
Id int,
Name varchar(255)

);
GO
