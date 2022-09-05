using Mangakanji.NEGOCIO;
using System.Data.SqlClient;

namespace Mangakanji.DATOS
{

	public class CategoriaRepositorio
	{
		private readonly IConfiguration _configuration;

		public CategoriaRepositorio(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		public List<Categoria> ObtenerTodas()
		{
			var listaCategorias = new List<Categoria>();
			using SqlConnection sql = new SqlConnection(_configuration.GetConnectionString("conexionPorDefecto"));
			using SqlCommand cmd = new SqlCommand("select * from categorias", sql);
			sql.Open();
			using (var reader = cmd.ExecuteReader())
			{
				while (reader.Read())
				{
					var nuevaCategoria = new Categoria { Id = (int)reader["Id"], Nombre = reader["Nombre"].ToString()};
					listaCategorias.Add(nuevaCategoria);
				}
			}



			return listaCategorias;
		}
	}
}
