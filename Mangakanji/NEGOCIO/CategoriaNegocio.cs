using Mangakanji.DATOS.REPOSITORIOS;
using Mangakanji.DTO;

namespace Mangakanji.NEGOCIO
{
	public class CategoriaNegocio : ICategoriaNegocio
	{
		private readonly ICategoriaRepositorio _categoriaRepositorio;

		public CategoriaNegocio(ICategoriaRepositorio categoriaRepositorio)
		{
			_categoriaRepositorio = categoriaRepositorio;
		}
		public List<CategoriaDTO> ObtenerCategorias()
		{
			var listaCategoriasDTO = new List<CategoriaDTO>();
			var listaCategoriasEntidades = _categoriaRepositorio.ObtenerTodas();
			foreach (var categoria in listaCategoriasEntidades)
			{
				var categoriaDTO = new CategoriaDTO { Id = categoria.Id, Nombre = categoria.Nombre };
				listaCategoriasDTO.Add(categoriaDTO);
			}

			return listaCategoriasDTO;
		}
	}
}
