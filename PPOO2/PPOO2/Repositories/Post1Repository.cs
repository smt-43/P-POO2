using Microsoft.Data.SqlClient;
using PPOO2.Models;
using PPOO2.Models.ViewModels;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PPOO2.Repositories
{
    public class Post1Repository
    {
        private readonly string _connectionString;

        public Post1Repository(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public async Task<(List<ListPost1> record1, int TotalRegistros)> FiltrarPaginado1Async 
            (
                string titulo,
                string artista,
                string genero,
                int page = 1,
                int pageSize = 5
            )
        {
            var lista = new List<ListPost1>();
            int totalRegistros = 0;

            using (var con = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand("dbo.usp_FiltrarLista1Paginada", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@titulo", titulo);
                cmd.Parameters.AddWithValue("@artista", artista);
                cmd.Parameters.AddWithValue("@genero", genero);
                cmd.Parameters.AddWithValue("@page", page);
                cmd.Parameters.AddWithValue("@pageSize", pageSize);

                await con.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        if (totalRegistros == 0 && !reader.IsDBNull(reader.GetOrdinal("TotalRegistros")))
                        {
                            totalRegistros = Convert.ToInt32(reader["TotalRegistros"]);
                        }

                        var p = new ListPost1
                        {
                            id = reader["id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["id"]),
                            title = reader["title"] == DBNull.Value ? null : reader["title"].ToString(),
                            artist = reader["artist"] == DBNull.Value ? null : reader["artist"].ToString(),
                            genre = reader["genre"] == DBNull.Value ? null : reader["genre"].ToString(),
                            release_date = reader["release_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["release_date"]),
                            uploader = reader["uploader"] == DBNull.Value ? null : reader["uploader"].ToString(),
                            upload_date = reader["upload_date"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["upload_date"]),
                            approbation = reader["approbation"] == DBNull.Value ? false : Convert.ToBoolean(reader["approbation"])
                        };
                        lista.Add(p);
                    }
                }
            }
            return (lista, totalRegistros);
        }

    }
}
