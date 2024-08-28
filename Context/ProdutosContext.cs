using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CSharp_API_Prod_ASPNET.Models;

namespace CSharp_API_Prod_ASPNET.Context
{
    public class ProdutosContext : DbContext
    {
        public ProdutosContext(DbContextOptions<ProdutosContext> options) : base(options){

        }

        public DbSet<Produto> Produtos{ get; set; }
    }
}