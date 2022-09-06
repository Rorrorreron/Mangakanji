
using Mangakanji.DATOS.REPOSITORIOS;
using System.Data.SqlClient;

namespace Mangakanji.DATOS
{

    public class CategoriaRepositorio : ICategoriaRepositorio
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
            using SqlCommand cmd = new SqlCommand("sp_obtener_categorias", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            sql.Open();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var nuevaCategoria = new Categoria { Id = (int)reader["Id"], Nombre = reader["Nombre"].ToString() };
                    listaCategorias.Add(nuevaCategoria);
                }
            }



            return listaCategorias;
        }

        public void CrearCategoria(Categoria categoria)
        {
            using SqlConnection sql = new SqlConnection(_configuration.GetConnectionString("conexionPorDefecto"));
            using SqlCommand cmd = new SqlCommand("sp_insertar_categoria", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@nombre", categoria.Nombre));
            sql.Open();
            cmd.ExecuteNonQuery();
        }

    }
}
