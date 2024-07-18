select * from [dbo].[Role];
go

insert into [dbo].[Role] 
([Description],[InsertDate],[InsertUser],[UpdateDate],[UpdateUser],[IsDeleted]) VALUES 
('Desenvolvedor Dot Net', getdate(), 1, getdate(), 1, 0),
('Desenvolvedor Java', getdate(), 1, getdate(), 1, 0),
('Desenvolvedor Angular', getdate(), 1, getdate(), 1, 0),
('Desenvolvedor ReactJS', getdate(), 1, getdate(), 1, 0),
('Desenvolvedor C++', getdate(), 1, getdate(), 1, 0),
('Desenvolvedor Go(Lang)', getdate(), 1, getdate(), 1, 0),
('Desenvolvedor NodeJS', getdate(), 1, getdate(), 1, 0),
('Product Owner', getdate(), 1, getdate(), 1, 0),
('Scrum Master', getdate(), 1, getdate(), 1, 0),
('UX Designer', getdate(), 1, getdate(), 1, 0),
('UI Designer', getdate(), 1, getdate(), 1, 0);



select * from [dbo].[Person];

select * from [dbo].[PersonRole];

select * from [dbo].[User];