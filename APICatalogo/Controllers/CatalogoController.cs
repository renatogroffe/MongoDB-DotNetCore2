using Microsoft.AspNetCore.Mvc;

namespace APICatalogo.Controllers
{
    [Route("api/[controller]")]
    public class CatalogoController : Controller
    {
        private CatalogoContext _contexto;

        public CatalogoController(CatalogoContext context)
        {
            _contexto = context;
        }

        [HttpGet("produtos/{codigo}")]
        public IActionResult GetProduto(string codigo)
        {
            Produto prod = null;
            if (codigo.StartsWith("PROD"))
                prod = _contexto.ObterItem<Produto>(codigo);

            if (prod != null)
                return new ObjectResult(prod);
            else
                return NotFound();
        }

        [HttpGet("servicos/{codigo}")]
        public IActionResult GetServico(string codigo)
        {
            Servico serv = null;
            if (codigo.StartsWith("SERV"))
                serv = _contexto.ObterItem<Servico>(codigo);

            if (serv != null)
                return new ObjectResult(serv);
            else
                return NotFound();
        }
    }
}