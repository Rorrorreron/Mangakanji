using Mangakanji.NEGOCIO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mangakanji.Pages
{
    public class testModel : PageModel
    {
        private readonly ICalculo _calculo;

        public testModel(ICalculo calculo)
        {
            _calculo = calculo;
        }

        [BindProperty]
        public int Numero1 { get; set; }
        [BindProperty]
        public int Numero2 { get; set; }
        public void OnGet()
        {
            //this.Numero1 = 123;
            //this.Numero2 = 321;
        }
        [BindProperty]
        public int? Resultado { get; set; }
        public void OnPost()
        {
            
            var resultado = _calculo.Operacion(this.Numero1, this.Numero2);
            
        }
    }
}
