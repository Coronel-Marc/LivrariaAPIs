using LivrariaAPIs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrariaController : ControllerBase
    {
        private readonly ToDoContext _context;

        public LivrariaController(ToDoContext context)
        {
            _context = context;

            _context.todoProducts.Add(new Produto { ID = "1", Nome = "Book 1", Preco = 225.0, Quant = 1, Categoria = "Ação", Img = "Img1" });
            _context.todoProducts.Add(new Produto { ID = "2", Nome = "Book 2", Preco = 5.0, Quant = 18, Categoria = "Ação", Img = "Img2" });
            _context.todoProducts.Add(new Produto { ID = "3", Nome = "Book 3", Preco = 45.0, Quant = 17, Categoria = "Ação", Img = "Img3" });
            _context.todoProducts.Add(new Produto { ID = "4", Nome = "Book 4", Preco = 77.0, Quant = 167, Categoria = "Ação", Img = "Img4" });
            _context.todoProducts.Add(new Produto { ID = "5", Nome = "Book 5", Preco = 373.0, Quant = 37, Categoria = "Ação", Img = "Img5" });

            _context.SaveChanges();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
        {
            return await _context.todoProducts.ToListAsync();
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult<Produto>> GetItem(int id)
        {
            var item = await _context.todoProducts.FindAsync(id.ToString());

            if(item == null)
            {
                return NotFound();
            }

            return item;
        }

        [HttpPost]

        public async Task<ActionResult<Produto>> PostProduto (Produto produto)
        {
            _context.todoProducts.Add(produto);

            return  produto;
        }
    }
}
