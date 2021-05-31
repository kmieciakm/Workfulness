USE [Workfulness]
GO

DELETE FROM [dbo].[Songs]
DELETE FROM [dbo].[Playlists]
DELETE FROM [dbo].[PlaylistsCategories]

DBCC CHECKIDENT ([Songs], RESEED, 0);
DBCC CHECKIDENT ([Playlists], RESEED, 0);
DBCC CHECKIDENT ([PlaylistsCategories], RESEED, 0);

INSERT INTO [dbo].[PlaylistsCategories] ([Name])
	VALUES ('Folk')

INSERT INTO [dbo].[PlaylistsCategories] ([Name])
	VALUES ('Jazz')

INSERT INTO [dbo].[Playlists] ([Title], [CoverUrl], [CategoryId])
	VALUES ('Countryside Wind', 'https://images.pexels.com/photos/774535/pexels-photo-774535.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260', 1)

INSERT INTO [dbo].[Songs] ([Title], [Author], [FileName], [DbPlaylistId])
	VALUES ('Blathering On', 'Derek Clegg', 'Derek Clegg - Blathering On.mp3', 1)
INSERT INTO [dbo].[Songs] ([Title], [Author], [FileName], [DbPlaylistId])
	VALUES ('Astrometrics', 'Lentomatto', 'Astrometrics - Lentomatto.mp3', 1)
INSERT INTO [dbo].[Songs] ([Title], [Author], [FileName], [DbPlaylistId])
	VALUES ('Derek Clegg', 'All I Want Is You', 'Derek Clegg - All I Want Is You.mp3', 1)
INSERT INTO [dbo].[Songs] ([Title], [Author], [FileName], [DbPlaylistId])
	VALUES ('Derek Clegg', 'Souvenir', 'Derek Clegg - Souvenir.mp3', 1)
INSERT INTO [dbo].[Songs] ([Title], [Author], [FileName], [DbPlaylistId])
	VALUES ('Greg Atkinson', '120 Words', 'Greg Atkinson - 120 Words.mp3', 1)
INSERT INTO [dbo].[Songs] ([Title], [Author], [FileName], [DbPlaylistId])
	VALUES ('Joshua Hedley', 'Parting Words', 'Joshua Hedley - Parting Words.mp3', 1)
INSERT INTO [dbo].[Songs] ([Title], [Author], [FileName], [DbPlaylistId])
	VALUES ('Ketsa', 'Bubbles', 'Ketsa - Bubbles.mp3', 1)
INSERT INTO [dbo].[Songs] ([Title], [Author], [FileName], [DbPlaylistId])
	VALUES ('Malachi Graham', 'Malachi Graham', 'Malachi Graham - Malachi Graham.mp3', 1)
INSERT INTO [dbo].[Songs] ([Title], [Author], [FileName], [DbPlaylistId])
	VALUES ('notforme!', 'Forlorn Shores', 'notforme! - Forlorn Shores.mp3', 1)
INSERT INTO [dbo].[Songs] ([Title], [Author], [FileName], [DbPlaylistId])
	VALUES ('Quimorucru', 'Que pour toi', 'Quimorucru - Que pour toi.mp3', 1)
	
INSERT INTO [dbo].[Playlists] ([Title], [CoverUrl], [CategoryId])
	VALUES ('Off the beaten path', 'https://images.pexels.com/photos/4843438/pexels-photo-4843438.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940', 1)

INSERT INTO [dbo].[Songs] ([Title], [Author], [FileName], [DbPlaylistId])
	VALUES ('Kielicaster', 'Wegwerfen oder Behalten', 'Kielicaster - Wegwerfen oder Behalten.mp3', 2)
INSERT INTO [dbo].[Songs] ([Title], [Author], [FileName], [DbPlaylistId])
	VALUES ('Lobo Loco', 'Traveling to Louisiana', 'Lobo Loco - Traveling to Louisiana.mp3', 2)
INSERT INTO [dbo].[Songs] ([Title], [Author], [FileName], [DbPlaylistId])
	VALUES ('Lobo Loco', 'Waiting Alone in the Dust', 'Lobo Loco - Waiting Alone in the Dust.mp3', 2)
INSERT INTO [dbo].[Songs] ([Title], [Author], [FileName], [DbPlaylistId])
	VALUES ('Marwood Williams', 'I''m Walking', 'Marwood Williams - I''m Walking.mp3', 2)
INSERT INTO [dbo].[Songs] ([Title], [Author], [FileName], [DbPlaylistId])
	VALUES ('Thorn & Shout', 'All Things Magical', 'Thorn & Shout - All Things Magical.mp3', 2)
INSERT INTO [dbo].[Songs] ([Title], [Author], [FileName], [DbPlaylistId])
	VALUES ('Thorn & Shout', 'Caput Lupinum', 'Thorn & Shout - Caput Lupinum.mp3', 2)
