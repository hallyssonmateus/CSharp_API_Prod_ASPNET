using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CSharp_API_Prod_ASPNET.Models;
using CSharp_API_Prod_ASPNET.Context;

namespace CSharp_API_Prod_ASPNET.Controllers
{   
    [ApiController]
    [Route("[controller]")]
    public class InsercaoController : ControllerBase
    {   
        private readonly ProdutosContext _context;

        //Construtor
        public InsercaoController(ProdutosContext context){
            _context = context;
        }

        [HttpPost("Insercao")]
        public IActionResult Create(Produto produto){
            if(produto == null){
                return BadRequest();
            }

            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return Ok(produto);
        }

        [HttpGet("ObterporID/{Id}")]
        public IActionResult ObterporID(int Id){
            
            var produto = _context.Produtos.Find(Id);

            if(produto == null){
                return NotFound();
            }

            
            return Ok(produto);
        }

        [HttpGet("listagem")]
        public IActionResult ListarProdutos(){
            // Recupera todos os produtos do banco de dados
            var produtos = _context.Produtos.ToList();

            // Verifica se a lista de produtos está vazia
            if (produtos == null || !produtos.Any())
            {
                return NotFound("Nenhum produto encontrado.");
            }

            // Retorna a lista de produtos
            return Ok(produtos);
}

        [HttpPut("alteracao/{Id}")]
        public IActionResult Atualizar(int Id, Produto produto){
            
            var produtoBanco = _context.Produtos.Find(Id);

            if(produtoBanco == null){
                return NotFound();
            }

            produtoBanco.Nome = produto.Nome;
            produtoBanco.Tipo = produto.Tipo;
            produtoBanco.precoUnitario = produto.precoUnitario;

            _context.Produtos.Update(produtoBanco);
            _context.SaveChanges();
            
            return Ok(produtoBanco);
        }

        [HttpDelete("delecao/{Id}")]
        public IActionResult Deletar(int Id){
            
            var produtoBanco = _context.Produtos.Find(Id);

            if(produtoBanco == null){
                return NotFound();
            }

            _context.Produtos.Remove(produtoBanco);
            _context.SaveChanges();            
            return NoContent();
        }
    }
}