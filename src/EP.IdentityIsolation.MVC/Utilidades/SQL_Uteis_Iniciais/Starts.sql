insert into AspNetRoles values(1,'Admin')


select * from AspNetRoles

select * from AspNetUserRoles

insert into AspNetUserRoles values('42fcc459-1d94-4436-97e4-1d25146c7bab',1)



select * from AspNetUsers where  AspNetUsers.Id = '42fcc459-1d94-4436-97e4-1d25146c7bab'


insert into AspNetClaims  values(NEWID(),'AdmClaims')

select * from AspNetClaims


select * from AspNetUserClaims


CREATE TABLE AspNetRoles
(
Id int,
Name varchar(255)

);