INSERT INTO [dbo].[Songs] ([Title], [Author], [FileName], [DbPlaylistId])
	VALUES ('Todd Barrow', 'Guadalupe River', 'Todd Barrow - Guadalupe River.mp3', 2)

INSERT INTO [dbo].[Playlists] ([Title], [CoverUrl], [CategoryId])
	VALUES ('Jazz Cocktail', 'https://images.pexels.com/photos/733767/pexels-photo-733767.jpeg?cs=srgb&dl=pexels-victor-freitas-733767.jpg&fm=jpg', 2)

INSERT INTO [dbo].[Songs] ([Title], [Author], [FileName], [DbPlaylistId])
	VALUES ('Checkie Brown', 'Desinfect Ourselves', 'Checkie Brown - Desinfect Ourselves.mp3', 3)
INSERT INTO [dbo].[Songs] ([Title], [Author], [FileName], [DbPlaylistId])
	VALUES ('Dee Yan-Key', 'Gloomy Sky', 'Dee Yan-Key - Gloomy Sky.mp3', 3)
INSERT INTO [dbo].[Songs] ([Title], [Author], [FileName], [DbPlaylistId])
	VALUES ('Jesse Spillane', 'Organized Audio Crimes', 'Jesse Spillane - Organized Audio Crimes.mp3', 3)
INSERT INTO [dbo].[Songs] ([Title], [Author], [FileName], [DbPlaylistId])
	VALUES ('Ketsa', 'Good Vibe', 'Ketsa - Good Vibe.mp3', 3)
INSERT INTO [dbo].[Songs] ([Title], [Author], [FileName], [DbPlaylistId])
	VALUES ('Ketsa', 'Head Jive', 'Ketsa - Head Jive.mp3', 3)
INSERT INTO [dbo].[Songs] ([Title], [Author], [FileName], [DbPlaylistId])
	VALUES ('Ketsa', 'This Way For Joyous Street', 'Ketsa - This Way For Joyous Street.mp3', 3)
INSERT INTO [dbo].[Songs] ([Title], [Author], [FileName], [DbPlaylistId])
	VALUES ('Lobo Loco', 'Woke up This Morning', 'Lobo Loco - Woke up This Morning.mp3', 3)
INSERT INTO [dbo].[Songs] ([Title], [Author], [FileName], [DbPlaylistId])
	VALUES ('Till Paradiso', 'Breakfast Bread', 'Till Paradiso - Breakfast Bread.mp3', 3)
INSERT INTO [dbo].[Songs] ([Title], [Author], [FileName], [DbPlaylistId])
	VALUES ('Till Paradiso', 'Woke up This Morning', 'Till Paradiso - Woke up This Morning.mp3', 3)

INSERT INTO [dbo].[Playlists] ([Title], [CoverUrl], [CategoryId])
	VALUES ('Modern', 'https://images.pexels.com/photos/2347916/pexels-photo-2347916.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940', 2)

INSERT INTO [dbo].[Songs] ([Title], [Author], [FileName], [DbPlaylistId])
	VALUES ('Ainst Char', 'If you Itch, I''ll Scratch', 'Ainst Char - If you Itch, I''ll Scratch.mp3', 4)
INSERT INTO [dbo].[Songs] ([Title], [Author], [FileName], [DbPlaylistId])
	VALUES ('Checkie Brown', 'Pay Attention Duffy Duck', 'Checkie Brown - Pay Attention Duffy Duck.mp3', 4)
INSERT INTO [dbo].[Songs] ([Title], [Author], [FileName], [DbPlaylistId])
	VALUES ('Crowander', 'Sadpop', 'Crowander - Sadpop.mp3', 4)
INSERT INTO [dbo].[Songs] ([Title], [Author], [FileName], [DbPlaylistId])
	VALUES ('Electric Tric', 'Sketch 25', 'Electric Tric - Sketch 25.mp3', 4)
INSERT INTO [dbo].[Songs] ([Title], [Author], [FileName], [DbPlaylistId])
	VALUES ('Lobo Loco', 'Invasion of the Killer Sweets', 'Lobo Loco - Invasion of the Killer Sweets.mp3', 4)
INSERT INTO [dbo].[Songs] ([Title], [Author], [FileName], [DbPlaylistId])
	VALUES ('Nin Martoize', 'åtte', 'Nin Martoize - åtte.mp3', 4)
INSERT INTO [dbo].[Songs] ([Title], [Author], [FileName], [DbPlaylistId])
	VALUES ('Nin Martoize', 'Dreizehn', 'Nin Martoize - Dreizehn.mp3', 4)
INSERT INTO [dbo].[Songs] ([Title], [Author], [FileName], [DbPlaylistId])
	VALUES ('Nin Martoize', 'Penki', 'Nin Martoize - Penki.mp3', 4)