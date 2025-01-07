CREATE TABLE [dbo].[searched_places]
(
	[id] UNIQUEIDENTIFIER NOT NULL,
	[search_phase] NVARCHAR(MAX) NOT NULL,
	[inserted_on] DATETIMEOFFSET NOT NULL,
	CONSTRAINT [pk_searched_places] PRIMARY KEY ([id])
);

GO
CREATE INDEX [ix_searched_places_inserted_on] ON [dbo].[searched_places] ([inserted_on] DESC);