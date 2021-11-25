using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/inicializar")]
    public class InicializarDadosController : ControllerBase
    {
        private readonly DataContext _context;
        public InicializarDadosController(DataContext context)
        {
            _context = context;
        }

        //POST: api/inicializar/create
        [HttpPost]
        [Route("create")]
        public IActionResult Create()
        {
            _context.Categorias.AddRange(new Categoria[]
                {
                    new Categoria { CategoriaId = 1, Nome = "Alimentos" },
                }
            );
            _context.Produtos.AddRange(new Produto[]
                {
                    new Produto { ProdutoId = 1, Nome = "Arroz", Preco = 10, Quantidade = 19, CategoriaId = 1 },
                    new Produto { ProdutoId = 2, Nome = "Feijão", Preco = 8, Quantidade = 23, CategoriaId = 1 },
                    new Produto { ProdutoId = 3, Nome = "Batata", Preco = 6, Quantidade = 31, CategoriaId = 1 },
                    new Produto { ProdutoId = 3, Nome = "Carne", Preco = 12, Quantidade = 27, CategoriaId = 1 },
                    new Produto { ProdutoId = 3, Nome = "Macarrão", Preco = 4, Quantidade = 26, CategoriaId = 1 },
                }
            );
            _context.SaveChanges();
            return Ok(new { message = "Dados inicializados com sucesso!" });
        }
    }
}