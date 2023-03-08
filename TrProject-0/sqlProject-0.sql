

GO

create table [siva.TrDetails](
	[TrId] int not null,
	[Email] varchar(50),
	[Password] varchar(max),
	[Fullname] varchar(50),
	[phone] varchar(10),
	[website] varchar(50),
	
	[gender] varchar(10),
	constraint [PK_Tr_Id] primary key ([TrId])
)
	
create table [siva.TrSkill](
	[skill] varchar(50),
	[Trskillid] int not null
	constraint [FK_trainer_skill_id] foreign key ([Trskillid]) references [siva.TrDetails] ([TrId]) on delete cascade
)

create table [siva.TrEducation](
	[TUniversity] varchar(max),
	[HdegreeName] varchar(100),
	[Cgpa] varchar(5),
	[startdate] varchar(10),
	[PassoutDate] varchar(10),
	[TrEduid] int not null,
	constraint [FK_trainer_education_id] foreign key (TrEduid) references [siva.TrDetails]([Trid]) on delete cascade
)


create table [siva.Trcompany](
	[Cname] varchar(50),
	[CType] varchar(25),
	[startyear] varchar(20),
	[endyear] varchar(20),
	[Trcompanyid] int not null,
	constraint [FK_Tr_company_id] foreign key ([Trcompanyid]) references [siva.TrDetails]([TrId]) on delete cascade
)


create table [siva.TrContact](
	[pincode] varchar(6) not null,
	[city] varchar(50),
	[CId] int not null
	unique constraint [FK_C_Id] foreign key ([CId]) references [siva.TrDetails]([TrId]) on delete cascade
)


select * from [siva.TrDetails]
SELECT * from [siva.TrSkill]
SELECT * from [siva.Trcompany]
SELECT * from [siva.TrEducation]
SELECT * from [siva.TrContact]
