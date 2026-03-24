USE [SmraaAlYamanDbTran]
GO

INSERT INTO [dbo].[Branches]
           ([BranchName],
           [BranchAddress],
           [BranchPhone],
           [CreatedAt],
           [LastUpdate],
           [IsDeleted])   
     VALUES
           (
           'Branche 2',
           'someplace 2',
           '555555555',
           GETDATE(),
           NULL,
           0),
           (
           'Branche 3',
           'someplace 3',
           '555555555',
           GETDATE(),
           NULL,
           0),
           (
           'Branche 4',
           'someplace 4',
           '555555555',
           GETDATE(),
           NULL,
           0),
           (
           'Branche 5',
           'someplace 5',
           '555555555',
           GETDATE(),
           NULL,
           0)     
GO





USE [SmraaAlYamanDbTran]
GO

INSERT INTO [dbo].[Brands]
           ([Name]
           ,[CreatedAt]
           ,[LastUpdate])
     VALUES
           ('Brand 1',
           GETDATE(),
           NULL),
           ('Brand 222',
           GETDATE(),
           NULL),
           ('Brand 333',
           GETDATE(),
           NULL),
           ('Brand 444',
           GETDATE(),
           NULL),
           ('Brand 555',
           GETDATE(),
           NULL)
GO

USE [SmraaAlYamanDbTran]
GO

INSERT INTO [dbo].[Catagories]
           ([Name]
           ,[CreatedAt]
           ,[LastUpdate])
     VALUES
           ('Catagory 111',
           GETDATE(),
           NULL),
           ('Catagory 222',
           GETDATE(),
           NULL),
           ('Catagory 333',
           GETDATE(),
           NULL),
           ('Catagory 444',
           GETDATE(),
           NULL),
           ('Catagory 555',
           GETDATE(),
           NULL)
GO

USE [SmraaAlYamanDbTran]
GO

INSERT INTO [dbo].[CountriesOfOrigin]
           ([Name]
           ,[ZCode]
           ,[CreatedAt]
           ,[LastUpdate])
     VALUES
           ('Country 1',
           '123456',
           GETDATE(),
           NULL),
           ('Country 222',
           '123456',
           GETDATE(),
           NULL),
           ('Country 333',
           '123456',
           GETDATE(),
           NULL),
           ('Country 444',
           '123456',
           GETDATE(),
           NULL),
           ('Country 555',
           '123456',
           GETDATE(),
           NULL)
GO

USE [SmraaAlYamanDbTran]
GO

INSERT INTO [dbo].[ProductGroups]
           ([Name]
           ,[CreatedAt]
           ,[LastUpdate])
     VALUES
           ('Group 111',
           GETDATE(),
           NULL),
           ('Group 222',
           GETDATE(),
           NULL),
           ('Group 333',
           GETDATE(),
           NULL),
           ('Group 444',
           GETDATE(),
           NULL),
           ('Group 555',
           GETDATE(),
           NULL)
GO

