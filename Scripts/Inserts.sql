USE [Workfulness]
GO

DELETE FROM [dbo].[Songs];
DELETE FROM [dbo].[Playlists]
DELETE FROM [dbo].[PlaylistsCategories]

DBCC CHECKIDENT ([Songs], RESEED, 0);
DBCC CHECKIDENT ([Playlists], RESEED, 0);
DBCC CHECKIDENT ([PlaylistsCategories], RESEED, 0);

INSERT INTO [dbo].[PlaylistsCategories] ([Name])
	VALUES ('Folk')

INSERT INTO [dbo].[PlaylistsCategories] ([Name])
	VALUES ('Rock')

INSERT INTO [dbo].[Playlists] ([Title], [CoverUrl], [CategoryId])
	VALUES ('Calm lake', 'https://images.pexels.com/photos/747964/pexels-photo-747964.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260', 1)

INSERT INTO [dbo].[Playlists] ([Title], [CoverUrl], [CategoryId])
	VALUES ('Rock IT', 'https://images.pexels.com/photos/749090/pexels-photo-749090.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260', 2)

INSERT INTO [dbo].[Songs] ([Title], [Author], [FileName], [DbPlaylistId])
	VALUES ('Blathering On', 'Derek Clegg', 'Derek Clegg - Blathering On.mp3', 1)
INSERT INTO [dbo].[Songs] ([Title], [Author], [FileName], [DbPlaylistId])
	VALUES ('Heavy Waves', 'Crowander', 'Crowander - Heavy Waves.mp3', 2)
