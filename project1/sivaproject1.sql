


CREATE TABLE [siva.TrainneLogin] (
  [Email] varchar(20),
  [Password] varchar(10) not null,
  [Id] int  ,
  PRIMARY KEY ([Id])
);

GO

CREATE TABLE [siva.TraineeDetails] (
  [TraineeId] int not null,
  [FirstName] varchar(15),
  [LastName] varchar(15),
  [Age] int not null,
  [Gender] varchar(10) not null,
  PRIMARY KEY ([TraineeId])
);

GO

CREATE TABLE [siva.Company] (
  [Cid] int not null,
  [Cname] varchar(15),
  [Ctype] varchar(15),
  [TCompanyId] int,
  PRIMARY KEY ([Cid]),
  CONSTRAINT [FK_Company.TCompanyId]
    FOREIGN KEY ([TCompanyId])
      REFERENCES [siva.TraineeDetails]([TraineeId])
);

GO


CREATE TABLE [siva.TraineeEducation] (
  [TEducationId] int not null,
  [university] varchar(20),
  [HDegree] varchar(20) not null,
  [YearOfStart] date,
  [PassoutYear] date,
  [Percentage] float not null,
  CONSTRAINT [FK_TraineeEducation.TEducationId]
    FOREIGN KEY ([TEducationId])
      REFERENCES [siva.TraineeDetails]([TraineeId])
);
GO

CREATE TABLE [siva.TraineeContact] (
  [phoneno] varchar(10),
  [Email] varchar(20),
  [Address] varchar(20),
  [City] varchar(10),
  [state] varchar(20),
  [Pincode] varchar(6),
  [Website] varchar(20),
  [TContactId] int,
  PRIMARY KEY ([phoneno]),
  CONSTRAINT [FK_TraineeContact.TContactId]
    FOREIGN KEY ([TContactId])
      REFERENCES [siva.TraineeDetails]([TraineeId])
);

GO

CREATE TABLE [siva.TraineeSkills] (
  [SkillId] int,
  [SkillName] varchar(20),
  [Experience] varchar(20),
  [TSkillsId] int,
  PRIMARY KEY ([SkillId]),
  CONSTRAINT [FK_TraineeSkills.TSkillsId]
    FOREIGN KEY ([TSkillsId])
      REFERENCES [siva.TrainneLogin]([Id])
);

select * from [siva.TraineeSkills]
SELECT * from [siva.TraineeDetails]
SELECT * from [siva.Company]
select * from [siva.TraineeEducation]
select * from [siva.Company]
select * from [siva.TraineeSkills]