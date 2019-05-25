CREATE TABLE [dbo].[Tax]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [StartDate] DATE NOT NULL, 
    [EndDate] DATE NULL, 
    [Value] DECIMAL(10, 4) NOT NULL, 
    [Type] NCHAR(1) NOT NULL
)
