create proc dbo.usp_FiltrarLista1Paginada
(
	@titulo nvarchar(200) = null,
	@artista nvarchar(200) = null,
	@genero nvarchar(200) = null,
	@page int = 1,
	@pageSize int = 5
) as
begin
	set nocount on;
	declare @inicio int = (@page - 1) * @pageSize
	select 
		id, title, artist, genre, release_date, uploader, upload_date, approbation, count(*) over() as TotalRegistros 
	from 
		dbo.Record_1
	where
		(@titulo is null or title like '%' + @titulo + '%') and
		(@artista is null or artist like '%' + @artista + '%') and
		(@genero is null or genre like '%' + @genero + '%')
	order by title
	offset @inicio rows
	fetch next @pageSize rows only
end