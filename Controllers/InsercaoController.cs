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

        [HttpPost]
        public IActionResult Create(Produto produto){
            if(produto == null){
                return BadRequest();
            }

            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return Ok(produto);
        }


        
    }
}